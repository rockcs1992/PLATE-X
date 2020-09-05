<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pvTJInfo.aspx.cs" Inherits="QIANCHEN.admin.pvTJInfo" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>页面统计信息</title>
<link href="css/admin.css" type="text/css" rel="stylesheet">
    <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div class="rtitle" >页面统计信息</div>
<div class="rcont" style=" min-height:500px;"> 
    <table cellpadding="0" cellspacing="0" border="0">
		<tr>
			<td class="r_tab2">过滤IP</td>
            <td class="r_cont">
                <asp:TextBox ID="txtIP" runat="server"></asp:TextBox>(本地IP：<%=ViewState["IP"] %>)</td>   
           
            <td class="r_tab2">时间段</td>
            <td class="r_cont"><asp:TextBox ID="txtTimeFrom" runat="server" onfocus="WdatePicker({isShowOthers:true,dateFmt:'yyyy-MM-dd'})" ></asp:TextBox>-<asp:TextBox ID="txtTimeEnd" runat="server" onfocus="WdatePicker({isShowOthers:true,dateFmt:'yyyy-MM-dd'})" ></asp:TextBox></td>
            <td class="r_cont"><asp:Button ID="Button2" runat="server" Text="统计" onclick="Button2_Click" /></td>
        </tr>       
    </table>
    <table class="tab_list" width="100%" cellpadding="0" cellspacing="0" border="0" align="center";>
        <tr >
            <th width="20%">页面备注</th>
            <th width="20%">页面名称</th>
            <th width="25%">浏览次数</th>              
        </tr>
         <tr >
            <td width="20%">首页</td>
            <td width="20%">index.aspx</td>
            <td width="25%"><%=ViewState["index"] %></td>              
        </tr>
         <tr >
            <td width="20%">注册页面</td>
            <td width="20%">reg.aspx</td>
            <td width="25%"><%=ViewState["reg"] %></td>              
        </tr>
         <tr >
            <td width="20%">登陆页面</td>
            <td width="20%">login.aspx</td>
            <td width="25%"><%=ViewState["login"]%></td>              
        </tr>
         <tr >
            <td width="20%">搜索列表页面</td>
            <td width="20%">searchList.aspx</td>
            <td width="25%"><%=ViewState["searchList"]%></td>              
        </tr>
         <tr >
            <td width="20%">搜索详细页</td>
            <td width="20%">comDetail_client.aspx</td>
            <td width="25%"><%=ViewState["comDetail_client"]%></td>              
        </tr>
         <tr >
            <td width="20%">找回密码</td>
            <td width="20%">findPass.aspx</td>
            <td width="25%"><%=ViewState["findPass"]%></td>              
        </tr>
         <tr >
            <td width="20%">移动版浏览页</td>
            <td width="20%">m_comDetail.aspx</td>
            <td width="25%"><%=ViewState["m_comDetail"]%></td>              
        </tr>
         <tr >
            <td width="20%">服务协议</td>
            <td width="20%">protocol.aspx</td>
            <td width="25%"><%=ViewState["protocol"]%></td>              
        </tr>


        <tr >
            <td width="20%">充值记录</td>
            <td width="20%">storeList.aspx</td>
            <td width="25%"><%=ViewState["storeList"]%></td>              
        </tr>
        <tr >
            <td width="20%">充值界面</td>
            <td width="20%">storeMoney.aspx</td>
            <td width="25%"><%=ViewState["storeMoney"]%></td>              
        </tr>
        <tr >
            <td width="20%">会员中心</td>
            <td width="20%">userCenter.aspx</td>
            <td width="25%"><%=ViewState["userCenter"]%></td>              
        </tr>
        <tr >
            <td width="20%">更多用户信息</td>
            <td width="20%">userList.aspx</td>
            <td width="25%"><%=ViewState["userList"]%></td>              
        </tr>
        <tr >
            <td width="20%">浏览记录</td>
            <td width="20%">viewsHistory.aspx</td>
            <td width="25%"><%=ViewState["viewsHistory"]%></td>              
        </tr>
    </table>
</div>
</form>
</body>
</html>
