﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saleOrder.aspx.cs" Inherits="CommonBussiness.mobile.saleOrder" %>
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
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="result_top">
  <div class="top_con"> <a href="shop_center.html" class="arrow_left"></a>
    <div class="title">New Sale Orders</div>
  </div>
</div>
<div class="writeOrder">  
  <div class="address">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
    <div class="proList">
      <ul>
          <asp:Repeater ID="repOrderDetail" runat="server" onitemcommand="Repeater1_ItemCommand">
            <ItemTemplate>
            <li style=" height:100px;border-bottom: 1px solid #333333;margin-bottom: 20px;">
            <p class="name" style=" width:98%;">Order ID：<%#GetOrderNo(Eval("orderId"))%>
            <asp:LinkButton ID="lbtnFinish" runat="server" CommandName="finish" CommandArgument='<%#Eval("orderId") %>' style="float:right; color:#ffffff; border-radius:7%;" ><%#GetDone(Eval("orderId"))%></asp:LinkButton></p>
            <div style="margin-top:10px;"><%#GetProductInfo(Eval("orderId")) %></div>
            </li>
            </ItemTemplate>
          </asp:Repeater>
      </ul>
    </div>
    </ContentTemplate>
      </asp:UpdatePanel>
  </div>  
  
</div>
<uc1:bottom ID="bottom1" runat="server" /> 
</form>
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("订单详情", url, 2)
</script>
