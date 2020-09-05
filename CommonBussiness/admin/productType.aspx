<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productType.aspx.cs" Inherits="CommonBussiness.admin.productType" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>产品类型设置</title>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
 <script src="js/GetAllCheckBox.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="rtitle" >产品类型信息</div>
<div class="rcont" style=" min-height:500px;">

    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<tr>
            <td align="left" bgcolor="#eeeeee">
                <input onclick="overKeyWordDiv()" type="button" value="分类添加"> </input></td>
            <td align="left" bgcolor="#eeeeee">
                <asp:DropDownList ID="ddlSelProductType" runat="server" Width="200px" 
                    AutoPostBack="true" 
                    onselectedindexchanged="ddlSelProductType_SelectedIndexChanged" >
                </asp:DropDownList>
                <asp:DropDownList ID="ddlSelTwo" runat="server" Width="200px" >
                </asp:DropDownList>
                <asp:DropDownList ID="ddlSelThree" runat="server" Width="200px" Visible="false" >
                </asp:DropDownList>
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="查询" />
            </td>
        </tr>
    </table>   
        
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;">      
          <td width="5%"><input id="Checkbox1" type="checkbox" onclick="GetAllCheckBox(this)" /></td>             
            <td width="5%">ID</td>               
            <td width="20%">类型名称</td>  
             <td width="20%">类型图片</td> 
            <td width="10%">一级</td>   
            <td width="20%">二级</td> 
            <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand">
            <ItemTemplate>
                <tr>
                  <td><asp:CheckBox ID="cbxAll" runat="server"   /></td>
                    <td>
                        <asp:Label ID="lblId" runat="server" Text='<%#  Eval("id") %>'></asp:Label></td>    
                                              
                    <td><%#Eval("typeName") %></td>          
                    <td><%#GetImg(Eval("imgUrl")) %></td>                                   
                    <td><%#GetName(Eval("oneId"))%></td>          
                                                  
                    <td><%#GetName(Eval("twoId")) %></td>          
                                                  
                    <%--<td><%#Eval("threeName") %></td>  --%>
                    <td align="center">
                    <asp:LinkButton ID="lbtnMod" runat="server" CssClass="edit_bt" CommandName="mod" CommandArgument='<%#Eval("id") %>'  >编辑</asp:LinkButton>
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
   
 <div id="wfullbg">
        </div>
        <div id="layer" class="layer" style=" margin-left:13%; top:100px;">        
            <table class="cf" style="width: 800px;" cellpadding="0" cellspacing="0" border="0">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                <tr>
                    <td align="right" width="20%">
                        一级：
                    </td>
                    <td align="left" width="80%">
                         <asp:DropDownList ID="ddlOne" runat="server" Width="200px" AutoPostBack="true"
                    onselectedindexchanged="ddlOne_SelectedIndexChanged">
                </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        二级：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlTwo" runat="server" Width="200px" AutoPostBack="true"
                    onselectedindexchanged="ddlTwo_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>  
                <tr style="display:none;">
                    <td align="right">
                        三级：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlThree" runat="server" Width="200px" AutoPostBack="true"
                    onselectedindexchanged="ddlThree_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr> 
                <tr style="display:none;">
                    <td align="right">
                        四级：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlFour" runat="server" Width="200px">
                </asp:DropDownList>
                    </td>
                </tr> 
                </ContentTemplate>
</asp:UpdatePanel>
                <tr>
                    <td align="right">
                        类型名称：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTypeName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>  
                
             
                <tr>
                    <td align="right">
                        类型图片：
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Label ID="lblUrl" runat="server"
                            Text=""></asp:Label><asp:Button ID="Button6" runat="server" Text="删除图片" OnClientClick="return confirm('您确定要删除吗？');" onclick="Button6_Click" Visible="false" />(156px * 150px)
                    </td>
                </tr>  
                <tr>
                    <td align="right">
                        移动端类型图片：
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblUrl2" runat="server"
                            Text=""></asp:Label><asp:Button ID="Button7" runat="server" Text="删除图片" OnClientClick="return confirm('您确定要删除吗？');" onclick="Button7_Click" Visible="false" />(340px * 150px)
                    </td>
                </tr>  
                <tr>
                    <td align="right">
                        类型图片链接：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNameEn" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                   <tr>
                    <td align="right">
                        移动端首页更多图片：
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="FileUpload3" runat="server" /><asp:Label ID="lblUrl3" runat="server"
                            Text=""></asp:Label><asp:Button ID="Button8" runat="server" Text="删除图片" OnClientClick="return confirm('您确定要删除吗？');" onclick="Button8_Click" Visible="false" />(69px * 70px)
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
            <div class="close" onclick="hideOver()">
            </div>
        </div>
        <!----浮动窗口结束--------->
</div>
</form>
</body>
</html>
