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
    public partial class shoper_setup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                //if (Session["user"] == null)
                //{
                //    Response.Redirect("login.html");
                //}
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
            
            //ddlYear.Items.Insert(0,new ListItem("0","请选择"));
            //ddlDay.Items.Insert(0,new ListItem("0","请选择"));
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                if (user.imgUrl != "")
                {
                    ViewState["headImg"] = user.imgUrl;
                }
                else
                {
                    ViewState["headImg"] = "images/nohead.png";
                }
                if (user.mainbrand != "")
                {
                    ViewState["nicheng"] = user.mainbrand;
                }
                else
                {
                    ViewState["nicheng"] = user.mobile;
                }
                if(user.shopingtime != "")
                {
                    ViewState["birthday"] = user.shopingtime;
                }
                if(user.relName != "")
                {
                    ViewState["realname"] = user.relName;
                }
            }
        }
    }
}