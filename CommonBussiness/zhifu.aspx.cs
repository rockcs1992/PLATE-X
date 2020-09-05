using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Data;

namespace CommonBussiness
{
    public partial class zhifu : System.Web.UI.Page
    {
        protected int orderId = CRequest.GetInt("orderId", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            OrderInfo order = OrderService.GetModel(orderId);
            if (order != null)
            {
                ViewState["orderDate"] = order.addTime.ToString("yyyy-MM-dd HH:mm");
                Session["payOrder"] = order;
                ViewState["orderId"] = orderId;
                ViewState["orderTotal"] = order.orderTotal.ToString("0.00");
                ViewState["productCount"] = OrderDetailService.GetProductCount(order.id);
                ViewState["orderNo"] = order.orderNo;
                
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }

    }
}