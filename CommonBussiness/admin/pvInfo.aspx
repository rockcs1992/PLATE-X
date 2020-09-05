<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pvInfo.aspx.cs" Inherits="QIANCHEN.admin.pvInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>页面统计信息</title>
<script src="js/jquery.js" type="text/javascript"></script>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
      <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div class="rtitle" >页面统计信息</div>
<div class="rcont" style=" min-height:500px;">    
    <table cellpadding="0" cellspacing="0" border="0">
		<tr>
            <td class="r_tab2">IP地址</td>
            <td class="r_cont">
                <asp:TextBox ID="txtIP" runat="server"></asp:TextBox></td>     
			<td class="r_tab2">页面备注</td>
            <td class="r_cont">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>     
            <td class="r_tab2">页面名称</td>
            <td class="r_cont">
                <asp:TextBox ID="txtPageValue" runat="server"></asp:TextBox></td>        
            <td class="r_tab2">浏览时间</td>
            <td class="r_cont"><asp:TextBox ID="txtTimeFrom" runat="server" onfocus="WdatePicker({isShowOthers:true,dateFmt:'yyyy-MM-dd'})"  ></asp:TextBox>-<asp:TextBox ID="txtTimeEnd" runat="server" onfocus="WdatePicker({isShowOthers:true,dateFmt:'yyyy-MM-dd'})" ></asp:TextBox></td>
            <td class="r_cont"><asp:Button ID="Button1" runat="server" Text="检索" onclick="Button1_Click" /></td>
            <td class="r_cont"><asp:Button ID="Button2" runat="server" Text="统计" onclick="Button2_Click" /></td>
        </tr>       
    </table>
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
            <td width="20%">页面备注</td>
            <td width="20%">页面名称</td>
            <td width="20%">浏览时间</td>
            <td width="20%">IP</td> 
            <td width="5%">操作</td>              
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand" >
            <ItemTemplate>
                <tr>
                    <td><%#Eval("pageName") %></td>
                    <td><%#Eval("pageValue")%></td>
                    <td><%#Eval("addTime","{0:yyyy-MM-dd HH:mm}") %></td>
                    <td><%#Eval("ip") %></td>                    
                    <td>
                    <asp:LinkButton ID="lbtnDel" runat="server" CssClass="edit_bt" OnClientClick="return confirm('您确定要删除吗？');" CommandName="del" CommandArgument='<%#Eval("id") %>' >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        
    </table>
</div>
    <div class="page">
     <webdiyer:AspNetPager ID="pager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条"
                        CustomInfoTextAlign="Left" FirstPageText="首页" LastPageText="末页" NextPageText="下一页"
                        NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Never" ShowPageIndexBox="Auto" PageSize="10"
                       CustomInfoSectionWidth="10%">
                    </webdiyer:AspNetPager>
    </div>
</form>
</body>
</html>
