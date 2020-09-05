using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace CommonBussiness.mobile
{
    public partial class product_details : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KeyWordBind();

                if(id != 0)
                {
                    ViewState["id"] = id;
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
        /// 获取标题
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        protected string GetTitle(int num)
        {
            if(num == 1)
            {
                return "蔬菜起源";
            }
            if (num == 2)
            {
                return "高光时刻";
            }
            if (num == 3)
            {
                return "精挑细选";
            }
            if (num == 4)
            {
                return "亲身看守";
            }
            return "";
        }

        /// <summary>
        /// 获取产品Quantity
        /// </summary>
        /// <returns></returns>
        protected int GetProductCount()
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                return CartTempService.GetProductCount(user.id);

            }
            return 0;
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
                    sb.Append("<span class=\"num totleNum\" id=\"carttotal\">" + count + "</span>");
                }
                else
                {
                    sb.Append("<span class=\"num hideNum\" id=\"carttotal\"></span>");
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
                        foreach (CartTemp ct in list)
                        {
                            total += ct.productCount;
                        }
                        sb.Append("<span class=\"num totleNum\" id=\"carttotal\">" + total + "</span>");
                    }
                    else
                    {
                        sb.Append("<span class=\"num\" id=\"carttotal\"></span>");
                    }
                }
                else
                {
                    sb.Append("<span class=\"\" id=\"carttotal\"></span>");
                }
            }
            return sb.ToString();
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
        /// 显示购物车图标
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetProductDis(object productId)
        {
            StringBuilder sb = new StringBuilder();
            string str = GetProductCount(productId);
            if (str != "")
            {
                return "<em></em><span class=\"num\" id=\"product_" + productId + "\">" + str + "</span>";
            }
            return sb.ToString();
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
        /// 获取图片信息
        /// </summary>
        /// <param name="img1Url"></param>
        /// <param name="img2Url"></param>
        /// <param name="img3Url"></param>
        /// <param name="img4Url"></param>
        /// <returns></returns>
        protected string GetImgInfo(object img1Url, object img2Url, object img3Url, object img4Url)
        {
            StringBuilder sb = new StringBuilder();
            if (img1Url.ToString().Length == 0 && img2Url.ToString().Length == 0 && img3Url.ToString().Length == 0 && img4Url.ToString().Length == 0)
            {

            }
            else
            {
                sb.Append("<ul>");
                if (img1Url.ToString().Length != 0)
                {
                    sb.Append("<li><a href=\"" + img1Url + "\"><img src=\"" + img1Url + "\" style=\"width:80px; height:80px;\"/></a></li>");
                }
                if (img2Url.ToString().Length != 0)
                {
                    sb.Append("<li><a href=\"" + img2Url + "\"><img src=\"" + img2Url + "\" style=\"width:80px; height:80px;\"/></a></li>");
                }
                if (img3Url.ToString().Length != 0)
                {
                    sb.Append("<li><a href=\"" + img3Url + "\"><img src=\"" + img3Url + "\" style=\"width:80px; height:80px;\"/></a></li>");
                }
                if (img4Url.ToString().Length != 0)
                {
                    sb.Append("<li><a href=\"" + img4Url + "\"><img src=\"" + img4Url + "\" style=\"width:80px; height:80px;\"/></a></li>");
                }
                sb.Append("</ul>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="addUser"></param>
        /// <returns></returns>
        protected string GetUser(object addUser, int num)
        {
            UserInfo user = UserInfoService.GetModel(Convert.ToInt32(addUser));
            if (user != null)
            {
                if (num == 1)
                {
                    return user.imgUrl;
                }
                else
                {
                    return user.mobile.Substring(0, 3) + "*****" + user.mobile.Substring(7);
                }
            }
            return "images/tx.jpg";
        }
        /// <summary>
        /// 面包屑
        /// </summary>
        /// <returns></returns>
        protected string GetBread()
        {
            StringBuilder sb = new StringBuilder();
            Product item = ProductService.GetModel(id);
            if (item != null)
            {
                sb.Append("<a href=\"/project_" + item.oneId + "_0_0_0_0_0_0_0.html\">All </a> ");
                if (item.twoId != 0)
                {
                    sb.Append("<span>></span>");
                    ProductType pt = ProductTypeService.GetModel(item.twoId);
                    if (pt != null)
                    {
                        sb.Append(" <a href=\"/project_" + item.oneId + "_" + item.twoId + "_0_0_0_0_0_0.html\">" + pt.typeName + "</a> ");
                    }
                    if (item.threeId != 0)
                    {
                        sb.Append("<span>></span>");
                        pt = ProductTypeService.GetModel(item.threeId);
                        if (pt != null)
                        {
                            sb.Append(" <a href=\"/project_" + item.oneId + "_" + item.twoId + "_" + item.threeId + "_0_0_0_0_0.html\">" + pt.typeName + "</a> ");
                        }
                    }
                }
                sb.Append("<span>></span>");
                sb.Append(" <a href=\"/project_" + item.oneId + "_" + item.twoId + "_" + item.threeId + "_" + item.productType + "_0_0_0_0.html\">" + item.productTypeName + "</a>");
            }

            return sb.ToString();
        }
        
        /// <summary>
        /// 绑定信息
        /// </summary>
        private void BindData()
        {
            Product item = ProductService.GetModel(id);
            if (item != null)
            {
                this.hidStoreCount.Value = item.proType.ToString();
                ViewState["proName"] = item.proName;
                ViewState["proDesc"] = item.proDesc;
                if(item.detailImg1 != "")
                {
                    ViewState["imgInfo"] = "<div class=\"guige\" style=\"text-align:center;\"> <img src='" + item.detailImg1 + "'></div>";
                }
                ViewState["productInfo"] = item.proContent;
                ViewState["specialInfo"] = item.advantage ;
                
                ViewState["unitInfo"] = item.unit1;

                ViewState["price1"] = item.price1.ToString("0.00");
                if(item.proDesc != "")
                {
                    ViewState["goodInfo"] = "<div class=\"guige\">" + item.proDesc + "：" + item.stopTypeName + "</div>";
                }
                
                ViewState["productContent"] = item.ImgDesc;

                UserInfo user = UserInfoService.GetModel(item.useId);
                if(user != null)
                {
                    ViewState["shoperId"] = user.id;
                    ViewState["shoperName"] = user.comName;
                }
                //相关产品
                DataSet ds = ProductService.GetList(16, "productType = " + item.productType, "id");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //repXG.DataSource = ds;
                    //repXG.DataBind();
                }

                //推荐购买
                ProductType pt = ProductTypeService.GetModel(item.productType);
                if (pt != null)
                {
                    ds = ProductService.GetList(10,"productType in(select id from ProductType where parentId = " + pt.parentId + ") and id <> " + id,"id");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        repTj.DataSource = ds;
                        repTj.DataBind();
                    }

                }
                else
                {
                    ds = ProductService.GetList(10, "productType = " + item.productType + " and id <> " + id, "id");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        repTj.DataSource = ds;
                        repTj.DataBind();
                    }

                }
                
                ///bannner
                ds = ProductImgMobileService.GetList("productId = " + item.id + " and infoType = 1");
                if(ds.Tables[0].Rows.Count > 0)
                {
                    repBanner.DataSource = ds;
                    repBanner.DataBind();
                }
            }
        }

    }
}