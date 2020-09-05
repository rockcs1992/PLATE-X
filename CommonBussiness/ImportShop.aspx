<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportShop.aspx.cs" Inherits="CommonBussiness.ImportShop" %>

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
                <asp:TemplateField HeaderText="类型">
                    <ItemTemplate>
                       <%#GetShopTypeName(Eval("shopType"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:BoundField DataField="comName" HeaderText="店铺名称"  />
                <asp:BoundField DataField="mobile" HeaderText="手机号" /> 
                 
                <asp:BoundField DataField="username" HeaderText="姓"  />    
                 <asp:BoundField DataField="relName" HeaderText="名"  />             
                 
                  
                    <asp:BoundField DataField="mobileCode" HeaderText="街道1"  />
                     <asp:BoundField DataField="weibo" HeaderText="街道2"  />
                        <asp:BoundField DataField="activeCode" HeaderText="城市"  />  
                          <asp:BoundField DataField="mainbrand" HeaderText="州"  />  

                   <asp:BoundField DataField="email" HeaderText="邮箱"  />  
                <asp:BoundField DataField="addTime" HeaderText="注册时间"  />    
            
                 <asp:BoundField DataField="remark" HeaderText="店铺介绍"  />
     
                 <asp:BoundField DataField="loginIP" HeaderText="IP"  />   

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
