<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modpass.aspx.cs" Inherits="CommonBussiness.mobile.modpass" %>
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
<%--<link rel="stylesheet" href="css/base.css"/>--%>
<link rel="stylesheet" href="css/content.css"/>
<script src="js/jquery.js"></script>
<script type="text/javascript" src="js/slider.js"></script>
<script type="text/javascript" src="js/lazyload.js"></script>
<script src="js/index.js"></script>
<script src="js/user.js" type="text/javascript"></script>
<script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="js/user.js" type="text/javascript"></script>
</head>
<body style="background:#fbfbfb;">
<form id="form1" runat="server">
 <div class="result_top">
  <div class="top_con"> <a href="/mobile/security_center.html" class="arrow_left"></a>
    <div class="title">修改Password</div>
  </div>
</div>
<div class="setup"> 
  <div class="item">
    <span class="tipcv fl">旧Password： </span>
    <span class="info fl infoBox"><input type="password" class="textInput" id="oldp" /></span>
  </div>
  <div class="item">
    <span class="tipcv fl">新Password： </span>
    <span class="info fl infoBox" id="Span1"><input type="password" class="textInput" id="newp" /></span>
  </div>
  <div class="item">
    <span class="tipcv fl">确认Password： </span>
    <span class="info fl infoBox" id="Span2"><input type="password" class="textInput" id="newp2" /></span>
  </div>
 
  <a onclick="return modpass();" class="submit">提交</a>
</div>
</form>
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("修改Password", url, 2)
</script>
