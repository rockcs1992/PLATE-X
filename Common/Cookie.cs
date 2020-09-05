using System;
using System.Web;
	/// <summary>
	/// Cookie ��ժҪ˵��
	/// </summary>
	public class Cookie
	{
		/// <summary>
		/// ����Cookies
		/// </summary>
		/// <param name="strName">Cookie ����</param>
		/// <param name="strValue">Cookie ��ֵ</param>
		/// <param name="strDay">Cookie ����</param>
		/// <code>Cookie ck = new Cookie();</code>
		/// <code>ck.setCookie("����","��ֵ","����");</code>
		public bool setCookie(string strName, string strValue, int strDay)
		{
			try
			{
				HttpCookie Cookie = new HttpCookie(strName);
				if(strDay >0)
				{
					Cookie.Expires = DateTime.Now.AddDays(strDay);
				}
				
				Cookie.Value = strValue;
                //Cookie.Domain = ".gkxx.com";
                HttpContext.Current.Response.Cookies.Remove(strName);
				System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
				return true;
			}
			catch
			{
				return false;
			}
		}
		/// <summary>
		/// ��ȡCookies
		/// </summary>
		/// <param name="strName">Cookie ����</param>
		/// <code>Cookie ck = new Cookie();</code>
		/// <code>ck.getCookie("����");</code>
		public string getCookie(string strName)
		{
			HttpCookie Cookie = System.Web.HttpContext.Current.Request.Cookies[strName];
			if (Cookie != null)
			{
				return Cookie.Value.ToString();
			}
			else
			{
				return "";
			}
		}
		/// <summary>
		/// DeleteCookies
		/// </summary>
		/// <param name="strName">Cookie ����</param>
		/// <code>Cookie ck = new Cookie();</code>
		/// <code>ck.delCookie("����");</code>
		public bool delCookie(string strName)
		{
			try
			{
				HttpCookie Cookie = new HttpCookie(strName);
				Cookie.Expires = DateTime.Now.AddDays(-1);
               // Cookie.Domain = ".gkxx.com";
                HttpContext.Current.Response.Cookies.Remove(strName);
				System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
				return true;
			}
			catch
			{
				return false;
			}
		}

	}

