using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.Text;
using System.IO;
using DAL;
using System.Data;
using Model;

namespace CommonBussiness.mobile
{
    public partial class createOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            #region 生成订单
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                OrderInfo order = new OrderInfo();
                order.orderNo = "";
                order.orderName = user.relName + "在Plate-X订单";
                order.proTotal = 0;
                order.sendTotal = 0;
                order.orderTotal = 0;
                double total = 0;
                DataSet ds = CartTempService.GetList("addUser = " + user.id);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        total += Convert.ToDouble(dr["remark"]);
                    }
                }
                order.orderTotal = Math.Round(total, 2);
                order.orderDesc = "";
                order.remark = order.orderName + ",订单日期：" + DateTime.Now.ToString("yyyy-MM-dd");
                order.recieveUser = user.relName;
                order.pid = 0;
                order.cid = 0;
                order.regionId = 0;
                order.PName = "";
                order.CName = "";
                order.ReginName = "";
                order.address = "";
                order.mobile = user.mobile;
                order.tel = "";
                order.status = 0;
                order.addTime = DateTime.Now;
                order.infoType = 0;
                order.addUser = user.id;
                int maxId = OrderService.Add(order);

                //生成二维码：
                //string ranStr = Rand.GetMixPwd(10);
                //string websiteUrl = BaseConfigService.GetById(12);
                //string userUrlStr = "";

                // websiteUrl + "/mychat.aspx?orderId=" + maxId;
                //weixin：//wxpay/bizpayurl?appid=wx8a02513b182f68af&mch_id=1372977102&nonce_str=" + ranStr + "&product_id=" + maxId + "&time_stamp=" + DateTime.Now.ToString("yyyyMMddhhmm") + "&sign=
                string url = "";// create_two(userUrlStr, maxId);


                order.orderDesc = url;

                order.orderNo = maxId + DateTime.Now.ToString("yyyyMMdd") + user.id + DateTime.Now.ToString("hhmmss");
                int rows = OrderService.UpdateOrderNo(maxId, order.orderNo, order.orderDesc);
                if (rows > 0)
                {
                    #region 订单详细
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach(DataRow dr in ds.Tables[0].Rows)
                        {
                            int productId = Convert.ToInt32(dr["productId"]);
                            Product item = ProductService.GetModel(productId);
                            if (item != null)
                            {
                                #region 订单详细表
                                OrderDetail od = new OrderDetail();
                                od.orderId = maxId;
                                od.orderNo = order.orderNo;
                                od.productId = productId;
                                od.productCount = Convert.ToInt32(dr["productCount"]);
                                od.isActive = 0;
                                od.activeCode = "";
                                od.activeMoney = 0;
                                od.total = Convert.ToDouble(dr["remark"]);
                                od.satus = 0;
                                od.remark = "";
                                od.infoType = 0;
                                OrderDetailService.Add(od);
                                #endregion

                                //清空临时表信息
                                CartTempService.DeleteByUserId(user.id, productId);
                            }
                        }
                        
                    }
                    
                    #endregion
                }
                Response.Redirect("orders_99.html");
            }
            #endregion

        }
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="nr"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private string create_two(string nr, int id)
        {
            Bitmap bt;
            string enCodeString = nr;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
            if (!Directory.Exists(Server.MapPath("/upload/erweiImg/")))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("/upload/erweiImg/"));
            }
            try
            {
                ////如果存在就Delete，重新生成
                if (System.IO.File.Exists(Server.MapPath("/upload/erweiImg/") + id + ".jpg"))
                {
                    System.IO.File.Delete(Server.MapPath("/upload/erweiImg/") + id + ".jpg");
                }
                bt.Save(Server.MapPath("/upload/erweiImg/") + id + ".jpg");
            }
            catch (Exception je)
            {

            }

            bt.Dispose();

            return "/upload/erweiImg/" + id + ".jpg";
        }
    }
}