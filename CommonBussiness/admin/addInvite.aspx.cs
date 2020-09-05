using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using Model;
using System.IO;
using System.Text;
using System.Net;

namespace CommonBussiness.admin
{
    public partial class addInvite : System.Web.UI.Page
    {
        int id = CRequest.GetInt("id",0);
        Page_ZH sp = new Page_ZH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                if(id != 0)
                {
                    LoadInfo();
                }
            }
        }
        /// <summary>
        /// 加载信息进行修改
        /// </summary>
        private void LoadInfo() 
        {
            Invite item = InviteService.GetModel(id);
            if(item != null)
            {
                txtTitle.Text = item.inviteName;
                txtPeopleCount.Text = item.inviteType.ToString();
                txtZhaiYao.Value = item.inviteDesc;
                content1.Value = item.inviteInfo;

            }
        }
        /// 发布资讯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRelease_Click(object sender, EventArgs e)
        {
            if (Session["loginUser"] == null)
            {
                Jscript.AlertAndRedirect("请登录", "/admin/login.aspx");
                return;
            }
            string peopleCount = txtPeopleCount.Text.Trim();
            if(peopleCount.Length == 0)
            {
                lblError.Text = "请输入招聘人数";
                return;
            }
            Invite item = new Invite();
            item.inviteType = 0;
            try
            {
                item.inviteType = Convert.ToInt32(txtPeopleCount.Text.Trim());
            }
            catch(Exception je)
            {
                lblError.Text = "招聘人数输入错误";
                return;
            }
            item.inviteName = txtTitle.Text.Trim();
            item.inviteInfo = this.content1.Value;
            item.inviteDesc = txtZhaiYao.Value.Trim();
            txtHidInfo.Text = item.inviteInfo;
            item.inforemark = txtHidInfo.Text.Trim();
            txtHidInfo.Text = item.inviteDesc;
            item.descremark = txtHidInfo.Text;
            item.addTime = DateTime.Now;
            item.status = 0;
            if (id != 0)
            {
                item.id = id;
                if (InviteService.Update(item))
                {
                    Jscript.AlertAndRedirect("修改成功", "inviteInfo.aspx");
                }
                else
                {
                    Jscript.AlertAndRedirect("修改失败", "inviteInfo.aspx");
                }
            }
            else
            {
                int num = InviteService.Add(item);
                if (num > 0)
                {
                    Jscript.AlertAndRedirect("添加成功", "inviteInfo.aspx");
                }
                else
                {
                    Jscript.AlertAndRedirect("添加失败", "inviteInfo.aspx");
                }
            }
            
           
        }
        
    }
}