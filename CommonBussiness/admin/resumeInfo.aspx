<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resumeInfo.aspx.cs" Inherits="CommonBusiness.admin.resumeInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>简历信息</title>
<script src="js/jquery.js" type="text/javascript"></script>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div class="rtitle" >简历信息</div>
<div class="rcont" style=" min-height:500px;">    
 
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
            <td width="10%">应聘职位</td>
            <td width="10%">姓名</td>
            <td width="10%">手机</td>
            <td width="10%">QQ</td>
            <td width="10%">工作年限</td>
            <td width="30%">自我介绍</td>
            <td width="10%">应聘日期</td>
             <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand" >
            <ItemTemplate>
                <tr>
                    <td><%#Eval("inviteName") %></td>
                    <td><%#Eval("realName")%></td>
                    <td><%#Eval("mobile") %></td>
                    <td><%#Eval("QQ") %></td>
                    <td><%#Eval("workYears") %></td>
                    <td><%# Text.Left(Eval("selfInfo").ToString(),50) %>....</td>
                    <td><%#Eval("addTime","{0:yyyy-MM-dd HH:mm}") %></td>
                    <td>
                    <asp:LinkButton ID="lbtnView" runat="server" CssClass="edit_bt" CommandName="view" CommandArgument='<%#Eval("id") %>' >查看</asp:LinkButton>
                    <asp:LinkButton ID="lbtnDel" runat="server" CssClass="edit_bt" OnClientClick="return confirm('您确定要删除吗？');" CommandName="del" CommandArgument='<%#Eval("id") %>' >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        
    </table>
<!-----浮动窗口开始---->
    <div id="wfullbg"></div>
    <div id="layer" class="layer" style="margin-left:20%;">
      <table class="cf" style="width:600px;" cellpadding="0" cellspacing="0" border="0">
             <tr>
            	<td align="right">职位名称：</td>
                <td align="left"><%=ViewState["inviteName"] %></td>
                <td align="right">姓名：</td>
                <td align="left"><%=ViewState["realName"] %></td>
            </tr>
            <tr>
            	<td align="right">手机：</td>
                <td align="left"><%=ViewState["mobile"] %></td>
                <td align="right">QQ：</td>
                <td align="left"><%=ViewState["qq"] %></td>
            </tr>
            <tr>
            	<td align="right">工作年限：</td>
                <td align="left"><%=ViewState["workYears"] %></td>
                <td align="right">应聘时间：</td>
                <td align="left"><%=ViewState["addTime"] %></td>
            </tr>
            <tr>
            	<td align="right">自我介绍：</td>
                <td align="left" colspan="3"><%=ViewState["selfInfo"] %></td>
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
