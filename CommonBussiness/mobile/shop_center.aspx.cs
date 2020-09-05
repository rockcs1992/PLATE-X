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
    public partial class shop_center : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KeyWordBind();

                //和用户控件交互
                Type ucType = this.bottom1.GetType();
                PropertyInfo PageId = ucType.GetProperty("PageId");
                PageId.SetValue(this.bottom1, 5, null);
                //#region 记住Password
                //HttpCookie cookies = Request.Cookies["userInfo"];

                //// 如果此Cookies存在且它里面有子键则进行读取
                //if (cookies != null && cookies.HasKeys)
                //{
                //    string mobile = cookies["Name"].ToString();
                //    string password = cookies["Pwd"].ToString();
                //    string md5Pass = encrypt.EncryptMd5(password);
                //    UserInfo user = UserInfoService.GetModel(mobile, md5Pass);
                //    if (user != null)
                //    {
                //        Session["user"] = user;
                //    }
                //}

                //#endregion
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
        /// 获取Log In信息
        /// </summary>
        /// <returns></returns>
        protected string GetAuditStatus()
        {
            StringBuilder sb = new StringBuilder();
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                user = UserInfoService.GetModel(user.id);
                if(user != null)
                {
                    if (user.status == 0)
                    {
                        return "<span style='color:red;'>【审核中】</span>";
                    }
                    if (user.status == 2)
                    {
                        return "<span style='color:pink;'>【已停用，请联系管理员】</span>";
                    }
                }
                
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取Plate-X券总金额
        /// </summary>
        /// <returns></returns>
        protected int GetFinishOrderCount(int num)
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                return OrderDetailService.GetSaleOrder(user.id, num).Tables[0].Rows.Count;
            }
            return 0;
        }
        /// <summary>
        /// 获取Plate-X券总金额
        /// </summary>
        /// <returns></returns>
        protected int GetNewOrderCount(int num)
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                return OrderDetailService.GetSaleOrder(user.id, num).Tables[0].Rows.Count;
            }
            return 0;
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
                UserAccount ua = UserAccountService.GetModelByUserId(user.id);
                if (ua != null)
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
        protected int GetProductCount(int num)
        {
            int count = 0;
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (num == 2)
                {
                    count = ProductService.GetList("id in(select productId from OrderDetail where orderId in (select id from OrderInfo where addUser = " + user.id + " and status in(0,1,2,3,4)))").Tables[0].Rows.Count;
                }
                else
                {
                    count = ProductService.GetList("useId = " + user.id).Tables[0].Rows.Count;
                }
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
            if (user != null)
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
                if(user.status == 0)
                {
                    ViewState["auditStatus"] = "<span style='color:red;'>【审核中】</span>";
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
                
                ViewState["nameInfo"] = user.comName;
            }
            else
            {
                Response.Redirect("login.html");
            }
        }
    }
}