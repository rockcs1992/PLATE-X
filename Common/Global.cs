using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
public class Global_Upload
{
    /// <summary>
    /// 新闻图片大小
    /// </summary>
    public static int Imgsize = 406900;

    /// <summary>
    /// 二维码图片
    /// </summary>
    public static string ErWeiImgPath = "/upload/ErWeiMa/";

    /// <summary>
    /// 资讯图片地址
    /// </summary>
    public static string NewsImgPath = "/upload/newsImg/";
    /// <summary>
    /// 资讯置顶图片地址
    /// </summary>
    public static string NewsTopImgPath = "/upload/newsImg/zhiding/";

    /// <summary>
    /// 催乳师资质图片和身份证
    /// </summary>
    public static string FriendImgPath = "/upload/fiendImg/";

    /// <summary>
    /// 品牌
    /// </summary>
    public static string BrandImgPath = "/upload/brandImg/";

    /// <summary>
    /// 产品图片
    /// </summary>
    public static string ProductImgPath = "/upload/productImg/";
    /// <summary>
    /// 用户头像地址
    /// </summary>
    public static string UsersImgPath = "/upload/users/";

    /// <summary>
    /// 广告图片地址
    /// </summary>
    public static string GuangGaoImgPath = "/upload/guangGao/";

 
    /// <summary>
    /// 经销商图片地址
    /// </summary>
    public static string ShoperResImgPath = "/upload/shoper/";

    /// <summary>
    /// 广告图片地址
    /// </summary>
    public static string UploadWxLogoPath = "/upload/wx/logo";

    /// <summary>
    /// 图片I am a
    /// </summary>
    public static string ImgType = ".jpg,.gif,.png,.bmp,.jpeg,.swf,.mp4,.3gp,.flv,.MP4,.MPEG4,.mpeg4";

   


    /// <summary>
    /// 是否启用缓存
    /// </summary>
    public static bool UseCache = ConfigHelper.GetConfigInt("UsedCache") == 1 ? true : false;



    /// <summary>
    /// 获得Upload文件的I am aItem Name
    /// </summary>
    /// <param name="filename">文件Item Name或者完整的路径</param>
    /// <returns></returns>
    public static string GetFileTypeName(string filename)
    {
        if (filename == "")
            return "";
        else
        {
            string ext = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            if (ext == "doc" || ext == "rtf")
                return "Word文档";
            else if (ext == "rar")
                return "压缩文件";
            else
                return "";
        }
    }

    /// <summary>
    /// 返回项目的根目录
    /// </summary>
    /// <returns></returns>
    public static string GetApplicationPath()
    {
        return HttpContext.Current.Request.ApplicationPath.TrimEnd('/');
    }
}