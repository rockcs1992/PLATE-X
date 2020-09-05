using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Data;
using System.Text;
using CommonBussiness;
namespace CommonBusiness.admin
{
    public partial class orderList : System.Web.UI.Page
    {
        Page_ZH sp = new Page_ZH();
        int type = CRequest.GetInt("type",0);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                sp.InitBindData(Repeater1, pager1, "OrderInfo", "id", sear());
            }
        }
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetStatus(object status) 
        {
            int s = Convert.ToInt32(status);
            if(s == 0)
            {
                return "<span style='color:red;'>未支付</span>";
            }
            if (s == 1)
            {
                return "<span style='color:green;'>已支付（待发货）</span>";
            }
            if (s == 2)
            {
                return "<span style='color:blue;'>待收货</span>";
            }
            if (s == 3)
            {
                return "<span style='color:pink;'>待评价</span>";
            }
            if (s == 4)
            {
                return "<span style='color:gray;'>已完成</span>";
            }
            if (s == 100)
            {
                return "<span style='color:gray;'>已取消</span>";
            }
            if (s == 150)
            {
                return "<span style='color:orange;'>客户端删除</span>";
            }
            return "";
        }
        /// <summary>
        /// 获取下单人
        /// </summary>
        /// <param name="addUser"></param>
        /// <returns></returns>
        protected string GetUserInfo(object addUser) 
        {
            UserInfo user = UserInfoService.GetModel(Convert.ToInt32(addUser));
            if(user != null)
            {
                return user.relName + "/" + user.mobile;
            }
            return "";
        }
        /// <summary>
        /// 收货人信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="recieveUser"></param>
        /// <param name="mobile"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        protected string GetSend(object pid,object recieveUser,object mobile,object address) 
        {
            UserAddress ua = UserAddressService.GetModel(Convert.ToInt32(pid));
            if (ua != null)
            {
                return "<a title='" + ua.relName + " " + ua.mobile + "/" + ua.tel + "  " + ua.qq + " " + ua.weixin + " " + ua.zipcode + " " + ua.address + "'>" + ua.relName + "/" + ua.mobile + "</a>";
            }
            else
            {
                return "<a title='" + mobile + " " + address + "'>" + recieveUser + "/" + mobile + "</a>";
            }
        }
        
        
        /// <summary>
        /// 获取选择的信息
        /// </summary>
        /// <returns></returns>
        private string selInfo()
        {
            string Id = "";//获取当前选中的ID                       
            for (int i = 0; i < this.Repeater1.Items.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.Repeater1.Items[i].FindControl("cbxAll");
                if (ckb.Checked)
                {
                    Id += (this.Repeater1.Items[i].FindControl("lblId") as Label).Text + ",";
                }
            }
            return Id;

        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            int num = 0;
            if (ids.Length == 0)
            {
                Jscript.Alert("请选择要更新的记录！", this.Page);
                return;
            }
            string[] arr = ids.TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (OrderService.UpdateStatus(Convert.ToInt32(arr[i]),2) > 0)
                {
                    num++;
                }
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('成功更新" + num + "条记录！');", true);
            sp.InitBindData(Repeater1, pager1, "OrderInfo", "id", sear());
        }
        
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if(ddlStatus.SelectedValue != "99")
            {
                sb.Append(" and status = " + ddlStatus.SelectedValue);
            }
            if (txtTimeFrom.Text.Trim() != "")
            {
                sb.Append(" and addTime >= '" + txtTimeFrom.Text.Trim() + "' ");
            }
            if (txtTimeEnd.Text.Trim() != "")
            {
                sb.Append(" and addTime <= '" + txtTimeEnd.Text.Trim() + "' ");
            }
            if(txtNo.Text.Trim() != "")
            {
                sb.Append(" and orderNo like '%" + txtNo.Text.Trim() + "%'");
            }
            
            
            return sb.ToString();
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            sp.InitBindData(Repeater1, pager1, "OrderInfo", "id", sear());
        }
        
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            sp.InitBindData(Repeater1, pager1, "OrderInfo", "id", sear());
            this.pager1.PageSize = 100000;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string ids = selInfo();
            if (ids.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要导出的记录！');", true);
                return;
            }
            Response.Redirect("/ImportOrders.aspx?ids=" + ids.TrimEnd(','));
        }
    }
}