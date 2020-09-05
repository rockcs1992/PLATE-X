<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myproduct.aspx.cs" Inherits="CommonBussiness.mobile.myproduct" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc1" %>
<!doctype html>
<html>
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
 <script src="../js/myindex.js" type="text/javascript"></script>
<style type="text/css">
.information{ text-align:center;}
.information a{ display:inline-block; width:100px; height:40px; line-height:40px; margin:0px 10px; font-size:16px; color:#fff; background:#f12727; border-radius:4px;}
.bigPic { margin:0px 2%; margin-bottom:3%;}
.bigPic img{ width:100%;}
.index_recommend ul li .car .hideNum{ display:none;}
.bottomCar .hideNum{ display:none;}
</style>
</head>
<body>
<%--<div class="index_header">
  <div class="header_con clearfix"><a href="index.html" class="logo fl"><img src="images/logo.png"/></a>
    <div class="search_box fl clearfix"> <a href="search.html"><em class="search_btn"></em>
      <input type="text" placeholder="搜索商品"/>
      </a> </div>
    <div class="set_btn fr"><a href="#"></a></div>
  </div>
</div>--%>
<div class="result_top">
  <div class="top_con"> <a href="/mobile/my_yuanxiang.html" class="arrow_left"></a>
    <div class="title">Your Orders</div>
  </div>
</div>
<div class="index_recommend">
 <%-- <h2>Your Orders</h2>--%>
  <%--<div class="re_banner"> <a href="#"><img src="images/re_banner.jpg"/></a> </div>--%>
  <ul class="clearfix">
      <asp:Repeater ID="repInfo" runat="server">
        <ItemTemplate>
         <li>
          <div class="image"><a href="product_details_<%#Eval("id") %>.html"><img src="<%#Eval("listImgUrl") %>" class="lazyImg"/></a></div>
          <div class="con">
            <div class="name"><%#Eval("proName") %></div>           
            <div class="eva"><%#Eval("unit1") %></div>
            <div class="price"><span>$ <%#Eval("price1","{0:0.00}") %></span></div>
            <a onmousedown="return AddToCartComment(<%#Eval("id") %>)" class="car"><em></em><span class="<%#GetNumClass(Eval("id")) %>" id="product_<%#Eval("id") %>"><%#GetProductCount(Eval("id")) %></span></a> </div>
        </li>
        </ItemTemplate>
      </asp:Repeater>
  </ul>
  <div id="noList" runat="server" visible="false" style="margin:36px auto; width:100%; height:300px;text-align:center;">
        <div style="text-align:center;" ><img src="images/favorite.png" /></div>
        <div class="information" style="margin-top:40px; padding-top:17px; padding-bottom:14px; background-color:#fff;"> 
            <a href="classify_details_1_0_0_0_0_0_0.html" style="width:80%; background-color:#fff; color:#aaa;">You haven't frequently bought any item, come check them out</a>
        </div>
        
    </div>
</div>
<uc1:bottom ID="bottom1" runat="server" /> 
</body>
</html>
<script>
    if ($("#carttotal").text() == "") {
        $("#carttotal").addClass("hideNum");
    }
</script>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("Your Orders", url, 2)
</script>
