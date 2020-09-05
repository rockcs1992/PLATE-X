<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_yuanxiang.aspx.cs" Inherits="CommonBussiness.mobile.my_yuanxiang" %>
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
<style type="text/css">
.information{ text-align:center; padding:25px;}
.information a{ display:inline-block; width:100px; height:40px; line-height:40px; margin:0px 10px; font-size:16px; color:#fff; background:#f12727; border-radius:4px;}
.result_top .set_exit{    width: 25px;
    height: 60px;
    width:100px;
    display: block;
    position: absolute;
    top: 0;
    left: 0;}
</style>
</head>
<body style=" background:#fbfbfb;">
<div class="result_top">
  <div class="top_con">
  <a href="/exit.html" class="set_exit">【Log Out】</a> 
    <div class="title">My Plate-X</div>
    <a href="data_setup.html" class="set_btn"></a> </div>
</div>
<div class="information"> 
    <%--<%=GetLoginInfo() %>--%>
    <a class="touxiang" href="/mobile/data_setup.html"><img src="<%=ViewState["imgUrl"] %>" class="img"/></a>
    <p><%=ViewState["nameInfo"] %></p>
</div>
<div class="myList">
  <table>
    <tr>
      <td><a href="myorder_0.html"><b class="b1"></b><span>My Order</span><span><%=GetOrderCount() %></span></a></td>
      <td><a href="myproduct.html"><b class="b2"></b><span>Items Purchased</span><span><%=GetProductCount() %></span></a></td>
    </tr>
    <tr>
      <td><a href="myFavorite_1.html"><b class="b3"></b><span>Saved Restaurants</span><span><%=GetShoperCount(1) %></span></a></td>
      <td><a href="myFavorite_2.html"><b class="b4"></b><span>Saved Stores</span><span><%=GetShoperCount(2) %></span></a></td>
    </tr>
    <%--<tr>
      <td><a href="myticket.html"><b class="b5" style=""></b><span>My Plate-X券</span><%=GetTicketTotal()%><span></span></a></td>
      <td><a href="mybalance.html"><b class="b6"></b><span>我的余额</span><span><%=GetBalance() %></span></a></td>
    </tr>--%>
  </table>
</div>
<div class="myfoot" style="padding: 20px 0px 80px 45px; text-align:left;"> 
<strong style="line-height: 35px;">Contact：<a href="tel:13889266506">13889266506</a></strong><br />
<strong style="line-height: 35px;">Email：<a mailto:platexofficial@gmail.com>platexofficial@gmail.com</a></strong>
  <p style="line-height: 35px; font-size:14px;">We will get back to you as soon as possible</p>
</div>
<uc1:bottom ID="bottom1" runat="server" /> 
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("个人中心首页", url, 2)
</script>
