<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="common_link.aspx.cs" Inherits="CommonBussiness.admin.common_link" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>基础设置</title>
<script src="js/jquery.js" type="text/javascript"></script>
<link href="css/admin.css" type="text/css" rel="stylesheet"/>
<script src="js/admin.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div class="rtitle" >友情链接</div>
<div class="rcont" style=" min-height:500px;">
    <asp:Panel ID="pnlAdd" runat="server" Visible="false">
    
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	 <tr>
        <td class="r_tab2">位置</td>
            <td class="r_cont">
                <asp:DropDownList ID="ddlPlace" runat="server">
                    <asp:ListItem Value="1">首页</asp:ListItem>
                    <asp:ListItem Value="2">子页</asp:ListItem>
                </asp:DropDownList>
               </td>
        </tr>
        <tr>
        <td class="r_tab2">链接类型</td>
            <td class="r_cont">
                <asp:DropDownList ID="ddlLinkType" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlLinkType_SelectedIndexChanged">
                    <asp:ListItem Value="1">文字</asp:ListItem>
                    <asp:ListItem Value="2">图片</asp:ListItem>
                </asp:DropDownList>
               </td>
        </tr>    
        <tr id="imgRow" runat="server" visible="false">
        <td class="r_tab2">图片上传</td>
            <td class="r_cont">
               <asp:FileUpload ID="filepic_weibo" runat="server"  onchange="javascript:__doPostBack('lbtnWeiBo','')"/><asp:LinkButton ID="lbtnWeiBo" runat="server" OnClick="lbtnWeiBo_Click"></asp:LinkButton>
                        <asp:Label ID="lblImgWeiBo" runat="server" Text=""></asp:Label>
               </td>
        </tr>    
        <tr>
        	<td class="r_tab2">链接名称</td>
            <td class="r_cont">
                <asp:TextBox ID="txtLinkName" runat="server" Width="200px"></asp:TextBox></td>
          </tr>
       
        <tr>
            <td class="r_tab2">链接路径</td>
            <td class="r_cont"><asp:TextBox ID="txtLinkUrl" runat="server" Width="300px"></asp:TextBox></td>
        </tr>
       <%-- <tr>
            <td class="r_tab2">顺序号</td>
            <td class="r_cont"><asp:TextBox ID="txtOrder" runat="server" Width="300px"></asp:TextBox>
               </td>
        </tr>--%>
        <tr>
            <td class="r_tab2">推荐</td>
            <td class="r_cont">
                <asp:CheckBox ID="cboTj" runat="server" /></td>
        </tr>
        <tr>
            <td class="r_tab2">热点</td>
            <td class="r_cont">
                <asp:CheckBox ID="cboHot" runat="server" /></td>
        </tr>
        <tr>
            <td class="r_tab2">新打开页面</td>
            <td class="r_cont">
                <asp:CheckBox ID="cboNewBlank" runat="server" /></td>
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
             <td width="10%">名称</td> 
            <td width="10%">链接类型</td>  
              <td width="15%">路径</td> 
            <td width="10%">位置</td>       
            <td width="20%">图片路径</td>
            <td width="5%">推荐首页</td>
             <td width="5%">热点</td>
             <td width="5%">新窗口打开</td>
             <td width="10%">操作人</td>
            <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server"  onitemcommand="repInfo_ItemCommand">
            <ItemTemplate>
                <tr>
                <td><asp:Label ID="lblId" runat="server" Text='<%#  Eval("id") %>' Visible="false"></asp:Label><%#Eval("linkname") %></td>                  
                 <td><%#Eval("linkType").ToString() == "1" ? "文字" : "图片" %></td>
                 <td><a href="<%#Eval("linkurl") %>" target="_blank"><%#Eval("linkurl") %></a></td>
                 <td><%#Eval("linkPlace").ToString() == "1" ? "首页" : "子页" %></td>
                  <td><%#Eval("imgurl") %></td>
                   <td><%#Eval("isTj").ToString() == "1" ? "是" : "否" %></td>
                    <td><%#Eval("isHot").ToString() == "1" ? "是" : "否"%></td>
                    <td><%#Eval("is_target").ToString() == "1" ? "是" : "否"%></td>
                      <td><%#GetUser(Eval("addUser")) %></td>                                      
                    <td><asp:LinkButton
                            ID="lbtnMod" runat="server" CssClass="edit_bt" CommandName="mod" CommandArgument='<%#Eval("id") %>' >编辑</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                            ID="lbtnDel" runat="server" CssClass="edit_bt" OnClientClick="return confirm('您确定要删除吗？');" CommandName="del" CommandArgument='<%#Eval("id") %>' >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="10" align="right">
                <asp:Button ID="Button2" runat="server" Text="添加" onclick="Button2_Click" />
            </td>
        </tr>
    </table>
    </asp:Panel>
</div>
</form>
</body>
</html>
