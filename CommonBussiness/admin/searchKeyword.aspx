<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchKeyword.aspx.cs" Inherits="CommonBusiness.admin.searchKeyword" %>
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh" >
<head>
<meta charset="utf-8">
<title></title>
<link href="css/admin.css" type="text/css" rel="stylesheet">        
     <script src="js/GetAllCheckBox.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate></ContentTemplate>
</asp:UpdatePanel>
<div class="rtitle" >搜索关键字设置</div>
<div class="rcont">
    <table cellpadding="0" cellspacing="0" border="0">
		<tr>
			<td class="r_tab2">&nbsp;</td>
            <td class="r_cont">
                </td>   
            <td class="r_cont">
                
            </td>
        </tr>       
    </table>
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
        	<td width="5%"><input id="Checkbox1" type="checkbox" onclick="GetAllCheckBox(this)" /></td>
            <td width="10%">编号</td>
            <td width="50%">关键字</td>   
            <td width="10%">顺序号</td>   
            <td width="15%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand">
            <ItemTemplate>
                <tr>
        	        <td><asp:CheckBox ID="cbxAll" runat="server"   /></td>
                    <td ><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label><%#Eval("id") %></td>
                      <td>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("seaTitle") %>'></asp:Label></td>      
                         <td>
                        <asp:Label ID="lblOrderNum" runat="server" Text='<%#Eval("remark") %>'></asp:Label></td>                
                    <td><asp:LinkButton
                            ID="lbtnMod" runat="server" CssClass="edit_bt_linkbutton" CommandName="mod" CommandArgument='<%#Eval("id") %>' >编辑</asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton ID="lbtnSave" runat="server" CssClass="edit_bt_linkbutton" CommandName="save" CommandArgument='<%#Eval("id") %>' Visible="false" >保存</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                            ID="lbtnDel" runat="server" CssClass="edit_bt_linkbutton" OnClientClick="return confirm('您确定要删除吗？');" CommandName="del" CommandArgument='<%#Eval("id") %>' >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr><td colspan="10" style="background:#eee;">&nbsp;</td></tr>
        <tr><td class="tleft" style="background:#eee;"><asp:Button ID="btnDel" runat="server" Text="删除所选" OnClientClick="return confirm('您确认要删除吗？');" OnClick="btnDel_Click" /></td>
        <td colspan="9" class="tright" style="background:#eee;">
            名称：<asp:TextBox ID="txtTitle" runat="server" Height="30px" Width="200px"></asp:TextBox>&nbsp;顺序号：<asp:TextBox ID="txtOrderNum" runat="server" Height="30px" Width="200px"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text=" 保存 " onclick="Button1_Click" /><asp:Label
                    ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label><asp:HiddenField ID="hidId" runat="server" /></td>
        </tr>
    </table>
    <div style=" text-align:center; margin-top:10px;"><span>本页记录数：<b style=" color:#e00; padding:0px 3px; font-size:14px;"><%=this.pager1.PageCount > 1 ? this.repInfo.Items.Count.ToString() : this.pager1.RecordCount.ToString()%></b>条</span><span style=" margin-left:30px;">所有记录数：<b style=" color:#e00; padding:0px 3px; font-size:14px;"><%=this.pager1.RecordCount%></b>条</span></div>

    <div class="page">
     <webdiyer:AspNetPager ID="pager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条"
                        CustomInfoTextAlign="Left" FirstPageText="首页" LastPageText="末页" NextPageText="下一页"
                        NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Never" ShowPageIndexBox="Auto" PageSize="5"
                       CustomInfoSectionWidth="10%">
                    </webdiyer:AspNetPager>
    </div>
</div>

</form>
</body>
</html>
