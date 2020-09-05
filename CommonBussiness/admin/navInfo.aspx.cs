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

namespace CommonBussiness.admin
{
    public partial class navInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                LoadData();
            }
        }
        private void LoadData() 
        {
            DataSet ds = NavInfoService.GetList("");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.repInfo.DataSource = ds;
                repInfo.DataBind();
            }
        }
        /// <summary>
        /// 文件上传
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
        /// 添加友情连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string title2 = txtTitle2.Text.Trim();
            string contentTitle = txtContentTitle.Text.Trim();
           
            string url = this.txtLinkUrl.Text.Trim();
            string spic = "";
            if (this.FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                if (!Directory.Exists(Server.MapPath(Global_Upload.FriendImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.FriendImgPath));//创建目录
                }
                spic = DoClass.UploadFile(FileUpload1.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.FriendImgPath);

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
                    spic = Global_Upload.FriendImgPath + spic;
                    ViewState["newsImg1"] = spic;
                    lblURL1.Text = spic;
                }
            }

            NavInfo item = new NavInfo();
            item.indexTitle = title;
            item.indexTitle2 = title2;
            item.linkurl = url;
            item.indexImg = "";
           
            if (ViewState["newsImg1"] != null || lblURL1.Text != "")
            {
                item.indexImg = lblURL1.Text;
            }
            else 
            {
                lblError.Text = "请上传图片";
                return;
            }
            item.title = contentTitle;
            item.infoDesc = content1.Value.Trim();
            item.infoRemark = "";
            
            item.addTime = DateTime.Now;
            item.status = 0;
            item.remark = "";

            item.infoType = 0;
            item.addUser = 0;
            AdminUser au = Session["loginUser"] as AdminUser;
            if(au != null)
            {
                item.addUser = au.id;
            }
            if (lblId.Text != "")
            {
                item.id = Convert.ToInt32(lblId.Text.Trim());
                NavInfoService.Update(item);
            }
            else
            {
                int num = NavInfoService.Add(item);                
            }
            pnlAdd.Visible = false;
            pnlList.Visible = true;
            LoadData();
        }
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        protected void repInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                NavInfo item = NavInfoService.GetModel(id);
                if(item != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(item.indexImg)))
                    {
                        System.IO.File.Delete(Server.MapPath(item.indexImg));
                    }
                }
                NavInfoService.Delete(id);
                LoadData();
            }
            if(e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                NavInfo item = NavInfoService.GetModel(id);
                if(item != null)
                {
                  
                    txtTitle.Text = item.indexTitle;
                    
                    txtContentTitle.Text = item.title;
                    txtTitle2.Text = item.indexTitle2;

                    lblURL1.Text = item.indexImg;
                    txtLinkUrl.Text = item.linkurl;
                    this.content1.Value = item.infoDesc;

                    lblId.Text = item.id.ToString() ;
                    this.pnlAdd.Visible = true;
                    pnlList.Visible = false;
                }

            }
            
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.pnlAdd.Visible = true;
            pnlList.Visible = false;
            content1.Value = "";

            txtTitle.Text = "";
            txtLinkUrl.Text = "";
            lblURL1.Text = "";

            txtTitle2.Text = "";
            txtContentTitle.Text = "";
            lblId.Text = "";
            lblError.Text = "";


        }

    }
}