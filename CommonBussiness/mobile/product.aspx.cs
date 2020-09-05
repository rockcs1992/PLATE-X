using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DAL;
using Model;

namespace CommonBussiness.mobile
{
    public partial class product : System.Web.UI.Page
    {
        protected int typeId = CRequest.GetInt("typeId", 0);
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
        /// 获取图片信息
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="img2"></param>
        /// <param name="img3"></param>
        /// <returns></returns>
        protected string GetImg(object img1, object img2, object img3)
        {
            StringBuilder sb = new StringBuilder();
            if (img1.ToString() != "")
            {
                sb.Append("<li><a href=\"" + img1 + "\"><img src=\"" + img1 + "\"/></a></li>");
            }
            if (img2.ToString() != "")
            {
                sb.Append("<li><a href=\"" + img2 + "\"><img src=\"" + img2 + "\"/></a></li>");
            }
            if (img3.ToString() != "")
            {
                sb.Append("<li><a href=\"" + img3 + "\"><img src=\"" + img3 + "\"/></a></li>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            Product pt = ProductService.GetModel(typeId);
            if(pt != null)
            {
                ProductImgMobile item = ProductImgMobileService.GetMobileBanner(pt.id);
                if(item != null)
                {
                    ViewState["typeImg"] = item.imgUrl;
                }
                
                ViewState["typeName"] = pt.proName;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (typeId != 0)
            {
                sb.Append(" and infoType = " + typeId);
            }
            sb.Append(" order by releaseTime desc");
            
        }
    }
}