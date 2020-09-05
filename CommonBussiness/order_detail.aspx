<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_detail.aspx.cs" Inherits="CommonBussiness.order_detail" %>
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
    </style>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/js_new.js"></script>
    <script type="text/javascript" src="js/region_select.js"></script>
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
                    <div class="my_yuanX dingdan my_yuanX3">
                        <div class="my_balance_t">
                          <h2>Order ID：<%=ViewState["orderNo"] %></h2>
                          <h3>Order Status：<%=ViewState["orderStatus"] %></h3>
                        </div>
                        <div class="dingdan_main">
                          <h2>Order Time：<%=ViewState["addTime"] %>&nbsp;  &nbsp;&nbsp;&nbsp;   Total Price：$<%=ViewState["orderTotal"]%> </h2>
                          <ul>
                              <asp:Repeater ID="repInfo" runat="server">
                                <ItemTemplate> 
                                <%#GetProductInfo(Eval("productId"),Eval("productCount"),Eval("total"),Eval("infoType")) %>

                                </ItemTemplate>
                              </asp:Repeater>
                          </ul>
                        </div>
                        <div class="dingdan_b">                          
                          <div class="dingdan_b_r">
                            <h2>Total：$<%=ViewState["orderTotal"]%></h2>                        
                            <%--<p class="zong">总计：<span>$<%=ViewState["orderTotal"] %></span></p>--%>
                          </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--foot-->
         <uc2:bottom ID="bottom1" runat="server" />
</body>
</html>