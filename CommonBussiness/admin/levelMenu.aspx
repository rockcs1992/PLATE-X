<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="levelMenu.aspx.cs" Inherits="CommonBussiness.admin.levelMenu" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>权限菜单</title>
<link href="css/admin.css" type="text/css" rel="stylesheet">
    <script src="js/admin.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="rtitle" >权限菜单</div>
<div class="rcont">
    <table cellpadding="0" cellspacing="0" border="0">
		<tr>
			<td class="r_tab bold">添加大类：</td>
			<td class="r_cont">
            <div>
            <asp:HiddenField ID="hidOne" runat="server" />
                <asp:TextBox ID="txtOne" runat="server" Width="209px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnAddOne" runat="server" Text="添加一级分类" 
                    onclick="btnAddOne_Click"  />
                <asp:Button ID="btnModOne" runat="server" Text="修改所选" onclick="btnModOne_Click" 
                     /><asp:Button ID="btnDelOne" runat="server" Text="删除所选" 
                    onclick="btnDelOne_Click"  Visible="false" />
            </div>
            </td>
		</tr>
        <tr>
			<td class="r_tab">已添加分类：</td>
			<td class="r_cont"><%=GetOneInfo()%></td>
		</tr>
        <tr><td colspan="2"></td></tr>
        <tr>
			<td class="r_tab bold">添加子分类：</td>
			<td class="r_cont">
            <div>    
            <asp:HiddenField ID="hidTwo" runat="server" />
                <asp:DropDownList ID="ddlOne" runat="server" 
                    onselectedindexchanged="ddlOne_SelectedIndexChanged" AutoPostBack="true" Height="33px">
                </asp:DropDownList>
                <asp:TextBox ID="txtTwo" runat="server" Width="199px"></asp:TextBox>&nbsp;&nbsp;链接<asp:TextBox ID="txtURL" runat="server" Width="199px"></asp:TextBox>
                <asp:Button ID="btnAddTwo" runat="server" Text="添加二级分类" 
                    onclick="btnAddTwo_Click" />
                 <asp:Button ID="btnModTwo" runat="server" Text="修改所选" 
                    onclick="btnModTwo_Click" />
            </div>
            </td>
		</tr>
        <tr>
			<td class="r_tab">已添加二级分类：</td>
			<td class="r_cont"><%=ViewState["twoInfo"]%></td>
		</tr>
		<tr>
			<td class="r_tab">&nbsp;</td>
			<td class="r_cont"></td>
		</tr>
	</table>
</div>

</ContentTemplate>
</asp:UpdatePanel>
</form>

</body>
</html>
