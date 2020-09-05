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

namespace CommonBussiness
{
    public partial class myFavorite : System.Web.UI.Page
    {
        protected int shopType = CRequest.GetInt("shopType", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KeyWordBind();

                if (shopType != 0)
                {
                    if (shopType == 1)
                    {
                        ViewState["shopTypeName"] = "Restaurant";
                    }
                    else if (shopType == 2)
                    {
                        ViewState["shopTypeName"] = "Store";
                    }
                    else
                    {
                        ViewState["shopTypeName"] = "Restaurant";
                    }
                    ViewState["shopType"] = shopType;
                }
                BindData();
                //UserInfo user = Session["user"] as UserInfo;
                //if (user == null)
                //{

                //}

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
        /// 获取购物车中产品的Quantity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string getClass(int num)
        {
            if (shopType == num)
            {
                return "li_cur";
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
                if (ViewState["shopType"] != null)
                {
                    DataSet ds = UserInfoService.GetList("shopType = " + ViewState["shopType"] + " and infoType = 2 and id in(select objId from UserFavoriteInfo where addUser = " + user.id + ")");
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

            }
            else
            {
                Response.Redirect("login.html");
            }
        }
    }
}