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
    public partial class infoList : System.Web.UI.Page
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
                ViewState["typeId"] = typeId;
                sp.InitBindData(Repeater1, pager1, "news", "id", sear());
            }
        }
        /// <summary>
        /// 资讯类型
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        protected int GetType(object typeId)
        {
            NewsType nt = NewsTypeService.GetModel(Convert.ToInt32(typeId));
            if(nt.parentId == 69)
            {
                return nt.parentId;
            }
            nt = NewsTypeService.GetModel(nt.parentId);
            if(nt.parentId == 5)
            {
                return nt.parentId;
            }
            return Convert.ToInt32(typeId);
        }
        /// <summary>
        /// 置顶显示
        /// </summary>
        /// <param name="is_hot"></param>
        /// <returns></returns>
        protected string GetDone(object is_hot) 
        {
            if(is_hot.ToString() == "1")
            {
                return "取消";
            }
            return "热点";
        }
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("top"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                News item = NewsService.GetModel(id);
                if (item.is_hot == 0)
                {
                    NewsService.UpdateTop(id, 1);
                }
                else
                {
                    NewsService.UpdateTop(id, 0);
                }
                
            }
            sp.InitBindData(Repeater1, pager1, "news", "id", sear());
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ViewState["typeId"] != null)
            {
                if (ViewState["typeId"].ToString() == "5")
                {
                    Response.Redirect("otherInfo.aspx?typeId=" + ViewState["typeId"]);
                }
                else
                {
                    Response.Redirect("info.aspx?typeId=" + ViewState["typeId"]);
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
                if (NewsService.Delete(Convert.ToInt32(arr[i])) > 0)
                {
                    num++;
                }
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功删除" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "news", "id", sear());
        }
        /// <summary>
        /// 批量取消推荐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQxTj_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                Jscript.Alert("请选择要取消推荐的记录！", this.Page);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (NewsService.UpdateTj(Convert.ToInt32(arr[i]), 0) > 0)
                {
                    num++;
                }
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功取消推荐" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "news", "id", sear());
        }
        /// <summary>
        /// 批量推荐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTj_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                Jscript.Alert("请选择要推荐的记录！", this.Page);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (NewsService.UpdateTj(Convert.ToInt32(arr[i]),1) > 0)
                {
                    num++;
                }
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功推荐" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "news", "id", sear());
        }
        /// <summary>
        /// 类别
        /// </summary>
        /// <param name="newsType"></param>
        /// <returns></returns>
        protected string GetNewsTypeParent(object newsType,object id) 
        {
            //
            NewsType nt = NewsTypeService.GetModel(Convert.ToInt32(newsType));
            if(nt != null)
            {
                if (nt.parentId != 0)
                {
                    nt = NewsTypeService.GetModel(nt.parentId);
                    if (nt.parentId == 5)
                    {
                        return "otherInfo.aspx?typeId=5&id=" + id;
                    }
                    else
                    {
                        return "info.aspx?typeId=" + nt.parentId + "&id=" + id;
                    }
                    
                }
                else
                { 
                    if(nt.id == 1)
                    {
                        return "info.aspx?typeId=" + nt.id + "&id=" + id;
                    }
                }
            }
            return "";
        }
        /// <summary>
        /// 资讯类别名称
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        protected string GetNewsType(object typeId) 
        {
            NewsType item = NewsTypeService.GetModel(Convert.ToInt32(typeId));
            if (item != null)
            {
                return item.name;                
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 发布状态
        /// </summary>
        /// <param name="releaseTime"></param>
        /// <returns></returns>
        protected string GetReleaseStatus(object releaseTime,object ishot)
        {
            if (ishot.ToString() == "5")
            { 
                return "已屏蔽";
            }
            DateTime t = Convert.ToDateTime(releaseTime);
            if (t > DateTime.Now)
            {
                return "待发布";
            }
            else
            {
                return "已发布";
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
            if (typeId != 0)
            {
                sb.Append(" and newsType in(select id from NewsType where parentId = " + typeId + ")");                
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
                sb.Append(" and title like '%" + txtTitle.Text.Trim() + "%'");
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
            sp.InitBindData(Repeater1, pager1, "news", "id", sear());
        }
        
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            sp.InitBindData(Repeater1, pager1, "news", "id", sear());
        }
        /// <summary>
        /// 热门新闻设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetHot_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                Jscript.Alert("请选择要设置的记录！", this.Page);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (NewsService.UpdateOrderNum(Convert.ToInt32(arr[i])) > 0)
                {
                    num++;
                }
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功设置" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "news", "id", sear());
        }
    }
}