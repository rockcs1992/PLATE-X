using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DAL;
using Model;
using System.Text;
using System.IO;

namespace CommonBusiness.admin
{
    public partial class modGovAndCerti : System.Web.UI.Page
    {
        int userId = CRequest.GetInt("userId",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                LoadInfo();
            }
        }
        
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadInfo()
        {
            UserBussState item = UserBussStateService.GetModelByUserId(userId);
            if(item != null)
            {
                this.content1.Value = item.serverAddress;
                this.content2.Value = item.serverRName;
            }
           
        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserBussState item = UserBussStateService.GetModelByUserId(userId);
            if (item != null)
            {
                item.serverAddress = this.content1.Value.Trim().Replace("'", "\"");
                item.serverRName = this.content2.Value.Trim().Replace("'", "\"");
                UserBussStateService.UpdateGovAndHonour(item);
            }
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');", true);
        }
        /// <summary>
        /// 重置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.content1.Value = "";
            this.content2.Value = "";
        }
    }
}