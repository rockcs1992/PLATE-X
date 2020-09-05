

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CommonBussiness.mobile.index" %>
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
    <script src="/js/myindex.js" type="text/javascript"></script>
 <style>
.bigPic { margin:0px 2%; margin-bottom:3%;}
.bigPic img{ width:100%;}
.index_recommend ul li .car .hideNum{ display:none;}
.index_header .search_box{ width:65%;}
</style>
</head>
<body>
<div class="index_header">
  <div class="header_con clearfix"><a href="about.html" class="logo fl"><img src="images/logo.png"/></a>
    <div class="search_box fl clearfix"> <a onclick="return sear();"><em class="search_btn"></em></a>
      <input type="text" id="keyword" placeholder="Search"/>
     </div>
    <%--<a href="setup.html"><div class="set_btn fr"></div></a>--%>
  </div>
</div>
<div class="banner">
  <div id="demo01" class="flexslider">
    <ul class="slides">
        <asp:Repeater ID="repBanner" runat="server">
            <ItemTemplate>
            <li><a href="<%#Eval("linkurl") %>"><img src="<%#Eval("img1path") %>" alt="<%#Eval("title") %>" /></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
  </div>
</div>
<div class="banner" style=" background-color:#d3dcbf; padding:10px;">
    <div style=" background:#ffffff; min-height:500px; height:auto;">
       <div><a href="classify_details_1_51_0_0_0_0_0.html"><img src="images/index1.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
       <div><a href="classify_details_1_51_0_0_0_0_0.html"><img src="images/index11.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
        <div><a href="classify_details_1_52_0_0_0_0_0.html"><img src="images/index2.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
         
          <div><a href="classify_details_1_53_0_0_0_0_0.html"><img src="images/index4.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
          <%-- <div><a href="classify_details_1_60_0_0_0_0_0.html"><img src="images/index5.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
            <div><a href="classify_details_1_57_0_0_0_0_0.html"><img src="images/index6.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
             
              
               <div><a href="classify_details_1_59_0_0_0_0_0.html"><img src="images/index9.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
                <div><a href="classify_details_1_61_0_0_0_0_0.html"><img src="images/index10.jpg" style="width:100%;margin-bottom:0px;" /></a></div>--%>

                <div><a href="classify_details_1_54_0_0_0_0_0.html"><img src="images/index8.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
                <div><a href="classify_details_1_55_0_0_0_0_0.html"><img src="images/index3.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
                <div><a href="classify_details_1_56_0_0_0_0_0.html"><img src="images/index7.jpg" style="width:100%;margin-bottom:0px;" /></a></div>

    </div>
</div>
    
    <div class='common-divider'></div>
<uc1:bottom ID="bottom1" runat="server" /> 
</body>
</html>
<script type="text/javascript">
    function sear() {
        var keywordvalue = document.getElementById("keyword").value;
        location.href = "classify_details_1_0_0_0_0_0_0.html?keywordvalue=" + escape(keywordvalue);
    }
    var url = document.location.href;
    UpdateViews("首页", url, 2)
</script>
