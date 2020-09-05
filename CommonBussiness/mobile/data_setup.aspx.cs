using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.IO;
using DAL;
using System.Text;
using System.Data;

namespace CommonBussiness.mobile
{
    public partial class data_setup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                if (Session["user"] == null)
                {
                    Response.Redirect("login.html");
                }
                BindData();
            }
        }
        /// <summary>
        /// 二进制转图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var imgData = hidImg.Value.Replace("data:image/png;base64,", "");
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
                    this.hidImg.Value = path;
                    user.imgUrl = path;
                    int rows = UserInfoService.UpdateImg(user, 5);
                    if (rows > 0)
                    {
                        Session["user"] = user;
                        ViewState["headImg"] = path;
                    }
                        
                }

            }
            catch (System.Exception exp)
            {
                // Error creating stream or reading from it.
                System.Console.WriteLine("{0}", exp.Message);
                return;
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
        /// 获取性别信息
        /// </summary>
        /// <returns></returns>
        protected string GetSexInfo() 
        {
            StringBuilder sb = new StringBuilder();
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if(user.sharecount == 1)
                {
                    sb.Append("<input type=\"radio\" id=\"woman\" checked=\"checked\" name=\"sex\"/>Male<br><br/>");
                    sb.Append("<input type=\"radio\" id=\"man\" name=\"sex\"/>Female<br><br/>");
                    sb.Append("<input type=\"radio\" id=\"secret\" name=\"sex\" />Do no disclose");
                }
                else if (user.sharecount == 2)
                {
                    sb.Append("<input type=\"radio\" id=\"woman\" name=\"sex\"/>Male<br><br/>");
                    sb.Append("<input type=\"radio\" id=\"man\" checked=\"checked\" name=\"sex\"/>Female<br><br/>");

                    sb.Append("<input type=\"radio\" id=\"secret\" name=\"sex\"/>Do no disclose");
                }
                else
                {
                    sb.Append("<input type=\"radio\" id=\"woman\" name=\"sex\"/>Male<br><br/>");
                    sb.Append("<input type=\"radio\" id=\"man\" name=\"sex\"/>Female<br><br/>");
                    sb.Append("<input type=\"radio\" id=\"secret\" checked=\"checked\" name=\"sex\"/>Do no disclose");
                }
            }
            else
            {
                sb.Append("<input type=\"radio\" id=\"woman\" name=\"sex\"/>Male<br><br/>");
                sb.Append("<input type=\"radio\" id=\"man\" checked=\"checked\" name=\"sex\"/>Female<br><br/>");
                sb.Append("<input type=\"radio\" id=\"secret\" name=\"sex\"/>Do no disclose");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 身份证正面预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbUploadPhoto_Click(object sender, EventArgs e)
        {
            fileUpload(1);
        }

        //从控件Upload文件
        public void fileUpload(int num)
        {
            string spic = "";
            if (num == 1)
            {
                if (filepic.PostedFile != null && filepic.PostedFile.FileName != "")
                {
                    if (!Directory.Exists(Server.MapPath(Global_Upload.NewsTopImgPath)))//判断目录是否存在
                    {
                        Directory.CreateDirectory(Server.MapPath(Global_Upload.NewsTopImgPath));//创建目录
                    }
                    spic = DoClass.UploadFile(filepic.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.NewsTopImgPath);

                    if (spic == "-1")
                    {
                        return;
                    }
                    else if (spic == "0")
                    {
                        return;
                    }
                    else
                    {
                        spic = Global_Upload.NewsTopImgPath + spic;
                        UserInfo user = Session["user"] as UserInfo;
                        if (user != null)
                        {
                            user.imgUrl = spic;
                            int rows = UserInfoService.UpdateImg(user, 5);
                            if(rows > 0)
                            {
                                Session["user"] = user;
                                ViewState["headImg"] = spic;
                            }
                        }
                        
                    }
                }
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            for (int i = 0; i < 100;i++ )
            {
                this.ddlYear.Items.Insert(i,new ListItem((DateTime.Now.Year - i).ToString(),(DateTime.Now.Year - i).ToString()));
            }
            for (int i = 0; i < 31;i++ )
            {
                this.ddlDay.Items.Insert((i), new ListItem((i + 1).ToString(), (i + 1).ToString())); ;
            }
            //ddlYear.Items.Insert(0,new ListItem("0","请选择"));
            //ddlDay.Items.Insert(0,new ListItem("0","请选择"));
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                ViewState["surname"] = user.username;
                ViewState["realname"] = user.relName;
                ViewState["mobile"] = user.mobile;

                ViewState["street"] = user.mobileCode;
                ViewState["city"] = user.activeCode;
                ViewState["province"] = user.mainbrand;

                string[] arr = user.shopingtime.Split('-'); ;
                if(arr.Length > 1)
                {
                    ddlYear.SelectedValue = arr[0];
                    ddlMonth.SelectedValue = arr[1];
                    ddlDay.SelectedValue = arr[2];
                }
                if (user.imgUrl != "")
                {
                    ViewState["headImg"] = user.imgUrl;
                }
                else
                {
                    ViewState["headImg"] = "images/nohead.png";
                }

                ViewState["birthday"] = user.shopingtime;
               
            }
        }
    }
}