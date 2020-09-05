<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoper_detail.aspx.cs" Inherits="CommonBussiness.mobile.shoper_detail" %>
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
    <script src="js/order.js" type="text/javascript"></script>
    <script src="../js/myindex.js" type="text/javascript"></script>

</head>
 <style>
.bigPic { margin:0px 2%; margin-bottom:3%;}
.bigPic img{ width:100%;}
.index_recommend ul li .car .hideNum{ display:none;}
.guige{ padding:5px 3%;}
.countBox .red_car .hideNum{ display:none;}
</style>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="banner product_banner"> 
<div class="product_top clearfix">
<a href="javascript:history.go(-1);" class="arrow_return"></a></div>
  <div id="demo02" class="flexslider">
    <ul class="slides">
        <asp:Repeater ID="repBanner" runat="server">
            <ItemTemplate>
           <%-- <li><a href="javascript:void(0);"><img src="<%#Eval("imgUrl") %>" alt="<%=ViewState["proName"] %>" /></a></li>--%>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
  </div>
</div>
<div class="pro_details">
  <div class="summary">
    <div class="guige" style="text-align:center;"> <%=ViewState["imgInfo"]%></div>
    <h1 style="margin-bottom:20px;"><%=ViewState["shoperName"]%></h1> 
    <div class="guige">Addr：<%=ViewState["addr"] %></div>
     <div class="guige">City：<%=ViewState["city"]%></div>
   <div class="guige">Province：<%=ViewState["province"]%></div>
  
 

 <div class="guige"> <%=ViewState["shopRemark"] %></div>
  <div class="guige" id="favoriteInfoId"></div>
  
</div>
<div class="index_recommend recommend_buy">
  <h2>Items</h2>
  <ul class="clearfix" style=" white-space:nowrap; overflow:scroll; font-size:0;">
      <asp:Repeater ID="repTj" runat="server">
        <ItemTemplate>
            <li style=" width: 43%; display:inline-block; float:none;">
              <div class="image"><a href="product_details_<%#Eval("id") %>.html"><img src="<%#Eval("listImgUrl") %>" alt="<%#Eval("proName") %>" /></a></div>
              <div class="con"><a href="product_details_<%#Eval("id") %>.html">
                <div class="name"><%#Eval("proName") %></div>
                <div class="eva">Amount in Stock：<%#Eval("proType") %>单</div>
                <div class="eva"><%#Eval("unit1") %></div>
                <div class="price"><span>$ <%#Eval("price1","{0:0.00}") %></span></div></a>
                <%--<a href="addToCartIndex(<%#Eval("id") %>)" class="car"><em></em></a>--%>
                <div onmousedown="return AddToCartIndexNew(<%#Eval("id") %>)" class="car" style="cursor:pointer;">
                <em></em>
                <span class="<%#GetNumClass(Eval("id")) %>" id="product_<%#Eval("id") %>"><%#GetProductCount(Eval("id")) %></span>
                </div> 
                 </div>

            </li>
        </ItemTemplate>
      </asp:Repeater>
  </ul>
</div>
  <uc1:bottom ID="bottom1" runat="server" /> 
  </form>
</body>
</html>
<script>
    $(function () {
        $(window).scroll(function () {
            var scrollHeight = $(document).scrollTop();
            if (scrollHeight > 0) {
                $('.product_banner .product_top').addClass('bg');
            } else {
                $('.product_banner .product_top').removeClass('bg');
            }
        });
    })
</script>
<script src="js/baguetteBox.js" type="text/javascript"></script>
<script>
    if ($("#carttotal").text() == "") {
        $("#carttotal").addClass("hideNum");
    }

    window.onload = function () {
        baguetteBox.run('.baguetteBoxTwo');

    };
    function favorite(id) {
        $.ajax({
            url: "/JsData/user.aspx?action=Favorite&shoperId=" + id + "&time=" + new Date().getTime() + "",
            type: 'GET',
            success: function (msg) {
                if ($.trim(msg) == "success") {
                    //alert("Action成功");
                    loadFavorite(id);
                } else if ($.trim(msg) == "nologin") {
                    alert('请登陆！');
                } else {
                    alert('Action失败！');
                }

            }
        });
    }
    function loadFavorite(id) {
        $.ajax({
            url: "/JsData/user.aspx?action=LoadFavorite&shoperId=" + id + "&time=" + new Date().getTime() + "",
            type: 'GET',
            success: function (msg) {
                if ($.trim(msg) == "exists") {
                    $("#favoriteInfoId").html("<a onclick=\"return favorite(<%=id %>);\">【已收藏】</a>");
                } else if ($.trim(msg) == "nologin") {
                    $("#favoriteInfoId").html("<a onclick=\"return favorite(<%=id %>);\">【加入收藏】</a>");
                } else {
                    $("#favoriteInfoId").html("<a onclick=\"return favorite(<%=id %>);\">【加入收藏】</a>");
                }

            }
        });
    }
    loadFavorite(<%=id %>);
</script>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("商家详情", url, 2)
</script>
