using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;





/// <summary>
/// ����ˮӡ������ͼ��������ָ�����ݵ�ͼƬ
/// </summary>
public class FSImage
{
    private int _width;
    private int _height;
    private string _title = "www.netcms";    //���ֱ���
    private Color _bgcolor = Color.White;
    private int _fontsize = 14;  //�ֺ�
    private string _familyname = "����";   //����
    private FontStyle _fontstyle = FontStyle.Regular;
    private Color _forcecolor = Color.Black;
    private string _filepath = "";   //��ȡ·�����ļ���
    private PointF _txtpos;
    private long _quality = 100;
    private string _waterpos = "0";
    private string _waterpath = "";
    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="width">����ͼƬ�Ŀ�ȡ�
    /// ���С�ڻ�����㣺�߶�ҲС�ڻ�����㣬��ͼƬ��ԭͼ�Ĵ�С��ˮӡ������ͼ����������ֵĴ�С����ͼƬ����߶ȴ����㣬�򰴸߶����ȱ�������ԭͼ
    /// ��������㣺�߶�Ҳ�����㣬��ָ����С������ͼƬ������߶�С�ڵ����㣬�򰴿�����ȱȽ�����ͼƬ</param>
    /// <param name="height">ͼƬ�߶ȣ���ͼƬ���ע��</param>
    /// <param name="filepath">ԭ�ļ��������·����ˮӡ������ͼ����Save�ļ�·��������������ͼƬ��</param>
    public FSImage(int width, int height, string filepath)
    {
        _txtpos = new PointF(-1, -1);
        _width = width;
        _height = height;
        _filepath = filepath.Replace("/", "\\");
    }
    /// <summary>
    /// ˮӡ������ͼƬ������,Ĭ��Ϊ:www.netcms
    /// </summary>
    public string Title
    {
        set { _title = value; }
        get { return _title; }
    }
    /// <summary>
    /// ������Ϊ��λ�������С��Ĭ��Ϊ��14
    /// </summary>
    public int FontSize
    {
        get { return _fontsize; }
        set { _fontsize = value; }
    }
    /// <summary>
    /// ������ͼƬ�ı���ɫ,Ĭ��Ϊ͸��
    /// </summary>
    public Color BackGroudColor
    {
        get { return _bgcolor; }
        set { _bgcolor = value; }
    }
    /// <summary>
    /// ���õ�����Item Name,Ĭ��Ϊ������
    /// </summary>
    public string FontFamilyName
    {
        get { return _familyname; }
        set { _familyname = value; }
    }
    /// <summary>
    /// ����������ʽ,Ĭ��Ϊ��ͨ�ı�
    /// </summary>
    public FontStyle StrStyle
    {
        set { _fontstyle = value; }
        get { return _fontstyle; }
    }
    /// <summary>
    /// ˮӡ���ֵ���ɫ,Ĭ��Ϊ��ɫ
    /// </summary>
    public Color FontColor
    {
        set { _forcecolor = value; }
        get { return _forcecolor; }
    }
    /// <summary>
    /// ˮӡ�ı���λ������,��ͼƬ�����Ͻ�Ϊԭ��,Ĭ��λ��ΪͼƬ�����½�
    /// ���x����С������������ͼƬ���ұ�,���y����С��0��������ͼƬ���±�
    /// ����ʱע�����λ���Ǵ����ֵ����Ͻ�Ϊԭ��,��(0,0)��ʾ������ͼƬ�����Ͻ�
    /// </summary>
    public PointF TextPos
    {
        set { _txtpos.X = value.X; _txtpos.Y = value.Y; }
        get { return _txtpos; }
    }

    /// <summary>
    /// ���ͼƬ������������Χ0-100,I am aΪlong
    /// </summary>
    public long Quality
    {
        get { return _quality; }
        set { _quality = value; }
    }

    /// <summary>
    /// ˮӡλ��
    /// </summary>
    public string Waterpos
    {
        get { return _waterpos; }
        set { _waterpos = value; }
    }

