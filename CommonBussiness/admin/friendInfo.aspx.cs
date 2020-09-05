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
    public partial class friendInfo : System.Web.UI.Page
    {
        protected int typeId = CRequest.GetInt("typeId",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                if(typeId != 0)
                {
                    ViewState["typeId"] = typeId;
                }
                LoadData();
            }
        }
        private void LoadData() 
        {
            if (ViewState["typeId"] != null)
            {
                DataSet ds = FriendsInfoService.GetList("infoType = " + ViewState["typeId"]);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.repInfo.DataSource = ds;
                    repInfo.DataBind();
                }
                else
                {
                    this.repInfo.DataSource = null;
                    repInfo.DataBind();
                }
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
            string alt = this.txtAlt.Text.Trim();
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
            if (this.FileUpload2.PostedFile != null && FileUpload2.PostedFile.FileName != "")
            {
                if (!Directory.Exists(Server.MapPath(Global_Upload.FriendImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.FriendImgPath));//创建目录
                }
                spic = DoClass.UploadFile(FileUpload2.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.FriendImgPath);

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
                    ViewState["img2Name"] = spic;
                    spic = Global_Upload.FriendImgPath + spic;
                    ViewState["newsImg2"] = spic;
                    lblURL2.Text = spic;
                }
            }
            FriendsInfo item = new FriendsInfo();
            item.title = title;
            item.alt = alt;
            item.linkurl = url;
            item.img1path = "";
            item.img2Path = "";
            if (ViewState["newsImg1"] != null || lblURL1.Text != "")
            {
                item.img1path = lblURL1.Text;
            }
            else 
            {
                lblError.Text = "请上传图片1";
                return;
            }
            
            item.addTime = DateTime.Now;
            item.status = 0;
            item.infoType = 0;
            if (ViewState["typeId"] != null)
            {
                item.infoType = Convert.ToInt32(ViewState["typeId"]);
            }
            item.orderNum = 0;
            if(txtOrder.Text.Trim() != "")
            {
                if(RegExp.IsNumeric(txtOrder.Text.Trim()))
                {
                    item.orderNum = Convert.ToInt32(txtOrder.Text.Trim());
                }
            }
            item.addUser = 0;
            AdminUser au = Session["loginUser"] as AdminUser;
            if(au != null)
            {
                item.addUser = au.id;
            }
            if (lblId.Text != "")
            {
                item.id = Convert.ToInt32(lblId.Text.Trim());
                int num = FriendsInfoService.Update(item);
            }
            else
            {
                int num = FriendsInfoService.Add(item);                
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
                FriendsInfo item = FriendsInfoService.GetModel(id);
                if(item != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(item.img1path)))
                    {
                        System.IO.File.Delete(Server.MapPath(item.img1path));
                    }
                    if (System.IO.File.Exists(Server.MapPath(item.img2Path)))
                    {
                        System.IO.File.Delete(Server.MapPath(item.img2Path));
                    }     
                }

                FriendsInfoService.Delete(id);
                LoadData();
            }
            if(e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                FriendsInfo item = FriendsInfoService.GetModel(id);
                if(item != null)
                {
                    txtOrder.Text = item.orderNum.ToString();
                    txtLinkUrl.Text = item.linkurl;
                    txtAlt.Text = item.alt;
                    txtTitle.Text = item.title;
                    lblURL1.Text = item.img1path;
                    lblURL2.Text = item.img2Path;
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
            txtAlt.Text = "";
            txtTitle.Text = "";
            txtLinkUrl.Text = "";
            lblURL1.Text = "";
            lblURL2.Text = "";
            lblId.Text = "";
            lblError.Text = "";


        }

    }
}