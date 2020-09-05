<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CommonBussiness.register" %>

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
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/region_select.js"></script>
    <%--<script type="text/javascript" src="js/login.js"></script>--%>
    <script src="js/login.js" type="text/javascript"></script>
    <script src="js/reg.js" type="text/javascript"></script>
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
        .registerBox_r{display:none;}
        .registerBox_l{ display:block}
        .registerBox{ position: fixed;width:100%;height:100%; background:rgba(0,0,0,0.6);top:0;}
        .registerBox_l{ position:absolute;top:20%;left:33%;}
        .registerBox_r{ position:absolute;top:50%;margin-top:-240px;left:50%;margin-left:-260px}
        .seach{ margin:45px 65px 0 65px}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<!--head-->

<%--<div class="changePassword">
        <div class="close_fp">×</div>
        <h2></h2>
        <div class="password01"><input type="password"  placeholder="Phone Cannot Be Blank"/></div>
        <div class="password02"><input type="password"  placeholder="请输入Image Verification Code"/></div>
        <div class="passBtn">提交</div>
</div>--%>
<uc1:top ID="top1" runat="server" />
<!--list-->
<div class="blank_bg">
    <div class="overf">
        <div class="register_bg">
            <div class="registerBox">
                <div class="registerBox_l" style="height:510px;">
                    <h2></h2>

                        <div class="one">
                            <label for="tel" style="width:220px;margin-top: 3px;">Phone：+1</label>
                            <asp:TextBox ID="tel" runat="server" CssClass="a1 a1_img" style=" margin-left:5px; width:190px;    background: url(../images/icon/register01.png) no-repeat scroll 170px 5px;"></asp:TextBox>
                        </div>
                        <div class="one">
                            <label for="password">Verification Code：</label>
                            <input type="password" id="password" class="a1 a1_img2"/>
                        </div>
                        <div class="one">
                            <label for="passwords">Confirm Verification Code：</label>
                            <input type="password" id="passwords" class="a1 a1_img2"/>
                        </div>
                        <div class="one">
                            <label for="username">Image Verification Code：</label>
                            <input type="text" id="username" class="a1"/>

                            <div class="yzm"><img src="/VerifyCode.aspx" id="imgRandom" onmousedown="changeImage();" title="Change" class="yanz"/></div>
                            <div class="next" onmousedown="changeImage();">Change</div>
                            <input type="hidden" id="hidcode" />
                        </div>
                        <div class="one">
                            <label for="telusername">Text Verification Code：</label>
                             <asp:TextBox ID="txtCode" runat="server" placeholder="Text Verification Code" class="a1" style="margin-right: 5px; width:160px;" ></asp:TextBox>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="lbtnGetCode" runat="server" Text="Send Verification Code" BackColor="#808080" ForeColor="White" Width="136px" onclick="lbtnGetCode_Click"  /> 
                 <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick"></asp:Timer>
        </ContentTemplate>
      </asp:UpdatePanel>                          
                        </div>
                        <div class="two">
                            <!--<p><input type="checkbox" id="check" /><a href="">服务条款</a></p>-->
                            <a id="send" onclick="return reg();" style="display:block; width:80%; margin-left:10%;">Sign Up</a>
                            
        <p style="float: right; margin:20px; margin-right:10%; margin-top:15px;"><a href="protocol_6.html" style="text-decoration:none;">【Privacy Policy】</a> &amp; <a href="protocol_7.html" style="text-decoration:none;">【Terms of Use】</a></p>
                        </div>
                </div>
                <div class="registerBox_r" style=" height:400px;">
                    <div class="login_r">
                            <h2></h2>

                            <div class="one">
                                <label for="tel">Username：</label>
                                +1 <input type="text" id="mobile" class="a1_img" placeholder="Phone Cannot Be Blank" style="float:none; width:194px;" />
                            </div>
                            <div class="one">
                                <label for="tel">Password：</label>
                                <input type="password" id="loginpass" class="a1_img2" placeholder="Input Password"  />
                            </div>
                            <h3 class="changePass"><a href="javascript:;">Forgot Password？</a></h3>

                            <div class="login_btn" onmousedown="return login();" style="width: 56%;margin: 20px 0 0 125px;">Log In</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!--foot-->
