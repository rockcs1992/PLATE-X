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
    public partial class resumeInfo : System.Web.UI.Page
    {
        protected string inviteName = "";
        protected int inviteId = CRequest.GetInt("inviteId",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                if (inviteId != 0)
                {
                    ViewState["inviteId"] = inviteId;
                }
                LoadData();
            }
        }
        private void LoadData() 
        {
            if (ViewState["inviteId"] != null)
            {
                DataSet ds = ResumeService.GetList("inviteId = " + ViewState["inviteId"]);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.repInfo.DataSource = ds;
                    repInfo.DataBind();
                }
                else
                {
                    this.repInfo.DataSource = null;
                    repInfo.DataBind();
                }
            }
            else
            {
                DataSet ds = ResumeService.GetList("");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.repInfo.DataSource = ds;
                    repInfo.DataBind();
                }
                else
                {
                    this.repInfo.DataSource = null;
                    repInfo.DataBind();
                }
            }
            
        }
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        protected void repInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if(e.CommandName.Equals("del"))
            {                
                ResumeService.Delete(id);    
                LoadData();   
            }
            if(e.CommandName.Equals("view"))
            {                
                Resume item = ResumeService.GetModel(id);
                if(item != null)
                {
                    ViewState["inviteName"] = item.inviteName;
                    ViewState["selfInfo"] = item.selfInfo;
                    ViewState["addTime"] = item.addTime.ToString("yyyy-MM-dd HH:mm");
                    ViewState["workYears"] = item.workYears;
                    ViewState["qq"] = item.QQ;
                    ViewState["mobile"] = item.mobile;
                    ViewState["realName"] = item.realName;
                    ViewState["inviteName"] = item.inviteName;
                }
                ScriptManager.RegisterStartupScript(this.form1, GetType(), "", "$('#wfullbg').show();$('#layer').show();", true);
            }
            
        }

    }
}