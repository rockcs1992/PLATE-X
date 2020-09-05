<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_shop.aspx.cs" Inherits="CommonBussiness.my_shop" %>

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
    <link rel="stylesheet" type="text/css" href="css/jiesuan.css" />
    <link rel="stylesheet" type="text/css" href="css/project.css" />
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/region_select.js"></script>
    <script type="text/javascript" src="js/birthday.js"></script>
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
                    <div class="my_yuanX" style=" min-height:800px;">
                      <div class="my_shopping">
                        <div class="my_balance_t">
                          <h2>Your Orders</h2>
                        </div>
                        <div class="project_shop">
                          <ul>
                              <asp:Repeater ID="repProduct" runat="server">
                                <ItemTemplate>
                                <li>
                                    <%#GetInfo(Eval("productId")) %>
                                </li>
                                </ItemTemplate>
                              </asp:Repeater>
                          </ul>
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