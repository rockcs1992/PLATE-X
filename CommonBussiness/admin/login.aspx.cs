using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;

namespace CommonBussiness.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.txtUserName.Text.Trim();
            string pass = this.txtPassWord.Text.Trim();
            if(name.Length == 0 || pass.Length == 0)
            {
                Jscript.Alert("各项不能为空");
                return ;
            }
            AdminUser item = AdminUserService.GetModel(name,pass);
            if (item != null && item.status == 1)
            {                
                Session["loginUser"] = item;
                Response.Redirect("inok.aspx");
            }
            else
            {
                Jscript.AlertAndRedirect("无此账号或已被停用，请联系超级管理员！",this.Request.RawUrl);
            }
        }
    }
}