using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Data;

namespace CommonBussiness.admin
{
    public partial class showRole : System.Web.UI.Page
    {
        AdminUser loginUser = null;
        #region###窗体加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                //得到当前登录用户的信息
                loginUser = Session["loginUser"] as AdminUser;
                //调用分页
                DataSet ds = SysRoleService.GetList("");
                if(ds.Tables[0].Rows.Count > 0)
                {
                    this.Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
            }
        }
        #endregion

        /// <summary>
        /// 绑定权限分配按钮路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //获取id
            int roleId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "permissi")
            {
                Response.Redirect("RolePermissions.aspx?roleId=" + roleId);
            }
        }
    }
}