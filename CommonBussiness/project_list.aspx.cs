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

namespace CommonBussiness
{
    public partial class project_list : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                if (id != 0)
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
        /// 获取图片信息
        /// </summary>
        /// <param name="img1Url"></param>
        /// <param name="img2Url"></param>
        /// <param name="img3Url"></param>
        /// <param name="img4Url"></param>
        /// <returns></returns>
        protected string GetImgInfo(object img1Url,object img2Url, object img3Url,object img4Url) 
        {
            StringBuilder sb = new StringBuilder();
            if (img1Url.ToString().Length == 0 || img2Url.ToString().Length == 0 || img3Url.ToString().Length == 0 || img4Url.ToString().Length == 0)
            {

            }
            else
            {
                sb.Append("<ul>");
                if(img1Url.ToString().Length != 0)
                {
                    sb.Append("<li><img src=\"" + img1Url + "\" style=\"width:80px; height:80px;\"/></li>");
                }
                if (img2Url.ToString().Length != 0)
                {
                    sb.Append("<li><img src=\"" + img2Url + "\" style=\"width:80px; height:80px;\"/></li>");
                }
                if (img3Url.ToString().Length != 0)
                {
                    sb.Append("<li><img src=\"" + img3Url + "\" style=\"width:80px; height:80px;\"/></li>");
                }
                if (img4Url.ToString().Length != 0)
                {
                    sb.Append("<li><img src=\"" + img4Url + "\" style=\"width:80px; height:80px;\"/></li>");
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
        protected string GetUser(object addUser,int num) 
        {
            UserInfo user = UserInfoService.GetModel(Convert.ToInt32(addUser));
            if(user != null)
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
            if(item != null)
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
                else
                {
                    sb.Append("<span>></span>");
                    ProductType pt = ProductTypeService.GetModel(item.productType);
                    if (pt != null)
                    {
                        sb.Append(" <a href=\"/project_" + item.oneId + "_" + item.twoId + "_0_0_0_0_0_0.html\">" + pt.typeName + "</a> ");
                    }
                }
                
            }
            
            return sb.ToString();
        }
        /// <summary>
        /// 送达时间
        /// </summary>
        /// <returns></returns>
        protected string GetSendTime() 
        {
            StringBuilder sb = new StringBuilder();
            //送达时间
            if (DateTime.Now.Hour > 10)
            {
                sb.Append("明天(<span>" + DateTime.Now.AddDays(1).ToString("MM月dd日") + "</span>)");
            }
            else
            {
                sb.Append("今天(<span>" + DateTime.Now.ToString("MM月dd日") + "</span>)");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 绑定信息
        /// </summary>
        private void BindData()
        {
            
            Product item = ProductService.GetModel(id);
            if(item != null)
            {
                UserInfo user = UserInfoService.GetModel(item.useId);
                if (user != null)
                {
                    ViewState["shoperId"] = user.id;
                    ViewState["shoperName"] = user.comName;
                }

                ViewState["proName"] = item.proName;
                ViewState["proDesc"] = item.proDesc;
                ViewState["advantage"] = item.advantage;
                ViewState["productType"] = item.productType;
                StringBuilder sb = new StringBuilder();
                if(item.detailImg1 != "")
                {
                    sb.Append("<li><img src=\"" + item.detailImg1 + "\" alt=\"" + item.proName + "\"/></li>");
                }
                if (item.detailImg2 != "")
                {
                    sb.Append("<li><img src=\"" + item.detailImg2 + "\" alt=\"" + item.proName + "\"/></li>");
                }
                if (item.detailImg3 != "")
                {
                    sb.Append("<li><img src=\"" + item.detailImg3 + "\" alt=\"" + item.proName + "\"/></li>");
                }
                if (item.detailImg4 != "")
                {
                    sb.Append("<li><img src=\"" + item.detailImg4 + "\" alt=\"" + item.proName + "\"/></li>");
                }
                ViewState["imgInfo"] = sb.ToString();
                if(sb.ToString().Length == 0)
                {
                    ViewState["noImg"] = item.listImgUrl;
                }

               
                StringBuilder sb2 = new StringBuilder();
                sb = new StringBuilder();
                sb.Append("<ul>");
                if(item.unit1 != "")
                {
                    sb.Append("<li id=\"price1\">" + item.unit1 + "</li>");
                    sb2.Append("<div class=\"rmb\">$ <span>" + item.price1.ToString("0.00") + "</span></div>");
                }
               
                sb.Append("</ul>");

                ViewState["unitInfo"] = sb.ToString();
                ViewState["priceInfo"] = sb2.ToString();

                ViewState["productContent"] = item.proContent;
                //相关产品
                DataSet ds = ProductService.GetList(16,"productType = " + item.productType,"id");
                if(ds.Tables[0].Rows.Count > 0)
                {
                    repXG.DataSource = ds;
                    repXG.DataBind();
                }
            }
        }
    }
}