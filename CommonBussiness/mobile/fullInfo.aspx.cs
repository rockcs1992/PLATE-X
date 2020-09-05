using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Text;
using System.Net;
using System.IO;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core;
using Aliyun.Acs.Dysmsapi.Model.V20170525;

using Aliyun.Acs.Core.Exceptions;

namespace CommonBussiness.mobile
{
    public partial class fullInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KeyWordBind();

                UserInfo user = Session["user"] as UserInfo;
                if (user != null)
                {
                    if (user.mobile.Length == 11)
                    {
                        ViewState["mobile"] = user.mobile.Substring(0, 3) + "****" + user.mobile.Substring(7, 4);
                    }
                    if (user.imgUrl == "")
                    {
                        ViewState["imgUrl"] = "images/nohead.png";
                    }
                    else
                    {
                        ViewState["imgUrl"] = user.imgUrl;
                    }

                    ViewState["nameInfo"] = user.comName;

                    this.surname.Text = user.username;
                    relname.Text = user.relName;
                    shoperName.Text = user.comName;
                    street.Text = user.mobileCode;

                    street2.Text = user.weibo;
                    city.Text = user.activeCode;
                    province.Text = user.mainbrand;
                    email.Text = user.email;
                    remark.Text = user.remark;
                    radShoperType.SelectedValue = user.shopType.ToString();
                }
                else
                {
                    Response.Redirect("login.html");
                }
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
    }
}