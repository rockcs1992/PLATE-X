using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Configuration;

/// <summary>
/// �����ı�������
/// </summary>
public class Text
{
    

    #region ������� public static string ShitEncode(string s)
    /// <summary>
    /// ������ʣ�Ĭ����Ϊ�����|����|����|��b|���|fuck|shit|����|����|�Ҳ١�
    /// ������ bbs.config ������ BadWords ��ֵ
    /// </summary>
    public static string ShitEncode(string s)
    {
        string bw = ConfigHelper.GetConfigString("BadWords");
        if (bw == null || 0 == bw.Length)
        {
            bw = "���|����|����|��b|���|fuck|shit|����|����|�Ҳ�";
        }
        else
        {
            bw = Regex.Replace(bw, @"\|{2,}", "|");
            bw = Regex.Replace(bw, @"(^\|)|(\|$)", string.Empty);
        }
        return Regex.Replace(s, bw, "**", RegexOptions.IgnoreCase);
    }
    #endregion


    #region �ı����� 	public static string TextEncode(string s)
    /// <summary>
    /// �ı�����
    ///</summary>
    public static string TextEncode(string s)
    {
        if (null == s || 0 == s.Length)
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder(s);
        sb.Replace("&", "&amp;");
        sb.Replace("<", "&lt;");
        sb.Replace(">", "&gt;");
        sb.Replace("\"", "&quot;");
        sb.Replace("\'", "&#39;");
        return ShitEncode(sb.ToString());
    }
    #endregion


    #region HTML ���� public static string HtmlEncode(string s)
    /// <summary>
    /// HTML ����
    ///</summary>
    public static string HtmlEncode(string s)
    {
        return HtmlEncode(s, false);
    }

    public static string HtmlEncode(string s, bool bln)
    {
        if (null == s || 0 == s.Length)
        {
            return s;
        }

        StringBuilder sb = new StringBuilder(s);
        sb.Replace("&", "&amp;");
        sb.Replace("<", "&lt;");
        sb.Replace(">", "&gt;");
        sb.Replace("\"", "&quot;");
        sb.Replace("\'", "&#39;");

        if (bln)
        {
            return ShitEncode(sb.ToString());
        }
        else
        {
            return sb.ToString();
        }
    }
    #endregion


    #region HTML ���� public static string HtmlDecode(string s)
    /// <summary>
    /// HTML ����
    ///</summary>
    public static string HtmlDecode(string s)
    {
        StringBuilder sb = new StringBuilder(s);
        sb.Replace("&amp;", "&");
        sb.Replace("&lt;", "<");
        sb.Replace("&gt;", ">");
        sb.Replace("&quot;", "\"");
        sb.Replace("&#39;", "'");

        return sb.ToString();
    }
    #endregion


    #region TEXT����		public static string TextDecode(string s)
    /// <summary>
    /// TEXT����
    /// </summary>
    public static string TextDecode(string s)
    {
        StringBuilder sb = new StringBuilder(s);
        sb.Replace("<br/><br/>", "\r\n");
        sb.Replace("<br/>", "\r");
        sb.Replace("<p></p>", "\r\n\r\n");
        return sb.ToString();
    }
    #endregion


    #region �ַ����ĳ��� public static int Len(string s)
    /// <summary>
    /// �ַ����ĳ���
    /// </summary>
    public static int Len(string s)
    {
        return HttpContext.Current.Request.ContentEncoding.GetByteCount(s);
    }
    #endregion


    #region ȥ�� htmlCode �����е�HTML��ǩ(������ǩ�е�����) public static string StripHtml(string htmlCode)
    /// <summary>
    /// ȥ�� htmlCode �����е�HTML��ǩ(������ǩ�е�����)
    /// </summary>
    /// <param name="htmlCode">���� HTML ������ַ�����</param>
    /// <returns>����һ�������� HTML ������ַ���</returns>
    public static string StripHtml(string htmlCode)
    {
        if (null == htmlCode || 0 == htmlCode.Length)
        {
            return string.Empty;
        }
        return Regex.Replace(htmlCode, @"<[^>]+>", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Multiline);
    }
    #endregion

