<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project.aspx.cs" Inherits="CommonBussiness.project" %>

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
    <link rel="stylesheet" type="text/css" href="css/list.css" />
    <link rel="stylesheet" type="text/css" href="css/project.css" />
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/js_menu2.js"></script>
    <style>
    .result_title { padding: 7px 0; border-bottom: 1px solid #eeeeee; -moz-box-sizing: border-box; -webkit-box-sizing: border-box; -ms-box-sizing: border-box; -o-box-sizing: border-box; box-sizing: border-box; position: relative; top: -1px; margin-bottom: 2%; }
.result_title span { color: #7c7c7c; display: inline-block; width: 25%; position: relative; font-size: 14px; text-align: center; }
.result_title span.active { color: #ff0000; }
.result_title .triangle:after { content: ''; width: 8px; height: 12px; background: url(../images/formal_san.png) no-repeat center / contain; margin-left: 6px; display: inline-block; }
.result_title .triangle.arrow_up:after { background: url(../images/top_san.png) no-repeat center / contain; }
.result_title .triangle.arrow_down:after { background: url(../images/bottom_san.png) no-repeat center / contain; }
    </style>
    <script>
        //搜索结果页 
        $(".result_title .triangle").click(function () {
            $(this).addClass("active").siblings().removeClass("active");
            $(this).siblings().removeClass("arrow_up");
            $(this).siblings().removeClass("arrow_down");
            if ($(this).hasClass("arrow_up")) {
                $(this).removeClass("arrow_up").addClass("arrow_down");
            } else {
                $(this).addClass("arrow_up").removeClass("arrow_down");
            }
        });
    </script>
</head>
<body>
<form id="form1" runat="server">
<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>    <!--head-->
    
    <uc1:top ID="top1" runat="server" />
    <!--project-->
    <div class="list_bg">
      <div class="project wrap project_mar">
        <div class="project_t">
          <h2><%=ViewState["productName"] %></h2>
          <ul>
              <%=GetCate() %>
          </ul>
        </div>
        <div class="project_main">
          <div class="project_pro">
            <ul>
                <asp:Repeater ID="repInfo" runat="server">
                    <ItemTemplate>
                    <li>
                        <a href="/project_list_<%#Eval("id") %>.html">
                          <s><img src="<%#Eval("listImgUrl")%>" alt="<%#Eval("proName")%>" /></s>
                          <p><%#Eval("proName")%></p>
                          <h4>$<span><%#Eval("price1","{0:0.00}") %></span>（<%#Eval("unit1")%>）</h4>
                        </a>
                      </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
          </div>
        </div>
      </div>
    </div>
<!--foot-->
 <uc2:bottom ID="bottom1" runat="server" />
<div class="show_bg" style="display:none;background-color:#000;opacity:0.4;position:absolute;width:100%;top:0;left:0;z-index:9999;"></div>

<script type="text/javascript">
   // var h = $('html,body').height() - 120;
    var h = $('html,body').height() - 120 + 10000; 
    $('.show_bg').height(h);
</script>
</form>
</body>
</html>