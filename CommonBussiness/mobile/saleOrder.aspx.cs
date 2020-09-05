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
    public partial class saleOrder : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id",0);
        protected int infoType = CRequest.GetInt("infoType", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KeyWordBind();

                if (infoType != 100)
                {
                    ViewState["infoType"] = infoType;
                }
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
        /// 获取订单的状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        protected string GetDone(object orderId) 
        {
            DataSet ds = OrderDetailService.GetList("orderId = " + orderId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int infoType = Convert.ToInt32(ds.Tables[0].Rows[0]["infoType"]);
                if (infoType == 0)
                {
                    return "<platex style=' padding:5px 10px; background-color:red;'>Order Placed</platex>";
                }
            }
            return "<platex style=' padding:5px 10px; background-color:green;'>Order Delivered</platex>";
        }
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user == null)
            {
                return;
            }
            if (e.CommandName.Equals("finish"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DataSet ds = OrderDetailService.GetList("orderId = " + id + " and productId in(select id from Product where useId = " + user.id + ")");
                if(ds.Tables[0].Rows.Count > 0)
                {
                    int infoType = Convert.ToInt32(ds.Tables[0].Rows[0]["infoType"]);
                    if (infoType == 0)
                    {
                        OrderDetailService.UpdateInfoTypeByOrderId(user.id,id,1);       //只更新自己的商品状态
                        DataSet ds2 = OrderDetailService.GetList("orderId = " + id);     //循环遍历所有商品，查看是否都备货完毕，更新整个订单的状态。
                        if(ds2.Tables[0].Rows.Count > 0)
                        {
                            bool flag = true;
                            foreach(DataRow dr in ds2.Tables[0].Rows)
                            {
                                if(Convert.ToInt32(dr["infoType"]) == 0)
                                {
                                    flag = false;
                                }
                            }
                            if(flag)    //更新整个订单状态
                            {
                                OrderService.UpdateStatus(id, 1);
                                OrderDetailService.UpdateStatus(id, 1);
                            }
                        }
                    }
                    else
                    {
                        OrderDetailService.UpdateInfoTypeByOrderId(user.id, id, 0);   //只更新自己的商品状态
                        //更新整个订单状态
                        OrderService.UpdateStatus(id, 0);
                        OrderDetailService.UpdateStatus(id, 0);
                    }
                }
            }
            BindData();
        }
        /// <summary>
        /// 获取开票I am a
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        protected string GetProductInfo(object orderId)
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user == null)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            DataSet ds = OrderDetailService.GetList("orderId = " + orderId + " and productId in(select id from Product where useId = " + user.id + ")");
            if(ds.Tables[0].Rows.Count > 0)
            {
                double total = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    total += Convert.ToDouble(ds.Tables[0].Rows[i]["total"]);
                    Product p = ProductService.GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["productId"]));
                    if(p != null)
                    {
                        sb.Append("<p style=\"line-height:25px;margin: 5px 0px;\">");
                        sb.Append("<span class=\"name\" style=\" width:65%;\"><img src=\"" + p.listImgUrl + "\" style=\"width:60px; height:60px; margin-right:5px;\">" + p.proName + "</span>");
                        sb.Append("<span class=\"num\">x" + ds.Tables[0].Rows[i]["productCount"] + "</span>  ");
                        sb.Append("<span class=\"price\">$" + Convert.ToDouble(ds.Tables[0].Rows[i]["total"]).ToString("0.00") + "</span></p>");  
                      
                    }
                }
                sb.Append("<p style='text-align:right;    border-top: 1px #eee solid;    margin: 10px 0px;    padding-top: 10px;'>Total：$" + total.ToString("0.00") + "</p>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取发票信息
        /// </summary>
        /// <returns></returns>
        protected string GetOrderNo(object orderId)
        {
            
            OrderInfo order = OrderService.GetModel(Convert.ToInt32(orderId));
            if(order != null)
            {
                return order.orderNo;
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
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (ViewState["infoType"] != null)
                {
                    DataSet ds = OrderDetailService.GetSaleOrder(user.id, Convert.ToInt32(ViewState["infoType"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        repOrderDetail.DataSource = ds;
                        repOrderDetail.DataBind();
                    }
                    else
                    {
                        repOrderDetail.DataSource = ds;
                        repOrderDetail.DataBind();
                    }
                }
                else
                {
                    DataSet ds = OrderDetailService.GetSaleOrder(user.id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        repOrderDetail.DataSource = ds;
                        repOrderDetail.DataBind();
                    }
                    else
                    {
                        repOrderDetail.DataSource = ds;
                        repOrderDetail.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("/mobile/login.html");
            }
        }
    }
}