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
    public partial class userActiveList : System.Web.UI.Page
    {
        Page_ZH sp = new Page_ZH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                sp.InitBindData(Repeater1, pager1, "ActiveInfo", "id", sear());
            }
        }
        /// <summary>
        /// 会员账号
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected string GetUserName(object userId) 
        {
            UserInfo user = UserInfoService.GetModel(Convert.ToInt32(userId));
            if(user != null)
            {
                return user.username;
            }
            return "系统管理员";
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
                Jscript.Alert("请选择要删除的记录！", this.Page);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (ActiveInfoService.Delete(Convert.ToInt32(arr[i])))
                {
                    num++;
                }
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功删除" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "ActiveInfo", "id", sear());
        }
        /// <summary>
        /// 批量审核未通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQxTj_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                Jscript.Alert("请选择要审核未通过的记录！", this.Page);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (ActiveInfoService.UpdateCheckInfo(Convert.ToInt32(arr[i]), 2) > 0)
                {
                    num++;
                }
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('审核未通过" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "ActiveInfo", "id", sear());
        }
        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTj_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                Jscript.Alert("请选择要审核的记录！", this.Page);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (ActiveInfoService.UpdateCheckInfo(Convert.ToInt32(arr[i]), 1) > 0)
                {
                    num++;
                }
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功审核" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "ActiveInfo", "id", sear());
        }
        
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            
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
                sb.Append(" and activeName like '%" + txtTitle.Text.Trim() + "%'");
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
            sp.InitBindData(Repeater1, pager1, "ActiveInfo", "id", sear());
        }
        
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            sp.InitBindData(Repeater1, pager1, "ActiveInfo", "id", sear());
        }        
    }
}