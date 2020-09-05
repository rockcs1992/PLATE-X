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
    public partial class searchKeyword : System.Web.UI.Page
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
                sp.InitBindData(this.repInfo, pager1, "SearchKeyWord", "id", sear());
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
                SearchKeyWordService.Delete(id);
                sp.InitBindData(this.repInfo, pager1, "SearchKeyWord", "id", sear());
            }
            if (e.CommandName.Equals("mod"))
            {
                this.hidId.Value = e.CommandArgument.ToString();
                SearchKeyWord nt = SearchKeyWordService.GetModel(Convert.ToInt32(e.CommandArgument));
                if (nt != null)
                {
                    txtTitle.Text = nt.seaTitle;
                    txtOrderNum.Text = nt.status.ToString();
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
                if (SearchKeyWordService.Delete(Convert.ToInt32(arr[i])))
                {
                    num++;
                }
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功删除" + num + "条记录！');", true);
            sp.InitBindData(this.repInfo, pager1, "SearchKeyWord", "id", sear());
        }
        
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1 and infoType = 0");
            return sb.ToString();
        }
        
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            sp.InitBindData(this.repInfo, pager1, "SearchKeyWord", "id", sear());
        }
        
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            SearchKeyWord item = new SearchKeyWord();
            item.typeId = 0;
            item.typeName = "";
            item.seaTitle = txtTitle.Text.Trim();
            item.status = Convert.ToInt32(txtOrderNum.Text);

            item.remark = "";
            item.addTime = DateTime.Now;
            item.addUser = 0;
            AdminUser au = Session["loginUser"] as AdminUser;
            if(au != null)
            {
                item.addUser = au.id;
            }
            item.infoType = 0;

            string hidId = this.hidId.Value;
            if (hidId != "")
            {
                item.id = Convert.ToInt32(hidId);
                SearchKeyWordService.Update(item);
            }
            else
            {
                SearchKeyWordService.Add(item);
                txtTitle.Text = "";               
            }
            this.hidId.Value = "";
            sp.InitBindData(this.repInfo, pager1, "SearchKeyWord", "id", sear());
        }
        
    }
}