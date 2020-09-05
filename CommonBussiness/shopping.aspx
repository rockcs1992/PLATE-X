<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopping.aspx.cs" Inherits="CommonBussiness.shopping" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc2" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8"/>
       <title><%= ViewState["title"] %></title>
    <meta name="keywords" content="<%= ViewState["keyword"] %>" />
    <meta name="description" content="<%= ViewState["miaoshu"] %>" /> 
 
    <meta name="renderer" content="webkit">
    <meta name="viewport" content="width=device-width">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="css/index.css"/>
    <link rel="stylesheet" type="text/css" href="css/lanmu.css"/>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <style type="text/css">
    .overf{ min-height:738px;}
    </style>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<uc1:top ID="top1" runat="server" />
<!--shopping-->
<div class="blank_bg">
    <div class="overf">
        <div class="shopping wrap">
            <ul class="shop_top">
                <li class="li01">Items</li>
                <li class="li02">Price</li>
                <li class="li03">Quantity</li>
                <li class="li04">Total Price</li>
                <li class="li05">Action</li>
            </ul>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <ul class="shop">
                        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand">
                            <ItemTemplate>
                            <li class="shop_li">
                                <ol class="tr">
                                    <li class="li12"><a href="/project_list_<%#Eval("productId") %>.html"><img src="<%#GetImg(Eval("productId")) %>" alt="<%#GetProName(Eval("productId"))%>" style="width:100px; height:100px;" /></a></li>
                                    <li class="li13"><a href="/project_list_<%#Eval("productId") %>.html"><%#GetProName(Eval("productId"))%></a></li>
                                    <li class="li14"><span>$<i><%#GetPrice(Eval("productId"),Eval("status"))%></i></span></li>
                                    <li class="li15">
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="images/zhifu/shopping06.jpg" CommandName="reduce" CommandArgument='<%#Eval("id") %>' CssClass="reduce" style=" margin-bottom:8px;" />
                                        <span class="num count-input" id="productcount_<%#Eval("productId") %>"><%#Eval("productCount")%></span>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/zhifu/shopping07.jpg" CommandName="add" CommandArgument='<%#Eval("id") %>' CssClass="add" style=" margin-bottom:8px;" />
                                    </li>
                                    <li class="li16"><span>$<i id="productprice_<%#Eval("id") %>"><asp:Label ID="lblTotal"
                                        runat="server" Text='<%#Convert.ToDouble(GetPrice(Eval("productId"),Eval("status"))) * Convert.ToInt32(Eval("productCount"))%>'></asp:Label></i></span></li>
                                    <li class="li17">
                                    <asp:LinkButton ID="lbtnMod" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');" CommandName="del" CommandArgument='<%#Eval("id") %>'><img src="images/zhifu/shopping05.jpg" alt="Delete"/></asp:LinkButton>
                                    </li>
                                </ol>
                            </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:HiddenField ID="hidItemsCount" runat="server" />
                    </ul>
                    <ul class="shop_btm">
                            <li class="btm_l">
                                </li>                       
                            <li class="btm_r">Total Item Price<span class="qian">$<span class="jg_col priceTotal"><%=ViewState["carTotal"]%></span></span><a href="createOrder.html" style="cursor:pointer;">Check Out</a></li>
                        </ul>                
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<!--foot-->
 <uc2:bottom ID="bottom1" runat="server" />
 </form>
</body>
</html>
<script type="text/javascript">
    function checkCart() {
        return false;
    }
</script>