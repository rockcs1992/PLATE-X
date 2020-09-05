<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderDetail.aspx.cs" Inherits="CommonBussiness.mobile.orderDetail" %>
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
<div class="result_top">
  <div class="top_con"> <a href="javascript:history.go(-1);" class="arrow_left"></a>
    <div class="title">Order Details</div>
  </div>
</div>
<div class="writeOrder">  
  <div class="address">
    <h2><span>Orders</span><em class="total_pro">Subtotal <%=ViewState["productCount"]%> in Cart</em></h2>
    <div class="proList">
      <ul>
          <asp:Repeater ID="repOrderDetail" runat="server">
            <ItemTemplate>
            <li><span class="name" style=" width:60%;"><%#Convert.ToInt32(Eval("infoType")) == 0 ? "<a href='shoper_detail_" + GetShoperId(Eval("productId")) + ".html' target='blank' style='color:red;'>【Order Placed..】</a>" : "<a style='color:green;'>【Order Delivered】</a>"%><%#GetProductName(Eval("productId")) %></span><span class="num">x<%#Eval("productCount") %></span><span class="price">$<%#Eval("total","{0:0.00}") %></span></li>
            </ItemTemplate>
          </asp:Repeater>
      </ul>
    </div>
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
