<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showRole.aspx.cs" Inherits="CommonBussiness.admin.showRole" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色权限管理</title>
    
    <link href="css/admin.css" type="text/css" rel="stylesheet">    
</head>
<body style=" font-size:12px;">
    <form id="form1" runat="server" onkeypress="buttonClick()">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>  
        <div class="rtitle" >角色权限管理</div>
<div class="rcont">   
    
        <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">      
            <td>角色名称</td>
            <td>角色描述</td>
            <td>操作</td>            
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" onitemcommand="Repeater1_ItemCommand"  >
            <ItemTemplate>
                <tr>
        	       <td><asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label><%# Eval("RoleName")%></td>
                    <td><%# Eval("RoleDesc")%></td>
                    <td><asp:LinkButton ID="lbtnPermissi" runat="server" CommandName="permissi" CommandArgument='<%# Eval("Id") %>'>权限分配</asp:LinkButton></td>   
                </tr>
            </ItemTemplate>
        </asp:Repeater> 
        </table>      
        </div> 
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
