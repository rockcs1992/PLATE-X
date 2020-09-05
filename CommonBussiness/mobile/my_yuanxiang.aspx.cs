using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Text;
using System.Reflection;

namespace CommonBussiness.mobile
{
    public partial class my_yuanxiang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                //和用户控件交互
                Type ucType = this.bottom1.GetType();
                PropertyInfo PageId = ucType.GetProperty("PageId");
                PageId.SetValue(this.bottom1, 5, null);                
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
        /// 获取收藏商家Quantity
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        protected int GetShoperCount(int num) 
        {
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                return UserFavoriteInfoService.GetList("addUser = " + user.id + " and typeId = 1 and objId in(select id from UserInfo where infoType = 2 and shopType = " + num + ")").Tables[0].Rows.Count;
            }
            return 0;
            
        }
        /// <summary>
        /// 获取Log In信息
        /// </summary>
        /// <returns></returns>
        protected string GetLoginInfo() 
        {
            StringBuilder sb = new StringBuilder();
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (user.imgUrl != "")
                {
                    sb.Append("<a class=\"touxiang\" href=\"/mobile/data_setup.html\"><img src=\"" + user.imgUrl + "\" class=\"img\"/></a>");
                }
                else
                {
                    sb.Append("<a class=\"touxiang\" href=\"/mobile/data_setup.html\"><img src=\"images/nohead.png\" class=\"img\"/></a>");
                }
                
                if (user.mainbrand != "")
                {
                    sb.Append("<p>" + user.mainbrand + "</p>");
                }
                else
                {
                    sb.Append("<p>" + user.mobile + "</p>");
                }
            }
            else
            {
                Response.Redirect("login.html");
                //sb.Append("<a href=\"login.html\" class=\"loginBtn\" style=\"background-color:#fff; border:1px red solid; color:red;\">Log In</a><a href=\"register.html\" class=\"reBtn\" style=\"background-color:#fff; border:1px red solid; color:red;\">Join</a>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取Plate-X券总金额
        /// </summary>
        /// <returns></returns>
        protected string GetTicketTotal()
        {
            return "0.00";
        }
        /// <summary>
        /// 获取Plate-X卡总金额
        /// </summary>
        /// <returns></returns>
        protected string GetBalance()
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                UserAccount ua =  UserAccountService.GetModelByUserId(user.id);
                if(ua != null)
                {
                    return ua.moneyValue.ToString("0.00");
                }
            }
            return "0.00";
        }
        /// <summary>
        /// 获取Plate-X卡总金额
        /// </summary>
        /// <returns></returns>
        protected string GetTotal()
        {
            
            return "0.00";
        }
        /// <summary>
        /// 获取订单Quantity
        /// </summary>
        /// <returns></returns>
        protected string GetJiFenCount()
        {
            return "0.00";
        }
        /// <summary>
        /// 获取订单Quantity
        /// </summary>
        /// <returns></returns>
        protected int GetProductCount()
        {
            int count = 0;
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                count = ProductService.GetList("id in(select productId from OrderDetail where orderId in (select id from OrderInfo where addUser = " + user.id + " and status in(0,1,2,3,4)))").Tables[0].Rows.Count;
                //count = OrderDetailService.GetProductTypeCount(user.id);
            }
            return count;
        }
        /// <summary>
        /// 获取订单Quantity
        /// </summary>
        /// <returns></returns>
        protected int GetOrderCount() 
        {
            int count = 0;
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                count = OrderService.GetCount(user.id, 100);
            }
            return count;
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {            
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if(user.infoType == 2)
                {
                    Response.Redirect("shop_center.html");
                    return;
                }
                if (user.mobile.Length == 11)
                {
                    ViewState["mobile"] = user.mobile.Substring(0, 3) + "****" + user.mobile.Substring(7, 4);
                }
                if (user.imgUrl == "")
                {
                    ViewState["imgUrl"] = "images/nohead.png";
                }
                else
                {
                    ViewState["imgUrl"] = user.imgUrl;
                }
                ViewState["nameInfo"] = user.relName + " " + user.username;
            }
            else
            {
                Response.Redirect("login.html");
            }
        }
    }
}