<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderQuickInfo.aspx.cs" Inherits="CommonBusiness.admin.orderQuickInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>在线留言信息</title>
<script src="js/jquery.js" type="text/javascript"></script>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="rtitle" >在线留言信息</div>
<div class="rcont" style=" min-height:500px;">   
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    <tr><td class="tleft" style="background:#eee;" colspan="10"></td></tr>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
            <td width="10%">联系人</td>
            <td width="10%">手机</td>      
             <td width="25%">住址</td>      
            <td width="10%">上门时间</td>           
            <td width="10%">邮箱</td>     
            <td width="10%">留言时间</td>    
             <td width="15%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand" >
            <ItemTemplate>
                <tr>
                    <td><%#Eval("name")%></td>
                    <td><%#Eval("mobile") %></td>
                    <td><%#Eval("address") %></td>
                    
                    <td><%#Eval("tel")%></td>
                    
                     <td><%#Eval("email")%></td>                       
                    <td><%#Eval("addTime","{0:yyyy-MM-dd HH:mm}") %></td>

                   <td>
                   <asp:LinkButton ID="lbtnView" runat="server" CssClass="edit_bt_linkbutton" CommandName="view" CommandArgument='<%#Eval("id") %>' >查看</asp:LinkButton>
                   <asp:LinkButton ID="lbtnDel" runat="server" CssClass="edit_bt_linkbutton" OnClientClick="return confirm('您确定要删除吗？');" CommandName="del" CommandArgument='<%#Eval("id") %>' >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        
    </table>

    <!-----浮动窗口开始---->
    <div id="wfullbg"></div>
    <div id="layer" class="layer" style="margin-left:20%;">
      <table class="cf" style="width:600px;" cellpadding="0" cellspacing="0" border="0">
             <tr>
                <td align="right">姓名：</td>
                <td align="left"><%=ViewState["realName"] %></td>
            	<td align="right">手机：</td>
                <td align="left"><%=ViewState["mobile"] %></td>                
            </tr>
            <tr>
            	<td align="right">电话：</td>
                <td align="left"><%=ViewState["tel"] %></td>
                <td align="right">email：</td>
                <td align="left"><%=ViewState["email"] %></td>
            </tr>
            <tr>
            	<td align="right">qq：</td>
                <td align="left"><%=ViewState["qq"] %></td>
                <td align="right">留言时间：</td>
                <td align="left"><%=ViewState["addTime"] %></td>
            </tr>
            <tr>
            	<td align="right">地址：</td>               
                <td align="left" colspan="3"><%=ViewState["address"] %></td>
            </tr>
            <tr>     
                <td align="left" colspan="4"><%=ViewState["mesInfo"] %></td>
                
            </tr>
            <tr>
            <td bgcolor="#eeeeee"  align="right">&nbsp;</td>
            <td bgcolor="#eeeeee"  align="right">&nbsp;</td>
            	<td bgcolor="#eeeeee"  align="right">&nbsp;</td>
                <td bgcolor="#eeeeee"  align="left">
                <input type="button" value="关闭" onClick="hideOver()">
                </td>
            </tr>
        </table>
      <div class="close" onClick="hideOver()"></div>
    </div>
    <!----浮动窗口结束--------->
</div>
</form>
</body>
</html>
