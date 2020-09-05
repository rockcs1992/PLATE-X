using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Data;

namespace CommonBussiness.admin
{
    public partial class manager : System.Web.UI.Page
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
                else
                {
                    AdminUser item = Session["loginUser"] as AdminUser;
                    if(item.roleId != 2)
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('无操作权限');window.location='/admin/basis.aspx';", true);
                        return;
                    }
                }
                LoadData();
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
        protected void Button2_Click(object sender, EventArgs e)
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
                if (AdminUserService.Delete(Convert.ToInt32(arr[i])) > 0)
                {
                    num++;
                }
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功删除" + num + "条记录！');", true);
            DataSet ds = AdminUserService.GetList("");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.repInfo.DataSource = ds;
                repInfo.DataBind();
            }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        protected string GetRoleName(object roleId)
        {
            int id = Convert.ToInt32(roleId);
            SysRole item = SysRoleService.GetSysRoleById(id);
            if (item != null)
            {
                return item.RoleName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            this.txtPass.Text = "";
            this.txtPassAgain.Text = "";
            this.txtRealName.Text = "";
            this.txtUserName.Text = "";
            //加载角色
            DataSet dsRole = SysRoleService.GetList("");
            if (dsRole.Tables[0].Rows.Count > 0)
            {
                this.ddlRole.DataSource = dsRole;
                ddlRole.DataTextField = "roleName";
                ddlRole.DataValueField = "id";
                ddlRole.DataBind();
            }
            ddlRole.Items.Insert(0, new ListItem("请选择","0"));
            if (Request.QueryString["useAdmin"] != null)
            {
                string useAdmin = Request.QueryString["useAdmin"];
                if (useAdmin == "1")
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('操作成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('操作失败!');", true);
                }
            }
            if (Request.QueryString["delAdmin"] != null)
            {
                string delAdmin = Request.QueryString["delAdmin"];
                if (delAdmin == "1")
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除失败!');", true);
                }
            }
            DataSet ds = AdminUserService.GetList("");
            if(ds.Tables[0].Rows.Count > 0)
            {
                this.repInfo.DataSource = ds;
                repInfo.DataBind();
            }
        }

        /// <summary>
        /// 添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = this.txtUserName.Text.Trim();
            string realName = this.txtRealName.Text.Trim();
            string pass = this.txtPass.Text.Trim();
            string md5Pass = encrypt.EncryptMd5(pass);
            int roleId = Convert.ToInt32(this.ddlRole.SelectedValue);
            AdminUser item = new AdminUser();
            item.username = username;
            item.realName = realName;
            item.password = pass;
            item.md5Pass = md5Pass;
            item.roleId = roleId;
            item.status = 1;
            item.remark = "";
            if (this.hidAdminId.Value != "")      //编辑
            {
                item.id = Convert.ToInt32(this.hidAdminId.Value);
                int num = AdminUserService.Update(item);
                if (num > 0)
                {
                    
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('更新成功!');location.href='manager.aspx'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('更新失败!');location.href='manager.aspx'", true);
                }
            }
            else
            {
                if (AdminUserService.Exists(item))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('用户已经存在，请更换!');location.href='manager.aspx'", true);
                    return;
                }
                int num = AdminUserService.Add(item);
                if (num > 0)
                {
                    
                    this.txtPass.Text = "";
                    this.txtPassAgain.Text = "";
                    this.txtRealName.Text = "";
                    this.txtUserName.Text = "";

                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('添加成功!');location.href='manager.aspx'", true);
                }
            }
            
        }
    }
}