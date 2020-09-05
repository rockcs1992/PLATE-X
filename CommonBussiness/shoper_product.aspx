<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoper_product.aspx.cs" Inherits="CommonBussiness.shoper_product" %>

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
                            <li><a href="saleOrder_0.html" class="aa"><i>New Orders</i><span></span></a></li>
                            <li><a href="saleOrder_1.html" class="aa"><i>Complete Orders</i><span></span></a></li>
                             <li><a href="saleOrder_100.html" class="aa"><i>Manage My Orders</i><span></span></a></li>
                              <li class="li_cur"><a href="shoper_product.html" class="aa"><i>Manage My Items</i><span></span></a></li>
                            <li><a href="orders_0.html" class="aa"><i> My Items</i><span></span></a></li>
                            <li><a href="my_shop.html" class="aa"><i>Past Orders</i><span></span></a></li>
                            <li><a href="/exit.html" class="aa"><i>Log Out</i><span></span></a></li>
                        </ul>
                    </div>
                    <div class="my_yuanX" style="min-height:800px;">
                      <div class="my_shopping">
                        <div class="my_balance_t">
                          <h2>Manage My Items<a href="shoper_product_add_0.html" style="float:right; font-size:18px;">【Add Item】</a></h2>
                        </div>
                        <div class="project_shop">
                          <ul>
                              <asp:Repeater ID="repProduct" runat="server" onitemcommand="Repeater1_ItemCommand">
                                <ItemTemplate>
                                <li>
                                    <a href="/shoper_product_add_<%#Eval("id") %>.html" title="Edit"><s><img src="<%#Eval("listImgUrl") %>" alt="<%#Eval("proName") %>"></s>
                                    <p><%#Eval("proName") %></p><h4>$<span><%#Eval("price1","{0:0.00}") %></span>（<%#Eval("unit1") %>）</h4><img src="images/modify.png" style=" margin-top:-12px;" /></a>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('Are you sure you want to delete?');"  style=" margin-top:-33px; float:right;"><img src="images/delete.png" /></asp:LinkButton>
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
     </form>
</body>
</html>