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

namespace CommonBussiness
{
    public partial class order_detail : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                BindData();
            }
        }
        #region###页面标题、关键字和描述信息
        /// <summary>
        /// 页面标题、关键字和描述信息
        /// </summary>
        private void KeyWordBind()
        {
            string url = Request.Url.ToString().Replace("aspx", "html");

            KeyWordInfo km = KeyWordInfoService.GetModel(url);
            if (km != null)
            {
                ViewState["title"] = km.title;
                ViewState["keyword"] = km.keyword;
                ViewState["miaoshu"] = km.description;
            }
            else
            {
                ViewState["title"] = BaseConfigService.GetById(9);
                ViewState["keyword"] = BaseConfigService.GetById(23);
                ViewState["miaoshu"] = BaseConfigService.GetById(13);
            }
        }
        #endregion
        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <returns></returns>
        protected string GetMenu()
        {
            StringBuilder sb = new StringBuilder();
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (user.infoType == 1)
                {
                    sb.Append("<li class=\"li_cur\"><a href=\"orders_0.html\" class=\"aa\"><i>My Items</i><span></span></a></li>");
                    sb.Append("<li><a href=\"my_shop.html\" class=\"aa\"><i>Past Orders</i><span></span></a></li>");
                    sb.Append("<li><a href=\"my_person.html\" class=\"aa\"><i>Your Account</i><span></span></a></li>");
                    sb.Append("<li><a href=\"myFavorite_1.html\" class=\"aa\"><i>Your Restaurant</i><span></span></a></li>");
                    sb.Append("<li><a href=\"myFavorite_2.html\" class=\"aa\"><i>Your Store</i><span></span></a></li>");
                    sb.Append("<li><a href=\"exit.html\" class=\"aa\"><i>Log Out</i><span></span></a></li>");
                }
                if (user.infoType == 2)
                {
                    sb.Append("<li><a href=\"my_person.html\" class=\"aa\"><i>My Business Center</i><span></span></a></li>");
                    sb.Append("<li><a href=\"saleOrder_0.html\" class=\"aa\"><i>New Orders</i><span></span></a></li>");
                    sb.Append("<li><a href=\"saleOrder_1.html\" class=\"aa\"><i>Complete Orders</i><span></span></a></li>");
                    sb.Append("<li><a href=\"saleOrder_100.html\" class=\"aa\"><i>Manage My Orders</i><span></span></a></li>");
                    sb.Append("<li><a href=\"shoper_product.html\" class=\"aa\"><i>Manage My Items</i><span></span></a></li>");
                    sb.Append("<li class=\"li_cur\"><a href=\"orders_0.html\" class=\"aa\"><i>My Items</i><span></span></a></li>");
                    sb.Append("<li><a href=\"my_shop.html\" class=\"aa\"><i>Past Orders</i><span></span></a></li>");
                    sb.Append("<li><a href=\"/exit.html\" class=\"aa\"><i>Log Out</i><span></span></a></li>");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetProductInfo(object productId,object productCount,object total,object infoType) 
        {
            int s = Convert.ToInt32(infoType);
            StringBuilder sb = new StringBuilder();
            Product item = ProductService.GetModel(Convert.ToInt32(productId));
            if(item != null)
            {
                sb.Append("<li><dl><dt>");
                sb.Append("<a href=\"project_list_" + productId + ".html\"><img src=\"" + item.listImgUrl + "\" style=\"width:118px; height:116px;\"  alt=\"" + item.proName + "\" /></a>");
                sb.Append("</dt><dd>");
                sb.Append(item.proName);
               // <%#Convert.ToInt32(Eval("infoType")) == 0 ? "" : ""%>
                if (s == 0)
                {
                    sb.Append("<a href='shoper_detail_" + item.useId + ".html' target='blank' style='color:red;'>【Order Placed..】</a>");
                }
                else
                {
                    sb.Append("<a style='color:green;'>【Order Delivered】</a>");
                }
                sb.Append("</dd></dl></li>");

                sb.Append("<li><p style=' margin-right:80px;'>× " + productCount + "</p></li>");
                sb.Append("<li><p style=' margin-right:10px;'>$" + Convert.ToDouble(total).ToString("0.00") + "</p></li>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            OrderInfo order = OrderService.GetModel(id);
            if(order != null)
            {
                ViewState["sendTime"] = order.PName;
                
                ViewState["orderNo"] = order.orderNo;

                int s = order.status;
                if (s == 0)
                {
                    ViewState["orderStatus"] = "<span style='color:red;'>Order Placed</span>";
                }
                if (s == 1)
                {
                    ViewState["orderStatus"] = "<span style='color:green;'>Order Delivered</span>";
                }
                
                //if (s == 100)
                //{
                //    ViewState["orderStatus"] = "<span style='color:gray;'>已取消</span>";
                //}
                //if (s == 150)
                //{
                //    ViewState["orderStatus"] = "<span style='color:orange;'>客户端Delete</span>";
                //}
                ViewState["addTime"] = order.addTime.ToString("yyyy-MM-dd");
                ViewState["orderTotal"] = order.orderTotal.ToString("0.00");
                DataSet ds = OrderDetailService.GetList("orderId = " + id);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    repInfo.DataSource = ds;
                    repInfo.DataBind();
                }
            }
        }
    }
}