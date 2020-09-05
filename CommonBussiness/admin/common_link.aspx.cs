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
    public partial class common_link : System.Web.UI.Page
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
        /// 操作人
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        protected string GetUser(object userid) 
        {
            AdminUser user = AdminUserService.GetModel(Convert.ToInt32(userid));
            if(user != null)
            {
                return user.realName;
            }
            return "";
        }

        /// <summary>
        /// 链接图片的上传
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
                    }
                }
                #endregion
            }
           
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadData() 
        {
            DataSet ds = Common_LinksService.GetList("");
            if(ds.Tables[0].Rows.Count > 0)
            {
                this.repInfo.DataSource = ds;
                repInfo.DataBind();
            }
        }
        /// <summary>
        /// 添加友情连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.txtLinkName.Text.Trim();     
            string url = this.txtLinkUrl.Text.Trim();
            if(name.Length == 0 || url.Length == 0)
            {
                lblError.Text="各项不能为空";
                return;
            }
            Common_Links item = new Common_Links();
            item.linkPlace = Convert.ToInt32(ddlPlace.SelectedValue);
            item.linkType = Convert.ToInt32(ddlLinkType.SelectedValue);

            item.linkname = name;
            item.linktitle = "";
            item.linkurl = url;
            if (item.linkType == 2)
            {
                item.imgurl = lblImgWeiBo.Text.Trim();
            }
            else
            {
                item.imgurl = "";
            }
           
            item.is_target = 0;
            if(cboNewBlank.Checked)
            {
                item.is_target = 1;
            }

            item.isHot = 0;
            if(cboHot.Checked)
            {
                item.isHot = 1;
            }

            item.isTj = 0;
            if(cboTj.Checked)
            {
                item.isTj = 1;
            }
            item.orderNum = 0;
            item.remark = "";
            item.status = 0;
            item.infoType = 0;
            item.addTime = DateTime.Now;

            item.addUser = 0;
            AdminUser user = Session["loginUser"] as AdminUser;
            if(user != null)
            {
                item.addUser = user.id;
            }
            if (lblId.Text != "")
            {
                item.id = Convert.ToInt32(lblId.Text.Trim());
                int num = Common_LinksService.Update(item);
            }
            else
            {
                int num = Common_LinksService.Add(item);
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
            if (e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Common_LinksService.Delete(id);
                LoadData();
            }
            if (e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Common_Links item = Common_LinksService.GetModel(id);
                if(item != null)
                {
                    ddlLinkType.SelectedValue = item.linkType.ToString();
                    ddlPlace.SelectedValue = item.linkPlace.ToString();
                    lblImgWeiBo.Text = item.imgurl;
                    if (item.linkType == 2)
                    {
                        imgRow.Visible = true;
                    }
                    else
                    {
                        imgRow.Visible = false;
                    }
                    txtLinkUrl.Text = item.linkurl;
                    //txtLinkTitle.Text = item.linktitle;
                    txtLinkName.Text = item.linkname;
                    lblId.Text = item.id.ToString();
                    if (item.isTj == 1)
                    {
                        cboTj.Checked = true;
                    }
                    else
                    {
                        cboTj.Checked = false;
                    }

                    if (item.isHot == 1)
                    {
                        cboHot.Checked = true;
                    }
                    else
                    {
                        cboHot.Checked = false;
                    }

                    if (item.is_target == 1)
                    {
                        cboNewBlank.Checked = true;
                    }
                    else
                    {
                        cboNewBlank.Checked = false;
                    }
                    pnlAdd.Visible = true;
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
            pnlAdd.Visible = true;
            pnlList.Visible = false;
            txtLinkName.Text = "";
            //txtLinkTitle.Text = "";
            txtLinkUrl.Text = "";
            lblId.Text = "";
            lblError.Text = "";
        }
        /// <summary>
        /// 链接类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlLinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLinkType.SelectedValue.ToString() == "2")
            {
                imgRow.Visible = true;
            }
            else
            {
                imgRow.Visible = false;
            }
        }

    }
}