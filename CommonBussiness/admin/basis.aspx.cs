using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DAL;
using System.IO;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.Text;
using System.Drawing.Imaging;

namespace CommonBussiness.admin
{
    public partial class basis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                LoadInfo();
            }
        }
        
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadInfo()
        {
            if(!IsPostBack)
            {
                this.txtBase1.Text = BaseConfigService.GetById(13);
                this.txtBase2.Text = BaseConfigService.GetById(12);
                this.txtBase3.Text = BaseConfigService.GetById(13);
                this.txtBase4.Text = BaseConfigService.GetById(14);
                this.txtBase5.Text = BaseConfigService.GetById(15);
                this.txtBase6.Text = BaseConfigService.GetById(16);
                this.txtBase7.Text = BaseConfigService.GetById(17);
                this.txtBase8.Text = BaseConfigService.GetById(18);
                this.txtBase9.Text = BaseConfigService.GetById(19);
                
                this.txtBase12.Text = BaseConfigService.GetById(20);
                this.txtBase13.Text = BaseConfigService.GetById(21);
                this.txtBase14.Text = BaseConfigService.GetById(22);
                this.txtBase15.Text = BaseConfigService.GetById(23);

                this.tb_id.Text = BaseConfigService.GetById(39);
                this.tb_secret.Text = BaseConfigService.GetById(40);
                this.tb_URL.Text = BaseConfigService.GetById(41);
                lblURL1.Text = BaseConfigService.GetById(24);
                lblURL2.Text = BaseConfigService.GetById(25);

                lblURL3.Text = BaseConfigService.GetById(26);
                lblURL4.Text = BaseConfigService.GetById(27);

                lblURL5.Text = BaseConfigService.GetById(28);

                txtMonthValue.Text = BaseConfigService.GetById(1);
                txtYearValue.Text = BaseConfigService.GetById(2);
                txtVideo.Text = BaseConfigService.GetById(5);
            }
            
        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            BaseConfigService.SetValue(1, this.txtMonthValue.Text.Trim());
            BaseConfigService.SetValue(2, this.txtYearValue.Text.Trim());

            BaseConfigService.SetValue(5, this.txtVideo.Text.Trim());
            BaseConfigService.SetValue(11, this.txtBase1.Text.Trim());
            BaseConfigService.SetValue(12, this.txtBase2.Text.Trim());
            BaseConfigService.SetValue(13, this.txtBase3.Text.Trim());
            BaseConfigService.SetValue(14, this.txtBase4.Text.Trim());
            BaseConfigService.SetValue(15, this.txtBase5.Text.Trim());
            BaseConfigService.SetValue(16, this.txtBase6.Text.Trim());
            BaseConfigService.SetValue(17, this.txtBase7.Text.Trim());
            BaseConfigService.SetValue(18, this.txtBase8.Text.Trim());
            BaseConfigService.SetValue(19, this.txtBase9.Text.Trim());

            BaseConfigService.SetValue(20, this.txtBase12.Text.Trim());
            BaseConfigService.SetValue(21, this.txtBase13.Text.Trim());
            BaseConfigService.SetValue(22, this.txtBase14.Text.Trim());
            BaseConfigService.SetValue(23, this.txtBase15.Text.Trim());
            BaseConfigService.SetValue(39, this.tb_id.Text.Trim());
            BaseConfigService.SetValue(40, this.tb_secret.Text.Trim());
            BaseConfigService.SetValue(41, this.tb_URL.Text.Trim());
            string spic = "";
            if (this.FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                if (!Directory.Exists(Server.MapPath(Global_Upload.NewsImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.NewsImgPath));//创建目录
                }
                spic = DoClass.UploadFile(FileUpload1.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.NewsImgPath);

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
                    spic = Global_Upload.NewsImgPath + spic;
                    lblURL1.Text = spic;
                }
            }
            if (this.FileUpload2.PostedFile != null && FileUpload2.PostedFile.FileName != "")
            {
                if (!Directory.Exists(Server.MapPath(Global_Upload.NewsImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.NewsImgPath));//创建目录
                }
                spic = DoClass.UploadFile(FileUpload2.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.NewsImgPath);

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
                    spic = Global_Upload.NewsImgPath + spic;
                    lblURL2.Text = spic;
                }
            }
            if (this.FileUpload3.PostedFile != null && FileUpload3.PostedFile.FileName != "")
            {
                if (!Directory.Exists(Server.MapPath(Global_Upload.NewsImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.NewsImgPath));//创建目录
                }
                spic = DoClass.UploadFile(FileUpload3.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.NewsImgPath);

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
                    spic = Global_Upload.NewsImgPath + spic;
                    lblURL3.Text = spic;
                }
            }
            if (this.FileUpload4.PostedFile != null && FileUpload4.PostedFile.FileName != "")
            {
                if (!Directory.Exists(Server.MapPath(Global_Upload.NewsImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.NewsImgPath));//创建目录
                }
                spic = DoClass.UploadFile(FileUpload4.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.NewsImgPath);

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
                    spic = Global_Upload.NewsImgPath + spic;
                    lblURL4.Text = spic;
                }
            }
            if (this.FileUpload5.PostedFile != null && FileUpload5.PostedFile.FileName != "")
            {
                if (!Directory.Exists(Server.MapPath(Global_Upload.NewsImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.NewsImgPath));//创建目录
                }
                spic = DoClass.UploadFile(FileUpload5.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.NewsImgPath);

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
                    spic = Global_Upload.NewsImgPath + spic;
                    lblURL5.Text = spic;
                }
            }
            BaseConfigService.SetValue(24, this.lblURL1.Text.Trim());
            BaseConfigService.SetValue(25, this.lblURL2.Text.Trim());
            BaseConfigService.SetValue(26, this.lblURL3.Text.Trim());
            BaseConfigService.SetValue(27, this.lblURL4.Text.Trim());
            BaseConfigService.SetValue(28, this.lblURL5.Text.Trim());
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');", true);
        }
        /// <summary>
        /// 重置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.txtBase1.Text = "";
            this.txtBase2.Text = "";
            this.txtBase3.Text = "";
            this.txtBase4.Text = "";
            this.txtBase5.Text = "";
            this.txtBase6.Text = "";
            this.txtBase7.Text = "";
            this.txtBase8.Text = "";
            this.txtBase9.Text = "";
            
            this.txtBase12.Text = "";
            this.txtBase13.Text = "";
            this.txtBase14.Text = "";
            this.txtBase15.Text = "";
            this.txtVideo.Text = "";
            this.txtMonthValue.Text = "";
            txtYearValue.Text = "";
        }
        /// <summary>
        /// 如果目录不存在就创建目录
        /// </summary>
        /// <param name="filename"></param>
        private void NoFolderCreate(string filename)
        {
            string fileDir = Server.MapPath(Path.GetDirectoryName(filename));
            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }
        }

        private string create_two(string nr,int id)
        {
            Bitmap bt;
            string enCodeString = nr;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
            string filename = string.Format(DateTime.Now.ToString(), "yyyymmddhhmmss") + id;
            filename = filename.Replace(" ", "");
            filename = filename.Replace(":", "");
            filename = filename.Replace("-", "");
            filename = filename.Replace(".", "");
            string filepath = Server.MapPath("/image/") + filename + ".png";
            string filepath2 = Server.MapPath("/image/") + filename + ".jpg";
            if (!Directory.Exists(Server.MapPath("/image/")))
                Directory.CreateDirectory(Server.MapPath("/image/"));   
            bt.Save(filepath2, System.Drawing.Imaging.ImageFormat.Jpeg);                  
            //bt.Dispose();



            
            return "/image/" + filename + ".jpg";
        }
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnErWeiCode_Click(object sender, EventArgs e)
        {
            string websiteUrl = BaseConfigService.GetById(12);
            if (websiteUrl == "") 
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请设置网站地址!');", true);
                return;
            }
            DataSet ds = UserInfoService.GetList("infoType in (2,3,4)");
            if(ds.Tables[0].Rows.Count > 0)
            {
                string userUrl = "";
                int id = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"]);
                    userUrl = websiteUrl + "/userDetail_" + id + "_1.html";
                    string url = create_two(userUrl,id);
                    //更新二维码信息
                    UserInfoService.UpdateErWeiCode(id,url);
                }
            }
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('生成成功!');", true);
        }
    }
}