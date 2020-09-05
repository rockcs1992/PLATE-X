<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fullInfo.aspx.cs" Inherits="CommonBussiness.mobile.fullInfo" %>
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
         input[type=radio]{ width:20px; height:20px; margin-right:5px;}
    </style>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager><asp:FileUpload ID="filepic" runat="server"  onchange="showImage(this,'headImgId');" style="display:none;" />
<div class="register"> <a href="/mobile/shop_center.html" class="close"></a> <platex id="headImgId" onclick="document.getElementById('filepic').click();"><img src="<%=ViewState["imgUrl"] %>" class="logo"/></platex> 
<asp:HiddenField ID="hidImg" runat="server" />
  <%--<div class="title">UploadLOGO</div>--%>
  <ul>
  <li style="padding-left:20px;">
        <asp:RadioButtonList ID="radShoperType" runat="server" 
            RepeatDirection="Horizontal" Width="100%">
            <asp:ListItem Value="1" Selected="True">I own a restaurant</asp:ListItem>
            <asp:ListItem Value="2">I own a store</asp:ListItem>
        </asp:RadioButtonList>
      </li>
    
   
    <li>
      <asp:TextBox ID="relname" runat="server" CssClass="tel" placeholder="First Name" autocomplete="off"></asp:TextBox>
      </li>
 <li>
      <asp:TextBox ID="surname" runat="server" CssClass="tel" placeholder="Last Name"  autocomplete="off"></asp:TextBox>
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
      <asp:TextBox ID="city" runat="server" CssClass="tel" placeholder="city" autocomplete="off"></asp:TextBox>
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
      <input type="button" value="Save" class="zhuce" onclick="return FullShop();"/>
    </li>   
  </ul>
  <%--<div class="haslogin"><a href="login.html"></a></div>--%>
</div>
<uc1:bottom ID="bottom1" runat="server" /> 
</form>
</body>
</html>
<script type="text/javascript">
    function showImage(file, id) {
        var ext = file.value.toLowerCase().split('.').splice(-1);
        var div = document.getElementById(id);
        if (file.files && file.files[0]) {
            div.innerHTML = "<img id='img_" + id + "' class='logo'>";
            var img = document.getElementById("img_" + id);
            img.onload = function () {
//                img.width = "150";
//                img.height = "150";
            }
            var reader = new FileReader();
            reader.onload = function (evt) {
                img.src = evt.target.result;
                document.getElementById("hidImg").value = img.src;
            }
            reader.readAsDataURL(file.files[0]);
        }
        else { //兼容IE

        }
    }
</script>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("商家完善信息", url, 2)
</script>
