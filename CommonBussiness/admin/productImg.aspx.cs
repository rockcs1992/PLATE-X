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
    public partial class productImg : System.Web.UI.Page
    {
        protected int productId = CRequest.GetInt("productId",0);
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
        /// 获取类型名称
        /// </summary>
        /// <param name="infoType"></param>
        /// <returns></returns>
        protected string GetTypeName(object infoType) 
        {
            int type = Convert.ToInt32(infoType);
            if(type == 1)
            {
                return "移动端Banner";
            }
            if (type == 2)
            {
                return "移动端证书";
            }
            if (type == 3)
            {
                return "成长阶段";
            }
            if (type == 4)
            {
                return "移动端产品展示图";
            }
            return "";
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadData() 
        {
            DataSet ds = ProductImgMobileService.GetList("productId = " + productId);
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
            ProductImgMobile item = new ProductImgMobile();
            item.typeId = Convert.ToInt32(ddlType.SelectedValue);
            item.typeName = txtLinkUrl.Text.Trim();
            if(item.typeId == 1)
            {
                item.typeName = "移动端Banner";
            }
            if(item.typeId == 2)
            {
                item.typeName = "移动端证书";
            }
            if (item.typeId == 3)
            {
                item.typeName = "成长阶段";
            }
            if (item.typeId == 4)
            {
                item.typeName = "移动端产品展示图";
            }
            item.productId = productId;
            item.orderNum = 0;
            item.imgUrl = lblURL1.Text;
            item.status = 0;
            if(cboYes.Checked)
            {
                item.status = 1;
            }
            item.remark = content1.Value ;
            item.addTime = DateTime.Now;
            item.addUser = 0;
            
            AdminUser au = Session["loginUser"] as AdminUser;
            if(au != null)
            {
                item.addUser = au.id;
            }
            item.infoType = Convert.ToInt32(ddlType.SelectedValue);
            if (lblId.Text != "")
            {
                item.id = Convert.ToInt32(lblId.Text.Trim());
                ProductImgMobileService.Update(item);
            }
            else
            {
                int num = ProductImgMobileService.Add(item);                
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
                ProductImgMobile item = ProductImgMobileService.GetModel(id);
                if(item != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(item.imgUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath(item.imgUrl));
                    }
                }

                ProductImgMobileService.Delete(id);
                LoadData();
            }
            if(e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ProductImgMobile item = ProductImgMobileService.GetModel(id);
                if(item != null)
                {
                    ddlType.SelectedValue = item.infoType.ToString();
                    txtLinkUrl.Text = item.typeName;
                    content1.Value = item.remark;
                    lblURL1.Text = item.imgUrl;
                    if (item.status == 1)
                    {
                        cboYes.Checked = true;
                    }
                    else
                    { 
                        cboYes.Checked = false;
                    }
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
            txtLinkUrl.Text = "";
            lblURL1.Text = "";
            lblId.Text = "";
            lblError.Text = "";


        }

    }
}