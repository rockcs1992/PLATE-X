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

/// <summary>
/// 字符串Action
/// </summary>
public class StringUtil
{
    public StringUtil()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static bool IfNull(string strText)
    {
        bool b = false;
        if (strText == null || strText == "")
        {
            b = true;
        }
        else
        {
            b = false;
        }
        return b;
    }

    //字符传的转换 用在查询 登陆时 防止恶意的盗取Password
    public static string TBCode(string strtb)
    {
        strtb = strtb.Trim();
        strtb = strtb.Replace("!", "");
        strtb = strtb.Replace("@", "");
        strtb = strtb.Replace("#", "");
        strtb = strtb.Replace("$", "");
        strtb = strtb.Replace("%", "");
        strtb = strtb.Replace("^", "");
        strtb = strtb.Replace("&", "");
        strtb = strtb.Replace("*", "");
        strtb = strtb.Replace("(", "");
        strtb = strtb.Replace(")", "");
        strtb = strtb.Replace("_", "");
        strtb = strtb.Replace("+", "");

        strtb = strtb.Replace("?", "");

        strtb = strtb.Replace(".", "");
        strtb = strtb.Replace(">", "");
        strtb = strtb.Replace("<", "");
        strtb = strtb.Replace("{", "");
        strtb = strtb.Replace("}", "");
        strtb = strtb.Replace("[", "");
        strtb = strtb.Replace("]", "");
        strtb = strtb.Replace("-", "");
        strtb = strtb.Replace("=", "");
        strtb = strtb.Replace(",", "");

        strtb = strtb.Replace("\r", "<br>");
        strtb = strtb.Replace("\r\n", "<br>");
        strtb = strtb.Replace("'", "");
        return strtb;
    }

    /// <summary>
    /// 截取部分内容
    /// </summary>
    /// <param name="content"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    static public string GetSubstr(string content, int nlength)
    {
        if (content.Length > nlength)
            return content.Substring(0, nlength - 2) + "...";
        else
            return content;

    }

    /// <summary>
    /// 返回文本编辑器替换后的字符串
    /// </summary>
    /// <param name="str">要替换的字符串</param>
    /// <returns></returns>
    static public string GetHtmlEditReplace(string str)
    {
        #region
        return str.Replace("'", "''").Replace("&nbsp;", " ").Replace(",", "，").Replace("%", "％").Replace("script", "").Replace(".js", "");
        #endregion
    }

    #region 用户输入文本插入数据库时要用到
    /// <summary>
    /// 用户输入文本插入数据库时要用到
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string HtmlEncode(string str)
    {
        str = str.Replace("\n", "<br>");
        str = str.Replace("<", "&lt");
        str = str.Replace(">", "&gt");
        str = str.Replace("'", "''");
        str = str.Replace("-", "－");
        return str;
    }
    #endregion

    #region 从数据库中读取到页面显示的时候要用到
    /// <summary>
    /// 从数据库中读取到页面显示的时候要用到
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string HtmlDecode(string str)
    {
        str = str.Replace("''", ",");
        str = str.Replace("&lt", "<");
        str = str.Replace("&gt", ">");
        str = str.Replace("－", "-");
        return str;
    }
    #endregion

    /// <summary>
    /// 该方法用于判断是否为数字
    /// </summary>
    public static bool IsNumeric(string value)
    {
        return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
    }
    /// <summary>
    /// 该方法用于判断是否为整形
    /// </summary>
    public static bool IsInt(string value)
    {
        return Regex.IsMatch(value, @"^[+-]?\d*$");
    }
    /// <summary>
    /// 该方法用于判断是否为无符号数字
    /// </summary>
    public static bool IsUnsign(string value)
    {
        return Regex.IsMatch(value, @"^\d*[.]?\d*$");
    }

    /// <summary> 
    /// 去除HTML标记
    /// </summary>
    /// <param name="NoHTML">包括HTML的源码 </param>
    /// <returns>已经去除后的文字</returns>
    public static string NoHTML(string Htmlstring)
    {
        //Delete脚本
        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //DeleteHTML
        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&ldquo;", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&rdquo;", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
        Htmlstring.Replace("<", "");
        Htmlstring.Replace(">", "");
        Htmlstring.Replace("\r\n", "");
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
        return Htmlstring;
    }

    /// <summary>
    /// 用|号拆分字符返回一个数组
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string[] ret_Arry(string str)
    {

        string[] Dic = str.Split('|');
        return Dic;
    }
    /// <summary>
    /// 用,号拆分字符返回一个数组
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string[] ret_String(string str)
    {
        string[] Dic = str.Split(',');
        return Dic;
    }

}

