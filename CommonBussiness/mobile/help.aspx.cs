using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;

namespace CommonBussiness.mobile
{
    public partial class help : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();
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
        /// 获取标题
        /// </summary>
        /// <returns></returns>
        protected string GetTitle()
        {
             if(id == 1)
             {
                 return "关于Plate-X";
             }
             if (id == 2)
             {
                 return "Plate-X招聘";
             }
             if (id == 3)
             {
                 return "版权政策";
             }
             if (id == 4)
             {
                 return "Join账号";
             }
             if (id == 5)
             {
                 return "购物流程";
             }
             if (id == 6)
             {
                 return "Plate-X积分";
             }
             if (id == 7)
             {
                 return "配送时间";
             }
             if (id == 8)
             {
                 return "配送范围";
             }
             if (id == 9)
             {
                 return "验货签收";
             }
             if (id == 10)
             {
                 return "线上支付";
             }
             if (id == 11)
             {
                 return "Plate-X卡";
             }
             if (id == 12)
             {
                 return "退款方式时间";
             }
             if (id == 13)
             {
                 return "关于发票";
             }
             if (id == 14)
             {
                 return "退换货政策";
             }
             if (id == 15)
             {
                 return "联系客服";
             }
             return "";
        }
    }
}