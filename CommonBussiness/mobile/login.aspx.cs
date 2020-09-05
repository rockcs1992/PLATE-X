using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;

namespace CommonBussiness.mobile
{
    public partial class login : System.Web.UI.Page
    {
        protected string action = CRequest.GetString("action");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                #region 记住Password
                HttpCookie cookies = Request.Cookies["userInfo"];

                // 如果此Cookies存在且它里面有子键则进行读取
                if (cookies != null && cookies.HasKeys)
                {
                    //string mobile = cookies["Name"].ToString();
                    //string password = cookies["Pwd"].ToString();
                    //string md5Pass = encrypt.EncryptMd5(password);
                    //UserInfo user = UserInfoService.GetModel(mobile, md5Pass);
                    //if (user != null)
                    //{                        
                    //    Session["user"] = user;
                    //    Response.Redirect("/mobile/my_yuanxiang.html");
                    //}
                }

                #endregion
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