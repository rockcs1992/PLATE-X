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
    public partial class joinBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

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
        /// SaveMy Business Center
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string surname = this.surname.Text.Trim();
            string relname = this.relname.Text.Trim();
            string shoperName = this.shoperName.Text.Trim();
            string street = this.street.Text.Trim();
            string city = this.city.Text.Trim();
            string province = this.province.Text.Trim();
            string email = this.email.Text.Trim();
            string remark = this.remark.Text.Trim();

            string password = this.password.Text.Trim();
            if(password.Length == 0)
            {
                password = "123456";
            }
            string mobile = this.tel.Text.Trim();
            string md5Pass = encrypt.EncryptMd5(password);
           
            UserInfo user = null;
            if (UserInfoService.ExistsMobile(mobile))
            {
                ScriptManager.RegisterStartupScript(Button1, GetType(), "", "alert('This phone number has already joined.');", true);
                return;
            }
            user = new UserInfo();
            user.username = surname;
            user.mobile = mobile;
            user.isBindMobile = 1;
            user.email = email;
            user.isBindEmail = 0;
            user.password = password;
            user.md5Pass = encrypt.EncryptMd5(password);
            user.telephone = "";
            user.relName = relname;
            user.bodyCode = "";
            user.comName = shoperName;
            user.pid = 0;
            user.cid = 0;
            user.regionId = 0;
            user.address = "";
            user.zipCode = "";
            user.qq = "";
            user.weixin = "";
            user.isBindWeiXin = 0;
            user.weibo = "";
            user.isBindWeiBo = 0;
            user.shopType = 0;
            user.shopTypeName = "";
            user.imgUrl = "";
            user.comInfo = "";
            user.remark = remark;
            user.status = 1;
            user.addTime = DateTime.Now;
            user.mobileCode = street;
            user.activeCode = city;
            user.infoType = 2;
            user.shopingtime = "";

            user.mainbrand = province;
            user.assesscount = 0;
            user.sharecount = 0;
            user.producttype = 0;
            user.goodcount = 0;
            user.badcount = 0;
            user.viewscountd = 0;
            user.logintime = DateTime.Now;
            user.loginip = IpSearch.GetIp();

            int maxId = UserInfoService.Add(user);
            if (maxId > 0)
            {
                ScriptManager.RegisterStartupScript(Button1, GetType(), "", "alert('Saved succesfully！');location.href='/mobile/joinBack.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Button1, GetType(), "", "alert('Failed to save！');", true);
                return;
            }
        }
    }
}