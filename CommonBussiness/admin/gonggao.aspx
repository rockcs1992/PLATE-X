<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gonggao.aspx.cs" Inherits="CommonBussiness.admin.gonggao" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>基础设置</title>
<script src="/js/jquery.js" type="text/javascript"></script>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="rtitle" >公告信息</div>
<div class="rcont" style=" min-height:500px;">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr>       
            <td class="r_tab2">标题</td>
            <td class="r_cont"><asp:TextBox ID="txtTitle" runat="server" Width="200px"></asp:TextBox></td>
             <td class="r_tab2">连接路径</td>
            <td class="r_cont"><asp:TextBox ID="txtURL" runat="server" Width="200px"></asp:TextBox></td>
            <td class="r_tab2">内容</td>
            <td class="r_cont" colspan="5"><asp:TextBox ID="txtContent" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox></td>
            <td class="r_cont">
                <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" /></td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">          
            <td width="20%">标题</td>
            <td width="20%">连接路径</td>
            <td width="30%">内容</td>
            <td width="10%">添加人</td>
              <td width="10%">添加时间</td>
            <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" 
            onitemdatabound="repInfo_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblId" runat="server" Text='<%#  Eval("id") %>' Visible="false"></asp:Label><%#Eval("title") %></td>
                        <td><a href="<%#Eval("linkurl") %>" target="_blank"><%#Eval("linkurl") %></a></td>
                    <td><%#Eval("gongGaoContent") %></td>                    
                    <td><%#GetUserName(Eval("addUser")) %></td>
                    <td><%#Eval("addTime","{0:yyyy-MM-dd}") %></td>
                    <td align="center">
                            <asp:LinkButton ID="lbtnDel" runat="server" CssClass="edit_bt" OnClientClick="return confirm('您确定要删除吗？');" >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        
    </table>
    </ContentTemplate>
</asp:UpdatePanel>
</div>
</form>
</body>
</html>
