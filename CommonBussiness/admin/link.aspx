<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="link.aspx.cs" Inherits="CommonBussiness.admin.link" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>基础设置</title>
<script src="js/jquery.js" type="text/javascript"></script>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div class="rtitle" >政府部门风云榜</div>
<div class="rcont" style=" min-height:500px;">
    <asp:Panel ID="pnlAdd" runat="server" Visible="false">
    
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr>
        <td class="r_tab2">模块</td>
            <td class="r_cont">
                <asp:DropDownList ID="ddlPlace" runat="server" Width="210px">
                </asp:DropDownList>
               </td>
        </tr>
        <tr>
        	<td class="r_tab2">名称</td>
            <td class="r_cont">
                <asp:TextBox ID="txtLinkName" runat="server" Width="200px"></asp:TextBox></td>
          </tr>
        <tr>
            <td class="r_tab2">顺序号</td>
            <td class="r_cont"><asp:TextBox ID="txtLinkTitle" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="r_tab2">链接</td>
            <td class="r_cont"><asp:TextBox ID="txtLinkUrl" runat="server" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
        <td class="r_tab2">&nbsp;</td>
            <td class="r_cont">
                <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" /><asp:Label
                    ID="lblId" runat="server" Text="" Visible="false"></asp:Label><asp:Label
                    ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlList" runat="server">
    
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
            <td width="10%">ID</td>    
            <td width="20%">名称</td>            
            <td width="20%">链接</td>
            <td width="10%">模块</td>
            <td width="10%">顺序号</td>  
            <td width="20%">添加时间</td>
            <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server"  onitemcommand="repInfo_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><asp:Label ID="lblId" runat="server" Text='<%#  Eval("id") %>'></asp:Label></td>
                    <td><%#Eval("linkname") %></td>
                    <td><a href="<%#Eval("linkurl") %>" target="_blank"><%#Eval("linkurl") %></a></td>
               <td><%#GetModule(Eval("istj")) %></td>  
                <td><%#Eval("linktitle") %></td>
                    <td><%#Eval("addTime","{0:yyyy-MM-dd}") %></td></td>
                    <td><asp:LinkButton
                            ID="lbtnMod" runat="server" CssClass="edit_bt" CommandName="mod" CommandArgument='<%#Eval("id") %>' >编辑</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                            ID="lbtnDel" runat="server" CssClass="edit_bt" OnClientClick="return confirm('您确定要删除吗？');" CommandName="del" CommandArgument='<%#Eval("id") %>' >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="7" align="right">
                <asp:Button ID="Button2" runat="server" Text="添加" onclick="Button2_Click" />
            </td>
        </tr>
    </table>
     <div style=" text-align:center; margin-top:10px;"><span>本页记录数：<b style=" color:#e00; padding:0px 3px; font-size:14px;"><%=this.pager1.PageCount > 1 ? this.repInfo.Items.Count.ToString() : this.pager1.RecordCount.ToString()%></b>条</span><span style=" margin-left:30px;">所有记录数：<b style=" color:#e00; padding:0px 3px; font-size:14px;"><%=this.pager1.RecordCount%></b>条</span></div>

    <div class="page">
     <webdiyer:AspNetPager ID="pager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条"
                        CustomInfoTextAlign="Left" FirstPageText="首页" LastPageText="末页" NextPageText="下一页"
                        NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Never" ShowPageIndexBox="Auto" PageSize="10"
                       CustomInfoSectionWidth="10%">
                    </webdiyer:AspNetPager>
    </div>
    </asp:Panel>
</div>
</form>
</body>
</html>
