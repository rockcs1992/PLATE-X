using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using System.Text;
using Model;

namespace CommonBussiness
{
    public partial class project : System.Web.UI.Page
    {
        int oneId = CRequest.GetInt("oneId", 0);//$1&amp;twoId=$2&amp;threeId=$3&amp;fourId=$4&amp;varietyId=$5&amp;relieveId=$6&amp;cookId=$7&amp;otherId
        int twoId = CRequest.GetInt("twoId", 0);
        int threeId = CRequest.GetInt("threeId", 0);
        int fourId = CRequest.GetInt("fourId", 0);
        int varietyId = CRequest.GetInt("varietyId", 0);
        int relieveId = CRequest.GetInt("relieveId", 0);
        int cookId = CRequest.GetInt("cookId", 0);
        string keyword = CRequest.GetString("keyword");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                ViewState["stylePrice"] = "<span></span><s></s>";
                ViewState["styleCommit"] = "<span></span><s></s>";
                
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
        /// 获取Category
        /// </summary>
        /// <returns></returns>
        protected string GetCate() 
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = ProductTypeService.GetList("parentId = " + oneId);
            if(ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ ) 
                {
                    sb.Append("<li class=\"pro_z\"><a href=\"/project_1_" + ds.Tables[0].Rows[i]["id"] + "_0_0_0_0_0_0.html\">" + ds.Tables[0].Rows[i]["typeName"] + "</a></li>");
                    if (i != ds.Tables[0].Rows.Count - 1)
                    {
                        sb.Append("<li>|</li>");
                    }
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 绑定信息
        /// </summary>
        private void BindData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if(oneId != 0)
            {
                ProductType pt = ProductTypeService.GetModel(oneId);
                if(pt != null)
                {
                    ViewState["productName"] = pt.typeName;
                }
                sb.Append(" and oneId = " + oneId);
            }
            if (twoId != 0)
            {
                sb.Append(" and twoId = " + twoId);
            }
            if (threeId != 0)
            {
                sb.Append(" and threeId = " + threeId);
            }
            if (varietyId != 0)
            {
                sb.Append(" and varietyId = " + varietyId);

            }
            if (relieveId != 0)
            {
                sb.Append(" and relieveId = " + relieveId);

            }
            if (cookId != 0)
            {
                sb.Append(" and cookId = " + cookId);

            }
            if(keyword != "")
            {
                sb.Append(" and proName like '%" + keyword + "%'");
            }
            DataSet ds = ProductService.GetList(sb.ToString());
            if(ds.Tables[0].Rows.Count > 0)
            {
                repInfo.DataSource = ds;
                repInfo.DataBind();
            }
        }
    }
}