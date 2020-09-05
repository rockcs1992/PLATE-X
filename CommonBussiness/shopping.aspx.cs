using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using Model;

namespace CommonBussiness
{
    public partial class shopping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                ViewState["total"] = "0.00";
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
        protected void repInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("add"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CartTemp ct = CartTempService.GetModel(id);
                if (ct != null)
                {
                    ct.productCount++;
                    Product p = ProductService.GetModel(ct.productId);
                    if (p != null)
                    {
                        ct.remark = (ct.productCount * p.price1).ToString("0.00");
                    }
                    CartTempService.UpdateCart(ct);
                }
            }
            if (e.CommandName.Equals("del"))
            {
                CartTempService.Delete(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName.Equals("reduce"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CartTemp ct = CartTempService.GetModel(id);
                if(ct != null)
                {
                    if(ct.productCount > 1)
                    {
                        ct.productCount--;
                        Product p = ProductService.GetModel(ct.productId);
                        if(p != null)
                        {
                            ct.remark = (ct.productCount * p.price1).ToString("0.00");
                        }
                        CartTempService.UpdateCart(ct);
                    }
                }
            }
            BindData();
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
        /// 获取产品图片
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetProName(object productId)
        {
            Product item = ProductService.GetModel(Convert.ToInt32(productId));
            if (item != null)
            {
                return item.proName;
            }
            return "";
        }
        /// <summary>
        /// 获取产品图片
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetPrice(object productId,object status)
        {
            int s = Convert.ToInt32(status);
            Product item = ProductService.GetModel(Convert.ToInt32(productId));
            if (item != null)
            {
                if(s == 1)
                {
                    return item.price1.ToString("0.00");
                }
                if (s == 2)
                {
                    return item.price2.ToString("0.00");
                }
                if (s == 3)
                {
                    return item.price3.ToString("0.00");
                }
                if (s == 4)
                {
                    return item.price4.ToString("0.00");
                }
            }
            return "0";
        }
        /// <summary>
        /// 获取产品图片
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetImg(object productId) 
        {
            Product item = ProductService.GetModel(Convert.ToInt32(productId));
            if(item != null)
            {
                return item.listImgUrl;
            }
            return "";
        }
        /// <summary>
        /// 绑定信息
        /// </summary>
        private void BindData()
        {
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                DataSet ds = CartTempService.GetList("addUser = " + user.id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    repInfo.DataSource = ds;
                    repInfo.DataBind();
                }
                else
                {
                    repInfo.DataSource = null;
                    repInfo.DataBind();
                }
            }
            double total = 0;
            for (int i = 0; i < repInfo.Items.Count; i++)
            {
                Label lbl = repInfo.Items[i].FindControl("lblTotal") as Label;
                total += Convert.ToDouble(lbl.Text.Trim());
            }
            ViewState["carTotal"] = total.ToString("0.00");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                Jscript.Alert("请选择要Delete的记录！", this.Page);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (CartTempService.Delete(Convert.ToInt32(arr[i])))
                {
                    num++;
                }
            }
            BindData();
        }
    }
}