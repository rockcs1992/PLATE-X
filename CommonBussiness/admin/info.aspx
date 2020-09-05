<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="CommonBusiness.admin.info" ValidateRequest="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
    
    <script src="js/admin.js" type="text/javascript"></script>
       <script src="js/jquery-1.8.2.min.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="rtitle" >添加信息</div>
<div class="rcont">
    <div class="news">
    	<div style=" width:80%; margin-left:50px; margin-top:20px;">
        列表图：<asp:FileUpload ID="FileUpload1" runat="server" /><asp:Label ID="lblURL" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<br /><br />
        <asp:Label ID="lblIndexLabel" runat="server" Text="热点图：" ></asp:Label><asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblIndexImg" runat="server" Text="" ></asp:Label>
        <br /><br />
            <asp:Label ID="lblCate" runat="server" Text="分类："></asp:Label>
            <asp:DropDownList ID="ddlCate" runat="server" Width="200px" >
            </asp:DropDownList>
        <br />
        <br />标题：
            <asp:TextBox ID="txtTitle" runat="server" CssClass="n_title"></asp:TextBox>
            <div class="blank_10"></div>
            <!--编辑器开始-->
            <asp:Label ID="lblInfoContent" runat="server" Text="信息内容"></asp:Label>：
            <textarea id="content1" cols="100" rows="8" style="height:400px;visibility:hidden; width:100%" runat="server"></textarea><br />
            <asp:Label ID="lblPrice" runat="server" Text="刊例" Visible="false"></asp:Label>
            <textarea id="content2" cols="100" rows="8" style="height:400px;visibility:hidden; width:100%" runat="server" visible="false"></textarea>
             <!--编辑器结束-->
        <div class="border_1 mt20 bgfa">
        	<div class="n_tab">信息参数设置</div>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
           
            <tr>
                	<td class="table_l">摘要：</td>
                    <td class="table_r"><asp:TextBox ID="txtZhaiYao" runat="server" style="height:70px; width:100%" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
            	<tr>
                	<td class="table_l">关键字：</td>
                    <td class="table_r"><asp:TextBox ID="txtKeyWord" runat="server" style="height:70px; width:100%; margin-right:5px;" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                	<td class="table_l">信息描述：</td>
                    <td class="table_r"><asp:TextBox ID="txtDesc" runat="server" style="height:70px; width:100%" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
       
                <tr><td>&nbsp;</td>
                    <td align="center" style=" width:80%; height:50px;"> <asp:Button ID="btnRelease" runat="server" Text="        发      布         " 
                                OnClientClick="return checkNewsInput()" onclick="btnRelease_Click"  Height="30px"/><asp:Label ID="lblError"
                                    runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
        </div>
        </div>     
    </div>
</div>
</form>
</body>
</html>
