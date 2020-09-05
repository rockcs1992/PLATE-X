using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using System.Text;
using Model;
using System.Reflection;

namespace CommonBussiness.mobile
{
    public partial class classify_details : System.Web.UI.Page
    {
        protected int oneId = 1;
        protected int twoId = CRequest.GetInt("twoId", 0);
        protected int threeId = CRequest.GetInt("threeId", 0);
        protected int fourId = CRequest.GetInt("fourId", 0);
        protected int fiveId = CRequest.GetInt("fiveId", 0);
        protected int sixId = CRequest.GetInt("sixId", 0);
        protected int sevenId = CRequest.GetInt("sevenId", 0);
        protected string keywordvalue = CRequest.GetString("keywordvalue");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                if(keywordvalue != "")
                {
                    txtKeyWord.Text = keywordvalue;
                }
                if(twoId != 0)
                {
                    ViewState["twoId"] = twoId;
                }
                if (threeId != 0)
                {
                    ViewState["threeId"] = threeId;
                }
                if (fourId != 0)
                {
                    ViewState["fourId"] = fourId;
                }
                if (fiveId != 0)
                {
                    ViewState["fiveId"] = fiveId;
                }
                if (sixId != 0)
                {
                    ViewState["sixId"] = sixId;
                }
                if (sevenId != 0)
                {
                    ViewState["sevenId"] = sevenId;
                }

                ViewState["priceClass"] = "triangle top_active";
                ViewState["commitClass"] = "triangle top_active";
                ViewState["addtimeClass"] = "triangle top_active";
                //和用户控件交互
                Type ucType = this.bottom1.GetType();
                PropertyInfo PageId = ucType.GetProperty("PageId");
                PageId.SetValue(this.bottom1, 2, null);    
                BindData(0);
                StringBuilder sb = new StringBuilder();
                sb.Append("1=1");
                DataSet ds = ProductTypeService.GetList(sb.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    repType.DataSource = ds;
                    repType.DataBind();
                }
                //sb = new StringBuilder();
                //sb.Append("1=1");
                //if (oneId != 0 && ViewState["twoId"] != null)
                //{
                //    sb.Append(" and oneId = " + oneId + " and twoId = " + ViewState["twoId"]);
                //    ds = ProductTypeService.GetList(sb.ToString());
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        this.repSon.DataSource = ds;
                //        repSon.DataBind();
                //    }
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
                    sb.Append("<span class=\"num\" id=\"carttotal\"></span>");
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
        /// 获取样式类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetAllClass2()
        {
            if (ViewState["twoId"] == null)
            {
                return "allBtn";
            }
            return "allBtn allBtn2";
        }
        /// <summary>
        /// 获取样式类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetAllClass()
        {
            if (ViewState["twoId"] == null)
            {
                return "on";
            }
            return "";
        }
        /// <summary>
        /// 获取样式类GetAllClass
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetClass(object id)
        {
            if(twoId == Convert.ToInt32(id))
            {
                return "on";
            }
            return "";
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData(int num)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (ViewState["twoId"] != null)
            {
                sb.Append(" and productType = " + ViewState["twoId"]);
            }
            if (txtKeyWord.Text.Trim() != "")
            {
                sb.Append(" and proName like '%" + txtKeyWord.Text.Trim() + "%'");
            }
            DataSet ds = ProductService.GetList(sb.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                repInfo.DataSource = ds;
                repInfo.DataBind();
            }
            else
            {
                repInfo.DataSource = null;
                repInfo.DataBind();
            }
            
        }
        /// <summary>
        /// 显示或者隐藏
        /// </summary>
        /// <returns></returns>
        protected string GetMeumClass()
        {
            if (twoId == 0)
            {
                return "none";
            }
            return "block";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            BindData(0);
        }
        
    }
}