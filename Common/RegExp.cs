using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// ������ʽ
/// </summary>
public class RegExp
{


    #region �ж��Ƿ�ΪUnicode�� public static bool IsUnicode(string s)
    /// <summary>
    /// �ж��Ƿ�ΪUnicode��
    /// </summary>
    public static bool IsUnicode(string s)
    {
        string pattern = @"^[\u4E00-\u9FA5\uE815-\uFA29]+$";
        return Regex.IsMatch(s, pattern);
    }
    #endregion

    #region �õ������������ķ���ֵ 	public static string[] GetPercence(int a, int b)
    /// <summary>
    /// �õ������������ķ���ֵ
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static string[] GetPercence(int a, int b)
    {
        while (true)
        {
            if (0 == a % 2 && 0 == b % 2)
            {
                a = a / 2;
                b = b / 2;
            }
            else if (0 == a % 3 && 0 == b % 3)
            {
                a = a / 3;
                b = b / 3;
            }
            else if (0 == a % 5 && 0 == b % 5)
            {
                a = a / 5;
                b = b / 5;
            }
            else if (0 == a % 7 && 0 == b % 7)
            {
                a = a / 7;
                b = b / 7;
            }
            else
            {
                break;
            }
        }
        return new string[2] { a.ToString(), b.ToString() };
    }
    #endregion

    #region ����ʱ����˶�����,����Сʱ�ļ��� public static string[] GetDifDateAndTime(object todate, object fodate)
    /// <summary>
    /// ����ʱ����˶�����,����Сʱ�ļ��� 
    /// </summary>
    /// <param name="todate"></param>
    /// <param name="fodate"></param>
    /// <returns></returns>
    public static string[] GetDifDateAndTime(object todate, object fodate)
    {
        string[] DateHoure = new string[2];

        System.TimeSpan ts = System.DateTime.Parse(todate.ToString()) - System.DateTime.Parse(fodate.ToString());

        double alltimes = ts.TotalSeconds;
        alltimes = alltimes / (60 * 60 * 24);
        string strdate = alltimes.ToString();
        int length = alltimes.ToString().Length;
        int start = alltimes.ToString().LastIndexOf(@".");
        int date = (int)System.Math.Round(alltimes, 10);
        int houre = (int)(double.Parse("0" + alltimes.ToString().Substring(start, length - start)) * 24);
        DateHoure[0] = date.ToString();
        DateHoure[1] = houre.ToString();
        return DateHoure;
    }
    #endregion

    #region ����ʱ����˶�����,����Сʱ�ļ��� public static string GetDifDateAndTime(object todate, object fodate, string v1, string v2, string v3, string v4, string v5, string v6)
    /// <summary>
    /// ����ʱ����˶�����,����Сʱ�ļ���
    /// </summary>
    /// <param name="todate"></param>
    /// <param name="fodate"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string GetDifDateAndTime(object todate, object fodate, string v1, string v2, string v3, string v4, string v5, string v6)
    {
        System.TimeSpan ts = System.DateTime.Parse(todate.ToString()) - System.DateTime.Parse(fodate.ToString());

        int y = (int)ts.TotalDays / 365;

        int M = (int)((ts.TotalDays / 365 - (double)(int)(ts.TotalDays / 365)) * 12);

        int d = ts.Days - y * 365 - M * 30;

        int h = ts.Hours;

        int m = ts.Minutes;
        string rsr = "";

        if (0 != y)
        {
            rsr += y.ToString() + v1;
        }
        if (0 != M)
        {
            rsr += M.ToString() + v2;
        }
        if (0 != d)
        {
            rsr += d.ToString() + v3;
        }
        if (0 != h)
        {
            rsr += h.ToString() + v4;
        }
        if (0 != m)
        {
            rsr += m.ToString() + v5;
        }
        if (0 == y && 0 == M && 0 == d && 0 == h && 0 == m)
        {
            return v6;
        }
        return rsr;
    }
    #endregion

    #region �ж��ַ����Ƿ����������
    /// <summary>
    /// �ж��ַ����Ƿ����������
    /// </summary>
    public static bool IsNumeric(string s)
    {
        string pattern = @"^\-?[0-9]+$";
        return Regex.IsMatch(s, pattern);
    }
    #endregion

