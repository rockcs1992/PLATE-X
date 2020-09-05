using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.IO;

/// <summary>
/// ͼƬAction(����ͼ)
/// </summary>
public class ImageHelper
{


    /// <summary>
    /// ��ȡͼ���������������������Ϣ
    /// </summary>
    /// <param name="mimeType">��������������Ķ���;�����ʼ�����Э�� (MIME) I am a���ַ���</param>
    /// <returns>����ͼ���������������������Ϣ</returns>
    static ImageCodecInfo GetCodecInfo(string mimeType)
    {
        ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
        foreach (ImageCodecInfo ici in CodecInfo)
        {
            if (ici.MimeType == mimeType) return ici;
        }
        return null;
    }

    static internal readonly string AllowExt = "jpe|jpeg|jpg|png|tif|tiff|bmp|gif|wbmp|swf|psd";

    /// <summary>
    /// �����չ������Ч��
    /// </summary>
    /// <param name="sExt">�ļ�����չ��</param>
    /// <returns>�����չ����Ч,����true,���򷵻�false.</returns>
    public static bool CheckValidExt(string sExt)
    {
        bool flag = false;
        string[] aExt = AllowExt.Split('|');
        foreach (string filetype in aExt)
        {
            if (filetype.ToLower() == sExt.Replace(".", ""))
            {
                flag = true;
                break;
            }
        }
        return flag;
    }

    public static string GetHtmime(string ext)
    {
        Hashtable htmimes = new Hashtable();

        switch (ext.ToLower())
        {
            case ".jpe":
            case ".jpeg":
            case ".jpg":
                htmimes[ext] = "image/jpeg";
                break;
            case ".png":
                htmimes[ext] = "image/png";
                break;
            case ".tif":
            case ".tiff":
                htmimes[ext] = "image/tiff";
                break;
            case ".bmp":
                htmimes[ext] = "image/bmp";
                break;
            case ".gif":
                htmimes[ext] = "image/gif";
                break;
            case ".swf":
                htmimes[ext] = "image/swf";
                break;
            case ".wbmp":
                htmimes[ext] = "image/wbmp";
                break;
            case ".psd":
                htmimes[ext] = "image/psd";
                break;


        }
        return (string)htmimes[ext];
    }


    /// <summary>
    /// SaveͼƬ
    /// </summary>
    /// <param name="image">Image ����</param>
    /// <param name="savePath">Save·��</param>
    /// <param name="ici">ָ����ʽ�ı�������</param>
    public static void SaveImage(System.Drawing.Image image, string savePath, ImageCodecInfo ici)
    {
        //���� ԭͼƬ ����� EncoderParameters ����
        EncoderParameters parameters = new EncoderParameters(1);
        parameters.Param[0] = new EncoderParameter(Encoder.Quality, ((long)90));
        image.Save(savePath, ici, parameters);
        parameters.Dispose();
    }






