using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Text;
using System.IO;
using DAL;

namespace CommonBussiness
{
    public partial class shopInfo_edit : System.Web.UI.Page
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
                    ViewState["headImg"] = "images/toux.jpg";
                }
                ViewState["mobile"] = user.mobile;


                ViewState["shopName"] = user.comName;

                ViewState["street"] = user.mobileCode;
                ViewState["city"] = user.activeCode;
                ViewState["province"] = user.mainbrand;

                ViewState["email"] = user.email;
                ViewState["remark"] = user.remark;
                ViewState["street2"] = user.weibo;

                ViewState["surname"] = user.username;
                ViewState["realname"] = user.relName;
                StringBuilder sb = new StringBuilder();

                if (user.shopType == 1)
                {
                    ViewState["sexValue"] = "woman";
                    sb.Append("<li id=\"woman\"><input type=\"radio\" name=\"sex\" /><span class=\"cur\"><i style=\"display: inline;\"></i></span>Restaurant</li>");
                    sb.Append("<li id=\"man\"><input type=\"radio\" name=\"sex\"  /><span><i></i></span>Store</li>");
                    ViewState["sexInfo"] = "$('._sex li').eq(0).find('span').addClass('cur');$('._sex li').eq(0).find('i').show();$('._sex li').eq(0).find('input').attr('checked','true');";
                }
                else
                {
                    ViewState["sexValue"] = "man";
                    sb.Append("<li id=\"woman\"><input type=\"radio\" name=\"sex\"/><span><i></i></span>Restaurant</li>");
                    sb.Append("<li id=\"man\"><input type=\"radio\" name=\"sex\" checked=\"checked\"   /><span class=\"cur\"><i style=\"display: inline;\"></i></span>Store</li>");
                    ViewState["sexInfo"] = "$('._sex li').eq(1).find('span').addClass('cur');$('._sex li').eq(1).find('i').show();$('._sex li').eq(1).find('input').attr('checked','true');";

                }
                ViewState["sex"] = sb.ToString();
            }
            else
            {
                Response.Redirect("/register.html");
            }

            
        }
    }
}