    #region ��ȡ�ַ���
    /// <summary>
    /// ��ȡ�ַ���
    /// </summary>
    /// <param name="str">ԭ�ַ���</param>
    /// <param name="len">Ҫ��ȡ�ĳ���</param>
    /// <returns></returns>
    public static string Left(string str,int len)
    {
        string strings;
        int j = 0, k = 0;
        int c = System.Text.Encoding.Default.GetByteCount(str);
        if (c > len)
        {
            for (int i = 0; i < len; i++)
            {
                if (i < str.Length)
                {
                    j += System.Text.Encoding.GetEncoding("GB2312").GetByteCount(str.Substring(i, 1));//���볤��
                    if (j <= len)
                    {
                        k++;//�ַ�����
                    }
                }
            }
            strings = str.Substring(0, k);
            return strings;
        }
        else
        {
            return str;
        }
    }
    /// <summary>
    /// ��ȡ�ַ���
    /// </summary>
    /// <param name="str">ԭ�ַ���</param>
    /// <param name="len">Ҫ��ȡ�ĳ���</param>
    /// <returns></returns>
    public static string LeftDian(string str, int len)
    {
        string strings;
        int j = 0, k = 0;
        int c = System.Text.Encoding.Default.GetByteCount(str);
        if (c > len)
        {
            for (int i = 0; i < len; i++)
            {
                if (i < str.Length)
                {
                    j += System.Text.Encoding.GetEncoding("GB2312").GetByteCount(str.Substring(i, 1));//���볤��
                    if (j <= len)
                    {
                        k++;//�ַ�����
                    }
                }
            }
            strings = str.Substring(0, k);
            return strings+"��";
        }
        else
        {
            return str;
        }
    }
    /// <summary>
    /// ��Gb2312������ַ���ת��Ϊutf-8
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Gb2312ToUTF8(string str)
    {
        if (str.Trim() != "")
        {
            Encoding enutf8 = Encoding.UTF8;
            byte[] utf8 = enutf8.GetBytes(str);
            Encoding engb2312 = Encoding.GetEncoding("gb2312");
            return engb2312.GetString(utf8);
        }
        else
        {
            return "";
        }
    }
    #endregion

    #region   �ж��Ƿ��зǷ��ַ�

    /// <summary>
    /// �ж��Ƿ��зǷ��ַ�
    /// </summary>
    /// <param name="strString"></param>
    /// <returns></returns>
    public static bool CheckBidStr(string strString)
    {
        bool outValue = false;
        if (strString != null && strString.Length > 0)
        {
            string[] bidStrlist = new string[20];
            bidStrlist[0] = "'";
            bidStrlist[1] = ";";
            bidStrlist[2] = ":";
            bidStrlist[3] = "%";
            bidStrlist[4] = "@";
            bidStrlist[5] = "&";
            bidStrlist[6] = "#";
            bidStrlist[7] = "\"";
            bidStrlist[8] = "net user";
            bidStrlist[9] = "exec";
            bidStrlist[10] = "net localgroup";
            bidStrlist[11] = "select";
            bidStrlist[12] = "asc";
            bidStrlist[13] = "char";
            bidStrlist[14] = "mid";
            bidStrlist[15] = "insert";
            bidStrlist[16] = "delete";
            bidStrlist[17] = "drop";
            bidStrlist[18] = "truncate";
            bidStrlist[19] = "xp_cmdshell";

            string tempStr = strString.ToLower();
            for (int i = 0; i < bidStrlist.Length; i++)
            {
                if (tempStr.IndexOf(bidStrlist[i]) != -1)
                {
                    outValue = true;
                    break;
                }
            }
        }
        return outValue;
    }

