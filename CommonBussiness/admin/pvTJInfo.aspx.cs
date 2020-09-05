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

namespace QIANCHEN.admin
{
    public partial class pvTJInfo : System.Web.UI.Page
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
                LoadViewInfo();
            }

        }
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            LoadViewInfo();
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadViewInfo() 
        {
            string ip = txtIP.Text.Trim();
            string tFrom = txtTimeFrom.Text.Trim();
            string tEnd = this.txtTimeEnd.Text.Trim();
            ViewState["IP"] = IpSearch.GetIp();

            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (ip.Length != 0)
            {
                sb.Append(" and ip <> '" + ip + "'");
            }
            if (tFrom.Length != 0)
            {
                sb.Append(" and addTime >= '" + Convert.ToDateTime(tFrom) + "'");
            }
            if (tEnd.Length != 0)
            {
                sb.Append(" and addTime <= '" + Convert.ToDateTime(tEnd).ToString("yyyy-MM-dd") + " 23:59:59'");
            }

            ViewState["index"] = PvService.GetViews(sb.ToString(), "index.aspx");
            ViewState["reg"] = PvService.GetViews(sb.ToString(), "reg.aspx");
            ViewState["login"] = PvService.GetViews(sb.ToString(), "login.aspx");
            ViewState["searchList"] = PvService.GetViews(sb.ToString(), "searchList.aspx");

            ViewState["comDetail_client"] = PvService.GetViews(sb.ToString(), "comDetail_client.aspx");
            ViewState["findPass"] = PvService.GetViews(sb.ToString(), "findPass.aspx");

            ViewState["m_comDetail"] = PvService.GetViews(sb.ToString(), "m_comDetail.aspx");



            ViewState["protocol"] = PvService.GetViews(sb.ToString(), "protocol.aspx");
            ViewState["storeList"] = PvService.GetViews(sb.ToString(), "storeList.aspx");
            ViewState["storeMoney"] = PvService.GetViews(sb.ToString(), "storeMoney.aspx");
            ViewState["userCenter"] = PvService.GetViews(sb.ToString(), "userCenter.aspx");
            ViewState["userList"] = PvService.GetViews(sb.ToString(), "userList.aspx");
            ViewState["viewsHistory"] = PvService.GetViews(sb.ToString(), "viewsHistory.aspx");
        }
    }
}