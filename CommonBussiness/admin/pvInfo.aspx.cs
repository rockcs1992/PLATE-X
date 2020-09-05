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
using System.Text;
using CommonBussiness;

namespace QIANCHEN.admin
{
    public partial class pvInfo : System.Web.UI.Page
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
                sp.InitBindData(repInfo, pager1, "Pv", "id", sear());
            }
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            sp.InitBindData(repInfo, pager1, "Pv", "id", sear());
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("pvTjInfo.aspx");
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            sp.InitBindData(repInfo, pager1, "Pv", "id", sear());
        }
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if(this.txtIP.Text.Trim() != "")
            {
                sb.Append(" and ip = '" + txtIP.Text.Trim() + "'");
            }
            if (txtTimeFrom.Text.Trim() != "")
            {
                sb.Append(" and addTime >= '" + txtTimeFrom.Text.Trim() + "' ");
            }
            if (txtTimeEnd.Text.Trim() != "")
            {
                sb.Append(" and addTime <= '" + Convert.ToDateTime(txtTimeEnd.Text.Trim()).ToString("yyyy-MM-dd") + " 23:59:59' ");
            }

            if (this.txtName.Text.Trim() != "")
            {
                sb.Append(" and pageName like '%" + txtName.Text.Trim() + "%'");
            }
            if(txtPageValue.Text.Trim() != "")
            {
                sb.Append(" and pageValue like '%" + txtPageValue.Text.Trim() + "%'");
            }
            return sb.ToString();
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
                PvService.Delete(id); 
            }
            sp.InitBindData(repInfo, pager1, "Pv", "id", sear());
        }

    }
}