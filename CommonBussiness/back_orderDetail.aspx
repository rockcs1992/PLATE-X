<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="back_orderDetail.aspx.cs" Inherits="CommonBussiness.back_orderDetail" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc2" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8" />
     <title><%= ViewState["title"] %></title>
    <meta name="keywords" content="<%= ViewState["keyword"] %>" />
    <meta name="description" content="<%= ViewState["miaoshu"] %>" /> 

    <meta name="renderer" content="webkit">

    <meta name="viewport" content="width=device-width">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <link rel="stylesheet" type="text/css" href="css/lanmu.css" />
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/js_new.js"></script>
    <script type="text/javascript" src="js/region_select.js"></script>
    <script src="js/order.js" type="text/javascript"></script>
</head>
<body>
<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
    <!--head-->    
 <%--  <uc1:top ID="top1" runat="server" />--%>
    <!--orders-->
    <div class="blank_bg">
        <div class="overf">
            <div class="order wrap">
                <div class="orders">
                   
                    <div class="orders_r my_yuanX orders_t">
                        <ul class="r_top">
                           <%-- <li class="ord_l"><img src="<%=ViewState["headImg"] %>" alt="" style="width:70px; height:70px;" /></li>
                            <li class="ord_r">
                                <h3><%=ViewState["mobile"] %></h3>
                                <p><%=ViewState["addTime"]%>加入Plate-X</p>
                                <p>
                                    积分：<span>0</span>
                                    Plate-X卡：<span>0</span>
                                    余额：<span>0</span>
                                    Plate-X劵：<span>0</span>
                                </p>
                            </li>--%>
                        </ul>
                        <ul class="r_title">
                            <%--<li class="<%=GetClass(0) %>"><a href="/orders_0.html">所有订单</a></li>
                            <li class="<%=GetClass(99) %>"><a href="/orders_99.html">待付款（<span><%=GetCount(0) %></span>）</a></li>
                            <li class="<%=GetClass(1) %>"><a href="/orders_1.html">待发货（<span><%=GetCount(1) %></span>）</a></li>
                            <li class="<%=GetClass(2) %>"><a href="/orders_2.html">待收货（<span><%=GetCount(2) %></span>）</a></li>
                            <li class="<%=GetClass(3) %>"><a href="/orders_3.html">待评价（<span><%=GetCount(3) %></span>）</a></li>--%>
                        </ul>
                        <asp:Repeater ID="repInfo" runat="server">
                            <ItemTemplate>
                                <ul class="r_huo">
                                    <li>Order Time：<span><%#Eval("addTime","{0:yyyy-MM-dd}")%></span></li>
                                    <li class="l_2">Total Price：<span>$<%#Eval("orderTotal","{0:0.00}")%></span></li>
                                    <li class="l_3">送至：<span><%#GetAddr(Eval("pid"))%></span></li>
                                    <li class="l_4">Order ID：<span><%#Eval("orderNo")%></span></li>
                                </ul>
                                <div class="r_shop">
                                    <ul>
                                        <%#GetDetail(Eval("id"),Eval("status")) %>                                       
                                    </ul>                            
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--foot-->
     <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>