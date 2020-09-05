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

namespace CommonBussiness
{
    public partial class back_orderDetail : System.Web.UI.Page
    {
        protected int orderId = CRequest.GetInt("orderId", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// 获取地址信息
        /// </summary>
        /// <returns></returns>
        protected string GetAddr(object pid) 
        {
            UserAddress ua = UserAddressService.GetModel(Convert.ToInt32(pid));            
            if (ua != null)
            {
                 return ua.zipcode + " " + ua.address;
            }
            return "";
        }
        /// <summary>
        /// 获取订单Quantity
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        protected int GetCount(int num) 
        {
            return OrderService.GetList("status = " + num).Tables[0].Rows.Count;
        }
        /// <summary>
        /// 获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetDetail(object id,object status) 
        {
            int s = Convert.ToInt32(status);
            StringBuilder sb = new StringBuilder();
            DataSet ds = OrderDetailService.GetList("orderId = " + id);
            if(ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ ) 
                {
                    sb.Append("<li>");
                    sb.Append("<ol class=\"ord_01\">");
                    Product item = ProductService.GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["productId"]));
                    if(item != null)
                    {
                        sb.Append("<li><a href=\"/project_list_" + item.id + ".html\" target='_blank'><img src=\"" + item.listImgUrl + "\" style=\"width:122px; height:120px;\" alt=\"" + item.proName + "\"/></a></li>");
                        sb.Append("<li class=\"shop02\">");
                        sb.Append("<p>" + item.proName + "</p>");
                        sb.Append("<p>" + item.proDesc + "</p>");
                        sb.Append("</li>");
                        sb.Append("<li class=\"shop03\">× <span>" + ds.Tables[0].Rows[i]["productCount"] + "</span></li>");
                        sb.Append("<li class=\"shop04\">$" + Convert.ToDouble(ds.Tables[0].Rows[i]["total"]).ToString("0.00") + "</li>");
                    }
                    sb.Append("</ol>");
                    sb.Append("</li>");

                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 绑定信息
        /// </summary>
        private void BindData()
        {
            DataSet ds = OrderService.GetList("id = " + orderId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                repInfo.DataSource = ds;
                repInfo.DataBind();
            }
        }

    }
}