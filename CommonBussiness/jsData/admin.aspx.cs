using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Net.Mail;
using System.Data;
using System.Text;

namespace CommonBussiness.jsData
{
    public partial class admin : System.Web.UI.Page
    {
        
        string action = CRequest.GetString("action");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (action.Equals("SinaLogin")) 
                {
                    SinaLogin();
                }
                if (action.Equals("Share")) 
                {
                    Share();
                }
                if (action.Equals("replyComment"))
                {
                    ReplyComment();
                }
                if (action.Equals("updateViewsCount")) 
                {
                    updateViewsCount();
                }
                
                if (action.Equals("UseOrStopMem"))
                {
                    UseOrStopMem();
                }
                if (action.Equals("SetPass"))
                {
                    SetPass();
                }
                if (action.Equals("DelNews"))
                {
                    DeleteInfo();
                }                
            }
        }
        /// <summary>
        /// 新浪授权登陆
        /// </summary>
        private void SinaLogin() 
        {
            
        }
        /// <summary>
        /// 分享更新
        /// </summary>
        private void Share()
        {
            int id = CRequest.GetInt("id",0);
            //int num = NewsService.Share(id);
            Response.Write("success");
        }
        /// <summary>
        /// 回复评价信息
        /// </summary>
        private void ReplyComment()
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user == null)
            {
                Response.Write("login");
            }
            else
            {
                int id = CRequest.GetInt("id", 0);
                string replyContent = CRequest.GetString("replyContent");
                Reply item = new Reply();
                item.commentId = id;
                Comment comItem = CommentService.GetModel(id);
                if(comItem.addUser == user.id)
                {
                    Response.Write("self");
                    return;
                }
                item.replyContent = replyContent;
                item.status = 0;
                item.remark = "";
                item.addTime = DateTime.Now;
                item.addUser = user.id;
                item.infoType = 0;
                
                int num = ReplyService.Add(item);
                StringBuilder sb = new StringBuilder();
                if (num > 0)
                {
                    DataSet ds = ReplyService.GetList("commentId = " + id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            UserInfo replyUser = UserInfoService.GetModel(Convert.ToInt32(dr["addUser"]));
                            if(replyUser != null)
                            {
                                sb.Append(replyUser.username + "：" + dr["replyContent"].ToString() + "<br/>");
                            }                            
                        }
                    }
                }
                Response.Write(sb.ToString());
            }
            
        }
        /// <summary>
        /// 更新资讯的浏览次数
        /// </summary>
        private void updateViewsCount() 
        {
            int id = CRequest.GetInt("id",0);
            NewsService.UpdateViews(id);
            News item = NewsService.GetModel(id);
            if (item != null)
            {
                Response.Write(item.res_views);
            }
            else
            {
                Response.Write("0");
            }
        }
       

        /// <summary>
        /// Delete信息
        /// </summary>
        private void DeleteInfo()
        {
            int id = CRequest.GetInt("id", 0);
            int num = NewsService.Delete(id);
            if (num > 0)
            {
                
                Response.Redirect("/admin/infoList.aspx");
                //Jscript.AlertAndRedirect("Delete成功","");
            }
        }


        #region 邮件发送
        protected bool User_SendMail(string host, string uid, string pwd, string to, string subject, string body)
        {
            //添加附件需将(附件先Upload到服务器)
            //        System.Net.Mail.Attachment data = new System.Net.Mail.Attachment(@"UpFile\fj.rar",
            //System.Net.Mime.MediaTypeNames.Application.Octet);
            //message.Attachments.Add(data);
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = host;// "mail.summerpalace-china.com";
                client.UseDefaultCredentials = false;

                client.Credentials = new System.Net.NetworkCredential(uid, pwd);//("info@summerpalace-china.com", "summerSiteDB");
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(uid, to);//("info@summerpalace-china.com", to);
                message.Subject = subject;
                message.Body = body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                throw;
                //return false;
            }
        }
        #endregion


        /// <summary>
        /// 重置Password
        /// </summary>
        private void SetPass() 
        {
            //int id = CRequest.GetInt("id", 0);
            //string email = CRequest.GetString("email");
            //string active = encrypt.EncryptMd5(id + "_" + email).ToUpper();
            //int num = UserInfoService.UpdateActiveLink(id, active);
            //UserInfo user = UserInfoService.GetModel(id);
            //if (num > 0)
            //{
            //    string activeStr = "<a href='http://www.rrb365.com/forgetPasswordReset.aspx?active=" + active + "&id=" + user.id + "' target='_blank'>http://www.rrb365.com/" + user.md5Pass.ToUpper() + encrypt.EncryptMd5("password").ToUpper() + user.activeStr + "</a>";
            //    bool flag = this.User_SendMail("smtp.exmail.qq.com", "service@rrb365.com", "manpower1711", email, "人人保网站找回Password通知", "请点击下面的链接Verification Code：<br/>" + activeStr);
            //    #region  日志
            //    LogInfo log = new LogInfo();
            //    if (Session["loginUser"] == null)
            //    {
            //        Response.Redirect("/admin/login.aspx");
            //        return;
            //    }
            //    AdminUser admin = Session["loginUser"] as AdminUser;
            //    log.typeId = 1;
            //    log.block = 1;
            //    log.blockSon = 1;
            //    log.doneType = 5;
            //    log.status = 0;
            //    log.remark = "";

            //    log.userId = admin.id;
            //    log.realName = admin.realName;
            //    log.doDesc = "后台重置用户ID=" + id + "用户Password";
            //    log.addTime = DateTime.Now;
            //    log.ipAddress = IpSearch.GetIp();
            //    LogInfoService.Add(log);
            //    #endregion
            //    Jscript.AlertAndRedirect("重置Password连接已发送到客户邮箱", "/admin/user.aspx?pageIndex=" + CRequest.GetInt("pageIndex", 0));

            //}
            //else
            //{
            //    Jscript.AlertAndRedirect("重置Password连接发送失败", "/admin/user.aspx?pageIndex=" + CRequest.GetInt("pageIndex", 0));
            //}
            
        }
        /// <summary>
        /// 启用或停用会员
        /// </summary>
        private void UseOrStopMem() 
        {
            //int id = CRequest.GetInt("id",0);
            //int status = CRequest.GetInt("status",0);
            //if(status != 3)
            //{
            //    status = 3;
            //}else
            //{
            //    status = 2;
            //}
            //int num = UserInfoService.UpdateStatus(id,status);
            //Response.Redirect("/admin/user.aspx?pageIndex=" + CRequest.GetInt("pageIndex", 0));
            //#region  日志
            //LogInfo log = new LogInfo();
            //if (Session["loginUser"] == null)
            //{
            //    Response.Redirect("/admin/login.aspx");
            //    return;
            //}
            //AdminUser admin = Session["loginUser"] as AdminUser;
            //log.typeId = 1;
            //log.block = 1;
            //log.blockSon = 1;
            //log.doneType = 5;
            //log.status = 0;
            //log.remark = "";

            //log.userId = admin.id;
            //log.realName = admin.realName;
            //log.doDesc = "后台批量启用/停用用户ID=" + id + "用户";
            //log.addTime = DateTime.Now;
            //log.ipAddress = IpSearch.GetIp();
            //LogInfoService.Add(log);
            //#endregion
        }
    }
}