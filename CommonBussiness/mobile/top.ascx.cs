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
    public partial class top : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                #region 记住Password
                HttpCookie cookies = Request.Cookies["userInfo"];

                // 如果此Cookies存在且它里面有子键则进行读取
                if (cookies != null && cookies.HasKeys)
                {
                    string mobile = cookies["Name"].ToString();
                    string password = cookies["Pwd"].ToString();
                    string md5Pass = encrypt.EncryptMd5(password);
                    UserInfo user = UserInfoService.GetModel(mobile, md5Pass);
                    if (user != null)
                    {
                        Session["user"] = user;
                    }
                }

                #endregion
            }
        }
    }
}