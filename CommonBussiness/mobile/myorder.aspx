<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myorder.aspx.cs" Inherits="CommonBussiness.mobile.myorder" %>
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
<style>
.myorder .title .del {
    float: right;
    font-size: 13px;
    color: #fff;
    height: 29px;
    background-color: #FF5050;
    line-height: 29px;
    text-align: center;
    width: 74px;
    border: 1px solid #f12727;
    margin-left: 12px;
}
</style>
</head>
<body style="background:#fbfbfb;">
<div class="result_top">
  <div class="top_con"> <a href="/mobile/my_yuanxiang.html" class="arrow_left"></a>
    <div class="title">My Order</div>
  </div>
</div>
<div class="mytitle">
  <ul class="clearfix">
    <li class="<%=GetTypeClass(0) %>" style=" width:20%;">
      <p><a href="myorder_0.html">All </a></p>
      <p class="num"><%=GetCount(100) %></p>
    </li>
    <li class="<%=GetTypeClass(99) %>" style=" width:40%;">
      <p><a href="myorder_99.html">Order Placed</a></p>
      <p class="num"><%=GetCount(0) %></p>
    </li>
    <li class="<%=GetTypeClass(1) %>" style=" width:40%;">
      <p><a href="myorder_1.html">Order Delivered</a></p>
      <p class="num"><%=GetCount(1) %></p>
    </li>
    <%--<li class="<%=GetTypeClass(2) %>">
      <p><a href="myorder_2.html">待收货</a></p>
      <p class="num"><%=GetCount(2) %></p>
    </li>
    <li class="<%=GetTypeClass(3) %>">
      <p><a href="myorder_3.html">待评价</a></p>
      <p class="num"><%=GetCount(3) %></p>
    </li>--%>
  </ul>
</div>
    <asp:Repeater ID="repInfo" runat="server">
        <ItemTemplate>
        <div class="myorder">
          <div class="title" style=" background:#eeeeee;">Order ID：<%#Eval("orderNo")%><em><%#GetStatus(Eval("status")) %></em></div>
          <div class="product clearfix">
            <ul class="item fl">
              <%#GetProductImg(Eval("id")) %>
            </ul>
            <a href="orderDetail_<%#Eval("id") %>.html" style="display:block; width:100%; height:100%;"><div class="total fr">Subtotal <%#GetProductCount(Eval("id")) %> in Cart<em></em></div></a>
          </div>
          
          <div class="title clearfix">
            <div class="total_price fl">Total：$<%#Eval("proTotal","{0:0.00}")%></div>
           <%-- <%#GetDoneInfo(Eval("id"),Eval("status")) %>--%>
            </div>
        </div>
        </ItemTemplate>
    </asp:Repeater>
    <div style="padding-bottom:55px;"></div>
    <uc1:bottom ID="bottom1" runat="server" /> 
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("个人订单", url, 2)
</script>
