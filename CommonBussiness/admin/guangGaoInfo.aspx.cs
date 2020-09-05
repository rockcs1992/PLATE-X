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

namespace CommonBussiness.admin
{
    public partial class guangGaoInfo : System.Web.UI.Page
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
                sp.InitBindData(repInfo, pager1, "GuangGao", "id", sear());
            }
        }
        /// <summary>
        /// 投放状态
        /// </summary>
        /// <param name="endTime"></param>
        /// <returns></returns>
        protected string GetStatus(object endTime) 
        {
            DateTime tEnd = Convert.ToDateTime(endTime);
            if(tEnd >= DateTime.Now)
            {
                return "投放中";
            }
            return "已结束";
        }
        /// <summary>
        /// 身份证正面预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbUploadPhoto_Click(object sender, EventArgs e)
        {
            fileUpload(1);
        }

        //从控件上传文件
        public void fileUpload(int num)
        {
            string spic = "";
            if (num == 1)
            {
                if (filepic.PostedFile != null && filepic.PostedFile.FileName != "")
                {
                    if (!Directory.Exists(Server.MapPath(Global_Upload.GuangGaoImgPath)))//判断目录是否存在
                    {
                        Directory.CreateDirectory(Server.MapPath(Global_Upload.GuangGaoImgPath));//创建目录
                    }
                    spic = DoClass.UploadFile(filepic.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.GuangGaoImgPath);

                    if (spic == "-1")
                    {
                        return;
                    }
                    else if (spic == "0")
                    {
                        return;
                    }
                    else
                    {
                        ViewState["img1Name"] = spic;
                        spic = Global_Upload.GuangGaoImgPath + spic;
                        ViewState["guangGaoImg1"] = spic;
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "overKeyWordDiv();", true);
        }

        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string sear()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if(txtKey.Text.Trim() != "")
            {
                sb.Append(" and (title like '%" + txtKey.Text.Trim() + "%' or comName like '%" + txtKey.Text.Trim() + "%' or relUser like '%" + txtKey.Text.Trim() + "%' or placeName like '%" + txtKey.Text.Trim() + "%')");
            }
            if(ddlSelTimeStr.SelectedValue != "0")
            {
                sb.Append(" and infoType = " + ddlSelTimeStr.SelectedValue);
            }
            //if(txtStartTime.Text.Trim() != "")
            //{
            //    sb.Append(" and timeFrom <= '" + txtStartTime.Text.Trim() + "'");
            //}
            return sb.ToString();
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            sp.InitBindData(repInfo, pager1, "GuangGao", "id", sear());
        }
        
        /// <summary>
        /// 添加人姓名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected string GetUserName(object userId)
        {
            AdminUser au = AdminUserService.GetModel(Convert.ToInt32(userId));
            if(au != null)
            {
                return au.realName;
            }
            return "";
        }
        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ViewState["guangGaoImg1"] == null)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('请上传广告图片!');", true);
                return;
            }
            string linkUrl = this.txtLinkurl.Text.Trim();
            string comName = this.txtComName.Text.Trim();
            string relUser = this.txtRelUser.Text.Trim();
            string tel = txtTel.Text.Trim();
            string order = txtOrder.Text.Trim();
            if(comName.Length == 0 || tel.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('投放企业和联系方式不能为空!');", true);
                return;
            }
            if (!RegExp.IsNumeric(order))
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('顺序号信息有误!');", true);
                return;
            }
            GuangGao item = new GuangGao();
            item.imgUrl = ViewState["guangGaoImg1"].ToString();
            item.title = comName;
            item.alt = comName;
            item.linkurl = linkUrl;
            item.comName = comName;
            item.relUser = relUser;
            item.tel = tel;
            item.timeStr = ddlTimeStr.SelectedItem.Text;
            item.infoType = Convert.ToInt32(ddlTimeStr.SelectedValue);
            item.timeFrom = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            item.timeEnd = Convert.ToDateTime(DateTime.Now.AddMonths(item.infoType).ToString("yyyy-MM-dd"));
            item.placeSite = Convert.ToInt32(ddlPlace.SelectedValue);
            item.placeName = ddlPlace.SelectedItem.Text;
            item.isTj = 0;
            item.isHot = 0;
            item.isNew = 0;
            if(order != "")
            {
                item.isNew = Convert.ToInt32(order);
            }
            item.views = 0;
            item.status = 0;
            item.remark = "";
            item.addTime = DateTime.Now;
            if (Session["loginUser"] == null)
            {
                Response.Redirect("/admin/login.aspx");
                return;
            }
            AdminUser admin = Session["loginUser"] as AdminUser;
            item.addUser = admin.id;
            if (ViewState["modId"] != null)
            {
                item.id = Convert.ToInt32(ViewState["modId"]);
                GuangGaoService.Update(item);
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');", true);
            }
            else
            { 
                int num = GuangGaoService.Add(item);
            }

            sp.InitBindData(repInfo, pager1, "GuangGao", "id", sear());
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');", true);
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
                GuangGaoService.Delete(id);
                sp.InitBindData(repInfo, pager1, "GuangGao", "id", sear());
            }
            if(e.CommandName.Equals("mod"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                GuangGao item = GuangGaoService.GetModel(id);
                if(item != null)
                {
                    ViewState["guangGaoImg1"] = item.imgUrl;
                    txtLinkurl.Text = item.linkurl;
                    txtComName.Text = item.comName;
                    txtRelUser.Text = item.relUser;
                    txtTel.Text = item.tel;
                    txtOrder.Text = item.isNew.ToString();
                    ddlPlace.SelectedValue = item.placeSite.ToString();
                    ddlTimeStr.SelectedValue = item.infoType.ToString();
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "overKeyWordDiv();", true);
                }
                ViewState["modId"] = id;
                
                
            }
        }
       
       
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            sp.InitBindData(repInfo, pager1, "GuangGao", "id", sear());
        }


        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("guangGaoInfo.aspx");
        }

        /// <summary>
        /// 获取选择的信息
        /// </summary>
        /// <returns></returns>
        private string selInfo()
        {
            string Id = "";//获取当前选中的ID                       
            for (int i = 0; i < this.repInfo.Items.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.repInfo.Items[i].FindControl("cbxAll");
                if (ckb.Checked)
                {
                    Id += (this.repInfo.Items[i].FindControl("lblId") as Label).Text + ",";
                }
            }
            return Id;

        }       

    }
}