    #endregion

    /// <summary>
    /// ���˷Ƿ��ַ�
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string MoveBidStr(string strString)
    {
        if (string.IsNullOrEmpty(strString))
            return "";
        string strBadChar, tempChar;
        string[] arrBadChar;
        strBadChar = "@@,+,',--,%,^,&,?,(,),<,>,[,],{,},/,\\,;,:,\",\"\",";
        arrBadChar = SplitString(strBadChar, ",");
        tempChar = strString;
        for (int i = 0; i < arrBadChar.Length; i++)
        {
            if (arrBadChar[i].Length > 0)
                tempChar = tempChar.Replace(arrBadChar[i], "");
        }
        return tempChar;
    }

    /// <summary>
    /// �����ַ�(SQL)
    /// </summary>
    /// <param name="Input"></param>
    /// <returns></returns>
    public static string Filter(string sInput)
    {
        if (sInput == null || sInput == "")
            return null;
        string sInput1 = sInput.ToLower();
        string output = sInput;
        string pattern = @"*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
        if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
        {
            throw new Exception("�ַ����к��зǷ��ַ�!");
        }
        else
        {
            output = output.Replace("'", "''");
        }
        return output;
    }


    /// <summary>
    /// �ָ��ַ���
    /// </summary>
    public static string[] SplitString(string strContent, string strSplit)
    {
        int i = strContent.IndexOf(strSplit);
        if (strContent.IndexOf(strSplit) < 0)
        {
            string[] tmp = { strContent };
            return tmp;
        }

        return Regex.Split(strContent, @strSplit.Replace(".", @"\."));
    }


    /// <summary>
    /// ȥ����βP
    /// </summary>
    /// <param name="Input"></param>
    /// <returns></returns>
    public static string RemovePor(string Input)
    {
        if (Input != string.Empty && Input != null)
        {
            string TMPStr = Input;
            if (Input.ToLower().Substring(0, 3) == "<p>")
            {
                TMPStr = TMPStr.Substring(3);
            }
            if (TMPStr.Substring(TMPStr.Length - 4) == "</p>")
            {
                TMPStr = TMPStr.Remove(TMPStr.ToLower().LastIndexOf("</p>"));
            }
            return TMPStr;
        }
        else
        {
            return string.Empty;
        }
    }


    /// <summary>
    /// ��⺬�����ַ���ʵ�ʳ���
    /// </summary>
    /// <param name="str">�������ַ���</param>
    /// <returns>����������</returns>
    public static int NumChar(string Input)
    {
        ASCIIEncoding n = new ASCIIEncoding();
        byte[] b = n.GetBytes(Input);
        int l = 0;
        for (int i = 0; i <= b.Length - 1; i++)
        {
            if (b[i] == 63)//�ж��Ƿ�Ϊ���ֻ�ȫ�ŷ���
            {
                l++;
            }
            l++;
        }
        return l;
    }

    /// <summary> 
    /// ����תƴ����д 
    /// 2004-11-30 
    /// </summary> 
    /// <param name="Input">Ҫת���ĺ����ַ���</param> 
    /// <returns>ƴ����д</returns> 
    public static string GetPYString(string Input)
    {
        string ret = "";
        foreach (char c in Input)
        {
            if ((int)c >= 33 && (int)c <= 126)
            {//��ĸ�ͷ���ԭ������ 
                ret += c.ToString();
            }
            else
            {//�ۼ�ƴ����ĸ 
                ret += GetPYChar(c.ToString());
            }
        }
        return ret;
    }

