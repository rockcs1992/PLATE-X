<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productList.aspx.cs" Inherits="CommonBussiness.admin.productList" %>
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh" >
<head>
<meta charset="utf-8">
<title></title>
<link href="css/admin.css" type="text/css" rel="stylesheet">        
     <script src="js/GetAllCheckBox.js" type="text/javascript"></script>
    <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="rtitle" >产品列表</div>
<div class="rcont">
    <table cellpadding="0" cellspacing="0" border="0">
		<tr>
			<td class="r_tab2">产品名称</td>
            <td class="r_cont">
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td> 
            <td class="r_tab2">产品类型</td>
            <td class="r_cont">
                <asp:DropDownList ID="ddlProductType" runat="server" 
                    onselectedindexchanged="ddlProductType_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>   
                 <asp:DropDownList ID="ddlSon" runat="server">
                </asp:DropDownList>   
            </td> 
            <td class="r_tab2">推荐状态</td>
            <td class="r_cont">
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="100">请选择</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:DropDownList>   
            </td> 
            <td class="r_tab2">发布时间</td>
            <td class="r_cont"><asp:TextBox ID="txtTimeFrom" runat="server" onfocus="WdatePicker({lang:'zh-cn'})" ></asp:TextBox>-<asp:TextBox ID="txtTimeEnd" runat="server" onfocus="WdatePicker({lang:'zh-cn'})" ></asp:TextBox></td>           
            <td class="r_cont"><asp:Button ID="Button1" runat="server" Text="检索" onclick="Button1_Click" /><a href="addProduct.aspx?userId=<%=ViewState["userId"] %>" style=" background:rgb(68, 68, 68); color:#ffffff; padding:5px 10px; border-radius:2px;">添加商品</a></td>
        </tr>       
    </table>
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">
        	<td width="5%"><input id="Checkbox1" type="checkbox" onclick="GetAllCheckBox(this)" /></td>
                  <td width="10%">商家</td>               
            <td width="10%">产品名称</td>     
             <td width="5%">类型</td>    
             <td width="5%">库存数量</td>   
               <td width="5%">产品规格</td> 
                 <td width="5%">产品价格</td> 
          <td width="10%">产地</td>   
                    <td width="10%">列表图片</td>  
                    <td width="5%">推荐</td>  
            <td width="5%">操作</td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" onitemcommand="repInfo_ItemCommand">
            <ItemTemplate>
                <tr>
        	        <td><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label><asp:CheckBox ID="cbxAll" runat="server"   /></td> 
                    <td><%#GetShoper(Eval("useId")) %></td>                  
                    <td><%#Eval("proName") %></td>
                    <td ><%#Eval("productTypeName")%></td>
                    <td ><%#Eval("proType")%></td>
                    
                    <td ><%#Eval("unit1")%></td>
                    <td ><%#Eval("price1","{0:0.00}")%></td>
                    <td ><%#Eval("fromName")%></td>
                      <td ><%#Convert.ToInt32(Eval("status")) == 1 ? "<span style='color:Red'>是</span>" : "否"%></td>
               
                      <td><img src="<%#Eval("listImgUrl") %>" style="width:100px; height:100px;" /></td>
                     
                 <td ><%--<a class="edit_bt"  href="productImg.aspx?productId=<%#Eval("id") %>">移动配置</a>&nbsp;&nbsp;--%><a class="edit_bt"  href="addProduct.aspx?id=<%#Eval("id") %>">编辑</a>&nbsp;&nbsp;
                     <asp:LinkButton ID="lbtnDel" runat="server" CssClass="edit_bt" OnClientClick="return confirm('您确定要删除吗？');"  CommandName="del" CommandArgument='<%#Eval("id") %>'  >删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        
        <tr><td colspan="10" class="tleft" style="background:#eee;">
        <asp:Button ID="btnDel" runat="server" Text="删除所选" OnClientClick="return confirm('您确认要删除吗？');" OnClick="btnDel_Click" />   
        <asp:Button ID="btnTj" runat="server" Text="推荐所选" OnClick="btnTj_Click"/> 
        <asp:Button ID="btnCancel" runat="server" Text="取消推荐" OnClick="btnCancel_Click" />   
        <asp:Button ID="btnOK" runat="server" Text="审核通过" OnClick="btnOK_Click" Visible="false"  /> 
        <asp:Button ID="btnNO" runat="server" Text="审核失败" OnClick="btnNO_Click" Visible="false"  />     
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
