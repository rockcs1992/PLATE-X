<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product_details.aspx.cs" Inherits="CommonBussiness.mobile.product_details" %>
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
            <li><a href="javascript:void(0);"><img src="<%#Eval("imgUrl") %>" alt="<%=ViewState["proName"] %>" /></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
  </div>
</div>
<input type="hidden" id="priceItem" value="price1" />
<div class="pro_details">
  <div class="summary">
    <h1><%=ViewState["proName"]%></h1>   
   <h3 class="price"><div class="rmb"><span id="currentPrice">$<%=ViewState["price1"] %></span></div></h3>
    <div class="guige">Unit：<%=ViewState["unitInfo"] %></div>
     <%=ViewState["goodInfo"] %>
   <%=ViewState["imgInfo"] %>
  
 <div class="guige"> <%=ViewState["specialInfo"] %></div>

 <div class="guige"> <%=ViewState["productInfo"] %></div>
 <div class="guige"> <a href="shoper_detail_<%=ViewState["shoperId"] %>.html">【<%=ViewState["shoperName"] %> Items】</a></div>
   
</div>
<asp:HiddenField ID="hidStoreCount" runat="server" />
<div class="index_recommend recommend_buy">
  <h2 style="width: 95%;">Frequently Bought Together</h2>
  <ul class="clearfix" style=" white-space:nowrap; overflow:scroll; font-size:0;">
      <asp:Repeater ID="repTj" runat="server">
        <ItemTemplate>
            <li style=" width: 43%; display:inline-block; float:none;">
              <div class="image"><a href="product_details_<%#Eval("id") %>.html"><img src="<%#Eval("listImgUrl") %>" alt="<%#Eval("proName") %>" /></a></div>
              <div class="con"><a href="product_details_<%#Eval("id") %>.html">
                <div class="name"><%#Eval("proName") %></div>
                <div class="eva">Amount in Stock：<%#Eval("proType") %></div>
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

<div class='common-divider'></div>
<div class="countBox clearfix" id="donenum">

  <div class="count fl clearfix"> <i class="minus"></i>
    <input type="text" id="procount" value="1" class="num" readonly="readonly"/>
    <i class="plus"></i> </div>
  <div onmousedown="return AddToCartIndexNewDetail(<%=id %>)"  class="fl joinBtn" id="jointocar">Add To Cart</div> 
  <span style="display:none;" class="<%#GetNumClass(Eval("id")) %>" id="add_<%=id %>"><%#GetProductCount(Eval("id")) %></span>
  <a href="car.html"><em class="red_car fr"><%=GetCarTotal()%></em></a>
   </div>

   <div class="wifiBox2">
    <asp:Repeater ID="repEvent" runat="server">
    <ItemTemplate>
    <div class="event" id="event_<%#Eval("id") %>">   
        <%#Eval("remark") %>
       </div>
    </ItemTemplate>
    </asp:Repeater>  
  <div class="blankBox"></div>
  <div class="closeDiv"></div>
</div>


   <div class="wifiBox">
  <%--<div class="result_top">
    <div class="top_con"> <a href="" class="arrow_left"></a>
      <div class="title">我们的丰收结果</div>
      <a href="" class="icon_share"></a> </div>
   </div>--%>
   <asp:Repeater ID="repBottom" runat="server">
    <ItemTemplate>
    <div class="event" id="event_<%#Eval("id") %>">   
        <%#Eval("remark") %>
       </div>
    </ItemTemplate>
    </asp:Repeater>  
  <div class="blankBox"></div>
  <div class="closeDiv"></div>
</div>


  <%--<uc1:bottom ID="bottom1" runat="server" /> --%>
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

    var store = document.getElementById("hidStoreCount").value;
    //alert(store);
    if (store == 0) {
        $("#donenum").html("<div style='background-color:#f04400; padding:10px; width:100%; display:block; text-align:center; font-size:18px;'><a href='/mobile/classify.html' style='color:#fff; '>我还小 请先别吃我</a></div>");
        //$("#jointocar").hide();

    }
</script>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("商品详情", url, 2)
</script>
