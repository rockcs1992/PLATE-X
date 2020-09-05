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
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;


namespace CommonBussiness.jsData
{
    public partial class order : System.Web.UI.Page
    {
        string action = CRequest.GetString("action");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                #region 功能方法
                if (action.Equals("SaveOrderPCRightNow1"))
                {
                    SaveOrderPCRightNow1();
                }
                if (action.Equals("SaveOrderPCRightNow"))
                {
                    SaveOrderPCRightNow();
                }
                if (action.Equals("AddToCartIndexNewDetail")) 
                {
                    AddToCartIndexNewDetail();
                }
                if (action.Equals("SaveComment")) 
                {
                    SaveComment();
                }
                if (action.Equals("UpdateSel")) 
                {
                    UpdateSel();
                }
                if (action.Equals("PaySuccess"))
                {
                    PaySuccess();
                }
                if (action.Equals("AddToCartProductDetail")) 
                {
                    AddToCartProductDetail();
                }
                if (action.Equals("SaveOrderMobile")) 
                {
                    SaveOrderMobile();
                }
                if (action.Equals("AddToCartIndexNew"))
                {
                    AddToCartIndexNew();
                }
                if (action.Equals("AddCartIndex"))
                {
                    AddCartIndex();
                }
                

                if (action.Equals("UpdateCartCount")) 
                {
                    UpdateCartCount();
                }
                if (action.Equals("SaveInvoice"))
                {
                    SaveInvoice();
                }
                if (action.Equals("RecieveOrder")) 
                {
                    RecieveOrder();
                }
                if (action.Equals("RightNow"))
                {
                    RightNow();
                }
                if (action.Equals("PreOrder"))
                {
                    PreOrder();
                }
                if (action.Equals("SaveOrder"))
                {
                    SaveOrder();
                }
                if (action.Equals("CancelOrder"))
                {
                    CancelOrder();
                }
                if (action.Equals("DelCartTemp")) 
                {
                    DelCartTemp();
                }
                if (action.Equals("AddCart")) 
                {
                    AddCart();
                }
                #endregion
            }
        }
        /// <summary>
        /// Save订单
        /// </summary>
        private void SaveOrderPCRightNow1()
        {
            string hidAddrId = CRequest.GetString("hidAddrId");
            string sendDate = CRequest.GetString("sendDate");

            string hidTicketUse = CRequest.GetString("hidTicketUse");
            string hidCardUse = CRequest.GetString("hidCardUse");
            string hidScoreUse = CRequest.GetString("hidScoreUse");
            string hidBalanceUse = CRequest.GetString("hidBalanceUse");

            string zhekou = CRequest.GetString("zhekou");
            string fact = CRequest.GetString("orderTotal");
            int zhekouType = 0;
            if (hidTicketUse == "1")
            {
                zhekouType = 1;
            }
            if (hidCardUse == "1")
            {
                zhekouType = 2;
            }
            if (hidScoreUse == "1")
            {
                zhekouType = 3;
            }
            if (hidBalanceUse == "1")
            {
                zhekouType = 4;
            }
            //string proTotal = CRequest.GetString("hidProTotal");
            #region 生成订单
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                #region 封装订单
                OrderInfo order = new OrderInfo();
                order.orderNo = "";
                order.orderName = user.relName + "在Plate-X订单";

                order.sendTotal = Convert.ToDouble(zhekou);
                order.orderTotal = Convert.ToDouble(fact);
                if (order.orderTotal < 0)
                {
                    order.orderTotal = 0;
                }
                order.proTotal = order.sendTotal + order.orderTotal;
                order.orderDesc = "";
                order.remark = order.orderName + ",订单日期：" + DateTime.Now.ToString("yyyy-MM-dd");
                order.recieveUser = user.relName;
                order.pid = 0;
                if (hidAddrId != "")
                {
                    order.pid = Convert.ToInt32(hidAddrId);
                }
                
                order.cid = zhekouType;
                order.regionId = 0;
                string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                string week = Day[Convert.ToInt32(Convert.ToDateTime(sendDate.Substring(0, 10)).DayOfWeek.ToString("d"))].ToString();

                order.PName = Convert.ToDateTime(sendDate.Substring(0, 10)).ToString("yyyy年MM月dd日") + "(" + week + ")";

                order.CName = "";
                order.ReginName = "";
                order.address = "";
                order.mobile = user.mobile;
                order.tel = "";
                order.status = 0;
                if (order.orderTotal == 0)
                {
                    order.status = 1;
                }
                order.addTime = DateTime.Now;
                order.infoType = 0;
                order.addUser = user.id;
                int maxId = OrderService.Add(order);
                string url = "";// create_two(userUrlStr, maxId);
                order.id = maxId;

                order.orderDesc = url;

                order.orderNo = maxId + DateTime.Now.ToString("yyMMdd") + user.id + DateTime.Now.ToString("HHmm");
                int rows = OrderService.UpdateOrderNo(maxId, order.orderNo, order.orderDesc);
                if (rows > 0)
                {
                    #region 订单详细表
                    DataSet ds = CartTempService.GetList("addUser = " + user.id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int pid = Convert.ToInt32(dr["productId"]);
                            int count = Convert.ToInt32(dr["productCount"]);
                            int priceS = Convert.ToInt32(dr["status"]);
                            OrderDetail od = new OrderDetail();
                            od.orderId = maxId;
                            od.orderNo = order.orderNo;
                            od.productId = pid;
                            od.productCount = count;

                            od.isActive = 0;
                            od.activeCode = "";
                            od.activeMoney = 0;
                            od.total = 0;
                            Product item = ProductService.GetModel(pid);
                            if (item != null)
                            {
                                if (priceS == 1)
                                {
                                    od.activeMoney = item.price1;
                                    od.total = item.price1 * count;
                                }
                                if (priceS == 2)
                                {
                                    od.activeMoney = item.price2;
                                    od.total = item.price2 * count;
                                }
                                if (priceS == 3)
                                {
                                    od.activeMoney = item.price3;
                                    od.total = item.price3 * count;
                                }
                                if (priceS == 4)
                                {
                                    od.activeMoney = item.price4;
                                    od.total = item.price4 * count;
                                }
                            }

                            od.satus = order.status;
                            od.remark = "";
                            od.infoType = 0;
                            OrderDetailService.Add(od);
                        }
                    }

                    #endregion

                    ///Delete购物车中的商品
                    CartTempService.DeleteByUserIdRightNow(user.id);
                    ///更新发票的订单信息
                    

                }
                Response.Write(maxId.ToString());
                #endregion
            }
            else
            {
                Response.Write("nologin");
            }
            #endregion
        }
        /// <summary>
        /// Save订单
        /// </summary>
        private void SaveOrderPCRightNow()
        {
            string hidAddrId = CRequest.GetString("hidAddrId");
            string sendDate = CRequest.GetString("sendDate");

            string hidTicketUse = CRequest.GetString("hidTicketUse");
            string hidCardUse = CRequest.GetString("hidCardUse");
            string hidScoreUse = CRequest.GetString("hidScoreUse");
            string hidBalanceUse = CRequest.GetString("hidBalanceUse");

            string zhekou = CRequest.GetString("zhekou");
            string fact = CRequest.GetString("orderTotal");
            int zhekouType = 0;
            if (hidTicketUse == "1")
            {
                zhekouType = 1;
            }
            if (hidCardUse == "1")
            {
                zhekouType = 2;
            }
            if (hidScoreUse == "1")
            {
                zhekouType = 3;
            }
            if (hidBalanceUse == "1")
            {
                zhekouType = 4;
            }
            //string proTotal = CRequest.GetString("hidProTotal");
            #region 生成订单
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                #region 封装订单
                OrderInfo order = new OrderInfo();
                order.orderNo = "";
                order.orderName = user.relName + "在Plate-X订单";
                
                order.sendTotal = Convert.ToDouble(zhekou);
                order.orderTotal = Convert.ToDouble(fact);
                if (order.orderTotal < 0)
                {
                    order.orderTotal = 0;
                }
                order.proTotal = order.sendTotal + order.orderTotal;
                order.orderDesc = "";
                order.remark = order.orderName + ",订单日期：" + DateTime.Now.ToString("yyyy-MM-dd");
                order.recieveUser = user.relName;
                order.pid = 0;
                if (hidAddrId != "")
                {
                    order.pid = Convert.ToInt32(hidAddrId);
                }
                else
                {
                    string location_p = CRequest.GetString("location_p");
                    string location_c = CRequest.GetString("location_c");
                    string location_a = CRequest.GetString("location_a");
                    string address = CRequest.GetString("address");

                    string name = CRequest.GetString("name");
                    string labelname = CRequest.GetString("labelname");

                    string mobile = CRequest.GetString("mobile");
                    string telephone = CRequest.GetString("telephone");

                    UserAddress ua = new UserAddress();
                    ua.relName = name;
                    ua.mobile = mobile;
                    ua.tel = telephone;
                    ua.qq = location_p;
                    ua.weixin = location_c;
                    ua.zipcode = location_a;
                    ua.pid = 0;
                    ua.cid = 0;
                    ua.regionId = 0;
                    ua.address = address;
                    ua.addressDetail = labelname;
                    ua.status = 0;
                    ua.remark = "";
                    ua.addTime = DateTime.Now;
                    ua.addUser = user.id;
                    ua.infoType = 1;
                    order.pid = UserAddressService.Add(ua);
                }
                order.cid = zhekouType;
                order.regionId = 0;
                string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                string week = Day[Convert.ToInt32(Convert.ToDateTime(sendDate.Substring(0,10)).DayOfWeek.ToString("d"))].ToString();

                order.PName = Convert.ToDateTime(sendDate.Substring(0,10)).ToString("yyyy年MM月dd日") + "(" + week + ")";

                order.CName = "";
                order.ReginName = "";
                order.address = "";
                order.mobile = user.mobile;
                order.tel = "";
                order.status = 0;
                if (order.orderTotal == 0)
                {
                    order.status = 1;
                }
                order.addTime = DateTime.Now;
                order.infoType = 0;
                order.addUser = user.id;
                int maxId = OrderService.Add(order);
                string url = "";// create_two(userUrlStr, maxId);
                order.id = maxId;

                order.orderDesc = url;

                order.orderNo = maxId + DateTime.Now.ToString("yyMMdd") + user.id + DateTime.Now.ToString("HHmm");
                int rows = OrderService.UpdateOrderNo(maxId, order.orderNo, order.orderDesc);
                if (rows > 0)
                {
                    #region 订单详细表
                    DataSet ds = CartTempService.GetList("addUser = " + user.id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int pid = Convert.ToInt32(dr["productId"]);
                            int count = Convert.ToInt32(dr["productCount"]);
                            int priceS = Convert.ToInt32(dr["status"]);
                            OrderDetail od = new OrderDetail();
                            od.orderId = maxId;
                            od.orderNo = order.orderNo;
                            od.productId = pid;
                            od.productCount = count;

                            od.isActive = 0;
                            od.activeCode = "";
                            od.activeMoney = 0;
                            od.total = 0;
                            Product item = ProductService.GetModel(pid);
                            if (item != null)
                            {
                                if(priceS == 1)
                                {
                                    od.activeMoney = item.price1;
                                    od.total = item.price1 * count;
                                }
                                if (priceS == 2)
                                {
                                    od.activeMoney = item.price2;
                                    od.total = item.price2 * count;
                                }
                                if (priceS == 3)
                                {
                                    od.activeMoney = item.price3;
                                    od.total = item.price3 * count;
                                }
                                if (priceS == 4)
                                {
                                    od.activeMoney = item.price4;
                                    od.total = item.price4 * count;
                                }
                            }

                            od.satus = order.status;
                            od.remark = "";
                            od.infoType = 0;
                            OrderDetailService.Add(od);
                        }
                    }

                    #endregion

                    ///Delete购物车中的商品
                    CartTempService.DeleteByUserIdRightNow(user.id);
                    ///更新发票的订单信息
                   

                }
                Response.Write(maxId.ToString());
                #endregion
            }
            else
            {
                Response.Write("nologin");
            }
            #endregion
        }
        /// <summary>
        /// 添加到购物车
        /// </summary>
        private void AddToCartIndexNewDetail()
        {
            int id = CRequest.GetInt("id", 0);
            int procount = CRequest.GetInt("procount", 0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                CartTemp item = new CartTemp();
                #region Log In状态下的
                item.productId = id;
                item.productCount = procount;

                item.addUser = user.id;
                item.status = 1;
                item.remark = "";
                item.sel = 1;
                Product p = ProductService.GetModel(id);
                if (p != null)
                {
                    if (item.status == 1)
                    {
                        item.remark = (p.price1 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 2)
                    {
                        item.remark = (p.price2 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 3)
                    {
                        item.remark = (p.price3 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 4)
                    {
                        item.remark = (p.price4 * item.productCount).ToString("0.00");
                    }

                }
                CartTemp cts = CartTempService.GetModel(item.addUser, item.productId);
                if (cts != null)
                {
                    cts.productCount += item.productCount;
                    cts.remark = (Convert.ToDouble(cts.remark) + Convert.ToDouble(item.remark)).ToString();
                    if (CartTempService.UpdateCart(cts) > 0)
                    {
                        Response.Write(cts.productCount.ToString());
                    }
                    else
                    {
                        Response.Write("0");
                    }
                }
                else
                {
                    int maxId = CartTempService.Add(item);
                    if (maxId > 0)
                    {
                        Response.Write(item.productCount.ToString());
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                #endregion
            }
            else
            {
                List<CartTemp> cartlist = Session["nologinCart"] as List<CartTemp>;
                if (cartlist != null)
                {
                    if (cartlist.Count > 0)
                    {
                        int exists = 0;
                        foreach (CartTemp ct in cartlist)
                        {
                            if (ct.productId == id)
                            {
                                exists = 1;
                                ct.productCount += procount;
                                cartlist.Remove(ct);
                                cartlist.Add(ct);
                                Response.Write(ct.productCount.ToString());
                                break;
                            }
                        }
                        if (exists == 0)
                        {
                            CartTemp ct = new CartTemp();
                            ct.productId = id;
                            ct.productCount = procount;
                            cartlist.Add(ct);
                            Response.Write(ct.productCount.ToString());
                        }

                    }
                    else
                    {
                        CartTemp ct = new CartTemp();
                        ct.productId = id;
                        ct.productCount = procount;
                        cartlist.Add(ct);
                        Response.Write(ct.productCount.ToString());
                    }
                }
                else
                {
                    cartlist = new List<CartTemp>();
                    CartTemp ct = new CartTemp();
                    ct.productId = id;
                    ct.productCount = procount;
                    cartlist.Add(ct);
                    Response.Write(ct.productCount.ToString());
                }
                Session["nologinCart"] = cartlist;
            }
        }

        /// <summary>
        /// Save评论
        /// </summary>
        private void SaveComment()
        {
            int orderId = CRequest.GetInt("orderId", 0);
            int id = CRequest.GetInt("id",0);
            string commentLevel = CRequest.GetString("commentLevel");
            string hidImgUrl = CRequest.GetString("hidImgUrl");
            string messInfo = CRequest.GetString("messInfo");
            Comment item = new Comment();
            item.orderId = orderId;
            item.orderNo = "";
            OrderInfo order = OrderService.GetModel(orderId);
            if(order != null)
            {
                item.orderNo = order.orderNo;
            }
            item.productId = id;
            item.commentType = 0;
            string[] arr2 = commentLevel.Split('_');
            if(arr2.Length > 0)
            {
                item.commentType = Convert.ToInt32(arr2[1]);            
            }
            item.dataType = 1;
            item.fromId = 0;
            item.commentInfo = messInfo;
            item.commentDesc = commentLevel;
            item.img1Url = "";
            item.img2Url = "";
            item.img3Url = "";
            item.img4Url = "";
            string[] arr = hidImgUrl.Trim(',').Split(',');
            if(arr.Length > 0)
            {
                if(arr.Length > 0)
                {
                    item.img1Url = arr[0];
                }
                if (arr.Length > 1)
                {
                    item.img2Url = arr[1];
                }
                if (arr.Length > 2)
                {
                    item.img3Url = arr[2];
                }
                if (arr.Length > 3)
                {
                    item.img4Url = arr[3];
                }
            }
            item.status = 0;
            item.remark = "";
            item.addTime = DateTime.Now;
            item.addUser = 0;
            UserInfo user = Session["user"] as UserInfo;
            if(user != null)
            {
                item.addUser = user.id;
            }
            item.infoType = 0;
            int maxId = CommentService.Add(item);
            if (maxId > 0)
            {
                Response.Write("success");
            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// 更新购物车商品的选中状态
        /// </summary>
        private void UpdateSel()
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user == null)
            {
                int status = CRequest.GetInt("status", 0);
                string tempId = CRequest.GetString("tempId");
                if (tempId.IndexOf("_") != -1)
                {
                    string[] arr = tempId.Split('_');
                    List<CartTemp> cartlist = Session["nologinCart"] as List<CartTemp>;
                    if (cartlist != null)
                    {
                        foreach (CartTemp ct in cartlist)
                        {
                            int index = cartlist.FindIndex(s => s.productId == Convert.ToInt32(arr[1]));
                            if (ct.productId == Convert.ToInt32(arr[1]))
                            {
                                cartlist.Remove(ct);
                                ct.sel = status;
                                cartlist.Insert(index, ct);
                                //cartlist.Add(ct);
                                Session["nologinCart"] = cartlist;
                                break;
                            }
                        }
                    }
                }
                
            }
            else
            {
                int status = CRequest.GetInt("status", 0);
                string tempId = CRequest.GetString("tempId");
                if (tempId.IndexOf("_") != -1)
                {
                    string[] arr = tempId.Split('_');
                    int rows = CartTempService.UpdateSel(Convert.ToInt32(arr[1]), status,user.id);
                    if (rows > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                else
                {
                    Response.Write("fail");
                }
            }
        }
        /// <summary>
        /// 支付成功更新数据库
        /// </summary>
        private void PaySuccess()
        {
           
        }
        /// <summary>
        /// 添加到购物车
        /// </summary>
        private void AddToCartProductDetail()
        {
            int id = CRequest.GetInt("id", 0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                CartTemp item = new CartTemp();
                #region Log In状态下的
                item.productId = id;
                item.productCount = 1;

                item.addUser = user.id;
                item.status = 1;
                item.remark = "";
                item.sel = 1;
                Product p = ProductService.GetModel(id);
                if (p != null)
                {
                    if (item.status == 1)
                    {
                        item.remark = (p.price1 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 2)
                    {
                        item.remark = (p.price2 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 3)
                    {
                        item.remark = (p.price3 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 4)
                    {
                        item.remark = (p.price4 * item.productCount).ToString("0.00");
                    }

                }
                CartTemp cts = CartTempService.GetModel(item.addUser, item.productId);
                if (cts != null)
                {
                    cts.productCount += item.productCount;
                    cts.remark = (Convert.ToDouble(cts.remark) + Convert.ToDouble(item.remark)).ToString();
                    if (CartTempService.UpdateCart(cts) > 0)
                    {
                        Response.Write(cts.productCount.ToString());
                    }
                    else
                    {
                        Response.Write("0");
                    }
                }
                else
                {
                    int maxId = CartTempService.Add(item);
                    if (maxId > 0)
                    {
                        Response.Write(item.productCount.ToString());
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                #endregion
            }
            else
            {
                List<CartTemp> cartlist = Session["nologinCart"] as List<CartTemp>;
                if (cartlist != null)
                {
                    if (cartlist.Count > 0)
                    {
                        int exists = 0;
                        foreach (CartTemp ct in cartlist)
                        {
                            if (ct.productId == id)
                            {
                                exists = 1;
                                ct.productCount++;
                                cartlist.Remove(ct);
                                cartlist.Add(ct);
                                Response.Write(ct.productCount.ToString());
                                break;
                            }
                        }
                        if (exists == 0)
                        {
                            CartTemp ct = new CartTemp();
                            ct.productId = id;
                            ct.productCount = 1;
                            cartlist.Add(ct);
                            Response.Write(ct.productCount.ToString());
                        }

                    }
                    else
                    {
                        CartTemp ct = new CartTemp();
                        ct.productId = id;
                        ct.productCount = 1;
                        cartlist.Add(ct);
                        Response.Write(ct.productCount.ToString());
                    }
                }
                else
                {
                    cartlist = new List<CartTemp>();
                    CartTemp ct = new CartTemp();
                    ct.productId = id;
                    ct.productCount = 1;
                    cartlist.Add(ct);
                    Response.Write(ct.productCount.ToString());
                }
                Session["nologinCart"] = cartlist;
            }
        }

        /// <summary>
        /// Save订单
        /// </summary>
        private void SaveOrderMobile()
        {
            #region 生成订单
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (!CartTempService.ExistsSelProduct(user.id))
                {
                    Response.Write("noproduct");
                    return;
                }
                #region 封装订单
                double total = 0;
                DataSet ds = CartTempService.GetList("addUser = " + user.id + " and sel = 1");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(dr["sel"]) == 1)
                        {
                            total += Convert.ToDouble(dr["remark"]);
                        }
                    }
                }
                OrderInfo order = new OrderInfo();
                order.orderNo = "";
                order.orderName = user.relName + "在Plate-X订单";
                order.proTotal = total;
                order.sendTotal = 0;
                order.orderTotal = order.proTotal + order.sendTotal;
                if(order.orderTotal < 0)
                {
                    order.orderTotal = 0;
                }
                
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
                if(order.orderTotal == 0)
                {
                    order.status = 1;
                }
                order.addTime = DateTime.Now;
                order.infoType = 0;
                order.addUser = user.id;
                int maxId = OrderService.Add(order);
                string url = "";// create_two(userUrlStr, maxId);
                order.id = maxId;

                order.orderDesc = url;

                order.orderNo = maxId + DateTime.Now.ToString("yyMMdd") + user.id + DateTime.Now.ToString("HHmm");
                int rows = OrderService.UpdateOrderNo(maxId, order.orderNo, order.orderDesc);
                if (rows > 0)
                {
                    #region 订单详细表                    
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int pid = Convert.ToInt32(dr["productId"]);
                            int count = Convert.ToInt32(dr["productCount"]);
                            OrderDetail od = new OrderDetail();
                            od.orderId = maxId;
                            od.orderNo = order.orderNo;
                            od.productId = pid;
                            od.productCount = count;

                            od.isActive = 0;
                            od.activeCode = "";
                            od.activeMoney = 0;
                            od.total = Convert.ToDouble(dr["remark"]);                            
                            od.satus = order.status;
                            od.remark = "";
                            od.infoType = 0;
                            OrderDetailService.Add(od);
                        }
                    }
                   
                    #endregion

                    ///Delete购物车中的商品
                    CartTempService.DeleteByUserId(user.id);                    
                    
                }
                Response.Write(maxId.ToString());
                #endregion
            }
            else
            {
                Response.Write("nologin");
            }
            #endregion
        }
        /// <summary>
        /// 添加到购物车
        /// </summary>
        private void AddToCartIndexNew()
        {
            int id = CRequest.GetInt("id", 0);
            Product product = ProductService.GetModel(id);
            if(product.proType == 0)
            {
                Response.Write("nostore");
                return;
            }
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                CartTemp item = new CartTemp();
                #region Log In状态下的
                item.productId = id;
                item.productCount = 1;

                item.addUser = user.id;
                item.status = 1;
                item.remark = "";
                item.sel = 1;
                Product p = ProductService.GetModel(id);
                if (p != null)
                {
                    if (item.status == 1)
                    {
                        item.remark = (p.price1 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 2)
                    {
                        item.remark = (p.price2 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 3)
                    {
                        item.remark = (p.price3 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 4)
                    {
                        item.remark = (p.price4 * item.productCount).ToString("0.00");
                    }

                }
                CartTemp cts = CartTempService.GetModel(item.addUser, item.productId);
                if (cts != null)
                {
                    cts.productCount += item.productCount;
                    cts.remark = (Convert.ToDouble(cts.remark) + Convert.ToDouble(item.remark)).ToString();
                    if (CartTempService.UpdateCart(cts) > 0)
                    {
                        Response.Write(cts.productCount.ToString());
                    }
                    else
                    {
                        Response.Write("0");
                    }
                }
                else
                {
                    int maxId = CartTempService.Add(item);
                    if (maxId > 0)
                    {
                        Response.Write(item.productCount.ToString());
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                #endregion
            }
            else
            {
                List<CartTemp> cartlist = Session["nologinCart"] as List<CartTemp>;
                if (cartlist != null)
                {
                    if (cartlist.Count > 0)
                    {
                        int exists = 0;
                        foreach (CartTemp ct in cartlist)
                        {
                            if (ct.productId == id)
                            {
                                exists = 1;
                                ct.productCount++;
                                cartlist.Remove(ct);
                                cartlist.Add(ct);
                                Response.Write(ct.productCount.ToString());
                                break;
                            }
                        }
                        if(exists == 0)
                        {
                            CartTemp ct = new CartTemp();
                            ct.productId = id;
                            ct.productCount = 1;
                            cartlist.Add(ct);
                            Response.Write(ct.productCount.ToString());
                        }

                    }
                    else
                    {
                        CartTemp ct = new CartTemp();
                        ct.productId = id;
                        ct.productCount = 1;
                        cartlist.Add(ct);
                        Response.Write(ct.productCount.ToString());
                    }
                }
                else
                {
                    cartlist = new List<CartTemp>();
                    CartTemp ct = new CartTemp();
                    ct.productId = id;
                    ct.productCount = 1;
                    cartlist.Add(ct);
                    Response.Write(ct.productCount.ToString());
                }
                Session["nologinCart"] = cartlist;
            }
        }


        /// <summary>
        /// 添加到购物车
        /// </summary>
        private void AddCartIndex()
        {
            int id = CRequest.GetInt("id", 0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                CartTemp item = new CartTemp();
                item.productId = id;
                item.productCount = 1;

                item.addUser = user.id;
                item.status = 1;
                item.remark = "";
                item.sel = 1;
                Product p = ProductService.GetModel(id);
                if (p != null)
                {
                    if (item.status == 1)
                    {
                        item.remark = (p.price1 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 2)
                    {
                        item.remark = (p.price2 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 3)
                    {
                        item.remark = (p.price3 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 4)
                    {
                        item.remark = (p.price4 * item.productCount).ToString("0.00");
                    }

                }
                CartTemp cts = CartTempService.GetModel(item.addUser, item.productId);
                if (cts != null)
                {
                    cts.productCount += item.productCount;
                    cts.remark = (Convert.ToDouble(cts.remark) + Convert.ToDouble(item.remark)).ToString();
                    if (CartTempService.UpdateCart(cts) > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                else
                {
                    int maxId = CartTempService.Add(item);
                    if (maxId > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }

            }
            else
            {
                Response.Write("nologin");
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        private void UpdateCartCount()
        {
            string productId = CRequest.GetString("productId");
            int count = CRequest.GetInt("count", 0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                string[] arr = productId.Split('_');
                if (arr.Length > 0)
                {
                    if (arr[1] != "")
                    {
                        CartTemp ct = CartTempService.GetModel(user.id, Convert.ToInt32(arr[1]));
                        if (ct != null)
                        {
                            ct.productCount = count;
                            Product p = ProductService.GetModel(ct.productId);
                            if (ct.status == 1)
                            {
                                ct.remark = (ct.productCount * p.price1).ToString("0.00");
                            }
                            if (ct.status == 2)
                            {
                                ct.remark = (ct.productCount * p.price2).ToString("0.00");
                            }
                            if (ct.status == 3)
                            {
                                ct.remark = (ct.productCount * p.price3).ToString("0.00");
                            }
                            if (ct.status == 4)
                            {
                                ct.remark = (ct.productCount * p.price4).ToString("0.00");
                            }
                        }
                        CartTempService.UpdateCart(ct);
                    }
                }

            }
            else
            {
                string[] arr = productId.Split('_');
                List<CartTemp> cartlist = Session["nologinCart"] as List<CartTemp>;
                if (cartlist != null)
                {
                    if (cartlist.Count > 0)
                    {
                        foreach (CartTemp ct in cartlist)
                        {
                            int index = cartlist.FindIndex(s => s.productId == Convert.ToInt32(arr[1]));
                            if(ct.productId == Convert.ToInt32(arr[1]))
                            {
                                ct.productCount = count;                                
                                cartlist.Remove(ct);
                                cartlist.Insert(index, ct);
                             //   cartlist.Add(ct);

                               // cartlist.Sort();
                                break;
                            }
                        }

                    }
                }
                Session["nologinCart"] = cartlist;
            }
            Response.Write("success");
        }
        /// <summary>
        /// 发票信息
        /// </summary>
        private void SaveInvoice()
        {
            int invoiceType = CRequest.GetInt("invoiceType", 0);
            int contentType = CRequest.GetInt("contentType", 0);
            string invoiceTitle = CRequest.GetString("invoiceTitle");
            InvoiceInfo item = new InvoiceInfo();
            item.typeId = invoiceType;
            item.typeName = "个人";
            if(invoiceType == 2)
            {
                item.typeName = "企业";
            }
            item.invoiceTitle = invoiceTitle;
            item.invoiceMoney = 0;
            item.sendMoney = 10;
            item.invoiceDesc = "";
            item.status = 0;
            item.remark = "";
            item.addTime = DateTime.Now;
            item.addUser = 0;
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                item.addUser = user.id;
            }
            else
            { 
                Response.Write("nologin");
                return;
            }
            item.isSend = 0;
            item.isRecive = 0;
            item.recieveTel = "";
            item.recieveName = "";
            item.recieveAddr = "";
            item.infoType = contentType ;
            if (item.infoType == 1)
            {
                item.invoiceDesc = "礼品";
            }
            if (item.infoType == 2)
            {
                item.invoiceDesc = "蔬菜水果";
            }
            if (item.infoType == 3)
            {
                item.invoiceDesc = "广告费";
            }
            if (item.infoType == 4)
            {
                item.invoiceDesc = "办公用品";
            }
            if (item.infoType == 5)
            {
                item.invoiceDesc = "会议";
            }
           
        }
        /// <summary>
        /// 收到货品更新状态
        /// </summary>
        private void RecieveOrder()
        {
            int orderId = CRequest.GetInt("orderId", 0);
            int rows = OrderService.UpdateStatus(orderId, 3);
            if (rows > 0)
            {
                Response.Write("success");
            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        private void RightNow()
        {
            int status = 0;
            string priceItem = CRequest.GetString("priceItem");
            if (priceItem == "price1")
            {
                status = 1;
            }
            if (priceItem == "price2")
            {
                status = 2;
            }
            if (priceItem == "price3")
            {
                status = 3;
            }
            if (priceItem == "price4")
            {
                status = 4;
            }

            int procount = CRequest.GetInt("procount", 0);
            int id = CRequest.GetInt("id", 0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                CartTemp item = new CartTemp();
                item.productId = id;
                item.productCount = procount;

                item.addUser = user.id;
                item.status = status;
                item.remark = "";
                item.sel = 1;
                Product p = ProductService.GetModel(id);
                if (p != null)
                {
                    if (status != 0)
                    {
                        if(status == 1)
                        {
                            item.remark = (p.price1 * item.productCount).ToString("0.00");
                        }
                        if (status == 2)
                        {
                            item.remark = (p.price2 * item.productCount).ToString("0.00");
                        }
                        if (status == 3)
                        {
                            item.remark = (p.price3 * item.productCount).ToString("0.00");
                        }
                        if (status == 4)
                        {
                            item.remark = (p.price4 * item.productCount).ToString("0.00");
                        }
                    }
                    else
                    { 
                        item.remark = (p.price1 * item.productCount).ToString("0.00");
                    }
                    
                }
                CartTemp cts = CartTempService.GetModel(item.addUser, item.productId);
                if (cts != null)
                {
                    item.productCount += cts.productCount;
                    if (status != 0)
                    {
                        if (status == 1)
                        {
                            item.remark = (p.price1 * item.productCount).ToString("0.00");
                        }
                        if (status == 2)
                        {
                            item.remark = (p.price2 * item.productCount).ToString("0.00");
                        }
                        if (status == 3)
                        {
                            item.remark = (p.price3 * item.productCount).ToString("0.00");
                        }
                        if (status == 4)
                        {
                            item.remark = (p.price4 * item.productCount).ToString("0.00");
                        }
                    }
                    else
                    {
                        item.remark = (p.price1 * item.productCount).ToString("0.00");
                    }
                    if (CartTempService.UpdateNewPC(cts.id, item.productCount, item.remark,item.status))
                    {
                        DataSet ds = UserAddressService.GetList("addUser = " + user.id);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("noAddr");
                        }
                       
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                else
                {
                    int maxId = CartTempService.Add(item);
                    if (maxId > 0)
                    {
                        DataSet ds = UserAddressService.GetList("addUser = " + user.id);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("noAddr");
                        }
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }

            }
            else
            {
                Response.Write("nologin");
            }
        }
        /// <summary>
        /// 获取xml
        /// </summary>
        /// <returns></returns>
        private string CreateXML()
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
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
        /// <summary>
        /// 微信支付系统预支付交易
        /// </summary>
        private void PreOrder() 
        {
        }
        /// <summary>
        /// 如果目录不存在就创建目录
        /// </summary>
        /// <param name="filename"></param>
        private void NoFolderCreate(string filename)
        {
            string fileDir = Server.MapPath(Path.GetDirectoryName(filename));
            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }
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
        /// <summary>
        /// Save订单
        /// </summary>
        private void SaveOrder() 
        {
            int hidAddrId = CRequest.GetInt("hidAddrId",0);
            string ids = CRequest.GetString("ids");
            #region 生成订单
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                #region 封装订单

                OrderInfo order = new OrderInfo();
                order.orderNo = "";
                order.orderName = user.relName + "在Plate-X订单";
                order.proTotal = 0;
                order.sendTotal = 0;
                order.orderTotal = 0;
                double total = 0;
                double priceItem = 0;
                if (ids != "")
                {
                    #region 选中的购物车中的商品
                    string[] arr = ids.Trim(',').Split(',');
                    if (arr.Length > 0)
                    {
                        for (var i = 0; i < arr.Length; i++)
                        {
                            if (arr[i] != "")
                            {
                                string[] arr2 = arr[i].Split('_');
                                if (arr2.Length > 0)
                                {
                                    int pid = Convert.ToInt32(arr2[0]);
                                    int count = Convert.ToInt32(arr2[1]);
                                    Product item = ProductService.GetModel(pid);
                                    if (item != null)
                                    {
                                        CartTemp ct = CartTempService.GetModel(user.id, item.id);
                                        if(ct != null)
                                        {
                                            if(ct.status == 1)
                                            {
                                                priceItem = item.price1;
                                                total += item.price1 * count;
                                            }
                                            if (ct.status == 2)
                                            {
                                                priceItem = item.price2;
                                                total += item.price2 * count;
                                            }
                                            if (ct.status == 3)
                                            {
                                                priceItem = item.price3;
                                                total += item.price3 * count;
                                            }
                                            if (ct.status == 4)
                                            {
                                                priceItem = item.price4;
                                                total += item.price4 * count;
                                            }

                                        }
                                        
                                    }
                                }

                            }

                        }
                    }
                    #endregion
                }
                order.orderTotal = Math.Round(total, 2);
                if (order.orderTotal == 0)
                {
                    Jscript.AlertAndRedirect("请选择购物车中的商品", "/shopping.html");
                    return;
                }

                order.orderDesc = "";
                order.remark = order.orderName + ",订单日期：" + DateTime.Now.ToString("yyyy-MM-dd");
                order.recieveUser = user.relName;
                order.pid = hidAddrId;
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

                order.orderNo = maxId + DateTime.Now.ToString("yyMMdd") + user.id + DateTime.Now.ToString("hhmm");
                int rows = OrderService.UpdateOrderNo(maxId, order.orderNo, order.orderDesc);
                if (rows > 0)
                {
                    int productCount = 0;
                    if (ids != "")
                    {
                        ///选中的购物车中的商品
                        ///
                        #region 订单详细
                        string[] arr = ids.Trim(',').Split(',');
                        if (arr.Length > 0)
                        {
                            for (var i = 0; i < arr.Length; i++)
                            {
                                if (arr[i] != "")
                                {
                                    string[] arr2 = arr[i].Split('_');
                                    if (arr2.Length > 0)
                                    {
                                        int pid = Convert.ToInt32(arr2[0]);
                                        int count = Convert.ToInt32(arr2[1]);
                                        productCount += count;
                                        #region 订单详细
                                        Product item = ProductService.GetModel(pid);
                                        if (item != null)
                                        {
                                            #region 订单详细表
                                            OrderDetail od = new OrderDetail();
                                            od.orderId = maxId;
                                            od.orderNo = order.orderNo;
                                            od.productId = pid;
                                            od.productCount = count;

                                            od.isActive = 0;
                                            od.activeCode = "";
                                            od.activeMoney = 0;
                                             CartTemp ct = CartTempService.GetModel(user.id, item.id);
                                             if (ct != null)
                                             {
                                                 od.isActive = ct.status;
                                                 if (ct.status == 1)
                                                 {
                                                     od.activeMoney = item.price1;
                                                 }
                                                 if (ct.status == 2)
                                                 {
                                                     od.activeMoney = item.price2;
                                                 }
                                                 if (ct.status == 3)
                                                 {
                                                     od.activeMoney = item.price3;
                                                 }
                                                 if (ct.status == 4)
                                                 {
                                                     od.activeMoney = item.price4;
                                                 }

                                             }
                                            od.total = priceItem *count;
                                            od.satus = 0;
                                            od.remark = "";
                                            od.infoType = 0;
                                            OrderDetailService.Add(od);
                                            #endregion

                                            //清空临时表信息
                                            CartTempService.DeleteByUserId(user.id, pid);
                                        }
                                        #endregion
                                    }

                                }

                            }
                        }

                        #endregion
                    }
                }
                Response.Write("success");
                #endregion
            }
            else
            {
                Response.Write("nologin");
            }
            #endregion
        }
        /// <summary>
        /// 取消订单RecieveOrder
        /// </summary>
        private void CancelOrder() 
        {
            int orderId = CRequest.GetInt("orderId", 0);
            int rows = OrderService.UpdateStatus(orderId, 100);
            if (rows > 0)
            {
                Response.Write("success");
            }
            else
            {
                Response.Write("fail");
            }
        }
        /// <summary>
        /// Delete购物车商品
        /// </summary>
        private void DelCartTemp() 
        {
            int productId = CRequest.GetInt("productId", 0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if (CartTempService.Delete(user.id,productId))
                {
                    Response.Write("success");
                }
                else
                {
                    Response.Write("fail");
                }
            }
            else
            {
                List<CartTemp> cartlist = Session["nologinCart"] as List<CartTemp>;
                if (cartlist != null)
                {
                    foreach (CartTemp ct in cartlist)
                    {
                        if (ct.productId == productId)
                        {
                            cartlist.Remove(ct);
                            break;
                        }
                    }
                }
                Session["nologinCart"] = cartlist;
                Response.Write("success");
            }
            
        }
       
        /// <summary>
        /// 添加到购物车
        /// </summary>
        private void AddCart()
        {
            string priceItem = CRequest.GetString("priceItem");
            int procount = CRequest.GetInt("procount", 0);
            int id = CRequest.GetInt("id",0);
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                CartTemp item = new CartTemp();
                item.productId = id;
                item.productCount = procount;
                
                item.addUser = user.id;
                item.status = 0;
                if (priceItem == "price1")
                {
                    item.status = 1;
                }
                if (priceItem == "price2")
                {
                    item.status = 2;
                }
                if (priceItem == "price3")
                {
                    item.status = 3;
                }
                if (priceItem == "price4")
                {
                    item.status = 4;
                }

                item.remark = "";
                item.sel = 1;
                Product p = ProductService.GetModel(id);
                if (p != null)
                {
                    if(item.status == 1)
                    {
                        item.remark = (p.price1 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 2)
                    {
                        item.remark = (p.price2 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 3)
                    {
                        item.remark = (p.price3 * item.productCount).ToString("0.00");
                    }
                    if (item.status == 4)
                    {
                        item.remark = (p.price4 * item.productCount).ToString("0.00");
                    }
                    
                }
                CartTemp cts = CartTempService.GetModel(item.addUser,item.productId);
                if (cts != null) 
                {
                    cts.productCount += item.productCount;
                    cts.remark = (Convert.ToDouble(cts.remark) + Convert.ToDouble(item.remark)).ToString();
                    if (CartTempService.UpdateCart(cts) > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }else
                {
                    int maxId = CartTempService.Add(item);
                    if(maxId > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("fail");
                    }
                }
                
            }
            else
            {
                Response.Write("nologin");
            }
        }
    }
}