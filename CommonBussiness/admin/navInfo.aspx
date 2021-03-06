﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="navInfo.aspx.cs" Inherits="CommonBussiness.admin.navInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>相见以诚</title>
<link href="css/admin.css" type="text/css" rel="stylesheet"/>
<script src="js/admin.js" type="text/javascript"></script>
<style type="text/css">
td{ line-height:30px;}
</style>
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
	</script>
<!--编辑器引用 结束-->
</head>
<body>
<form id="form1" runat="server">

<div class="rtitle" >相见以诚</div>
<div class="rcont" style=" min-height:500px;">    
<asp:Panel ID="pnlAdd" runat="server" Visible="false">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr>
        <td class="r_tab2">首页标题</td>
            <td class="r_cont">
                <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
               </td>
        </tr>
        <tr>
        <td class="r_tab2">首页标题2</td>
            <td class="r_cont">
                <asp:TextBox ID="txtTitle2" runat="server" Width="300px"></asp:TextBox>
               </td>
        </tr>
        <tr>
        <td class="r_tab2">内容标题</td>
            <td class="r_cont">
                <asp:TextBox ID="txtContentTitle" runat="server" Width="300px"></asp:TextBox>
               </td>
        </tr>
        <tr>
        	<td class="r_tab2">内容</td>
            <td class="r_cont">
                <textarea id="content1" cols="100" rows="8" style="height:400px;visibility:hidden; width:100%" runat="server"></textarea>
             </td>
        </tr>        
        <tr>
            <td class="r_tab2">链接</td>
            <td class="r_cont"><asp:TextBox ID="txtLinkUrl" runat="server" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="r_tab2">图片1</td>
            <td class="r_cont">
                <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Label ID="lblURL1" runat="server"
                    Text="Label"></asp:Label></td>
        </tr>
       
        <tr>
        <td class="r_tab2">&nbsp;</td>
            <td class="r_cont">
                <asp:Button ID="Button1" runat="server" Text="保存" onclick="Button1_Click" /><asp:Label ID="lblId" runat="server"
                    Text="" Visible="false"></asp:Label><asp:Label ID="lblError" runat="server"
                    Text="" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
    </table>
</asp:Panel>
    <asp:Panel ID="pnlList" runat="server">
   
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold; line-height:20px;">
            <td width="20%">图片</td>
            <td width="15%">首页标题</td>
            <td width="15%">首页标题2</td>
            <td width="15%">列表页标题</td>
            <td width="15%">链接</td>
            <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand" >
            <ItemTemplate>
                <tr>
                    <td><img src="<%#Eval("indexImg") %>" style="width:100px; height:100px;" /></td>
                    <td><%#Eval("indexTitle")%></td>
                     <td><%#Eval("indexTitle2")%></td>
                      <td><%#Eval("title")%></td>                
                    <td><%#Eval("linkurl") %></td>
                    <td>
                    <asp:LinkButton ID="lbtnMod" runat="server" CssClass="edit_bt" CommandName="mod" CommandArgument='<%#Eval("id") %>' >编辑</asp:LinkButton>
                    <asp:LinkButton ID="lbtnDel" runat="server" CssClass="edit_bt" OnClientClick="return confirm('您确定要删除吗？');" CommandName="del" CommandArgument='<%#Eval("id") %>' >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="6" align="right">
                <asp:Button ID="Button2" runat="server" Text="添加" onclick="Button2_Click" 
                    Width="102px" />
            </td>
        </tr>
    </table>
     </asp:Panel>
</div>
</form>
</body>
</html>
