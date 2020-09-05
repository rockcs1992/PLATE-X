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
    public partial class commentList : System.Web.UI.Page
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
                sp.InitBindData(Repeater1, pager1, "Comment", "id", sear());
            }
        }
        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="img2"></param>
        /// <param name="img3"></param>
        /// <param name="img4"></param>
        /// <returns></returns>
        protected string GetImg(object img1,object img2,object img3,object img4)
        {
            StringBuilder sb = new StringBuilder();
            if(img1.ToString() != "")
            {
                sb.Append("<img src='" + img1 + "' style='width:100px; height:100px;' />");
            }
            if (img2.ToString() != "")
            {
                sb.Append("<img src='" + img2 + "' style='width:100px; height:100px;' />");
            }
            if (img3.ToString() != "")
            {
                sb.Append("<img src='" + img3 + "' style='width:100px; height:100px;' />");
            }
            if (img4.ToString() != "")
            {
                sb.Append("<img src='" + img4 + "' style='width:100px; height:100px;' />");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 添加人
        /// </summary>
        /// <param name="addUser"></param>
        protected string GetAddUser(object addUser) 
        {
            UserInfo au = UserInfoService.GetModel(Convert.ToInt32(addUser));
            if (au != null)
            {
                if (au.relName != "")
                {
                    return au.relName;
                }
                else
                {
                    return au.mobile;  
                }
            }
            return "";
        }
        /// <summary>
        /// 评论对象标题
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        protected string GetObjTitle(object proid)
        {
            Product item = ProductService.GetModel(Convert.ToInt32(proid));
            if(item != null)
            {
                return item.proName;
            }
            return "";
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
                if (CommentService.Delete(Convert.ToInt32(arr[i])))
                {
                    num++;
                }
            }

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功删除" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "Comment", "id", sear());
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
                sb.Append(" and commentInfo like '%" + txtTitle.Text.Trim() + "%'");
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
            sp.InitBindData(Repeater1, pager1, "Comment", "id", sear());
        }
        
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            sp.InitBindData(Repeater1, pager1, "Comment", "id", sear());
        }
        
    }
}