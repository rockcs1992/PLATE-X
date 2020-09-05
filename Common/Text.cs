using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Configuration;

/// <summary>
/// 常用文本处理方法
/// </summary>
public class Text
{
    

    #region 过滤脏词 public static string ShitEncode(string s)
    /// <summary>
    /// 过滤脏词，默认有为“妈的|你妈|他妈|妈b|妈比|fuck|shit|我日|法轮|我操”
    /// 可以在 bbs.config 里设置 BadWords 的值
    /// </summary>
    public static string ShitEncode(string s)
    {
        string bw = ConfigHelper.GetConfigString("BadWords");
        if (bw == null || 0 == bw.Length)
        {
            bw = "妈的|你妈|他妈|妈b|妈比|fuck|shit|我日|法轮|我操";
        }
        else
        {
            bw = Regex.Replace(bw, @"\|{2,}", "|");
            bw = Regex.Replace(bw, @"(^\|)|(\|$)", string.Empty);
        }
        return Regex.Replace(s, bw, "**", RegexOptions.IgnoreCase);
    }
    #endregion


    #region 文本编码 	public static string TextEncode(string s)
    /// <summary>
    /// 文本编码
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


    #region HTML 编码 public static string HtmlEncode(string s)
    /// <summary>
    /// HTML 编码
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


    #region HTML 解码 public static string HtmlDecode(string s)
    /// <summary>
    /// HTML 解码
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


    #region TEXT解码		public static string TextDecode(string s)
    /// <summary>
    /// TEXT解码
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


    #region 字符串的长度 public static int Len(string s)
    /// <summary>
    /// 字符串的长度
    /// </summary>
    public static int Len(string s)
    {
        return HttpContext.Current.Request.ContentEncoding.GetByteCount(s);
    }
    #endregion


    #region 去除 htmlCode 中所有的HTML标签(包括标签中的属性) public static string StripHtml(string htmlCode)
    /// <summary>
    /// 去除 htmlCode 中所有的HTML标签(包括标签中的属性)
    /// </summary>
    /// <param name="htmlCode">包含 HTML 代码的字符串。</param>
    /// <returns>返回一个不包含 HTML 代码的字符串</returns>
    public static string StripHtml(string htmlCode)
    {
        if (null == htmlCode || 0 == htmlCode.Length)
        {
            return string.Empty;
        }
        return Regex.Replace(htmlCode, @"<[^>]+>", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Multiline);
    }
    #endregion

    #region 截取字符串
    /// <summary>
    /// 截取字符串
    /// </summary>
    /// <param name="str">原字符串</param>
    /// <param name="len">要截取的长度</param>
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
                    j += System.Text.Encoding.GetEncoding("GB2312").GetByteCount(str.Substring(i, 1));//编码长度
                    if (j <= len)
                    {
                        k++;//字符长度
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
    /// 截取字符串
    /// </summary>
    /// <param name="str">原字符串</param>
    /// <param name="len">要截取的长度</param>
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
                    j += System.Text.Encoding.GetEncoding("GB2312").GetByteCount(str.Substring(i, 1));//编码长度
                    if (j <= len)
                    {
                        k++;//字符长度
                    }
                }
            }
            strings = str.Substring(0, k);
            return strings+"…";
        }
        else
        {
            return str;
        }
    }
    /// <summary>
    /// 将Gb2312编码的字符串转换为utf-8
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

    #region   判断是否有非法字符

    /// <summary>
    /// 判断是否有非法字符
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
    /// 过滤非法字符
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
    /// 过滤字符(SQL)
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
            throw new Exception("字符串中含有非法字符!");
        }
        else
        {
            output = output.Replace("'", "''");
        }
        return output;
    }


    /// <summary>
    /// 分割字符串
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
    /// 去掉首尾P
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
    /// 检测含中文字符串实际长度
    /// </summary>
    /// <param name="str">待检测的字符串</param>
    /// <returns>返回正整数</returns>
    public static int NumChar(string Input)
    {
        ASCIIEncoding n = new ASCIIEncoding();
        byte[] b = n.GetBytes(Input);
        int l = 0;
        for (int i = 0; i <= b.Length - 1; i++)
        {
            if (b[i] == 63)//判断是否为汉字或全脚符号
            {
                l++;
            }
            l++;
        }
        return l;
    }

    /// <summary> 
    /// 汉字转拼音缩写 
    /// 2004-11-30 
    /// </summary> 
    /// <param name="Input">要转换的汉字字符串</param> 
    /// <returns>拼音缩写</returns> 
    public static string GetPYString(string Input)
    {
        string ret = "";
        foreach (char c in Input)
        {
            if ((int)c >= 33 && (int)c <= 126)
            {//字母和符号原样保留 
                ret += c.ToString();
            }
            else
            {//累加拼音声母 
                ret += GetPYChar(c.ToString());
            }
        }
        return ret;
    }

    /// <summary> 
    /// 取单个字符的拼音声母 
    /// 2004-11-30 
    /// </summary> 
    /// <param name="c">要转换的单个汉字</param> 
    /// <returns>拼音声母</returns> 
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


    #region 截断字符串 public static string Left(string s, int need, bool encode)
    /// <summary>
    /// 截断字符串，如果str 的长度超过 need，则提取 str 的前 need 个字符，并在尾部加 “...”
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
    /// 产生个随即Item Name
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
    /// 产生订单号
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
    /// 将字符串中的html代码去掉
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
    /// 将字符串中的html代码去掉 针对单个标签
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
    /// 将字符串中的html代码去掉 针对单个标签xue
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


    #region 去除HTML标记
    ///   <summary>   
    ///   去除HTML标记   
    ///   </summary>   
    ///   <param   name="NoHTML">包括HTML的源码   </param>   
    ///   <returns>已经去除后的文字</returns>   
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
    /// 去掉html标记
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
    /// 截取指定长度字符串
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
            tempString += "…";
        return tempString;
    }

    #region 提取HTML代码中文字的C#函数
    ///提取HTML代码中文字的C#函数     
    ///   <summary>   
    ///   去除HTML标记   
    ///   </summary>   
    ///   <param name="strHtml">包括HTML的源码</param>   
    ///   <returns>已经去除后的文字</returns>   
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


    #region  用C#截取指定长度的中英文混合字符串
    /// <summary>
    ///  C#截取指定长度的中英文混合字符串
    /// </summary>
    /// <param name="s">要截取的字符串</param>
    /// <param name="l">要截取的长度</param>
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
