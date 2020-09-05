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
    public partial class my_shop : System.Web.UI.Page
    {
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
                    sb.Append("<li><a href=\"orders_0.html\" class=\"aa\"><i>My Items</i><span></span></a></li>");
                    sb.Append("<li class=\"li_cur\"><a href=\"my_shop.html\" class=\"aa\"><i>Past Orders</i><span></span></a></li>");
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
                    sb.Append("<li><a href=\"orders_0.html\" class=\"aa\"><i>My Items</i><span></span></a></li>");
                    sb.Append("<li class=\"li_cur\"><a href=\"my_shop.html\" class=\"aa\"><i>Past Orders</i><span></span></a></li>");
                    sb.Append("<li><a href=\"/exit.html\" class=\"aa\"><i>Log Out</i><span></span></a></li>");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetInfo(object productId) 
        {
            StringBuilder sb = new StringBuilder();
            Product item = ProductService.GetModel(Convert.ToInt32(productId));
            if(item != null)
            {
                sb.Append("<a href=\"/project_list_" + item.id + ".html\">");
                sb.Append("<s><img src=\"" + item.listImgUrl + "\" alt=\"" + item.proName + "\"></s>");
                sb.Append("<p>" + item.proName + "</p>");
                sb.Append("<h4>$<span>" + item.price1.ToString("0.00") + "</span>（" + item.unit1 + "）</h4>");
                sb.Append("</a>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                DataSet ds = OrderDetailService.GetProduct(user.id);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    repProduct.DataSource = ds;
                    repProduct.DataBind();
                }
            }
            else
            {
                Response.Redirect("/register.html");
            }
        }
    }
}