    /// <summary>
    /// ˮӡͼƬ���
    /// </summary>
    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }

    /// <summary>
    /// ˮӡͼƬ�߶�
    /// </summary>
    public int Height
    {
        get { return _height; }
        set { _height = value; }
    }

    /// <summary>
    /// ˮӡͼƬ��ַ
    /// </summary>
    public string WaterPath
    {
        get { return _waterpath; }
        set { _waterpath = value; }
    }

    /// <summary>
    /// ��������ˮӡ
    /// </summary>
    public void Watermark()
    {
        if (_title == null || _title.Equals(""))
            throw new NullReferenceException("ͼƬ����Ϊ��!");
        ImageFormat format = GetFormat();
        if (!File.Exists(_filepath))
            throw new FileNotFoundException("ָ��·�����ļ�������");
        Graphics g;
        Bitmap bitmap = GetBitmap(out g);
        Font f = new Font(_familyname, _fontsize, _fontstyle, GraphicsUnit.Pixel);
        SizeF size = g.MeasureString(_title, f);
        switch (_waterpos)
        {
            case "1":
                _txtpos.X = ((float)_width * (float).01) + (size.Width / 2) - 20;
                _txtpos.Y = (float)_height * (float).01;
                break;
            case "3":
                _txtpos.X = ((float)_width * (float).99) - (size.Width);
                _txtpos.Y = (float)_height * (float).01;
                break;
            case "4":
                _txtpos.X = ((float)_width * (float).99) - (size.Width);
                _txtpos.Y = ((float)_height * (float).99) - size.Height;
                break;
            case "2":
                _txtpos.X = ((float)_width * (float).01) + (size.Width / 2) - 20;
                _txtpos.Y = ((float)_height * (float).99) - size.Height;
                break;
            default:
                _txtpos.X = ((float)_width * (float).50) - 20;
                _txtpos.Y = ((float)_height * (float).50);
                break;
        }
        Brush b = new SolidBrush(_forcecolor);
        g.DrawString(_title, f, b, _txtpos);
        g.Dispose();
        bitmap.Save(_filepath, format);
        bitmap.Dispose();
    }
    /// <summary>
    /// ��������ͼ
    /// </summary>
    /// <param name="newpath">����ͼ��Save����·���������ļ����������Ϊnull����򸲸�ԭͼ</param>
    public void Thumbnail(string newpath)
    {
        ImageFormat format = GetFormat();
        if (!File.Exists(_filepath))
            throw new FileNotFoundException("ָ��·�����ļ�������");
        Graphics g;
        Bitmap bitmap = GetBitmap(out g);
        if (newpath == null || newpath.Trim().Equals(""))
            bitmap.Save(_filepath, format);
        else
        {
            newpath = newpath.Replace("/", "\\");
            if (newpath.IndexOf("\\") > 0)
            {
                string dir = newpath.Substring(0, newpath.LastIndexOf("\\"));
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
            bitmap.Save(newpath, format);
        }
        g.Dispose();
        bitmap.Dispose();
    }
    /// <summary>
    /// �����ı�ͼƬ
    /// </summary>
    public void GenerateTextPic()
    {
        if (_title == null || _title.Equals(""))
            throw new NullReferenceException("ͼƬ����Ϊ��!");

        ImageFormat format = GetFormat();

        Font f = new Font(_familyname, _fontsize, _fontstyle, GraphicsUnit.Pixel);
        Bitmap _bitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        Graphics _g = Graphics.FromImage(_bitmap);
        SizeF size = _g.MeasureString(_title, f);
        _g.Dispose();
        _bitmap.Dispose();
        double rate = size.Height / size.Width;
        if (_width <= 0 && _height <= 0)
        {
            _width = (int)size.Width;
            _height = (int)size.Height;
        }
        else if (_width > 0 && _height <= 0)
        {
            _height = (int)(_width * rate);
        }
        else if (_width <= 0 && _height > 0)
        {
            _width = (int)(_height / rate);
        }
        Bitmap bitmap = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);
        Graphics g = Graphics.FromImage(bitmap);
        g.Clear(_bgcolor);
        if (_txtpos.X < 0)
            _txtpos.X = _width - size.Width;
        if (_txtpos.Y < 0)
            _txtpos.Y = _height - size.Height;
        Brush b = new SolidBrush(_forcecolor);
        g.DrawString(_title, f, b, _txtpos);
        g.Dispose();
        if (_filepath.IndexOf("\\") > 0)
        {
            string dir = _filepath.Substring(0, _filepath.LastIndexOf("\\"));
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
        bitmap.Save(_filepath, format);
        bitmap.Dispose();
    }
    /// <summary>
    /// ����ָ���Ĵ�С����ͼƬ������ԭͼ���ƹ�ȥ
    /// </summary>
    /// <param name="graphics"></param>
    /// <returns></returns>
    private Bitmap GetBitmap(out Graphics graphics)
    {
        //�ж��ļ�I am a�Ƿ�Ϊͼ��I am a
        Image image = Image.FromFile(_filepath);
        int x = image.Width;
        int y = image.Height;
        double rate = (float)y / (float)x;
        if (_width <= 0 && _height <= 0)
        {
            _width = x;
            _height = y;
        }
        else if (_width > 0 && _height <= 0)
        {
            _height = (int)(_width * rate);
        }
        else if (_width <= 0 && _height > 0)
        {
            _width = (int)(_height / rate);
        }
        Bitmap bitmap = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);
        graphics = Graphics.FromImage(bitmap);
        graphics.Clear(_bgcolor);
        graphics.DrawImage(image, new Rectangle(0, 0, _width, _height));
        image.Dispose();
        return bitmap;
    }
    /// <summary>
    /// �����ļ���չ��ȡ��ͼƬ�ĸ�ʽ
    /// </summary>
    /// <returns></returns>
    private ImageFormat GetFormat()
    {
        if (_filepath == null || _filepath.IndexOf(".") < 0)
            throw new FileNotFoundException("�ļ�·������Ϊ�ջ����ļ�����correct!");
        string extend = _filepath.Substring(_filepath.LastIndexOf(".")).ToLower();
        switch (extend)
        {
            case ".jpe":
                return ImageFormat.Jpeg;
            case ".jpeg":
                return ImageFormat.Jpeg;
            case ".jpg":
                return ImageFormat.Jpeg;
            case ".png":
                return ImageFormat.Png;
            case ".tif":
                return ImageFormat.Tiff;
            case ".tiff":
                return ImageFormat.Tiff;
            case ".bmp":
                return ImageFormat.Bmp;
            case ".gif":
                return ImageFormat.Gif;
            default:
                throw new FormatException("�ļ���ʽ����֧��!");
        }
    }


    /// <summary>
    ///  ����ͼƬˮӡ
    /// </summary>
    public void WaterPicturemark()
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(_filepath);
        Bitmap b = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
        Graphics g = Graphics.FromImage(b);

        g.Clear(Color.White);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        g.DrawImage(image, 0, 0, image.Width, image.Height);

        WaterPicturmark(g, image.Height, image.Width);
        image.Dispose();

        b.Save(_filepath);
        b.Dispose();
    }

    protected void WaterPicturmark(Graphics g, int height, int width)
    {
        Image watermark = new Bitmap(_waterpath);
        ImageAttributes imageAttributes = new ImageAttributes();
        ColorMap colorMap = new ColorMap();
        colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
        colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
        ColorMap[] remapTable = { colorMap };
        imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
        float[][] colorMatrixElements = {
                                                new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                            };
        ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
        imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        int xpos = 0;
        int ypos = 0;
        int WatermarkWidth = 0;
        int WatermarkHeight = 0;
        double bl = 1d;
        //����ˮӡͼƬ�ı���
        //ȡ������1/4������Ƚ�
        if ((width > watermark.Width * 4) && (height > watermark.Height * 4))
        {
            bl = 1;
        }
        else if ((width > watermark.Width * 4) && (height < watermark.Height * 4))
        {
            bl = Convert.ToDouble(height / 4) / Convert.ToDouble(watermark.Height);
        }
        else if ((width < watermark.Width * 4) && (height > watermark.Height * 4))
        {
            bl = Convert.ToDouble(width / 4) / Convert.ToDouble(watermark.Width);
        }
        else
        {
            if ((width * watermark.Height) > (_height * watermark.Width))
            {
                bl = Convert.ToDouble(height / 4) / Convert.ToDouble(watermark.Height);
            }
            else
            {
                bl = Convert.ToDouble(width / 4) / Convert.ToDouble(watermark.Width);
            }
        }

        WatermarkWidth = Convert.ToInt32(watermark.Width * bl);
        WatermarkHeight = Convert.ToInt32(watermark.Height * bl);

        switch (_waterpos)
        {
            case "1":
                xpos = 10;
                ypos = 10;
                break;
            case "3":
                xpos = width - WatermarkWidth - 10;
                ypos = 10;
                break;
            case "4":
                xpos = width - WatermarkWidth - 10;
                ypos = height - WatermarkHeight - 10;
                break;
            case "2":
                xpos = 10;
                ypos = height - WatermarkHeight - 10;
                break;
            default:
                xpos = Convert.ToInt32(width / 2) - (WatermarkWidth / 2);
                ypos = Convert.ToInt32(height / 2) - (WatermarkHeight / 2);
                break;
        }
        g.DrawImage(watermark, new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);
        watermark.Dispose();
        imageAttributes.Dispose();
    }
}

