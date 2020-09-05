<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CommonBussiness.admin.login" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Plate-X后台登录</title>
    <script src="/script/jquery-1.9.1.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js" data-appid="101149316" data-redirecturi="http://www.bjqianchen.com/backqq_qianchen.aspx" charset="utf-8"></script>

<link href="css/admin.css" type="text/css" rel="stylesheet">
<style>
.login_main{ width:400px; height:200px; background:#eee; margin-left:auto; margin-right:auto; margin-top:150px; -webkit-box-shadow:0px 0px 50px #000; -moz-box-shadow:0px 0px 50px #000; -o-box-shadow:0px 0px 50px #000; box-shadow:0px 0px 50px #000; -webkit-border-radius:5px; -moz-border-radius:5px; -o-border-radius:5px; border-radius:5px; color:#333; font-size:14px; -webkit-text-shadow:0px 1px 0px #fff;-moz-text-shadow:0px 1px 0px #fff; -o-text-shadow:0px 1px 0px #fff; text-shadow:0px 1px 0px #fff;}
.login_main table td{ padding:5px;}
</style>
</head>
<body style="background:#292f33">
<form id="form1" runat="server">
<div class="login_main">
	<table cellpadding="0" cellspacing="0" border="0" width="100%">
    	<tr>
        	<td style=" width:30%; border-bottom:1px solid #aaa; box-shadow:0px 1px 0px #fff; " ><span style="font-size:30px; padding:5px 10px 5px 20px;color:#38769f">Login</span></td><td style=" width:70%; border-bottom:1px solid #aaa; box-shadow:0px 1px 0px #fff; "><span style=" float:right; font-size:16px; color:#999;  margin-right:20px;">Plate-X</span></td>
        </tr>
        <tr>
        	<td style="text-align:right; padding-top:15px; font-size:14px;">用户名：</td>
            <td style=" padding-top:15px;">
                <asp:TextBox ID="txtUserName" runat="server" TabIndex="1"></asp:TextBox></td>
        </tr>
        <tr>
        	<td style="text-align:right; font-size:14px;">密&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
            <td><asp:TextBox ID="txtPassWord" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
        	<td></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="登陆" 
                    OnClientClick="return checkAdminLoginInput()" OnClick="Button1_Click" style=" padding:5px 20px; font-size:16px;" />                   
                    </td>
        </tr>
    </table>
</div>
</form>
<script type="text/javascript">
//添加管理员验证
function checkAdminLoginInput() {
    var name = document.getElementById("txtUserName").value;
    var pass = document.getElementById("txtPassWord").value;
    if (name.length == 0 || pass.length < 6) {
        alert('各项不能为空!');
        return false;
    }
 }
</script>
</body>
</html>


