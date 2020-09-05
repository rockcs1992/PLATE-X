using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using Model;
using System.IO;

namespace CommonBusiness.admin
{
    public partial class orderQuickInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                LoadData();
            }
        }
        private void LoadData() 
        {
            DataSet ds = Common_OnlineMessageService.GetList("typeId = 2");
            if(ds.Tables[0].Rows.Count > 0)
            {
                this.repInfo.DataSource = ds;
                repInfo.DataBind();
            }
        }
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        protected void repInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Common_OnlineMessageService.Delete(id);
                LoadData();
            }
            if (e.CommandName.Equals("view"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Common_OnlineMessage item = Common_OnlineMessageService.GetModel(id);
                if (item != null)
                {
                    ViewState["mobile"] = item.mobile;
                    ViewState["realName"] = item.name;
                    ViewState["addTime"] = item.addTime.ToString("yyyy-MM-dd HH:mm");
                    ViewState["tel"] = item.tel;
                    ViewState["email"] = item.email;
                    ViewState["qq"] = item.qq;

                    ViewState["address"] = item.qq;
                    ViewState["addTime"] = item.addTime.ToString("yyyy-MM-dd HH:mm");
                    ViewState["mesInfo"] = item.mesContent;

                }
                ScriptManager.RegisterStartupScript(this.form1, GetType(), "", "$('#wfullbg').show();$('#layer').show();", true);
            }
        }

    }
}