using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using Model;

namespace CommonBussiness.admin
{
    public partial class gonggao : System.Web.UI.Page
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
        /// 添加人姓名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected string GetUserName(object userId)
        {
            AdminUser au = AdminUserService.GetModel(Convert.ToInt32(userId));
            if(au != null)
            {
                return au.realName;
            }
            return "";
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData() 
        {
            DataSet ds = GongGaoInfoService.GetList("");
            if(ds.Tables[0].Rows.Count > 0)
            {
                this.repInfo.DataSource = ds;
                repInfo.DataBind();
            }
        }
        /// <summary>
        /// 添加公告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string title = this.txtTitle.Text.Trim();
            string content = this.txtContent.Text.Trim();
            string url = txtURL.Text.Trim();
            if (title.Length == 0 || content.Length == 0 || url.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('各项不能为空!');", true);
                return;
            }
            GongGaoInfo item = new GongGaoInfo();
            item.title = title;
            item.gongGaoContent = content;
            item.status = 0;
            item.addTime = DateTime.Now;

            if (Session["loginUser"] == null)
            {
                Response.Redirect("/admin/login.aspx");
                return;
            }
            AdminUser admin = Session["loginUser"] as AdminUser;
            item.addUser = admin.id;
            item.infoType = 0;
            item.linkurl = url;
            int num = GongGaoInfoService.Add(item);
            if (num > 0)
            {
                
                //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('添加成功!');location.href='link.aspx';", true);
            }
            else
            {
               // ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('添加失败!');location.href='link.aspx';", true);
            }
            LoadData();
        }
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton lbtnDel = e.Item.FindControl("lbtnDel") as LinkButton;//删除超连接
            Label lblId = e.Item.FindControl("lblId") as Label;//ID          
            lbtnDel.PostBackUrl = "/jsData/common.aspx?action=delGongGao&id=" + lblId.Text;            
        }

    }
}