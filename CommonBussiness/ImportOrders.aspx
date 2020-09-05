<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportOrders.aspx.cs" Inherits="CommonBussiness.ImportOrders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>       
    <table width="100%">
    <tr><th align="center" width="100%" colspan="5"><%=ViewState["columnCount"]%></th></tr>
    </table>
         <asp:GridView ID="GridView1" runat="server" Height="130px" Width="100%" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="编号" />
                 <asp:BoundField DataField="addTime" HeaderText="下单时间"  /> 
                  <asp:BoundField DataField="orderTotal" HeaderText="合计金额"  /> 
                <asp:TemplateField HeaderText="订单状态">
                    <ItemTemplate>
                       <%#GetOrderStatusName(Eval("status"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="mobile" HeaderText="手机号" /> 
                 <asp:TemplateField HeaderText="下单人">
                    <ItemTemplate>
                       <%#GetUserInfo(Eval("addUser"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订单详情">
                    <ItemTemplate>
                       <%#GetOrderDetailInfo(Eval("id"))%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle 
                Font-Size="12px" />
            <RowStyle HorizontalAlign="Center" 
                BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
