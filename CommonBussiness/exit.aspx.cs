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

namespace CommonBussiness
{
    public partial class exit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HttpCookie aCookie;
                string cookieName;
                int limit = Request.Cookies.Count;
                for (int i = 0; i < limit; i++)
                {
                    cookieName = Request.Cookies[i].Name;
                    aCookie = new HttpCookie(cookieName);
                    aCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(aCookie);
                }
                //Session.RemoveAll();
                //Session.Clear();
                if (CRequest.GetString("action").Equals("sysback"))
                {
                    Session["loginUser"] = null;
                    Response.Redirect("/admin/login.aspx");
                }
                else
                {
                    Session["user"] = null;
                    Response.Redirect("login.html");                    
                }
                
              // Jscript.AlertAndRedirect("安全Log Out成功", "/");
               // Jscript.AlertAndRedirectJstr("安全Log Out成功", "window.parent.location.href='login.html'");//.Response.Write("ok");
            }
        }
    }
}
