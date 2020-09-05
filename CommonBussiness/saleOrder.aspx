<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saleOrder.aspx.cs" Inherits="CommonBussiness.saleOrder" %>
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
       .overf{ min-height:738px;}
       .dingdan_main h2{ height:50px; line-height:50px;}
    </style>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/js_new.js"></script>
    <script type="text/javascript" src="js/region_select.js"></script>
</head>
<body>
<form id="form1" runat="server">
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
                            
                            <li><a href="my_person.html" class="aa"><i>My Business Center</i><span></span></a></li>
                            <li class="<%=GetClass(0) %>" ><a href="saleOrder_0.html" class="aa"><i>New Orders</i><span></span></a></li>
                            <li class="<%=GetClass(1) %>"><a href="saleOrder_1.html" class="aa"><i>Complete Orders</i><span></span></a></li>
                             <li class="<%=GetClass(100) %>"><a href="saleOrder_100.html" class="aa"><i>Manage My Orders</i><span></span></a></li>
                              <li><a href="shoper_product.html" class="aa"><i>Manage My Items</i><span></span></a></li>
                            <li><a href="orders_0.html" class="aa"><i> My Items</i><span></span></a></li>
                            <li><a href="my_shop.html" class="aa"><i>Past Orders</i><span></span></a></li>
                            <li><a href="/exit.html" class="aa"><i>Log Out</i><span></span></a></li>
                        </ul>
                    </div>
                    <div class="my_yuanX dingdan my_yuanX3" style="    min-height: 800px;">    
                        <asp:Repeater ID="repOrderDetail" runat="server" onitemcommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                            <div class="dingdan_main" style=" border-bottom:1px #000000 solid; margin-bottom:20px; padding-bottom:20px;">
                              <h2>Order ID：<%#GetOrderInfo(Eval("orderId")) %><asp:LinkButton ID="lbtnFinish" runat="server" CommandName="finish" CommandArgument='<%#Eval("orderId") %>'><%#GetDone(Eval("orderId"))%></asp:LinkButton></h2>
                              <%#GetOrderDetail(Eval("orderId")) %>
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
         </form>
</body>
</html>