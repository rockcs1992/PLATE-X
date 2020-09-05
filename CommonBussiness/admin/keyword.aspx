<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="keyword.aspx.cs" Inherits="CommonBussiness.admin.keyword" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>关键字</title>
    <link href="css/admin.css" type="text/css" rel="stylesheet">
    <script src="js/admin.js" type="text/javascript"></script>    
</head>
<body>
   <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div class="rtitle">
        关键字列表</div>
    <div class="rcont" style="min-height:600px;">
        <table class="tab_list" width="100%" cellpadding="0"
            cellspacing="0" border="1" align="center">
            <tr>
                <td bgcolor="#eeeeee" align="left" colspan="7">
                    <input type="button" value="关键字添加" onclick="overKeyWordDiv()">
                </td>
            </tr>
            <tr id="tjKey" runat="server" visible="false">
                <td colspan="7" align="center" style="text-align:center; font-weight:bold;">
                    页面文本总长度：<span style=" color:red;"><%=ViewState["pageTextAllLength"] %></span>字符&nbsp;&nbsp;&nbsp;
                    
                    关键字符串长度：<span style=" color:red;"><%=ViewState["keywordLength"] %></span>字符&nbsp;&nbsp;&nbsp;
                    
                    关键字出现频率：<span style=" color:red;"><%=ViewState["keywordCount"] %></span>次&nbsp;&nbsp;&nbsp;
                    
                    关键字符总长度：<span style=" color:red;"><%=ViewState["keywordAllLength"] %></span>字符&nbsp;&nbsp;&nbsp;
                    
                    （密度结果计算：<span style=" color:red;"><%=ViewState["keywordMiDu"] %>%</span>）&nbsp;&nbsp;&nbsp;
                    
                    密度建议值：2% <= 密度 <= 8%
                </td>
            </tr>
            <tr bgcolor="#444444" style="background: #444; color: #eee; font-weight: bold; border: 0px;">
                <td width="5%">
                    ID
                </td>
                <td width="10%">
                    页面名称
                </td>
                <td width="10%">
                    页面地址
                </td>
                <td width="15%">
                    标题
                </td>
                <td width="15%">
                    关键字
                </td>
                <td width="30%">
                    描述
                </td>
                <td width="10%">
                    操作
                </td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="repInfo_ItemCommand">
            <ItemTemplate>
                <tr>
                <td>
                    <%#Eval("id") %>
                </td>
                <td>
                    <%#Eval("pageName") %>
                </td>
                <td>
                    <%#Eval("pageNameValue") %>
                </td>
                <td>
                    <%#Eval("title") %>
                </td>
                <td>
                    <%#Eval("keyword") %>
                </td>
                <td>
                <%#Eval("description") %>
                </td>
                <td> <asp:LinkButton ID="LinkButton1" CommandName='mod' CommandArgument=<%# Eval("id") %> runat="server" CssClass="edit_bt">编辑</asp:LinkButton>&nbsp;&nbsp;
                 <asp:LinkButton ID="LinkButton2" CommandName='del' CommandArgument=<%# Eval("id") %> runat="server" OnClientClick="return confirm('确定删除吗？');" CssClass="edit_bt">删除</asp:LinkButton>
                </td>
            </tr>
            </ItemTemplate>
        </asp:Repeater>
            
            <tr>
                <td colspan="7" class="tleft" style="background: #eee;"><span class="tips">注意关键字优化及页面是否correct</span></td>
            </tr>
        </table>
        <div style=" text-align:center; margin-top:10px;"><span>本页记录数：<b style=" color:#e00; padding:0px 3px; font-size:14px;"><%=this.pager1.PageCount > 1 ? this.Repeater1.Items.Count.ToString() : this.pager1.RecordCount.ToString()%></b>条</span><span style=" margin-left:30px;">所有记录数：<b style=" color:#e00; padding:0px 3px; font-size:14px;"><%=this.pager1.RecordCount%></b>条</span></div>

        <div class="page" >
            <webdiyer:AspNetPager ID="pager1" runat="server" CustomInfoHTML=""
                        CustomInfoTextAlign="Left" FirstPageText="首页" LastPageText="末页" NextPageText="下一页"
                        NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Never" ShowPageIndexBox="Auto" PageSize="10"
                       CustomInfoSectionWidth="10%">
                    </webdiyer:AspNetPager>
        </div>
        <!-----浮动窗口开始---->
        <div id="wfullbg">
        </div>
        <div id="layer" class="layer" style=" margin-left:13%; top:100px;">
            <table class="cf" style="width: 600px;" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td align="right" width="20%">
                        页面名称：
                    </td>
                    <td align="left" width="80%">
                        <asp:TextBox ID="txtPageName" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        页面地址：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtURL" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        页面标题：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTitle" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        关键字：
                    </td>
                    <td align="left">
                       <asp:TextBox ID="txtKeyWord" runat="server" TextMode="MultiLine" Height="44" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        描述：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="100" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" align="right">
                        &nbsp;
                    </td>
                    <td bgcolor="#eeeeee" align="left">
                        <asp:Button ID="Button1" runat="server" Text=" 添  加 " 
                            onclick="Button1_Click1" /><input type="button" value="取&nbsp;消" onclick="hideOver()">                       
                    </td>
                </tr>
            </table>
            <div class="close" onclick="hideOver()">
            </div>
        </div>
        <!----浮动窗口结束--------->
    </div>
    </ContentTemplate>
</asp:UpdatePanel>
    </form>
</body>
</html>
