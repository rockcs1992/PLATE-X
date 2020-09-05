<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manager.aspx.cs" Inherits="CommonBussiness.admin.manager" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>基础设置</title>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
    <script src="js/GetAllCheckBox.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" name="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
</ContentTemplate>
</asp:UpdatePanel>
<div class="rtitle" >用户管理</div>
<div class="rcont" style="min-height:600px;">

    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr>
        	<td colspan="6" bgcolor="#eeeeee" align="left"><input type="button" value="添加管理员" onclick="showAdminDiv()"></td>
        </tr>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
        	<td width="5%"><input id="Checkbox1" type="checkbox" onclick="GetAllCheckBox(this)" /></td>
            <td width="18%">姓名</td>
            <td width="18%">账户</td>
            <td width="18%">角色</td>
            <td width="12%">状态</td>
            <td width="24%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server">
            <ItemTemplate>
                <tr>
        	        <td width="5%"><asp:CheckBox ID="cbxAll" runat="server"   /></td>
                    <td width="18%"><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label><%#Eval("realName") %></td>
                    <td width="18%"><%#Eval("username") %></td>
                    <td width="18%"><%#GetRoleName(Eval("roleId")) %></td>
                    <td width="12%"><%#Eval("status").ToString() == "1"?"启用":"<span style='color:red;'>停用</span>" %></td>
                    <td width="24%"><a class="edit_bt" onclick=overAdminDiv(<%#Eval("id") %>,'<%#Eval("username") %>','<%#Eval("password") %>','<%#Eval("realName") %>',<%#Eval("roleId") %>)>编辑</a>&nbsp;&nbsp;
                    <a class="edit_bt" onclick="return confirm('您确定要删除吗？')" href="/jsData/common.aspx?action=DelAdmin&id=<%#Eval("id") %>">删除</a>&nbsp;&nbsp;                    
                    <%#Eval("status").ToString() == "2" ? "<a  onclick='return confirm(\"您确定要启用吗？\")' class=\"edit_bt\" href=\"/jsData/common.aspx?action=UseAdmin&id=" + Eval("id") + "&status=" + Eval("status") + "\">启用</a>" : "<a onclick='return confirm(\"您确定要停用吗？\")' class=\"edit_bt\" href=\"/jsData/common.aspx?action=UseAdmin&id=" + Eval("id") + "&status=" + Eval("status") + "\">停用"%></a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>        
        <tr><td colspan="6" class="tleft" style="background:#eee;"><asp:Button ID="Button2" runat="server" Text="删除所选" OnClientClick="return confirm('您确认要删除吗？');" OnClick="Button2_Click" /></td></tr>
    </table>
    
    <div class="page" style="display:none;">
    <a href="">|<</a><a href=""><</a><a href="">1</a><a href="">2</a><a href="">3</a><a href="">4</a><a href="">...</a><a href="">20</a><a href="">></a><a href="">>|</a>
    </div>
    <!-----浮动窗口开始---->
    <div id="wfullbg"></div>
    <div id="layer" class="layer" style="top:150px;" >
        <asp:HiddenField ID="hidAdminId" runat="server" />
      <table class="cf" style="width:400px;" cellpadding="0" cellspacing="0" border="0">
            <tr>
            	<td align="right">用户名：</td>
                <td align="left">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
            	<td align="right">真实姓名：</td>
                <td align="left"><asp:TextBox ID="txtRealName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
            	<td align="right">密码：</td>
                <td align="left"><asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
            	<td align="right">确认密码：</td>
                <td align="left"><asp:TextBox ID="txtPassAgain" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
            	<td align="right">角色：</td>
                <td align="left">
                    <asp:DropDownList ID="ddlRole" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            	<td bgcolor="#eeeeee"  align="right">&nbsp;</td>
                <td bgcolor="#eeeeee"  align="left">
                    <asp:Button ID="Button1" runat="server" Text="保存" OnClientClick="return checkAdminInput()" OnClick="Button1_Click" /><input type="button" value="取消" onClick="hideOver()">
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
