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
    public partial class link : System.Web.UI.Page
    {
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
                LoadData();
                sp.InitBindData(repInfo, pager1, "Links", "id", sear());
            }
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

            return sb.ToString();
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            sp.InitBindData(repInfo, pager1, "Links", "id", sear());
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
            item.linktitle = "0";
            if (title != "")
            {
                if (!RegExp.IsNumeric(title))
                {
                    lblError.Text = "顺序号输入有误！";
                    return;
                }
                else
                {
                    item.linktitle = title;
                }
            }
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
                LinksService.Delete(id);
                LoadData();
            }
            if (e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Links item = LinksService.GetModel(id);
                if(item != null)
                {
                    DataSet ds = NewsTypeService.GetList(4, "parentId = 2", "id");
                    int flag = 0;
                    if (ds.Tables[0].Rows.Count > 0)
                    { 
                        foreach(DataRow dr in ds.Tables[0].Rows)
                        {
                            if(Convert.ToInt32(dr["id"]) == item.istj)
                            {
                                flag = 1;
                                break;
                            }
                        }
                    }
                    if(flag == 1)
                    {
                        ddlPlace.SelectedValue = item.istj.ToString();
                    }
                    
                    txtLinkUrl.Text = item.linkurl;
                    txtLinkTitle.Text = item.linktitle;
                    txtLinkName.Text = item.linkname;
                    lblId.Text = item.id.ToString();
                    pnlAdd.Visible = true;
                    pnlList.Visible = false;
                }
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

    }
}