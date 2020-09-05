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

namespace CommonBussiness.admin
{
    public partial class productList : System.Web.UI.Page
    {
        Page_ZH sp = new Page_ZH();
        int userId = CRequest.GetInt("userId", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                if (userId != 0)
                {
                    ViewState["userId"] = userId;
                }
                DataSet ds = ProductTypeService.GetList("parentId = 0");
                if(ds.Tables[0].Rows.Count > 0)
                {
                    ddlProductType.DataSource = ds;
                    ddlProductType.DataTextField = "typeName";
                    ddlProductType.DataValueField = "id";
                    ddlProductType.DataBind();
                }
                ddlProductType.Items.Insert(0,new ListItem("请选择","0"));
                this.ddlSon.Items.Insert(0, new ListItem("请选择", "0"));

                sp.InitBindData(Repeater1, pager1, "Product", "id", sear());
            }
        }
        /// <summary>
        /// 获取商家名称
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected string GetShoper(object userId)
        {
            UserInfo user = UserInfoService.GetModel(Convert.ToInt32(userId));
            if(user != null)
            {
                return "<a href='productList.aspx?userId=" + user.id +"' title='" + user.mobile + "'>" + user.comName + "</a>";
            }
            return "";
        }
        /// <summary>
        /// 获取类型名称
        /// </summary>
        /// <param name="twoId"></param>
        /// <param name="threeId"></param>
        /// <returns></returns>
        protected string GetTypeName(object twoId,object threeId) 
        {
            return ProductTypeService.GetName(twoId) + "-" + ProductTypeService.GetName(threeId);
        }
        
        /// <summary>
        /// 获取选择的信息
        /// </summary>
        /// <returns></returns>
        private string selInfo()
        {
            string Id = "";//获取当前选中的ID                       
            for (int i = 0; i < this.Repeater1.Items.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.Repeater1.Items[i].FindControl("cbxAll");
                if (ckb.Checked)
                {
                    Id += (this.Repeater1.Items[i].FindControl("lblId") as Label).Text + ",";
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
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要删除的记录！');", true);               
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (ProductService.Delete(Convert.ToInt32(arr[i])))
                {
                    num++;
                }
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功删除" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "Product", "id", sear());
        }
             
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (ViewState["userId"] != null)
            {
                sb.Append(" and useId = " + ViewState["userId"]);
            }
            if (txtTimeFrom.Text.Trim() != "")
            {
                sb.Append(" and addTime >= '" + txtTimeFrom.Text.Trim() + "' ");
            }
            if (txtTimeEnd.Text.Trim() != "")
            {
                sb.Append(" and addTime <= '" + txtTimeEnd.Text.Trim() + "' ");
            }
            
            if (txtTitle.Text.Trim() != "")
            {
                sb.Append(" and (proName like '%" + txtTitle.Text.Trim() + "%')");
            }
            if (ddlStatus.SelectedValue != "100")
            {
                sb.Append(" and status = " + ddlStatus.SelectedValue);
            }
            if(ddlProductType.SelectedValue != "0")
            {
                sb.Append(" and oneId = " + ddlProductType.SelectedValue);
            }
            if(ddlSon.SelectedValue != "0")
            {
                sb.Append(" and twoId = " + ddlSon.SelectedValue);
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
            sp.InitBindData(Repeater1, pager1, "Product", "id", sear());
        }
        
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            sp.InitBindData(Repeater1, pager1, "Product", "id", sear());
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
                ProductService.Delete(id);
                sp.InitBindData(Repeater1, pager1, "Product", "id", sear());
            }
        }
        /// <summary>
        /// 推荐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTj_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要删除的记录！');", true);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (ProductService.UpdateTj(Convert.ToInt32(arr[i]), 1) > 0)
                {
                    num++;
                }
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功推荐" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "Product", "id", sear());
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要删除的记录！');", true);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (ProductService.UpdateTj(Convert.ToInt32(arr[i]), 0) > 0)
                {
                    num++;
                }
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('取消推荐" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "Product", "id", sear());
        }
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //string ids = selInfo();
            //int num = 0;
            //if (ids.Length == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要审核的记录！');", true);
            //    return;
            //}
            //string[] arr = ids.TrimEnd(',').Split(',');
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (ProductService.UpdateStatus(Convert.ToInt32(arr[i]), 1) > 0)
            //    {
            //        num++;
            //    }
            //}

            //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功审核" + num + "条记录！');", true);
            //sp.InitBindData(Repeater1, pager1, "Product", "id", sear());
        }
        /// <summary>
        /// 审核失败
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNO_Click(object sender, EventArgs e)
        {
            //string ids = selInfo();
            //int num = 0;
            //if (ids.Length == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要审核的记录！');", true);
            //    return;
            //}
            //string[] arr = ids.TrimEnd(',').Split(',');
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (ProductService.UpdateStatus(Convert.ToInt32(arr[i]), 2) > 0)
            //    {
            //        num++;
            //    }
            //}

            //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('审核失败" + num + "条记录！');", true);
            //sp.InitBindData(Repeater1, pager1, "Product", "id", sear());
        }
        /// <summary>
        /// 下拉菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSon.Items.Clear();
            DataSet ds = ProductTypeService.GetList("parentId = " + ddlProductType.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSon.DataSource = ds;
                ddlSon.DataTextField = "typeName";
                ddlSon.DataValueField = "id";
                ddlSon.DataBind();
            }
            ddlSon.Items.Insert(0,new ListItem("请选择","0"));
        }
    }
}