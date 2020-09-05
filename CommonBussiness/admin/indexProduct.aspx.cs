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
    public partial class indexProduct : System.Web.UI.Page
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
            DataSet ds = ProductTypeService.GetList(8, "parentId = 0", "id");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCate.DataSource = ds;
                ddlCate.DataTextField = "typeName";
                ddlCate.DataValueField = "id";
                ddlCate.DataBind();
            }
            ddlCate.Items.Insert(0,new ListItem("请选择","0"));

            ds = IndexProductService.GetList("");
            if(ds.Tables[0].Rows.Count > 0)
            {
                repInfo.DataSource = ds;
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
            string proDesc = this.txtTitle2.Text.Trim();
            string proPrice = this.txtPrice.Text.Trim();
            string unitDesc = txtUnit.Text.Trim();
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

            IndexProduct item = new IndexProduct();
            item.typeId = Convert.ToInt32(ddlCate.SelectedValue);
            item.typeName = ddlCate.SelectedItem.Text;
            item.proName = title;
            item.proDesc = proDesc;
            item.proPrice = 0;
            item.priceStr = proPrice;
            item.unitDesc = unitDesc;

            if (ViewState["newsImg1"] != null || lblURL1.Text != "")
            {
                item.imgUrl = lblURL1.Text;
            }
            else 
            {
                lblError.Text = "请上传图片";
                return;
            }
            item.status = 0;
            item.remark = url;
            item.addTime = DateTime.Now;         
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
                IndexProductService.Update(item);
            }
            else
            {
                int num = IndexProductService.Add(item);                
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
                IndexProductService.Delete(id);
                LoadData();
            }
            if(e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                IndexProduct item = IndexProductService.GetModel(id);
                if(item != null)
                {
                    ddlCate.SelectedValue = item.typeId.ToString();
                    txtTitle.Text = item.proName;

                    txtTitle2.Text = item.proDesc;
                    txtPrice.Text = item.priceStr;

                    lblURL1.Text = item.imgUrl;
                    txtLinkUrl.Text = item.remark;

                    txtUnit.Text = item.unitDesc;
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
            

            txtTitle.Text = "";
            txtLinkUrl.Text = "";
            lblURL1.Text = "";

            txtTitle2.Text = "";
            txtPrice.Text = "";


            txtUnit.Text = "";
            lblId.Text = "";
            lblError.Text = "";


        }

    }
}