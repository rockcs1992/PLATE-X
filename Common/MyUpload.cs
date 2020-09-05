
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
/// <summary>
/// MyUpload 的摘要说明
/// </summary>
public class MyUpload
{
    public MyUpload()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    private System.Web.HttpPostedFile postedFile = null;
    private string savePath = "";
    private string extension = "";
    private int fileLength = 0;
    private string setfilenme = "";
    //显示该组件使用的参数信息
    public string Help
    {
        get
        {
            string helpstring;
            helpstring = "<font size=3>MyUpload myUpload=new MyUpload(); //构造函数";
            helpstring += "myUpload.PostedFile=file1.PostedFile;//设置要Upload的文件";
            helpstring += "myUpload.SavePath=\"e:\\\";//设置要Upload到服务器的路径，默认c:\\";
            helpstring += "myUpload.FileLength=100; //设置Upload文件的最大长度，单位k，默认1k";
            helpstring += "myUpload.Extension=\"doc\";设置Upload文件的扩展名，默认txt";
            helpstring += "label1.Text=myUpload.Upload();//开始Upload，并显示Upload结果</font>";
            helpstring += "<font size=3 color=red>Design By WengMingJun 2001-12-12 All Right Reserved!</font>";
            return helpstring;
        }
    }



    public System.Web.HttpPostedFile PostedFile
    {
        get
        {
            return postedFile;
        }
        set
        {
            postedFile = value;
        }
    }



    public string SavePath
    {
        get
        {
            if (savePath != "") return savePath;
            return "c:\\";
        }
        set
        {
            savePath = value;
        }
    }



    public int FileLength
    {
        get
        {
            if (fileLength != 0) return fileLength;
            return 1024;
        }
        set
        {
            fileLength = value * 1024;
        }
    }



    public string Extension
    {
        get
        {
            if (extension != "") return extension;
            return "txt";
        }
        set
        {
            extension = value;
        }
    }



    public string PathToName(string path)
    {
        int pos = path.LastIndexOf("\\");
        return path.Substring(pos + 1);
    }



    public string Upload()
    {
        string strMappath = "";
        if (this.PostedFile != null || this.PostedFile.ToString() != "")
        {
            try
            {
                string type1 = this.PostedFile.FileName.Substring(this.PostedFile.FileName.LastIndexOf(".") + 1);
                string fileName = PathToName(PostedFile.FileName);
                if (type1 != "")
                {
                    if (!type(type1))
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('请Upload'+'" + Extension + "'+'文件');</script>");
                        //"请Upload "+Extension+" 文件!";
                        return "";

                    }
                    if (PostedFile.ContentLength > FileLength)
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('文件太大了!');</script>");
                        return "";
                    }
                    //postedFile.SaveAs(SavePath+fileName);
                    strMappath = this.savePath + System.DateTime.Now.ToFileTimeUtc() + "." + type1;
                    PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(strMappath));
                    return strMappath;
                }
                else
                {
                    strMappath = "";
                }
            }
            catch
            {
            }
        }
        else
        {
            return "";
        }
        return strMappath;
    }
    /// <summary>
    /// 文件Upload Return -1="文件I am a有问题" 0="文件超过指定大小"
    /// </summary>
    /// <returns>Return -1="文件I am a有问题" 0="文件超过指定大小"</returns>
    public string UploadRes(int userid)
    {
        string strMappath = "";
        if (this.PostedFile != null || this.PostedFile.FileName.ToString() != "")
        {
            try
            {
                string type1 = this.PostedFile.FileName.Substring(this.PostedFile.FileName.LastIndexOf(".") + 1).ToLower();
                string fileName = PathToName(PostedFile.FileName);
                if (!type(type1))
                {
                    //System.Web.HttpContext.Current.Response.Write("<script>alert('请Upload'+'"+Extension+"'+'文件');</script>");
                    //"请Upload "+Extension+" 文件!";
                    return "-1";

                }
                if (PostedFile.ContentLength > fileLength)
                {
                    //System.Web.HttpContext.Current.Response.Write("<script>alert('文件太大了!');</script>");
                    return "0";
                }
                if (this.setfilenme != "")
                {
                    strMappath = setfilenme;
                }
                else
                {
                    strMappath = Text.OrderID() + RndStr(5, true) +"." + type1;
                }

                if (!Directory.Exists(HttpContext.Current.Server.MapPath("/Resources/" + userid.ToString() + "/")))//判断目录是否存在
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Resources/" + userid.ToString() + "/"));//创建目录
                }

                string strym = DateTime.Now.ToString("yyyy-MM-dd");

                if (!Directory.Exists(HttpContext.Current.Server.MapPath("/Resources/"+ userid.ToString()+"/" + strym + "/")))//判断目录是否存在
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Resources/"+userid.ToString()+"/" + strym + "/"));//创建目录
                }
                string path = this.savePath+userid.ToString()+"/" + strym +"/"+ strMappath;
                PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path));
                return this.SavePath + userid.ToString() + "/" + strym + "/" + strMappath;
            }
            catch
            {
            }
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('请选择要Upload的文件!');</script>");
            return "";
        }
        return strMappath;
    }
    public bool type(string aa)
    {
        if (this.Extension.IndexOf(aa) < 0)
            return false;
        else
            return true;
    }

    /// <summary>
    /// 生成随机字母与数字
    /// </summary>
    /// <param name="Length">生成长度</param>
    /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
    /// <returns>随机串</returns>
    public static string RndStr(int Length, bool Sleep)
    {
        if (Sleep)
            System.Threading.Thread.Sleep(1);
        char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        string result = "";
        int n = Pattern.Length;
        System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
        for (int i = 0; i < Length; i++)
        {
            int rnd = random.Next(0, n);
            result += Pattern[rnd];
        }
        return result;
    }

}



