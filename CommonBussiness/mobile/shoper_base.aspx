<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoper_base.aspx.cs" Inherits="CommonBussiness.mobile.shoper_base" %>
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
        .register .logo{ border-radius:50%;}
    </style>
</head>
<body>
<form id="form1" runat="server">
<div class="register">
 <platex id="headImgId" onclick="document.getElementById('filepic').click();"><img src="<%=ViewState["imgUrl"] %>" class="logo"/></platex> 
 <p style="width:100%; text-align:center; margin-bottom:20px;"> <a href="tel:<%=ViewState["mobile"] %>">TEL：<%=ViewState["mobile"] %></a></p>
  <ul>
    <li>
     
      </li>
    <li>
      <asp:TextBox ID="surname" runat="server" CssClass="tel" autocomplete="off" ReadOnly="true"></asp:TextBox>
      </li>  
 
    <li>
      <asp:TextBox ID="shoperName" runat="server" CssClass="tel" autocomplete="off" ReadOnly="true"></asp:TextBox>
      </li>
 
   
    <li>
      <asp:TextBox ID="street" runat="server" CssClass="tel" autocomplete="off" ReadOnly="true"></asp:TextBox>
      </li>

    <li>
      <asp:TextBox ID="city" runat="server" CssClass="tel" autocomplete="off" ReadOnly="true"></asp:TextBox>
      </li>
    <li>
      <asp:TextBox ID="province" runat="server" CssClass="tel"  autocomplete="off" ReadOnly="true"></asp:TextBox>
    </li>
  <li>
      <asp:TextBox ID="email" runat="server" CssClass="tel" autocomplete="off" ReadOnly="true"></asp:TextBox>
      </li>
 <li>
      <asp:TextBox ID="remark" runat="server" CssClass="tel" autocomplete="off" ReadOnly="true"></asp:TextBox>
    </li>
   
  </ul>
  <%--<div class="haslogin"><a href="login.html"></a></div>--%>
</div>
<uc1:bottom ID="bottom1" runat="server" /> 
</form>
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("商家详情信息", url, 2)
</script>
