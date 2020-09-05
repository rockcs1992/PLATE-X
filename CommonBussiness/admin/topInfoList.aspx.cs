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
    public partial class topInfoList : System.Web.UI.Page
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
                sp.InitBindData(Repeater1, pager1, "TopNews", "id", sear());
            }
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
            int newsId = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int id = Convert.ToInt32(arr[i]);
                newsId = TopNewsService.GetModel(id).newsId;
                if (TopNewsService.Delete(id) > 0)
                {
                    NewsService.UpdateTop(newsId,0);
                    num++;
                }
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功删除" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "TopNews", "id", sear());
        }
        
        /// <summary>
        /// 资讯类别名称
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        protected string GetNewsInfo(object typeId,int num) 
        {
            News item = NewsService.GetModel(Convert.ToInt32(typeId));
            if (item != null)
            {
                if (num == 1)
                {
                    return item.title;
                }
                else
                {
                    NewsType nt = NewsTypeService.GetModel(item.newsType);
                    if(nt != null)
                    {
                        return nt.name;
                    }
                    return "";
                }
                
            }
            else
            {
                return "";
            }
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
                sb.Append(" and releaseTime >= '" + txtTimeFrom.Text.Trim() + "' ");
            }
            if (txtTimeEnd.Text.Trim() != "")
            {
                sb.Append(" and releaseTime <= '" + txtTimeEnd.Text.Trim() + "' ");
            }
            
            if (txtKey.Text.Trim() != "")
            {
                sb.Append(" and (baseInfo like '%" + txtKey.Text.Trim() + "%' or newsId in (select id from news where title like '%" + txtKey.Text.Trim() + "%'))");
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
            sp.InitBindData(Repeater1, pager1, "TopNews", "id", sear());
        }
        
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            sp.InitBindData(Repeater1, pager1, "TopNews", "id", sear());
        }
        
    }
}