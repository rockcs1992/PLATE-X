using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
using DAL;
using System.Text;

namespace CommonBussiness
{
    public partial class shoper_product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                BindData();
            }
        }
        #region###页面标题、关键字和描述信息
        /// <summary>
        /// 页面标题、关键字和描述信息
        /// </summary>
        private void KeyWordBind()
        {
            string url = Request.Url.ToString().Replace("aspx", "html");

            KeyWordInfo km = KeyWordInfoService.GetModel(url);
            if (km != null)
            {
                ViewState["title"] = km.title;
                ViewState["keyword"] = km.keyword;
                ViewState["miaoshu"] = km.description;
            }
            else
            {
                ViewState["title"] = BaseConfigService.GetById(9);
                ViewState["keyword"] = BaseConfigService.GetById(23);
                ViewState["miaoshu"] = BaseConfigService.GetById(13);
            }
        }
        #endregion
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ProductService.Delete(id);
            }
            BindData();
        }
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetInfo(object productId) 
        {
            StringBuilder sb = new StringBuilder();
            Product item = ProductService.GetModel(Convert.ToInt32(productId));
            if(item != null)
            {
                sb.Append("<a href=\"/project_list_" + item.id + ".html\">");
                sb.Append("<s><img src=\"" + item.listImgUrl + "\" alt=\"" + item.proName + "\"></s>");
                sb.Append("<p>" + item.proName + "</p>");
                sb.Append("<h4>$<span>" + item.price1.ToString("0.00") + "</span>（" + item.unit1 + "）</h4>");
                sb.Append("</a>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                DataSet ds = ProductService.GetList("(addUser = " + user.id + " or useId = " + user.id + ")");
                if(ds.Tables[0].Rows.Count > 0)
                {
                    repProduct.DataSource = ds;
                    repProduct.DataBind();
                }
            }
            else
            {
                Response.Redirect("/register.html");
            }
        }
    }
}