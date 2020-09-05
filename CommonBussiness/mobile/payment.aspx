<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="CommonBussiness.mobile.payment" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc1" %>
<!doctype html>
<html style=" background:#fbfbfb;">
<head>
<meta charset="utf-8">
<meta content="initial-scale=1.0,user-scalable=no,maximum-scale=1,width=device-width" name="viewport" />
<meta content="yes" name="apple-mobile-web-app-capable" />
<meta content="black" name="apple-mobile-web-app-status-bar-style"/>
<meta content="telephone=no" name="format-detection" />
   <title><%= ViewState["title"] %></title>
    <meta name="keywords" content="<%= ViewState["keyword"] %>" />
    <meta name="description" content="<%= ViewState["miaoshu"] %>" /> 
<link rel="stylesheet" href="css/base.css"/>
<link rel="stylesheet" href="css/content.css"/>
<script src="js/jquery.js"></script>
<script type="text/javascript" src="js/slider.js"></script>
<script type="text/javascript" src="js/lazyload.js"></script>
<script src="js/index.js"></script>
</head>
<body style="background:#fbfbfb;">
<div class="result_top">
  <div class="top_con"> <a href="my_yuanxiang.html" class="arrow_left"></a>
    <div class="title">Order is placed</div>
  </div>
</div>
<div class="payment" style=" padding:22px 6%;">
  
  <p>Order ID：<%=ViewState["orderNo"] %></p>
  <p>Order Time：<%=ViewState["orderDate"] %></p>
  <p>Total Payment：$<%=ViewState["orderTotal2"] %></p>
  <p>&nbsp;</p>
  <p><a href="myorder_0.html" style=" color:#ffffff;">【I will pay later】</a></p>
  <%--<p><strong>请在4小时内完成付款</strong></p>--%>
</div>
<div class="pay_btn">
  <p><a id="mychat" href="/pub_v2/pay/JsApiPayPage.aspx?orderId=<%=ViewState["orderId"] %>&total_fee=<%=ViewState["orderTotal"] %>">
  <img src="images/paypal.jpg" style="border: 1px #ccc solid;" />
  </a></p>
  <%--<p><a id="alipay" href="goali.html"><i class="alipay"></i>支付宝支付</a></p>--%>
</div>
<uc1:bottom ID="bottom1" runat="server" /> 
</body>
</html>
<script type="text/javascript">
//    var ua = navigator.userAgent.toLowerCase();
//    if (ua.match(/MicroMessenger/i) == "micromessenger") {
//        $("#alipay").hide();       
//    } else {
//        $("#mychat").hide();
//    }
</script>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("订单支付", url, 2)
</script>