    /// <summary> 
    /// ȡ�����ַ���ƴ����ĸ 
    /// 2004-11-30 
    /// </summary> 
    /// <param name="c">Ҫת���ĵ�������</param> 
    /// <returns>ƴ����ĸ</returns> 
    private static string GetPYChar(string c)
    {
        byte[] array = new byte[2];
        array = System.Text.Encoding.Default.GetBytes(c);
        int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
        if (i < 0xB0A1) return "*";
        if (i < 0xB0C5) return "A";
        if (i < 0xB2C1) return "B";
        if (i < 0xB4EE) return "C";
        if (i < 0xB6EA) return "D";
        if (i < 0xB7A2) return "E";
        if (i < 0xB8C1) return "F";
        if (i < 0xB9FE) return "G";
        if (i < 0xBBF7) return "H";
        if (i < 0xBFA6) return "G";
        if (i < 0xC0AC) return "K";
        if (i < 0xC2E8) return "L";
        if (i < 0xC4C3) return "M";
        if (i < 0xC5B6) return "N";
        if (i < 0xC5BE) return "O";
        if (i < 0xC6DA) return "P";
        if (i < 0xC8BB) return "Q";
        if (i < 0xC8F6) return "R";
        if (i < 0xCBFA) return "S";
        if (i < 0xCDDA) return "T";
        if (i < 0xCEF4) return "W";
        if (i < 0xD1B9) return "X";
        if (i < 0xD4D1) return "Y";
        if (i < 0xD7FA) return "Z";
        return "*";
    }

    public static int GetRandomNum(int i, int length, int up, int down)
    {
        int iFirst = 0;
        Random ro = new Random(i * length * unchecked((int)DateTime.Now.Ticks));
        iFirst = ro.Next(up, down);
        return iFirst;
    }


    #region �ض��ַ��� public static string Left(string s, int need, bool encode)
    /// <summary>
    /// �ض��ַ��������str �ĳ��ȳ��� need������ȡ str ��ǰ need ���ַ�������β���� ��...��
    /// </summary>
    public static string Left(string s, int need, bool encode)
    {
        if (s == null || s == "")
        {
            return string.Empty;
        }

        int len = s.Length;
       // int len = NumChar(s);
        if (len < need / 2)
        {
            return encode ? TextEncode(s) : s;
        }

        int i, j, bytes = 0;
        for (i = 0; i < len; i++)
        {
            bytes += RegExp.IsUnicode(s[i].ToString()) ? 2 : 1;
            if (bytes >= need)
            {
                break;
            }
        }

        string result = s.Substring(0, i);
        if (len > i)
        {
            for (j = 0; j < 5; j++)
            {
                bytes -= RegExp.IsUnicode(s[i - j].ToString()) ? 2 : 1;
                if (bytes <= need)
                {
                    break;
                }
            }
            result = s.Substring(0, i - j) + "...";
        }
        return encode ? TextEncode(result) : result;
    }
    #endregion


    /// <summary>
    /// �������漴Item Name
    /// </summary>
    /// <returns></returns>
    public static string sjname()
    {
        Random ro = new Random();
        string sj = null;
        sj = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.TimeOfDay.Hours.ToString() + DateTime.Now.TimeOfDay.Minutes.ToString() + DateTime.Now.TimeOfDay.Milliseconds.ToString() + ro.Next(100, 100000000).ToString();
        return sj;
    }

    /// <summary>
    /// ����������
    /// </summary>
    /// <returns></returns>
    public static string OrderID()
    {
        System.Threading.Thread.Sleep(3);
        string sj = null;
        sj = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.TimeOfDay.Hours.ToString() + DateTime.Now.TimeOfDay.Minutes.ToString() + DateTime.Now.TimeOfDay.Milliseconds.ToString();
        return sj;
    }

    /// <summary>
    /// ���ַ����е�html����ȥ��
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string subString_html(string content)
    {
        string newcontent = "";
        int start = 0;
        if (content.IndexOf("<") != -1)
        {
            while (content.IndexOf("<") != -1)
            {
                start = content.IndexOf("<");
                if (start != -1)
                {
                    newcontent += content.Substring(0, start);
                    content = content.Substring(start + 1);
                    start = content.IndexOf(">");
                    if (start != -1)
                    {
                        content = content.Substring(start + 1);
                    }
                }
            }
            newcontent += content;
        }
        else
        {
            newcontent = content;
        }
        newcontent = newcontent.Replace("&nbsp;", "");
        newcontent = newcontent.Replace(" ", "");
        return newcontent;
    }

