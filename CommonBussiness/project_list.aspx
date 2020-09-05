<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project_list.aspx.cs" Inherits="CommonBussiness.project_list" %>

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
</head>
<body>
<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<!--head-->

<uc1:top ID="top1" runat="server" />
<!--project-->
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt=""/></div>
<div class="list_bg">
    <div class="project_list wrap">
        <div class="project_list_t">
            <%=GetBread() %>
        </div>
        <div class="pro_list_show">
            <div class="big_img">
                <a href="javaScript:;" id="zoom1">
                    <img src="<%=ViewState["noImg"] %>" alt=""/>
                </a>
            </div>
            <div class="min_img">
                <ul>
                    <%=ViewState["imgInfo"] %>
                </ul>
            </div>
            <div class="buy">
                <form action="" method="">
                    <h2><%=ViewState["proName"] %></h2>

                    <h3><%=ViewState["proDesc"] %></h3>
                    <%=ViewState["unitInfo"] %>
                    <%=ViewState["priceInfo"]%>
                    <input type="hidden" id="priceItem" value="price1" />
                    <div class="rmb_num">
                        <span class="jian"></span>
                        <input type="text" id="procount" value="1"/>
                        <span class="jia"></span>
                    </div>
                   <%-- <p>预计送达日期：<%=GetSendTime() %></p>--%>

                    <div class="buy_btn">
                       <%-- <span class="buy_btn_l"><a onclick="return rightnow(<%=id %>);">立即购买</a></span>--%>
                        <span class="buy_btn_l">
                            <a onclick="return addToCart(<%=id %>);">Add To Cart</a>
                        </span>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>
<div class="proList_bg">
    <div class="QC wrap">
        <div class="QC_t"><span>Plate-X Best Quality</span></div>
    </div>
    <div class="QC_jies wrap">
        <%=ViewState["advantage"] %>
        
    </div>
    <div class="QC_main wrap" id="NUMOne">           
        <%=ViewState["productContent"] %>
        <div style="    margin-top: 50px;">
        <a href="shoper_detail_<%=ViewState["shoperId"] %>.html">【<%=ViewState["shoperName"] %> Items】</a>
        
        </div>
    </div>
    <div class="xiangguan_bg">
        <div class="xiangg wrap">
            <h2>Frequently Bought Together</h2>

            <div class="xiangg_main">
                <span class="list_l"><img src="images/icon/list_l.png" alt=""/></span>
                <span class="list_r"><img src="images/icon/list_r.png" alt=""/></span>

                <div class="pro_box">
                    <ul class="project_pro project_pro_scro">
                        <asp:Repeater ID="repXG" runat="server">
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

