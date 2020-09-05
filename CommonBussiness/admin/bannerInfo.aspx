<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bannerInfo.aspx.cs" Inherits="CommonBusiness.admin.bannerInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>首页轮播图设置</title>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
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
<div class="rtitle" >首页轮播图设置</div>
<div class="rcont" style=" min-height:500px;">
    <asp:Panel ID="pnlAdd" runat="server" Visible="false">   
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
         <tr style="display:none;">
             <td class="r_tab2">模块</td>
            <td class="r_cont">
                <asp:DropDownList ID="ddlModule" runat="server">
                </asp:DropDownList>
               </td></tr>
    	<tr>
             <td class="r_tab2">名称</td>
            <td class="r_cont">
                <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
               </td></tr>      <tr style="display:none;">
             <td class="r_tab2">名称3</td>
            <td class="r_cont">
                <asp:TextBox ID="txtTitleEn" runat="server" Width="300px"></asp:TextBox>
               </td></tr>
        <tr>
         <td class="r_tab2">链接</td>
            <td class="r_cont"><asp:TextBox ID="txtLinkUrl" runat="server" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
        <td class="r_tab2">顺序号</td>
            <td class="r_cont"><asp:TextBox ID="txtOrder" runat="server" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="r_tab2">图片</td>
            <td class="r_cont">
                <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Label ID="lblURL" runat="server" Text=""></asp:Label>（1920*480）</td>
        </tr>        
        <tr style="display:none;">
            <td class="r_tab2">背景</td>
            <td class="r_cont">
                <asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblURL2" runat="server" Text=""></asp:Label></td>
        </tr>
         
        <tr>
           <td>&nbsp;</td>
            <td class="r_cont"><asp:Button ID="Button1" runat="server" Text="保存" onclick="Button1_Click" /><asp:Label
                    ID="lblId" runat="server" Text="" Visible="false"></asp:Label><asp:Label
                    ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlList" runat="server">    
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
            <td width="5%">ID</td> 
            <td width="30%">图片</td>
            <td width="10%">名称</td>  
             <td width="20%">链接</td>  
           <%-- <td width="10%">模块</td>    --%>
            <td width="10%">添加时间</td>
            <td width="5%">顺序号</td>
            <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand" >
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ID") %></td>
                    <td><img src="<%#Eval("img1path") %>" style="width:200px; height:100px;" /></td> 
                    <td><%#Eval("title") %></td>  
                    <td><%#Eval("linkurl") %></td>  
                    <%--<td><%#GetModule(Eval("status")) %></td>  --%>
                    <td><%#Eval("addTime","{0:yyyy-MM-dd}") %></td>
                    <td><%#Eval("orderNum") %></td>
                    <td><asp:LinkButton ID="lbtnMod" runat="server" CssClass="edit_bt" CommandName="mod" CommandArgument='<%#Eval("id") %>' >编辑</asp:LinkButton>                    
                    <asp:LinkButton ID="lbtnDel" runat="server" CssClass="edit_bt" OnClientClick="return confirm('您确定要删除吗？');" CommandName="del" CommandArgument='<%#Eval("id") %>' >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="8" align="right">
                <asp:Button ID="Button2" runat="server" Text="添加" onclick="Button2_Click" 
                    Width="95px" /></td>
        </tr>
    </table>
    </asp:Panel>
</div>
</form>
</body>
</html>
