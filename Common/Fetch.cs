using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
///  �Գ��÷������½��з�װ
/// </summary>
public class Fetch
{

    #region ��ȡҳ���ύ�Ĳ���ֵ���൱�� Request.Form public static string Post(string name)
    /// <summary>
    /// ��ȡҳ���ύ�Ĳ���ֵ���൱�� Request.Form
    /// </summary>
    public static string Post(string name)
    {
        string value = HttpContext.Current.Request.Form[name];
        return value == null ? string.Empty : value.Trim();
    }
    #endregion

    #region ��ȡҳ���ַ�Ĳ���ֵ���൱�� Request.QueryString public static string Get(string name)
    /// <summary>
    /// ��ȡҳ���ַ�Ĳ���ֵ���൱�� Request.QueryString
    /// </summary>
    public static string Get(string name)
    {
        string value = HttpContext.Current.Request.QueryString[name];
        return value == null ? string.Empty : value.Trim();
    }
    #endregion


    #region ���ٵ������һ������ public static void  Trace(object obj)
    /// <summary>
    /// ���ٵ������һ������
    /// </summary>
    public static void Trace(object obj)
    {
        HttpContext.Current.Response.Write(obj.ToString());
    }
    #endregion


    #region IP ��ַ�ַ�����ʽת���ɳ����� public static long Ip2Int(string ip)
    /// <summary>
    /// IP ��ַ�ַ�����ʽת���ɳ�����
    /// </summary>
    public static long Ip2Int(string ip)
    {
        if (!RegExp.IsIp(ip))
        {
            return -1;
        }
        string[] arr = ip.Split('.');
        long lng = long.Parse(arr[0]) * 16777216;
        lng += int.Parse(arr[1]) * 65536;
        lng += int.Parse(arr[2]) * 256;
        lng += int.Parse(arr[3]);
        return lng;
    }
    #endregion

    #region ��ȡ�ͻ���IP  public static string UserIp
    /// <summary>
    /// ��ȡ�ͻ���IP 
    /// </summary>
    public static string UserIp
    {
        get
        {
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ip == null || ip == string.Empty)
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (!RegExp.IsIp(ip))
            {
                return "Unknown";
            }
            return ip;
        }
    }
    #endregion

    #region  ��ȡ��������ʹ�õ�������� public static string UserBrowser
    /// <summary>
    /// ��ȡ��������ʹ�õ��������
    /// </summary>
    public static string UserBrowser
    {
        get
        {
            string agent = HttpContext.Current.Request.UserAgent;
            if (agent == null || agent == string.Empty)
                return "Unknown";
            agent = agent.ToLower();

            HttpBrowserCapabilities bc = HttpContext.Current.Request.Browser;
            if (agent.IndexOf("firefox") >= 0
                || agent.IndexOf("firebird") >= 0
                || agent.IndexOf("myie") >= 0
                || agent.IndexOf("opera") >= 0
                || agent.IndexOf("netscape") >= 0
                || agent.IndexOf("msie") >= 0
                )
                return bc.Browser + bc.Version;

            return "Unknown";
        }
    }
    #endregion

    #region �����վ���� 	public static string ServerDomain
    /// <summary>
    /// �����վ����
    /// </summary>
    public static string ServerDomain
    {
        get
        {
            string host = HttpContext.Current.Request.Url.Host.ToLower();
            string[] arr = host.Split('.');
            if (arr.Length < 3 || RegExp.IsIp(host))
            {
                return host;
            }
            string domain = host.Remove(0, host.IndexOf(".") + 1);
            if (domain.StartsWith("com.") || domain.StartsWith("net.") || domain.StartsWith("org.") || domain.StartsWith("gov."))
            {
                return host;
            }
            return domain;
        }
    }
    #endregion

    #region ��õ�ǰ·��
    /// <summary>
    /// ��õ�ǰ·��
    /// </summary>
    public static string CurrentPath
    {
        get
        {
            string path = HttpContext.Current.Request.Path;
            path = path.Substring(0, path.LastIndexOf("/"));
            if (path == "/")
            {
                return string.Empty;
            }
            return path;
        }
    }
    #endregion

 
    #region ��õ�ǰURL public static string CurrentUrl
    /// <summary> 
    /// ��õ�ǰURL
    /// </summary>
    public static string CurrentUrl
    {
        get
        {
            return HttpContext.Current.Request.Url.ToString();
        }
    }
    #endregion

    #region ��ȡ��ǰ�����ԭʼURL
    /// <summary>
    /// ��ȡ��ǰ�����ԭʼ URL
    /// </summary>
    public static string webCurrentUrl
    {
        get
        {
            return HttpContext.Current.Request.RawUrl.ToString();
        }
    }
    #endregion

    #region �����ԴURL public static string Referrer
    /// <summary>
    /// �����ԴURL
    /// </summary>
    public static string Referrer
    {
        get
        {
            Uri uri = HttpContext.Current.Request.UrlReferrer;
            if (uri == null)
            {
                return string.Empty;
            }
            return Convert.ToString(uri);
        }
    }
    #endregion

    #region �Ƿ�������������������� 	public static bool IsPostFromAnotherDomain
    /// <summary>
    /// �Ƿ��������������������
    /// </summary>
    public static bool IsPostFromAnotherDomain
    {
        get
        {
            if (HttpContext.Current.Request.HttpMethod == "GET")
            {
                return false;
            }
            return Referrer.IndexOf(ServerDomain) == -1;
        }
    }
    #endregion

    #region �Ƿ������������������POST��ʽ�ύ�� 	public static bool IsGetFromAnotherDomain
    /// <summary>
    /// �Ƿ������������������POST��ʽ�ύ��
    /// </summary>
    public static bool IsGetFromAnotherDomain
    {
        get
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                return false;
            }
            return Referrer.IndexOf(ServerDomain) == -1;
        }
    }
    #endregion

    #region �Ƿ��ж�Ϊ������ public static bool IsRobots
    /// <summary>
    /// �Ƿ��ж�Ϊ������ 
    /// </summary>
    public static bool IsRobots
    {
        get
        {
            return IsWebSearch();
        }
    }
    #endregion

    #region ����������Դ�ж� public static bool IsWebSearch()

    /// <summary>
    /// ����������Դ�ж�
    /// </summary>
    private static string[] _WebSearchList = new string[] { "google", "isaac", "surveybot", "baiduspider", "yahoo", "yisou", "3721", "qihoo", "daqi", "ia_archiver", "p.arthur", "fast-webcrawler", "java", "microsoft-atl-native", "turnitinbot", "webgather", "sleipnir", "msn" };
    public static bool IsWebSearch()
    {
        string user_agent = HttpContext.Current.Request.UserAgent;
        if (null == user_agent || string.Empty == user_agent)
        {
            return true;
        }
        else
        {
            user_agent = user_agent.ToLower();
        }

        for (int i = 0; i < _WebSearchList.Length; i++)
        {
            if (-1 != user_agent.IndexOf(_WebSearchList[i]))
            {
                return true;
            }
        }
        return UserBrowser.Equals("Unknown");
    }
    #endregion

    #region Url���룬�൱�� Server.UrlEncode public static string UrlEncode(string url)
    /// <summary>
    /// Url���룬�൱�� Server.UrlEncode
    /// </summary>
    public static string UrlEncode(string url)
    {
        return HttpContext.Current.Server.UrlEncode(url);
    }
    #endregion



}
