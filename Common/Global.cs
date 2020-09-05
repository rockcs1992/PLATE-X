using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
public class Global_Upload
{
    /// <summary>
    /// ����ͼƬ��С
    /// </summary>
    public static int Imgsize = 406900;

    /// <summary>
    /// ��ά��ͼƬ
    /// </summary>
    public static string ErWeiImgPath = "/upload/ErWeiMa/";

    /// <summary>
    /// ��ѶͼƬ��ַ
    /// </summary>
    public static string NewsImgPath = "/upload/newsImg/";
    /// <summary>
    /// ��Ѷ�ö�ͼƬ��ַ
    /// </summary>
    public static string NewsTopImgPath = "/upload/newsImg/zhiding/";

    /// <summary>
    /// ����ʦ����ͼƬ�����֤
    /// </summary>
    public static string FriendImgPath = "/upload/fiendImg/";

    /// <summary>
    /// Ʒ��
    /// </summary>
    public static string BrandImgPath = "/upload/brandImg/";

    /// <summary>
    /// ��ƷͼƬ
    /// </summary>
    public static string ProductImgPath = "/upload/productImg/";
    /// <summary>
    /// �û�ͷ���ַ
    /// </summary>
    public static string UsersImgPath = "/upload/users/";

    /// <summary>
    /// ���ͼƬ��ַ
    /// </summary>
    public static string GuangGaoImgPath = "/upload/guangGao/";

 
    /// <summary>
    /// ������ͼƬ��ַ
    /// </summary>
    public static string ShoperResImgPath = "/upload/shoper/";

    /// <summary>
    /// ���ͼƬ��ַ
    /// </summary>
    public static string UploadWxLogoPath = "/upload/wx/logo";

    /// <summary>
    /// ͼƬI am a
    /// </summary>
    public static string ImgType = ".jpg,.gif,.png,.bmp,.jpeg,.swf,.mp4,.3gp,.flv,.MP4,.MPEG4,.mpeg4";

   


    /// <summary>
    /// �Ƿ����û���
    /// </summary>
    public static bool UseCache = ConfigHelper.GetConfigInt("UsedCache") == 1 ? true : false;



    /// <summary>
    /// ���Upload�ļ���I am aItem Name
    /// </summary>
    /// <param name="filename">�ļ�Item Name����������·��</param>
    /// <returns></returns>
    public static string GetFileTypeName(string filename)
    {
        if (filename == "")
            return "";
        else
        {
            string ext = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            if (ext == "doc" || ext == "rtf")
                return "Word�ĵ�";
            else if (ext == "rar")
                return "ѹ���ļ�";
            else
                return "";
        }
    }

    /// <summary>
    /// ������Ŀ�ĸ�Ŀ¼
    /// </summary>
    /// <returns></returns>
    public static string GetApplicationPath()
    {
        return HttpContext.Current.Request.ApplicationPath.TrimEnd('/');
    }
}