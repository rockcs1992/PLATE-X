using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;


    public class CRequest
    {
        /// <summary>
        /// ���ز�ѯ�ַ�����������ʽ
        /// </summary>
        /// <param name="name">�ַ���</param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int GetQueryStrintToInt(string name, Page p)
        {
            if (p.Request.QueryString[name] == null || p.Request.QueryString[name].ToString() == "")
            {
                Jscript.DamicAlert();
                return 0;
            }
            else
            {
                int result = 0;
                if (int.TryParse(p.Request.QueryString[name].ToString(), out result))
                {
                    return result;
                }
                else
                {
                    Jscript.DamicAlert();
                    return result;
                }
            }
        }



        /// <summary>
        /// ���ز�ѯ�ַ�����������ʽ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int GetQueryInt(string name, Page p)
        {
            if (p.Request.QueryString[name] == null || p.Request.QueryString[name].ToString() == "")
            {
                Jscript.DamicAlert();
                return -1;
            }
            else
            {
                int result = -1;
                if (int.TryParse(p.Request.QueryString[name].ToString(), out result))
                {
                    return result;
                }
                else
                {
                    Jscript.DamicAlert();
                    return result;
                }
            }
        }


        /// <summary>
        /// ���ز�ѯ�ַ�����������ʽ,�������Զ���ʾ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int GetQueryIntNoAlert(string name, Page p)
        {
            if (p.Request.QueryString[name] == null || p.Request.QueryString[name].ToString() == "")
            {                
                return -1;
            }
            else
            {
                int result = -1;
                if (int.TryParse(p.Request.QueryString[name].ToString(), out result))
                {
                    return result;
                }
                else
                {
                     return result;
                }
            }
        }



        /// <summary>
        /// �жϵ�ǰҳ���Ƿ���յ���Post����
        /// </summary>
        /// <returns>�Ƿ���յ���Post����</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /// <summary>
        /// �жϵ�ǰҳ���Ƿ���յ���Get����
        /// </summary>
        /// <returns>�Ƿ���յ���Get����</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// ����ָ���ķ�����������Ϣ
        /// </summary>
        /// <param name="strName">������������</param>
        /// <returns>������������Ϣ</returns>
        public static string GetServerString(string strName)
        {
            //
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        /// <summary>
        /// ������һ��ҳ��ĵ�ַ
        /// </summary>
        /// <returns>��һ��ҳ��ĵ�ַ</returns>
        public static string GetUrlReferrer()
        {
            string retVal = null;

            try
            {
                retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }

            if (retVal == null)
                return "";

            return retVal;

        }

        /// <summary>
        /// �õ���ǰ��������ͷ
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
            {
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
            }
            return request.Url.Host;
        }

        /// <summary>
        /// �õ�����ͷ
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }


        /// <summary>
        /// ��ȡ��ǰ�����ԭʼ URL(URL ������Ϣ֮��Ĳ���,������ѯ�ַ���(�������))
        /// </summary>
        /// <returns>ԭʼ URL</returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        /// <summary>
        /// �жϵ�ǰ�����Ƿ�������������
        /// </summary>
        /// <returns>��ǰ�����Ƿ�������������</returns>
        public static bool IsBrowserGet()
        {
            string[] BrowserName = { "ie", "opera", "netscape", "mozilla" };
            string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < BrowserName.Length; i++)
            {
                if (curBrowser.IndexOf(BrowserName[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// �ж��Ƿ�����������������
        /// </summary>
        /// <returns>�Ƿ�����������������</returns>
        public static bool IsSearchEnginesGet()
        {
            string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom" };
            string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < SearchEngine.Length; i++)
            {
                if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ��õ�ǰ����Url��ַ
        /// </summary>
        /// <returns>��ǰ����Url��ַ</returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }


        /// <summary>
        /// ���ָ��Url������ֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <returns>Url������ֵ</returns>
        public static string GetQueryString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.QueryString[strName];
        }

        /// <summary>
        /// ��õ�ǰҳ���Item Name
        /// </summary>
        /// <returns>��ǰҳ���Item Name</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /// <summary>
        /// ��õ�ǰҳ������ڵ��ļ���
        /// </summary>
        /// <returns>��ǰҳ���Item Name</returns>
        public static string GetPageFile()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 2].ToLower();
        }

        /// <summary>
        /// ���ر���Url�������ܸ���
        /// </summary>
        /// <returns></returns>
        public static int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }


        /// <summary>
        /// ���ָ����������ֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <returns>��������ֵ</returns>
        public static string GetFormString(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName];
        }

        /// <summary>
        /// ���Url���������ֵ, ���ж�Url�����Ƿ�Ϊ���ַ���, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <returns>Url���������ֵ</returns>
        public static string GetString(string strName)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                return GetFormString(strName);
            }
            else
            {
                return GetQueryString(strName);
            }
        }


        /// <summary>
        /// ���ָ��Url������intI am aֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url������intI am aֵ</returns>
        public static int GetQueryInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// ���ָ����������intI am aֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>��������intI am aֵ</returns>
        public static int GetFormInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// ���ָ��Url���������intI am aֵ, ���ж�Url�����Ƿ�Ϊȱʡֵ, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">Url�������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url���������intI am aֵ</returns>
        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
            {
                return GetFormInt(strName, defValue);
            }
            else
            {
                return GetQueryInt(strName, defValue);
            }
        }

        /// <summary>
        /// ���ָ��Url������floatI am aֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url������intI am aֵ</returns>
        public static float GetQueryFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// ���ָ����������floatI am aֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>��������floatI am aֵ</returns>
        public static float GetFormFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// ���ָ��Url���������floatI am aֵ, ���ж�Url�����Ƿ�Ϊȱʡֵ, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">Url�������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url���������intI am aֵ</returns>
        public static float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
            {
                return GetFormFloat(strName, defValue);
            }
            else
            {
                return GetQueryFloat(strName, defValue);
            }
        }

        /// <summary>
        /// ��õ�ǰҳ��ͻ��˵�IP
        /// </summary>
        /// <returns>��ǰҳ��ͻ��˵�IP</returns>
        public static string GetIP()
        {


            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            if (null == result || result == String.Empty || !Utils.IsIP(result))
            {
                return "0.0.0.0";
            }

            return result;

        }

        /// <summary>
        /// Save�û�Upload���ļ�
        /// </summary>
        /// <param name="path">Save·��</param>
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }

        //		/// <summary>
        //		/// SaveUpload���ļ�
        //		/// </summary>
        //		/// <param name="MaxAllowFileCount">��������Upload�ļ�����</param>
        //		/// <param name="MaxAllowFileSize">���������ļ�����(��λ: KB)</param>
        //		/// <param name="AllowFileExtName">������ļ���չ��, ��string[]��ʽ�ṩ</param>
        //		/// <param name="AllowFileType">������ļ�I am a, ��string[]��ʽ�ṩ</param>
        //		/// <param name="Dir">Ŀ¼</param>
        //		/// <returns></returns>
        //		public static Forum.AttachmentInfo[] SaveRequestFiles(int MaxAllowFileCount, int MaxAllowFileSize, string[] AllowFileExtName, string[] AllowFileType, string Dir)
        //		{
        //			int savefilecount = 0;
        //			
        //			int fcount = Math.Min(MaxAllowFileCount, HttpContext.Current.Request.Files.Count);
        //
        //			Forum.AttachmentInfo[] attachmentinfo = new Forum.AttachmentInfo[fcount];
        //			for(int i=0;i<fcount;i++)
        //			{
        //				string filename = HttpContext.Current.Request.Files[i].FileName;
        //				string fileextname = filename.Substring(filename.LastIndexOf("."));
        //				string filetype = HttpContext.Current.Request.Files[i].ContentType;
        //				int filesize = HttpContext.Current.Request.Files[i].ContentLength;
        //				// �ж� �ļ���չ��/�ļ���С/�ļ�I am a �Ƿ����Ҫ��
        //				if(Utils.InArray(fileextname, AllowFileExtName) && (filesize <= MaxAllowFileSize * 1024) && Utils.InArray(filetype, AllowFileType))
        //				{
        //
        //					HttpContext.Current.Request.Files[i].SaveAs(Dir + Utils.GetDateTime() + Environment.TickCount.ToString() + fileextname);
        //					attachmentinfo[savefilecount].Filename = filename;
        //					attachmentinfo[savefilecount].Filesize = filesize;
        //					attachmentinfo[savefilecount].Description = filetype;
        //					attachmentinfo[savefilecount].Filetype = fileextname;
        //					savefilecount++;
        //				}
        //			}
        //			return attachmentinfo;
        //			
        //		}

    }

