using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Data;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CommonBussiness.jsData
{
    public partial class common : System.Web.UI.Page
    {
        string action = CRequest.GetString("action");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 功能方法
                if (action.Equals("MobileHeadImg")) 
                {
                    MobileHeadImg();
                }
                if (action.Equals("DelMobileCard")) 
                {
                    DelMobileCard();
                }
                if (action.Equals("DelMobileTicket")) 
                {
                    DelMobileTicket();
                }
                if (action.Equals("CollapseInfo")) 
                {
                    CollapseInfo();
                }
                if (action.Equals("GetMoreAreaInfo")) 
                {
                    GetMoreAreaInfo();
                }
                if (action.Equals("JumpURL")) 
                {
                    JumpURL();
                }
                if (action.Equals("User2Credit")) 
                {
                    User2Credit();
                }
                if (action.Equals("Business"))
                {
                    Business();
                }
                if (action.Equals("UpdateNiCheng")) 
                {
                    UpdateNiCheng();
                }
                if (action.Equals("qqLogin"))
                {
                    qqLogin();
                }
                if (action.Equals("updateView"))
                {
                    UpdateView();
                }
               
                if (action.Equals("delGongGao"))
                {
                    DelGongGao();
                }
                
                if (action.Equals("UpdateViews")) 
                {
                    UpdateViews();
                }
                if(action.Equals("delLink"))
                {
                    DelLink();
                }
                if (action.Equals("ModLink"))
                {
                    ModLink();
                }
                if (action.Equals("UseAdmin"))
                {
                    UseAdmin();
                }
                if (action.Equals("DelAdmin"))
                {
                    DelAdmin();
                }
                #endregion
            }
        }
        /// <summary>
        /// 功能方法
        /// </summary>
        private void MobileHeadImg() 
        {
            string dataURL = CRequest.GetString("dataURL").Trim();
            try
            {
                if (dataURL.IndexOf("data") != -1)
                {
                    var imgData = dataURL.Replace("data:image/jpeg;base64,", "");
                    //过滤特殊字符即可   
                    string dummyData = imgData.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
                    if (dummyData.Length % 4 > 0)
                    {
                        dummyData = dummyData.PadRight(dummyData.Length + 4 - dummyData.Length % 4, '=');
                    }
                    byte[] imageBytes = Convert.FromBase64String(dummyData);
                    //读入MemoryStream对象  
                    MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
                    memoryStream.Write(imageBytes, 0, imageBytes.Length);
                    //二进制转成图片Save  
                    System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);

                    if (!Directory.Exists(Server.MapPath(Global_Upload.FriendImgPath)))//判断目录是否存在
                    {
                        Directory.CreateDirectory(Server.MapPath(Global_Upload.FriendImgPath));//创建目录
                    }
                    UserInfo user = Session["user"] as UserInfo;
                    if (user != null)
                    {
                        string path = Global_Upload.FriendImgPath + user.id + DateTime.Now.ToString("yyyyMMddHH") + ".jpg";

                        image.Save(Server.MapPath(path));
                        user.imgUrl = path;
                        int rows = UserInfoService.UpdateImg(user, 5);
                        if (rows > 0)
                        {
                            Session["user"] = user;
                        }

                    }
                }


            }
            catch (System.Exception exp)
            {
                //// Error creating stream or reading from it.
                //System.Console.WriteLine("{0}", exp.Message);
                //return;
            }
            finally
            { 
                Response.Write("success");
            }
            
        }
        /// <summary>
        /// Delete优惠卡
        /// </summary>
        private void DelMobileCard()
        {
            
        }
        /// <summary>
        /// Delete优惠券
        /// </summary>
        private void DelMobileTicket() 
        {
            
        }
        /// <summary>
        /// 收起
        /// </summary>
        private void CollapseInfo()
        {
            StringBuilder sb = new StringBuilder();
            string areaId = CRequest.GetString("areaId");
            DataSet ds = UserBaseService.GetList(10,"regCode = '" + areaId + "'","id");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["fullName"].ToString().Length > 12)
                    {
                        sb.Append("<li style=\"float:left; width:18%; line-height:35px; text-align:center; padding:5px; margin-bottom:5px; border:1px #eee solid;\"><a href=\"/comDetail_client_" + dr["userId"] + "_1.html\" title=\"" + dr["fullName"] + "\">" + dr["fullName"].ToString().Substring(0, 12) + "</a></li> ");
                    }
                    else
                    {
                        sb.Append("<li style=\"float:left; width:18%; line-height:35px; text-align:center; padding:5px; margin-bottom:5px; border:1px #eee solid;\"><a href=\"/comDetail_client_" + dr["userId"] + "_1.html\" title=\"" + dr["fullName"] + "\">" + dr["fullName"] + "</a></li> ");
                    }
                }
                sb.Append("<li style=\"float:left; width:18%; line-height:35px; text-align:center; padding:5px; margin-bottom:5px; border:1px #eee solid;\"><a href='javascript:showMore(" + areaId + ")'>更多 >></a></li> ");

            }
            Response.Write(sb.ToString());
        }
        /// <summary>
        /// 获取子级信息
        /// </summary>
        private void GetMoreAreaInfo()
        {
            StringBuilder sb = new StringBuilder();
            string areaId = CRequest.GetString("areaId");
            DataSet ds = UserBaseService.GetList("regCode = '" + areaId + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["fullName"].ToString().Length > 12)
                    {
                        sb.Append("<li style=\"float:left; width:18%; line-height:35px; text-align:center; padding:5px; margin-bottom:5px; border:1px #eee solid;\"><a href=\"/comDetail_client_" + dr["userId"] + "_1.html\" title=\"" + dr["fullName"] + "\">" + dr["fullName"].ToString().Substring(0, 12) + "</a></li> ");
                    }
                    else
                    {
                        sb.Append("<li style=\"float:left; width:18%; line-height:35px; text-align:center; padding:5px; margin-bottom:5px; border:1px #eee solid;\"><a href=\"/comDetail_client_" + dr["userId"] + "_1.html\" title=\"" + dr["fullName"] + "\">" + dr["fullName"] + "</a></li> ");
                    }
                }
                sb.Append("<li style=\"float:left; width:18%; line-height:35px; text-align:center; padding:5px; margin-bottom:5px; border:1px #eee solid;\"><a href='javascript:collapseInfo(" + areaId + ")'>收起 <<</a></li> ");

            }
            Response.Write(sb.ToString());
        }
        /// <summary>
        /// 获取跳转路径
        /// </summary>
        private void JumpURL()
        {
            string weburl = BaseConfigService.GetById(12);
            string src = CRequest.GetString("src").Replace(weburl, "");

            string url = FriendsInfoService.GetUrl(src);
            Response.Write(url);
        }
        /// <summary>
        /// 催乳师认证
        /// </summary>
        private void User2Credit() 
        {
            int id = CRequest.GetInt("id",0);
            int type = CRequest.GetInt("num",0);
            int num = UserInfoService.CreditUser(id,type);
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
        /// 商圈I am a下的产品
        /// </summary>
        private void Business() 
        {
            int newsType = CRequest.GetInt("typeId",0);
            StringBuilder sb = new StringBuilder();
            DataSet ds = NewsService.GetList(10,"newsType = " + newsType + " and is_tj = 1 and newImg <> ''","id");
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append("<div class=\"liebiao\"><b class=\"liebiao_newb\"></b><strong class=\"liebiao_newst\"></strong>");
                    sb.Append("<a href=\"/businessDetail_" + dr["id"] + ".html\"><p class=\"tup\"><img src=\"" + dr["newImg"] + "\" alt=\"" + dr["title"] + "\" />");
                    sb.Append("<p class=\"neirong\"><i></i><span>");
                    if (dr["title"].ToString().Length > 10)
                    {
                        sb.Append(dr["title"].ToString().Substring(0,10));
                    }
                    else
                    {
                        sb.Append(dr["title"].ToString());
                    }
                    sb.Append("</span></p></p></a></div>");
                }
            }
            Response.Write(sb.ToString());
        }
        /// <summary>
        /// 更新昵称信息
        /// </summary>
        private void UpdateNiCheng()
        {
            UserInfo user = Session["user"] as UserInfo;
            string relName = CRequest.GetString("relName");
            if (user != null)
            {
                int num = UserInfoService.UpdateNiCheng(user, relName);
                Response.Write("success");
            }
            else
            {
                Response.Write("fail");
            }
            
        }
        /// <summary>
        /// qq授权代理Save
        /// </summary>
        private void qqLogin() 
        {
            string openId = CRequest.GetString("openId");
            string accessToken = CRequest.GetString("accessToken");
            string nickname = CRequest.GetString("nickname");
            UserInfo user = UserInfoService.GetModel(openId,accessToken,2);
            if (user == null)
            {
                user = new UserInfo();
                #region 封装对象进行Join并Log In
                user.username = "";
                user.mobile = "";
                user.isBindMobile = 0;
                user.email = "";
                user.isBindEmail = 0;
                user.password = "";
                user.md5Pass = encrypt.EncryptMd5(accessToken);
                user.relName = nickname;
                user.bodyCode = openId;
                user.comName = accessToken;
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
                user.infoType = 2;
                int maxId = UserInfoService.Add(user);
                if (maxId > 0)
                {
                    user.id = maxId;
                    Session["user"] = user;
                    Response.Write("success");
                }
                else
                {
                    Response.Write("fail");
                }

                #endregion
            }
            else
            {
                Session["user"] = user;
                Response.Write("success");
            }
            
            
            
        }
        /// <summary>
        /// 更新浏览次数
        /// </summary>
        private void UpdateView()
        {
            int typeId = CRequest.GetInt("typeId", 0);
            string pageName = CRequest.GetString("pageName");
            string pageValue = CRequest.GetString("pageValue");

            //Pv统计
            #region
            Pv pv = new Pv();
            pv.pageName = pageName;
            pv.pageValue = pageValue;
            pv.viewsCount = 1;
            string sUserAgent = Request.UserAgent.ToLower();
            bool bIsIpad = Regex.IsMatch(sUserAgent, "ipad");
            bool bIsIphoneOs = Regex.IsMatch(sUserAgent, "iphone");
            bool bIsAndroid = Regex.IsMatch(sUserAgent, "android");
            bool bIsWP = Regex.IsMatch(sUserAgent, "windows phone");
            if (bIsAndroid || bIsIphoneOs || bIsIpad || bIsWP)
            {
                pv.viewsCount = 2;
            }
            pv.addTime = DateTime.Now;
            pv.ip = IpSearch.GetIp();
            pv.status = 0;
            pv.remark = "";
            pv.infoType = typeId;
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                pv.status = user.id;
                pv.remark = user.mobile;
            }
            PvService.Add(pv);
            #endregion
        }
        /// <summary>
        /// Delete公告
        /// </summary>
        private void DelGongGao() 
        {
            int id = CRequest.GetInt("id", 0);
            int num = GongGaoInfoService.Delete(id);
            if (num > 0)
            {
                
                Response.Redirect("/admin/gonggao.aspx");
            }
        }
       
        /// <summary>
        /// 资讯的浏览量
        /// </summary>
        private void UpdateViews() 
        {
            int typeId = CRequest.GetInt("typeId", 0);
            string pageName = CRequest.GetString("pageName");
            string pageValue = CRequest.GetString("pageValue");

            //Pv统计
            #region
            Pv pv = new Pv();
            pv.pageName = pageName;
            pv.pageValue = pageValue;
            pv.viewsCount = 1;
            string sUserAgent = Request.UserAgent.ToLower();
            bool bIsIpad = Regex.IsMatch(sUserAgent, "ipad");
            bool bIsIphoneOs = Regex.IsMatch(sUserAgent, "iphone");
            bool bIsAndroid = Regex.IsMatch(sUserAgent, "android");
            bool bIsWP = Regex.IsMatch(sUserAgent, "windows phone");
            if (bIsAndroid || bIsIphoneOs || bIsIpad || bIsWP)
            {
                pv.viewsCount = 2;
            }
            pv.addTime = DateTime.Now;
            pv.ip = IpSearch.GetIp();
            pv.status = 0;
            pv.remark = "";
            pv.infoType = typeId;
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                pv.status = user.id;
                pv.remark = user.mobile;
            }
            PvService.Add(pv);
            #endregion
        }
       
        
        /// <summary>
        /// Delete管理员
        /// </summary>
        private void DelAdmin() 
        {
            int id = CRequest.GetInt("id", 0);            
            int num = AdminUserService.Delete(id);
            
            Response.Redirect("/admin/manager.aspx?delAdmin=" + num);
            
        }
        /// <summary>
        /// 启用/停用管理员
        /// </summary>
        private void UseAdmin()
        {
            int id = CRequest.GetInt("id",0);
            int status = CRequest.GetInt("status",0);
            int num = AdminUserService.UseAdmin(id,status);
            
            Response.Redirect("/admin/manager.aspx?useAdmin=" + num);
        }
        /// <summary>
        /// 修改连接信息
        /// </summary>
        private void ModLink() 
        {
            int id = CRequest.GetInt("id",0);
            string name = CRequest.GetString("name");
            string title = CRequest.GetString("title");
            string path = CRequest.GetString("path");
            int place = CRequest.GetInt("place",0);
            Links item = LinksService.GetModel(id);
            if(item != null)
            {
                item.linkname = name;
                item.linktitle = title;
                item.linkurl = path;
                item.istj = place;
                int num = LinksService.Update(item);
                if (num > 0)
                {
                    
                    Response.Write("success");
                }
                else
                {
                    Response.Write("fail");
                }
            }
        }
        /// <summary>
        /// Delete连接
        /// </summary>
        private void DelLink() 
        {
            int id = CRequest.GetInt("id",0);
            int num = LinksService.Delete(id);
            if(num > 0)
            {
                
                Response.Redirect("/admin/link.aspx");
            }
        }
    }
}