<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="classify_details.aspx.cs" Inherits="CommonBussiness.mobile.classify_details" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta content="initial-scale=1.0,user-scalable=no,maximum-scale=1,width=device-width" name="viewport" />
<meta content="yes" name="apple-mobile-web-app-capable" />
<meta content="black" name="apple-mobile-web-app-status-bar-style"/>
<meta content="telephone=no" name="format-detection" />
<title>Product</title>
<link rel="stylesheet" href="css/base.css"/>
<link rel="stylesheet" href="css/content.css"/>
<script src="js/jquery.js"></script>
<script type="text/javascript" src="js/slider.js"></script>
<script type="text/javascript" src="js/lazyload.js"></script>
<script src="js/index.js"></script>
    <script src="js/user.js" type="text/javascript"></script>
    <script type="text/javascript">
        function buttonClick() {
            if ((event.which == 13) || (event.keyCode == 13)) {
                event.cancelBubble = true;
                event.returnValue = false;
                search();
            }
        }

</script>
 <style>
.bigPic { margin:0px 2%; margin-bottom:3%;}
.bigPic img{ width:100%;}
.index_recommend ul li .car .hideNum{ display:none;}
.bottomCar .hideNum{ display:none;}
.sub_nav .sub_top .allBtn2{ background-color:#ffffff; color:#f07979}
.classify_header .search_box{left: 0;    margin-left: 10px; width:95%;}
</style>
    <script src="../js/myindex.js" type="text/javascript"></script>
</head>
<body onkeypress="buttonClick()">
<form id="form1" runat="server">
<div class="index_header classify_header">
  <div class="header_con clearfix"><%--<a href="/mobile/classify.html" class="arrow_left"></a>--%>
    <div class="search_box fl clearfix"> 
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"><em class="search_btn"></em></asp:LinkButton>  
        <asp:TextBox ID="txtKeyWord" runat="server" placeholder="Search" ></asp:TextBox>
    </div>
    <div class="cancel_btn fr"><%--<a href="javascript:history.go(-1);">取消</a>--%></div>
  </div>
</div>
<div class="sub_nav">
  <div class="sub_top">
    <a href="classify_details_<%=oneId %>_0_0_0_0_0_0.html" class="<%=GetAllClass2() %>">All </a>
    <ul>
      <li class="<%=GetAllClass() %>"></li>
        <asp:Repeater ID="repType" runat="server">
            <ItemTemplate>
            <li class="<%#GetClass(Eval("id")) %>"><a href="classify_details_<%=oneId %>_<%#Eval("id") %>_0_0_0_0_0.html"><%#Eval("typeName") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
   <%-- <a href="javascript:;" class="arrow_btn" style="display:<%=GetMeumClass() %>;"></a>--%> </div>
  <div class="subList">
    
    <div class="listCon">
        <asp:Repeater ID="repSon" runat="server">
            <ItemTemplate>
            <a href="classify_details_<%=oneId %>_<%=twoId %>_<%#Eval("id") %>_0_0_0_0.html"><%#Eval("typeName")%></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    
  </div>
</div>

<div class="index_recommend">
  <ul class="clearfix">
      <asp:Repeater ID="repInfo" runat="server">
        <ItemTemplate>
      
            <li>
             <a href="product_details_<%#Eval("id") %>.html"> 
            <div class="image"><img src="<%#Eval("listImgUrl") %>" class="lazyImg" alt="<%#Eval("proName")%>"/></div>
            <div class="con">
            <div class="name"><%#Eval("proName")%></div>
            <div class="eva">Amount in Stock：<%#Eval("proType") %></div>
            <div class="eva"><%#Eval("unit1")%></div>
            
            <div class="price"><span>$ <%#Eval("price1","{0:0.00}") %></span></div></div>
            </a>
      
            <div onmousedown="return AddToCartIndexNew(<%#Eval("id") %>)" class="car" style="cursor:pointer;"><em></em><span class="<%#GetNumClass(Eval("id")) %>" id="product_<%#Eval("id") %>"><%#GetProductCount(Eval("id")) %></span></div>
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
    if ($("#carttotal").text() == "") {
        $("#carttotal").addClass("hideNum");
    }
</script>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("Category", url, 2)
</script>
