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
    public partial class aboutSet : System.Web.UI.Page
    {
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
            this.content1.Value = AboutMenuService.GetById(1);
            this.content2.Value = AboutMenuService.GetById(2);
        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            AboutMenuService.SetValue(1, this.content1.Value.Trim().Replace("'", "\""));
            AboutMenuService.SetValue(2, this.content2.Value.Trim().Replace("'", "\""));
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