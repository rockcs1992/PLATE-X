<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="CommonBussiness.mobile.product" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc1" %>
<!doctype html>
<html style=" background:#fdfdfd;">
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
</head>
<body style=" background:#fdfdfd;">
<div class="result_top">
  <div class="top_con"> <a href="javascript:history.go(-1);" class="arrow_left"></a>
    <div class="title"><%=ViewState["typeName"] %></div>
    <a href="http://v.t.sina.com.cn/share/share.php?url=http://www.shao-ming.com&title='<%=ViewState["typeName"] %>'" class="icon_share"></a> </div>
</div>
<div class="pro_banner"> <a href="product_details_<%=typeId %>.html"><img src="<%=ViewState["typeImg"] %>"/></a> </div>
<div class="watch">
    <asp:Repeater ID="repInfo" runat="server">
        <ItemTemplate>
        <div class="item">
            <div class="timeBox"> <%#Eval("releaseTime","{0:yyyy-MM-dd HH:mm}") %> </div>
            <div class="watch_con">
              <div class="conmentBox">
                <div class="conment_top">
                  <div class="portrait"><img src="<%#Eval("headImg") %>"/></div>
                  <p class="name"><%#Eval("title") %></p>
                  <p class="time"><%#Eval("author") %><em class="from"></em></p>
                </div>
                <div class="conment_con"><%#Eval("typeDesc") %></div>
                <div class="conment_pic">
                  <ul class="clearfix baguetteBoxTwo">
                    <%#GetImg(Eval("img1Url"), Eval("img2Url"), Eval("img3Url"))%>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<uc1:bottom ID="bottom1" runat="server" /> 

</body>
</html>
<script src="js/baguetteBox.js" type="text/javascript"></script>
<script>
    window.onload = function () {
        baguetteBox.run('.baguetteBoxTwo');

    };
    </script>
   <%-- <script type="text/javascript">
        var url = document.location.href;
        UpdateViews("商品列表", url, 2)
</script>
--%>