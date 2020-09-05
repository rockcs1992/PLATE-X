<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="friendInfo.aspx.cs" Inherits="CommonBussiness.admin.friendInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>基础设置</title>
<link href="css/admin.css" type="text/css" rel="stylesheet"/>
<script src="js/admin.js" type="text/javascript"></script>
<style type="text/css">
td{ line-height:30px;}
</style>
</head>
<body>
<form id="form1" runat="server">

<div class="rtitle" >合作伙伴</div>
<div class="rcont" style=" min-height:500px;">    
<asp:Panel ID="pnlAdd" runat="server" Visible="false">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr>
        <td class="r_tab2">title</td>
            <td class="r_cont">
                <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
               </td>
        </tr>
        <tr>
        	<td class="r_tab2">alt</td>
            <td class="r_cont">
                <asp:TextBox ID="txtAlt" runat="server" Width="300px"></asp:TextBox></td>
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
            <td class="r_tab2">顺序</td>
            <td class="r_cont">
            <asp:TextBox ID="txtOrder" runat="server" Width="300px"></asp:TextBox>
                <asp:FileUpload ID="FileUpload2" runat="server" Visible="false" /><asp:Label ID="lblURL2" runat="server"
                    Text="Label" Visible="false"></asp:Label></td>
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
           
            <td width="20%">title</td>
            <td width="20%">alt</td>
            <td width="20%">链接</td>
             <td width="10%">顺序</td>
            <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand" >
            <ItemTemplate>
                <tr>
                    <td><img src="<%#Eval("img1path") %>" style="width:100%;" /></td>
                   
                    <td><a href="<%#Eval("linkurl") %>" target="_blank"><%#Eval("title") %></a></td>
                    <td><%#Eval("alt") %></td>
                    <td><%#Eval("linkurl") %></td>
                    <td><%#Eval("orderNum")%></td>
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
