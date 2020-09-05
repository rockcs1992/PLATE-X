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

namespace CommonBussiness.admin
{
    public partial class motherList : System.Web.UI.Page
    {
        Page_ZH sp = new Page_ZH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                //LoadData();
                sp.InitBindData(repInfo, pager1, "AboutMenu", "id", sear());
            }
        }
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");

            return sb.ToString();
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            sp.InitBindData(repInfo, pager1, "AboutMenu", "id", sear());
        }
        /// <summary>
        /// 添加友情连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.txtLinkName.Text.Trim();
            string title = txtTitle.Text.Trim();
            string content = this.content1.Value;
            if (name.Length == 0 || content.Length == 0)
            {
                lblError.Text="各项不能为空";
                return;
            }
            AboutMenu item = new AboutMenu();
            item.proName = name;
            item.proValue = content;
            item.infoType = 0;
            item.remark = title;
            if (lblId.Text != "")
            {
                item.id = Convert.ToInt32(lblId.Text.Trim());
                AboutMenuService.Update(item);
            }
            else
            {
                AboutMenuService.Add(item);
            }
            pnlAdd.Visible = false;
            pnlList.Visible = true;
            sp.InitBindData(repInfo, pager1, "AboutMenu", "id", sear());
        }
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                AboutMenuService.Delete(id);
            }
            if (e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                AboutMenu item = AboutMenuService.GetModel(id);
                if(item != null)
                {;
                    txtLinkName.Text = item.proName;
                    txtTitle.Text = item.remark;
                    lblId.Text = item.id.ToString();
                    content1.Value = item.proValue;
                    pnlAdd.Visible = true;
                    pnlList.Visible = false;
                }
            }
            sp.InitBindData(repInfo, pager1, "AboutMenu", "id", sear());
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;
            pnlList.Visible = false;
            txtLinkName.Text = "";
            content1.Value = "";
            lblId.Text = "";
            lblError.Text = "";
            txtTitle.Text = "";
        }

    }
}