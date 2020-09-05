<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inok.aspx.cs" Inherits="CommonBussiness.admin.inok" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>后台管理界面</title>
<link href="css/admin.css" type="text/css" rel="stylesheet" />
<script src="js/admin.js" type="text/javascript"></script>
<!--框架自适应高度 开始-->
<script type="text/javascript">

    function reinitIframe() {

        var iframe = document.getElementById("iframeid");

        try {

            iframe.height = iframe.contentWindow.document.documentElement.scrollHeight;

        } catch (ex) { }

    }

    window.setInterval("reinitIframe()", 200);

</script>
<!--框架自适应结束-->
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<!--top begin-->
<div class="top">
	<div class="top_logo fl"><a href="/" target="_blank" style="width: 100%;float: left; height: 70px; font-size: 20px;">PLATE-X SYSTEM</a></div>
    <div class=" top_user fl mt10"><span style=" font-size:14px;">欢迎你：</span><%=ViewState["realName"]%>&nbsp;&nbsp;<span class="tips">(&nbsp;<%=ViewState["username"] %>&nbsp;|&nbsp;<%=ViewState["roleName"]%>&nbsp;)</span></div>
	<div class="top_info fr"><a href="/exit.aspx?action=sysback"><img src="image/login_out.png" title="退出当前账户" /></a></div>
	<div class="cf"></div>
</div>
<!----top end-->
<div class="main">
	<!--left begin-->
    <div id="left" class="left">
        
            <div  class="left_tab" style="padding-left:65px; border-bottom:1px solid #232a2e;">后台首页</div>
         <%--   <div class="left_tab" style="padding-left:30px;">微信产品</div>
		    <ul>
            <li id="m_51" onclick="dis_cont('/admin/wx_goods.aspx',51,2,52)" class="">产品列表</li>
            <li id="m_52" onclick="dis_cont('/admin/wx_order.aspx',52,2,52)" class="">订单信息</li>
            </ul>--%>
            <%=GetMenu() %>
            <ul>
            <li id="m_5" onclick="dis_cont('/admin/manager.aspx',5,2,6)" class="">&nbsp;</li>
             <li id="Li1" onclick="dis_cont('/admin/manager.aspx',5,2,6)" class="">&nbsp;</li>
              <li id="Li2" onclick="dis_cont('/admin/manager.aspx',5,2,6)" class="">&nbsp;</li>
              <li id="Li3" onclick="dis_cont('/admin/manager.aspx',5,2,6)" class="">&nbsp;</li>
               <li id="Li4" onclick="dis_cont('/admin/manager.aspx',5,2,6)" class="">&nbsp;</li>
               <li id="Li5" onclick="dis_cont('/admin/manager.aspx',5,2,6)" class="">&nbsp;</li>
            
            </ul>
	</div>
	<!--left end-->
	<!--right begin-->
	<div class="right"> 
		<div id="r_div" class="right_body">            
			<iframe src="main.aspx" id="iframeid" name="iframeid" frameBorder="0"  scrolling="no" height="" width="100%"></iframe><!-----设置默认打开页面--------->
		</div>
        <div class="blank_30"></div>
	</div>
	<!--right end-->
</div>
</ContentTemplate>
</asp:UpdatePanel>
</form>

</body>
</html>
