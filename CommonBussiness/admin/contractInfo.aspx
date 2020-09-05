
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contractInfo.aspx.cs" Inherits="CommonBusiness.admin.contractInfo" ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml" lang="zh" >
<head id="Head1" runat="server">
<meta charset="utf-8">
<title>关于我们栏目设置</title>
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
	</script>
<!--编辑器引用 结束-->
<link href="css/admin.css" type="text/css" rel="stylesheet">
<style type="text/css">
        #bodyImg1{
            FILTER: progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)
        }
    </style>
    <script type="text/javascript">
        function SetHidLabel(obj) {
            document.getElementById("hidLabel").value = obj;
            document.getElementById("txtLabel").value = obj;
        }
    </script>
    <script src="js/admin.js" type="text/javascript"></script>
    
    </head>
<body>
<form id="form10" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
</asp:UpdatePanel>
<div class="rtitle" >联系信息设置</div>
<div class="rcont">
	<table cellpadding="0" cellspacing="0" border="0">		
    <tr><td class="tleft" style="background:#eee;" colspan="10"></td></tr>
    <tr style="display:none;">
			<td class="r_tab">二维码：</td>
			<td class="r_cont">
            <asp:FileUpload ID="filepic_weibo" runat="server"  onchange="javascript:__doPostBack('lbtnWeiBo','')"/><asp:LinkButton ID="lbtnWeiBo" runat="server" OnClick="lbtnWeiBo_Click"></asp:LinkButton>
                        <asp:Label ID="lblImgWeiBo" runat="server" Text=""></asp:Label>
            </td>
            <td>&nbsp;</td>
		</tr>
        <tr><td colspan="3">&nbsp;</td></tr>
		<tr>
			<td class="r_tab">联系信息：</td>            
			<td class="r_cont">
             <!--编辑器开始-->     
            <textarea id="content2" cols="10" rows="5" style="height:600px;visibility:hidden; width:800px" runat="server"></textarea>
             <!--编辑器结束-->            
            </td>
            <td style="text-align:left;"></td>
		</tr>
		<tr>
			<td class="r_tab">&nbsp;</td>
			<td style="text-align:left;"><asp:Button ID="Button1" runat="server" Text=" 保 存 " onclick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Button ID="Button2" runat="server" Text=" 重 置 " OnClientClick="return confirm('您确定要重置吗？');" onclick="Button2_Click" /></td>
            <td class="r_cont">&nbsp;</td>
		</tr>         
	</table>
</div>
</form>
</body>
</html>
