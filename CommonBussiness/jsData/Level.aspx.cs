using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using DAL;
using Model;
using System.Data;

namespace CommonBussiness.jsData
{
    public partial class Level : System.Web.UI.Page
    {
        int departId = CRequest.GetInt("departId",0);
        int roleId = CRequest.GetInt("roleId",0);
        string action = CRequest.GetString("action");
        string strLevelNo = CRequest.GetString("str");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (action.Equals("AddPrice")) 
                {
                    AddPrice();
                }
                if (action.Equals("GetBikeBrand")) 
                {
                    GetBikeBrand();
                }
                if (action.Equals("SetGoods")) 
                {
                    SetGoods();
                }
                if (action.Equals("DelPK")) 
                {
                    DelPK();
                }
                if (action.Equals("AddPK")) 
                {
                    AddPK();
                }
                if (action.Equals("QLogin"))
                {
                    QLogin();
                }
                if(action.Equals("Login"))
                {
                    Login();
                }
                if (action.Equals("level"))
                {
                    UpdatePrivilege();
                }
                if (action.Equals("UserReg"))
                {
                    UserReg();
                }

                if (action.Equals("CheckDelImg")) 
                {
                    CheckDelImg();
                }
            }
            
        }
        /// <summary>
        /// 报价
        /// </summary>
        private void AddPrice() 
        {
            int num = 0;
            string price = CRequest.GetString("price");
            string productId = CRequest.GetString("productId");
            if(price != "" && productId != "")
            {
                UserInfo user = Session["user"] as UserInfo;
                if(user != null)
                {
                    AddPrice ad = new AddPrice();
                    ad.productId = Convert.ToInt32(productId);
                    ad.price = Convert.ToDouble(price);
                    ad.addUser = user.id;
                    ad.addTime = DateTime.Now;
                    ad.status = 0;
                    ad.remark = "";
                    ad.infoType = 0;
                    num = AddPriceService.Add(ad);
                }
            }
            if (num > 0)
            {
                Response.Write("success");
            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// 页面头部自行车下的品牌和价格相关信息
        /// </summary>
        private void GetBikeBrand() 
        {
            
        }
        /// <summary>
        /// 设置产品属性赞
        /// </summary>
        private void SetGoods()
        {
            int id = CRequest.GetInt("pid",0);
            int num = CRequest.GetInt("num",0);
            int row = ProductGoodsService.SetGoods(num,id);
            if (row > 0)
            {
                int goods = ProductGoodsService.GetGoods(num, id);
                Response.Write(goods.ToString());
            }
            else
            {
                Response.Write("0");
            }

        }
        /// <summary>
        /// DeletePK产品
        /// </summary>
        private void DelPK() 
        {
            int id = CRequest.GetInt("id", 0);
            if (Session["PK1"] != null)
            {
                Product item = Session["PK1"] as Product;
                if (item.id == id)
                {
                    Session["PK1"] = null;
                }
                Product item2 = Session["PK2"] as Product;
                if (item2 != null && item2.id == id)
                {
                    Session["PK2"] = null;
                }
            }
            else
            {
                Product item = Session["PK2"] as Product;
                if (item.id == id)
                {
                    Session["PK2"] = null;
                }
            }
            Response.Write("success");
        }
        /// <summary>
        /// 设置PK对象
        /// </summary>
        private void AddPK() 
        {
            int id = CRequest.GetInt("id",0);
            if (Session["PK1"] != null && Session["PK2"] != null)
            {
                Response.Write("full");
                return;
            }
            else
            {
                Product item = ProductService.GetModel(id);
                if (Session["PK1"] == null)
                {
                    if (Session["PK2"] != null)
                    {
                        Product item2 = Session["PK2"] as Product;
                        if (item.id == item2.id)
                        {
                            Response.Write("exists");
                            return;
                        }
                    }
                    if (item != null)
                    {
                        Session["PK1"] = item;
                    }
                }
                else
                {
                    Product item2 = Session["PK1"] as Product ;
                    if (item2.id == item.id)
                    {
                        Response.Write("exists");
                        return;
                    }
                    if (Session["PK2"] == null)
                    {
                        if (item != null)
                        {
                            Session["PK2"] = item;
                        }          
                    }
                }
            } 
            Response.Write("success");
        }
        /// <summary>
        /// Delete图片集图片
        /// </summary>
        private void CheckDelImg()
        {
            int id = CRequest.GetInt("id",0);
            int num = ProductImgService.DeleteById(id);
            Response.Write("success");
        }
        /// <summary>
        /// Q登陆
        /// </summary>
        private void QLogin()
        {
            string loginname = CRequest.GetString("username");
            string loginpass = CRequest.GetString("pass");

            string loginT = CRequest.GetString("cookeT");
            UserInfo user = UserInfoService.GetModel(loginname, encrypt.EncryptMd5(loginpass));
            if (user != null)
            {
                Session["Quser"] = user;
                if (loginT != "0")
                {
                    HttpCookie cookie = new HttpCookie("Quser");
                    cookie.Value = user.id.ToString();
                    cookie.Expires = DateTime.Now.AddDays(14);
                    Response.Cookies.Add(cookie);
                }
                Response.Write("success");
            }
            else
            {
                user = new UserInfo();
                #region 封装对象进行Join并Log In
                user.username = loginname;
                user.mobile = "";
                user.isBindMobile = 0;
                user.email = "";
                user.isBindEmail = 0;
                user.password = loginpass;
                user.md5Pass = encrypt.EncryptMd5(loginpass);
                user.relName = "";
                user.bodyCode = "";
                user.comName = "";
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
                user.remark = "";
                user.status = 0;
                
                user.addTime = DateTime.Now;
                user.mobileCode = "";
                user.activeCode = "";
                user.infoType = 1;

                int maxId = UserInfoService.Add(user);
                if (maxId > 0)
                {
                    user.id = maxId;
                    Session["Quser"] = user;
                    if (loginT != "0")
                    {
                        HttpCookie cookie = new HttpCookie("Quser");
                        cookie.Value = user.id.ToString();
                        cookie.Expires = DateTime.Now.AddDays(14);
                        Response.Cookies.Add(cookie);
                    }
                    Response.Write("success");
                }
                else
                { 
                    Response.Write("fail");
                }
                
                #endregion
            }

        }
        /// <summary>
        /// 登陆
        /// </summary>
        private void Login() 
        {
            string loginname = CRequest.GetString("username");
            string loginpass = CRequest.GetString("pass");
            
            string loginT = CRequest.GetString("cookeT");
            UserInfo user = UserInfoService.GetModel(loginname, encrypt.EncryptMd5(loginpass));
            if (user != null)
            {
                if (user.status == 100)
                {
                    Response.Write("stop");
                }
                else
                {
                    Session["user"] = user;
                    if (loginT != "0")
                    {
                        HttpCookie cookie = new HttpCookie("user");
                        cookie.Value = user.id.ToString();
                        cookie.Expires = DateTime.Now.AddDays(14);
                        Response.Cookies.Add(cookie);
                    }
                    Response.Write("success");
                }
                
            }
            else
            {
                Response.Write("fail");
            }
            
        }
        /// <summary>
        /// 用户Join
        /// </summary>
        private void UserReg() 
        {
            string userType = CRequest.GetString("userType");
            string username = CRequest.GetString("username");
            string pass = CRequest.GetString("pass");
            string code = CRequest.GetString("code");
            if (Session["code"].ToString() != code)
            {
                Response.Write("codeError");
                return;
            }
            UserInfo item = new UserInfo();
            #region 封装数据
            item.username = username;

            if (username.Length == 11 && username.Substring(0, 1) == "1")
            {
                item.mobile = username;
                item.isBindMobile = 1;
            }
            else
            {
                item.mobile = "";
                item.isBindMobile = 0;
            }
            if (username.IndexOf("@") != -1 && username.IndexOf(".") != -1)
            {
                item.email = username;
                item.isBindEmail = 1;
            }
            else
            {
                item.email = "";
                item.isBindEmail = 0;
            }
            item.password = pass;
            item.md5Pass = encrypt.EncryptMd5(pass);
            item.relName = "";
            item.bodyCode = "";
            item.comName = "";
            item.pid = 0;
            item.cid = 0;
            item.regionId = 0;
            item.address = "";
            item.zipCode = "";
            item.qq = "";
            item.weixin = "";
            item.isBindWeiXin = 0;
            item.weibo = "";
            item.isBindWeiBo = 0;

            item.shopType = 0;
            item.shopTypeName = "";
            if (userType != "")
            {
                item.shopType = Convert.ToInt32(userType);
                if(item.shopType == 1)
                {
                    item.shopTypeName = "品牌商";
                }else if(item.shopType == 2)
                {
                    item.shopTypeName = "经销商";
                }
                else if (item.shopType == 3)
                {
                    item.shopTypeName = "一般用户";
                }
            }
            item.imgUrl = "";
            item.comInfo = "";
            item.remark = "";
            item.status = 0;
            item.addTime = DateTime.Now;
            item.mobileCode = "";
            item.activeCode = "";
            item.infoType = 0;
            #endregion
            if (UserInfoService.Exists(item.username))
            {
                Response.Write("exists");
            }
            else
            {
                int maxId = UserInfoService.Add(item);
                if (maxId > 0)
                {
                    item.id = maxId;
                    Session["user"] = item;
                    Response.Write("success");
                }
                else
                {
                    Response.Write("fail");
                }
            }
            
        }
        /// <summary>
        /// 权限更新
        /// </summary>
        private void UpdatePrivilege() 
        {
            //先Delete已有的重新添加
            string sql = "delete from SysPrivileges where roleId = " + roleId;
            int rows = DBHelperSQL.ExecuteSql(sql);
           
            
            if (strLevelNo.Length == 0 && rows > 0)
            {
                Response.Write("success");
            }
            else
            {
                string[] arr = strLevelNo.TrimEnd(',').Split(',');
                int num = 5;
                SysPrivileges item = null;
                StringBuilder sb = new StringBuilder();
                if (arr.Length > 0)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        item = new SysPrivileges();
                        item.roleId = roleId;
                        item.departmentId = departId;
                        if(arr[i] != "on")
                        {
                            item.levelNo = Convert.ToInt32(arr[i]);
                        }
                        
                        item.parentLevelNo = OALevelService.GetparentLevelNoByLevelNo(item.levelNo);
                        if(!SysPrivilegesService.Exists(item.roleId,item.departmentId,item.levelNo))
                        {
                            num = SysPrivilegesService.Add(item);
                            if (num == 0)
                            {
                                sb.Append("权限编号：" + item.levelNo + "添加失败，");
                            }
                        }
                        
                    }
                }
                if (num == 0)
                {
                    Response.Write(sb.ToString());
                }
                else
                {
                    Response.Write("success");
                }
            }
        }
       
    }
}