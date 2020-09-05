using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DAL;
using Model;
using System.Text;
using System.IO;

namespace CommonBusiness.admin
{
    public partial class askNeed : System.Web.UI.Page
    {
        int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                LoadInfo();
            }
        }
        
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadInfo()
        {         
            this.content1.Value = AboutMenuService.GetById(id);
            if (id == 1)
            {
                ViewState["infoTypeName"] = "关于Plate-X";
            }
            if (id == 2)
            {
                ViewState["infoTypeName"] = "Plate-X招聘";
            }
            if (id == 3)
            {
                ViewState["infoTypeName"] = "版权政策";
            }

            if (id == 4)
            {
                ViewState["infoTypeName"] = "注册账号";
            }
            if (id == 5)
            {
                ViewState["infoTypeName"] = "购物流程";
            }
            if (id == 6)
            {
                ViewState["infoTypeName"] = "隐私政策";
            }
            if (id == 7)
            {
                ViewState["infoTypeName"] = "用户协议";
            }
            if (id == 8)
            {
                ViewState["infoTypeName"] = "配送时间";
            }

            if (id == 9)
            {
                ViewState["infoTypeName"] = "配送范围";
            }
            if (id == 10)
            {
                ViewState["infoTypeName"] = "验货签收";
            }
            if (id == 11)
            {
                ViewState["infoTypeName"] = "关于发票";
            }
            if (id == 12)
            {
                ViewState["infoTypeName"] = "微信支付";
            }
            if (id == 13)
            {
                ViewState["infoTypeName"] = "关于发票";
            }
            if (id == 14)
            {
                ViewState["infoTypeName"] = "退换货政策";
            }
            if (id == 15)
            {
                ViewState["infoTypeName"] = "退换方式时间";
            }
            if (id == 16)
            {
                ViewState["infoTypeName"] = "联系客服";
            }
            if (id == 20)
            {
                ViewState["infoTypeName"] = "";
            }
            if (id == 21)
            {
                ViewState["infoTypeName"] = "有机蔬菜";
            }
            
            if (id == 22)
            {
                ViewState["infoTypeName"] = "进口水果";
            }

            if (id == 23)
            {
                ViewState["infoTypeName"] = "肉禽蛋品";
            }
            if (id == 24)
            {
                ViewState["infoTypeName"] = "粮油副食";
            }
            if (id == 25)
            {
                ViewState["infoTypeName"] = "乳品饮料";
            }
            if (id == 26)
            {
                ViewState["infoTypeName"] = "进口零食";
            }
            if (id == 27)
            {
                ViewState["infoTypeName"] = "美酒咖啡";
            }
            if (id == 28)
            {
                ViewState["infoTypeName"] = "母婴滋补";
            }

            if (id == 28)
            {
                ViewState["infoTypeName"] = "母婴滋补";
            }
            if (id == 29)
            {
                ViewState["infoTypeName"] = "看守种植";
            }
            if (id == 30)
            {
                ViewState["infoTypeName"] = "当日采摘";
            }
            if (id == 32)
            {
                ViewState["infoTypeName"] = "随心退货";
            }
            if (id == 33)
            {
                ViewState["infoTypeName"] = "移动端看守种植";
            }
            if (id == 34)
            {
                ViewState["infoTypeName"] = "移动端当日采摘";
            }
            if (id == 35)
            {
                ViewState["infoTypeName"] = "移动端任性下单";
            }
            if (id == 36)
            {
                ViewState["infoTypeName"] = "移动端随心退货";
            }

        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id == 6 || id == 7)
            {
                AboutMenu item = AboutMenuService.GetModel(id);
                if(item != null)
                {
                    item.proValue = content1.Value;
                    AboutMenuService.Update(item);
                }
            }
            else
            {
                AboutMenuService.SetValue(id, content1.Value);
            }
            
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');", true);
        }
        /// <summary>
        /// 重置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.content1.Value = "";
            
        }
    }
}