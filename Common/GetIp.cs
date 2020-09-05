using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

   public class GetIp
    {
       private GetIp()
       {

       }

       public static string GetClientIP()
       {
           string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
           if (null == result || result == String.Empty)
           {
               result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
           }

           if (null == result || result == String.Empty)
           {
               result = HttpContext.Current.Request.UserHostAddress;
           }
           return result;
       }

       //根据表达式赛选出IP地址
      //public static string GetClientIP()
      // {
      //     string url = "http://www.ip138.com/ip2city.asp?time=" + DateTime.Now.ToString() + "";
      //     HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
      //     try
      //     {
      //         using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
      //         {
      //             using (StreamReader sr = new StreamReader(res.GetResponseStream()))
      //             {

      //                 //Response.Write(sr.ReadToEnd());

      //                 string strip = sr.ReadToEnd();
      //                return strip.Substring(strip.IndexOf("[") + 1, strip.IndexOf("]") - strip.IndexOf("[") - 1);
      //             }
      //         }
      //     }
      //     catch (System.Exception ex)
      //     {
      //          return ex.Message;
      //     }
      //     finally
      //     {
      //         req.Abort();
      //     }
      // }
      // //访问一个可以获取访问者IP地址的网页，再抓取这个页面
      // public static string GetPage(string url)
      // {
      //     HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
      //     try
      //     {
      //         using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
      //         {
      //             using (StreamReader sr = new StreamReader(res.GetResponseStream()))
      //             {
      //                 return sr.ReadToEnd();
      //             }
      //         }
      //     }
      //     catch (System.Exception e)
      //     {
      //         return e.Message;
      //     }
      //     finally
      //     {
      //         req.Abort();
      //     }
      // }


       /// <summary>
       /// 从IP转换为Int32
       /// </summary>
       /// <param name="IpValue"></param>
       /// <returns></returns>
       public static UInt32 IPToUInt32(string IpValue)
       {
           string[] IpByte = IpValue.Split('.');
           Int32 nUpperBound = IpByte.GetUpperBound(0);
           if (nUpperBound != 3)
           {
               IpByte = new string[4];
               for (Int32 i = 1; i <= 3 - nUpperBound; i++)
                   IpByte[nUpperBound + i] = "0";
           }

           byte[] TempByte4 = new byte[4];
           for (Int32 i = 0; i <= 3; i++)
           {
               //'如果是.Net 2.0可以支持TryParse。
               //'If Not (Byte.TryParse(IpByte(i), TempByte4(3 - i))) Then
               //'    TempByte4(3 - i) = &H0
               //'End If
               if (IsNumeric(IpByte[i]))
                   TempByte4[3 - i] = (byte)(Convert.ToInt32(IpByte[i]) & 0xff);
           }

           return BitConverter.ToUInt32(TempByte4, 0);
       }

       /// <summary>
       /// 判断是否为数字
       /// </summary>
       /// <param name="str">待判断字符串</param>
       /// <returns></returns>
       protected static bool IsNumeric(string str)
       {
           if (str != null && System.Text.RegularExpressions.Regex.IsMatch(str, @"^-?\d+$"))
               return true;
           else
               return false;
       }

    }

