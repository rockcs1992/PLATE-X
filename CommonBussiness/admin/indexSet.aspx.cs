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
    public partial class indexSet : System.Web.UI.Page
    {
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
            TextBox1.Text = BaseConfigService.GetById_Name(31);
            TextBox2.Text = BaseConfigService.GetById(31);

            TextBox3.Text = BaseConfigService.GetById_Name(32);
            TextBox4.Text = BaseConfigService.GetById(32);

            TextBox5.Text = BaseConfigService.GetById_Name(33);
            TextBox6.Text = BaseConfigService.GetById(33);

            TextBox7.Text = BaseConfigService.GetById_Name(34);
            TextBox8.Text = BaseConfigService.GetById(34);

            TextBox9.Text = BaseConfigService.GetById_Name(35);
            TextBox10.Text = BaseConfigService.GetById(35);

            TextBox11.Text = BaseConfigService.GetById_Name(36);
            TextBox12.Text = BaseConfigService.GetById(36);

            TextBox13.Text = BaseConfigService.GetById_Name(37);
            TextBox14.Text = BaseConfigService.GetById(37);

            TextBox15.Text = BaseConfigService.GetById_Name(38);
            TextBox16.Text = BaseConfigService.GetById(38);


        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            BaseConfigService.SetValue_Name(31,TextBox1.Text.Trim());
            BaseConfigService.SetValue(31, TextBox2.Text.Trim());

            BaseConfigService.SetValue_Name(32, TextBox3.Text.Trim());
            BaseConfigService.SetValue(32, TextBox4.Text.Trim());

            BaseConfigService.SetValue_Name(33, TextBox5.Text.Trim());
            BaseConfigService.SetValue(33, TextBox6.Text.Trim());

            BaseConfigService.SetValue_Name(34, TextBox7.Text.Trim());
            BaseConfigService.SetValue(34, TextBox8.Text.Trim());

            BaseConfigService.SetValue_Name(35, TextBox9.Text.Trim());
            BaseConfigService.SetValue(35, TextBox10.Text.Trim());

            BaseConfigService.SetValue_Name(36, TextBox11.Text.Trim());
            BaseConfigService.SetValue(36, TextBox12.Text.Trim());

            BaseConfigService.SetValue_Name(37, TextBox13.Text.Trim());
            BaseConfigService.SetValue(37, TextBox14.Text.Trim());

            BaseConfigService.SetValue_Name(38, TextBox15.Text.Trim());
            BaseConfigService.SetValue(38, TextBox16.Text.Trim());
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');", true);
        }
        /// <summary>
        /// 重置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox14.Text = "";
            TextBox15.Text = "";
            TextBox16.Text = "";

        }
    }
}