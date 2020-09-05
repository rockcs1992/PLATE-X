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
    public partial class areaInfo : System.Web.UI.Page
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
        /// 取消热门地区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelCity_Click(object sender, EventArgs e)
        {
            string hidValue = this.hidTwo.Value.TrimEnd(',');
            string pid = this.ddlOne.SelectedValue;
            if (hidValue.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要取消热门的信息!');", true);
                return;
            }
            string[] arr = hidValue.Split(',');
            if (arr.Length > 1)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('只能选择一项信息进行设置!');", true);
                return;
            }
            int num = AreaInfoService.SetHot(Convert.ToInt32(arr[0]), 0);
            if (num > 0)
            {

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('设置成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('设置失败!');", true);
            }
            GetTwo(pid);
            //加载热门信息
            LoadHotInfo();
        }
        /// <summary>
        /// 取消热门省
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelHot_Click(object sender, EventArgs e)
        {
            string hidValue = this.hidOne.Value.TrimEnd(',');
            if (hidValue.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要取消热门的信息!');", true);
                return;
            }
            string[] arr = hidValue.Split(',');
            if (arr.Length > 1)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('只能选择一项信息进行设置!');", true);
                return;
            }
            int num = AreaInfoService.SetHot(Convert.ToInt32(arr[0]),0);
            if (num > 0)
            {

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('设置成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('设置失败!');", true);
            }
            GetOneInfo();
            //加载热门信息
            LoadHotInfo();
        }
        /// <summary>
        /// 设置热门地区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bntHotCity_Click(object sender, EventArgs e)
        {
            string hidValue = this.hidTwo.Value.TrimEnd(',');
            string pid = this.ddlOne.SelectedValue;
            if (hidValue.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要设置的信息!');", true);
                return;
            }
            string[] arr = hidValue.Split(',');
            if (arr.Length > 1)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('只能选择一项信息进行设置!');", true);
                return;
            }
            int num = AreaInfoService.SetHot(Convert.ToInt32(arr[0]),1);
            if (num > 0)
            {

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('设置成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('设置失败!');", true);
            }
            GetTwo(pid);
            //加载热门信息
            LoadHotInfo();
        }
        /// <summary>
        /// 设为热门省
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnHot_Click(object sender, EventArgs e)
        {
            string hidValue = this.hidOne.Value.TrimEnd(',');
            if (hidValue.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择要设为热门的信息!');", true);
                return;
            }
            string[] arr = hidValue.Split(',');
            if (arr.Length > 1)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('只能选择一项信息进行设置!');", true);
                return;
            }
            int num = AreaInfoService.SetHot(Convert.ToInt32(arr[0]),1);
            if (num > 0)
            {

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('设置成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('设置失败!');", true);
            }
            GetOneInfo();
            //加载热门信息
            LoadHotInfo();
        }


        /// <summary>
        /// 市信息加载
        /// </summary>
        /// <returns></returns>
        private void GetRegion(string cid)
        {
            StringBuilder sb = new StringBuilder();
            if (cid != "0")
            {
                DataSet ds = AreaInfoService.GetList("parentId = " + cid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sb.Append("<label class=\"preview\"><input type=\"radio\" id='region" + dr["id"] + "' name='region' onclick=\"getRegionInfo(" + dr["id"] + ",'" + dr["areaName"] + "','" + dr["charIndex"] + "',this);\" />" + dr["areaName"] + "</label>");
                    }
                }
            }
            ViewState["regionInfo"] = sb.ToString();

        }
        /// <summary>
        /// 市信息加载
        /// </summary>
        /// <returns></returns>
        private void GetTwo(string pid)
        {
            StringBuilder sb = new StringBuilder();
            if (pid != "0")
            {
                DataSet ds = AreaInfoService.GetList("parentId = " + pid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sb.Append("<label class=\"preview\"><input type=\"radio\" id='city" + dr["id"] + "' name='city' onclick=\"getCityInfo(" + dr["id"] + ",'" + dr["areaName"] + "','" + dr["charIndex"] + "',this);\" />" + dr["areaName"] + "</label>");
                    }
                }
            }
            ViewState["twoInfo"] = sb.ToString();

        }
        /// <summary>
        /// 添加市信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddTwo_Click(object sender, EventArgs e)
        {
            string pid = this.ddlOne.SelectedValue;
            if (pid == "0")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择省级分类!');", true);
                return;
            }
            string twoName = this.txtTwo.Text.Trim();
            string cCh = txtCharCity.Text.Trim();
            if (twoName.Length == 0 || cCh.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('市名称和字符信息不能为空!');", true);
                return;
            }
            AreaInfo item = new AreaInfo();
            item.areaName = twoName;
            item.charIndex = cCh;
            item.parentId = Convert.ToInt32(pid);
            item.status = 0;
            item.remark = "";
            int num = AreaInfoService.Add(item);
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
        /// 修改市信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModTwo_Click(object sender, EventArgs e)
        {
            string name = this.txtTwo.Text.Trim();
            string cCh = txtCharCity.Text.Trim();
            if (name.Length == 0 || cCh.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('市名称和字符信息不能为空!');", true);
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
            AreaInfoService.Update(Convert.ToInt32(arr[0]), name,cCh);
            
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
        /// 一级分类下拉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cid = ddlCity.SelectedValue;
            if (cid != "0")
            {
                GetRegion(cid);
            }
        }
        /// <summary>
        /// 省级分类下拉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pid = ddlProvince.SelectedValue;
            if (pid != "0")
            {
                ddlCity.Items.Clear();
                DataSet ds = AreaInfoService.GetList("parentId = " + pid);
                if (ds.Tables[0].Rows.Count > 0)
                {                    
                    ddlCity.DataSource = ds;
                    ddlCity.DataTextField = "areaName";
                    ddlCity.DataValueField = "id";
                    ddlCity.DataBind();
                    
                }
                ddlCity.Items.Insert(0, new ListItem("请选择", "0"));
            }
        }

        /// <summary>
        /// 一级信息加载
        /// </summary>
        /// <returns></returns>
        protected string GetOneInfo()
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = AreaInfoService.GetList("parentId = 0");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append("<label class=\"preview\"><input type=\"radio\" id='one" + dr["id"] + "' name='one' onclick=\"getOneInfo(" + dr["id"] + ",'" + dr["areaName"] + "','" + dr["charIndex"] + "',this);\" />" + dr["areaName"] + "</label>");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 加载一级信息
        /// </summary>
        private void LoadOneInfo()
        {
            DataSet ds = AreaInfoService.GetList("parentId = 0");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlOne.Items.Clear();
                ddlOne.DataSource = ds;
                ddlOne.DataTextField = "areaName";
                ddlOne.DataValueField = "id";
                ddlOne.DataBind();
                //this.ddlProvince.SelectedValue = "1";

                ddlProvince.Items.Clear();
                ddlProvince.DataSource = ds;
                ddlProvince.DataTextField = "areaName";
                ddlProvince.DataValueField = "id";
                ddlProvince.DataBind();

            }
            ddlOne.Items.Insert(0, new ListItem("请选择省级分类", "0"));
            ddlProvince.Items.Insert(0, new ListItem("请选择省级分类", "0"));

            //加载热门信息
            LoadHotInfo();
        }
        private void LoadHotInfo() 
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = AreaInfoService.GetList("status = " + 1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append("<label class=\"preview\"> "+ dr["areaName"] + "</label>");
                }
            }
            ViewState["hotInfo"] = sb.ToString();
        }

        /// <summary>
        /// 添加一级信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddOne_Click(object sender, EventArgs e)
        {
            string pName = this.txtOne.Text.Trim();
            string pChar = this.txtChar.Text.Trim();
            if (pName.Length == 0 || pChar.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('名称和字符信息不能为空!');", true);
                return;
            }
            AreaInfo item = new AreaInfo();
            item.areaName = pName;
            item.charIndex = pChar;
            item.parentId = 0;
            item.status = 0;
            item.remark = "";
            int num = AreaInfoService.Add(item);
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
            string pChar = txtChar.Text.Trim();
            if (name.Length == 0 || pChar.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('名称和字符信息不能为空!');", true);
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
            AreaInfoService.Update(Convert.ToInt32(arr[0]), name,pChar);
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('修改成功!');location.href='areaInfo.aspx'", true);

        }


        /// <summary>
        /// 删除商圈信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelRegion_Click(object sender, EventArgs e)
        {
            string hidValue = this.hidRegion.Value.TrimEnd(',');
            string pid = this.ddlProvince.SelectedValue;
            string cid = ddlCity.SelectedValue;
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
            int num = AreaInfoService.Delete(Convert.ToInt32(arr[0]));
            if (num > 0)
            {

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除失败!');", true);
            }
            GetRegion(cid);
        }

        /// <summary>
        /// 删除二级信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelTwo_Click(object sender, EventArgs e)
        {
            string hidValue = this.hidTwo.Value.TrimEnd(',');
            string pid = this.ddlOne.SelectedValue;
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
            int num = AreaInfoService.Delete(Convert.ToInt32(arr[0]));
            if (num > 0)
            {

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除失败!');", true);
            }
            GetTwo(pid);
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
            int num = AreaInfoService.Delete(Convert.ToInt32(arr[0]));
            if (num > 0)
            {
                
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除失败!');", true);
            }
            GetOneInfo();
        }

        protected void btnRegion_Click(object sender, EventArgs e)
        {
            string pid = this.ddlProvince.SelectedValue;
            string cid = ddlCity.SelectedValue;
            if (pid == "0" || cid == "0")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请选择省市分类!');", true);
                return;
            }
            string regionName = this.txtRegion.Text.Trim();
            string cCh = this.txtC.Text.Trim();
            if (regionName.Length == 0 || cCh.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('商圈名称和字符信息不能为空!');", true);
                return;
            }
            AreaInfo item = new AreaInfo();
            item.areaName = regionName;
            item.charIndex = cCh;
            item.parentId = Convert.ToInt32(cid);
            item.status = 0;
            item.remark = "";
            int num = AreaInfoService.Add(item);
            if (num > 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('添加成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('添加失败!');", true);
            }
            this.GetRegion(cid);
        }

        protected void btnModRegion_Click(object sender, EventArgs e)
        {
            string name = this.txtRegion.Text.Trim();
            string cCh = txtC.Text.Trim();
            if (name.Length == 0 || cCh.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('商圈名称和字符信息不能为空!');", true);
                return;
            }
            string hidValue = this.hidRegion.Value.TrimEnd(',');
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
            AreaInfoService.Update(Convert.ToInt32(arr[0]), name, cCh);

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('修改成功!');", true);
            this.GetRegion(this.ddlCity.SelectedValue);
        }
    }
}