<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addProduct.aspx.cs" Inherits="CommonBussiness.admin.addProduct" %>

<html xmlns="http://www.w3.org/1999/xhtml" lang="zh" >
<head id="Head1" runat="server">
<meta charset="utf-8">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>��Ӳ�Ʒ</title>
<!--�༭������ ��ʼ-->
   <link rel="stylesheet" href="../kindeditor-v4.1.7/themes/default/default.css" />
	<link rel="stylesheet" href="../kindeditor-v4.1.7/plugins/code/prettify.css" />
	<script charset="utf-8" src="../kindeditor-v4.1.7/kindeditor.js"></script>
	<script charset="utf-8" src="../kindeditor-v4.1.7/lang/zh_CN.js"></script>
	<script charset="utf-8" src="../kindeditor-v4.1.7/plugins/code/prettify.js"></script>
	<script>
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content1', {
	            cssPath: '../kindeditor-v4.1.7/plugins/code/prettify.css',
	            uploadJson: '../kindeditor-v4.1.7/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor-v4.1.7/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content2', {
	            cssPath: '../kindeditor-v4.1.7/plugins/code/prettify.css',
	            uploadJson: '../kindeditor-v4.1.7/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor-v4.1.7/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content3', {
	            cssPath: '../kindeditor-v4.1.7/plugins/code/prettify.css',
	            uploadJson: '../kindeditor-v4.1.7/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor-v4.1.7/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	</script>
<!--�༭������ ����-->
<link href="css/admin.css" type="text/css" rel="stylesheet">
<style type="text/css">
        #bodyImg1{
            FILTER: progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)
        }
    </style>
    
    <script src="js/admin.js" type="text/javascript"></script>
    <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <style type="text/css">
        .td{ width:12%; text-align:right;}
        .td2{ width:88%; text-align:left}
    </style>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="rtitle" >��Ӳ�Ʒ</div>
