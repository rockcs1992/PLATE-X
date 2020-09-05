using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Data;
using System.Text;
using CommonBussiness;
using System.IO;
namespace CommonBusiness.admin
{
    public partial class infoType : System.Web.UI.Page
    {
        Page_ZH sp = new Page_ZH();
        int typeId = CRequest.GetInt("typeId", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                BindData();
                sp.InitBindData(this.repInfo, pager1, "NewsType", "id", sear());
            }
        }
        /// <summary>
        /// 获取父类名称
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        protected string GetParentName(object pid) 
        {
            NewsType nt = NewsTypeService.GetModel(Convert.ToInt32(pid));
            if(nt != null)
            {
                return nt.name;
            }
            return "<span style='color:red;'>根分类</span>";
        }
        /// <summary>
        /// 获取父类名称
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        protected string GetParent(object parentId) 
        {
            NewsType nt = NewsTypeService.GetModel(Convert.ToInt32(parentId));
            if(nt != null && nt.parentId == 5)
            {
                return nt.name;
            }
            return "";
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            DataSet ds = NewsTypeService.GetList("parentId = 0");
            if(ds.Tables[0].Rows.Count > 0)
            {
                ddlParent.DataSource = ds;
                ddlParent.DataTextField = "name";
                ddlParent.DataValueField = "id";
                ddlParent.DataBind();
            }
            ddlParent.Items.Insert(0, new ListItem("请选择", "0"));
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
                NewsTypeService.Delete(id);
                sp.InitBindData(this.repInfo, pager1, "NewsType", "id", sear());
            }
            if (e.CommandName.Equals("mod"))
            {
                this.hidId.Value = e.CommandArgument.ToString();
                NewsType nt = NewsTypeService.GetModel(Convert.ToInt32(e.CommandArgument));
                if (nt != null)
                {
                    ddlParent.SelectedValue = nt.parentId.ToString();
                    txtTitle.Text = nt.name;
                    txtOrder.Text = nt.status.ToString();
                    lblImg.Text = nt.remark;
                }                           
            }
        }
       
        /// <summary>
        /// 获取选择的信息
        /// </summary>
        /// <returns></returns>
        private string selInfo()
        {
            string Id = "";//获取当前选中的ID                       
            for (int i = 0; i < this.repInfo.Items.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.repInfo.Items[i].FindControl("cbxAll");
                if (ckb.Checked)
                {
                    Id += (this.repInfo.Items[i].FindControl("lblId") as Label).Text + ",";
                }
            }
            return Id;

        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                Jscript.Alert("请选择要删除的记录！", this.Page);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (NewsTypeService.Delete(Convert.ToInt32(arr[i])) > 0)
                {
                    num++;
                }
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功删除" + num + "条记录！');", true);
            sp.InitBindData(this.repInfo, pager1, "NewsType", "id", sear());
        }
        
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            return sb.ToString();
        }
        
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            sp.InitBindData(this.repInfo, pager1, "NewsType", "id", sear());
        }
        
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
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
                    this.lblUrl.Text = spic;
                }
            }  
            if(txtOrder.Text.Trim() != "")
            {
                if(!RegExp.IsNumeric(txtOrder.Text.Trim()))
                {
                    lblError.Text = "顺序号输入有误！";
                    return;
                }
            }
            NewsType item = new NewsType();
            item.name = txtTitle.Text.Trim();
            if(item.name.Length == 0)
            {
                lblError.Text = "分类名称不能为空!";
                return;
            }
            item.parentId = Convert.ToInt32(ddlParent.SelectedValue);
            
            item.status = 0;
            if(txtOrder.Text.Trim() != "")
            {
                item.status = Convert.ToInt32(txtOrder.Text.Trim());
            }
            item.remark = lblUrl.Text;
            item.typedesc = "";
            item.pagename = "";
            string hidId = this.hidId.Value;
            if (hidId != "")
            {
                item.id = Convert.ToInt32(hidId);
                NewsTypeService.UpdateModel(item);
            }
            else
            {
                if (NewsTypeService.Exists(item))
                {
                    lblError.Text = "该分类以及存在";
                    return;
                }
                NewsTypeService.Add(item);
                txtTitle.Text = "";
                lblUrl.Text = "";
                txtOrder.Text = "";
            }
            this.hidId.Value = "";
            sp.InitBindData(this.repInfo, pager1, "NewsType", "id", sear());
        }
        
    }
}