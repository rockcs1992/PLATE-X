<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="receipt_address.aspx.cs" Inherits="CommonBussiness.mobile.receipt_address" %>
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
<link rel="stylesheet" href="css/base.css"/>
<link rel="stylesheet" href="css/content.css"/>
<script src="js/jquery.js"></script>
<script type="text/javascript" src="js/slider.js"></script>
<script type="text/javascript" src="js/lazyload.js"></script>
<script src="js/index.js"></script>
    <script src="js/user.js" type="text/javascript"></script>
</head>
<body style="background:#fbfbfb;">
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="result_top">
  <div class="top_con"> <a href="javascript:history.go(-1);" class="arrow_left"></a>
    <div class="title">新增地址</div>
  </div>
</div>
<div class="security">
  <div class="item"> <span class="tip">收货人姓名</span>
    <input type="text" class="text"  id="name" value="<%=ViewState["name"] %>"/>
  </div>
  <div class="item"> <span class="tip">收货人Phone号</span>
    <input type="text" class="text" id="mobile" value="<%=ViewState["mobile"] %>"/>
  </div>
  <div class="item"> <span class="tip">备用Phone号</span>
    <input type="text" class="text"  id="telephone" value="<%=ViewState["telephone"] %>"/>
  </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
  <div class="item"> <span class="tip">所在地</span>
      <asp:DropDownList ID="location_p" runat="server" AutoPostBack="true" Width="23%" Height="30px" 
          onselectedindexchanged="location_p_SelectedIndexChanged">
      </asp:DropDownList>
       <asp:DropDownList ID="location_c" runat="server" AutoPostBack="true"  Width="23%" Height="30px" 
          onselectedindexchanged="location_c_SelectedIndexChanged">
      </asp:DropDownList>
       <asp:DropDownList ID="location_a" runat="server" Width="23%" Height="30px" >
      </asp:DropDownList>
  </div>
  
        </ContentTemplate>
    </asp:UpdatePanel>
  <div class="item"> <span class="tip">详细收货地址</span>
    <input type="text" class="text" id="address" value="<%=ViewState["address"] %>"/>
  </div>
  <div class="item"> <span class="tip">标签</span>
    <input type="text" class="text" id="labelname" value="<%=ViewState["labelname"] %>"/>
  </div>
  <div class="item"> <span class="tip">默认</span>
    <p class="labelBox"><em class="circle"></em><input type="checkbox" id="cboDefault"/>&nbsp;设为默认收货地址</p>
  </div>
</div>
<asp:HiddenField ID="hidId" runat="server" />
<asp:HiddenField ID="hidAction" runat="server" />

<div><a onclick="return addAddrUser(<%=id %>);" class="infoBtn">Save</a></div>

</form>
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("收货地址", url, 2)
</script>
