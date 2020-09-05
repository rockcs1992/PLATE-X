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
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.IO;
using System.Data.OleDb;

namespace CommonBussiness.admin
{
    public partial class userList : System.Web.UI.Page
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
                sp.InitBindData(Repeater1, pager1, "userInfo", "id", sear());
            }
        }
        /// <summary>
        /// 获取性别
        /// </summary>
        /// <param name="sharecount"></param>
        /// <returns></returns>
        protected string GetSex(object sharecount) 
        {
            int sex = Convert.ToInt32(sharecount);
            if(sex == 1)
            {
                return "男";
            }
            if(sex == 2)
            {
                return "女";
            }
            return "保密";
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
                if (UserInfoService.Delete(Convert.ToInt32(arr[i])) > 0)
                {
                    num++;
                }
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功删除" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "userInfo", "id", sear());
        }
        
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1 and infoType = 1");
           
            if (txtTimeFrom.Text.Trim() != "")
            {
                sb.Append(" and addTime >= '" + txtTimeFrom.Text.Trim() + "' ");
            }
            if (txtTimeEnd.Text.Trim() != "")
            {
                sb.Append(" and addTime <= '" + txtTimeEnd.Text.Trim() + " 23:59:59' ");
            }
            
            if (txtTitle.Text.Trim() != "")
            {                
                sb.Append(" and (relName like '%" + txtTitle.Text.Trim() + "%' or username like '%" + txtTitle.Text.Trim() + "%') ");
            }
            if (this.txtMobile.Text.Trim() != "")
            {
                sb.Append(" and (mobile like '%" + txtMobile.Text.Trim() + "%') ");
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
            sp.InitBindData(Repeater1, pager1, "userInfo", "id", sear());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            if (ids.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要导出的记录！');", true);
                return;
            }
            Response.Redirect("/Import.aspx?ids=" + ids.TrimEnd(','));
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            sp.InitBindData(Repeater1, pager1, "userInfo", "id", sear());
            this.pager1.PageSize = 100000;
            
        }
    }
}