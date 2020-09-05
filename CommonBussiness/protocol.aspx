<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="protocol.aspx.cs" Inherits="CommonBussiness.protocol" %>

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
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="js/easyzoom.js"></script>
    <!--
    EasyZoom by Matt Hinchliffe <http://maketea.co.uk>
    Find out more at GitHub <http://github.com/i-like-robots/EasyZoom>
    -->
    <script type="text/javascript">
        /*project_list*/
        $(function () {
            var h = $("html,body").height();
            $('.renz').height(h);
        });
    </script>
    <script src="js/order.js" type="text/javascript"></script>
    <style type="text/css">
        #NUMOne h1{ font-weight:bold; font-size:16px; margin-top:20px; margin-bottom:5px;}
    #NUMOne h2{ font-weight:bold; font-size:16px; margin-top:20px; margin-bottom:5px;}
    .help_p1{ text-indent:2em; font-size:16px; text-align:justify;}
    </style>
</head>
<body>
<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<!--head-->

<uc1:top ID="top1" runat="server" />
<!--project-->
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt=""/></div>
<div class="proList_bg">   
    
    <div class="QC_main wrap" id="NUMOne" style="padding:20px;">       
        <h1 style="text-align:center; font-weight:bold; font-size:36px; margin:20px;"><%=ViewState["infoTitle"] %></h1>    
        <%=ViewState["infoContent"] %>
    </div>
    
</div>


<!--foot-->
 <uc2:bottom ID="bottom1" runat="server" />

<img src="images/icon/list_a.png" alt="" class="renz_close"/>
<img src="images/list_3.jpg" alt="" class="yx_renz2"/>
<img src="images/icon/list_a.png" alt="" class="renz_close2"/>
<div class="show_bg" style="display:none;background-color:#000;opacity:0.4;position:absolute;width:100%;top:0;left:0;z-index:9999;"></div>

<script type="text/javascript">
    var h = $('html,body').height() - 120;
    $('.show_bg').height(h);
</script>
<script type="text/javascript">
    // Instantiate EasyZoom plugin
    var $easyzoom = $('.easyzoom').easyZoom();

    // Get the instance API
    //    var api = $easyzoom.data('easyZoom');
    //    $('.yx_renz').hover(
    //            function(){
    //                var top=$('body').scrollTop();
    //                $(window).scroll(function(){ //滚动时，固定页面滚动条到页顶的高度，使其不滚动
    //                    $('body').scrollTop(top);
    //                });
    //            },function(){
    //                $(window).off('scroll');	//鼠标移开后，解除固定
    //            });

    
</script>
</body>
</html>

