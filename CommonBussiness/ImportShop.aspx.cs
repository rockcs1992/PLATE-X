using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.IO;
using System.Text;
using DAL;
using Model;

namespace CommonBussiness
{
    public partial class ImportShop : System.Web.UI.Page
    {
        string ids = CRequest.GetString("ids");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = UserInfoService.GetList("id in(" + ids.TrimEnd(',') + ")");               
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                //GridView1.Columns[17].ItemStyle.Width = System;
                CreateExcel();
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
            if (sex == 1)
            {
                return "男";
            }
            if (sex == 2)
            {
                return "女";
            }
            return "保密";
        }
        /// <summary>
        /// 获取说明书
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        protected string GetShopTypeName(object shopType)
        {
            int sex = Convert.ToInt32(shopType);
            if (sex == 1)
            {
                return "Restaurant";
            }
            if (sex == 2)
            {
                return "Store";
            }
            return "";
        }
        /// <summary>
        /// 获取父类名称
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        protected string GetAddUser(object addUser)
        {
            AdminUser nt = AdminUserService.GetModel(Convert.ToInt32(addUser));
            if (nt != null)
            {
                return nt.realName;
            }
            return "";
        }
        private void CreateExcel()
        {            
            try
            {
                this.GridView1.AllowPaging = false;
                Response.ClearContent();
                Response.Charset = "utf-8";
                Page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.AddHeader("content-disposition", "attachment; filename=导出商家会员信息.xls");
                Response.AddHeader("Content-Type", "text/html; charset=utf-8");
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < GridView1.Columns.Count; j++)
                    {
                        this.GridView1.Rows[i].Cells[j].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
                    }
                }
                GridView1.RenderControl(htw);
                Response.Write("" + sw.ToString());
                Response.End();
            }
            catch (Exception je)
            {
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[16].Text = "&nbsp;" + e.Row.Cells[16].Text + "&nbsp;";
                //e.Row.Cells[17].Text = "&nbsp;" + e.Row.Cells[16].Text + "&nbsp;";
                //e.Row.Cells[18].Text = "&nbsp;" + e.Row.Cells[16].Text + "&nbsp;";
                //e.Row.Cells[16].Wrap = false;
                //e.Row.Cells[17].Wrap = false;
                //e.Row.Cells[18].Wrap = false;
            }
        }
    }
}