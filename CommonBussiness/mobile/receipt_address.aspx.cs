using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using Model;

namespace CommonBussiness.mobile
{
    public partial class receipt_address : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id",0);
        string action = CRequest.GetString("action");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                if(action != "")
                {
                    this.hidAction.Value = action;
                }
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
            DataSet ds = AreaInfoService.GetList("parentId = 0");
            if(ds.Tables[0].Rows.Count > 0)
            {
                location_p.DataSource = ds;
                location_p.DataTextField = "areaName";
                location_p.DataValueField = "id";
                location_p.DataBind();
            }
            location_p.Items.Insert(0,new ListItem("请选择","0"));
            location_c.Items.Insert(0, new ListItem("请选择", "0"));
            location_a.Items.Insert(0, new ListItem("请选择", "0"));
            UserAddress item = UserAddressService.GetModel(id);
            if(item != null)
            {
                ViewState["labelname"] = item.addressDetail;
                ViewState["address"] = item.address;
                ViewState["telephone"] = item.tel;
                ViewState["mobile"] = item.mobile;
                ViewState["name"] = item.relName;
                location_p.SelectedValue = item.qq;

                location_c.Items.Clear();
                ds = AreaInfoService.GetList("parentId = " + location_p.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    location_c.DataSource = ds;
                    location_c.DataTextField = "areaName";
                    location_c.DataValueField = "id";
                    location_c.DataBind();
                }
                location_c.Items.Insert(0, new ListItem("请选择", "0"));
                location_c.SelectedValue = item.weixin;

                location_a.Items.Clear();
                ds = AreaInfoService.GetList("parentId = " + location_c.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    location_a.DataSource = ds;
                    location_a.DataTextField = "areaName";
                    location_a.DataValueField = "id";
                    location_a.DataBind();
                }
                location_a.Items.Insert(0, new ListItem("请选择", "0"));
                location_a.SelectedValue = item.zipcode;
            }
        }

        protected void location_p_SelectedIndexChanged(object sender, EventArgs e)
        {
            location_c.Items.Clear();
            DataSet ds = AreaInfoService.GetList("parentId = " + location_p.SelectedValue + " and parentId <> 0");
            if (ds.Tables[0].Rows.Count > 0)
            {
                location_c.DataSource = ds;
                location_c.DataTextField = "areaName";
                location_c.DataValueField = "id";
                location_c.DataBind();
            }
            location_c.Items.Insert(0, new ListItem("请选择", "0"));
            location_a.Items.Clear();
            location_a.Items.Insert(0, new ListItem("请选择", "0"));
        }

        protected void location_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            location_a.Items.Clear();
            DataSet ds = AreaInfoService.GetList("parentId = " + location_c.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                location_a.DataSource = ds;
                location_a.DataTextField = "areaName";
                location_a.DataValueField = "id";
                location_a.DataBind();
            }
            location_a.Items.Insert(0, new ListItem("请选择", "0"));
        }
    }
}