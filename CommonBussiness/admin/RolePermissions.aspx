<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rolePermissions.aspx.cs" Inherits="CommonBussiness.admin.rolePermissions" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd"> 
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色权限设置</title>
    <script src="js/GetAllCheckBox.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/level.js" type="text/javascript"></script>
</head>
<body style=" font-size:12px;">
<form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hidRowsCount" runat="server" />
        <asp:HiddenField ID="hidDepartId" runat="server" />
       <asp:HiddenField ID="hidRoleId" runat="server" />
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
               <td align="left">
                    <table align="center" width="80%" >
                        <tr>
                            <th colspan="2" height="30">
                                当前角色权限设置</th>
                        </tr>
                        <tr>
                            <th style="text-align:right; width:200px" height="25">
                                角色名称：</th>
                            <td style="text-align:left">
                                <asp:Label ID="lblRoleName" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                           <th style="text-align:right; width:200px" height="25">
                                所属部门：</th>
                            <td style="text-align:left">
                                <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                            <th style="text-align:right; width:200px" height="25">
                                角色描述：</th>
                            <td style="text-align:left">
                                <asp:Label ID="lblRoleDesc" runat="server"></asp:Label>
                            </td>
                        </tr>                        
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table align="center" width="80%" >
                        <tr> 
                        <th style="text-align:left; width:200px" height="225">
                                </th>
                             <td style="text-align:left" align="left" >                                   
                                    <asp:TreeView ID="tvModel" runat="server" Height="233px" Width="389px" 
                                        ShowLines="True" EnableViewState="False" >
                                    </asp:TreeView>                        
                            </td>
                        </tr>                       
                        </table>
                </td>
            </tr>
        </table>
                       <div style="margin-top:5px;text-align:right;">
                       <input type="button" onclick="GetSel();" value="保存" />
                
                    </div>   
    
    </div>
    </form>
</body>
</html>
