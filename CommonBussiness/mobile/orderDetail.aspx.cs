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
    public partial class orderDetail : System.Web.UI.Page
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
        /// 获取商家id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected int GetShoperId(object productId) 
        {
            Product item = ProductService.GetModel(Convert.ToInt32(productId));
            if(item != null)
            {
                return item.useId;
            }
            return 0;
        }
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
                UserInfo user = Session["user"] as UserInfo;
                if (user != null)
                {
                    if(user.id != item.addUser)
                    {
                        Jscript.AlertAndRedirectJstr("订单异常","history.go(-1);");
                        return;
                    }
                }
                else
                {
                    Response.Redirect("login.html");
                    return;
                }
                //StringBuilder sb = new StringBuilder();
                //DataSet ds = UserAddressService.GetList(1, "id = " + item.pid, "infoType");
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    sb.Append("<p><span class=\"tip\">收件人：</span><span class=\"person\">" + ds.Tables[0].Rows[0]["relName"] + "</span><em class=\"tel\">" + ds.Tables[0].Rows[0]["mobile"] + "</em></p>");
                //    sb.Append("<p class=\"clearfix\"><span class=\"tip fl\">收货地址：</span><span class=\"info fl\">" + ds.Tables[0].Rows[0]["qq"] + ds.Tables[0].Rows[0]["weixin"] + ds.Tables[0].Rows[0]["zipcode"] + ds.Tables[0].Rows[0]["address"] + "</span></p>");
                //    ViewState["defaultAddr"] = sb.ToString();
                //}

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