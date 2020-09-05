using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Net.Mail;
using System.Data;
using System.IO;
using System.Text;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Aliyun.Acs.Core.Exceptions;

namespace CommonBussiness.jsData
{
    public partial class user : System.Web.UI.Page
    {
        string action = CRequest.GetString("action");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (action.Equals("ResetPass")) 
                {
                    ResetPass();
                }
                if (action.Equals("GetSMS")) 
                {
                    GetSMS();
                }
                if (action.Equals("SaveProduct"))
                {
                    SaveProduct();
                }
                if (action.Equals("SaveBaseShop")) 
                {
                    SaveBaseShop();   
                }
                if (action.Equals("LoadFavorite"))
                {
                    LoadFavorite();
                }
                if (action.Equals("Favorite"))
                {
                    Favorite();
                }
                #region 功能方法
                if (action.Equals("SaveAddrNew")) 
                {
                    SaveAddrNew();
                }
                if (action.Equals("GetArea33"))
                {
                    GetArea33();
                }
                if (action.Equals("GetArea22"))
                {
                    GetArea22();
                }
                if (action.Equals("GetArea3"))
                {
                    GetArea3();
                }
                if (action.Equals("GetArea2")) 
                {
                    GetArea2();
                }

                if (action.Equals("SetHeadImgMobile")) 
                {
                    SetHeadImgMobile();
                }
                if (action.Equals("BindCardMobile")) 
                {
                    BindCardMobile();
                }
                if (action.Equals("SetNewPass")) 
                {
                    SetNewPass();
                }
                if (action.Equals("BindMobileEmail")) 
                {
                    BindMobileEmail();
                }
                if (action.Equals("GetEmail")) 
                {
                    GetEmail();
                }
                if (action.Equals("SaveMess"))
                {
                    SaveMess();
                }
               
                if (action.Equals("UpdateDefaultAddr"))
                {
                    UpdateDefaultAddr();
                }
                if (action.Equals("CheckAddr")) 
                {
                    CheckAddr();
                }
                