<uc2:bottom ID="bottom1" runat="server" />
    <asp:HiddenField ID="hidAction" runat="server" />
    <div class="findPassword">
    <div class="close_fp">×</div>
    <h2 style="margin-bottom:30px;"></h2>
        <div class="one">
            <label for="tel">Phone：</label>
            +1<input type="text" id="loginTel" class="a1" style="float:none; width:190px; margin-left:8px;" />
        </div>
        <div class="one">
            <label for="telusername">Text Verification Code：</label>
            <input type="text" id="resetSMScode" class="a1" style="width:64px; margin-right:2px;" />
            <a onclick="return getSMS(this);" style="width:150px; background-color:#666; color:#fff; display:inline-block; padding:3px; text-align:center; cursor:pointer;">Send Verification Code</a>
            <%--<div class="telYzm" style="width:105px; float:right;">
                Send Verification Code
            </div>--%>
        </div>
        <div class="one">
            <label for="tel">Verification Code：</label>
            <input type="password" id="pass1" class="a1" />
        </div>
        <div class="one">
            <label for="tel">Confirm Verification Code：</label>
            <input type="password" id="pass2" class="a1" />
        </div>
        <div onclick="return checkResetPass();" class="find_btn" style="margin-top:0px;">Save</div>
</div>
  <input type="hidden" id="regsmsstatus" value="1" />
    </form>
</body>
</html>

<script>
    var action = document.getElementById("hidAction").value;
    if (action == "reg") {
        $(".registerBox_r").hide();
        $(".registerBox_l").show();
        
    }
    else {
        $(".registerBox_r").show();
        $(".registerBox_l").hide();
    }
    ///重置密码
    function checkResetPass() {
        var mobile = document.getElementById("loginTel").value;
        if (mobile.length == 0) {
            alert("Phone Can not Be Blank！");
            return false;
        }
        if (mobile.length != 10) {
            alert("Wrong mobile number input！");
            return false;
        }
        var resetSMScode = document.getElementById("resetSMScode").value;
        var pass1 = document.getElementById("pass1").value;
        var pass2 = document.getElementById("pass2").value;

        if (resetSMScode.length == 0 || pass1.length == 0 || pass2.length == 0) {
            alert("The information cannot be blank");
            return false;
        }
        if (pass1 != pass2) {
            alert("The new password must be the same");
            return false;
        }
        $.ajax(
	            {
	                type: 'POST',
	                url: "/jsData/user.aspx",
	                data: { action: "ResetPass", mobile: mobile, resetSMScode: resetSMScode, pass1: pass1},
	                success: function (msg) {
	                    if (msg == "success") {
	                        alert("Reset password success,login please");
	                        location.href = "/register.html?action=login";
	                    } else if ($.trim(msg) == "codeError") {
	                        alert('Verification is wrong！');
	                    } 
	                    else {
	                        alert("Fail to find");
	                    }
	                }
	            }
	            );
    }
    ///快速登录
    function getSMS(obj) {
        var status = document.getElementById("regsmsstatus").value;
        if (status == 0) {
            return false;
        }
        var mobile = document.getElementById("loginTel").value;
        if (mobile.length == 0) {
            alert("Phone Can not Be Blank！");
            return false;
        }
        if (mobile.length != 10) {
            alert("Wrong mobile number input！");
            return false;
        }
        $.ajax(
	            {
	                type: 'POST',
	                url: "/jsData/user.aspx",
	                data: { action: "GetSMS", mobile: mobile },
	                success: function (msg) {
	                    if (msg == "success") {
	                        alert("Verification Code Sent");
	                        settime(obj);
	                        document.getElementById("regsmsstatus").value = 0;
	                    }
	                    else {
	                        alert("Verification Code Failed to Send");
	                    }
	                }
	            }
	            );
    }
    var countdown = 120;
    function settime(val) {
        if (countdown == 0) {
            val.removeAttribute("disabled");
            val.value = "Send Verification Code";
            countdown = 120;
            document.getElementById("regsmsstatus").value = 1;
            $(val).html("Send Verification Code");
        } else {
            val.setAttribute("disabled", true);
            $(val).html("(" + countdown + ") Seconds");
            countdown--;
            setTimeout(function () {
                settime(val)
            }, 1000)
        }

    }
//    function reg() {
//        var tel = document.getElementById("tel").value;
//        var password = document.getElementById("password").value;
//        var code = document.getElementById("txtCode").value;
//        if (tel.length == 0 || password.length == 0 || code.length == 0) {
//            alert('The information cannot be blank！');
//            return false;
//        }
//        $.ajax(
//	        {
//	            url: "/JsData/user.aspx?action=Reg&code=" + code + "&tel=" + tel + "&password=" + password + "&t=" + new Date().getTime() + "",
//	            type: 'GET',
//	            success: function (msg) {
//	                if ($.trim(msg) == "success") {
//	                    window.location.href = "/my_person.html";
//	                } else if ($.trim(msg) == "existsMobile") {
//	                    alert('该用户已Join！');
//	                } else if ($.trim(msg) == "codeError") {
//	                    alert('PhoneImage Verification Code错误！');
//	                } else {
//	                    alert('Join失败！');
//	                }
//	            }
//	        }
//	    );

//        return false;
//    }
</script>