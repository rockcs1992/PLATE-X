<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="basis.aspx.cs" Inherits="CommonBussiness.admin.basis" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>基础设置</title>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<!--编辑器引用 开始-->
   <link rel="stylesheet" href="../kindeditor-v4.1.7/themes/default/default.css" />
	<link rel="stylesheet" href="../kindeditor-v4.1.7/plugins/code/prettify.css" />
	<script charset="utf-8" src="../kindeditor-v4.1.7/kindeditor.js"></script>
	<script charset="utf-8" src="../kindeditor-v4.1.7/lang/zh_CN.js"></script>
	<script charset="utf-8" src="../kindeditor-v4.1.7/plugins/code/prettify.js"></script>
	<script>
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content1', {
	            cssPath: '../kindeditor-v4.1.7/plugins/code/prettify.css',
	            uploadJson: '../kindeditor-v4.1.7/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor-v4.1.7/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content2', {
	            cssPath: '../kindeditor-v4.1.7/plugins/code/prettify.css',
	            uploadJson: '../kindeditor-v4.1.7/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor-v4.1.7/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content3', {
	            cssPath: '../kindeditor-v4.1.7/plugins/code/prettify.css',
	            uploadJson: '../kindeditor-v4.1.7/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor-v4.1.7/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content4', {
	            cssPath: '../kindeditor-v4.1.7/plugins/code/prettify.css',
	            uploadJson: '../kindeditor-v4.1.7/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor-v4.1.7/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content5', {
	            cssPath: '../kindeditor-v4.1.7/plugins/code/prettify.css',
	            uploadJson: '../kindeditor-v4.1.7/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor-v4.1.7/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content6', {
	            cssPath: '../kindeditor-v4.1.7/plugins/code/prettify.css',
	            uploadJson: '../kindeditor-v4.1.7/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor-v4.1.7/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content7', {
	            cssPath: '../kindeditor-v4.1.7/plugins/code/prettify.css',
	            uploadJson: '../kindeditor-v4.1.7/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor-v4.1.7/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	</script>
<!--编辑器引用 结束-->
</head>
<body>
<form id="form10" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
</asp:UpdatePanel>
<div class="rtitle" >基本配置</div>
<div class="rcont">
	<table cellpadding="0" cellspacing="0" border="0">
		<tr>
			<td class="r_tab">网站名称：</td>
			<td class="r_cont">
                <asp:TextBox ID="txtBase1" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="r_tab">网站地址：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase2" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
        <tr>
			<td class="r_tab">网站关键字：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase15" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="r_tab">网站描述：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase3" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="r_tab">网站版权信息：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase4" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="r_tab">站长EMAIL：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase5" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="r_tab">备案号：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase6" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="r_tab">电话：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase7" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="r_tab">免费电话：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase8" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
		<tr style="display:none;">
			<td class="r_tab" >时间设置：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase9" runat="server" Width="500px"></asp:TextBox></td>
		</tr>

        <tr style="display:none;" >
			<td class="r_tab" >下午送货时间：</td>
			<td class="r_cont"><asp:TextBox ID="txtMonthValue" runat="server" Width="500px"></asp:TextBox></td>
		</tr>

        <tr style="display:none;">
			<td class="r_tab" >晚上送货时间：</td>
			<td class="r_cont"><asp:TextBox ID="txtYearValue" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
        <tr style="display:none;">
			<td class="r_tab" >appID：</td>
			<td class="r_cont"><asp:TextBox ID="tb_id" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
        <tr style="display:none;">
			<td class="r_tab" >secret：</td>
			<td class="r_cont"><asp:TextBox ID="tb_secret" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
        <tr style="display:none;">
			<td class="r_tab" >微信授权回调页面地址：</td>
			<td class="r_cont"><asp:TextBox ID="tb_URL" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
        <tr style=" display:none;">
			<td class="r_tab" >首页视频外链：</td>
			<td class="r_cont"><asp:TextBox ID="txtVideo" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
         <tr style="display:none;">
			<td class="r_tab">首页视频封面：</td>
			<td class="r_cont">
                <asp:FileUpload ID="FileUpload3" runat="server" />
                <asp:Label ID="lblURL3" runat="server" Text=""></asp:Label>&nbsp;&nbsp;(600px * 300px)
            </td>
		</tr>
         <tr style="display:none;">
			<td class="r_tab">首页视频上传：</td>
			<td class="r_cont">
                <asp:FileUpload ID="FileUpload4" runat="server" />
                <asp:Label ID="lblURL4" runat="server" Text=""></asp:Label>
            </td>
		</tr>
         <tr style="display:none;">
			<td class="r_tab">移动端推荐首页：</td>
			<td class="r_cont">
                <asp:FileUpload ID="FileUpload5" runat="server" />
                <asp:Label ID="lblURL5" runat="server" Text=""></asp:Label>
            </td>
		</tr>
        <tr style="display:none;">
			<td class="r_tab">Plate-X微信：</td>
			<td class="r_cont">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Label ID="lblURL1" runat="server" Text=""></asp:Label> &nbsp;&nbsp;(100px * 100px)
            </td>
		</tr>
        <tr style="display:none;">
			<td class="r_tab">下载APP：</td>
			<td class="r_cont">
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:Label ID="lblURL2" runat="server" Text=""></asp:Label>&nbsp;&nbsp;(100px * 100px)
            </td>
		</tr>
        <tr style="display:none;">
			<td class="r_tab table_tab">给客户邮件发送信息配置</td>
			<td class="r_cont"></td>
		</tr>
        
        <tr style="display:none;">
			<td class="r_tab">邮箱账号：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase12" runat="server" Width="500px"></asp:TextBox></td>
		</tr>
        <tr style="display:none;">
			<td class="r_tab">邮箱密码：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase13" runat="server" Width="500px" ></asp:TextBox></td>
		</tr>
        <tr style="display:none;">
			<td class="r_tab">SMTP协议：</td>
			<td class="r_cont"><asp:TextBox ID="txtBase14" runat="server" Width="500px"></asp:TextBox>（如：smtp.qq.com）</td>
		</tr>
		<tr>
			<td class="r_tab">&nbsp;</td>
			<td class="r_cont"><asp:Button ID="Button1" runat="server" Text=" 保 存 " onclick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnErWeiCode" runat="server" Text=" 批量生成二维码 " onclick="btnErWeiCode_Click" Visible="false" />&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Button ID="Button2" runat="server" Text=" 重 置 " OnClientClick="return confirm('您确定要重置吗？');" onclick="Button2_Click" /></td>
		</tr>         
	</table>
</div>
</form>
</body>
</html>