                if (action.Equals("ModPayPass")) 
                {
                    ModPayPass();
                }
                if (action.Equals("BindMobile"))
                {
                    BindMobile();
                }
                if (action.Equals("BindEmail")) 
                {
                    BindEmail();
                }
                if (action.Equals("SaveOrderAddr")) 
                {
                    SaveOrderAddr();
                }
                if (action.Equals("ModAddr")) 
                {
                    ModAddr();
                }
                if (action.Equals("DelAddr"))
                {
                    DelAddr();
                }
                if (action.Equals("SaveBase"))
               {
                   SaveBase();
               }
                if (action.Equals("DelProduct"))
                {
                    DelProduct();
                }
                if (action.Equals("AddToCart")) 
                {
                    AddToCart();
                }
                if (action.Equals("NewsMessage"))
                {
                    NewsMessage();
                }
                if (action.Equals("SetPass")) 
                {
                    SetPass();
                }
                if (action.Equals("FindPass"))
                {
                    FindPass();
                }
                if (action.Equals("SaveAddr")) 
                {
                    SaveAddr();
                }
                if (action.Equals("SaveAddr1"))
                {
                    SaveAddr1();
                }
                if (action.Equals("Reply"))
                {
                    Reply();
                }
                if (action.Equals("Login")) 
                {
                    Login();
                }
                if (action.Equals("ModPass")) 
                {
                    ModPass();
                }
                if (action.Equals("RegShop"))
                {
                    RegShop();
                }
                if (action.Equals("Reg"))
                {
                    Reg();
                }
                if (action.Equals("FullShop"))
                {
                    FullShop();
                }
                if (action.Equals("GetCode"))
                {
                    GetCode();
                }
                #endregion
            }
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        private void ResetPass() 
        {
            string mobile = "1" + CRequest.GetString("mobile");
            string resetSMScode = CRequest.GetString("resetSMScode");
            string pass1 = CRequest.GetString("pass1");
            
            if (!MessageCodeService.Exists(mobile, resetSMScode))
            {
                Response.Write("codeError");
                return;
            }
            UserInfo user = UserInfoService.GetModel(mobile);
            if(user != null)
            {
                user.password = pass1;
                user.md5Pass = encrypt.EncryptMd5(user.password);
                int rows = UserInfoService.ModPass(user);
                if(rows > 0)
                {
                    Response.Write("success");
                    return;
                }
            }
            Response.Write("fail");
            
        }
        /// <summary>
        /// 获取短信验证码
        /// </summary>
        private void GetSMS() 
        {
            string product = "Dysmsapi";//短信API产品Item Name
            string domain = "dysmsapi.aliyuncs.com";//短信API产品域名
            string accessId = "LTAI4GDo5Rcso77WY8SnA7wb";
            string accessSecret = "Yj71lRSbBSVTT018rly629xmQGhL5O";
            string regionIdForPop = "cn-hangzhou";
            string mobile = "1" + CRequest.GetString("mobile");
            
            Random ran = new Random();
            int num = ran.Next(105000, 999999);
            MessageCode item = new MessageCode();
            item.mobile = mobile;
            item.code = num.ToString();
            item.status = 0;
            item.remark = "";
            item.addTime = DateTime.Now;
            item.infoType = 1;
            int maxId = MessageCodeService.Add(item);
            if (maxId > 0)
            {
                IClientProfile profile = Aliyun.Acs.Core.Profile.DefaultProfile.GetProfile(regionIdForPop, accessId, accessSecret);
                Aliyun.Acs.Core.Profile.DefaultProfile.AddEndpoint(regionIdForPop, regionIdForPop, product, domain);
                IAcsClient acsClient = new DefaultAcsClient(profile);
                SendSmsRequest request = new SendSmsRequest();
                try
                {
                    //request.SignName = "上云预发测试";//"管理控制台中配置的短信签名（状态必须是验证通过）"
                    //request.TemplateCode = "SMS_71130001";//管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）"
                    //request.RecNum = "13567939485";//"接收号码，多个号码可以逗号分隔"
                    //request.ParamString = "{\"name\":\"123\"}";//短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。"
                    //SingleSendSmsResponse httpResponse = client.GetAcsResponse(request);
                    request.PhoneNumbers = mobile;
                    request.SignName = "PlateX";
                    request.TemplateCode = "SMS_188556279";
                    request.TemplateParam = "{\"code\":\"" + num + "\"}";
                    request.OutId = DateTime.Now.ToString("yyyyMMddHHmmss"); //"xxxxxxxx";
                    //请求失败这里会抛ClientException异常
                    SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                    string mess = sendSmsResponse.Message;
                    Response.Write("success");                    
                }
                catch (ServerException je)
                {
                    Response.Write("fail");           
                }
                catch (ClientException ne)
                {
                    Response.Write("fail");      
                }

            }
        }
        /// <summary>
        /// Upload图片
        /// </summary>
        private string UploadImg64(string imgstr)
        {
            string path = "";
            try
            {
                var imgData = imgstr.Replace("data:image/png;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");
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
                path = Global_Upload.ShoperResImgPath + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".jpg";
                if (!Directory.Exists(Server.MapPath(Global_Upload.ShoperResImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.ShoperResImgPath));//创建目录
                }
                image.Save(Server.MapPath(path));

            }
            catch (Exception je)
            {
               // Log.Info(this.GetType().ToString(), "UploadPicture" + je.Message);
                Response.Write(je.Message);
            }
            return path;
        }
        /// <summary>
        /// Save商品
        /// </summary>
        private void SaveProduct() 
        {
            string hidId = CRequest.GetString("hidId");
            string infoDesc = CRequest.GetString("infoDesc");
            string price1 = CRequest.GetString("price1");
            string unit1 = CRequest.GetString("unit1");

            string storeCount = CRequest.GetString("storeCount");
            string proname = CRequest.GetString("proname");
            string proType = CRequest.GetString("proType");
            string imgurl = CRequest.GetString("imgurl");
            UserInfo user = Session["user"] as UserInfo;
            if (user == null)
            {
                return;
            }
            
            if (hidId != "")
            {
                Product item = ProductService.GetModel(Convert.ToInt32(hidId));
                if (item != null)
                {
                    #region 修改
                    item.proName = proname.Trim();
                    item.productType = Convert.ToInt32(proType);
                    item.productTypeName = "";
                    item.proType = 0;
                    if (storeCount.Trim() != "")
                    {
                        if (RegExp.IsNumeric(storeCount.Trim()))
                        {
                            item.proType = Convert.ToInt32(storeCount.Trim());
                        }
                    }
                    item.oneId = item.productType;
                    item.listImgUrl = imgurl;
                    if (imgurl != "" && imgurl.IndexOf("data") != -1)
                    {
                        item.listImgUrl = UploadImg64(imgurl);
                    }
                    item.unit1 = unit1.Trim();
                    item.price1 = 0;
                    if (price1.Trim() != "")
                    {
                        item.price1 = Convert.ToDouble(price1.Trim());
                    }
                    item.advantage = infoDesc.Trim();
                    if (ProductService.Update(item))
                    {
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
                    Response.Write("fail");  
                }
            }
            else
            {
                Product item = new Product();
                #region 新增
                item.proName = proname.Trim();
                item.proNameEn = "";
                item.productType = Convert.ToInt32(proType);
                item.productTypeName = "";

                item.proType = 0;
                if (storeCount.Trim() != "")
                {
                    if (RegExp.IsNumeric(storeCount.Trim()))
                    {
                        item.proType = Convert.ToInt32(storeCount.Trim());
                    }
                }
                item.proTypeName = "";

                item.oneId = Convert.ToInt32(proType);
                item.twoId = 0;
                item.threeId = 0;
                item.fourId = 0;
                if (item.twoId != 0)
                {
                    item.productType = item.twoId;
                }
                if (item.threeId != 0)
                {
                    item.productType = item.threeId;
                }


                item.listImgUrl = "";
                if (imgurl != "")
                {
                    item.listImgUrl = UploadImg(imgurl);
                }
                item.detailImg1 = "";
                item.detailImg2 = "";
                item.detailImg3 = "";
                item.detailImg4 = "";

                item.creditImg1 = "";
                item.creditImg2 = "";
                item.creditImg3 = "";
                item.creditImg4 = "";

                item.fromImg = "";
                item.otherImg = "";
                item.fromId = 0;
                item.fromName = "";
                item.fromDesc = "";
                item.brandId = 0;
                item.brandName = "";

                item.varietyId = 0;
                item.varietyName = "";

                item.relieveId = 0;
                item.relieveName = "";
                item.cookId = 0;
                item.cookName = "";
                item.useId = user.id;
                item.useName = "";

                item.unit1 = unit1.Trim();
                item.price1 = 0;
                if (price1.Trim() != "")
                {
                    item.price1 = Convert.ToDouble(price1.Trim());
                }
                item.unit2 = "";
                item.price2 = 0;
                item.unit3 = "";
                item.price3 = 0;
                item.unit4 = "";
                item.price4 = 0;

                item.advantage = infoDesc.Trim();

                item.saveInfo = "";// saveInfo.Text.Trim();

                item.rankingType = 0;
                item.rankingTypeName = "";

                item.ranking = 0;

                item.listeTime = DateTime.Now;

                item.proGrade = 0;
                item.proGradeName = "";
                item.proMaterial = 0;
                item.proMaterialName = "";
                item.speed = 0;

                item.stopType = 0;
                item.stopTypeName = "";

                item.proContent = "";

                item.proDesc = "";
                item.ImgDesc = "";
                item.propertyDesc = "";

                item.labelInfo = "";
                item.remark = "";

                item.assessCount = 0;
                item.shareCount = 0;
                item.viewsCount = 0;


                item.author = "";
                item.isTj = 0;
                item.isHot = 0;
                item.isNew = 0;
                item.goodCount = 0;
                item.badCount = 0;
                item.status = 0;

                item.infoType = 0;
                item.addTime = DateTime.Now;
                item.addUser = user.id;
                item.addUserName = user.username;
                int maxId = ProductService.Add(item);
                if (maxId > 0)
                {
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
        /// 完善信息
        /// </summary>
        private void SaveBaseShop()
        {

            string shopName = CRequest.GetString("shopName");
            string email = CRequest.GetString("email");
            string remark = CRequest.GetString("remark");


            string surname = CRequest.GetString("surname");
            string realname = CRequest.GetString("realname");

            string street = CRequest.GetString("street");
            string street2 = CRequest.GetString("street2");

            string city = CRequest.GetString("city");
            string province = CRequest.GetString("province");

            string imgurl = CRequest.GetString("imgurl");
            
            int sex = CRequest.GetInt("sex", 0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                user.comName = shopName;
                user.email = email;
                user.remark = remark;


                user.username = surname;
                user.relName = realname;
                user.shopType = sex;
                if (imgurl.IndexOf("data") != -1)
                {
                    user.imgUrl = UploadImg(imgurl);
                }
                user.mobileCode = street;
                user.activeCode = city;
                user.mainbrand = province;
                user.weibo = street2;

                UserInfoService.UpdateInfoShop(user);
                Session["user"] = user;
            }
            Response.Write("success");
        }
        /// <summary>
        /// 收藏
        /// </summary>
        private void LoadFavorite()
        {
            int shoperId = CRequest.GetInt("shoperId", 0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (UserFavoriteInfoService.Exists(user.id, shoperId))
                {
                    Response.Write("exists");
                }
                else
                {
                    Response.Write("noexists");
                }
            }
            else
            {
                Response.Write("nologin");
            }
        }
        /// <summary>
        /// 收藏
        /// </summary>
        private void Favorite() 
        {
            int shoperId = CRequest.GetInt("shoperId", 0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (UserFavoriteInfoService.Exists(user.id, shoperId))
                {
                    UserFavoriteInfoService.Delete(user.id,shoperId);
                }
                else
                {
                    UserFavoriteInfo item = new UserFavoriteInfo();
                    item.typeId = 1;
                    item.typeName = "收藏商家";
                    item.objId = shoperId;
                    item.objName = "";
                    item.status = 0;
                    item.remark = "";
                    item.addTime = DateTime.Now;
                    item.addUser = user.id;
                    UserFavoriteInfoService.Add(item);
                }
                Response.Write("success");
            }
            else
            {
                Response.Write("nologin");
            }
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        private void SaveAddrNew()
        {
            int id = CRequest.GetInt("id", 0);
            int isdefault = CRequest.GetInt("isdefault", 0);
            string location_p = CRequest.GetString("location_p");
            string location_c = CRequest.GetString("location_c");
            string location_a = CRequest.GetString("location_a");
            string address = CRequest.GetString("address");

            string name = CRequest.GetString("name");
            string labelname = CRequest.GetString("labelname");

            string mobile = CRequest.GetString("mobile");
            string telephone = CRequest.GetString("telephone");


            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                UserAddress ua = new UserAddress();
                ua.relName = name;
                ua.mobile = mobile;
                ua.tel = telephone;
                ua.qq = location_p;
                ua.weixin = location_c;
                ua.zipcode = location_a;
                ua.pid = 0;
                ua.cid = 0;
                ua.regionId = 0;
                ua.address = address;
                ua.addressDetail = labelname;
                ua.status = 0;
                ua.remark = "";
                ua.addTime = DateTime.Now;
                ua.addUser = user.id;
                ua.infoType = isdefault;
                //更新其他未默认
                int rows = UserAddressService.UpdateInfoType(ua.addUser, 0);
                int num = UserAddressService.Add(ua);
                if (num > 0)
                {
                    Response.Write("success_" + num);
                }
                else
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("fail");
            }
        }

        /// <summary>
        /// 获取三级地址信息
        /// </summary>
        private void GetArea33()
        {
            StringBuilder sb = new StringBuilder();
            int p = CRequest.GetInt("p", 0);
            int zipcode = CRequest.GetInt("zipcode", 0);
            if(p != 0)
            {
                DataSet ds = AreaInfoService.GetList("parentId = " + p);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sb.Append("<option value=\"0\">请选择</option>");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (zipcode == Convert.ToInt32(dr["id"]))
                        {
                            sb.Append("<option value=\"" + dr["id"] + "\" selected>" + dr["areaName"] + "</option>");
                        }
                        else
                        {
                            sb.Append("<option value=\"" + dr["id"] + "\">" + dr["areaName"] + "</option>");
                        }

                    }
                }
                else
                {
                    sb.Append("<option value=\"0\">请选择</option>");
                }
            }
            else
            {
                sb.Append("<option value=\"0\">请选择</option>");
            }
            Response.Write(sb.ToString());
        }
        /// <summary>
        /// 获取二级地址信息
        /// </summary>
        private void GetArea22()
        {
            StringBuilder sb = new StringBuilder();
            int p = CRequest.GetInt("p", 0);
            int cur = CRequest.GetInt("cur", 0);
            DataSet ds = AreaInfoService.GetList("parentId = " + p);
            if (ds.Tables[0].Rows.Count > 0)
            {
                sb.Append("<option value=\"0\">请选择</option>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (cur == Convert.ToInt32(dr["id"]))
                    {
                        sb.Append("<option value=\"" + dr["id"] + "\" selected>" + dr["areaName"] + "</option>");
                    }
                    else
                    { 
                        sb.Append("<option value=\"" + dr["id"] + "\">" + dr["areaName"] + "</option>");
                    }
                    
                }
            }
            else
            {
                sb.Append("<option value=\"0\">请选择</option>");
            }
            Response.Write(sb.ToString());
        }
        /// <summary>
        /// 获取三级地址信息
        /// </summary>
        private void GetArea3()
        {
            StringBuilder sb = new StringBuilder();
            int p = CRequest.GetInt("p", 0);
            DataSet ds = AreaInfoService.GetList("parentId = " + p);
            if (ds.Tables[0].Rows.Count > 0)
            {
                sb.Append("<option value=\"0\">请选择</option>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append("<option value=\"" + dr["id"] + "\">" + dr["areaName"] + "</option>");
                }
            }
            else
            {
                sb.Append("<option value=\"0\">请选择</option>");
            }
            Response.Write(sb.ToString());
        }
        /// <summary>
        /// 获取二级地址信息
        /// </summary>
        private void GetArea2() 
        {
            StringBuilder sb = new StringBuilder();
            int p = CRequest.GetInt("p",0);
            DataSet ds = AreaInfoService.GetList("parentId = " + p);
            if (ds.Tables[0].Rows.Count > 0)
            {
                sb.Append("<option value=\"0\">请选择</option>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append("<option value=\"" + dr["id"] + "\">" + dr["areaName"] + "</option>");
                }
            }
            else
            {
                sb.Append("<option value=\"0\">请选择</option>");
            }
            Response.Write(sb.ToString());
        }
        /// <summary>
        /// 设置头像
        /// </summary>
        private void SetHeadImgMobile() 
        {
            string img = CRequest.GetString("img").Trim();
            if (img.IndexOf("data") != -1)
            {
                var imgData = img.Trim().Replace("data:image/png;base64,", "");
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
                    string path = Global_Upload.FriendImgPath + user.id + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";

                    image.Save(Server.MapPath(path));
                    user.imgUrl = path;
                    int rows = UserInfoService.UpdateImg(user, 5);
                    if (rows > 0)
                    {
                        Session["user"] = user;
                        Response.Write(path);
                    }
                }
            }
        }
        /// <summary>
        /// 绑定优惠卡
        /// </summary>
        private void BindCardMobile() 
        {
            
        }
        /// <summary>
        /// 找回Password
        /// </summary>
        private void SetNewPass()
        {
            string password = CRequest.GetString("password");
            string mobile = "1" + CRequest.GetString("tel");
            string md5Pass = encrypt.EncryptMd5(password);
            string code = CRequest.GetString("code");
             
            if (!MessageCodeService.Exists(mobile, code))
            {
                Response.Write("codeError");
                return;
            }


            int maxId = UserInfoService.SetNewPass(mobile,password,md5Pass);
            if (maxId > 0)
            {
                Response.Write("success");
            }
            else
            {
                Response.Write("fail");
            }

        }

        /// <summary>
        /// 绑定邮箱
        /// </summary>
        private void BindMobileEmail() 
        {
            string code = CRequest.GetString("code");
            string email = CRequest.GetString("email");
            EmailCode item = EmailCodeService.GetModel(email);
            if (item != null)
            {
                if (item.emailCode == code)
                {
                    UserInfo user = Session["user"] as UserInfo;
                    if(user != null)
                    {
                        user.email = email;
                        user.isBindEmail = 1;
                        int rows = UserInfoService.BindEmail(user.id, email);
                        if (rows > 0)
                        {
                            Session["user"] = user;
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("error");
                        }
                    }
                }
                else
                {
                    Response.Write("codeError");
                }
            }
            else
            {
                Response.Write("error");
            }
        }
        /// <summary>
        /// Send Verification Code
        /// </summary>
        private void GetEmail() 
        {
            string email = CRequest.GetString("email");
            GetModpassCode(email);
        }
        /// <summary>
        /// send code
        /// </summary>
        private void GetModpassCode(string email)
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (SendEmail(email))
                {
                    Response.Write("success");
                }
                else
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        private bool SendEmail(string clientEmail)
        {
            string email = BaseConfigService.GetById(20);
            string password = BaseConfigService.GetById(21);
            string protocol = BaseConfigService.GetById(22);

            EmailCode item = new EmailCode();
            Random ran = new Random();
            int num = ran.Next(105999, 999999);

            string title = "来自Plate-X网的邮箱Image Verification Code";
            string content = "尊敬的Plate-X网用户您好  您的Image Verification Code是：" + num + "<br><br>";
            string lan = "感谢您的访问，祝您使用愉快！";

            item.email = clientEmail;
            item.emailCode = num.ToString();
            item.status = 0;
            item.remark = "";
            item.infoType = 0;
            int maxId = EmailCodeService.Add(item);
            if (maxId > 0)
            {
                if (User_SendMail(protocol, email, password, clientEmail, title, content + lan))
                {
                    return true;
                }
            }
            return false;

        }
        //
        #region 邮件发送
        protected bool User_SendMail(string host, string uid, string pwd, string to, string subject, string body)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = host;// "mail.summerpalace-china.com";
                client.UseDefaultCredentials = false;

                client.Credentials = new System.Net.NetworkCredential(uid, pwd);//("info@summerpalace-china.com", "summerSiteDB");
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(uid, to);//("info@summerpalace-china.com", to);
                message.Subject = subject;
                message.Body = body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                throw;
                //return false;
            }
        }
        #endregion
        /// <summary>
        /// Save反馈
        /// </summary>
        private void SaveMess() 
        {
            string mess = CRequest.GetString("mess");
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                DataSet ds = UserImgService.GetList("addUser = " + user.id + " and infoType = 1 and typeId = 0");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int rows = UserImgService.UpdateMess(user.id,mess);
                    if (rows > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                else
                {
                    UserImg item = new UserImg();
                    item.typeId = 1;
                    item.typeName = "反馈图片";
                    item.messTitle = "";
                    item.messContent = mess;
                    item.imgUrl = "";
                    item.status = 0;
                    item.remark = "";
                    item.addTime = DateTime.Now;
                    item.addUser = user.id;
                    item.infoType = 1;
                    int rows = UserImgService.Add(item);
                    if (rows > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
            }
            
        }
        /// <summary>
        ///设置默认地址
        /// </summary>
        private void UpdateDefaultAddr() 
        {
            string id = CRequest.GetString("id");
            string[] arr = id.Split('_');
            if(arr.Length > 0)
            {
                int addid = Convert.ToInt32(arr[1]);
                UserInfo user = Session["user"] as UserInfo;
                if(user != null)
                {
                    UserAddressService.UpdateInfoType(user.id,0);
                    UserAddressService.SetDefault(addid,1);
                }
            }
        }
        /// <summary>
        /// 检查是否有默认地址
        /// 
        /// </summary>
        private void CheckAddr() 
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                DataSet ds = UserAddressService.GetList("addUser = " + user.id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Response.Write("success");
                }
                else
                {
                    Response.Write("no");
                }
            }
            else
            {
                Response.Write("nologin");
            }
        }
        
        /// <summary>
        /// 支付Password
        /// </summary>
        private void ModPayPass() 
        {
            int s = CRequest.GetInt("status",0);
            string oldP = CRequest.GetString("oldPass");

            string zhifupass1 = CRequest.GetString("zhifupass1");
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if(s == 1)
                {
                    if(encrypt.EncryptMd5(oldP) != user.telephone)
                    {
                        Response.Write("oldError");
                        return;
                    }
                }
                user.telephone = encrypt.EncryptMd5(zhifupass1);
                int num = UserInfoService.UpdatePayPass(user);
                if (num > 0)
                {
                    Response.Write("success");
                }
                else
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("nologin");
            }
        }
        /// <summary>
        /// 绑定Phone号
        /// </summary>
        private void BindMobile() 
        {
            string mobile = CRequest.GetString("mobile");
            string code = CRequest.GetString("code");
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (!MessageCodeService.Exists(mobile, code))
                {
                    Response.Write("codeError");
                    return;
                }
                else
                {
                    user.mobile = mobile;
                    int rows = UserInfoService.UpdateMobile(user);
                    if (rows > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
            }
            else
            {
                Response.Write("nologin");
            }
        }
        /// <summary>
        /// 绑定邮箱
        /// </summary>
        private void BindEmail() 
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                string email = CRequest.GetString("email");
                
                if (SendEmail(email, user))
                {
                    Response.Write("success");
                }
                else
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        private void ModAddr()
        {
            string hidId = CRequest.GetString("hidId");
            string location_p = CRequest.GetString("location_p");
            string location_c = CRequest.GetString("location_c");
            string location_a = CRequest.GetString("location_a");
            string address = CRequest.GetString("address");

            string name = CRequest.GetString("name");
            string labelname = CRequest.GetString("labelname");

            string mobile = CRequest.GetString("mobile");
            string telephone = CRequest.GetString("telephone");
            int isdefault = CRequest.GetInt("isdefault", 0);

            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                UserAddress ua = new UserAddress();
                ua.relName = name;
                ua.mobile = mobile;
                ua.tel = telephone;
                ua.qq = location_p;
                ua.weixin = location_c;
                ua.zipcode = location_a;
                ua.pid = 0;
                ua.cid = 0;
                ua.regionId = 0;
                ua.address = address;
                ua.addressDetail = labelname;
                ua.status = 0;
                ua.remark = "";
                ua.addTime = DateTime.Now;
                ua.addUser = user.id;
                ua.infoType = isdefault;
                if (ua.infoType == 1)
                {
                    if (hidId != "")
                    {
                        //更新其他为未默认
                        UserAddressService.UpdateInfoType(ua.addUser, 0);
                        ua.id = Convert.ToInt32(hidId);
                        if (UserAddressService.Update(ua))
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                else
                {
                    if (hidId != "")
                    {
                        ua.id = Convert.ToInt32(hidId);
                        if (UserAddressService.Update(ua))
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                

            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// Delete地址信息ModAddr
        /// </summary>
        private void DelAddr() 
        {
            int id = CRequest.GetInt("id",0);
            if (UserAddressService.Delete(id))
            {
                Response.Write("success");
            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// Upload图片
        /// </summary>
        private string UploadImg(string imgstr)
        {
            string path = "";
            try
            {
                var imgData = imgstr.Replace("data:image/png;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");
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

                path = Global_Upload.FriendImgPath + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".jpg";
                image.Save(Server.MapPath(path));

            }
            catch (Exception je)
            {
                Response.Write(je.Message);
            }
            return path;
        }

        /// <summary>
        /// 完善信息
        /// </summary>
        private void SaveBase() 
        {
            string surname = CRequest.GetString("surname");
            string birthday = CRequest.GetString("birthday");
            string realname = CRequest.GetString("realname");

            string street = CRequest.GetString("street");
            string street2 = CRequest.GetString("street2");

            string city = CRequest.GetString("city");
            string province = CRequest.GetString("province");

            string imgurl = CRequest.GetString("imgurl");
            int sex = CRequest.GetInt("sex",0);
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                user.shopingtime = birthday;
                user.username = surname;
                user.relName = realname;
                user.sharecount = sex;
                if(imgurl.IndexOf("data") != -1)
                {
                    user.imgUrl = UploadImg(imgurl);
                }
                user.mobileCode = street;
                user.activeCode = city;
                user.mainbrand = province;
                user.address = street2;

                UserInfoService.UpdateInfo(user);
                Session["user"] = user;
            }
            Response.Write("success");
        }
        /// <summary>
        /// Send Verification Code
        /// </summary>
        private void GetCode() 
        {
            if (Session["code"] != null)
            {
                Response.Write(Session["code"].ToString());
            }
            else
            {
                Response.Write("");
            }
        }
        /// <summary>
        /// Delete购物车中的商品
        /// </summary>
        private void DelProduct() 
        {
            int pid = CRequest.GetInt("id", 0);
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                CartTempService.Delete(user.id,pid);
            }
            Response.Write("success");
        }
        /// <summary>
        /// Add To Cart
        /// </summary>
        private void AddToCart() 
        {
            int hidCount = CRequest.GetInt("hidCount",0);
            int productId = CRequest.GetInt("id",0);
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                Product p = ProductService.GetModel(productId);
                if (p != null)
                {
                    string remark = (p.price1 * hidCount).ToString();
                    if (CartTempService.Exists(productId, user.id))
                    {
                        CartTemp ct = CartTempService.GetModel(user.id,productId);
                        if(ct != null)
                        {
                            ct.productCount += hidCount;
                            ct.remark = (Convert.ToDouble(ct.remark) + (p.price1 * hidCount)).ToString();
                            CartTempService.UpdateCart(ct);
                        }
                        //CartTempService.Update(productId, hidCount,remark);
                    }
                    else
                    {
                        CartTemp ct = new CartTemp();
                        ct.productId = productId;
                        ct.productCount = hidCount;
                        ct.addUser = user.id;
                        ct.status = 0;
                        ct.remark = remark;
                        CartTempService.Add(ct);
                    }
                    Response.Write("success");
                }
                else
                {
                    Response.Write("error");
                }
            }else
            {
                Response.Write("nologin");
            }
            
        }
        /// <summary>
        /// 资讯留言
        /// </summary>
        private void NewsMessage() 
        {
            UserInfo user = Session["user"] as UserInfo;

            string id = CRequest.GetString("id");
            string message = CRequest.GetString("message");
            Comment item = new Comment();
            item.dataType = 1;
            item.fromId = Convert.ToInt32(id);
            item.commentInfo = message;
            item.commentDesc = "";
            item.status = 0;
            item.remark = "";
            item.addTime = DateTime.Now;
            item.addUser = 0;
            if(user != null)
            {
                item.addUser = user.id;
            }
            item.infoType = 0;
            int maxId = CommentService.Add(item);
            if (maxId > 0)
            {
                Response.Write("success");
            }
            else
            {
                Response.Write("fail");
            }
        }

        /// <summary>
        /// 设置Password
        /// </summary>
        private void SetPass()
        {
            string password = CRequest.GetString("password");
            string hidMobileCode = CRequest.GetString("hidMobileCode");
            string hidActiveCode = CRequest.GetString("hidActiveCode");
            string md5Pass = encrypt.EncryptMd5(password);
            int num = UserInfoService.UpdatePassword(password,md5Pass,hidMobileCode,hidActiveCode);
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
        /// 发送邮件
        /// </summary>
        private bool SendEmail_FindPass(string username,string email_User)
        {
            string title = "农搜搜通知—Password修改";
            string content = "尊敬的农搜搜用户您好  您只需点击链接即可修改Password：<br><br> ";
            string url = "<a href='" + BaseConfigService.GetById(12) + "/findPass.html?q=" + encrypt.EncryptMd5(username) + "&w=" + encrypt.EncryptMd5(email_User) + "' target='_blank' style='text-decoration:none;'>http://" + encrypt.EncryptMd5("nss_nongsousou" + username) + encrypt.EncryptMd5(email_User) + "</a>";
            string lan = "<br><br>（如果点击链接无效，请将该地址手工粘贴到浏览器地址栏再访问），感谢您的访问，祝您使用愉快！";
            string protocol = BaseConfigService.GetById(22);
            string email = BaseConfigService.GetById(20);
            string password = BaseConfigService.GetById(21);
            //更新这个账号和邮箱的信息

            UserInfoService.UpdateActive(username, email_User, encrypt.EncryptMd5(username), encrypt.EncryptMd5(email_User));
            return User_SendMail(protocol, email, password, email_User, title, content + url + lan);
        }
        /// <summary>
        /// 找回Password
        /// </summary>
        private void FindPass() 
        {
            string username = CRequest.GetString("username");
            string email = CRequest.GetString("email");
            username = UserInfoService.GetUserName(username, email);
            if (username != "")
            {
                if (SendEmail_FindPass(username, email))
                {
                    Response.Write("success");
                }
                else
                {
                    Response.Write("emailError");
                } 
            }
            else
            {
                Response.Write("error");
            }
        }
        /// <summary>
        /// 完善信息
        /// </summary>
        private void FullShop() 
        {
            string surname = CRequest.GetString("surname");
            string relname = CRequest.GetString("relname");
            string shoperName = CRequest.GetString("shoperName");
            string street = CRequest.GetString("street");
            string street2 = CRequest.GetString("street2");
            string city = CRequest.GetString("city");
            string province = CRequest.GetString("province");
            string email = CRequest.GetString("email");
            string remark = CRequest.GetString("remark");
            string imgUrl = CRequest.GetString("imgurl");

            int shopType = CRequest.GetInt("shopType", 0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                user.username = surname;
                user.relName = relname;
                user.comName = shoperName;
                user.mobileCode = street;
                user.activeCode = city;
                user.mainbrand = province;
                user.email = email;
                user.remark = remark;
                user.shopType = shopType;
                user.weibo = street2;
                if (imgUrl.IndexOf("data") != -1)
                {
                    user.imgUrl = UploadImg(imgUrl);
                }
                int rows = UserInfoService.UpdateShopInfo(user);
                if (rows > 0)
                {
                    Session["user"] = user;
                    Response.Write("success");
                }
                else
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("nologin");
            }
        }
        /// <summary>
        /// 添加地址信息
        /// </summary>
        private void SaveOrderAddr()
        {
            int orderId = CRequest.GetInt("orderId", 0);
            string location_p = CRequest.GetString("location_p");
            string location_c = CRequest.GetString("location_c");
            string location_a = CRequest.GetString("location_a");
            string address = CRequest.GetString("address");

            string name = CRequest.GetString("name");
            string labelname = CRequest.GetString("labelname");

            string mobile = CRequest.GetString("mobile");
            string telephone = CRequest.GetString("telephone");


            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                OrderAddress ua = new OrderAddress();
                ua.orderId = orderId;
                ua.orderNo = "";

                ua.relName = name;
                ua.mobile = mobile;
                ua.tel = telephone;
                ua.qq = location_p;
                ua.weixin = location_c;
                ua.zipcode = location_a;
                ua.pid = 0;
                ua.cid = 0;
                ua.regionId = 0;
                ua.pName = location_p;
                ua.cName = location_c;
                ua.regionName = location_a;


                ua.address = address;
                ua.addressDetail = labelname;
                ua.labelName = labelname;
                ua.otherName = labelname;


                ua.status = 0;
                ua.remark = "";
                ua.addTime = DateTime.Now;
                ua.addUser = user.id;
                ua.infoType = 0;
                int num = OrderAddressService.Add(ua);
                if (num > 0)
                {
                    Response.Write("success");
                }
                else
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        private void SaveAddr() 
        {
            int id = CRequest.GetInt("id",0);
            int isdefault = CRequest.GetInt("isdefault", 0);
            string location_p = CRequest.GetString("location_p");
            string location_c = CRequest.GetString("location_c");
            string location_a = CRequest.GetString("location_a");
            string address = CRequest.GetString("address");

            string name = CRequest.GetString("name");
            string labelname = CRequest.GetString("labelname");

            string mobile = CRequest.GetString("mobile");
            string telephone = CRequest.GetString("telephone");
            

            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                UserAddress ua = new UserAddress();
                ua.relName = name;
                ua.mobile = mobile;
                ua.tel = telephone;
                ua.qq = location_p;
                ua.weixin = location_c;
                ua.zipcode = location_a;
                ua.pid = 0;
                ua.cid = 0;
                ua.regionId = 0;
                ua.address = address;
                ua.addressDetail = labelname;
                ua.status = 0;
                ua.remark = "";
                ua.addTime = DateTime.Now;
                ua.addUser = user.id;
                ua.infoType = isdefault;
                //更新其他未默认
                if (id != 0)
                {
                    if (ua.infoType == 1)
                    {
                        int rows = UserAddressService.UpdateInfoType(ua.addUser, 0);
                        ua.id = id;

                        if (UserAddressService.Update(ua))
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                    else
                    {
                        ua.id = id;
                        if (UserAddressService.Update(ua))
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                }
                else
                {
                    if (ua.infoType == 1)
                    {
                        int rows = UserAddressService.UpdateInfoType(ua.addUser, 0);
                        int num = UserAddressService.Add(ua);
                        if (num > 0)
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                    else
                    {
                        int num = UserAddressService.Add(ua);
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
               
                
            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        private void SaveAddr1()
        {
            int id = CRequest.GetInt("id", 0);
            int isdefault = CRequest.GetInt("isdefault", 0);
            string location_p = CRequest.GetString("location_p");
            string location_c = CRequest.GetString("location_c");
            string location_a = CRequest.GetString("location_a");
            string address = CRequest.GetString("address");

            string name = CRequest.GetString("name");
            string labelname = CRequest.GetString("labelname");

            string mobile = CRequest.GetString("mobile");
            string telephone = CRequest.GetString("telephone");


            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                UserAddress ua = new UserAddress();
                ua.relName = name;
                ua.mobile = mobile;
                ua.tel = telephone;
                ua.qq = location_p;
                ua.weixin = location_c;
                ua.zipcode = location_a;
                ua.pid = 0;
                ua.cid = 0;
                ua.regionId = 0;
                ua.address = address;
                ua.addressDetail = labelname;
                ua.status = 0;
                ua.remark = "";
                ua.addTime = DateTime.Now;
                ua.addUser = user.id;
                ua.infoType = isdefault;
                //更新其他未默认
                if (id != 0)
                {
                    if (ua.infoType == 1)
                    {
                        int rows = UserAddressService.UpdateInfoType(ua.addUser, 0);
                        ua.id = id;

                        if (UserAddressService.Update(ua))
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                    else
                    {
                        ua.id = id;
                        if (UserAddressService.Update(ua))
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                }
                else
                {
                    if (ua.infoType == 1)
                    {
                        int rows = UserAddressService.UpdateInfoType(ua.addUser, 0);
                        int num = UserAddressService.Add(ua);
                        if (num > 0)
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                    else
                    {
                        int num = UserAddressService.Add(ua);
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


            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// 回复信息
        /// </summary>
        private void Reply() 
        {
            string reply = CRequest.GetString("reply");
            string code = CRequest.GetString("code");
            if (Session["code"].ToString() != code)
            {
                Response.Write("codeError");
            }
            else
            {
                int id = CRequest.GetInt("id", 0);
                Reply item = new Reply();
                item.commentId = id;
                item.replyContent = reply;
                item.status = 0;
                item.remark = "";
                item.addTime = DateTime.Now;
                item.addUser = 0;
                UserInfo user = Session["user"] as UserInfo;
                if (user != null && user.infoType == 2)
                {
                    item.addUser = user.id;
                    item.infoType = 0;
                    int num = ReplyService.Add(item);
                    if (num > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                else
                {
                    Response.Write("login");
                }
            }
        }
        /// <summary>
        /// 登陆事件
        /// </summary>
        private void Login() 
        {
            int cboRemember = CRequest.GetInt("cboRemember", 0);
            string mobile = "1" + CRequest.GetString("mobile");
            string password = CRequest.GetString("password");
            string md5Pass = encrypt.EncryptMd5(password);
            UserInfo user = UserInfoService.GetModel(mobile, md5Pass);
            if (user != null)
            {
                HttpCookie cookie = new HttpCookie("userInfo");
                if (cboRemember == 1)
                {
                    cookie.Expires = DateTime.Now.AddDays(365);
                    cookie.Values.Add("Name", mobile);
                    cookie.Values.Add("Pwd", password);
                    Response.AppendCookie(cookie);
                    //cookie["userId"] = user.id.ToString();
                    //cookie["cookDays"] = "365";
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(0);
                }
                //临时购物车中的商品插入到购物车表
                List<CartTemp> cartlist = Session["nologinCart"] as List<CartTemp>;
                if (cartlist != null)
                {
                    if (cartlist.Count > 0)
                    {
                        foreach (CartTemp ct in cartlist)
                        {
                            ct.addUser = user.id;
                            ct.status = 1;
                            Product item = ProductService.GetModel(ct.productId);
                            ct.remark = "";
                            if (item != null)
                            {
                                ct.remark = (item.price1 * ct.productCount).ToString("0.00");
                            }
                            ct.sel = 1;
                            CartTempService.Add(ct);
                        }
                    }
                }
                Session["nologinCart"] = null;


                Session["user"] = user;
                Response.Write("success");
            }
            else
            {
                if (UserInfoService.Exists(mobile))
                {
                    Response.Write("fail");
                }
                else
                {
                    Response.Write("noexists");
                }
                
            }
        }
        /// <summary>
        /// 修改Password
        /// </summary>
        private void ModPass()
        {
            string p1 = CRequest.GetString("oldp");
            string p2 = CRequest.GetString("newp");
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                if (user.md5Pass == encrypt.EncryptMd5(p1))
                {
                    user.password = p2;
                    user.md5Pass = encrypt.EncryptMd5(p2);
                    int num = UserInfoService.ModPass(user);
                    if (num > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                else
                {
                    Response.Write("error");
                }
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        private bool SendEmail(string emailBind,UserInfo user)
        {
            string title = "来自Plate-X网的邮箱绑定信";
            string content = "尊敬的Plate-X网用户您好  您只需点击链接即可激活绑定邮箱,<br><br>";
            string url = "<a href='" + BaseConfigService.GetById(12) + "/emailCredit.html?ue=" + user.id + "&ee=" + emailBind + "' target='_blank' style='text-decoration:none;'>http://" + encrypt.EncryptMd5("yx_iyuanxiang" + user.id.ToString()) + encrypt.EncryptMd5(user.email) + "</a>";
            string lan = "<br><br> （如果点击链接无效，请将该地址手工粘贴到浏览器地址栏再访问），感谢您的访问，祝您使用愉快！";
            string protocol = BaseConfigService.GetById(22);
            string email = BaseConfigService.GetById(20);
            string password = BaseConfigService.GetById(21);

            return User_SendMail(protocol, email, password, emailBind, title, content + url + lan);
        }
        //
        /// <summary>
        /// Join
        /// </summary>
        private void RegShop()
        {
            int shopType = CRequest.GetInt("shopType", 0);
            string surname = CRequest.GetString("surname");
            string relname = CRequest.GetString("relname");
            string shoperName = CRequest.GetString("shoperName");
            string street = CRequest.GetString("street");
            string street2 = CRequest.GetString("street2");
            string city = CRequest.GetString("city");
            string province = CRequest.GetString("province");
            string email = CRequest.GetString("email");
            string remark = CRequest.GetString("remark");
            
            string password = CRequest.GetString("password");
            string mobile = CRequest.GetString("tel");
            string md5Pass = encrypt.EncryptMd5(password);
            string code = CRequest.GetString("code");
            UserInfo user = null;
            if (UserInfoService.ExistsMobile(mobile))
            {
                Response.Write("existsMobile");
                return;
            }
            if (!MessageCodeService.Exists(mobile, code))
            {
                Response.Write("codeError");
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
            user.weibo = street2;
            user.isBindWeiBo = 0;
            user.shopType = shopType;
            user.shopTypeName = "";
            user.imgUrl = "";
            user.comInfo = "";
            user.remark = remark;
            user.status = 0;
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
                user.id = maxId;
                Session["user"] = user;
                Response.Write("success");
            }
            else
            {
                Response.Write("fail");
            }

        }
        /// <summary>
        /// Join
        /// </summary>
        private void Reg() 
        {
            string password = CRequest.GetString("password");
            string mobile = "1" + CRequest.GetString("tel");
            string md5Pass = encrypt.EncryptMd5(password);
            string code = CRequest.GetString("code");
            UserInfo user = null;
            if (UserInfoService.ExistsMobile(mobile))
            {
                Response.Write("existsMobile");
                return;
            }
            if(!MessageCodeService.Exists(mobile,code))
            {
                Response.Write("codeError");
                return;
            }
            user = new UserInfo();
            user.username = "";
            user.mobile = mobile;
            user.isBindMobile = 1;
            user.email = "";
            user.isBindEmail = 0;
            user.password = password;
            user.md5Pass = encrypt.EncryptMd5(password);
            user.telephone = "";
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
            user.shopingtime = "";

            user.mainbrand = "";
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
                user.id = maxId;
                Session["user"] = user;
                Response.Write("success");
            }
            else
            {
                Response.Write("fail");
            }
            
        }
    }
}