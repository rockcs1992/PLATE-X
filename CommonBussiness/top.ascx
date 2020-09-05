<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top.ascx.cs" Inherits="CommonBussiness.top" %>
 <script type="text/javascript">
     function buttonClick() {
         if ((event.which == 13) || (event.keyCode == 13)) {
             event.cancelBubble = true;
             event.returnValue = false;
             sea();
         }
     }
</script>
<div class="head_bg" onkeypress="buttonClick()">
    <div class="head wrap">
        <div class="logo"><a href="index.html"><img src="images/logo.png" alt="Plate-X"/></a></div>
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
                <%--<li class="register01"><a href="/register.html">Join</a></li><li>&nbsp;&nbsp;|&nbsp;&nbsp;</li><li class="login01"><a href="/register.html">Log In</a></li>--%>
                <%=ViewState["isLog"] %>
                <%--<li><a href="">丨</a></li>--%>
                <li class="my_yx"><a href="">My Plate-X</a>
                    <ul>
                        <%=GetMenu() %>                        
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
            <h2><span>Plate-X All</span></h2>

            <div class="allFoodMenu">
                <asp:Repeater ID="repOne" runat="server">
                    <ItemTemplate>
                    <div class="allFood_menu allFood_menu_<%#(Container.ItemIndex + 1) %>"> <div class="menu_xg"><a href="/project_<%#Eval("id") %>_0_0_0_0_0_0_0.html"><%#Eval("typeName") %></a></div>
                       <%-- <div class="allFood_menu_main">
                            <div class="menu_bg"><img src="images/xiangJ0<%#GetNum(Container.ItemIndex + 1) %>.png" alt="<%#Eval("typeName") %>" /></div>
                            <ul>
                                <%#GetSon(Eval("id")) %>
                            </ul>
                        </div>--%>
                    </div>
                    </ItemTemplate>
                </asp:Repeater>
                
            </div>
        </div>
        
        
    </div>
</div>