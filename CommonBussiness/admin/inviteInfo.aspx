<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inviteInfo.aspx.cs" Inherits="CommonBusiness.admin.inviteInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>职位信息</title>
<script src="js/jquery.js" type="text/javascript"></script>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div class="rtitle" >职位信息</div>
<div class="rcont" style=" min-height:500px;"> 
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
     <tr><td class="tleft" style="background:#eee;" colspan="10"></td></tr>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
            <td width="10%">职位名称</td>
            <td width="10%">招聘人数</td>      
             <td width="10%">收取简历</td>                
            <td width="20%">添加时间</td>
             <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand" >
            <ItemTemplate>
                <tr>
                    <td><%#Eval("inviteName") %></td>
                    <td><%#Eval("inviteType") %>人</td>              
                       <td><a href="resumeInfo.aspx?inviteId=<%#Eval("id") %>"><%#GetResumeCount(Eval("id")) %>份</a></td>      
                    <td><%#Eval("addTime","{0:yyyy-MM-dd HH:mm}") %></td>
                 <td>
                 <asp:LinkButton ID="lbtnMod" runat="server" CssClass="edit_bt_linkbutton" CommandName="mod" CommandArgument='<%#Eval("id") %>' >编辑</asp:LinkButton>
                 <asp:LinkButton ID="lbtnDel" runat="server" CssClass="edit_bt_linkbutton" OnClientClick="return confirm('您确定要删除吗？');" CommandName="del" CommandArgument='<%#Eval("id") %>' >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="5" align="right">
                <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
</div>
</form>
</body>
</html>
