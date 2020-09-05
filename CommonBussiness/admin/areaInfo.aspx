<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="areaInfo.aspx.cs" Inherits="CommonBussiness.admin.areaInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>基础设置</title>
<link href="css/admin.css" type="text/css" rel="stylesheet">
    <script src="js/admin.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="rtitle" >地区管理</div>
<div class="rcont">
    <table cellpadding="0" cellspacing="0" border="0">
		<tr>
			<td class="r_tab bold">添加省：</td>
			<td class="r_cont">
            <div>
            <asp:HiddenField ID="hidOne" runat="server" />
                <asp:TextBox ID="txtOne" runat="server" Width="209px"></asp:TextBox>&nbsp;简称字符<asp:TextBox ID="txtChar" runat="server" Width="50px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnAddOne" runat="server" Text="添加省" 
                    onclick="btnAddOne_Click"  />
                <asp:Button ID="btnModOne" runat="server" Text="修改所选" onclick="btnModOne_Click" 
                     /><asp:Button ID="btnDelOne" runat="server" Text="删除所选" 
                    onclick="btnDelOne_Click" OnClientClick="return confirm('您真的要删除吗？');"  /><asp:Button ID="btnHot" runat="server" Text="设为热门" 
                    onclick="btnHot_Click" /><asp:Button ID="btnCancelHot" runat="server" Text="取消热门" 
                    onclick="btnCancelHot_Click" />
            </div>
            </td>
		</tr>

        <tr>
			<td class="r_tab">已添加省：</td>
			<td class="r_cont"><%=GetOneInfo()%></td>
		</tr>


        <tr><td colspan="2"></td></tr>
        <tr>
			<td class="r_tab bold">添加市：</td>
			<td class="r_cont">
            <div>    
            <asp:HiddenField ID="hidTwo" runat="server" />
                <asp:DropDownList ID="ddlOne" runat="server" 
                    onselectedindexchanged="ddlOne_SelectedIndexChanged" AutoPostBack="true" Width="150px">
                </asp:DropDownList>
                <asp:TextBox ID="txtTwo" runat="server" Width="199px"></asp:TextBox> &nbsp;简称字符<asp:TextBox ID="txtCharCity" runat="server" Width="50px"></asp:TextBox>
                <asp:Button ID="btnAddTwo" runat="server" Text="添加市" 
                    onclick="btnAddTwo_Click" />
                 <asp:Button ID="btnModTwo" runat="server" Text="修改所选" 
                    onclick="btnModTwo_Click" /><asp:Button ID="btnDelTwo" runat="server" Text="删除所选" 
                    onclick="btnDelTwo_Click" OnClientClick="return confirm('您真的要删除吗？');"  /><asp:Button ID="bntHotCity" runat="server" Text="设为热门" 
                    onclick="bntHotCity_Click" /><asp:Button ID="btnCancelCity" runat="server" Text="取消热门" 
                    onclick="btnCancelCity_Click" />
            </div>
            </td>
		</tr>
        <tr>
			<td class="r_tab">已添市：</td>
			<td class="r_cont"><%=ViewState["twoInfo"]%></td>
		</tr>
		<tr>
			<td class="r_tab">&nbsp;</td>
			<td class="r_cont"></td>
		</tr>


         <tr><td colspan="2"></td></tr>
        <tr>
			<td class="r_tab bold">添加商圈：</td>
			<td class="r_cont">
            <div>    
            <asp:HiddenField ID="hidRegion" runat="server" />
                省<asp:DropDownList ID="ddlProvince" runat="server" 
                    onselectedindexchanged="ddlProvince_SelectedIndexChanged" AutoPostBack="true" Width="150px">
                </asp:DropDownList>

                &nbsp;&nbsp;市<asp:DropDownList ID="ddlCity" runat="server" 
                    onselectedindexchanged="ddlCity_SelectedIndexChanged" AutoPostBack="true" Width="150px">
                </asp:DropDownList>
                <asp:TextBox ID="txtRegion" runat="server" Width="199px"></asp:TextBox> &nbsp;简称字符<asp:TextBox ID="txtC" runat="server" Width="50px"></asp:TextBox>
                <asp:Button ID="btnRegion" runat="server" Text="添加商圈" 
                    onclick="btnRegion_Click" />
                 <asp:Button ID="btnModRegion" runat="server" Text="修改所选" 
                    onclick="btnModRegion_Click" /><asp:Button ID="btnDelRegion" runat="server" Text="删除所选" 
                    onclick="btnDelRegion_Click" OnClientClick="return confirm('您真的要删除吗？');"  />
            </div>
            </td>
		</tr>
        <tr>
			<td class="r_tab">已添商圈：</td>
			<td class="r_cont"><%=ViewState["regionInfo"]%></td>
		</tr>
		<tr>
			<td class="r_tab">&nbsp;</td>
			<td class="r_cont"></td>
		</tr>
	</table>
    <table cellpadding="0" cellspacing="0" border="0">
		<tr>
			<td class="r_tab bold">热门城市信息</td>
			<td class="r_cont"><%=ViewState["hotInfo"]%></td>
		</tr>  
   </table>
</div>

</ContentTemplate>
</asp:UpdatePanel>
</form>

</body>
</html>
