<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="topInfo.aspx.cs" Inherits="CommonBussiness.admin.topInfo" %>

<html xmlns="http://www.w3.org/1999/xhtml" lang="zh" >
<head id="Head1" runat="server">
<meta charset="utf-8">
<title>基础设置</title>
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
    <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="rtitle" >新闻置顶</div>
<div class="rcont">
    <div class="news">
    	<div class="n_left mt20 fl">           
        	<div class="n_tab">上传图片</div>
            <table border="0" cellpadding="0" cellspacing="0" width="50%">
            	<tr>
                	<td class="table_l"></td>
                    <td class="table_r"><img class="n_upimg mt10" src="<%=ViewState["newsImg1"] %>"></td>
                </tr>
                <tr>
                	<td class="table_l">浏览上传：</td>
                    <td class="table_r">
                        <asp:FileUpload ID="filepic" runat="server"  onchange="javascript:__doPostBack('lbUploadPhoto','')"/><asp:LinkButton ID="lbUploadPhoto" runat="server" OnClick="lbUploadPhoto_Click"></asp:LinkButton></td>
                </tr>
                <tr>
                	<td class="table_l"></td>
                    <td class="table_r"><span class="tips">推荐尺寸：440px * 305px</span></td>
                </tr>
            </table>      

            <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                	<td class="table_l">标题：</td>
                    <td class="table_r"><asp:TextBox ID="txtTitle" runat="server" Width="300px" ></asp:TextBox></td>
                </tr>
            	
            <tr>
                	<td class="table_l">摘要：</td>
                    <td class="table_r"><asp:TextBox ID="txtZhaiYao" runat="server" style="height:70px; width:70%" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
            	
                <tr>
                	<td class="table_l"></td>
                    <td class="table_r"><asp:Button ID="btnRelease" runat="server" Text="置顶" 
                                onclick="btnRelease_Click" /><asp:Button ID="btnCancel" runat="server" Text="取消" 
                                onclick="btnCancel_Click" /><asp:Label ID="lblError"
                                    runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
        </div>
        
        </div>        
      
    </div>
</div>
</form>
</body>
</html>
