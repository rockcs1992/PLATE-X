using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;

namespace CommonBussiness.mobile
{
    public partial class about : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                //if(id == 33)
                //{
                //    ViewState["infoTitle"] = "看守种植";
                //    ViewState["infoContent"] = DAL.AboutMenuService.GetById(33);
                //}else if (id == 34)
                //{
                //    ViewState["infoTitle"] = "当日采摘";
                //    ViewState["infoContent"] = DAL.AboutMenuService.GetById(34);
                //}
                //else if (id == 35)
                //{
                //    ViewState["infoTitle"] = "任性下单";
                //    ViewState["infoContent"] = DAL.AboutMenuService.GetById(35);
                //}
                //else if (id == 36)
                //{
                //    ViewState["infoTitle"] = "随心退货";
                //    ViewState["infoContent"] = DAL.AboutMenuService.GetById(36);
                //}
                //else
                //{
                //    News item = NewsService.GetModel(id);
                //    if(item != null)
                //    {
                //        ViewState["infoTitle"] = item.title;
                //        ViewState["infoContent"] = item.newsContent;
                //    }
                //}
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
    }
}