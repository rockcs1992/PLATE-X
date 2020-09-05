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

namespace CommonBussiness.admin
{
    public partial class levelMenu : System.Web.UI.Page
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
                LoadOneInfo();
                //GetCity("1");
            }
        }
        /// <summary>
        /// 一级权限菜单信息加载
        /// </summary>
        /// <returns></returns>
        private void GetTwo(string pid)
        {
            StringBuilder sb = new StringBuilder();
            if (pid != "0")
            {
                OALevel item = OALevelService.GetModel(Convert.ToInt32(pid));
                if(item != null)
                {
                    DataSet ds = OALevelService.GetList("parentLevelNo = " + item.levelNO);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            sb.Append("<label class=\"preview\"><input type=\"radio\" id='city" + dr["id"] + "' name='city' onclick=\"getTwoInfo(" + dr["id"] + ",'" + dr["levelName"] + "',this,'" + dr["url"] + "');\" />" + dr["levelName"] + "</label>");
                        }
                    }
                }
                
            }
            ViewState["twoInfo"] = sb.ToString();

        }
        /// <summary>
        /// 添加二级信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddTwo_Click(object sender, EventArgs e)
        {
            string pid = this.ddlOne.SelectedValue;
            if (pid == "0")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择一级分类!');", true);
                return;
            }
            string twoName = this.txtTwo.Text.Trim();
            if (twoName.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('二级分类名称不能为空!');", true);
                return;
            }
            OALevel item = new OALevel();
            item.levelName = twoName;
            item.isParent = 0;
            item.url = txtURL.Text.Trim();
            OALevel parentItem = OALevelService.GetModel(Convert.ToInt32(pid));
            if (parentItem != null)
            {
                item.parentLevelNo = parentItem.levelNO;
            }
            else
            {
                item.parentLevelNo = 0;
            }
            item.levelNO = OALevelService.GetMaxLevelNo(item.parentLevelNo);
            item.status = 0;
            item.remark = "";
            int num = OALevelService.Add(item);
            if (num > 0)
            {                
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('添加成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('添加失败!');", true);
            }
            GetTwo(pid);
        }
        /// <summary>
        /// 修改二级信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModTwo_Click(object sender, EventArgs e)
        {
            string name = this.txtTwo.Text.Trim();
            if (name.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('二级分类名称不能为空!');", true);
                return;
            }
            string hidValue = this.hidTwo.Value.TrimEnd(',');
            if (hidValue.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要修改的信息!');", true);
                return;
            }
            string[] arr = hidValue.Split(',');
            if (arr.Length > 1)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('只能选择一项信息进行修改!');", true);
                return;
            }
            string url = txtURL.Text.Trim();
            OALevelService.Update(Convert.ToInt32(arr[0]), name,url);
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('修改成功!');", true);
            GetTwo(this.ddlOne.SelectedValue);
        }
        /// <summary>
        /// 一级分类下拉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pid = ddlOne.SelectedValue;
            if (pid != "0")
            {
                GetTwo(pid);
            }
        }


        /// <summary>
        /// 一级信息加载
        /// </summary>
        /// <returns></returns>
        protected string GetOneInfo()
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = OALevelService.GetList("parentLevelNo = 0");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append("<label class=\"preview\"><input type=\"radio\" id='one" + dr["id"] + "' name='one' onclick=\"getOneMenuInfo(" + dr["id"] + ",'" + dr["levelName"] + "',this);\" />" + dr["levelName"] + "</label>");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 加载一级信息
        /// </summary>
        private void LoadOneInfo()
        {
            DataSet ds = OALevelService.GetList("parentLevelNo = 0");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlOne.Items.Clear();
                ddlOne.DataSource = ds;
                ddlOne.DataTextField = "levelName";
                ddlOne.DataValueField = "id";
                ddlOne.DataBind();
                //this.ddlProvince.SelectedValue = "1";
            }
            ddlOne.Items.Insert(0, new ListItem("请选择一级分类", "0"));

        }

        /// <summary>
        /// 添加一级信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddOne_Click(object sender, EventArgs e)
        {
            string pName = this.txtOne.Text.Trim();
            if (pName.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('名称不能为空!');", true);
                return;
            }
            OALevel item = new OALevel();
            item.levelName = pName;
            item.levelNO = OALevelService.GetMaxLevelNo(0);
            item.isParent = 0;
            item.url = "";

            item.parentLevelNo = 0;
            item.status = 0;
            item.remark = "";
            int num = OALevelService.Add(item);
            if (num > 0)
            {                
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('添加成功!');", true);
            }

            LoadOneInfo();
        }
        /// <summary>
        /// 修改一级信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModOne_Click(object sender, EventArgs e)
        {
            string name = this.txtOne.Text.Trim();
            if (name.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('名称不能为空!');", true);
                return;
            }
            string hidValue = this.hidOne.Value.TrimEnd(',');
            if (hidValue.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要修改的信息!');", true);
                return;
            }
            string[] arr = hidValue.Split(',');
            if (arr.Length > 1)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('只能选择一项信息进行修改!');", true);
                return;
            }
            OALevelService.Update(Convert.ToInt32(arr[0]), name,"");

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('修改成功!');location.href='levelMenu.aspx'", true);

        }
        /// <summary>
        /// 删除一级信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelOne_Click(object sender, EventArgs e)
        {
            string hidValue = this.hidOne.Value.TrimEnd(',');
            if (hidValue.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要删除的信息!');", true);
                return;
            }
            string[] arr = hidValue.Split(',');
            if (arr.Length > 1)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('只能选择一项信息进行删除!');", true);
                return;
            }
            int num = OALevelService.Delete(Convert.ToInt32(arr[0]));
            if (num > 0)
            {

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除成功!');location.href='levelMenu.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除失败!');location.href='levelMenu.aspx'", true);
            }

        }
    }
}