    /// <summary>
    /// ��ָ����С�Զ���������ͼ
    /// </summary>
    /// <param name="sourceImagePath">ԭͼƬ·��(���·��)</param>
    /// <param name="thumbnailImagePath">���ɵ�����ͼ·��,���Ϊ����SaveΪԭͼƬ·��(���·��)</param>
    /// <param name="thumbnailImageWidth">����ͼ�Ŀ��</param>
    /// <param name="thumbnailImageHeight">����ͼ�ĸ߶�</param>
    /// <param name="backgroundcolor">����ͼ�ı�����ɫ,</param>
    public static void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight, string backgroundcolor)
    {
        string SourceImagePath = sourceImagePath;
        string ThumbnailImagePath = thumbnailImagePath;
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        if (!CheckValidExt(sExt))
        {
            throw new ArgumentException("ԭͼƬ�ļ���ʽ��correct,֧�ֵĸ�ʽ��[ " + AllowExt + " ]", "SourceImagePath");
        }

        System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(SourceImagePath));

        Bitmap bitmap = new Bitmap(thumbnailImageWidth, thumbnailImageHeight, PixelFormat.Format32bppArgb);

        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;

        //�����ͼ��λ��
        float defaultSizeScale = (float)thumbnailImageHeight / thumbnailImageWidth;
        float imageSizeScale = (float)image.Height / image.Width;

        if (defaultSizeScale > imageSizeScale)
        {
            dstLeft = 0;
            dstTop = (int)((thumbnailImageHeight - (imageSizeScale * thumbnailImageWidth)) / 2);
            dstWidth = thumbnailImageWidth;
            dstHeight = (int)(imageSizeScale * thumbnailImageWidth);
        }
        else if (defaultSizeScale == imageSizeScale)
        {
            dstLeft = 0;
            dstTop = 0;
            dstWidth = thumbnailImageWidth;
            dstHeight = thumbnailImageHeight;
        }
        else
        {
            dstLeft = (int)((thumbnailImageWidth - (thumbnailImageHeight / imageSizeScale)) / 2);
            dstTop = 0;
            dstWidth = (int)(thumbnailImageHeight / imageSizeScale);
            dstHeight = thumbnailImageHeight;
        }

        //��䱳����ɫ
        Graphics graphics = Graphics.FromImage(bitmap);
        if (string.IsNullOrEmpty(backgroundcolor))
            graphics.Clear(Color.Transparent);
        else
        {
            ColorConverter colorConverter = new ColorConverter();

            Color color = new Color();
            color = (Color)colorConverter.ConvertFromString(backgroundcolor);
            graphics.Clear(color);
        }

        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);

        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��

        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);


        image.Dispose();
        try
        {
            //���� ԭͼƬ ��ָ����ʽ����ָ���ı�������Save��ָ���ļ� 
            string savepath = (ThumbnailImagePath == null ? SourceImagePath : ThumbnailImagePath);
            SaveImage(bitmap, HttpContext.Current.Server.MapPath(savepath), GetCodecInfo(GetHtmime(sExt)));
       
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
        }
    }

    /// <summary>
    /// ��ԴͼƬ�����Զ���������ͼ
    /// </summary>
    /// <param name="sourceImagePath">ԭͼƬ·��(���·��)</param>
    /// <param name="thumbnailImagePath">���ɵ�����ͼ·��,���Ϊ����SaveΪԭͼƬ·��(���·��)</param>
    /// <param name="thumbnailImageWidth">����ͼ�Ŀ�ȣ��߶��밴ԴͼƬ�����Զ����ɣ�</param>
    public static void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, string backgroundcolor)
    {
        string SourceImagePath = sourceImagePath;
        string ThumbnailImagePath = thumbnailImagePath;
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        if (!CheckValidExt(sExt))
        {
            throw new ArgumentException("ԭͼƬ�ļ���ʽ��correct,֧�ֵĸ�ʽ��[ " + AllowExt + " ]", "SourceImagePath");
        }
        //�� ԭͼƬ ���� Image ����
        System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(SourceImagePath));
        int num = ((ThumbnailImageWidth / 4) * 3);
        int width = image.Width;
        int height = image.Height;
        //����ͼƬ�ı���
        if ((((double)width) / ((double)height)) >= 1.3333333333333333f)
        {
            num = ((height * ThumbnailImageWidth) / width);
        }
        else
        {
            ThumbnailImageWidth = ((width * num) / height);
        }
        if ((ThumbnailImageWidth < 1) || (num < 1))
        {
            return;
        }
        //��ָ���Ĵ�С�͸�ʽ��ʼ�� Bitmap �����ʵ��
        Bitmap bitmap = new Bitmap(ThumbnailImageWidth, num, PixelFormat.Format32bppArgb);
        //��ָ���� Image ���󴴽��� Graphics ����
        Graphics graphics = Graphics.FromImage(bitmap);
        //���������ͼ�沢��͸������ɫ���
        //graphics.Clear(Color.Transparent);

        if (string.IsNullOrEmpty(backgroundcolor))
            graphics.Clear(Color.Transparent);
        else
        {
            ColorConverter colorConverter = new ColorConverter();

            Color color = new Color();
            color = (Color)colorConverter.ConvertFromString(backgroundcolor);
            graphics.Clear(color);
        }

        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
        //��ָ��λ�ò��Ұ�ָ����С���� ԭͼƬ ����
        graphics.DrawImage(image, new Rectangle(0, 0, ThumbnailImageWidth, num));
        image.Dispose();
        try
        {
            //���� ԭͼƬ ��ָ����ʽ����ָ���ı�������Save��ָ���ļ� 
            string savepath = (ThumbnailImagePath == null ? SourceImagePath : ThumbnailImagePath);
            SaveImage(bitmap, HttpContext.Current.Server.MapPath(savepath), GetCodecInfo(GetHtmime(sExt)));
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
        }
    }






    #region ��������ͼ
    /// <summary>
    /// ��������ͼ
    /// </summary>
    /// <param name="originalImagePath">Դͼ·��������·����</param>
    /// <param name="thumbnailPath">����ͼ·��������·����</param>
    /// <param name="width">����ͼ���</param>
    /// <param name="height">����ͼ�߶�</param>
    /// <param name="mode">��������ͼ�ķ�ʽ</param>    
    public static void MakeThumbPhoto(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case "HW"://ָ���߿����ţ����ܱ��Σ�                
                break;
            case "W"://ָ�����߰�����                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://ָ���ߣ�������
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://ָ���߿�ü��������Σ�                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //�½�һ��bmpͼƬ
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //�½�һ������
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //���ø�������ֵ��
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //���ø�����,���ٶȳ���ƽ���̶�
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //��ջ�������͸������ɫ���
        g.Clear(System.Drawing.Color.Transparent);

        //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);
        try
        {
            //��jpg��ʽSave����ͼ
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }
    #endregion

    #region ��ͼƬ����������ˮӡ
    /// <summary>
    /// ��ͼƬ����������ˮӡ
    /// </summary>
    /// <param name="Path">ԭ������ͼƬ·��</param>
    /// <param name="Path_sy">���ɵĴ�����ˮӡ��ͼƬ·��</param>
    protected void AddWater(string Path, string Path_sy)
    {
        string addText = "jumbot.net";
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(image, 0, 0, image.Width, image.Height);
        System.Drawing.Font f = new System.Drawing.Font("Verdana", 60);
        System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);

        g.DrawString(addText, f, b, 35, 35);
        g.Dispose();

        image.Save(Path_sy);
        image.Dispose();
    }
    #endregion

    #region ��ͼƬ������ͼƬˮӡ
    /// <summary>
    /// ��ͼƬˮӡ
    /// </summary>
    /// <param name="filename">�ļ���</param>
    /// <param name="watermarkFilename">ˮӡ�ļ���</param>
    /// <param name="watermarkStatus">ͼƬˮӡλ��:0=��ʹ�� 1=���� 2=���� 3=���� 4=���� ... 9=����</param>
    /// <param name="quality">�Ƿ��Ǹ�����ͼƬ ȡֵ��Χ0--100</param> 
    /// <param name="watermarkTransparency">ͼƬˮӡ͸���� ȡֵ��Χ1--10 (10Ϊ��͸��)</param>

    public static void AddImageSignPic(string Path, string filename, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
    {
        System.Drawing.Image img = System.Drawing.Image.FromFile(Path);
        Graphics g = Graphics.FromImage(img);

        //���ø�������ֵ��
        //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //���ø�����,���ٶȳ���ƽ���̶�
        //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        System.Drawing.Image watermark = new Bitmap(watermarkFilename);

        if (watermark.Height >= img.Height || watermark.Width >= img.Width)
        {
            return;
        }

        ImageAttributes imageAttributes = new ImageAttributes();
        ColorMap colorMap = new ColorMap();

        colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
        colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
        ColorMap[] remapTable = { colorMap };

        imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

        float transparency = 0.5F;
        if (watermarkTransparency >= 1 && watermarkTransparency <= 10)
        {
            transparency = (watermarkTransparency / 10.0F);
        }

        float[][] colorMatrixElements = {
												new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
												new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
												new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
												new float[] {0.0f,  0.0f,  0.0f,  transparency, 0.0f},
												new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
											};

        ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

        imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

        int xpos = 0;
        int ypos = 0;

        switch (watermarkStatus)
        {
            case 1:
                xpos = (int)(img.Width * (float).01);
                ypos = (int)(img.Height * (float).01);
                break;
            case 2:
                xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                ypos = (int)(img.Height * (float).01);
                break;
            case 3:
                xpos = (int)((img.Width * (float).99) - (watermark.Width));
                ypos = (int)(img.Height * (float).01);
                break;
            case 4:
                xpos = (int)(img.Width * (float).01);
                ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                break;
            case 5:
                xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                break;
            case 6:
                xpos = (int)((img.Width * (float).99) - (watermark.Width));
                ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                break;
            case 7:
                xpos = (int)(img.Width * (float).01);
                ypos = (int)((img.Height * (float).99) - watermark.Height);
                break;
            case 8:
                xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                ypos = (int)((img.Height * (float).99) - watermark.Height);
                break;
            case 9:
                xpos = (int)((img.Width * (float).99) - (watermark.Width));
                ypos = (int)((img.Height * (float).99) - watermark.Height);
                break;
        }

        g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);

        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        ImageCodecInfo ici = null;
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.MimeType.IndexOf("jpeg") > -1)
            {
                ici = codec;
            }
        }
        EncoderParameters encoderParams = new EncoderParameters();
        long[] qualityParam = new long[1];
        if (quality < 0 || quality > 100)
        {
            quality = 80;
        }
        qualityParam[0] = quality;

        EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualityParam);
        encoderParams.Param[0] = encoderParam;

        if (ici != null)
        {
            img.Save(filename, ici, encoderParams);
        }
        else
        {
            img.Save(filename);
        }

        g.Dispose();
        img.Dispose();
        watermark.Dispose();
        imageAttributes.Dispose();
    }

    /// <summary>
    /// ��ͼƬ������ͼƬˮӡ
    /// </summary>
    /// <param name="Path">ԭ������ͼƬ·��</param>
    /// <param name="Path_syp">���ɵĴ�ͼƬˮӡ��ͼƬ·��</param>
    /// <param name="Path_sypf">ˮӡͼƬ·��</param>
    protected void AddWaterPic(string Path, string Path_syp, string Path_sypf)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
        g.Dispose();

        image.Save(Path_syp);
        image.Dispose();
    }
    #endregion




}
