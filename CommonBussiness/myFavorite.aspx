<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myFavorite.aspx.cs" Inherits="CommonBussiness.myFavorite" %>

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

    <uc1:top ID="top1" runat="server" />
    <!--orders-->
    <div class="blank_bg">
        <div class="overf">
            <div class="order wrap">
                <div class="orders">
                    <div class="orders_l">
                        <ul>
                            <li class="title"><i>My Plate-X</i></li>
                            <li><a href="orders_0.html" class="aa"><i> My Items</i><span></span></a></li>
                            <li><a href="my_shop.html" class="aa"><i>Past Orders</i><span></span></a></li>
                            <li><a href="my_person.html" class="aa"><i>Your Account</i><span></span></a></li>
                            <li class="<%=getClass(1) %>"><a href="myFavorite_1.html" class="aa"><i>Your Restaurant</i><span></span></a></li>
                            <li class="<%=getClass(2) %>"><a href="myFavorite_2.html" class="aa"><i>Your Store</i><span></span></a></li>
                            <li><a href="exit.html" class="aa"><i>Log Out</i><span></span></a></li>
                        </ul>
                    </div>
                    <div class="my_yuanX" style="min-height:800px;">
                      <div class="my_shopping">
                        <div class="my_balance_t">
                          <h2>Your <%=ViewState["shopTypeName"] %></h2>
                        </div>
                        <div class="project_shop">
                          <ul>
                              <asp:Repeater ID="repInfo" runat="server">
                                <ItemTemplate>
                                <li>
                                    <a href="shoper_detail_<%#Eval("id") %>.html"><div align="center"><img src="<%#Eval("imgUrl") %>" alt="<%#Eval("comName") %>" style="width:60%; margin-top:20px;"></div>
                                    <p style="margin-top:20px;"><%#Eval("comName") %></p>
                                    <h4><%#Eval("mobileCode") %> <%#Eval("activeCode") %>  <%#Eval("mainBrand") %> </h4></a>
                                </li>
                                </ItemTemplate>
                              </asp:Repeater>
                          </ul>
                          <div id="noList" runat="server" visible="false" style="margin:36px auto; width:100%; height:300px;text-align:center;">
                                <div style="text-align:center;" ><img src="images/favorite.png" style="display:inline;" /></div>
                                <div class="information" style="margin-top:40px; padding-top:17px; padding-bottom:14px; background-color:#fff;"> 
                                    <a href="classify_details_1_0_0_0_0_0_0.html" style="width:80%; background-color:#fff; color:#aaa;">You haven't loved any store yet. Come and like one :)</a>
                                </div>
                            </div>
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