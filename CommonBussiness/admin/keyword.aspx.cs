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
using System.Net;
using System.IO;

namespace CommonBussiness.admin
{
    public partial class keyword : System.Web.UI.Page
    {
        Page_ZH sp = new Page_ZH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                sp.InitBindData(Repeater1, pager1, "KeyWordInfo", "id", "1=1");
            }
        }
        
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            sp.InitBindData(Repeater1, pager1, "KeyWordInfo", "id", "1=1");
        }

        /// <summary>
        /// 控件绑定事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int num = KeyWordInfoService.Delete(id);
                if (num > 0)
                {
                    
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除成功!');", true);
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('删除失败，请重试！');", true);
                    
                }
                sp.InitBindData(Repeater1, pager1, "KeyWordInfo", "id", "1=1");
            }
            else if(e.CommandName == "mod")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                KeyWordInfo item = KeyWordInfoService.GetModel(id);
                if(item != null)
                {
                    txtPageName.Text = item.pageName;
                    txtTitle.Text = item.title;
                    txtKeyWord.Text = item.keyword;
                    txtDesc.Text = item.description;
                    txtURL.Text = item.pageNameValue;
                    ViewState["modId"] = item.id;
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "overKeyWordDiv();", true);
                }
            }
            
        }


        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string name = this.txtPageName.Text.Trim();
            string title = this.txtTitle.Text.Trim();
            string keyword = this.txtKeyWord.Text.Trim();
            string description = this.txtDesc.Text.Trim();
            string url = this.txtURL.Text.Trim();

            KeyWordInfo item = new KeyWordInfo();
            item.pageName = name;
            item.title = title;
            item.keyword = keyword;
            item.description = description;
            item.pageNameValue = url;
            if (ViewState["modId"] != null)
            {
                item.id = Convert.ToInt32(ViewState["modId"]);
                int num = KeyWordInfoService.Update(item);
                if (num > 0)
                {
                    
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');", true);
                    txtPageName.Text = "";
                    txtTitle.Text = "";
                    txtKeyWord.Text = "";
                    txtDesc.Text = "";
                    txtURL.Text = "";
                }
                ViewState["modId"] = null;
            }
            else
            {
                if(KeyWordInfoService.Exists(item.pageNameValue))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('信息已存在!');", true);
                    return;
                }
                int num = KeyWordInfoService.Add(item);
                if (num > 0)
                {
                    
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "alert('保存成功!');", true);
                    txtPageName.Text = "";
                    txtTitle.Text = "";
                    txtKeyWord.Text = "";
                    txtDesc.Text = "";
                    txtURL.Text = "";
                }
            }
            sp.InitBindData(Repeater1, pager1, "KeyWordInfo", "id", "1=1");
            
        }
       /// <summary>
       /// 页面关键字统计
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            //string pageStr = GetStr(url, "utf-8");

            //StringBuilder sb = new StringBuilder();
            //foreach (char ch in pageStr)
            //{
            //    if (Convert.ToInt32(ch) > 125)
            //    {
            //        if (Convert.ToInt32(ch) != 65288 || Convert.ToInt32(ch) != 65289)
            //        {
            //            sb.Append(ch.ToString());
            //        }

            //    }
            //}


            //pageStr = sb.ToString();
            //ViewState["pageTextAllLength"] = pageStr.Length;
            //ViewState["keywordLength"] = keyword.Length;
            //string sss = pageStr;

            //sss = sss.Replace(keyword, keyword + "a");
            //string[] arr = sss.Split('a');

            //ViewState["keywordCount"] = arr.Length - 1;
            //ViewState["keywordAllLength"] = (arr.Length - 1) * keyword.Length;

            //ViewState["keywordMiDu"] = Math.Round((Convert.ToDouble(ViewState["keywordAllLength"]) * 100 / pageStr.Length), 2);
            //this.tjKey.Visible = true;
        }
        /// <summary>
        /// 字符串长度信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="pagecode"></param>
        /// <returns></returns>
        private string GetStr(string url, string pagecode)
        {
            string str = "";
            try
            {

                Encoding encode = Encoding.GetEncoding(pagecode);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = 100000;
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), encode);
                str = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }
            catch (Exception je)
            {
                Response.Write(je.ToString());
            }
            return str;
        }

    }
}