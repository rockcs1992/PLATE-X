<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CommonBussiness.mobile.login" %>
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
    <script src="js/reg.js" type="text/javascript"></script>
    <style type="text/css">
        .register ul li .tel{ width:90%; margin-left:1%;padding: 9px 1%;}
    </style>
</head>
<body>
<div class="register"> <a href="/mobile/my_yuanxiang.html" class="close"></a> <a href="about.html"><img src="images/big_logo.png" class="logo"/></a>
  <div class="title">Log In</div>
  <ul>
    <li>
      +1<input type="text" id="mobile" placeholder="Phone Cannot Be Blank" class="tel" autocomplete="off"/>
      <i class="phone"></i> </li>
    <li>
      <input type="password" id="loginpass" placeholder="Password" class="password" autocomplete="off"/>
      <i class="lock"></i> </li>
      <li style=" font-size:16px; color:#b4b4b4;" > <input type="checkbox" id="cboRemember"  checked="checked" style="border:1px #b4b4b4 solid; width:20px; height:20px;" />&nbsp;Remember</li>
    <li>
      <input type="button" value="Log In" class="zhuce" onmousedown="return login('<%=action %>');" />
    </li>
    <li class="clearfix">
      <p class="resiter_book fl"><a href="register.html" style=" text-decoration:none; color:red;">Don't have an account yet? Create one</a></p>
      <a href="findpass.html" class="re_btn fr" style="color:#b4b4b4;float: left; margin-top: 20px;">Forgot password</a> </li>
  </ul>
  
</div>
<uc1:bottom ID="bottom1" runat="server" /> 
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("登陆", url, 2)
</script>
