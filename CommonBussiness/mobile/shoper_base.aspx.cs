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
    public partial class shoper_base : System.Web.UI.Page
    {
        protected int productId = CRequest.GetInt("productId", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KeyWordBind();

                Product item = ProductService.GetModel(productId);
                if (item != null)
                {
                    UserInfo user = UserInfoService.GetModel(item.useId);
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
                        ViewState["mobile"] = user.mobile;
                        this.surname.Text = user.relName + " " + user.username;
                        shoperName.Text = user.comName;
                        street.Text = user.mobileCode;
                        city.Text = user.activeCode;
                        province.Text = user.mainbrand;
                        email.Text = user.email;
                        remark.Text = user.remark;

                    }
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