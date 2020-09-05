﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="protocol.aspx.cs" Inherits="CommonBussiness.mobile.protocol" %>
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
<style type="text/css">
    .help_p1{ line-height:25px; text-align:justify;margin-bottom: 10px;}
    .help_p1 img{ margin:20px 0px;}
</style>
</head>
<body>
<div class="result_top" style=" position:fixed; left:0; top:0; width:100%; background:#fff; height:60px; overflow:hidden;">
  <div class="top_con"> <a href="javascript:history.go(-1);" class="arrow_left"></a>
    <div class="title"><%=ViewState["infoTitle"] %></div>   
  </div>
</div>
<div style=" height:60px;"></div>
<div class="event" style=" overflow:hidden;">   
 <%=ViewState["infoContent"] %>
</div>
<div style=" height:64px;"></div>
<uc1:bottom ID="bottom1" runat="server" /> 
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews(<%=ViewState["infoTitle"] %>, url, 2)
</script>
