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
/// 图片Action(缩略图)
/// </summary>
public class ImageHelper
{


    /// <summary>
    /// 获取图像编码解码器的所有相关信息
    /// </summary>
    /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) I am a的字符串</param>
    /// <returns>返回图像编码解码器的所有相关信息</returns>
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
    /// 检测扩展名的有效性
    /// </summary>
    /// <param name="sExt">文件名扩展名</param>
    /// <returns>如果扩展名有效,返回true,否则返回false.</returns>
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
    /// Save图片
    /// </summary>
    /// <param name="image">Image 对象</param>
    /// <param name="savePath">Save路径</param>
    /// <param name="ici">指定格式的编解码参数</param>
    public static void SaveImage(System.Drawing.Image image, string savePath, ImageCodecInfo ici)
    {
        //设置 原图片 对象的 EncoderParameters 对象
        EncoderParameters parameters = new EncoderParameters(1);
        parameters.Param[0] = new EncoderParameter(Encoder.Quality, ((long)90));
        image.Save(savePath, ici, parameters);
        parameters.Dispose();
    }






    /// <summary>
    /// 按指定大小自动生成缩略图
    /// </summary>
    /// <param name="sourceImagePath">原图片路径(相对路径)</param>
    /// <param name="thumbnailImagePath">生成的缩略图路径,如果为空则Save为原图片路径(相对路径)</param>
    /// <param name="thumbnailImageWidth">缩略图的宽度</param>
    /// <param name="thumbnailImageHeight">缩略图的高度</param>
    /// <param name="backgroundcolor">缩略图的背景颜色,</param>
    public static void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight, string backgroundcolor)
    {
        string SourceImagePath = sourceImagePath;
        string ThumbnailImagePath = thumbnailImagePath;
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        if (!CheckValidExt(sExt))
        {
            throw new ArgumentException("原图片文件格式不correct,支持的格式有[ " + AllowExt + " ]", "SourceImagePath");
        }

        System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(SourceImagePath));

        Bitmap bitmap = new Bitmap(thumbnailImageWidth, thumbnailImageHeight, PixelFormat.Format32bppArgb);

        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;

        //计算出图像位置
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

        //填充背景颜色
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

        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。

        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);


        image.Dispose();
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数Save到指定文件 
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
    /// 按源图片比例自动生成缩略图
    /// </summary>
    /// <param name="sourceImagePath">原图片路径(相对路径)</param>
    /// <param name="thumbnailImagePath">生成的缩略图路径,如果为空则Save为原图片路径(相对路径)</param>
    /// <param name="thumbnailImageWidth">缩略图的宽度（高度与按源图片比例自动生成）</param>
    public static void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, string backgroundcolor)
    {
        string SourceImagePath = sourceImagePath;
        string ThumbnailImagePath = thumbnailImagePath;
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        if (!CheckValidExt(sExt))
        {
            throw new ArgumentException("原图片文件格式不correct,支持的格式有[ " + AllowExt + " ]", "SourceImagePath");
        }
        //从 原图片 创建 Image 对象
        System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(SourceImagePath));
        int num = ((ThumbnailImageWidth / 4) * 3);
        int width = image.Width;
        int height = image.Height;
        //计算图片的比例
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
        //用指定的大小和格式初始化 Bitmap 类的新实例
        Bitmap bitmap = new Bitmap(ThumbnailImageWidth, num, PixelFormat.Format32bppArgb);
        //从指定的 Image 对象创建新 Graphics 对象
        Graphics graphics = Graphics.FromImage(bitmap);
        //清除整个绘图面并以透明背景色填充
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

        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
        //在指定位置并且按指定大小绘制 原图片 对象
        graphics.DrawImage(image, new Rectangle(0, 0, ThumbnailImageWidth, num));
        image.Dispose();
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数Save到指定文件 
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






    #region 生成缩略图
    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式</param>    
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
            case "HW"://指定高宽缩放（可能变形）                
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
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

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(System.Drawing.Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);
        try
        {
            //以jpg格式Save缩略图
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

    #region 在图片上增加文字水印
    /// <summary>
    /// 在图片上增加文字水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_sy">生成的带文字水印的图片路径</param>
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

    #region 在图片上生成图片水印
    /// <summary>
    /// 加图片水印
    /// </summary>
    /// <param name="filename">文件名</param>
    /// <param name="watermarkFilename">水印文件名</param>
    /// <param name="watermarkStatus">图片水印位置:0=不使用 1=左上 2=中上 3=右上 4=左中 ... 9=右下</param>
    /// <param name="quality">是否是高质量图片 取值范围0--100</param> 
    /// <param name="watermarkTransparency">图片水印透明度 取值范围1--10 (10为不透明)</param>

    public static void AddImageSignPic(string Path, string filename, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
    {
        System.Drawing.Image img = System.Drawing.Image.FromFile(Path);
        Graphics g = Graphics.FromImage(img);

        //设置高质量插值法
        //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //设置高质量,低速度呈现平滑程度
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
    /// 在图片上生成图片水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_syp">生成的带图片水印的图片路径</param>
    /// <param name="Path_sypf">水印图片路径</param>
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
