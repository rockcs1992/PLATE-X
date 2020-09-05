using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using Model;
using System.IO;
using System.Text;
using System.Net;

namespace CommonBussiness.admin
{
    public partial class topInfo : System.Web.UI.Page
    {
        int newsId = CRequest.GetInt("newsId",0);
        int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }     
                
                if(id != 0)
                {
                    LoadModelInfo();
                }
            }
        }
        /// <summary>
        /// 获取对象
        /// </summary>
        private void LoadModelInfo()
        {
            TopNews item = TopNewsService.GetModel(id);
            if(item != null)
            {
                txtTitle.Text = item.remark;
                txtZhaiYao.Text = item.baseInfo;
                ViewState["newsImg1"] = item.imgURL;                
            }
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

        //从控件上传文件
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
                        ViewState["img1Name"] = spic;
                        spic = Global_Upload.NewsTopImgPath + spic;
                        ViewState["newsImg1"] = spic;
                    }
                }
            }
        }

        /// <summary>
        /// 发布资讯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRelease_Click(object sender, EventArgs e)
        {
            if (Session["loginUser"] == null)
            {
                Jscript.AlertAndRedirect("请登录", "/admin/login.aspx");
                return;
            }
                      
            if(newsId != 0)
            {
                TopNews item = new TopNews();
                item.newsId = newsId;
                item.newsType = CRequest.GetInt("newsType",0);
                item.imgURL = "";
                if (ViewState["newsImg1"] != null)
                {
                    item.imgURL = ViewState["newsImg1"].ToString();
                }
                else
                {
                    item.imgURL = "";
                }
         
                item.baseInfo = txtZhaiYao.Text.Trim();
                item.orderNum = 0;
                item.status = 0;
                item.remark = txtTitle.Text.Trim();
                item.addtime = DateTime.Now;
                item.adduser = (Session["loginUser"] as AdminUser).id;
                item.infoType = 0;
                if(item.imgURL == "" || item.baseInfo == "")
                {
                    this.lblError.Text = "请填写信息内容并上传图片";
                    return;
                }
                if(item.baseInfo.Length > 500)
                {
                    this.lblError.Text = "信息内容不能超过500字";
                    return;
                }

                int num = TopNewsService.Add(item);
                if (num > 0)
                {
                    NewsService.UpdateTop(item.newsId,1);
                    Response.Redirect("infoList.aspx");
                }
                else
                {
                    lblError.Text = "设置置顶失败";
                }
            }
            if(id != 0)
            {
                TopNews item = TopNewsService.GetModel(id);
                if (item != null)
                {
                    item.imgURL = "";
                    if (ViewState["newsImg1"] != null)
                    {
                        item.imgURL = ViewState["newsImg1"].ToString();
                    }
                    else
                    {
                        item.imgURL = "";
                    }
                    item.remark = txtTitle.Text.Trim();
                    item.baseInfo = txtZhaiYao.Text.Trim();
                    int num = TopNewsService.Update(item);
                    if (num > 0)
                    {
                        Response.Redirect("topInfoList.aspx");
                    }
                    else
                    {
                        lblError.Text = "修改失败";
                    }
                }
            }
        }

        /// <summary>
        /// 文件夹不存在就创建文件夹
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
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                Response.Redirect("topInfoList.aspx");
            }
            else
            {
                Response.Redirect("infoList.aspx");
            }
        }
        
        
    }
}