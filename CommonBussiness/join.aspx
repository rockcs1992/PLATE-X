<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="join.aspx.cs" Inherits="CommonBussiness.join" %>

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
    <link rel="stylesheet" type="text/css" href="css/jiesuan.css"/>
 
<script src="js/jquery-1.11.3.min.js"
        type="text/javascript"></script>
    <%--<script type="text/javascript" src="js/login.js"></script>--%>
    <%--<script src="js/login.js" type="text/javascript"></script>
    <script src="js/reg.js" type="text/javascript"></script>--%>
    <script language="javascript" type="text/javascript">      
      function changeImage() {
            //单击触发图片重载事件，完成图片Image Verification Code的更换
            document.getElementById("imgRandom").src = document.getElementById("imgRandom").src + '?';
        }
</script>
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
           location.href = "/mobile/login.html";
       }
       
</script>
    <style type="text/css">
        .registerBox_l{ display:block}
        .registerBox{ position: fixed;width:100%;height:100%; background:rgba(0,0,0,0.6);top:0;}
        .registerBox_l{ position:absolute;top:50%;margin-top:-240px;left:50%;margin-left:-260px}
        .registerBox_r{ position:absolute;top:50%;margin-top:-240px;left:50%;margin-left:-260px}
        .seach{ margin:45px 65px 0 65px}
        .one{ height:42px;}
         .one input{ width:80%; margin-left:10%;}
        .one input[type=radio]{ width:20px;margin-left: 20%; }
        .one label{ width:130px; line-height:25px;text-align: left;margin-left: 10px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<!--head-->

<uc1:top ID="top1" runat="server" />
<!--list-->
<div class="blank_bg">
    <div class="overf">
        <div class="register_bg">
            <div class="registerBox">
                <div class="registerBox_l" style="height:748px; top:35%;">
                    <a style="margin:10px; float:left; font-size:14px; cursor:pointer;" onclick="javascript:history.go(-1);">Return</a>
                    <h2 style="margin: 20px auto 40px;"></h2>
                    <div class="one">
                            <asp:RadioButtonList ID="radShoperType" runat="server" 
            RepeatDirection="Horizontal" Width="100%">
            <asp:ListItem Value="1" Selected="True">I own a restaurant </asp:ListItem>
            <asp:ListItem Value="2"> I own a store</asp:ListItem>
        </asp:RadioButtonList>
                        </div>
                        <div class="one">
                            <label for="tel" style="width:80px;margin-left:50px;">Phone：+1</label>
                            <asp:TextBox ID="tel" runat="server" CssClass="a1" style=" width:65%; margin-left:0px;" placeholder="Input Phone"></asp:TextBox>
                        </div>
                        <div class="one">                           
                             <asp:TextBox ID="txtCode" runat="server" placeholder="Text Verification Code" class="a1" style="margin-right: 5px; width:40%;" ></asp:TextBox>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="lbtnGetCode" runat="server" Text="Send Verification Code" BackColor="#808080" ForeColor="White" Width="38%" onclick="lbtnGetCode_Click" style="margin-left: 1%;"  /> 
                 <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick"></asp:Timer>
        </ContentTemplate>
      </asp:UpdatePanel>                          
                        </div>
                        <div class="one">
                             <input type="password" id="password" class="a1" placeholder="Input Password" />
                        </div>
                        <div class="one">
                             <input type="text" id="relname" class="a1" placeholder="First Name" />
                        </div>
                        <div class="one">
                             <input type="text" id="surname" class="a1" placeholder="Last Name" />
                        </div>
                        <div class="one">
                             <input type="text" id="shoperName" class="a1" placeholder="Restaurant/Store Name" />
                        </div>
                        <div class="one">
                             <input type="text" id="street" class="a1" placeholder="Street1" />
                        </div>
                        <div class="one">
                             <input type="text" id="street2" class="a1" placeholder="Street2" />
                        </div>
                        <div class="one">
                             <input type="text" id="city" class="a1" placeholder="City" />
                        </div>
                        <div class="one">
                             <input type="text" id="province" class="a1" placeholder="State" />
                        </div>
                        <div class="one">
                             <input type="text" id="email" class="a1" placeholder="Email" />
                        </div>
                        <div class="one">
                             <input type="text" id="remark" class="a1" placeholder="Introduction" />
                        </div>
                        
                        <div class="two">
                            <!--<p><input type="checkbox" id="check" /><a href="">服务条款</a></p>-->
                            <a id="send" onclick="return regShop();" style="display:block; width:80%; margin-left:10%;">Submit</a>
                            <p style="float: right; margin:20px; margin-right:10%; margin-top:15px;"><a href="protocol_6.html" style="text-decoration:none;">【Privacy Policy】</a> &amp; <a href="protocol_7.html" style="text-decoration:none;">【Terms of Use】</a></p>
                        </div>
                </div>
                
            </div>
        </div>
    </div>
</div>
<!--foot-->
<uc2:bottom ID="bottom1" runat="server" />
    <asp:HiddenField ID="hidAction" runat="server" />
    </form>
</body>
</html>

<script>
    $(".registerBox_l").show();
    ///Join
    function regShop() {
        var surname = document.getElementById("surname").value;
        var relname = document.getElementById("relname").value;
        var shoperName = document.getElementById("shoperName").value;
        var street = document.getElementById("street").value;
        var street2 = document.getElementById("street2").value;
        var city = document.getElementById("city").value;
        var province = document.getElementById("province").value;
        var email = document.getElementById("email").value;
        var remark = document.getElementById("remark").value;

        var tel = "1" + document.getElementById("tel").value;
        var password = document.getElementById("password").value;
        var code = document.getElementById("txtCode").value;
        if (tel.length == 0 || password.length == 0 || code.length == 0) {
            alert('The information cannot be blank！');
            return false;
        }
        var shopType = 1;
        if (document.getElementById("radShoperType_1").checked) {
            shopType = 2;
        }
        $.ajax(
	        {
	            url: "/JsData/user.aspx?action=RegShop&street2=" + street2 + "&shopType=" + shopType + "&surname=" + surname + "&relname=" + relname + "&shoperName=" + shoperName + "&street=" + street + "&city=" + city + "&province=" + province + "&email=" + email + "&remark=" + remark + "&code=" + code + "&tel=" + tel + "&password=" + password + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if ($.trim(msg) == "success") {
	                    window.location.href = "shopInfo_edit.html";
	                } else if ($.trim(msg) == "existsMobile") {
	                    alert('Phone Exists！');
	                } else if ($.trim(msg) == "codeError") {
	                    alert('Phone Verification Code Error！');
	                } else {
	                    alert('Join Fail！');
	                }
	            }
	        }
	    );

        return false;
    }
</script>