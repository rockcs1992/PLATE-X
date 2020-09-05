using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;
using System.Data;
using System.Text;

namespace CommonBussiness.admin
{
    public partial class main : System.Web.UI.Page
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
        /// 促销状态
        /// </summary>
        /// <returns></returns>
        protected string GetCuXiaoStatus(object shStatus,object status,object endDate) 
        {
            if(shStatus.ToString() == "1")
            {
                return "未进行";
            }else
            {
                if(status.ToString() == "2")
                {
                    return "未进行";
                }
                else
                {
                    if(Convert.ToDateTime(endDate) <= DateTime.Now)
                    {
                        return "已过期";
                    }else
                    {
                        if(status.ToString() == "3")
                        {
                            return "已暂停";
                        }else
                        {
                            return "促销中";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void LoadInfo()
        {
            
        }

    }
}