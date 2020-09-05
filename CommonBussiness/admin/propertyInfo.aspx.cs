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

namespace CommonBussiness.admin
{
    public partial class propertyInfo : System.Web.UI.Page
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
                sp.InitBindData(repInfo, pager1, "ProperType", "id", sear());
            }
        }
        /// <summary>
        /// 父级属性名称
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="properName"></param>
        /// <returns></returns>
        protected string GetParentName(object pid,object properName) 
        {
            int parentId = Convert.ToInt32(pid);
            if (parentId != 0)
            {
                ProperType item = ProperTypeService.GetModel(parentId);
                if(item != null)
                {
                    return item.properName;
                }
                return "";
            }
            else
            {
                return "顶级";
            }
        }

        /// <summary>
        /// 产品类别名称
        /// </summary>
        /// <returns></returns>
        protected string GetProductName(object productTypeId) 
        {
            ProductType item = ProductTypeService.GetModel(Convert.ToInt32(productTypeId));
            if(item != null)
            {
                return item.typeName;
            }
            return "";
        }
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if(ddlSelProductType.SelectedValue != "0")
            {
                sb.Append(" and infoType = " + ddlSelProductType.SelectedValue);
            }
            if(ddlSelOne.SelectedValue != "0")
            {
                sb.Append(" and parentId = " + ddlSelOne.SelectedValue);
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
            sp.InitBindData(repInfo, pager1, "ProperType", "id", sear());
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
            //产品类别下拉框
            DataSet ds = ProductTypeService.GetList("typeValue = 0");
            if(ds.Tables[0].Rows.Count > 0)
            {
                ddlProductType.DataSource = ds;
                ddlProductType.DataTextField = "typeName";
                ddlProductType.DataValueField = "id";
                ddlProductType.DataBind();

                ddlSelProductType.DataSource = ds;
                ddlSelProductType.DataTextField = "typeName";
                ddlSelProductType.DataValueField = "id";
                ddlSelProductType.DataBind();
            }
            ddlSelProductType.Items.Insert(0, new ListItem("请选择", "0"));
            ddlSelOne.Items.Insert(0, new ListItem("请选择", "0"));
            ddlProductType.Items.Insert(0, new ListItem("请选择", "0"));
            ddlOne.Items.Insert(0,new ListItem("请选择","0"));
        }
        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string properName = this.txtPropertyName.Text.Trim();
            string productType = ddlProductType.SelectedValue;
            if(productType == "0")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择产品类型!');", true);
                return;
            }
            if (properName.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('属性名称不能为空!');", true);
                return;
            }
            string parentId = ddlOne.SelectedValue;

            ProperType item = new ProperType();
            item.infoType = Convert.ToInt32(productType);
            item.properName = properName;
            item.properValue = "";
            item.parentId = Convert.ToInt32(parentId);
            
            item.status = 0;
            if(cboTj.Checked)
            {
                item.status = 1;
            }
            item.remark = "";

            item.addTime = DateTime.Now;

            if (Session["loginUser"] == null)
            {
                Response.Redirect("/admin/login.aspx");
                return;
            }
            AdminUser admin = Session["loginUser"] as AdminUser;
            item.addUser = admin.id;
            if (ViewState["modId"] != null)
            {
                item.id = Convert.ToInt32(ViewState["modId"]);
                ProperTypeService.Update(item);
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');location.href='propertyInfo.aspx'", true);
            }
            else
            { 
                int num = ProperTypeService.Add(item);
            }
            
            sp.InitBindData(repInfo, pager1, "ProperType", "id", sear());
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');", true);
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
                ProperTypeService.Delete(id);
                sp.InitBindData(repInfo, pager1, "ProperType", "id", sear());
            }
            if(e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ProperType item = ProperTypeService.GetModel(id);
                if(item != null)
                {        
                    this.ddlProductType.SelectedValue = item.infoType.ToString();           
                    if (item.parentId == 0)
                    {                        
                        txtPropertyName.Text = item.properName;
                    }
                    else
                    {
                        DataSet ds = ProperTypeService.GetList("parentId = 0 and infoType = " + item.infoType);
                        ddlOne.Items.Clear();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddlOne.DataSource = ds;
                            ddlOne.DataTextField = "properName";
                            ddlOne.DataValueField = "id";
                            ddlOne.DataBind();
                        }
                        ddlOne.Items.Insert(0, new ListItem("请选择", "0"));
            
                        ddlOne.SelectedValue = item.parentId.ToString();
                        txtPropertyName.Text = item.properName;
                        if (item.status == 1)
                        {
                            cboTj.Checked = true;
                        }
                        else
                        {
                            cboTj.Checked = false;
                        }
                    }
                }
                ViewState["modId"] = id;
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "overKeyWordDiv();", true);
                
            }
        }
        /// <summary>
        /// 产品类型下拉事件更新一级属性信息----------查询用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSelProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productType = Convert.ToInt32(ddlSelProductType.SelectedValue);
            //产品一级属性下拉框
            DataSet ds = ProperTypeService.GetList("parentId = 0 and infoType = " + productType);
            ddlSelOne.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSelOne.DataSource = ds;
                ddlSelOne.DataTextField = "properName";
                ddlSelOne.DataValueField = "id";
                ddlSelOne.DataBind();
            }
            ddlSelOne.Items.Insert(0, new ListItem("请选择", "0"));

        }
        /// <summary>
        /// 产品类型下拉事件更新一级属性信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productType = Convert.ToInt32(ddlProductType.SelectedValue);
            //产品一级属性下拉框
            DataSet ds = ProperTypeService.GetList("parentId = 0 and infoType = " + productType);
            ddlOne.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlOne.DataSource = ds;
                ddlOne.DataTextField = "properName";
                ddlOne.DataValueField = "id";
                ddlOne.DataBind();
            }
            ddlOne.Items.Insert(0, new ListItem("请选择", "0"));
            
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            sp.InitBindData(repInfo, pager1, "ProperType", "id", sear());
        }


        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("propertyInfo.aspx");
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
                if (ProperTypeService.UpdateStatus(Convert.ToInt32(arr[i]),1) > 0)
                {
                    num++;
                }
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功设置" + num + "条记录！');", true);
            sp.InitBindData(repInfo, pager1, "ProperType", "id", sear());
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
                if (ProperTypeService.UpdateStatus(Convert.ToInt32(arr[i]), 0) > 0)
                {
                    num++;
                }
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功设置" + num + "条记录！');", true);
            sp.InitBindData(repInfo, pager1, "ProperType", "id", sear());
        }

    }
}