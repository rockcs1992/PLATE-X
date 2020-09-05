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
    public partial class ImportOrders : System.Web.UI.Page
    {
        string ids = CRequest.GetString("ids");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = OrderService.GetList("id in(" + ids.TrimEnd(',') + ")");               
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
        /// 获取用户信息
        /// </summary>
        /// <param name="sharecount"></param>
        /// <returns></returns>
        protected string GetUserInfo(object addUser)
        {
            StringBuilder sb = new StringBuilder();
            UserInfo user = UserInfoService.GetModel(Convert.ToInt32(addUser));
            if(user != null)
            {
                sb.Append(user.relName + "·" + user.username + "|" + user.email + "|" + user.mobileCode + "|" + user.address + "|" + user.activeCode + "|" + user.mainbrand);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        protected string GetOrderStatusName(object status)
        {
            int s = Convert.ToInt32(status);
            if (s == 1)
            {
                return "已支付（待发货）";
            }
            if (s == 2)
            {
                return "待收货";
            }
            if (s == 3)
            {
                return "待评价";
            }
            if (s == 4)
            {
                return "已完成";
            }
            if (s == 100)
            {
                return "已取消";
            }
            if (s == 150)
            {
                return "客户端删除";
            }
            return "未支付";
        }
        /// <summary>
        /// 获取父类名称
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        protected string GetOrderDetailInfo(object orderId)
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = OrderDetailService.GetList("orderId = " + orderId);
            if(ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ ) 
                {
                    Product item = ProductService.GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["productId"]));
                    if(item != null)
                    {
                        sb.Append(item.proName + "：" + ds.Tables[0].Rows[i]["productCount"] + " * $ " + item.price1.ToString("0.00") + " = $ " + Convert.ToDouble(ds.Tables[0].Rows[i]["total"]).ToString("0.00"));
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["satus"]) == 1)
                        {
                            sb.Append("|备货完成");
                        }
                        else
                        {
                            sb.Append("|备货中");
                        }
                        UserInfo user = UserInfoService.GetModel(item.useId);
                        if(user != null)
                        {
                            sb.Append("|" + user.comName + "：" + user.relName + "·" + user.username + " " + user.mobile);
                        }
                    }
                    sb.Append("||||||||||||||");
                }
            }
            return sb.ToString();
        }
        private void CreateExcel()
        {            
            try
            {
                this.GridView1.AllowPaging = false;
                Response.ClearContent();
                Response.Charset = "utf-8";
                Page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.AddHeader("content-disposition", "attachment; filename=导出订单信息.xls");
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