<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoper_product_add.aspx.cs" Inherits="CommonBussiness.mobile.shoper_product_add" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta content="initial-scale=1.0,user-scalable=no,maximum-scale=1,width=device-width" name="viewport" />
<meta content="yes" name="apple-mobile-web-app-capable" />
<meta content="black" name="apple-mobile-web-app-status-bar-style"/>
<meta content="telephone=no" name="format-detection" />
   <title><%= ViewState["title"] %></title>
    <meta name="keywords" content="<%= ViewState["keyword"] %>" />
    <meta name="description" content="<%= ViewState["miaoshu"] %>" /> 

<link rel="stylesheet" href="css/base.css"/>
<link rel="stylesheet" href="css/content.css"/>
<script src="js/jquery.js"></script>
<script type="text/javascript" src="js/slider.js"></script>
<script type="text/javascript" src="js/lazyload.js"></script>
<script src="js/index.js"></script>
    <script src="js/reg.js" type="text/javascript"></script>
    <style type="text/css">
        .register ul li{ margin-top:10px;}
        .register{ margin-bottom:100px;}
        .register .logo{ border-radius:50%;}
         input[type=radio]{ width:20px; height:20px; margin-right:5px;}
         .register .title:before{ background:none;}
         .register .title:after{ background:none;}
         .register .title{ font-size:16px; color:#000000; margin-top:5px;}
         select{ outline:1px solid #d2d2d2; border-radius: 2px; width:100%; font-size: 16px; padding: 9px 3%; color: #000; -webkit-appearance: none;}
         .register .logo{ border:1px #eeeeee solid;border-radius:0;}
         textarea::-webkit-input-placeholder {
               /* placeholder颜色  */
               color: #aaaaaa;
    font-family:"Microsoft YaHei"
         }
    </style>
    <!--编辑器引用 开始-->
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
	</script>
<!--编辑器引用 结束-->
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager><asp:FileUpload ID="filepic" runat="server"  onchange="showImage(this,'headImgId');" style="display:none;" />
<div class="register"> <a href="/mobile/shoper_product.html" class="close"></a> <platex id="headImgId" onclick="document.getElementById('filepic').click();"><img src="<%=ViewState["imgUrl"] %>" class="logo"/></platex> 
<asp:HiddenField ID="hidImg" runat="server" />
  <p class="title">Picture【200px * 150px】</p>
  <ul>
  <li>
      <asp:DropDownList ID="ddlProductType" runat="server">
      </asp:DropDownList>
      </li>
    <li>
      <asp:TextBox ID="proname" runat="server" CssClass="tel" placeholder="Item Name"  autocomplete="off"></asp:TextBox>
      </li>
   
    <li>
      <asp:TextBox ID="storeCount" runat="server" CssClass="tel" placeholder="Amount in StockQuantity" autocomplete="off"></asp:TextBox>
      </li>
 
    <li>
      <asp:TextBox ID="unit1" runat="server" CssClass="tel" placeholder="Unit" autocomplete="off"></asp:TextBox>
      </li>
 
   
    <li>
      <asp:TextBox ID="price1" runat="server" CssClass="tel" placeholder="Price" autocomplete="off"></asp:TextBox>
      </li>
 <li>
       <asp:TextBox ID="infoDesc" runat="server" CssClass="tel" placeholder="More About this Item" TextMode="MultiLine" Height="300px" autocomplete="off"></asp:TextBox>
    </li>
    <li>
        <asp:Button ID="btnAdd" runat="server" CssClass="zhuce" Text="Save" 
            onclick="btnAdd_Click" />
        <asp:HiddenField ID="hidId" runat="server" />
    </li>   
  </ul>
</div>
<uc1:bottom ID="bottom1" runat="server" /> 
</form>
</body>
</html>
<script type="text/javascript">
    function showImage(file, id) {
        var ext = file.value.toLowerCase().split('.').splice(-1);
        var div = document.getElementById(id);
        if (file.files && file.files[0]) {
            div.innerHTML = "<img id='img_" + id + "' class='logo'>";
            var img = document.getElementById("img_" + id);
            img.onload = function () {
//                img.width = "150";
//                img.height = "150";
            }
            var reader = new FileReader();
            reader.onload = function (evt) {
                img.src = evt.target.result;
                document.getElementById("hidImg").value = img.src;
            }
            reader.readAsDataURL(file.files[0]);
        }
        else { //兼容IE

        }
    }
</script>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("Add Item信息", url, 2)
</script>
