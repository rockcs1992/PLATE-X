<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhifu.aspx.cs" Inherits="CommonBussiness.zhifu" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc2" %>


<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8" />
      <title><%= ViewState["title"] %></title>
    <meta name="keywords" content="<%= ViewState["keyword"] %>" />
    <meta name="description" content="<%= ViewState["miaoshu"] %>" />   
   
    <meta name="renderer" content="webkit">

    <meta name="viewport" content="width=device-width">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <link rel="stylesheet" type="text/css" href="css/lanmu.css" />
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/js_new.js"></script>
    <script type="text/javascript" src="js/region_select.js"></script>
</head>
<body>

<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
    <!--head-->
   <uc1:top ID="top1" runat="server" />
    <!--zhifu-->
    <div class="blank_bg">
        <div class="overf">
            <div class="zhifu wrap">
                <div class="zhifu_top">
                   <%-- <h3>订单提交成功，请在<span>4</span>小时内付款。</h3>--%>
                    <p>Order ID：<%=ViewState["orderNo"] %> <%--<a href="/order_detail_<%=orderId %>.html" target="_blank">查看商品明细 ></a>--%></p>                    
                    <p>Order Time：<%=ViewState["orderDate"] %></p>
                    <p><a href="/orders_0.html">【I will pay later】</a></p>
                        

                </div>
                <div class="zhifu_cont">
                    <form action="" method="" runat="server">
                        <ul>
                            <li>
                                <h2>Payment Method</h2>
                                <ol>
                                    <li class="zhifu1" id="alipy">
                                        <input type="radio" name="radio"/>
                                        <span class="z_span"><i></i></span>
                                        <img src="images/paypal.jpg" alt=""/>
                                    </li>
                                    <%--<li class="zhifu1" id="mychat">
                                        <input type="radio" name="radio"/>
                                        <span class="z_span"><i></i></span>
                                        <img src="images/zhifu/zhifu12.jpg" alt=""/>
                                    </li>--%>
                                    <%--<li id="mychat" style=" display:block;">
                                        <%--<input type="radio" name="radio"/>
                                        <span class="z_span"><i></i></span>
                                        
                                    </li>--%>
                                </ol>
                            </li>
                            
                            <li id="alipaysel" class="_zhifu">
                                Total Payment:
                                <span>$ <%=ViewState["orderTotal"]%></span>
                                <a href="/goali.html" target="_blank">Pay Now</a>
                            </li>
                            <li id="mychatsel" style="display:none; padding-bottom:50px;">
                                <input type="hidden" id="hidOrderId" value="<%=orderId %>" />
                                <img src="<%=ViewState["codeImg"] %>" style="width:180px; height:180px; margin-left:300px;" /><br />
                                <span style=" text-align:center; margin-left:270px; color:#4f4f4f; font-size:16px;">请使用微信扫描二维码以完成支付</span>
                                
                            </li>
                        </ul>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!--foot-->
     <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>