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
using System.Data;
using System.Security.Cryptography;

namespace CommonBussiness.admin
{
    public partial class selOrderStatus : System.Web.UI.Page
    {
        int orderId = CRequest.GetInt("orderId", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OrderInfo order = OrderService.GetModel(orderId);
                if (order != null)
                {
                    string url = "https://api.mch.weixin.qq.com/pay/orderquery";
                    string appid = "wx8a02513b182f68af";
                    string mch_id = "1372977102";
                    string device_info = "WEB";
                    string nonce_str = "ibuaiVcKdpRxkhJA";// Rand.GetMixPwd(20);
                    string body = "test";
                    UserInfo user = Session["user"] as UserInfo;
                    if (user != null)
                    {
                        body = user.relName + "在Plate-X订单";
                    }


                    //string partnerKey = "ipEfo8DYseX4ZgBaerAveGNegZijUuya";
                    //string stringA = "appid=" + appid + "&body=" + body + "&device_info=" + device_info + "&mch_id=" + mch_id + "&nonce_str=" + nonce_str;

                    //string strSginTemp = string.Format("{0}&key={1}", stringA, partnerKey);//这个是在线生成的32为密钥，//8a4356d650495c51ba8c33ec5bebec38这个是公众号密钥
                    //string sign = encrypt.EncryptMd5(strSginTemp);//.ToUpper();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    sb.Append("\"goods_detail\":[");
                    #region 主题
                    DataSet ds = OrderDetailService.GetList("orderId = " + orderId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Product item = ProductService.GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["productId"]));
                            if (i == ds.Tables[0].Rows.Count - 1)
                            {
                                if (item != null)
                                {
                                    sb.Append("{");
                                    sb.Append("\"goods_id\":\"" + item.proName + "\",");
                                    sb.Append("\"wxpay_goods_id\":\"" + item.id + "\",");
                                    sb.Append("\"goods_name\":\"" + item.proName + "\",");
                                    sb.Append("\"goods_num\":" + ds.Tables[0].Rows[i]["productCount"] + ",");
                                    sb.Append("\"price\":" + item.price1 + ",");
                                    sb.Append("\"goods_category\":\"" + item.productType + "\",");
                                    sb.Append("\"body\":\"" + item.proName + "\"");
                                    sb.Append("}");
                                }
                            }
                            else
                            {
                                if (item != null)
                                {
                                    sb.Append("{");
                                    sb.Append("\"goods_id\":\"" + item.proName + "\",");
                                    sb.Append("\"wxpay_goods_id\":\"" + item.id + "\",");
                                    sb.Append("\"goods_name\":\"" + item.proName + "\",");
                                    sb.Append("\"goods_num\":" + ds.Tables[0].Rows[i]["productCount"] + ",");
                                    sb.Append("\"price\":" + item.price1 + ",");
                                    sb.Append("\"goods_category\":\"" + item.productType + "\",");
                                    sb.Append("\"body\":\"" + item.proName + "\"");
                                    sb.Append("},");
                                }
                            }

                        }
                    }
                    #endregion
                    sb.Append("]");
                    sb.Append("}");
                    string detail = sb.ToString();
                    string out_trade_no = order.orderNo;
                    double total_fee = order.orderTotal * 100;

                    string spbill_create_ip = "111.192.87.249"; //IpSearch.GetIp();

                    string time_start = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string notify_url = "http://iyuanxiang.com.cn/payInfo/yx_mychat_back.aspx";
                    string trade_type = "NATIVE";

                    string partnerKey = "ipEfo8DYseX4ZgBaerAveGNegZijUuya";
                    string stringA = "appid=" + appid;
                    stringA += "&body=" + body;
                    stringA += "&device_info=" + device_info;
                    stringA += "&mch_id=" + mch_id;
                    stringA += "&nonce_str=" + nonce_str;

                    stringA += "&notify_url=" + notify_url;



                    stringA += "&out_trade_no=" + out_trade_no;

                    stringA += "&spbill_create_ip=" + spbill_create_ip;


                    stringA += "&total_fee=" + total_fee;
                    stringA += "&trade_type=" + trade_type;

                    string strSginTemp = string.Format("{0}&key={1}", stringA, partnerKey);//这个是在线生成的32为密钥，//8a4356d650495c51ba8c33ec5bebec38这个是公众号密钥
                    string sign = MD5(strSginTemp).ToUpper(); ;//.ToUpper();


                    int product_id = order.id;

                    #region 生成XML
                    StringBuilder sb2 = new StringBuilder();
                    sb2.Append("<xml>");
                    sb2.Append("<appid>" + appid + "</appid>");
                    sb2.Append("<mch_id>" + mch_id + "</mch_id>");
                    sb2.Append("<nonce_str>" + nonce_str + "</nonce_str>");

                    sb2.Append("<out_trade_no>" + out_trade_no + "</out_trade_no>");
                    sb2.Append("<sign>" + sign + "</sign>");
                    sb2.Append("</xml>");

                    #endregion

                    Encoding encode = Encoding.GetEncoding("utf-8");
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    Response.Charset = "utf-8";
                    req.Method = "post";
                    req.ContentType = "application/x-www-form-urlencoded";
                    string str = sb2.ToString();
                    req.ContentLength = str.Length;
                    req.Timeout = 100000;
                    Stream newStream = req.GetRequestStream();
                    // Send the data.   
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] postdata = encoding.GetBytes(str);

                    newStream.Write(postdata, 0, str.Length);
                    newStream.Close();
                    // Get response   
                    HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();
                    StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding("utf-8"));

                    string content = reader.ReadToEnd();//得到二维码地址结果  


                    Response.Write(content);
                }
            }
        }

        #region 辅助方法

        public static string MD5(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(pwd);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str;
        }
        #endregion
    }
}