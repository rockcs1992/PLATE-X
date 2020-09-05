using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Text;
using System.Data;

namespace CommonBussiness
{
    public partial class invite : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KeyWordBind();

                DataSet ds = InviteService.GetList("");
                if(ds.Tables[0].Rows.Count > 0)
                {
                    repInfo.DataSource = ds;
                    repInfo.DataBind();
                }
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
        /// 提交信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string mobile = txtMobile.Text.Trim();
            string QQ = txtQQ.Text.Trim();
            string inviteName = txtInviteName.Text.Trim();
            string workYear = txtWorkYears.Text.Trim();
            string selfInfo = txtSelInfo.Text.Trim();
            if (name.Length == 0 || mobile.Length == 0 || inviteName.Length == 0)
            {
                ViewState["errorInfo"] = "姓名、手机号和求职岗位不能为空";
                return;
            }
            Resume item = new Resume();
            item.inviteId = 0;
            if(this.hidInviteId.Value != "")
            {
                item.inviteId = Convert.ToInt32(this.hidInviteId.Value.Trim());
            }
            item.realName = name;
            item.mobile = mobile;
            item.QQ = QQ;
            item.inviteName = inviteName;
            item.workYears = workYear;
            item.selfInfo = selfInfo;
            item.status = 0;
            item.addTime = DateTime.Now;
            item.remark = "";
            int num = ResumeService.Add(item);
            if (num > 0)
            {
                ViewState["errorInfo"] = "提交成功，网站管理员会联系您，请注意接听电话";
                txtName.Text = "";
                txtMobile.Text = "";
                txtQQ.Text = "";
                txtInviteName.Text = "";
                txtWorkYears.Text = "";
                txtSelInfo.Text = "";

            }
            else
            {
                ViewState["errorInfo"] = "保存失败";
            }
        }
    }
}