<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="propertyInfo.aspx.cs" Inherits="CommonBussiness.admin.propertyInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>产品属性设置</title>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
   <script src="js/GetAllCheckBox.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="rtitle" >产品属性信息</div>
<div class="rcont" style=" min-height:500px;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<td bgcolor="#eeeeee" align="left" colspan="5">
            <input type="button" value="属性添加" onclick="overKeyWordDiv()">
        </td>
        <td bgcolor="#eeeeee" align="left" colspan="2">
            <asp:DropDownList ID="ddlSelProductType" runat="server" 
            AutoPostBack="true" 
            onselectedindexchanged="ddlSelProductType_SelectedIndexChanged" Width="200px"></asp:DropDownList>
            <asp:DropDownList ID="ddlSelOne" runat="server" Width="200px"></asp:DropDownList>
            <asp:Button ID="Button2" runat="server" Text="查询" onclick="Button2_Click" />
        </td> 
    </table>   
   
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;"> 
            <td width="10%"><input id="Checkbox1" type="checkbox" onclick="GetAllCheckBox(this)" /></td>         
            <td width="10%">ID</td>
            <td width="10%">产品类型</td>  
            <td width="10%">一级属性</td>
            <td width="10%">二级属性</td> 
            <td width="10%">推荐</td>                 
            <td width="10%">添加人</td>
              <td width="10%">添加时间</td>
            <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand">
            <ItemTemplate>
                <tr>
                <td><asp:CheckBox ID="cbxAll" runat="server"   /></td>
                    <td>
                        <asp:Label ID="lblId" runat="server" Text='<%#  Eval("id") %>'></asp:Label></td>                       
                    <td><%#GetProductName(Eval("infoType")) %></td>  
                    <td><%#GetParentName(Eval("parentId"), Eval("properName"))%></td>   
                    <td><%#Eval("properName") %></td>   
                    <td><%#Eval("status").ToString() == "1" ? "是" : "否" %></td>          
                    <td><%#GetUserName(Eval("addUser")) %></td>
                    <td><%#Eval("addTime","{0:yyyy-MM-dd}") %></td>
                    <td align="center"> 
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="edit_bt"  CommandName="mod" CommandArgument='<%#Eval("id") %>'  >编辑</asp:LinkButton>
                            <asp:LinkButton ID="lbtnDel" runat="server" CssClass="edit_bt" OnClientClick="return confirm('您确定要删除吗？');"  CommandName="del" CommandArgument='<%#Eval("id") %>'  >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr><td colspan="6" class="tleft" style="background:#eee;"><asp:Button ID="Button4" runat="server" Text="推荐所选" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="取消推荐" OnClick="Button5_Click" /></td></tr>
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
    </ContentTemplate>
    </asp:UpdatePanel>
    <!-----浮动窗口开始---->
        <div id="wfullbg">
        </div>
        <div id="layer" class="layer" style=" margin-left:13%; top:100px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
            <table class="cf" style="width: 600px;" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td align="right" width="20%">
                        产品类型：
                    </td>
                    <td align="left" width="80%">
                        <asp:DropDownList ID="ddlProductType" runat="server" 
                    AutoPostBack="true" 
                    onselectedindexchanged="ddlProductType_SelectedIndexChanged" Width="200px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        一级属性：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlOne" runat="server" Width="200px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        属性：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPropertyName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>  
                <tr>
                    <td align="right">
                        推荐：
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="cboTj" runat="server" /> 
                    </td>
                </tr>                
                <tr>
                    <td bgcolor="#eeeeee" align="right">
                        &nbsp;
                    </td>
                    <td bgcolor="#eeeeee" align="left">
                        <asp:Button ID="Button1" runat="server" Text="保存" onclick="Button1_Click" /><asp:Button ID="Button3" runat="server" Text="取消" onclick="Button3_Click" />                       
                    </td>
                </tr>
            </table>
             </ContentTemplate>
</asp:UpdatePanel>
            <div class="close" onclick="hideOver()">
            </div>
        </div>
        <!----浮动窗口结束--------->
    
</div>
</form>
</body>
</html>
