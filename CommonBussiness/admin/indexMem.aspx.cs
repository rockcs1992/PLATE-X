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

namespace CommonBussiness.admin
{
    public partial class indexMem : System.Web.UI.Page
    {
        Page_ZH sp = new Page_ZH();
        int userId = CRequest.GetInt("userId", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                //LoadData();
                sp.InitBindData(repInfo, pager1, "IndexUser", "id", sear());
            }
        }
        /// <summary>
        /// 获取用户全称
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected string GetUserFullName(object  userId) 
        {
            UserBase ub = UserBaseService.GetModelByUserId(Convert.ToInt32(userId));
            if(ub != null)
            {
                return ub.fullName;
            }
            return "";
        }
        /// <summary>
        /// 获取模块名称
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetModule(object status)
        {
            NewsType nt = NewsTypeService.GetModel(Convert.ToInt32(status));
            if (nt != null)
            {
                return nt.name;
            }
            return "";
        }
        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (userId != 0)
            {
                sb.Append(" and userId = " + userId);
            }
            if(txtFullName.Text.Trim() != "")
            {
                sb.Append(" and userId in (select userId from UserBase where fullName like '%" + txtFullName.Text.Trim() + "%')");
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
            sp.InitBindData(repInfo, pager1, "IndexUser", "id", sear());
        }
        private void LoadData() 
        {
            //加载模块
            DataSet ds = NewsTypeService.GetList(4, "parentId = 2", "id");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPlace.DataSource = ds;
                ddlPlace.DataTextField = "name";
                ddlPlace.DataValueField = "id";
                ddlPlace.DataBind();
            }
            ddlPlace.Items.Insert(0, new ListItem("请选择", "0"));
        }
        /// <summary>
        /// 添加友情连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            int place = Convert.ToInt32(ddlPlace.SelectedValue);
            string name = this.txtLinkName.Text.Trim();
            string title = this.txtLinkTitle.Text.Trim();
            string url = this.txtLinkUrl.Text.Trim();
            if(name.Length == 0 || url.Length == 0)
            {
                lblError.Text="各项不能为空";
                return;
            }
            Links item = new Links();
            item.linkname = name;
            item.linktitle = title;
            item.linkurl = url;
            item.addtime = DateTime.Now;
            item.istj = place;
            if (lblId.Text != "")
            {
                item.id = Convert.ToInt32(lblId.Text.Trim());
                int num = LinksService.Update(item);
            }
            else
            {
                int num = LinksService.Add(item);
            }
            pnlAdd.Visible = false;
            pnlList.Visible = true;
            sp.InitBindData(repInfo, pager1, "Links", "id", sear());
        }
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                IndexUserService.Delete(id);
                sp.InitBindData(repInfo, pager1, "IndexUser", "id", sear());
            }
            if (e.CommandName.Equals("mod"))
            {
                IndexUser nt = IndexUserService.GetModel(Convert.ToInt32(e.CommandArgument));
                if (nt != null)
                {
                    Label lblOrder = e.Item.FindControl("lblOrder") as Label;
                    lblOrder.Visible = false;
                    TextBox txtOrderNum = e.Item.FindControl("txtOrderNum") as TextBox;
                    txtOrderNum.Visible = true;

                    Label lblFullName = e.Item.FindControl("lblFullName") as Label;
                    lblFullName.Visible = false;
                    TextBox txtFullName = e.Item.FindControl("txtFullName") as TextBox;
                    txtFullName.Visible = true;


                    LinkButton lbtnMod = e.Item.FindControl("lbtnMod") as LinkButton;
                    lbtnMod.Visible = false;
                    LinkButton lbtnSave = e.Item.FindControl("lbtnSave") as LinkButton;
                    lbtnSave.Visible = true;
                }
                else
                {
                    Label lblName = e.Item.FindControl("lblName") as Label;
                    lblName.Visible = false;
                    TextBox txtName = e.Item.FindControl("txtModName") as TextBox;
                    txtName.Visible = true;
                    LinkButton lbtnMod = e.Item.FindControl("lbtnMod") as LinkButton;
                    lbtnMod.Visible = false;
                    LinkButton lbtnSave = e.Item.FindControl("lbtnSave") as LinkButton;
                    lbtnSave.Visible = true;
                }


            }
            if (e.CommandName.Equals("save"))
            {
                TextBox txtOrderNum = e.Item.FindControl("txtOrderNum") as TextBox;
                string orderNum = txtOrderNum.Text.Trim();
                if (orderNum.Length != 0)
                {
                    if (!RegExp.IsNumeric(orderNum))
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('顺序号输入有误！');", true);
                        return;
                    }

                }
                TextBox txtFullName = e.Item.FindControl("txtFullName") as TextBox;
                string fullName = txtFullName.Text.Trim();
                if(fullName.Length == 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('名称不能为空！');", true);
                    return;
                }
                


                IndexUser nt = IndexUserService.GetModel(Convert.ToInt32(e.CommandArgument));
                if (nt != null)
                {
                    if (txtOrderNum.Text.Trim() != "")
                    {
                        nt.infoType = Convert.ToInt32(txtOrderNum.Text.Trim());
                    }
                    nt.id = Convert.ToInt32(e.CommandArgument);
                    int num = IndexUserService.Update(nt.id, nt.infoType);
                    if (num > 0)
                    {
                        ///更新基本信息全称和用户表全称

                        UserBase ub = UserBaseService.GetModelByUserId(nt.userId);
                        if (ub != null)
                        {
                            UserBaseService.UpdateFullName(ub.id, fullName);
                            UserInfo user = UserInfoService.GetModel(ub.userId);
                            if (user != null)
                            {
                                user.comName = fullName;
                                UserInfoService.UpdateComName(user);
                            }

                        }
                        ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('保存成功！');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('保存失败！');", true);
                    }

                    
                }
                sp.InitBindData(this.repInfo, pager1, "IndexUser", "id", sear());
            }
            
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;
            pnlList.Visible = false;
            txtLinkName.Text = "";
            txtLinkTitle.Text = "";
            txtLinkUrl.Text = "";
            lblId.Text = "";
            lblError.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            sp.InitBindData(this.repInfo, pager1, "IndexUser", "id", sear());
        }

    }
}