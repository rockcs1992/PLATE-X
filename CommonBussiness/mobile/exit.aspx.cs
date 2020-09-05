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

namespace CommonBussiness.mobile
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
                Session.RemoveAll();
                Session.Clear();
                Session["user"] = null;
                Response.Redirect("my_yuanxiang.html");
              // Jscript.AlertAndRedirect("安全Log Out成功", "/");
               // Jscript.AlertAndRedirectJstr("安全Log Out成功", "window.parent.location.href='login.html'");//.Response.Write("ok");
            }
        }
    }
}
