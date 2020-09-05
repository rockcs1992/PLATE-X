<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CommonBussiness.index" %>
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
    <link rel="stylesheet" type="text/css" href="css/project.css" />
    <link rel="stylesheet" type="text/css" href="css/list.css" />
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/login.js"></script>
    <%--<script src="layer/layer.js" type="text/javascript"></script>--%>
    <script src="js/layer.js" type="text/javascript"></script>
    <style>
        .shucai_l_t .item{overflow:hidden; }
.shucai_l_t .item .item_info{float:left;width: 160px;height: 240px;position: relative; padding:90px 0 0 10px;}
.youji{position: absolute;width: 56px; height: 56px; top:14px;left:12px;}
.youji_min{position: absolute;width: 40px; height: 40px; top:8px;left:12px;}
.youji img,.youji_min img{width: 100%; height: 100%;}
.shucai_l_t .item .item_info h2{font-size: 14px; color:#777;}
.shucai_l_t .item .item_info h3,.shucai_l_t .item .item_info h4{font-size: 16px; color:#444; margin:5px 0 20px;}
.shucai_l_t .item .item_info h4 span{font-size: 36px; color:#358749;}
.shucai_l_t .item_img{float:right;width: 490px;height: 240px;}
.shucai_l_t .item_img img{width: 100%; height: 100%;}

.shucai_r_t .item{overflow:hidden; }
.shucai_r_t .item .item_info{float:left;width: 160px;height: 240px;position: relative; padding:90px 0 0 10px;}
.youji{position: absolute;width: 56px; height: 56px; top:14px;left:12px;}
.youji_min{position: absolute;width: 40px; height: 40px; top:8px;left:12px;}
.youji img,.youji_min img{width: 100%; height: 100%;}
.shucai_r_t .item .item_info h2{font-size: 14px; color:#777;}
.shucai_r_t .item .item_info h3,.shucai_l_t .item .item_info h4{font-size: 16px; color:#444; margin:5px 0 20px;}
.shucai_r_t .item .item_info h4 span{font-size: 36px; color:#358749;}
.shucai_r_t .item_img{float:right;width: 330px;height: 240px;}
.shucai_r_t .item_img img{width: 100%; height: 100%;}
    .cateTypeImg img{ margin:0px; padding:0px; width:33%; display:inline;}
    </style>
    <script type="text/javascript">
    function buttonClick() {
        if ((event.which == 13) || (event.keyCode == 13)) {
            event.cancelBubble = true;
            event.returnValue = false;
            sea();
        }
    }
</script>
<link rel="shortcut icon" href="favicon.ico" type="image/x-icon">
<script type="text/javascript">
    var userAgentInfo = navigator.userAgent;
    var Agents = ["Android", "iPhone",
                "SymbianOS", "Windows Phone",
                "iPad", "iPod"];
    var flag = true;
    for (var v = 0; v < Agents.length; v++) {
        if (userAgentInfo.indexOf(Agents[v]) > 0) {
            flag = false;
            break;
        }
    }
    if (!flag) {
        location.href = "/mobile/";
    }
</script>
</head>
<body onkeypress="buttonClick()">
<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
    <!--head-->
    <div class="head_bg">
        <div class="head wrap">
            <div class="logo"><a href="index.html"><img src="images/logo.png" alt="Plate-X" /></a></div>
            <div class="seach">
                <input type="text" id="keyword" /><span onclick="return sea();"></span>
            </div>
            <script type="text/javascript">
                function sea() {
                    var keyword = document.getElementById("keyword").value;
                    window.location.href = "/project_0_0_0_0_0_0_0_0.html?keyword=" + escape(keyword);
                }
        </script>
            <div class="head_r">
                <ul>
                    <%=ViewState["isLog"] %>
                    <li class="my_yx"><a href="">My Plate-X</a>
                        <ul>
                          <%=GetMenu()%>
                        </ul>
                    </li>
                    <li><a href="shopping.html" class="my_shop"><span style="margin-right:5px;"><%=GetProductCount() %></span> in Cart</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="nav_bg">
        <div class="nav wrap">
               <div class="allFood">
                       <h2 onclick="$('#allFoodMenu2').toggle();"><span>Plate-X All</span></h2>
                       <div class="allFoodMenu allFoodMenu2" id="allFoodMenu2">
                            <asp:Repeater ID="repOne" runat="server">
                                <ItemTemplate>
                                <div class="allFood_menu allFood_menu_<%#(Container.ItemIndex + 1) %>"> <div class="menu_xg"><a href="/project_<%#Eval("id") %>_0_0_0_0_0_0_0.html"><%#Eval("typeName") %></a></div>                                    
                                </div>
                                </ItemTemplate>
                            </asp:Repeater>                           
                       </div>
               </div> 
               <div class="nav_lm">
                   <ul>
                       <li style="width: 160px; float:right;"><a href="invite.html" style="font-size:18px;">We Are Hiring</a></li>                       
                   </ul>
               </div>
               <div class="nav_kans">
                   <span></span>
                   <a href="/join.html" style="font-size:18px;">Join Us</a>
               </div>              
        </div>
    </div>
    <div class="blank_bg blank_bg2">
      <div class="overf">
        <div class="banner">
                <ul>
                    <asp:Repeater ID="repBanner" runat="server">
                        <ItemTemplate>
                        <a href="<%#Eval("linkurl") %>"><li style="background-image:url(http://plate-x.com<%#Eval("img1path")%>)"></li></a>
                        </ItemTemplate>
                    </asp:Repeater>
            </ul>
            <span class="btn_l"><img src="images/icon/btn_l.png" height="30" width="30" alt="" /></span>
            <span class="btn_r"><img src="images/icon/btn_r.png" height="30" width="30" alt="" /></span>
        </div>
    <!--main-->
    <div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
    
    <div class="main_bg" style="margin:0 auto; width:100%;">
        <div class="cateTypeImg" style=" background:#ffffff; min-height:500px; height:auto;">
           <div><a href="project_51_0_0_0_0_0_0_0.html"><img src="images/index1.jpg" style="width:100%; margin-bottom:0px;"/></a></div>
            <a href="project_51_0_0_0_0_0_0_0.html"><img src="images/index11.jpg"/></a>
            <a href="project_52_0_0_0_0_0_0_0.html"><img src="images/index2.jpg"/></a>
            
              <a href="project_53_0_0_0_0_0_0_0.html"><img src="images/index4.jpg"/></a>
               <%--<div><a href="project_60_0_0_0_0_0_0_0.html"><img src="images/index5.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
                <div><a href="project_57_0_0_0_0_0_0_0.html"><img src="images/index6.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
                 
                 
                   <div><a href="project_59_0_0_0_0_0_0_0.html"><img src="images/index9.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
                    <div><a href="project_61_0_0_0_0_0_0_0.html"><img src="images/index10.jpg" style="width:100%;margin-bottom:0px;" /></a></div>
--%>
                     <a href="project_54_0_0_0_0_0_0_0.html"><img src="images/index8.jpg"/></a>
                     <a href="project_55_0_0_0_0_0_0_0.html"><img src="images/index3.jpg"/></a>
                    <a href="project_56_0_0_0_0_0_0_0.html"><img src="images/index7.jpg"/></a>
                    <div style="margin-top:20px;"><a href="project_61_0_0_0_0_0_0_0.html"><img src="images/index10.jpg" style="width:100%; margin-bottom:0px;"/></a></div>
        </div>
    </div>
  </div>
</div>
<!--foot-->

<div class="foot_b_bg">
  <div class="foot_b wrap">
    <p><%=DAL.BaseConfigService.GetById(14)%><a href="protocol_6.html" style="text-decoration:none; margin-left: 20px;">【Privacy Policy】</a> &amp; <a href="protocol_7.html" style="text-decoration:none;">【Terms of Use】</a></p>

        <p>Contact：<%=DAL.BaseConfigService.GetById(17) %> <a rel="nofollow" style="margin-left:20px;">Email：<%=DAL.BaseConfigService.GetById(15)%></a></p>
     
  </div>
</div>
<div class="show_bg" style="display:none;background-color:#000;opacity:0.4;position:absolute;width:100%;top:0;left:0;z-index:9999;"></div>


    <script type="text/javascript">
        var h = $('html,body').height() - 120;
        $('.show_bg').height(h);
    </script>
</body>
</html>
<script src="js/updateview.js" type="text/javascript"></script>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("首页", url, 1);    
</script>
