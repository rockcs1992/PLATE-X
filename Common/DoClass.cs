using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Collections;
using System.Text;
/// <summary>
/// DoClass 的摘要说明


/// </summary>
public class DoClass
{
    public DoClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    private static ArrayList Arr = new ArrayList();


    /// <summary>
    /// 获得学校I am a
    /// </summary>
    /// <returns></returns>
    public static string GetSchoolType()
    {
        Cookie c = new Cookie();
        return c.getCookie(ConfigHelper.GetConfigString("SchoolType"));
    }
    /// <summary>
    /// 设置小学、初中还是高中会员
    /// </summary>
    /// <param name="usertype"></param>
    /// <param name="day"></param>

    public static void setSchoolType(string schooltype, int day)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("SchoolType"), schooltype, 0);

    }

    /// <summary>
    /// 返回自定义编号


    /// </summary>
    /// <param name="num"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    private static string GetNumber(long num, int length)
    {

        StringBuilder sb = new StringBuilder();
        int count = length - num.ToString().Length;
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                sb.Append("0");
            }
        }
        return sb.ToString() + num.ToString();
    }

    /// <summary>
    /// 返回自定义编号


    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string GetNumber(long num)
    {
        return GetNumber(num, 6);
    }

    /// <summary>
    /// 判断用户是否访问过当前页面


    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool InthisArray(string path)
    {
        if (Arr.Contains(path))
        {
            return true;
        }
        else
        {
            Arr.Add(path);
            return false;
        }
    }

    /// <summary>
    /// 将c1的项移除c2的项
    /// </summary>
    /// <param name="c1">第一个控件</param>
    /// <param name="c2"></param>
    public static void RemoveList1OfList2(Control c1, Control c2)
    {
        if (c1 is ListBox)
        {
            ListBox li = (ListBox)c1;

            ListBox li2 = (ListBox)c2;

            if (li.Items.Count > 0 && li2.Items.Count > 0)
            {
                foreach (ListItem item in li2.Items)
                {
                    li.Items.Remove(item);
                }
            }
        }
        if (c1 is DropDownList)
        {
            DropDownList dr = (DropDownList)c1;
            DropDownList dr2 = (DropDownList)c2;

            if (dr.Items.Count > 0 && dr2.Items.Count > 0)
            {
                foreach (ListItem item in dr2.Items)
                {
                    dr.Items.Remove(item);
                }
            }
        }
    }

    /// <summary>
    /// 将一个项从c1到c2,或者是c2到c1
    /// </summary>
    /// <param name="c1"></param>
    /// <param name="c2"></param>
    /// <param name="item"></param>
    /// <param name="to"></param>
    public static void RemoveTo(Control c1, Control c2, ListItem item, string to)
    {
        ListBox li1 = (ListBox)c1;
        ListBox li2 = (ListBox)c2;
        if (to == "<<")
        {
            li1.Items.Add(item);
            li2.Items.Remove(item);
        }
        if (to == ">>")
        {
            li2.Items.Add(item);
            li1.Items.Remove(item);
        }


    }

    public static void setUserNameCookid(string UserName)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("UserName"), UserName, 0);
    }


    #region 权限判断

    /// <summary>
    /// 判断是否已经登录,下面将验证是否具有一定的角色
    /// </summary>
    /// <param name="isparent">表示当前页面为几级页面,如果为根目录一层就为0,为根目录文件夹下面一层的为1</param>
    public static bool CheckLogin(int isparent)
    {
        string cname = ConfigHelper.GetConfigString("AdminLogin");
        Cookie c = new Cookie();
        string str = c.getCookie(cname);
        if (str == "")
        {
            string url = "LuntanLogin.aspx.aspx";
            switch (isparent)
            {
                case 0:
                    url = "/Proscenium/Pass/" + url;
                    break;
                case 1:
                    url = "/Proscenium/Pass/" + url;
                    break;
                case 2:
                    url = "/Proscenium/Pass/" + url;
                    break;
                case 3:
                    url = "/Proscenium/Pass/" + url;
                    break;
                case 4:
                    url = "/Proscenium/Pass/" + url;
                    break;
                case -1:
                    url = "/Proscenium/Pass/" + url;
                    break;

            }
            if (isparent == -1)
            {
                Jscript.RedirectTo(url);
                return false;
            }
            else if (isparent == -2) //判断是否通过登录验证  
            {
                return false;
            }
            else
            {
                Jscript.AlertAndRedirect("您未登录或者您的身份验证已经过期，请您重新登录或者与管理员联系!!", url);
                return false;
            }

        }
        else
            return true;
    }

    ///// <summary>
    ///// 是否具有访问此页面的权限
    ///// </summary>
    ///// <param name="p"></param>
    //public static bool VisiteCurPage(Page p,int parent)
    //{
    //    string Uid = new Cookie().getCookie(ConfigHelper.GetConfigString("AdminLogin"));
    //    WebSiteAdminUsers user = new WebSiteAdminUsers();
    //    if (!user.VisiteCurPage(Uid, p))
    //    {
    //        ReturnLogin(parent);
    //        return false;
    //    }
    //    return true;

    //}

    /// <summary>
    /// 是否登陆后台系统系统
    /// </summary>
    /// <param name="p"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static bool AdminIsLogin(Page p, int parent)
    {
        string Uid = DoClass.GetAdminUserID();

        if (Uid == "" || Uid == null)
        {
            ReturnLogin(parent);
            return false;
        }
        return true;

    }


    /// <summary>
    /// 判断是否已经登录,下面将验证是否具有一定的角色
    /// </summary>
    /// <param name="isparent">表示当前页面为几级页面,如果为根目录一层就为0,为根目录文件夹下面一层的为1</param>
    public static void ReturnLogin(int isparent)
    {
        string url = "login.aspx";
        switch (isparent)
        {
            case 0:
                url = "/Manager/" + url;
                break;
            case 1:
                url = "/Manager/" + url;
                break;
            case 2:
                url = "/Manager/" + url;
                break;
            case 3:
                url = "/Manager/" + url;
                break;
            case 4:
                url = "/Manager/" + url;
                break;
        }
        Jscript.AlertAndRedirect("您没有任何权限访问此页面!请您重新登录或者和管理员进行联系!!", url);

    }

    #endregion

    #region Upload文件封装函数

    /// <summary>
    /// Upload文件
    /// </summary>
    /// <param name="File1">对象</param>
    /// <param name="fileSize">大小</param>
    /// <param name="Extensioin">扩展名</param>
    /// <param name="savepath">Save位置</param>
    /// <returns>Return -1="文件I am a错误" 0=“文件太大”else=“ok”</returns>
    public static string UploadFile(HtmlInputFile File1, int fileSize, string Extensioin, string savepath)
    {

        FileUpload1 up = new FileUpload1();
        up.PostedFile = File1.PostedFile;
        up.Extension = Extensioin;
        up.SavePath = HttpContext.Current.Server.MapPath(savepath);
        up.FileLength = fileSize;
        string s = up.Upload();
        return s;

    }


    /// <summary>
    /// Upload文件
    /// </summary>
    /// <param name="File1">对象</param>
    /// <param name="fileSize">大小</param>
    /// <param name="Extensioin">扩展名</param>
    /// <param name="savepath">Save位置</param>
    /// <returns>Return -1="文件I am a错误" 0=“文件太大”else=“ok”</returns>
    public static string UploadFile(HttpPostedFile postFile1, int fileSize, string Extensioin, string savepath)
    {
        FileUpload1 up = new FileUpload1();
        up.PostedFile = postFile1;
        up.Extension = Extensioin;
        up.SavePath = HttpContext.Current.Server.MapPath(savepath);
        up.FileLength = fileSize;
        string s = up.Upload();
        return s;

    }


    /// <summary>
    /// Upload文件
    /// </summary>
    /// <param name="File1">对象</param>
    /// <param name="fileSize">大小</param>
    /// <param name="Extensioin">扩展名</param>
    /// <param name="savepath">Save位置</param>
    /// <returns>Return -1="文件I am a错误" 0=“文件太大”else=“ok”</returns>
    public static string UploadFile(HttpPostedFile postFile1, int fileSize, string Extensioin, string savepath, string filename)
    {
        FileUpload1 up = new FileUpload1();
        up.PostedFile = postFile1;
        up.Extension = Extensioin;
        up.SavePath = HttpContext.Current.Server.MapPath(savepath);
        up.FileLength = fileSize;
        up.SetFileName = filename;
        string s = up.Upload();
        return s;

    }

    #endregion

    /// <summary>
    /// 后台用户Log Out登陆
    /// </summary>
    public static void AdminLoginOut()
    {
        Cookie c = new Cookie();
        c.delCookie(ConfigHelper.GetConfigString("AdminLogin"));
        c.delCookie(ConfigHelper.GetConfigString("AdminName"));

        Jscript.RedirectTo("login.aspx");

    }

    /// <summary>
    /// 后台用户Log Out登陆
    /// </summary>
    public static void AdminLoginOutNoRedirect()
    {
        Cookie c = new Cookie();
        c.delCookie(ConfigHelper.GetConfigString("AdminLogin"));
        c.delCookie(ConfigHelper.GetConfigString("AdminName"));

    }

    /// <summary>
    /// 判断用户是否登录
    /// </summary>
    public static string CheckUserLogin(string msg)
    {
        Cookie c = new Cookie();
        if (c.getCookie(ConfigHelper.GetConfigString("UserName")) == "")
        {
            if (msg == "")
            {
                Jscript.AlertAndRedirectJstr("您还没有登录！", "window.top.location.href='../Pass/LuntanLogin.aspx'");
                return "";
            }
            else
            {
                Jscript.AlertAndRedirectJstr(msg, "window.top.location.href='../Pass/LuntanLogin.aspx'");
                return "";
            }

        }
        else
        {
            return c.getCookie(ConfigHelper.GetConfigString("UserName"));
        }
    }


    /// <summary>
    /// 判断用户是否登录
    /// </summary>
    public static string CheckUserLogin(string msg, string url)
    {
        Cookie c = new Cookie();
        if (c.getCookie(ConfigHelper.GetConfigString("UserName")) == "")
        {
            if (msg == "")
            {
                HttpContext.Current.Response.Redirect(url, true);

                return "";
            }
            else
            {
                Jscript.AlertAndRedirectJstr(msg, url);
                return "";
            }

        }
        else
        {
            return c.getCookie(ConfigHelper.GetConfigString("UserName"));
        }
    }

    /// <summary>
    /// 获得用户昵称
    /// </summary>
    /// <returns></returns>
    public static string GetUserName()
    {
        Cookie c = new Cookie();
        return HttpContext.Current.Server.UrlDecode(c.getCookie(ConfigHelper.GetConfigString("UserName")));
    }
    /// <summary>
    /// 获得集团Username
    /// </summary>
    /// <returns></returns>
    public static string GetJtUserName()
    {
        Cookie c = new Cookie();
        return HttpContext.Current.Server.UrlDecode(c.getCookie(ConfigHelper.GetConfigString("jtUserName")));
    }
    /// <summary>
    /// 获得管理员的登录名
    /// </summary>
    /// <returns></returns>
    public static string GetAdminUserID()
    {
        Cookie c = new Cookie();
        return c.getCookie(ConfigHelper.GetConfigString("AdminLogin"));

    }

    /// <summary>
    /// 获得管理员的Username称
    /// </summary>
    /// <returns></returns>
    public static string GetAdminUserName()
    {
        Cookie c = new Cookie();
        return c.getCookie(ConfigHelper.GetConfigString("AdminName"));
    }

    /// <summary>
    /// 获得用户登录名
    /// /// </summary>
    /// <returns></returns>
    public static string GetUserID()
    {
        Cookie c = new Cookie();


        string s = c.getCookie(ConfigHelper.GetConfigString("ZYKUserID"));


        return s;

    }


    /// <summary>
    /// 获得uid
    /// </summary>
    /// <returns></returns>
    public static string GetUid()
    {
        Cookie c = new Cookie();
        string s = c.getCookie(ConfigHelper.GetConfigString("UID"));
        if (s == "")
            return "0";
        return s;
    }


    /// <summary>
    /// 获得用户I am a
    /// </summary>
    /// <returns></returns>
    public static string GetUserType()
    {
        Cookie c = new Cookie();
        return c.getCookie(ConfigHelper.GetConfigString("UserType"));
    }
    /// <summary>
    /// 获得用户权限
    /// </summary>
    /// <returns></returns>
    public static string GetAdminquanxian()
    {
        Cookie c = new Cookie();
        return c.getCookie(ConfigHelper.GetConfigString("quanxian"));
    }
    /// <summary>
    /// 获得用户上次登陆城市
    /// </summary>
    /// <returns></returns>
    public static string GetAreaTag()
    {
        Cookie c = new Cookie();
        return c.getCookie(ConfigHelper.GetConfigString("areatag"));
    }
    /// <summary>
    /// Log Out登录
    /// </summary>
    public static void RemoveUserCookie()
    {
        Cookie c = new Cookie();

        c.delCookie(ConfigHelper.GetConfigString("AdminName"));
        c.delCookie(ConfigHelper.GetConfigString("UserID"));
        c.delCookie(ConfigHelper.GetConfigString("UsedCache"));
        // c.delCookie(ConfigHelper.GetConfigString("CacheTime"));
    }



    /// <summary>
    /// 绑定年


    /// </summary>
    /// <param name="start">开始时间</param>
    /// <param name="end">结束日期</param>
    public static void BindDate(int start, int end, Control c)
    {
        if (c is DropDownList)
        {
            DropDownList drli = (DropDownList)c;

            for (int i = start; i <= end; i++)
            {
                drli.Items.Add(i + "");
            }
            drli.Items.Insert(0, new ListItem("年", "-1"));
        }
    }



    /// <summary>
    /// 分割字符串
    /// </summary>
    public static string[] SplitString(string strContent, string strSplit)
    {
        if (strContent.IndexOf(strSplit) < 0)
        {
            string[] tmp = { strContent };
            return tmp;
        }
        return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
    }


    /// <summary>
    /// 进行指定的替换(脏字过滤)
    /// </summary>
    public static string StrFilter(string str, string zangzi)
    {
        string bantext = zangzi;
        if (zangzi == null || zangzi.IndexOf("=") == -1 || zangzi == "")
        {
            return str;
        }
        string text1 = "";
        string text2 = "";
        string[] textArray1 = SplitString(bantext, "\r\n");
        for (int num1 = 0; num1 < textArray1.Length; num1++)
        {
            text1 = textArray1[num1].Substring(0, textArray1[num1].IndexOf("="));
            text2 = textArray1[num1].Substring(textArray1[num1].IndexOf("=") + 1);
            str = str.Replace(text1, text2);
        }
        return str;
    }

    /// <summary>
    /// 返回自定义Image Verification Code　根据时间截取
    /// </summary>
    /// <returns></returns>
    public static string GetValidateCode()
    {
        System.Threading.Thread.Sleep(10);
        string head = DateTime.Now.ToString("HHmmssmm");

        return head;
    }
    /// <summary>
    /// 设置用户账号
    /// </summary>
    /// <param name="uid"></param>

    public static void setUserIdCookie(string uid)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("ZYKUserID"), uid, 0);

    }
    public static void setUserIdCookieAddtime(string uid)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("UserID"), uid, 30);

    }
    public static void setUserTypeCookie(string usertype, int day)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("UserType"), usertype, 0);

    }
    /// <summary>
    /// 设置用户I am a
    /// </summary>
    /// <param name="uid"></param>
    public static void setadminnameCookie(string Adminname)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("AdminName"), Adminname, 0);

    }
    /// <summary>
    /// 设置集团Username
    /// </summary>
    /// <param name="uid"></param>
    public static void setJtusernameCookie(string username)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("jtUserName"), username, 0);

    }
    /// <summary>
    /// 设置用户权限
    /// </summary>
    /// <param name="uid"></param>
    public static void setadminquanxian(string quanxian)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("quanxian"), quanxian, 0);

    }

    /// <summary>
    /// 设置Usernameｃｏｏｋｉｅ
    /// </summary>
    /// <param name="uname"></param>
    public static void setUserNameCookie(string uname, int day)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("UserName"), HttpUtility.HtmlEncode(uname), 0);
    }
    /// <summary>
    /// 设置用户id ｃｏｏｋｉｅ
    /// </summary>
    /// <param name="uname"></param>
    public static void setUidCookid(string uname)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("UID"), HttpUtility.HtmlEncode(uname), 0);
    }
    /// <summary>
    /// 设置用户上次登陆城市
    /// </summary>
    /// <param name="uname"></param>
    public static void setAreaTag(string areatag)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("areatag"), areatag, 365);
    }

    /// <summary>
    /// 判断用户是否登录前台
    /// </summary>
    public static bool checkUserHasCookie(string url)
    {
        if (DoClass.GetUserID() == "")
        {
            Jscript.RedirectTo("lologin.aspx?f=" + url);
            return false;
        }
        return true;
    }

}
