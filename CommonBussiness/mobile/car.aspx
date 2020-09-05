<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car.aspx.cs" Inherits="CommonBussiness.mobile.car" %>
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
    <script src="js/order.js" type="text/javascript"></script>
    <style type="text/css">
.information{ text-align:center;}
.information a{ display:inline-block; width:100px; height:40px; line-height:40px; margin:0px 10px; font-size:16px; color:#fff; background:#f12727; border-radius:4px;}
</style>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="result_top">
  <div class="top_con"><!-- <a href="javascript:history.go(-1);" class="arrow_left"></a>-->
    <div class="title">Cart</div>
  </div>
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<div class="shopCart">
  <%--<div class="title"> <span>北京市</span> &gt; <span>北京市</span> &gt; <span>北京市</span> <a href="#" class="next"></a> </div>--%>
    
        
  <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand">
        <ItemTemplate>
        <div class="list clearfix">
            <div class="deleteBtn" onclick="return delCartTemp(<%#Eval("productId") %>)" ></div>
            <div class="image fl"> 
            <span class="<%#GetClass(Eval("sel")) %>" id="span_<%#Eval("productId") %>"><i></i>
              <input type="checkbox" id="cbo_<%#(Container.ItemIndex) %>">
              </span>
          <span class="img"><a href="product_details_<%#Eval("productId") %>.html"><img src="<%#GetImg(Eval("productId")) %>"  /></a></span> </div>            
            <div class="abs">
              <h3><%#GetProName(Eval("productId"))%></h3>
              <h6><%--6粒装--%></h6>
              <div class="price_bar"><span class="new_price"><i>$</i><em><%#GetPrice(Eval("productId"),Eval("status"))%></em></span>
                <div class="amount_bar fr"> 
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="reduceNum" CommandName="reduce" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>                
                  <input type="text" id="count_<%#(Container.ItemIndex) %>" class="text-input" value="<%#Eval("productCount") %>" readonly="readonly">
                   <asp:LinkButton ID="LinkButton2" runat="server" CssClass="addNum" CommandName="add" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>  
                  </div>
              </div>
            </div>
          </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>
    <div id="noList" runat="server" visible="false" style="margin:-36px auto; width:100%; height:300px;text-align:center;">
        <div style="text-align:center;" ><img src="<%=ViewState["nologinImg"] %>" /></div>
        <div class="information" style="background-color:#fff;"> 
            <a href="classify_details_1_0_0_0_0_0_0.html" class="loginBtn">Let's go</a><%=GetLogin() %>
        </div>
        
    </div>
    <div class="inner_footer" id="cartButton" runat="server" style=" bottom:64px;">
              <div class="calculate_bar">
    <div class="cal_cell"><span class="total">Total：<em><strong id="totalValue"><%=ViewState["carTotal"]%></strong>$</em></span></div> 
    <a onclick="saveOrderMobile();" class="goCal_cell">Check Out</a></div>
    </div>
<uc1:bottom ID="bottom1" runat="server" />
</ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>