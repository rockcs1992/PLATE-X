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

namespace CommonBussiness.admin
{
    public partial class productType : System.Web.UI.Page
    {
        Page_ZH sp = new Page_ZH();
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
                sp.InitBindData(repInfo, this.pager1, "ProductType", "id", sear());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetName(object id)
        {
            ProductType pt = ProductTypeService.GetModel(Convert.ToInt32(id));
            if(pt != null)
            {
                return pt.typeName;
            }
            return "";
        }
        /// <summary>
        /// 图片
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        protected string GetImg(object imgUrl) 
        {
            if(imgUrl.ToString().Trim() != "")
            {
                return "<img src=\"" + imgUrl + "\" style=\"width:100px; height:100px;\" />";
            }
            return "";
        }
        /// <summary>
        /// 父类名称
        /// </summary>
        /// <param name="typeValue"></param>
        /// <returns></returns>
        protected string GetParentName(object typeValue) 
        {
            int type = Convert.ToInt32(typeValue);
            if(type == 0)
            {
                return "根分类";
            }
            
            ProductType item = ProductTypeService.GetModel(type);
            if(item != null)
            {
                return item.typeName;
            }
            return "";
        }
        /// <summary>
        /// 添加人姓名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected string GetUserName(object userId)
        {
            AdminUser au = AdminUserService.GetModel(Convert.ToInt32(userId));
            if(au != null)
            {
                return au.realName;
            }
            return "";
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData() 
        {
            //一级类别
            DataSet ds = ProductTypeService.GetList("parentId = 0");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.ddlOne.DataSource = ds;
                ddlOne.DataTextField = "typeName";
                ddlOne.DataValueField = "id";
                ddlOne.DataBind();

                ddlSelProductType.DataSource = ds;
                ddlSelProductType.DataTextField = "typeName";
                ddlSelProductType.DataValueField = "id";
                ddlSelProductType.DataBind();
            }
            ddlOne.Items.Insert(0, new ListItem("请选择", "0"));
            ddlSelProductType.Items.Insert(0, new ListItem("请选择", "0"));
            ddlSelTwo.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlSelThree.Items.Insert(0, new ListItem("请选择", "0"));

            ddlTwo.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlThree.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlFour.Items.Insert(0, new ListItem("请选择", "0"));
        }
        /// <summary>
        /// 取消新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("productType.aspx");
        }
        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string typename = this.txtTypeName.Text.Trim();            
            if (typename.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('类型名称不能为空!');", true);
                return;
            }
            ProductType item = new ProductType();
            
            item.typeName = typename;

