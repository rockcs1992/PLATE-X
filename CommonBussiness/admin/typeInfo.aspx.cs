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
namespace CommonBusiness.admin
{
    public partial class typeInfo : System.Web.UI.Page
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
                sp.InitBindData(this.repInfo, pager1, "TypeInfo", "id", sear());
            }
        }
        /// <summary>
        /// 父类名称
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        protected string GetParent(object parentId)
        {
            int typeId = Convert.ToInt32(parentId);
            switch(typeId)
            {
                case 1: return "产品品牌";
                case 2: return "安心度";
                case 3: return "烹饪方式";
                case 4: return "其他";
                case 5: return "其他";
                case 6: return "其他";
                case 7: return "其他";
                case 8: return "其他";
                case 9: return "其他";
                case 10: return "其他";
                case 11: return "其他";
                case 12: return "其他";
                default: return "";
            }
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
                TypeInfoService.Delete(id);
                sp.InitBindData(this.repInfo, pager1, "TypeInfo", "id", sear());
            }
            if (e.CommandName.Equals("mod"))
            {
                Label lblName = e.Item.FindControl("lblName") as Label;
                lblName.Visible = false;
                TextBox txtName = e.Item.FindControl("txtModName") as TextBox;
                txtName.Visible = true;
                LinkButton lbtnMod = e.Item.FindControl("lbtnMod") as LinkButton;
                lbtnMod.Visible = false;
                LinkButton lbtnSave = e.Item.FindControl("lbtnSave") as LinkButton;
                lbtnSave.Visible = true;
                this.hidId.Value = e.CommandArgument.ToString();                
            }
               if(e.CommandName.Equals("save"))
               {
                   TextBox txtName = e.Item.FindControl("txtModName") as TextBox;
                   string name = txtName.Text.Trim();
                   if(name.Length == 0)
                   {
                       ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('名称不能为空！');", true);
                       return;
                   }
                   TypeInfo nt = TypeInfoService.GetModel(Convert.ToInt32(hidId.Value));
                   if(nt != null)
                   {
                       nt.typeName = name;
                       nt.id = Convert.ToInt32(e.CommandArgument);
                       if (TypeInfoService.Exists(nt))
                       {
                           ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('名称已经存在！');", true);
                           sp.InitBindData(this.repInfo, pager1, "TypeInfo", "id", sear());
                           return;
                       }
                       TypeInfoService.Update(nt.id, nt.typeName);
                   }
                   sp.InitBindData(this.repInfo, pager1, "TypeInfo", "id", sear());
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
            sp.InitBindData(this.repInfo, pager1, "TypeInfo", "id", sear());
        }
        
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (typeId != 0)
            {
                sb.Append("1=1 and infoType = " + typeId);
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
            sp.InitBindData(this.repInfo, pager1, "TypeInfo", "id", sear());
        }
        
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            TypeInfo item = new TypeInfo();
            
            if(ddlParent.SelectedValue == "0")
            {
                lblError.Text = "请选择大类!";
                return;
                
            }
            item.infoType = Convert.ToInt32(ddlParent.SelectedValue);

            if(this.txtTitle.Text.Trim().Length == 0)
            {
                lblError.Text = "分类名称不能为空!";
                return;
            }
            item.typeName = txtTitle.Text.Trim();
            item.typeValue = 0;
            item.remark = "";            
            item.status = 1;
            item.remark = "";
            item.addTime = DateTime.Now;
            item.addUser = 0;
            if (Session["loginUser"] != null)
            {
                item.addUser = (Session["loginUser"] as AdminUser).id;
            }
            string hidId = this.hidId.Value;
            if (TypeInfoService.Exists(item))
            {
                lblError.Text = "该分类以及存在";
                return;
            }
            TypeInfoService.Add(item);
            txtTitle.Text = "";
            sp.InitBindData(this.repInfo, pager1, "TypeInfo", "id", sear());
        }
        
    }
}