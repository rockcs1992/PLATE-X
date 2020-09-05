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

namespace CommonBusiness.admin
{
    public partial class bannerInfo : System.Web.UI.Page
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
        /// <summary>
        /// 获取模块名称
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetModule(object status) 
        {
            //NewsType nt = NewsTypeService.GetModel(Convert.ToInt32(status));
            //if(nt != null)
            //{
            //    return nt.name;
            //}
            return "";
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadData() 
        {            
            DataSet ds = FriendsInfoService.GetList("infoType = 10");
            if(ds.Tables[0].Rows.Count > 0)
            {
                this.repInfo.DataSource = ds;
                repInfo.DataBind();
            }
           // 加载模块
            ds = NewsTypeService.GetList("parentId = 2");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlModule.DataSource = ds;
                ddlModule.DataTextField = "name";
                ddlModule.DataValueField = "id";
                ddlModule.DataBind();
            }
            ddlModule.Items.Insert(0, new ListItem("请选择", "0"));
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
                    lblURL.Text = spic;
                }
            }
            
            
            FriendsInfo item = new FriendsInfo();
            item.title = title;
            item.alt = txtTitleEn.Text.Trim();
            item.linkurl = url;
            item.img1path = "";
            item.img2Path = "";
            if (ViewState["newsImg1"] != null || lblURL.Text != "")
            {
                item.img1path = lblURL.Text;
            }
            else 
            {
                lblError.Text = "请上传图片";               
                return;
            }
            
            item.addTime = DateTime.Now;
            item.status = Convert.ToInt32(ddlModule.SelectedValue);
            //if(item.status == 0)
            //{
            //    lblError.Text = "请选择分类模块";
            //    return;
            //}
            item.infoType = 10;
            item.orderNum = 0;
            if(txtOrder.Text.Trim() != "")
            {
                if (!RegExp.IsNumeric(txtOrder.Text.Trim()))
                {
                    lblError.Text = "顺序号输入有误！";
                    return;
                }
                else
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
            this.pnlList.Visible = true;
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

                if (item != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(item.img1path)))
                    {
                        System.IO.File.Delete(Server.MapPath(item.img1path));
                    }
                }
                int num = FriendsInfoService.Delete(id);                
            }
            if (e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                FriendsInfo item = FriendsInfoService.GetModel(id);
                txtTitleEn.Text = item.alt;
                txtLinkUrl.Text = item.linkurl;
                txtTitle.Text = item.title;
                lblURL.Text = item.img1path;
                lblURL2.Text = item.img2Path;
                txtOrder.Text = item.orderNum.ToString();
                //ddlModule.SelectedValue = item.status.ToString();
                lblId.Text = id.ToString();
                this.pnlAdd.Visible = true;
                this.pnlList.Visible = false;
            }
            LoadData();
        }
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.pnlAdd.Visible = true;
            pnlList.Visible = false;
            txtTitleEn.Text = "";
            txtLinkUrl.Text = "";
            txtTitle.Text = "";
            lblURL.Text = "";
            lblId.Text = "";
            lblError.Text = "";
            txtOrder.Text = "";
        }
    }
}