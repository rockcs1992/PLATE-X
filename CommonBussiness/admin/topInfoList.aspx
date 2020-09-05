<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="topInfoList.aspx.cs" Inherits="CommonBussiness.admin.topInfoList" %>
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh" >
<head>
<meta charset="utf-8">
<title></title>
<link href="css/admin.css" type="text/css" rel="stylesheet">        
    <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
     <script src="js/GetAllCheckBox.js" type="text/javascript"></script>

</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="rtitle" >置顶资讯列表</div>
<div class="rcont">
    <table cellpadding="0" cellspacing="0" border="0">
		<tr>
			<td class="r_tab2">关键字</td>
            <td class="r_cont">
                <asp:TextBox ID="txtKey" runat="server"></asp:TextBox></td>            
            <td class="r_tab2">置顶时间</td>
            <td class="r_cont"><asp:TextBox ID="txtTimeFrom" runat="server"   onfocus="WdatePicker({lang:'zh-cn'})" ></asp:TextBox>-<asp:TextBox ID="txtTimeEnd" runat="server"  onfocus="WdatePicker({lang:'zh-cn'})" ></asp:TextBox></td>           
            <td class="r_cont"><asp:Button ID="Button1" runat="server" Text="检索" onclick="Button1_Click" /></td>
        </tr>       
    </table>
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
        	<td width="5%"><input id="Checkbox1" type="checkbox" onclick="GetAllCheckBox(this)" /></td>
             <td width="15%">资讯标题</td>   
             <td width="15%">置顶标题</td>     
             <td width="10%">资讯类别</td>           
            <td width="15%">图片路径</td>     
             <td width="15%">基本信息</td>             
            <td width="10%">置顶时间</td> 
            <td width="5%">操作</td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
        	        <td><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label><asp:CheckBox ID="cbxAll" runat="server"   /></td>    
                     <td ><%#GetNewsInfo(Eval("newsId"),1) %></td>    
                      <td><%#Eval("remark") %></td>                
                    <td ><%#GetNewsInfo(Eval("newsId"), 2)%></td>
                    <td><a href="<%#Eval("imgURL") %>" target="_blank"><%# Eval("imgURL") %></a></td>
                     <td><%#Eval("baseInfo") %></td>                    
                    <td><%#Eval("addTime","{0:yyyy-MM-dd}") %></td>
                    <td ><a class="edit_bt"  href="topInfo.aspx?id=<%#Eval("id") %>">编辑</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>        
        <tr><td colspan="10" class="tleft" style="background:#eee;">
        <asp:Button ID="btnDel" runat="server" Text="删除所选" OnClientClick="return confirm('您确认要删除吗？');" OnClick="btnDel_Click" />            
       </td></tr>
    </table>
    <div style=" text-align:center; margin-top:10px;"><span>本页记录数：<b style=" color:#e00; padding:0px 3px; font-size:14px;"><%=this.pager1.PageCount > 1 ? this.Repeater1.Items.Count.ToString() : this.pager1.RecordCount.ToString()%></b>条</span><span style=" margin-left:30px;">所有记录数：<b style=" color:#e00; padding:0px 3px; font-size:14px;"><%=this.pager1.RecordCount%></b>条</span></div>

    <div class="page">
     <webdiyer:AspNetPager ID="pager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条"
                        CustomInfoTextAlign="Left" FirstPageText="首页" LastPageText="末页" NextPageText="下一页"
                        NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Never" ShowPageIndexBox="Auto" PageSize="10"
                       CustomInfoSectionWidth="10%">
                    </webdiyer:AspNetPager>
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>
