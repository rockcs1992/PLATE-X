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
    public partial class orders : System.Web.UI.Page
    {
        protected int typeId = CRequest.GetInt("typeId",0);
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
            if(user != null)
            {
                if(user.infoType == 1)
                {
                    sb.Append("<li class=\"li_cur\"><a href=\"orders_0.html\" class=\"aa\"><i>My Items</i><span></span></a></li>");
                    sb.Append("<li><a href=\"my_shop.html\" class=\"aa\"><i>Past Orders</i><span></span></a></li>");
                    sb.Append("<li><a href=\"my_person.html\" class=\"aa\"><i>Your Account</i><span></span></a></li>");
                    sb.Append("<li><a href=\"myFavorite_1.html\" class=\"aa\"><i>Your Restaurant</i><span></span></a></li>");
                    sb.Append("<li><a href=\"myFavorite_2.html\" class=\"aa\"><i>Your Store</i><span></span></a></li>");
                    sb.Append("<li><a href=\"exit.html\" class=\"aa\"><i>Log Out</i><span></span></a></li>");
                }
                if(user.infoType == 2)
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
        /// 获取状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetStatus(object status)
        {
            int s = Convert.ToInt32(status);
            if (s == 0)
            {
                return "Order Placed";
            }
            if (s == 1)
            {
                return "Order Delivered";
            }
            if (s == 2)
            {
                return "待收货";
            }
            if (s == 3)
            {
                return "待评价";
            }
            if (s == 4)
            {
                return "Order Delivered";
            }
            if (s == 100)
            {
                return "已取消";
            }

            return "";
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
                return AreaInfoService.GetName(Convert.ToInt32(ua.qq)) + " " + AreaInfoService.GetName(Convert.ToInt32(ua.weixin)) + " " + AreaInfoService.GetName(Convert.ToInt32(ua.zipcode)) + " " + ua.address + " " + ua.addressDetail;
            }
            return "";
        }
        /// <summary>
        /// 获取样式类
        /// </summary>
        /// <returns></returns>
        protected string GetClass(int status) 
        {
            if(typeId == status)
            {
                return "title_cur";
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
            UserInfo user = Session["user"] as UserInfo;
            if (user == null)
            {
                return 0;
            }
            if (num != 100)
            {
                return OrderService.GetList("addUser = " + user.id + " and status = " + num).Tables[0].Rows.Count;
            }
            return OrderService.GetList(" status<>100 and status<>150 and addUser = " + user.id).Tables[0].Rows.Count;
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
                        sb.Append("<li><a href=\"/project_list_" + item.id + ".html\"><img src=\"" + item.listImgUrl + "\" style=\"width:122px; height:120px;\" alt=\"" + item.proName + "\"/></a></li>");
                        sb.Append("<li class=\"shop02\">");
                        sb.Append("<p>" + item.proName + "</p>");
                        sb.Append("<p>" + item.proDesc + "</p>");
                        sb.Append("</li>");
                        sb.Append("<li class=\"shop03\">× <span>" + ds.Tables[0].Rows[i]["productCount"] + "</span></li>");
                        sb.Append("<li class=\"shop04\">$" + Convert.ToDouble(ds.Tables[0].Rows[i]["total"]).ToString("0.00") + "</li>");
                        sb.Append("<li class=\"shop05\"><a href=\"/order_detail_" + id + ".html\">Details>></a></li>"); 
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
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                if (user.imgUrl != "")
                {
                    ViewState["headImg"] = user.imgUrl;
                }
                else
                {
                    ViewState["headImg"] = "images/zhifu/orders01.jpg";
                }
                
                ViewState["mobile"] = user.mobile;
                ViewState["addTime"] = user.addTime.ToString("yyyy/MM/dd");
                if(typeId == 0)
                {
                    DataSet ds = OrderService.GetList("addUser = " + user.id + " and status <> 150");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        repInfo.DataSource = ds;
                        repInfo.DataBind();
                    }
                    else
                    {
                        repInfo.DataSource = null;
                        repInfo.DataBind();
                    }
                }else if(typeId == 99)
                {
                    DataSet ds = OrderService.GetList("addUser = " + user.id + " and status = 0");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        repInfo.DataSource = ds;
                        repInfo.DataBind();
                    }
                    else
                    {
                        repInfo.DataSource = null;
                        repInfo.DataBind();
                    }
                }
                else
                {
                    DataSet ds = OrderService.GetList("addUser = " + user.id + " and status = " + typeId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        repInfo.DataSource = ds;
                        repInfo.DataBind();
                    }
                    else
                    {
                        repInfo.DataSource = null;
                        repInfo.DataBind();
                    }
                }
                
            }
            else
            {
                Response.Redirect("/register.html");
            }
        }

    }
}