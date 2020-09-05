<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoper_detail.aspx.cs" Inherits="CommonBussiness.shoper_detail" %>

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
    <meta http-equiv="X-UA-Compatible" content="IE=Edge;chrome=1"/>
    <link rel="stylesheet" type="text/css" href="css/index.css"/>
    <link rel="stylesheet" type="text/css" href="css/list.css"/>
    <link rel="stylesheet" type="text/css" href="css/project.css"/>
    <link rel="stylesheet" href="css/pygments.css"/>
    <link rel="stylesheet" href="css/easyzoom.css"/>
    <style type="text/css">
    .guige{ margin:20px 0px;}
    </style>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="js/easyzoom.js"></script>
    <!--
    EasyZoom by Matt Hinchliffe <http://maketea.co.uk>
    Find out more at GitHub <http://github.com/i-like-robots/EasyZoom>
    -->
    <script src="js/order.js" type="text/javascript"></script>
</head>
<body>
<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<!--head-->

<uc1:top ID="top1" runat="server" />
<!--project-->
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt=""/></div>

<div class="proList_bg">
    <div class="QC wrap">
        <div align="center" style=" margin:0 auto; margin-top:50px;"><%=ViewState["imgInfo"]%></div>
        <div class="QC_t"><span><%=ViewState["shoperName"]%></span></div>
        
    </div>
    <div class="QC_jies wrap">
       <div class="guige">Addr：<%=ViewState["addr"] %></div>
        <div class="guige">City：<%=ViewState["city"]%></div>
       <div class="guige">Province：<%=ViewState["province"]%></div>
        <div class="guige"> <%=ViewState["shopRemark"] %></div>
        <div class="guige" id="favoriteInfoId"> <%=ViewState["shopRemark"] %></div>
    </div>
   
    <div class="xiangguan_bg">
        <div class="xiangg wrap">
            <h2>Items</h2>

            <div class="xiangg_main">
                <span class="list_l"><img src="images/icon/list_l.png" alt=""/></span>
                <span class="list_r"><img src="images/icon/list_r.png" alt=""/></span>

                <div class="pro_box">
                    <ul class="project_pro project_pro_scro">
                        <asp:Repeater ID="repTj" runat="server">
                            <ItemTemplate>
                            <li>
                                <a href="/project_list_<%#Eval("id") %>.html">
                                    <s><img src="<%#Eval("listImgUrl") %>" alt="<%#Eval("proName") %>"/></s>
                                    <p><%#Eval("proName") %></p>
                                    <h4>$<span><%#Eval("price1","{0:0.00}") %></span>（<%#Eval("unit1") %>）</h4>
                                </a>
                            </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>


<!--foot-->
 <uc2:bottom ID="bottom1" runat="server" />

<script type="text/javascript">
    var h = $('html,body').height() - 120;
    $('.show_bg').height(h);
</script>
<script type="text/javascript">
    function favorite(id) {
        $.ajax({
            url: "/JsData/user.aspx?action=Favorite&shoperId=" + id + "&time=" + new Date().getTime() + "",
            type: 'GET',
            success: function (msg) {
                if ($.trim(msg) == "success") {
                    //alert("Action成功");
                    loadFavorite(id);
                } else if ($.trim(msg) == "nologin") {
                    location.href="/register.html?action=login";
                } else {
                    alert('Failed to save！');
                }

            }
        });
    }
    function loadFavorite(id) {
        $.ajax({
            url: "/JsData/user.aspx?action=LoadFavorite&shoperId=" + id + "&time=" + new Date().getTime() + "",
            type: 'GET',
            success: function (msg) {
                if ($.trim(msg) == "exists") {
                    $("#favoriteInfoId").html("<a onclick=\"return favorite(<%=id %>);\">【Saved】</a>");
                } else if ($.trim(msg) == "nologin") {
                    $("#favoriteInfoId").html("<a onclick=\"return favorite(<%=id %>);\">【Add to Save】</a>");
                } else {
                    $("#favoriteInfoId").html("<a onclick=\"return favorite(<%=id %>);\">【Add to Save】</a>");
                }

            }
        });
    }
    loadFavorite(<%=id %>);
</script>
</body>
</html>

