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
    public partial class propertyValue : System.Web.UI.Page
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
                sp.InitBindData(repInfo, pager1, "ProperValue", "id", sear());
            }
        }
        /// <summary>
        /// 父级属性名称
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="properName"></param>
        /// <returns></returns>
        protected string GetName(object pid) 
        {
            ProperType item = ProperTypeService.GetModel(Convert.ToInt32(pid));
            if (item != null)
            {
                return item.properName;
            }
            return "";
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
            if(ddlSelTwo.SelectedValue != "0")
            {
                sb.Append(" and properId = " + ddlSelTwo.SelectedValue);
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
            sp.InitBindData(repInfo, pager1, "ProperValue", "id", sear());
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

            ddlSelTwo.Items.Insert(0, new ListItem("请选择", "0"));
            ddlTwo.Items.Insert(0, new ListItem("请选择", "0"));
        }
        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string properValue = this.txtPropertyValue.Text.Trim();
            string productType = ddlProductType.SelectedValue;
            string parentId = ddlOne.SelectedValue;
            string two = ddlTwo.SelectedValue;

            if(productType == "0" || parentId == "0" || two == "0")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择属性类型!');", true);
                return;
            }
            if (properValue.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('属性值不能为空!');", true);
                return;
            }

            ProperValue item = new ProperValue();
            item.infoType = Convert.ToInt32(productType);
            item.parentId = Convert.ToInt32(parentId);
            item.properId = Convert.ToInt32(two);
            item.properValue = properValue;
            

            item.status = 0;
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
                ProperValueService.Update(item);
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');location.href='propertyValue.aspx'", true);
            }
            else
            {
                int num = ProperValueService.Add(item);
            }

            sp.InitBindData(repInfo, pager1, "ProperValue", "id", sear());
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
                ProperValueService.Delete(id);
                sp.InitBindData(repInfo, pager1, "ProperValue", "id", sear());
            }
            if(e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ProperValue item = ProperValueService.GetModel(id);
                if(item != null)
                {
                    this.ddlProductType.SelectedValue = item.infoType.ToString();
                    //产品一级属性下拉框
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
                    if(item.parentId != 0)
                    {
                        ddlOne.SelectedValue = item.parentId.ToString();
                        ds = ProperTypeService.GetList("parentId = " + item.parentId);
                        ddlTwo.Items.Clear();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddlTwo.DataSource = ds;
                            ddlTwo.DataTextField = "properName";
                            ddlTwo.DataValueField = "id";
                            ddlTwo.DataBind();
                        }
                        ddlTwo.Items.Insert(0, new ListItem("请选择", "0"));
                        if(item.properId != 0)
                        {
                            ddlTwo.SelectedValue = item.properId.ToString();
                            txtPropertyValue.Text = item.properValue;
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
        /// 产品类型下拉事件更新一级属性信息----------查询用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSelOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(ddlSelOne.SelectedValue);
            //产品一级属性下拉框
            DataSet ds = ProperTypeService.GetList("parentId = " + pid);
            ddlSelTwo.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSelTwo.DataSource = ds;
                ddlSelTwo.DataTextField = "properName";
                ddlSelTwo.DataValueField = "id";
                ddlSelTwo.DataBind();
            }
            ddlSelTwo.Items.Insert(0, new ListItem("请选择", "0"));

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
        /// 一级属性下拉事件更新二级属性信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(ddlOne.SelectedValue);
            //产品一级属性下拉框
            DataSet ds = ProperTypeService.GetList("parentId = " + pid);
            ddlTwo.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlTwo.DataSource = ds;
                ddlTwo.DataTextField = "properName";
                ddlTwo.DataValueField = "id";
                ddlTwo.DataBind();
            }
            ddlTwo.Items.Insert(0, new ListItem("请选择", "0"));

        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            sp.InitBindData(repInfo, pager1, "ProperValue", "id", sear());
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("propertyValue.aspx");
        }
    }
}