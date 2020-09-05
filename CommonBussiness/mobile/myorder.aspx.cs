using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Text;
using System.Data;
using System.Reflection;

namespace CommonBussiness.mobile
{
    public partial class myorder : System.Web.UI.Page
    {
        protected int typeId = CRequest.GetInt("typeId", 0);
        int orderId = CRequest.GetInt("orderId", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KeyWordBind();

                //和用户控件交互
                Type ucType = this.bottom1.GetType();
                PropertyInfo PageId = ucType.GetProperty("PageId");
                PageId.SetValue(this.bottom1, 5, null); 
                if(orderId != 0)
                {
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
        /// 移动端列表图片
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetMobileImg(object productId)
        {
            ProductImgMobile item = ProductImgMobileService.GetModelByProductId(Convert.ToInt32(productId));
            if (item != null)
            {
                return item.imgUrl;
            }
            return "";
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
        /// 获取Action信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetDoneInfo(object id,object status) 
        {
            int s = Convert.ToInt32(status);
            StringBuilder sb = new StringBuilder();
            if (s == 0)
            {
                //sb.Append("<a href=\"doneOrder_" + id + ".html?action=delete\" class=\"del\">Delete订单</a><a href=\"payment_" + id + ".html\" class=\"dai\">去付款</a><a href=\"doneOrder_" + id + ".html?action=cancel\" class=\"cancle\">取消订单</a>"); 
                sb.Append("<a href=\"payment_" + id + ".html\" class=\"dai\">去付款</a><a  href=\"doneOrder_" + id + ".html?action=cancel\"  onclick=\"return confirm('确定要取消该订单吗！');\" class=\"cancle\">取消订单</a>");
            }
            else if (s == 2)
            {
                //sb.Append("<a href=\"doneOrder_" + id + ".html?action=delete\" class=\"del\">Delete订单</a><a href=\"payment_" + id + ".html\" class=\"dai\">去付款</a><a href=\"doneOrder_" + id + ".html?action=cancel\" class=\"cancle\">取消订单</a>"); 
                sb.Append("<a  href=\"doneOrder_" + id + ".html?action=recieve\"  onclick=\"return confirm('您确定收到货物了吗！');\" class=\"del\">确认收货</a>");
            }
            else if (s == 3)
            {
                //sb.Append("<a href=\"doneOrder_" + id + ".html?action=delete\" class=\"del\">Delete订单</a><a href=\"payment_" + id + ".html\" class=\"dai\">去付款</a><a href=\"doneOrder_" + id + ".html?action=cancel\" class=\"cancle\">取消订单</a>"); 
                DataSet ds = OrderDetailService.GetList("orderId = " + id);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    int flag = 1;
                    for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                    {
                        if(!CommentService.Exists(ds.Tables[0].Rows[i]["productId"],id))
                        {
                            flag = 0;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        sb.Append("<a href=\"ordercomment_" + id + ".html\" class=\"del\">评论</a>");
                    }
                    else
                    { 
                        //更新状态为4Order Delivered
                        OrderService.UpdateStatus(Convert.ToInt32(id), 4);
                    }
                }
                sb.Append("<a onclick=\"return confirm('确定要Delete该订单吗！');\" href=\"doneOrder_" + id + ".html?action=delete\" class=\"del\">Delete订单</a>");
            }
            else
            {
                sb.Append("<a onclick=\"return confirm('确定要Delete该订单吗！');\" href=\"doneOrder_" + id + ".html?action=delete\" class=\"del\">Delete订单</a>");    
            }
            //if (s == 0)
            //{
            //    sb.Append("<a href=\"payment_" + id + ".html\" class=\"dai\">去付款</a><a href=\"doneOrder_" + id + ".aspx?action=cancel\" class=\"cancle\">取消订单</a>");
            //}
            return sb.ToString();
        }
        /// <summary>
        /// 获取类样式
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        protected string GetTypeClass(int num) 
        {
            if(typeId == num)
            {
                return "active";
            }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        protected int GetProductCount(object orderId) 
        {
            return OrderDetailService.GetProductCount(Convert.ToInt32(orderId));
        }
        /// <summary>
        /// 获取地址信息
        /// </summary>
        /// <returns></returns>
        protected string GetProductImg(object orderId)
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = OrderDetailService.GetList(2,"orderId = " + orderId,"id");
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    Product item = ProductService.GetModel(Convert.ToInt32(dr["productId"]));
                    if(item != null)
                    {
                        sb.Append("<li><a href=\"product_details_" + item.id + ".html\"><img src=\"" + item.listImgUrl + "\"/></a></li>");
                    }
                    
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取样式类
        /// </summary>
        /// <returns></returns>
        protected string GetClass(int status)
        {
            if (typeId == status)
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
            if(user == null)
            {
                return 0;
            }
            if(num != 100)
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
        protected string GetDetail(object id, object status)
        {
            int s = Convert.ToInt32(status);
            StringBuilder sb = new StringBuilder();
            DataSet ds = OrderDetailService.GetList("orderId = " + id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.Append("<li>");
                    sb.Append("<ol class=\"ord_01\">");
                    Product item = ProductService.GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["productId"]));
                    if (item != null)
                    {
                        sb.Append("<li><a href=\"/project_list_" + item.id + ".html\"><img src=\"" + item.listImgUrl + "\" style=\"width:122px; height:120px;\" alt=\"" + item.proName + "\"/></a></li>");
                        sb.Append("<li class=\"shop02\">");
                        sb.Append("<p>" + item.proName + "</p>");
                        sb.Append("<p>" + item.proDesc + "</p>");
                        sb.Append("</li>");
                        sb.Append("<li class=\"shop03\">× <span>" + ds.Tables[0].Rows[i]["productCount"] + "</span></li>");
                        sb.Append("<li class=\"shop04\">$" + Convert.ToDouble(ds.Tables[0].Rows[i]["total"]).ToString("0.00") + "</li>");
                        if (s == 0)
                        {
                            sb.Append("<li class=\"shop05\"><a href=\"/zhifu_" + id + ".html\">去付款</a></li>");
                            sb.Append("<li class=\"shop06\">");
                            sb.Append("<p class=\"remove\" onclick=\"return cancelOrder(" + id + ");\">取消订单</p>");
                            sb.Append("<p><a href=\"/order_detail_" + id + ".html\">订单详情</a></p>");
                            sb.Append("</li>");
                        }
                        if (s == 1)
                        {
                            sb.Append("<li class=\"shop05\">");
                            sb.Append("<a class=\"remove\">待发货</a>");
                            sb.Append("</li>");
                        }
                        if (s == 2)
                        {
                            sb.Append("<li class=\"shop05\">");
                            sb.Append("<a class=\"remove\" onclick=\"return recieveOrder(" + id + ");\">确认收货</a>");
                            sb.Append("</li>");
                        }


                        if (s == 100)
                        {
                            sb.Append("<li class=\"shop05\">");
                            sb.Append("<a href=\"javascript:void(0);\">已取消</a>");
                            sb.Append("</li>");
                        }
                        if (s == 3)
                        {
                            if (!CommentService.Exists(Convert.ToInt32(id), item.id))
                            {
                                sb.Append("<li class=\"shop05\">");
                                sb.Append("<a href=\"judge_" + id + "_" + item.id + ".html\">去评价</a>");
                                sb.Append("</li>");
                            }
                        }
                        if (s == 4)
                        {
                            if (!CommentService.Exists(Convert.ToInt32(id), item.id))
                            {
                                sb.Append("<li class=\"shop05\">");
                                sb.Append("<a href=\"javascript:void(0);\">Order Delivered</a>");
                                sb.Append("</li>");
                            }
                            else
                            {
                                sb.Append("<li class=\"shop05\">");
                                sb.Append("<a href=\"javascript:void(0);\">Order Delivered</a>");
                                sb.Append("</li>");
                            }
                        }
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
            if (user != null)
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
                ViewState["addTime"] = user.addTime.ToString("yyyy年MM月dd日");
                if (typeId == 0)
                {
                    DataSet ds = OrderService.GetList(" status<>150 and addUser = " + user.id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        repInfo.DataSource = ds;
                        repInfo.DataBind();
                    }
                }
                else if (typeId == 99)
                {
                    DataSet ds = OrderService.GetList("addUser = " + user.id + " and status = 0");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        repInfo.DataSource = ds;
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
                }

                #region 过时订单自动更新为取消订单
                //DataSet dsno = OrderService.GetList("status = 0");
                //if(dsno.Tables[0].Rows.Count > 0)
                //{
                //    foreach(DataRow dr in dsno.Tables[0].Rows)
                //    {
                //        object id = dr["id"];
                //        object t = dr["addTime"];
                //        if(DateTime.Now > Convert.ToDateTime(t).AddHours(4))
                //        {
                //            OrderService.UpdateStatus(Convert.ToInt32(id), 100);
                //        }
                //    }
                //}
                #endregion
            }
            else
            {
                Response.Redirect("/mobile/login.html");
            }
        }

    }
}