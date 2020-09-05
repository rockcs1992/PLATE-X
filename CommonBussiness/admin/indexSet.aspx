
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexSet.aspx.cs" Inherits="CommonBusiness.admin.indexSet" ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml" lang="zh" >
<head id="Head1" runat="server">
<meta charset="utf-8">
<title>关于我们栏目设置</title>
<link href="css/admin.css" type="text/css" rel="stylesheet">
<style type="text/css">
        #bodyImg1{
            FILTER: progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)
        }
    </style>
    <script type="text/javascript">
        function SetHidLabel(obj) {
            document.getElementById("hidLabel").value = obj;
            document.getElementById("txtLabel").value = obj;
        }
    </script>
    <script src="js/admin.js" type="text/javascript"></script>
    
    </head>
<body>
<form id="form10" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
</asp:UpdatePanel>
<div class="rtitle" >关于我们信息设置</div>
<div class="rcont">
	<table cellpadding="0" cellspacing="0" border="0">		
    <tr><td class="tleft" style="background:#eee;" colspan="10"></td></tr>   
        <tr style="display:none;">
			<td class="r_tab">企业介绍图片：</td>            
			<td class="r_cont">
              <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Label ID="lblURL" runat="server" Text=""></asp:Label><br /><br />
              <asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblSmall" runat="server" Text=""></asp:Label>
            </td>
            <td style="text-align:left;"><!--编辑器开始-->     
            
             <!--编辑器结束-->  </td>
		</tr> 
		<tr>
			<td class="r_tab">微乳会设置：</td>            
			<td class="r_cont">
                标题：<asp:TextBox ID="TextBox1" runat="server" Width="50%" Height="30px"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:top;">内容：<asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="80%" Height="80px"></asp:TextBox>  </td>
		</tr>
        <tr>
			<td class="r_tab">微宝贝设置：</td>            
			<td class="r_cont">
                标题：<asp:TextBox ID="TextBox3" runat="server" Width="50%" Height="30px"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:top;">内容：<asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Width="80%" Height="80px"></asp:TextBox>  </td>
		</tr>
        <tr>
			<td class="r_tab">Plate-X设置：</td>            
			<td class="r_cont">
                标题：<asp:TextBox ID="TextBox5" runat="server" Width="50%" Height="30px"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:top;">内容：<asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" Width="80%" Height="80px"></asp:TextBox>  </td>
		</tr>
        <tr>
			<td class="r_tab">微妈专题设置：</td>            
			<td class="r_cont">
                标题：<asp:TextBox ID="TextBox7" runat="server" Width="50%" Height="30px"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:top;">内容：<asp:TextBox ID="TextBox8" runat="server" TextMode="MultiLine" Width="80%" Height="80px"></asp:TextBox>  </td>
		</tr>
        <tr>
			<td class="r_tab">微妈商圈设置：</td>            
			<td class="r_cont">
                标题：<asp:TextBox ID="TextBox9" runat="server" Width="50%" Height="30px"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:top;">内容：<asp:TextBox ID="TextBox10" runat="server" TextMode="MultiLine" Width="80%" Height="80px"></asp:TextBox>  </td>
		</tr>
        <tr>
			<td class="r_tab">微妈同城设置：</td>            
			<td class="r_cont">
                标题：<asp:TextBox ID="TextBox11" runat="server" Width="50%" Height="30px"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:top;">内容：<asp:TextBox ID="TextBox12" runat="server" TextMode="MultiLine" Width="80%" Height="80px"></asp:TextBox>  </td>
		</tr>
        <tr>
			<td class="r_tab">联系微妈设置：</td>            
			<td class="r_cont">
                标题：<asp:TextBox ID="TextBox13" runat="server" Width="50%" Height="30px"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:top;">内容：<asp:TextBox ID="TextBox14" runat="server" TextMode="MultiLine" Width="80%" Height="80px"></asp:TextBox>  </td>
		</tr>
        <tr>
			<td class="r_tab">服务查询预约设置：</td>            
			<td class="r_cont">
                标题：<asp:TextBox ID="TextBox15" runat="server" Width="50%" Height="30px"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:top;">内容：<asp:TextBox ID="TextBox16" runat="server" TextMode="MultiLine" Width="80%" Height="80px"></asp:TextBox>  </td>
		</tr>
		<tr>
			<td class="r_tab">&nbsp;</td>
			<td style="text-align:left;"><asp:Button ID="Button1" runat="server" Text=" 保 存 " onclick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Button ID="Button2" runat="server" Text=" 重 置 " OnClientClick="return confirm('您确定要重置吗？');" onclick="Button2_Click" /></td>
            <td class="r_cont">&nbsp;</td>
		</tr>         
	</table>
</div>
</form>
</body>
</html>
