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

namespace CommonBussiness.mobile
{
    public partial class orderDetailBack : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id",0);
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
        /// 获取开票I am a
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string GetTypeName(int num)
        {
            if (num == 1)
            {
                return "礼品";
            }
            if (num == 2)
            {
                return "蔬菜水果";
            }
            if (num == 3)
            {
                return "礼品";
            }
            if (num == 4)
            {
                return "广告费";
            }
            if (num == 5)
            {
                return "办公用品";
            }
            if (num == 6)
            {
                return "会议";
            }
            return "";
        }
        /// <summary>
        /// 获取发票信息
        /// </summary>
        /// <returns></returns>
        protected string GetInvoice()
        {
            StringBuilder sb = new StringBuilder();
            
            return sb.ToString();

        }
        /// <summary>
        /// 产品Item Name
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetProductName(object productId) 
        {
            Product item = ProductService.GetModel(Convert.ToInt32(productId));
            if(item != null)
            {
                return item.proName;
            }
            return "";
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            OrderInfo item = OrderService.GetModel(id);
            if(item != null)
            {
                StringBuilder sb = new StringBuilder();
                UserInfo user = UserInfoService.GetModel(item.addUser);
                if (user != null)
                {
                    sb.Append("<p><span class=\"tip\">收件人：</span><span class=\"person\">" + user.relName + " " + user.username + "</span></p>");
                    sb.Append("<p><span class=\"tip\">联系方式：</span><span class=\"person\">" + user.mobile + "</span></p>");
                    sb.Append("<p class=\"clearfix\"><span class=\"tip fl\">街道：</span><span class=\"info fl\">" + user.mobileCode + "</span></p>");
                    sb.Append("<p class=\"clearfix\"><span class=\"tip fl\">市：</span><span class=\"info fl\">" + user.activeCode + "</span></p>");
                    sb.Append("<p class=\"clearfix\"><span class=\"tip fl\">州：</span><span class=\"info fl\">" + user.mainbrand + "</span></p>");
                    ViewState["defaultAddr"] = sb.ToString();
                }

                ViewState["productCount"] = OrderDetailService.GetProductCount(item.id);
                DataSet ds = OrderDetailService.GetList("orderId = " + item.id);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    repOrderDetail.DataSource = ds;
                    repOrderDetail.DataBind();

                }

                ViewState["sendDate"] = item.PName;



            }
        }
        /// <summary>
        ///提交订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            
        }
    }
}