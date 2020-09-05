using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using System.Text;
using Model;

namespace CommonBussiness
{
    public partial class top : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
                UserInfo user = Session["user"] as UserInfo;
                if (user != null)
                {
                    if (user.relName != "")
                    {
                        ViewState["isLog"] = "<li>Welcome：" + user.relName + " " + user.username + "</li>";
                    }
                    else
                    {
                        ViewState["isLog"] = "<li>Welcome：" + user.mobile + "</li>";
                    }
                    
                }
                else
                {
                    ViewState["isLog"] = "<li class=\"register01\"><a href=\"/register.html?action=reg\">Join</a></li><li>&nbsp;&nbsp;|&nbsp;&nbsp;</li><li class=\"login01\"><a href=\"/register.html?action=login\">Log In</a></li>";
                }
            }
        }
        /// <summary>
        /// 
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
                    sb.Append("<li><a href=\"/my_person.html\">My Plate-X</a></li>");
                    sb.Append("<li><a href=\"/orders_0.html\">My Cart</a></li>");
                    sb.Append("<li><a href=\"/my_shop.html\">Your Orders</a></li>");
                    sb.Append("<li><a href=\"/myFavorite_1.html\">Your Restaurant</a></li>");
                    sb.Append("<li><a href=\"/myFavorite_2.html\">Your Store</a></li>");
                    sb.Append("<li><a href=\"exit.html\">Log Out</a></li>");
                }
                else
                {
                    sb.Append("<li><a href=\"/shopInfo_edit.html\">My Business Center</a></li>");
                    sb.Append("<li><a href=\"/saleOrder_0.html\">New Orders</a></li>");
                    sb.Append("<li><a href=\"/saleOrder_1.html\">Complete Orders</a></li>");
                    sb.Append("<li><a href=\"/saleOrder_100.html\">Manage My Orders</a></li>");

                    sb.Append("<li><a href=\"/shoper_product.html\">Manage My Items</a></li>");
                    sb.Append("<li><a href=\"/orders_0.html\">My Items</a></li>");
                    sb.Append("<li><a href=\"/my_shop.html\">Past Orders</a></li>");                    
                
                    sb.Append("<li><a href=\"exit.html\">Log Out</a></li>");
                }
            }
            else
            {
                sb.Append("<li><a href=\"/my_person.html\">My Plate-X</a></li>");
                sb.Append("<li><a href=\"/orders_0.html\">My Cart</a></li>");
                sb.Append("<li><a href=\"/my_shop.html\">Your Orders</a></li>");
                sb.Append("<li><a href=\"/my_jifen.html\">Your Restaurant</a></li>");
                sb.Append("<li><a href=\"/my_jifen.html\">Your Store</a></li>");
                sb.Append("<li><a href=\"exit.html\">Log Out</a></li>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取产品Quantity
        /// </summary>
        /// <returns></returns>
        protected  int GetProductCount()
        {
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                return CartTempService.GetProductCount(user.id);
                
            }
            return 0;
        }
        /// <summary>
        /// 获取子类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetSon(object id) 
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = ProductTypeService.GetList("parentId = " + id);
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append(" <li><dl>");
                    sb.Append("<dt><a href=\"/project_" + id + "_" + dr["id"] + "_0_0_0_0_0_0.html\">" + dr["typeName"] + "</a></dt>");
                    sb.Append("<dd>");
                    DataSet ds2 = ProductTypeService.GetList("parentId = " + dr["id"]);
                    if(ds2.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds2.Tables[0].Rows.Count;i++ )
                        {
                            if (i == ds2.Tables[0].Rows.Count - 1)
                            {
                                sb.Append("<p><a href=\"/project_" + id + "_" + dr["id"] + "_" + ds2.Tables[0].Rows[i]["id"] + "_0_0_0_0_0.html\">" + ds2.Tables[0].Rows[i]["typeName"] + " </a></p>");
                            }
                            else
                            {
                                sb.Append("<p><a href=\"/project_" + id + "_" + dr["id"] + "_" + ds2.Tables[0].Rows[i]["id"] + "_0_0_0_0_0.html\">" + ds2.Tables[0].Rows[i]["typeName"] + "  </a>丨</p>");
                            }
                            
                        }
                    }
                    sb.Append("</dd>");

                    sb.Append("</dl></li>");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取样式参数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        protected int GetNum(int num)
        {
            if(num <= 4)
            {
                return num;
            }
            if(num > 4)
            {
                return num - 4;
            }
            return 0;
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            DataSet ds = ProductTypeService.GetList("parentId = 0");
            if(ds.Tables[0].Rows.Count > 0)
            {
                repOne.DataSource = ds;
                repOne.DataBind();
            }
        }
    }
}