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
using System.IO;

namespace CommonBusiness.admin
{
    public partial class contractInfo : System.Web.UI.Page
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
        /// 头部微博二维码扫描图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnWeiBo_Click(object sender, EventArgs e)
        {
            fileUpload(1);
        }

        //从控件上传文件
        public void fileUpload(int num)
        {
            string spic = "";
            if (num == 1)
            {
                #region 微博上传
                if (filepic_weibo.PostedFile != null && filepic_weibo.PostedFile.FileName != "")
                {
                    if (!Directory.Exists(Server.MapPath(Global_Upload.ErWeiImgPath)))//判断目录是否存在
                    {
                        Directory.CreateDirectory(Server.MapPath(Global_Upload.ErWeiImgPath));//创建目录
                    }
                    spic = DoClass.UploadFile(filepic_weibo.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.ErWeiImgPath);

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
                        //ViewState["img1Name"] = spic;
                        spic = Global_Upload.ErWeiImgPath + spic;
                        // ViewState["newsImg1"] = spic;
                        lblImgWeiBo.Text = spic;
                        BaseConfigService.SetValue(11111, spic);

                    }
                }
                #endregion
            }
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadInfo()
        {
            lblImgWeiBo.Text = BaseConfigService.GetById(11111);
            this.content2.Value = BaseConfigService.GetById(11112);
        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            BaseConfigService.SetValue(222222, this.content2.Value.Trim().Replace("'", "\""));
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');", true);
        }
        /// <summary>
        /// 重置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.content2.Value = "";
        }
    }
}