#region 此类功能同上

/// <summary>
/// MyUpload 的摘要说明。
/// </summary>
public class FileUpload1
{
    public FileUpload1()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    private System.Web.HttpPostedFile postedFile = null;
    private string savePath = "";
    private string extension = "";
    private int fileLength = 0;
    private string setfilenme = "";

    /// <summary>
    /// 设置文件名，直接覆盖文件
    /// </summary>
    public string SetFileName
    {
        set
        {
            setfilenme = value;
        }
    }
    //显示该组件使用的参数信息
    public string Help
    {
        get
        {
            string helpstring;
            helpstring = "<font size=3>MyUpload myUpload=new MyUpload(); //构造函数";
            helpstring += "myUpload.PostedFile=file1.PostedFile;//设置要Upload的文件";
            helpstring += "myUpload.SavePath=\"e:\\\";//设置要Upload到服务器的路径，默认c:\\";
            helpstring += "myUpload.FileLength=100; //设置Upload文件的最大长度，单位k，默认1k";
            helpstring += "myUpload.Extension=\"doc\";设置Upload文件的扩展名，默认txt";
            helpstring += "label1.Text=myUpload.Upload();//开始Upload，并显示Upload结果</font>";
            helpstring += "<font size=3 color=red>Design By WengMingJun 2001-12-12 All Right Reserved!</font>";
            return helpstring;
        }
    }



    public System.Web.HttpPostedFile PostedFile
    {
        get
        {
            return postedFile;
        }
        set
        {
            postedFile = value;
        }
    }



    public string SavePath
    {
        get
        {
            if (savePath != "") return savePath;
            return "c:\\";
        }
        set
        {
            savePath = value;
        }
    }



    public int FileLength
    {
        get
        {
            if (fileLength != 0) return fileLength;
            return 1024;
        }
        set
        {
            fileLength = value * 1024;
        }
    }



    public string Extension
    {
        get
        {
            if (extension != "") return extension;
            return "txt";
        }
        set
        {
            extension = value;
        }
    }



    public string PathToName(string path)
    {
        int pos = path.LastIndexOf("\\");
        return path.Substring(pos + 1);
    }



    /// <summary>
    /// 文件Upload Return -1="文件I am a有问题" 0="文件超过指定大小"
    /// </summary>
    /// <returns>Return -1="文件I am a有问题" 0="文件超过指定大小"</returns>
    public string Upload()
    {
        string strMappath = "";
        if (this.PostedFile != null || this.PostedFile.FileName.ToString() != "")
        {
            try
            {
                string type1 = this.PostedFile.FileName.Substring(this.PostedFile.FileName.LastIndexOf(".") + 1).ToLower();
                string fileName = PathToName(PostedFile.FileName);
                if (!type(type1))
                {
                    //System.Web.HttpContext.Current.Response.Write("<script>alert('请Upload'+'"+Extension+"'+'文件');</script>");
                    //"请Upload "+Extension+" 文件!";
                    return "-1";

                }
                if (PostedFile.ContentLength > FileLength)
                {
                    //System.Web.HttpContext.Current.Response.Write("<script>alert('文件太大了!');</script>");
                    return "0";
                }
                if (this.setfilenme != "")
                {
                    strMappath = setfilenme;
                }
                else {
                    strMappath = Text.OrderID() + "." + type1;
                }
               
                PostedFile.SaveAs(this.SavePath + strMappath);
                return strMappath;
            }
            catch
            {
            }
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('请选择要Upload的文件!');</script>");
            return "";
        }
        return strMappath;
    }
    /// <summary>
    /// 文件Upload Return -1="文件I am a有问题" 0="文件超过指定大小"
    /// </summary>
    /// <returns>Return -1="文件I am a有问题" 0="文件超过指定大小"</returns>
    public string UploadRes()
    {
        string strMappath = "";
        if (this.PostedFile != null || this.PostedFile.FileName.ToString() != "")
        {
            try
            {
                string type1 = this.PostedFile.FileName.Substring(this.PostedFile.FileName.LastIndexOf(".") + 1).ToLower();
                string fileName = PathToName(PostedFile.FileName);
                if (!type(type1))
                {
                    //System.Web.HttpContext.Current.Response.Write("<script>alert('请Upload'+'"+Extension+"'+'文件');</script>");
                    //"请Upload "+Extension+" 文件!";
                    return "-1";

                }
                if (PostedFile.ContentLength > fileLength)
                {
                    //System.Web.HttpContext.Current.Response.Write("<script>alert('文件太大了!');</script>");
                    return "0";
                }
                if (this.setfilenme != "")
                {
                    strMappath = setfilenme;
                }
                else
                {
                    strMappath = Text.OrderID() + "." + type1;
                }

                string strym = DateTime.Now.ToString("yyyy-MM");

                if (!Directory.Exists(HttpContext.Current.Server.MapPath("/Resources/" + strym + "/")))//判断目录是否存在
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Resources/" + strym + "/"));//创建目录
                }

                PostedFile.SaveAs(this.SavePath +strym+ strMappath);
                return this.SavePath + strym + strMappath;
            }
            catch
            {
            }
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('请选择要Upload的文件!');</script>");
            return "";
        }
        return strMappath;
    }
    public bool type(string aa)
    {
        if (this.Extension.IndexOf(aa) < 0)
            return false;
        else
            return true;
    }
}

#endregion