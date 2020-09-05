using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
using DAL;
using System.Text;

namespace CommonBussiness.admin
{
    public partial class inok : System.Web.UI.Page
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
                else
                {
                    AdminUser item = Session["loginUser"] as AdminUser;
                    ViewState["realName"] = item.realName;
                    ViewState["username"] = item.username;
                    ViewState["role"] = item.roleId;
                    if (item.roleId == 1)
                    {
                        ViewState["roleName"] = "管理员";
                    }
                    else
                    {
                        ViewState["roleName"] = "超级管理员";
                    }
                    

                }
            }
        }
        /// <summary>
        /// 返回菜单信息
        /// </summary>
        /// <returns></returns>
        protected string GetMenu() 
        {
            StringBuilder sb = new StringBuilder();
            AdminUser item = Session["loginUser"] as AdminUser;
            DataSet ds = SysPrivilegesService.GetLevelInfo(item.roleId, 3);
            int menuCount = SysPrivilegesService.GetSonCount(item.roleId, 3);  //总数
            int nowNode = 1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    OALevel levelItem = OALevelService.GetModelByLevelNo(Convert.ToInt32(ds.Tables[0].Rows[i]["levelNo"]));
                    if (levelItem != null)
                    {
                        sb.Append("<div  class=\"left_tab\" style=\"padding-left:30px;\">" + levelItem.levelName + "</div>");
                        sb.Append("<ul>");
                        DataSet ds2 = SysPrivilegesService.GetSonInfo(Convert.ToInt32(ViewState["role"]), 3, Convert.ToInt32(ds.Tables[0].Rows[i]["levelNo"]));
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                            {
                                levelItem = OALevelService.GetModelByLevelNo(Convert.ToInt32(ds2.Tables[0].Rows[j]["levelNo"]));
                                if (levelItem != null)
                                {
                                    sb.Append("<li id=\"m_" + nowNode + "\" onClick=\"dis_cont('" + levelItem.url + "'," + nowNode + "," + ViewState["role"] + "," + menuCount + ")\">" + levelItem.levelName + "</li>");
                                    nowNode++;
                                }
                            }
                        }
                        sb.Append("</ul>");
                    }

                }
            }
            return sb.ToString();
        }        
    }
}