<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="join.aspx.cs" Inherits="CommonBussiness.mobile.join" %>
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
        .register ul li{ margin-top:10px;}
        .register{ margin-bottom:100px;}
        input[type=radio]{ width:20px; height:20px; margin-right:5px;}
        .register ul li .phone{ right:15px;}
    </style>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="register"> <a href="/mobile/login.html" class="close"></a> <a href="about.html"><img src="images/big_logo.png" class="logo"/></a>
  <div class="title">Join</div>
  <ul>
    <li>&nbsp;</li>
    <li style="padding-left:20px;">
        <asp:RadioButtonList ID="radShoperType" runat="server" 
            RepeatDirection="Horizontal" Width="100%">
            <asp:ListItem Value="1" Selected="True">I own a restaurant </asp:ListItem>
            <asp:ListItem Value="2"> I own a store</asp:ListItem>
        </asp:RadioButtonList>
      </li>
   
   <li>
      + 1 <asp:TextBox ID="tel" runat="server" CssClass="tel" placeholder="Phone Can not Be Blank" autocomplete="off" style=" width:84%; margin-left:1%;"></asp:TextBox>
      <i class="phone"></i> </li>
    <li>
    <input type="password" id="password" class="password" placeholder="Input Password" autocomplete="off"/>
      <i class="lock"></i> </li>
    <li class="clearfix">
      <asp:TextBox ID="txtCode" runat="server" placeholder="Send Verification Code" class="code fl" style="font-size:12px; width:38%; padding:10px 3%;" autocomplete="off"></asp:TextBox>
      <div class="codeBox fr">
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="lbtnGetCode" runat="server" Text="Send Verification Code" onclick="lbtnGetCode_Click" style="font-size:12px;"  /> 
                 <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick"></asp:Timer>
        </ContentTemplate>
      </asp:UpdatePanel>    
      </div>
    </li>
    <li>
      <asp:TextBox ID="relname" runat="server" CssClass="tel" placeholder="First Name" autocomplete="off"></asp:TextBox>
      </li>
  <li>
      <asp:TextBox ID="surname" runat="server" CssClass="tel" placeholder="Last Name" autocomplete="off"></asp:TextBox>
      </li>
    <li>
      <asp:TextBox ID="shoperName" runat="server" CssClass="tel" placeholder="Restaurant/StoreItem Name" autocomplete="off"></asp:TextBox>
      </li>
 
   
    <li>
      <asp:TextBox ID="street" runat="server" CssClass="tel" placeholder="Street1" autocomplete="off"></asp:TextBox>
      </li>
      <li>
      <asp:TextBox ID="street2" runat="server" CssClass="tel" placeholder="Street2" autocomplete="off"></asp:TextBox>
      </li>
    <li>
      <asp:TextBox ID="city" runat="server" CssClass="tel" placeholder="City" autocomplete="off"></asp:TextBox>
      </li>
    <li>
      <asp:TextBox ID="province" runat="server" CssClass="tel" placeholder="State" autocomplete="off"></asp:TextBox>
    </li>
  <li>
      <asp:TextBox ID="email" runat="server" CssClass="tel" placeholder="Email" autocomplete="off"></asp:TextBox>
      </li>
 <li>
      <asp:TextBox ID="remark" runat="server" CssClass="tel" placeholder="Introduction" autocomplete="off"></asp:TextBox>
    </li>

    
    <li>
      <input type="button" value="Request Information" class="zhuce" onclick="return regShop();"/>
    </li>
    <li class="clearfix">
    <a href="login.html" class="re_btn fl">Have an account? Log in</a>
      <p class="resiter_book fl" style="margin-top:10px;"><a href="#" style="text-decoration:none;">By proceeding, you agree to our term of use</a></p>

<p style="float:left; margin-top:10px; color:#b4b4b4"><a href="protocol_6.html" style="text-decoration:none; color:#b4b4b4">Privacy Policy</a> &amp; <a href="protocol_7.html" style="text-decoration:none; color:#b4b4b4">Terms of Use</a></p>
       </li>
       <li style="padding-bottom:50px;">&nbsp;</li>
  </ul>
  <%--<div class="haslogin"><a href="login.html"></a></div>--%>
</div>
<uc1:bottom ID="bottom1" runat="server" /> 
</form>
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("加盟合作", url, 2)
</script>
