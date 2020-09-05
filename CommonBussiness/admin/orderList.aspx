<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderList.aspx.cs" Inherits="CommonBusiness.admin.orderList" %>
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
<div class="rtitle" >
    <asp:Label ID="lblTypeName" runat="server" Text=""></asp:Label>订单列表</div>
<div class="rcont">
    <table cellpadding="0" cellspacing="0" border="0">
    <tr><td class="tleft" style="background:#eee;" colspan="10"></td></tr>
		<tr>
        <td class="r_tab2">订单状态</td>
            <td class="r_cont">
                <asp:DropDownList ID="ddlStatus" runat="server">
                <asp:ListItem Value="99">请选择</asp:ListItem>
                    <asp:ListItem Value="0">未支付</asp:ListItem>
                    <asp:ListItem Value="1">已支付（待发货）</asp:ListItem>
                    <asp:ListItem Value="2">待收货</asp:ListItem>
                    <asp:ListItem Value="3">待评价</asp:ListItem>
                    <asp:ListItem Value="4">已完成</asp:ListItem>
                    <asp:ListItem Value="100">已取消</asp:ListItem>
                     <asp:ListItem Value="150">客户端删除</asp:ListItem>
                </asp:DropDownList>
            </td>     
        <td class="r_tab2">订单编号</td>
            <td class="r_cont">
                <asp:TextBox ID="txtNo" runat="server" Width="100px"></asp:TextBox></td>                      
            <td class="r_tab2">下单时间</td>
            <td class="r_cont"><asp:TextBox ID="txtTimeFrom" runat="server" Width="100px"   onfocus="WdatePicker({lang:'zh-cn'})" ></asp:TextBox>-<asp:TextBox ID="txtTimeEnd" runat="server" Width="100px"  onfocus="WdatePicker({lang:'zh-cn'})" ></asp:TextBox></td>
            <td class="r_cont"></td>
            <td class="r_cont"><asp:Button ID="Button1" runat="server" Text="检索" onclick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="导出所选" onclick="Button2_Click" />
            </td>
        </tr>       
    </table>
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
        	<td width="5%"><input id="Checkbox1" type="checkbox" onclick="GetAllCheckBox(this)" /></td>
            <td width="5%">订单ID</td>     
            <td width="15%">订单编号</td> 
            <td width="5%">金额</td>    
          
             <td width="10%">下单时间</td> 
             <td width="10%">付款状态</td> 
             <td width="15%">下单人</td> 
              <td width="5%">详情</td> 
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
        	        <td><asp:CheckBox ID="cbxAll" runat="server"   /></td>                    
                    <td><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' ></asp:Label></td>
                    <td ><a title="<%#Eval("orderName") %>"><%#Eval("orderNo")%></a></td>
                    <td ><%#Eval("orderTotal","{0:0.00}") %></td>                   
                    <td><%#Eval("addTime","{0:yyyy-MM-dd HH:mm}") %></td>  
                    <td ><%#GetStatus(Eval("status"))%></td>
                    <td ><%#GetUserInfo(Eval("addUser")) %></td>   
                    <td><a href="/mobile/orderDetailBack.aspx?id=<%#Eval("id") %>" target="_blank">详情</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr><td class="tleft" style="background:#eee;" colspan="10"></td></tr>
        <tr><td class="tleft" style="background:#eee;" colspan="5"> <asp:Button ID="btnDel" runat="server" Text="更新送货状态" OnClick="btnDel_Click"  />
        </td><td colspan="5" class="tright" style="background:#eee;">       
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
