<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="CommonBussiness.mobile.about" %>
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
<script src="js/index.js"></script>
<style type="text/css">
    .help_p1{ line-height:25px; text-align:justify;margin-bottom: 10px;}
    .help_p1 img{ margin:20px 0px;}
</style>
</head>
<body>
<div class="result_top" style=" position:fixed; left:0; top:0; width:100%; background:#fff; height:60px; overflow:hidden;">
  <div class="top_con"> <a href="javascript:history.go(-1);" class="arrow_left"></a>
    <div class="title">About Plate-X</div>    
  </div>
</div>
<div style=" height:60px;"></div>
<div class="event" style=" overflow:hidden;">
    <%--<div style="border-bottom:3px #dddddd dotted; padding-bottom:10px; height:50px; margin-bottom:10px;">
            <span style="float:left; margin-right:10px;"><img src="images/about_user.png" style="width:50px;" /></span>
            <span style=" color:#89a415; font-weight:bold; font-size:24px;">FOR BUYERS</span><br />
            <span>Restaurants & Retail Consumers</span>
        </div>
        <div style="clear:both;"></div>
    <p class="help_p1">        
        - Buy food from local restaurants & supermarkets at a lower price
    </p>
    <p class="help_p1">        
        - Extra inventory on-demand to keep us with your customers
    </p>
    <p class="help_p1">        
        - Never sacrifice the freshness and quality as provided by trusted food suppliers
    </p>
     <p class="help_p1">        
       <img src="images/about1.png"/>
    </p>
    
    <div style="border-bottom:3px #dddddd dotted; padding-bottom:10px; height:50px; margin-bottom:10px;">
            <span style="float:left; margin-right:10px;"><img src="images/about_shop.png" style="width:50px;" /></span>
            <span style=" color:#89a415; font-weight:bold; font-size:24px;">FOR BUYERS</span><br />
            <span>Restaurants & Store owners</span>
        </div>
        <div style="clear:both;"></div>

        <p class="help_p1">        
        - Resell excess inventory to other nearby businesses
    </p>
    <p class="help_p1">        
        - Free up cash flow in aneco-friendly way
    </p>
    <p class="help_p1">        
        - Make inventory management more fexible
    </p>
      <p class="help_p1">        
       <img src="images/about2.png"/>
    </p>--%>
 <%=DAL.AboutMenuService.GetById(1) %>
</div>
<div style=" height:64px;"></div>
<uc1:bottom ID="bottom1" runat="server" /> 
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("关于Plate-X", url, 2)
</script>
