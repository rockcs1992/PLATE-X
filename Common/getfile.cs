using System;
using System.Collections.Generic;
using System.Text;
 using System.Web;
using System.IO;
public	class getfile:IHttpHandler
	{

        #region IHttpHandler 成员

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest requ = context.Request;
            HttpResponse res = context.Response;
            string filename = CRequest.GetString("fn");

            if (!File.Exists(context.Server.MapPath(filename)))
            {
                context.Response.Write("文件不存在，或者已经被管理员Delete！");
                context.Response.End();
            }

            if (filename != "" && filename.IndexOf("/")>=0)
            {
                DoFile.ResponseFile(requ, res,filename.Substring( filename.LastIndexOf("/")+1), context.Server.MapPath(filename), 10233);          
            }


        }

        #endregion
    }
 
