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
    public partial class my_person : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                 UserInfo user = Session["user"] as UserInfo;
                 if (user != null)
                 { 
                    if(user.infoType == 2)
                    {
                        Response.Redirect("shopInfo_edit.html");
                        return;
                    }
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
        /// 绑定信息
        /// </summary>
        private void BindData()
        {
            for (int i = 0; i < 100; i++)
            {
                this.ddlYear.Items.Insert(i, new ListItem((DateTime.Now.Year - i).ToString(), (DateTime.Now.Year - i).ToString()));
            }
            for (int i = 0; i < 31; i++)
            {
                this.ddlDay.Items.Insert((i), new ListItem((i + 1).ToString(), (i + 1).ToString())); ;
            }
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


                string[] arr = user.shopingtime.Split('-'); ;
                if (arr.Length > 1)
                {
                    ddlYear.SelectedValue = arr[0];
                    ddlMonth.SelectedValue = arr[1];
                    ddlDay.SelectedValue = arr[2];
                }

                ViewState["street"] = user.mobileCode;
                ViewState["street2"] = user.address;

                ViewState["city"] = user.activeCode;
                ViewState["province"] = user.mainbrand;


                ViewState["surname"] = user.username;
                ViewState["realname"] = user.relName;
                StringBuilder sb = new StringBuilder();
                
                if(user.sharecount == 1)
                {
                    ViewState["sexValue"] = "woman";
                    sb.Append("<li id=\"woman\"><input type=\"radio\" name=\"sex\" /><span class=\"cur\"><i style=\"display: inline;\"></i></span>Male</li>");
                    sb.Append("<li id=\"man\"><input type=\"radio\" name=\"sex\"  /><span><i></i></span>Female</li>");
                    sb.Append("<li id=\"secret\"><input type=\"radio\" name=\"sex\" /><span><i></i></span>Do not disclose</li>");
                    ViewState["sexInfo"] = "$('._sex li').eq(0).find('span').addClass('cur');$('._sex li').eq(0).find('i').show();$('._sex li').eq(0).find('input').attr('checked','true');";
                }
                else if (user.sharecount == 2)
                {
                    ViewState["sexValue"] = "man";
                    sb.Append("<li id=\"woman\"><input type=\"radio\" name=\"sex\"/><span><i></i></span>Male</li>");
                    sb.Append("<li id=\"man\"><input type=\"radio\" name=\"sex\" checked=\"checked\"   /><span class=\"cur\"><i style=\"display: inline;\"></i></span>Female</li>");
                    sb.Append("<li id=\"secret\"><input type=\"radio\" name=\"sex\"/><span><i></i></span>Do not disclose</li>");
                    ViewState["sexInfo"] = "$('._sex li').eq(1).find('span').addClass('cur');$('._sex li').eq(1).find('i').show();$('._sex li').eq(1).find('input').attr('checked','true');";

                }
                else
                {
                    ViewState["sexValue"] = "secret";
                    sb.Append("<li id=\"woman\"><input type=\"radio\" name=\"sex\" /><span><i></i></span>Male</li>");
                    sb.Append("<li id=\"man\"><input type=\"radio\" name=\"sex\"  /><span><i></i></span>Female</li>");
                    sb.Append("<li id=\"secret\"><input type=\"radio\" name=\"sex\" checked=\"checked\" /><span class=\"cur\"><i style=\"display: inline;\"></i></span>Do not disclose</li>");
                    ViewState["sexInfo"] = "$('._sex li').eq(2).find('span').addClass('cur');$('._sex li').eq(2).find('i').show();$('._sex li').eq(2).find('input').attr('checked','true');";

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