    #region �ж��ַ����Ƿ��ɺ������ public static bool isChinese(string s)
    /// <summary>
    /// �ж��ַ����Ƿ��ɺ������
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool isChinese(string s)
    {
        string pattern = @"^[\u4e00-\u9fa5]{2,}$";

        return Regex.IsMatch(s, pattern);
    }
    /// <summary>
    /// �Ƿ��ǺϷ���Username
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool isValidUserName(string s)
    {
        string pattern = @"^[A-Za-z0-9]{1}(\w|[\.#@]){2,10}[A-Za-z0-9]{1}$";

        return Regex.IsMatch(s, pattern);
    }

    #endregion

    #region �ж��Ƿ��������� public static bool IsUnsNumeric(string s)
    /// <summary>
    /// �ж��Ƿ���������
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsUnsNumeric(string s)
    {
        string pattern = @"^[0-9]+$";
        return Regex.IsMatch(s, pattern);
    }
    #endregion


    #region �ж��Ƿ��������� public static bool IsUnsFlaot(string s)
    /// <summary>
    /// �ж��Ƿ���������
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsUnsFlaot(string s)
    {
        string pattern = @"^[0-9]+.?[0-9]+$";
        return Regex.IsMatch(s, pattern);
    }
    #endregion

    #region  �ж��ַ����Ƿ���correct�� IP ��ַ��ʽ public static bool IsIp(string s)
    /// <summary> 
    /// �ж��ַ����Ƿ���correct�� IP ��ַ��ʽ
    /// </summary>
    public static bool IsIp(string s)
    {
        string pattern = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";
        return Regex.IsMatch(s, pattern);
    }
    #endregion

    #region �ж��ַ����Ƿ����Action���ݿ�İ�ȫ���� public static bool IsSafety(string s)
    /// <summary>
    /// �ж��ַ����Ƿ����Action���ݿ�İ�ȫ����
    /// </summary>
    public static bool IsSafety(string s)
    {
        string str = s.Replace("%20", " ");
        str = Regex.Replace(str, @"\s", " ");
        string pattern = @"select |insert |delete from |count\(|drop table|update |truncate |asc\(|mid\(|char\(|xp_cmdshell|exec master|net localgroup administrators|:|net user|""|\'| or ";
        return !Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase);
    }
    #endregion

    #region �ж��ַ����Ƿ���correct�� Url ��ַ��ʽ public static bool IsUrl(string s)

    /// <summary>
    /// �ж��ַ����Ƿ���correct�� Url ��ַ��ʽ
    /// </summary>
    public static bool IsUrl(string s)
    {
        string pattern = @"^(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*$";
        return Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase);
    }
    #endregion

    #region �ж��Ƿ�Ϊ��Ե�ַ�������ַ�� public static bool IsRelativePath(string s)
    /// <summary>
    /// �ж��Ƿ�Ϊ��Ե�ַ�������ַ��
    /// </summary>
    public static bool IsRelativePath(string s)
    {
        if (s == null || s == string.Empty)
        {
            return false;
        }
        if (s.StartsWith("/") || s.StartsWith("?"))
        {
            return false;
        }
        if (Regex.IsMatch(s, @"^\s*[a-zA-Z]{1,10}:.*$"))
        {
            return false;
        }
        return true;
    }
    #endregion

    #region �ж��Ƿ�Ϊ���Ե�ַ�������ַ�� 	public static bool IsPhysicalPath(string s)
    /// <summary>
    /// �ж��Ƿ�Ϊ���Ե�ַ�������ַ��
    /// </summary>
    public static bool IsPhysicalPath(string s)
    {
        string pattern = @"^\s*[a-zA-Z]:.*$";
        return Regex.IsMatch(s, pattern);
    }
    #endregion

    #region �ж��Ƿ�Ϊcorrect�� email ��ַ��ʽ public static bool IsEmail(string s)
    /// <summary>
    /// �ж��Ƿ�Ϊcorrect�� email ��ַ��ʽ
    /// </summary>
    public static bool IsEmail(string s)
    {
        string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
        return Regex.IsMatch(s, pattern);
    }
    #endregion


}
