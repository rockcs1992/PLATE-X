<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guangGaoInfo.aspx.cs" Inherits="CommonBussiness.admin.guangGaoInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>广告信息</title>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<script src="js/admin.js" type="text/javascript"></script>
     <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="rtitle" >广告信息信息</div>
<div class="rcont" style=" min-height:500px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
    	<td bgcolor="#eeeeee" align="left" colspan="5">
            <input type="button" value="广告添加" onclick="overKeyWordDiv()">
        </td>
        <td bgcolor="#eeeeee" align="left" colspan="2">
            关键字<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>&nbsp;&nbsp;投放周期<asp:DropDownList ID="ddlSelTimeStr" runat="server" >
            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">1个月</asp:ListItem>
                             <asp:ListItem Value="3">3个月</asp:ListItem>
                              <asp:ListItem Value="6">6个月</asp:ListItem>
                               <asp:ListItem Value="9">9个月</asp:ListItem>
                                <asp:ListItem Value="12">12个月</asp:ListItem>
                        </asp:DropDownList>
            <asp:Button ID="Button2" runat="server" Text="查询" onclick="Button2_Click" />
        </td> 
    </table>   
   
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
        <tr bgcolor="#444444" style="background:#444; color:#eee; font-weight:bold;"> 
            <td width="5%">ID</td>      
            <td width="5%">顺序号</td>  
            <td width="10%">投放位置</td> 
            <td width="10%">投放企业</td>  
            <td width="10%">联系人</td>
            <td width="5%">联系电话</td> 
            <td width="10%">投放周期</td> 
            <td width="10%">开始时间</td> 
            <td width="10%">结束时间</td>    
            <td width="5%">状态</td>   
            <td width="5%">添加人</td>   
            <td width="10%">操作</td>
        </tr>
        <asp:Repeater ID="repInfo" runat="server" onitemcommand="repInfo_ItemCommand">
            <ItemTemplate>
                <tr>
                <td><asp:Label ID="lblId" runat="server" Text='<%#  Eval("id") %>' ></asp:Label></td> 
                          <td><%#Eval("isNew") %></td>                           
                    <td><%#Eval("placeName") %></td>  
                    <td><%#Eval("comName") %></td>   
                    <td><%#Eval("relUser") %></td>   
                    <td><%#Eval("tel") %></td> 
                    <td><%#Eval("timeStr") %></td> 
                    <td><%#Eval("timeFrom","{0:yyyy-MM-dd}") %></td> 
                    <td><%#Eval("timeEnd", "{0:yyyy-MM-dd}")%></td>  
                    <td width="10%"><%#GetStatus(Eval("timeEnd"))%></td>                      
                    <td><%#GetUserName(Eval("addUser")) %></td>
                    <td align="right"> 
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="edit_bt"  CommandName="mod" CommandArgument='<%#Eval("id") %>'  >编辑</asp:LinkButton>
                            <asp:LinkButton ID="lbtnDel" runat="server" CssClass="edit_bt" OnClientClick="return confirm('您确定要删除吗？');"  CommandName="del" CommandArgument='<%#Eval("id") %>'  >删除</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
       
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
    <!-----浮动窗口开始---->
        <div id="wfullbg">
        </div>
        <div id="layer" class="layer" style=" margin-left:13%; top:0px;">        
            <table class="cf" style="width: 600px;" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td align="right">
                       
                    </td>
                    <td align="left">
                        <img class="n_upimg mt10" src="<%=ViewState["guangGaoImg1"] %>">
                    </td>
                </tr>  
                <tr>
                    <td align="right">
                       浏览上传：
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="filepic" runat="server"  onchange="javascript:__doPostBack('lbUploadPhoto','')"/><asp:LinkButton ID="lbUploadPhoto" runat="server" OnClick="lbUploadPhoto_Click"></asp:LinkButton>(建议尺寸：120px * 120px)
                    </td>
                </tr>  
                <tr>
                    <td align="right">
                        链接路径：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLinkurl" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>                 
                <tr>
                    <td align="right">
                        投放位置：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlPlace" runat="server" Width="212px" Height="36px">
                            <asp:ListItem Value="1">搜索页面（120 * 120）</asp:ListItem>
                             <%--<asp:ListItem Value="2">首页中间（705*120）</asp:ListItem>
                             <asp:ListItem Value="3">品牌详细页左侧（300*75）</asp:ListItem>
                             <asp:ListItem Value="4">测评页左侧（300*75）</asp:ListItem>
                             <asp:ListItem Value="5">测评页中间（705*120）</asp:ListItem>
                             <asp:ListItem Value="6">资讯页左侧（300*75）</asp:ListItem>
                             <asp:ListItem Value="7">资讯页中间（705*120）</asp:ListItem>
                             <asp:ListItem Value="8">产品详细页左侧（300*75）</asp:ListItem>--%>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        投放企业：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtComName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr> 
                <tr>
                    <td align="right">
                        联系人：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRelUser" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>  
                <tr>
                    <td align="right">
                        联系电话：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTel" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>   
                 <tr>
                    <td align="right">
                        顺序号：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtOrder" runat="server" Width="200px" Text="0"></asp:TextBox>
                    </td>
                </tr>  
                <tr>
                    <td align="right" width="20%">
                        投放周期：
                    </td>
                    <td align="left" width="80%">
                        <asp:DropDownList ID="ddlTimeStr" runat="server"  Width="212px" Height="36px">
                            <asp:ListItem Value="1">1个月</asp:ListItem>
                             <asp:ListItem Value="3">3个月</asp:ListItem>
                              <asp:ListItem Value="6">6个月</asp:ListItem>
                               <asp:ListItem Value="9">9个月</asp:ListItem>
                                <asp:ListItem Value="12">12个月</asp:ListItem>
                        </asp:DropDownList>
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
