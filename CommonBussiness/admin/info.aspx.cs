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

namespace CommonBusiness.admin
{
    public partial class info : System.Web.UI.Page
    {
        int id = CRequest.GetInt("id",0);
        int typeId = CRequest.GetInt("typeId",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                LoadCate();
                if(id != 0)
                {
                    LoadModelInfo();
                }
            }
        }
        /// <summary>
        /// 加载分类
        /// </summary>
        private void LoadCate()
        {
            DataSet ds = NewsTypeService.GetList("parentId = " + typeId);
            if(ds.Tables[0].Rows.Count > 0)
            {
                ddlCate.DataSource = ds;
                ddlCate.DataTextField = "name";
                ddlCate.DataValueField = "id";
                ddlCate.DataBind();
            }
            ddlCate.Items.Insert(0,new ListItem("请选择","0"));
            
        }
        /// <summary>
        /// 获取对象
        /// </summary>
        private void LoadModelInfo()
        {
            News item = NewsService.GetModel(id);           
            if(item != null)
            {
                this.txtTitle.Text = item.title;
                this.content1.Value = item.newsContent;
                content2.Value = item.newsDesc;
                this.txtKeyWord.Text = item.keyword;
                this.txtDesc.Text = item.newsDesc;
                txtZhaiYao.Text = item.pageName;
                lblIndexImg.Text = item.author;
                if (item.newsType == 1)
                {

                }
                else
                {
                    NewsType nt = NewsTypeService.GetModel(item.newsType);
                    if (nt != null)
                    {
                        ddlCate.SelectedValue = item.newsType.ToString();
                    }
                    else
                    {
                        ddlCate.SelectedValue = item.newsType.ToString();
                    }
                    
                }
                
                lblURL.Text = item.newImg;
                ViewState["addTime"] = item.addTime;
                
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
                    ViewState["newsImg1"] = spic;
                    lblURL.Text = spic;
                }
            }  
            //热点大图
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
                    //ViewState["newsImg2"] = spic;
                    this.lblIndexImg.Text = spic;
                }
            }           
            News item = new News();
            
            item.title = this.txtTitle.Text.Trim();
            item.pageName = txtZhaiYao.Text.Trim();
            item.newsType = 0;
            item.newsType = Convert.ToInt32(ddlCate.SelectedValue);      
            item.newImg = lblURL.Text;


            item.newsContent = this.content1.Value;// Request.Form["content1"]; //this.txtContent.Value;
            item.keyword = this.txtKeyWord.Text.Trim();
            item.newsDesc = this.content2.Value.Trim();
            if (id != 0)
            {
                item.linkurl = "/news/" + Convert.ToDateTime(ViewState["addTime"]).ToString("yyyyMMddhhmmss") + ".html";
            }
            else
            {
                item.addTime = DateTime.Now;
                item.linkurl = "/news/" + item.addTime.ToString("yyyyMMddhhmmss") + ".html";
            }
            item.is_tj = 0;
            item.is_hot = 0;
            item.ordernum = 0;
            item.add_userid = Convert.ToInt32((Session["loginUser"] as AdminUser).id);
            item.res_views = 0;
            item.areaid = 0;   
            item.sid = txtDesc.Text.Trim(); 
      
            item.releaseTime = DateTime.Now;
            item.author = lblIndexImg.Text;
            if (item.pageName == "")
            {
                this.lblError.Text = "请填写摘要信息";
                return;
            }
            if (id != 0)
            {
                item.id = id;
                int num = NewsService.Update(item);
                if (num > 0)
                {
                    Jscript.AlertAndRedirectJstr("修改成功", "location.href='infoList.aspx?typeId=" + typeId + "';");
                }
                else
                {
                    this.lblError.Text = "修改失败";
                }
            }
            else
            {
                int num = NewsService.Add(item);
                if (num > 0)
                {
                    Jscript.AlertAndRedirectJstr("添加成功", "location.href='infoList.aspx?typeId=" + typeId + "';");
                }
                else
                {
                    this.lblError.Text = "添加失败";
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
        /// 生成静态页
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filename"></param>
        /// <param name="pagecode"></param>
        private void DownURLToFile(string url, string filename, string pagecode)
        {
            try
            {
                Encoding encode = Encoding.GetEncoding(pagecode);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = 100000;
                this.NoFolderCreate(filename);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), encode);
                StreamWriter sw = new StreamWriter(Server.MapPath(filename), false, encode);
                sw.Write(sr.ReadToEnd());
                //清理当前缓存区域
                sw.Flush();
                sw.Close();
                sw.Dispose();
                sr.Close();
                sr.Dispose();

            }
            catch (Exception je)
            {
                //Response.Write("生成静态页错误:" + je.Message);
            }
        }
        
    }
}