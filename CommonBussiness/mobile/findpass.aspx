<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findpass.aspx.cs" Inherits="CommonBussiness.mobile.findpass" %>
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
        input{}
    .register .title:after{ width:24%;}
    .register .title:before{ width:24%;}
    .register ul li .tel{ margin-left:1%;width: 90%;padding: 9px 1%;font-size:14px; }
    .register ul li .code{padding: 9px 1%;font-size:14px;    width: 35%;}
    .register ul li .password{padding: 9px 1%;font-size:14px;width: 98%;}
   .register ul li .codeBox input{font-size:14px;}
   .register ul li .codeBox{ width:60%;}
    
    </style>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="register"> <a href="/mobile/my_yuanxiang.html" class="close"></a> <img src="images/big_logo.png" class="logo"/>
  <div class="title">Reset Password</div>
  <ul>
    <li>
      +1<asp:TextBox ID="tel" runat="server" CssClass="tel" placeholder="Phone Cannot Be Blank" autocomplete="off"></asp:TextBox>
      <i class="phone"></i> </li>
    
    <li class="clearfix">
      <asp:TextBox ID="txtCode" runat="server" placeholder="Verification Code" class="code fl" autocomplete="off"></asp:TextBox>
      <div class="codeBox fr">
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="lbtnGetCode" runat="server" Text="Send Verification Code" onclick="lbtnGetCode_Click"  /> 
                 <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick"></asp:Timer>
        </ContentTemplate>
      </asp:UpdatePanel>    
      </div>
    </li>
    <li>
    <input type="password" id="password" class="password" placeholder="Verification Code" autocomplete="off"/>
      <i class="lock"></i> </li>
      <li>
    <input type="password" id="password1" class="password" placeholder="Confirm Verification Code" autocomplete="off"/>
      <i class="lock"></i> </li>
    <li>
      <input type="button" value="Reset Password" class="zhuce" onclick="return SetNewPass();"/>
    </li>
   <%-- <li class="clearfix">
    <a href="login.html" class="re_btn fl">已是Plate-X会员？去登陆</a>
      <p class="resiter_book fr">找回Password即为同意<a href="#">Plate-X找回Password协议</a></p>
       </li>--%>
  </ul>
  <%--<div class="haslogin"><a href="login.html"></a></div>--%>
</div>
<uc1:bottom ID="bottom1" runat="server" /> 
</form>
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("找回密码", url, 2)
</script>
