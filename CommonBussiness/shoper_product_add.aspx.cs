using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Text;
using System.IO;
using DAL;
using System.Data;

namespace CommonBussiness
{
    public partial class shoper_product_add : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                //产品I am a
                DataSet ds = ProductTypeService.GetList("parentId = 0");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.ddlProductType.DataSource = ds;
                    ddlProductType.DataTextField = "typeName";
                    ddlProductType.DataValueField = "id";
                    ddlProductType.DataBind();
                }
                ddlProductType.Items.Insert(0, new ListItem("Category", "0"));

                if(id != 0)
                {
                    ViewState["id"] = id;
                }
                ViewState["headImg"] = "images/product_default.png";
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
        /// 绑定信息
        /// </summary>
        private void BindData()
        {

            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (ViewState["id"] != null)
                {
                    Product p = ProductService.GetModel(Convert.ToInt32(ViewState["id"]));
                    if (p != null)
                    {
                        hidId.Value = p.id.ToString();
                        if (p.listImgUrl != "")
                        {
                            ViewState["headImg"] = p.listImgUrl;
                            hidImg.Value = p.listImgUrl;
                        }
                        proname.Text = p.proName;
                        ddlProductType.SelectedValue = p.productType.ToString();
                        storeCount.Text = p.proType.ToString();
                        unit1.Text = p.unit1;
                        price1.Text = p.price1.ToString("0.00");
                        infoDesc.Text = p.advantage;
                    }
                }               

            }
            else
            {
                Response.Redirect("/register.html");
            }

            
        }
    }
}