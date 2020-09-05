using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Text;

namespace CommonBussiness.mobile
{
    public partial class bottom : System.Web.UI.UserControl
    {
        private int pageId;
        public int PageId
        {
            get { return pageId; }
            set { pageId = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 获取跳转路径
        /// </summary>
        /// <returns></returns>
        protected string GetUrl() 
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (user.infoType == 1)
                {
                    return "my_yuanxiang.html";
                }
                else
                {
                    return "shop_center.html";
                }
            }
            else
            {
                return "my_yuanxiang.html";
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        protected string GetClass(int num)
        {
            if (num == pageId)
            {
                return "active";
            }
            return "";
        }
        /// <summary>
        /// 获取购物车产品Quantity
        /// </summary>
        /// <returns></returns>
        protected string GetCarTotal() 
        {
            StringBuilder sb = new StringBuilder();
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                int count = CartTempService.GetProductCount(user.id);
                if (count > 0)
                {
                    sb.Append("<em class=\"totleNum\" id=\"carttotal\">" + count + "</em>");
                }
                else
                {
                    sb.Append("<em class=\"totleNum hideNum\" id=\"carttotal\">0</em>");
                }
            }
            else
            {
                List<CartTemp> list = Session["nologinCart"] as List<CartTemp>;
                if (list != null)
                {
                    int count = list.Count;
                    if (count > 0)
                    {
                        int total = 0;
                        foreach(CartTemp ct in list)
                        {
                            total += ct.productCount;
                        }
                        sb.Append("<em class=\"totleNum\" id=\"carttotal\">" + total + "</em>");
                    }
                    else
                    {
                        sb.Append("<em class=\"totleNum hideNum\" id=\"carttotal\">0</em>");
                    }
                }
                else
                {
                    sb.Append("<em class=\"totleNum hideNum\" id=\"carttotal\">0</em>");
                }
            }
            return sb.ToString();
        }
    }
}