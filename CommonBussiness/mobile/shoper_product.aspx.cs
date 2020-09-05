using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
using DAL;

namespace CommonBussiness.mobile
{
    public partial class shoper_product : System.Web.UI.Page
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
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ProductService.Delete(id);                
            }
            BindData();
        }
        /// <summary>
        /// 获取购物车中产品的Quantity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetProductCount(object id)
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user == null)
            {
                List<CartTemp> cartlist = Session["nologinCart"] as List<CartTemp>;
                if (cartlist != null)
                {
                    if (cartlist.Count > 0)
                    {
                        foreach (CartTemp ct in cartlist)
                        {
                            if (ct.productId == Convert.ToInt32(id))
                            {
                                return ct.productCount.ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                Session["nologinCart"] = null;
                CartTemp item = CartTempService.GetModelByProductId(user.id, Convert.ToInt32(id));
                if (item != null)
                {
                    return item.productCount.ToString();
                }
            }
            return "";
        }
        /// <summary>
        /// 获取类
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetNumClass(object productId)
        {
            string str = GetProductCount(productId);
            if (str != "")
            {
                return "num";
            }
            return "num hideNum";

        }
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
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                DataSet ds = ProductService.GetList("useId = " + user.id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    repInfo.DataSource = ds;
                    repInfo.DataBind();
                }
                else
                {
                    this.noList.Visible = true;
                }
            }
            else
            {
                Response.Redirect("login.html");
            }
        }
    }
}