using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Text;
using System.Net;
using System.IO;
using Aliyun.Acs.Core.Exceptions;

using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core;

namespace CommonBussiness.mobile
{
    public partial class findpass : System.Web.UI.Page
    {
        static String product = "Dysmsapi";//短信API产品Item Name
        static String domain = "dysmsapi.aliyuncs.com";//短信API产品域名
        static String accessId = "LTAI4GDo5Rcso77WY8SnA7wb";
        static String accessSecret = "Yj71lRSbBSVTT018rly629xmQGhL5O";
        static String regionIdForPop = "cn-hangzhou";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KeyWordBind();

                Timer1.Enabled = false;
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
        /// 获取Text Verification Code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnGetCode_Click(object sender, EventArgs e)
        {
            // lbtnGetCode.Text = "";
            string mobile = "1" + this.tel.Text.Trim();
            if (mobile.Length == 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('Phone Can not Be Blank！');", true);
                return;
            }
            if (mobile.Length != 11)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('The Phone is wrong！');", true);
                return;
            }
            if(!UserInfoService.Exists(mobile))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('Phone number does not exist！');", true);
                return;
            }
            ViewState["time"] = null;
            Timer1.Enabled = true;
            Timer1.Interval = 1000;
            Random ran = new Random();
            int num = ran.Next(105000, 999999);
            MessageCode item = new MessageCode();
            item.mobile = mobile;
            item.code = num.ToString();
            item.status = 0;
            item.remark = "";
            item.addTime = DateTime.Now;
            item.infoType = 1;
            int maxId = MessageCodeService.Add(item);
            if (maxId > 0)
            {
                IClientProfile profile = Aliyun.Acs.Core.Profile.DefaultProfile.GetProfile(regionIdForPop, accessId, accessSecret);
                Aliyun.Acs.Core.Profile.DefaultProfile.AddEndpoint(regionIdForPop, regionIdForPop, product, domain);
                IAcsClient acsClient = new DefaultAcsClient(profile);
                SendSmsRequest request = new SendSmsRequest();
                try
                {
                    //request.SignName = "上云预发测试";//"管理控制台中配置的短信签名（状态必须是验证通过）"
                    //request.TemplateCode = "SMS_71130001";//管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）"
                    //request.RecNum = "13567939485";//"接收号码，多个号码可以逗号分隔"
                    //request.ParamString = "{\"name\":\"123\"}";//短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。"
                    //SingleSendSmsResponse httpResponse = client.GetAcsResponse(request);
                    request.PhoneNumbers = mobile;
                    request.SignName = "PlateX";
                    request.TemplateCode = "SMS_188556279";
                    request.TemplateParam = "{\"code\":\"" + num + "\"}";
                    request.OutId = DateTime.Now.ToString("yyyyMMddHHmmss"); //"xxxxxxxx";
                    //请求失败这里会抛ClientException异常
                    SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                    string mess = sendSmsResponse.Message;
                    //Response.Write(mess);
                    System.Console.WriteLine(mess);
                    ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert(' Verification Code Sent！');", true);
                }
                catch (ServerException je)
                {
                  
                    ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('Verification Code Failed to Send！');", true);

                    //System.Console.WriteLine("ServerException");
                }
                catch (ClientException ne)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "", "alert('Verification Code Failed to Send！');", true);
                }
            }
        }
        /// <summary>
        /// 计时器触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            int time = 60;
            if (ViewState["time"] != null)
            {
                time = Convert.ToInt32(ViewState["time"]);
            }
            if (time == 0)
            {
                Timer1.Enabled = false;
                lbtnGetCode.Enabled = true;
                lbtnGetCode.Text = "Send Verification Code";
                return;
            }
            this.lbtnGetCode.Text = time + " Seconds";
            lbtnGetCode.Enabled = false;
            ViewState["time"] = time - 1;
        }
    }
}