    /// <summary>
    /// ���ַ����е�html����ȥ�� ��Ե�����ǩ
    /// </summary>
    /// <param name="content"></param>
    /// <param name="strx"></param>
    /// <param name="strd"></param>
    /// <returns></returns>
    public static string subString_html(string content, string strx, string strd)
    {
        string newcontent = "";
        int start = 0;
        if (content.IndexOf("<" + strx) != -1)
        {
            while (content.IndexOf("<" + strx) != -1)
            {
                start = content.IndexOf("<" + strx);
                if (start != -1)
                {
                    newcontent += content.Substring(0, start);
                    content = content.Substring(start + 1);
                    start = content.IndexOf(">");
                    if (start != -1)
                    {
                        content = content.Substring(start + 1);
                    }
                }
            }
            newcontent += content;
        }
        else
        {
            newcontent = content;
        }
        content = newcontent;
        newcontent = "";
        start = 0;
        if (content.IndexOf("<" + strd) != -1)
        {
            while (content.IndexOf("<" + strd) != -1)
            {
                start = content.IndexOf("<" + strd);
                if (start != -1)
                {
                    newcontent += content.Substring(0, start);
                    content = content.Substring(start + 1);
                    start = content.IndexOf(">");
                    if (start != -1)
                    {
                        content = content.Substring(start + 1);
                    }
                }
            }
            newcontent += content;
        }
        else
        {
            newcontent = content;
        }
        newcontent = newcontent.Replace("</a>", "");
        newcontent = newcontent.Replace("</A>", "");
        return newcontent;
    }
    //xue
    /// <summary>
    /// ���ַ����е�html����ȥ�� ��Ե�����ǩxue
    /// </summary>
    /// <param name="content"></param>
    /// <param name="strx"></param>
    /// <param name="strd"></param>
    /// <returns></returns>
    public static string subString_htmlxue(string content, string strx, string strd)
    {
        string newcontent = "";
        int start = 0;
        if (content.IndexOf(strx) != -1)
        {
            while (content.IndexOf(strx) != -1)
            {
                start = content.IndexOf(strx);
                if (start != -1)
                {
                    newcontent += content.Substring(0, start);
                    content = content.Substring(start + 1);
                    start = content.IndexOf(strd);
                    if (start != -1)
                    {
                        content = content.Substring(start + 1);
                    }
                }
            }
            newcontent += content;
        }
        else
        {
            newcontent = content;
        }
        content = newcontent;
        newcontent = "";
        start = 0;
        if (content.IndexOf(strx + strd) != -1)
        {
            while (content.IndexOf(strx + strd) != -1)
            {
                start = content.IndexOf(strx + strd);
                if (start != -1)
                {
                    newcontent += content.Substring(0, start);
                    content = content.Substring(start + 1);
                    start = content.IndexOf(strd);
                    if (start != -1)
                    {
                        content = content.Substring(start + 1);
                    }
                }
            }
            newcontent += content;
        }
        else
        {
            newcontent = content;
        }
        newcontent = newcontent.Replace("</a>", "");
        newcontent = newcontent.Replace("</A>", "");
        return newcontent;
    }


    #region ȥ��HTML���
    ///   <summary>   
    ///   ȥ��HTML���   
    ///   </summary>   
    ///   <param   name="NoHTML">����HTML��Դ��   </param>   
    ///   <returns>�Ѿ�ȥ���������</returns>   
    public static string NoHTML(string Htmlstring)
    {
        //Delete�ű�   
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
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

        Htmlstring = Htmlstring.Replace("<", "");
        Htmlstring = Htmlstring.Replace(">", "");
        Htmlstring = Htmlstring.Replace("\r\n", "");
        Htmlstring = Htmlstring.Replace("&mdash;", "");
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

        return Htmlstring;
    }

