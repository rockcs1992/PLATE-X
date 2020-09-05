<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="joinBack.aspx.cs" Inherits="CommonBussiness.mobile.joinBack" %>

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
    </style>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="register"> <%--<a href="/mobile/joinBack.aspx" class="close" title="继续添加"></a>--%> <img src="images/big_logo.png" class="logo"/>
  <div class="title">添加商家</div>
  <ul>
    <li>
      <asp:TextBox ID="surname" runat="server" CssClass="tel" placeholder="Last Name" autocomplete="off"></asp:TextBox>
      </li>
   
    <li>
      <asp:TextBox ID="relname" runat="server" CssClass="tel" placeholder="姓名" autocomplete="off"></asp:TextBox>
      </li>
 
    <li>
      <asp:TextBox ID="shoperName" runat="server" CssClass="tel" placeholder="Restaurant/StoreItem Name" autocomplete="off"></asp:TextBox>
      </li>
 
   
    <li>
      <asp:TextBox ID="street" runat="server" CssClass="tel" placeholder="街道" autocomplete="off"></asp:TextBox>
      </li>

    <li>
      <asp:TextBox ID="city" runat="server" CssClass="tel" placeholder="市" autocomplete="off"></asp:TextBox>
      </li>
    <li>
      <asp:TextBox ID="province" runat="server" CssClass="tel" placeholder="州" autocomplete="off"></asp:TextBox>
    </li>
  <li>
      <asp:TextBox ID="email" runat="server" CssClass="tel" placeholder="邮箱" autocomplete="off"></asp:TextBox>
      </li>
 <li>
      <asp:TextBox ID="remark" runat="server" CssClass="tel" placeholder="My Business Center" autocomplete="off"></asp:TextBox>
    </li>

    <li>
      <asp:TextBox ID="tel" runat="server" CssClass="tel" placeholder="Phone Cannot Be Blank码" autocomplete="off"></asp:TextBox>
      </li>
    <li>
   <asp:TextBox ID="password" runat="server" CssClass="tel" placeholder="请输入Password,为空默认：123456" autocomplete="off"></asp:TextBox>
      </li>
    <li>
        <asp:Button ID="Button1" runat="server" Text="Save信息" CssClass="zhuce" 
            onclick="Button1_Click" />
    </li>
   
  </ul>
</div>
</form>
</body>
</html>