<div class="rcont">
    <div class="news">
    	<div class="n_left mt20 fl">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
            	<tr style="display:none;">       
                    <td colspan="3"><img class="n_upimg mt10" src="<%=ViewState["productImg1"] %>"></td>
                   
                    <td>&nbsp;</td>
                    
                </tr>       
                 
               <tr>
                    <td valign="top">��Ʒ���ࣺ</td>
                    <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:DropDownList ID="ddlOne" runat="server" Width="400px" AutoPostBack="true" 
                            onselectedindexchanged="ddlOne_SelectedIndexChanged">
                    </asp:DropDownList><br />
                    <asp:DropDownList ID="ddlTwo" runat="server" Width="400px" AutoPostBack="true" onselectedindexchanged="ddlTwo_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:DropDownList ID="ddlThree" runat="server" Width="400px">
                            </asp:DropDownList>
                            </ContentTemplate>
                </asp:UpdatePanel>           
                    </td>
                    <td></td>
                    <td></td>
                </tr>  
                    
                

                <%--<tr style="display:none;">          
                    <td>��ԴͼƬ��</td>      	
                    <td>
                        <asp:FileUpload ID="FileUpload9" runat="server"  /></td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>--%>
                 <tr>
                    <td>��Ʒ���ƣ�</td>
                    <td><asp:TextBox ID="txtProductName" runat="server" CssClass="n_title" Width="400px"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                </tr>  
                 <tr>
                    <td>���������</td>
                    <td><asp:TextBox ID="txtStoreCount" runat="server" CssClass="n_title" Width="400px"></asp:TextBox>��</td>
                    <td></td>
                    <td></td>
                </tr>  
                 <tr>
                    <td>��Ʒ���أ�</td>
                    <td><asp:TextBox ID="txtFrom" runat="server" CssClass="n_title" Width="400px"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                </tr>  
                <tr style="display:none;">
                    <td>��ƷƷ�֣�</td>
                    <td>
                    <asp:DropDownList ID="ddlVariety" runat="server" Width="400px">
                    </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr> 
                <tr style="display:none;">
                    <td>���Ķȣ�</td>
                    <td>
                    <asp:DropDownList ID="ddlRelieve" runat="server" Width="400px">
                    </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr> 
                <tr style="display:none;">
                    <td>��⿷�ʽ��</td>
                    <td>
                    <asp:DropDownList ID="ddlCook" runat="server" Width="400px">
                    </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr> 
                 <%--<tr style="display:none;">
                    <td>Ʒ�֣�</td>
                    <td>
                    <asp:DropDownList ID="ddl" runat="server" Width="400px" AutoPostBack="true">
                    </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr> 
                
                <tr style="display:none;">
                    <td>��;��</td>
                    <td>
                    <asp:DropDownList ID="DropDownList5" runat="server" Width="400px" AutoPostBack="true">
                    </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr> --%>
                <tr>
                    <td>��Ʒ�ص㣺</td>
                    <td><asp:TextBox ID="prodesc" runat="server" CssClass="n_title" Width="400px"></asp:TextBox></td>
                    <td></td>
                    <td>&nbsp;</td>
                </tr>  
                <tr>
                    <td>��Ʒ���1��</td>
                    <td><asp:TextBox ID="unit1" runat="server" CssClass="n_title" Width="400px"></asp:TextBox></td>
                    <td></td>
                    <td>&nbsp;</td>
                </tr>  
                 <tr>
                    <td>��Ʒ�۸�1��</td>
                    <td>
                        <asp:TextBox ID="price1" runat="server" CssClass="n_title" Width="400px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr style="display:none;">
                    <td>��Ʒ���2��</td>
                    <td><asp:TextBox ID="unit2" runat="server" CssClass="n_title" Width="400px"></asp:TextBox></td>
                    <td></td>
                    <td>&nbsp;</td>
                </tr> 
                <tr style="display:none;">
                    <td>��Ʒ�۸�2��</td>
                    <td>
                        <asp:TextBox ID="price2" runat="server" CssClass="n_title" Width="400px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr style="display:none;">
                    <td>��Ʒ���3��</td>
                    <td><asp:TextBox ID="unit3" runat="server" CssClass="n_title" Width="400px"></asp:TextBox></td>
                    <td></td>
                    <td>&nbsp;</td>
                </tr> 
                <tr style="display:none;">
                    <td>��Ʒ�۸�3��</td>
                    <td>
                        <asp:TextBox ID="price3" runat="server" CssClass="n_title" Width="400px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr style="display:none;">
                    <td>��Ʒ���4��</td>
                    <td><asp:TextBox ID="unit4" runat="server" CssClass="n_title" Width="400px"></asp:TextBox></td>
                    <td></td>
                    <td>&nbsp;</td>
                </tr> 
                <tr style="display:none;">
                    <td>��Ʒ�۸�4��</td>
                    <td>
                        <asp:TextBox ID="price4" runat="server" CssClass="n_title" Width="400px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>�ƶ�������</td>
                    <td>
                        <asp:TextBox ID="txtMobileGood" runat="server" CssClass="n_title" Width="400px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr style="display:none;">
                    <td>�ƶ��Ƽ�˳��</td>
                    <td>
                        <asp:TextBox ID="txtTjOrder" runat="server" CssClass="n_title" Width="400px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>          
                    <td style=" width:80px;">�б�ͼƬ��</td>      	
                    <td>
                        <asp:FileUpload ID="filepic" runat="server"  />
                        <asp:LinkButton ID="lbUploadPhoto" runat="server" OnClick="lbUploadPhoto_Click"></asp:LinkButton></td>
                    <td style="width:200px;">
                        <asp:Label ID="lblImgUrl" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>          
                    <td>��ϸͼƬ1��</td>      	
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server"  />
                       </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="display:none;">          
                    <td>��ϸͼƬ2��</td>      	
                    <td>
                        <asp:FileUpload ID="FileUpload2" runat="server"  />
                       </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="display:none;">          
                    <td>��ϸͼƬ3��</td>      	
                    <td>
                        <asp:FileUpload ID="FileUpload3" runat="server"  />
                       </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="display:none;">          
                    <td>��ϸͼƬ4��</td>      	
                    <td>
                        <asp:FileUpload ID="FileUpload4" runat="server"  />
                       </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>

                <tr style="display:none;">          
                    <td>��֤ͼƬ1��</td>      	
                    <td>
                        <asp:FileUpload ID="FileUpload5" runat="server"  />
                        </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="display:none;">          
                    <td>��֤ͼƬ2��</td>      	
                    <td>
                        <asp:FileUpload ID="FileUpload6" runat="server"  />
                        </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="display:none;">          
                    <td>��֤ͼƬ3��</td>      	
                    <td>
                        <asp:FileUpload ID="FileUpload7" runat="server"  />
                        </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="display:none;">          
                    <td>��֤ͼƬ4��</td>      	
                    <td>
                        <asp:FileUpload ID="FileUpload8" runat="server"  />
                        </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>��Ʒ�ŵ㣺</td>
                    <td colspan="3">
                    <textarea id="content2" cols="100" rows="8" style=" height:300px; visibility:hidden; width:100%; border:1px red solid;" runat="server"></textarea>
                    </td>
                </tr>          

                <tr>
                    <td valign="top">��Ʒ������</td>
                    <td colspan="3">
  <textarea id="content1" cols="100" rows="8" style=" height:600px; visibility:hidden; width:100%; border:1px red solid;" runat="server"></textarea>
                    </td>
                </tr>   
                <tr style="display:none;">
                    <td valign="top">�ֻ����ݣ�</td>
                    <td colspan="3">
  <textarea id="content3" cols="100" rows="8" style=" height:600px; visibility:hidden; width:100%; border:1px red solid;" runat="server"></textarea>
                    </td>
                </tr>  
            </table>
            <div class="blank_10"></div>
            <!--�༭����ʼ-->
          
             <!--�༭������-->         
              <table>
                    <tr>
                    	<td class="table_l_2"></td>
                        <td>
                            <asp:Button ID="btnRelease" runat="server" Text="  �� ��  " onclick="btnRelease_Click" /><asp:Label ID="lblError"
                                    runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
        </div>        
    </div>
</div>
</form>
</body>
</html>