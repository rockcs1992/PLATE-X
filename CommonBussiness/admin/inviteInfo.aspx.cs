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
    public partial class inviteInfo : System.Web.UI.Page
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
        /// <summary>
        /// 查询获取的简历数量
        /// </summary>
        /// <param name="inviteId"></param>
        /// <returns></returns>
        protected int GetResumeCount(object inviteId)
        {
            return ResumeService.GetList("inviteId = " + inviteId).Tables[0].Rows.Count;
        }
        /// <summary>
        /// 详细信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected string GetInfo(object info)
        {
            string desc = Server.HtmlDecode(info.ToString());
            string desc2 = Server.HtmlEncode(info.ToString());
            string descsss = Server.HtmlDecode(desc2);
            string ssss = descsss;
            return desc;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData() 
        {
            DataSet ds = InviteService.GetList("");
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
                InviteService.Delete(id);
                LoadData();
            }
            if(e.CommandName.Equals("mod"))
            {
                Response.Redirect("addInvite.aspx?id=" + e.CommandArgument);
            }
           
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("addInvite.aspx");
        }

    }
}