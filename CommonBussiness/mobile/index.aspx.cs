using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using Model;
using System.Text;
using System.Reflection;

namespace CommonBussiness.mobile
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                //和用户控件交互
                Type ucType = this.bottom1.GetType();
                PropertyInfo PageId = ucType.GetProperty("PageId");
                PageId.SetValue(this.bottom1, 1, null);
                #region 记住Password
                HttpCookie cookies = Request.Cookies["userInfo"];

                // 如果此Cookies存在且它里面有子键则进行读取
                //if (cookies != null && cookies.HasKeys)
                //{
                //    string mobile = cookies["Name"].ToString();
                //    string password = cookies["Pwd"].ToString();
                //    string md5Pass = encrypt.EncryptMd5(password);
                //    UserInfo user = UserInfoService.GetModel(mobile, md5Pass);
                //    if (user != null)
                //    {
                //        Session["user"] = user;
                //    }
                //}

                #endregion
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
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            DataSet ds = FriendsInfoService.GetList("infoType = 11");
            if(ds.Tables[0].Rows.Count > 0)
            {
                repBanner.DataSource = ds;
                repBanner.DataBind();
            }
        }
    }
}