<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addInvite.aspx.cs" Inherits="CommonBussiness.admin.addInvite" ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml" lang="zh" >
<head id="Head1" runat="server">
<meta charset="utf-8">
<title>基础设置</title>
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
	        var editor1 = K.create('#txtZhaiYao', {
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
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="rtitle" >发布职位</div>
<div class="rcont">
    <div class="news">
    	<div class="n_left mt20 fl">
         <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	    <tr>
                <td class="r_tab2">职位名称</td>
                <td class="r_cont">
                   <asp:TextBox ID="txtTitle" runat="server" CssClass="n_title" Width="500px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="r_tab2">招聘人数</td>
                <td class="r_cont">
                   <asp:TextBox ID="txtPeopleCount" runat="server" CssClass="n_title" Width="500px"></asp:TextBox>人
                    </td>
            </tr>
            <tr>
                <td class="r_tab2">任职要求</td>
                <td class="r_cont">
                   <textarea id="content1" cols="100" rows="6" style="height:300px;visibility:hidden; width:70%" runat="server"></textarea>

                    </td>
            </tr>
            <tr>
                <td class="r_tab2">描述</td>
                <td class="r_cont">               
                <textarea id="txtZhaiYao" cols="100" rows="6" style="height:300px;visibility:hidden; width:70%" runat="server"></textarea>
                    </td>
            </tr>
            <tr>
                <td class="r_tab2">&nbsp;</td>
                <td class="r_cont">
                    <asp:TextBox ID="txtHidInfo" runat="server" Visible="false" TextMode="MultiLine"></asp:TextBox>
                   <asp:Button ID="btnRelease" runat="server" Text="保存"  onclick="btnRelease_Click" Width="100px" /><asp:Label ID="lblError"
                                    runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>   
                    </td>
            </tr>
        </table>
    </div>
</div>

</form>
</body>
</html>