            item.parentId = 0;
            item.oneId = Convert.ToInt32(ddlOne.SelectedValue);
            item.oneName = ddlOne.SelectedItem.Text;
            if(item.oneId != 0)
            {
                item.parentId = item.oneId;
            }
            item.twoId = Convert.ToInt32(ddlTwo.SelectedValue);
            item.twoName = ddlTwo.SelectedValue;
            if(item.twoId != 0)
            {
                item.parentId = item.twoId;
            }
            item.threeId = Convert.ToInt32(ddlThree.SelectedValue);
            item.threeName = ddlThree.SelectedItem.Text;
            if(item.threeId != 0)
            {
                item.parentId = item.threeId;
            }
            item.fourId = Convert.ToInt32(ddlFour.SelectedValue);
            item.fourName = ddlFour.SelectedItem.Text;
            if(item.fourId != 0)
            {
                item.parentId = item.fourId;
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
                    this.lblUrl.Text = spic;
                }
            }
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
                    this.lblUrl2.Text = spic;
                }
            }
            if (this.FileUpload3.PostedFile != null && FileUpload3.PostedFile.FileName != "")
            {
                if (!Directory.Exists(Server.MapPath(Global_Upload.NewsImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.NewsImgPath));//创建目录
                }
                spic = DoClass.UploadFile(FileUpload3.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.NewsImgPath);

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
                    this.lblUrl3.Text = spic;
                }
            }  
            item.imgUrl = lblUrl.Text;
            item.diaryImg = lblUrl2.Text;
            item.typeContent = "";
            item.typeDesc = txtNameEn.Text.Trim();
            
            item.status = 0;
            
            item.remark = lblUrl3.Text.Trim();
            item.addTime = DateTime.Now;

            if (Session["loginUser"] == null)
            {
                Response.Redirect("/admin/login.aspx");
                return;
            }
            AdminUser admin = Session["loginUser"] as AdminUser;

            item.addUser = admin.id;
            item.infoType = 0;

            if (ViewState["mod"] != null)
            {
                item.id = Convert.ToInt32(ViewState["mod"]);
                ProductTypeService.Update(item);
            }
            else
            {
                int num = ProductTypeService.Add(item);
            }
            ViewState["mod"] = null;
            txtTypeName.Text = "";
            txtNameEn.Text = "";
            sp.InitBindData(repInfo, this.pager1, "ProductType", "id", sear());
        }
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("del"))
            {                
                ProductTypeService.Delete(id);
                sp.InitBindData(repInfo, this.pager1, "ProductType", "id", sear());
            }
            if(e.CommandName.Equals("mod"))
            {
                ProductType item = ProductTypeService.GetModel(id);
                if(item != null)
                {

                    this.txtTypeName.Text = item.typeName;
                    ddlOne.SelectedValue = item.oneId.ToString();
                    ddlTwo.Items.Clear();
                    DataSet ds = ProductTypeService.GetList("parentId = " + ddlOne.SelectedValue);
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        ddlTwo.DataSource = ds;
                        ddlTwo.DataTextField = "typeName";
                        ddlTwo.DataValueField = "id";
                        ddlTwo.DataBind();
                    }
                    ddlTwo.Items.Insert(0,new ListItem("请选择","0"));
                    ddlTwo.SelectedValue = item.twoId.ToString();

                    ddlThree.Items.Clear();
                    ds = ProductTypeService.GetList("parentId = " + ddlTwo.SelectedValue);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlThree.DataSource = ds;
                        ddlThree.DataTextField = "typeName";
                        ddlThree.DataValueField = "id";
                        ddlThree.DataBind();
                    }
                    ddlThree.Items.Insert(0, new ListItem("请选择", "0"));
                    ddlThree.SelectedValue = item.threeId.ToString();
                    if(item.imgUrl != "")
                    {
                         lblUrl.Text = item.imgUrl;
                         Button6.Visible = true;
                    }
                    lblUrl2.Text = item.diaryImg;
                    ViewState["mod"] = id;
                    lblUrl3.Text = item.remark;
                    txtNameEn.Text = item.typeDesc;
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "overKeyWordDiv();", true);
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
        /// 推荐所选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要推荐的记录！');", true);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                //if (ProductTypeService.UpdateStatus(Convert.ToInt32(arr[i]), 1) > 0)
                //{
                //    num++;
                //}
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功设置" + num + "条记录！');", true);
            sp.InitBindData(repInfo, pager1, "ProductType", "id", sear());
        }

        /// <summary>
        /// 取消推荐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要取消推荐的记录！');", true);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                //if (ProductTypeService.UpdateStatus(Convert.ToInt32(arr[i]), 0) > 0)
                //{
                //    num++;
                //}
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功设置" + num + "条记录！');", true);
            sp.InitBindData(repInfo,this.pager1, "ProductType", "id", sear());
        }
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (ddlSelProductType.SelectedValue != "0")
            {
                sb.Append(" and oneId = " + ddlSelProductType.SelectedValue);
            }
            if(ddlSelTwo.SelectedValue != "0")
            {
                sb.Append(" and twoId = " + ddlSelTwo.SelectedValue);
            }
            if(ddlThree.SelectedValue != "0")
            {
                sb.Append(" and threeId = " + ddlSelThree.SelectedValue);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            sp.InitBindData(repInfo, this.pager1, "ProductType", "id", sear());
        }
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            sp.InitBindData(repInfo, this.pager1, "ProductType", "id", sear());
        }

        protected void ddlOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTwo.Items.Clear();
            DataSet ds = ProductTypeService.GetList("parentId = " + ddlOne.SelectedValue);
            if(ds.Tables[0].Rows.Count > 0)
            {
                ddlTwo.DataSource = ds;
                ddlTwo.DataTextField = "typeName";
                ddlTwo.DataValueField = "id";
                ddlTwo.DataBind();
            }
            ddlTwo.Items.Insert(0,new ListItem("请选择","0"));
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "overKeyWordDiv();", true);
        }
        protected void ddlTwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlThree.Items.Clear();
            DataSet ds = ProductTypeService.GetList("parentId = " + ddlTwo.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlThree.DataSource = ds;
                ddlThree.DataTextField = "typeName";
                ddlThree.DataValueField = "id";
                ddlThree.DataBind();
            }
            ddlThree.Items.Insert(0, new ListItem("请选择", "0"));
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "overKeyWordDiv();", true);
        }
        protected void ddlThree_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlFour.Items.Clear();
            DataSet ds = ProductTypeService.GetList("parentId = " + ddlThree.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlFour.DataSource = ds;
                ddlFour.DataTextField = "typeName";
                ddlFour.DataValueField = "id";
                ddlFour.DataBind();
            }
            ddlFour.Items.Insert(0, new ListItem("请选择", "0"));
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "overKeyWordDiv();", true);
        }
        /// <summary>
        /// 下拉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSelProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSelTwo.Items.Clear();
            DataSet ds = ProductTypeService.GetList("parentId = " + ddlSelProductType.SelectedValue);
            if(ds.Tables[0].Rows.Count > 0)
            {
                ddlSelTwo.DataSource = ds;
                ddlSelTwo.DataTextField = "typeName";
                ddlSelTwo.DataValueField = "id";
                ddlSelTwo.DataBind();
            }
            ddlSelTwo.Items.Insert(0,new ListItem("请选择","0"));
        }
        /// <summary>
        /// 下拉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSelTwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlSelThree.Items.Clear();
            DataSet ds = ProductTypeService.GetList("parentId = " + ddlSelTwo.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSelThree.DataSource = ds;
                ddlSelThree.DataTextField = "typeName";
                ddlSelThree.DataValueField = "id";
                ddlSelThree.DataBind();
            }
            ddlSelThree.Items.Insert(0, new ListItem("请选择", "0"));
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (ViewState["mod"] != null)
            {
                int id = Convert.ToInt32(ViewState["mod"]);
                if (System.IO.File.Exists(Server.MapPath(lblUrl.Text)))
                {
                    System.IO.File.Delete(Server.MapPath(lblUrl.Text));
                }

                if(ProductTypeService.DeleteTypeImg(id,1))
                {
                    Jscript.Alert("操作成功");
                }
            }
            sp.InitBindData(repInfo, this.pager1, "ProductType", "id", sear());
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button7_Click(object sender, EventArgs e)
        {
            if (ViewState["mod"] != null)
            {
                int id = Convert.ToInt32(ViewState["mod"]);
                if (System.IO.File.Exists(Server.MapPath(lblUrl2.Text)))
                {
                    System.IO.File.Delete(Server.MapPath(lblUrl2.Text));
                }

                if (ProductTypeService.DeleteTypeImg(id,2))
                {
                    Jscript.Alert("操作成功");
                }
            }
            sp.InitBindData(repInfo, this.pager1, "ProductType", "id", sear());
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button8_Click(object sender, EventArgs e)
        {
            if (ViewState["mod"] != null)
            {
                int id = Convert.ToInt32(ViewState["mod"]);
                if (System.IO.File.Exists(Server.MapPath(lblUrl3.Text)))
                {
                    System.IO.File.Delete(Server.MapPath(lblUrl3.Text));
                }

                if (ProductTypeService.DeleteTypeImg(id,3))
                {
                    Jscript.Alert("操作成功");
                }
            }
            sp.InitBindData(repInfo, this.pager1, "ProductType", "id", sear());
        }
        
    }
}