    /// <summary>
    /// ȥ��html���
    /// </summary>
    /// <param name="ConStr"></param>
    /// <returns></returns>
    public string NoHtml_1(string ConStr)
    {
        Regex myReg = new Regex(@"(\<.[^\<]*\>)", RegexOptions.IgnoreCase);
        ConStr = myReg.Replace(ConStr, "");
        myReg = new Regex(@"(\<\/[^\<]*\>)", RegexOptions.IgnoreCase);
        ConStr = myReg.Replace(ConStr, "");
        return ConStr;
    }


    #endregion


    /// <summary>
    /// ��ȡָ�������ַ���
    /// </summary>
    /// <param name="inputString"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    public static string CutTitle(string inputString, int len)
    {
        System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
        int tempLen = 0;
        string tempString = "";
        byte[] s = ascii.GetBytes(inputString);
        for (int i = 0; i < s.Length; i++)
        {
            if ((int)s[i] == 63)
                tempLen += 2;
            else
                tempLen += 1;
            try
            {
                tempString += inputString.Substring(i, 1);
            }
            catch
            {
                break;
            }
            if (tempLen > len)
                break;
        }
        byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
        if (mybyte.Length > len)
            tempString += "��";
        return tempString;
    }

    #region ��ȡHTML���������ֵ�C#����
    ///��ȡHTML���������ֵ�C#����     
    ///   <summary>   
    ///   ȥ��HTML���   
    ///   </summary>   
    ///   <param name="strHtml">����HTML��Դ��</param>   
    ///   <returns>�Ѿ�ȥ���������</returns>   
    public static string StripHTML(string strHtml)
    {
        string[] aryReg ={   
                      @"<script[^>]*?>.*?</script>",   
    
                      @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",   
                      @"([\r\n])[\s]+",   
                      @"&(quot|#34);",   
                      @"&(amp|#38);",   
                      @"&(lt|#60);",   
                      @"&(gt|#62);",     
                      @"&(nbsp|#160);",     
                      @"&(iexcl|#161);",   
                      @"&(cent|#162);",   
                      @"&(pound|#163);",   
                      @"&(copy|#169);",   
                      @"&#(\d+);",   
                      @"-->",   
                      @"<!--.*\n"   
                    };

        string[] aryRep =   {   
                        "",   
                        "",   
                        "",   
                        "\"",   
                        "&",   
                        "<",   
                        ">",   
                        "   ",   
                        "\xa1",//chr(161),   
                        "\xa2",//chr(162),   
                        "\xa3",//chr(163),   
                        "\xa9",//chr(169),   
                        "",   
                        "\r\n",   
                        ""   
                      };

        string newReg = aryReg[0];
        string strOutput = strHtml;
        for (int i = 0; i < aryReg.Length; i++)
        {
            Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
            strOutput = regex.Replace(strOutput, aryRep[i]);
        }
        strOutput.Replace("<", "");
        strOutput.Replace(">", "");
        strOutput.Replace("\r\n", "");
        return strOutput;
    }
    #endregion


    #region  ��C#��ȡָ�����ȵ���Ӣ�Ļ���ַ���
    /// <summary>
    ///  C#��ȡָ�����ȵ���Ӣ�Ļ���ַ���
    /// </summary>
    /// <param name="s">Ҫ��ȡ���ַ���</param>
    /// <param name="l">Ҫ��ȡ�ĳ���</param>
    /// <returns></returns>
    public static string CutStr(string s, int l)
    {
        string temp = s.Trim();
        if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= l)
        {
            return temp;
        }
        for (int i = temp.Length; i >= 0; i--)
        {
            temp = temp.Substring(0, i);
            if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= l - 3)
            {
                return temp + "...";
            }
        }
        return "";
    }
    #endregion





}
