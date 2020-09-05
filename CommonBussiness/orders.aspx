<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="CommonBussiness.orders" %>

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
    <style type="text/css">
        .orders .orders_r .r_shop{ border-bottom:1px #aaa solid;}
        .orders .orders_r .r_huo{background: #eee;}
        .orders .orders_r .r_huo li{ width:30%;}
        .orders .orders_r .r_huo .l_2{ margin-left:0px;}
        .orders .orders_r .r_huo .l_3{ margin-left:0px; width:25%;}
        .orders .orders_r .r_shop ul>li ol .shop05{ float:right; margin-right:5%;}
    </style>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/js_new.js"></script>
    <script type="text/javascript" src="js/region_select.js"></script>
    <script src="js/order.js" type="text/javascript"></script>
    <script type="text/javascript">
        var userAgentInfo = navigator.userAgent;
        var Agents = ["Android", "iPhone",
                "SymbianOS", "Windows Phone",
                "iPad", "iPod"];
        var flag = true;
        for (var v = 0; v < Agents.length; v++) {
            if (userAgentInfo.indexOf(Agents[v]) > 0) {
                flag = false;
                break;
            }
        }
        if (!flag) {
            location.href = "/mobile/myorder_1.html";
        }
        function delOrder(id) {
            if (confirm("Are you sure you want to delete?")) {
                location.href = "/deleteOrder.aspx?id=" + id;
            }

         }
</script>

</head>
<body>
<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
    <!--head-->    
   <uc1:top ID="top1" runat="server" />
    <!--orders-->
    <div class="blank_bg">
        <div class="overf">
            <div class="order wrap">
                <div class="orders">
                    <div class="orders_l">
                        <ul>
                           <li class="title"><i>My Plate-X</i></li>
                           <%=GetMenu() %>
                        </ul>
                    </div>
                    <div class="orders_r my_yuanX orders_t" style="min-height:800px;">
                        <ul class="r_top">
                            <li class="ord_l"><img src="<%=ViewState["headImg"] %>" alt="" style="width:70px; height:70px;" /></li>
                            <li class="ord_r">
                                <h3><%=ViewState["mobile"] %></h3>
                                <p>Joined <%=ViewState["addTime"]%></p>
                            </li>
                        </ul>
                        <ul class="r_title">
                            <li class="<%=GetClass(0) %>"><a href="/orders_0.html">All </a></li>
                            <li class="<%=GetClass(99) %>"><a href="/orders_99.html">Order Placed（<span><%=GetCount(0) %></span>）</a></li>
                            <li class="<%=GetClass(1) %>"><a href="/orders_1.html">Order Delivered（<span><%=GetCount(1) %></span>）</a></li>
                        </ul>
                        <asp:Repeater ID="repInfo" runat="server">
                            <ItemTemplate>
                                <ul class="r_huo" style="margin-bottom:0px;">
                                    <li>Order ID：<span><%#Eval("orderNo")%></span></li>
                                    <li class="l_2">Order Time：<span><%#Eval("addTime","{0:yyyy-MM-dd HH:mm}")%></span></li>
                                    <li class="l_3">Total Price：<span>$<%#Eval("orderTotal","{0:0.00}")%></span></li>   
                                    <li style="float:right; width:15%;"><span><%#GetStatus(Eval("status")) %></span></li>                             
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