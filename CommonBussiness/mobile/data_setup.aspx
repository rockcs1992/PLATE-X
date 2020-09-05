<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="data_setup.aspx.cs" Inherits="CommonBussiness.mobile.data_setup" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc1" %>
<!doctype html>
<html style=" background:#fbfbfb;">
<head>
<%--<meta charset="utf-8">--%>
<meta content="initial-scale=1.0,user-scalable=no,maximum-scale=1,width=device-width" name="viewport" />
<meta content="yes" name="apple-mobile-web-app-capable" />
<meta content="black" name="apple-mobile-web-app-status-bar-style"/>
<meta content="telephone=no" name="format-detection" />

 <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no, minimal-ui" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="format-detection" content="telephone=no, email=no" />


<title><%= ViewState["title"] %></title>
    <meta name="keywords" content="<%= ViewState["keyword"] %>" />
    <meta name="description" content="<%= ViewState["miaoshu"] %>" /> 
<%--<link rel="stylesheet" href="css/base.css"/>--%>
<link rel="stylesheet" href="css/content.css"/>
<script src="js/jquery.js"></script>
<script type="text/javascript" src="js/slider.js"></script>
<script type="text/javascript" src="js/lazyload.js"></script>
<script src="js/index.js"></script>
<script src="js/user.js" type="text/javascript"></script>
<script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

<script type="text/javascript">
    function rotate(obj, arr) {
        var img = document.getElementById(obj);
        if (!img || !arr) return false;
        var n = img.getAttribute('step');
        if (n == null) n = 0;
        if (arr == 'left') {
            (n == 0) ? n = 3 : n--;
        } else if (arr == 'right') {
            (n == 3) ? n = 0 : n++;
        }
        img.setAttribute('step', n);
        //对IE浏览器使用滤镜旋转
        if (document.all) {
            img.style.filter = 'progid:DXImageTransform.Microsoft.BasicImage(rotation=' + n + ')';
            //HACK FOR MSIE 8
            switch (n) {
                case 0:
                    img.parentNode.style.height = img.height;
                    break;
                case 1:
                    img.parentNode.style.height = img.width;
                    break;
                case 2:
                    img.parentNode.style.height = img.height;
                    break;
                case 3:
                    img.parentNode.style.height = img.width;
                    break;
            }
            // 对现代浏览器写入HTML5的$素进行旋转： canvas
        } else {
            var c = document.getElementById('canvas_' + obj);
            if (c == null) {
                img.style.visibility = 'hidden';
                img.style.position = 'absolute';
                c = document.createElement('canvas');
                c.setAttribute("id", 'canvas_' + obj);
                img.parentNode.appendChild(c);
            }
            var canvasContext = c.getContext('2d');
            switch (n) {
                default:
                case 0:
                    c.setAttribute('width', img.width);
                    c.setAttribute('height', img.height);
                    canvasContext.rotate(0 * Math.PI / 180);
                    canvasContext.drawImage(img, 0, 0);
                    break;
                case 1:
                    c.setAttribute('width', img.height);
                    c.setAttribute('height', img.width);
                    canvasContext.rotate(90 * Math.PI / 180);
                    canvasContext.drawImage(img, 0, -img.height);
                    break;
                case 2:
                    c.setAttribute('width', img.width);
                    c.setAttribute('height', img.height);
                    canvasContext.rotate(180 * Math.PI / 180);
                    canvasContext.drawImage(img, -img.width, -img.height);
                    break;
                case 3:
                    c.setAttribute('width', img.height);
                    c.setAttribute('height', img.width);
                    canvasContext.rotate(270 * Math.PI / 180);
                    canvasContext.drawImage(img, -img.width, 0);
                    break;
            };
        }
    }
</script>

   <style>
    #clipArea {
        margin: 20px;
        height: 300px;
    }
    #file,
    #clipBtn {
        margin: 20px;
    }
    #view {
        margin: 0 auto;
        width: 200px;
        height: 200px;
    }
    .setup .item input{ width:60%}
    .setup .item select{ width:19.5%;}
    </style>
</head>
<body style="background:#fbfbfb;">
<form id="form1" runat="server">
 <div class="result_top">
  <div class="top_con"> <a href="/mobile/my_yuanxiang.html" class="arrow_left"></a>
    <div class="title">Your Account</div>
  </div>
</div>

<div class="setup"><asp:FileUpload ID="filepic" runat="server"  onchange="showImage(this,'headImgId');" style="display:none;" />
  <div class="item" id="headUrl" ><span style=" margin-right:10%; line-height:120px;vertical-align: text-bottom;">Upload Faces：</span>
  <platex id="headImgId" onclick="document.getElementById('filepic').click();"><img src="<%=ViewState["headImg"] %>" class="photo" /></platex>  
   </div>
   <asp:HiddenField ID="hidImg" runat="server" />
   <div class="item"><span style=" width:100px;display: inline-block;">Phone： </span></span><span class="info"><input type="text" id="mobile" value="<%=ViewState["mobile"] %>" readonly="readonly" /></span> </div>
 
  <div class="item"><span style=" width:100px;display: inline-block;">First Name： </span><span class="info"><input type="text" id="realname" value="<%=ViewState["realname"] %>" /></span> </div>
   <div class="item"><span style=" width:100px;display: inline-block;">Last Name： </span><span class="info"><input type="text" id="surname" value="<%=ViewState["surname"] %>" /></span> </div>
  <div class="item"><span style=" width:100px;display: inline-block;height: 100px;float: left;">Sex： </span><span class="info"><%=GetSexInfo() %>  
  </span> </div>
  <div class="item"><span style=" width:100px;display: inline-block;">Birthday： </span><span class="info">
      <asp:DropDownList ID="ddlYear" runat="server">
      </asp:DropDownList> <asp:DropDownList ID="ddlMonth" runat="server">
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem Value="3">3</asp:ListItem>
        <asp:ListItem Value="4">4</asp:ListItem>
        <asp:ListItem Value="5">5</asp:ListItem>
        <asp:ListItem Value="6">6</asp:ListItem>
        <asp:ListItem Value="7">7</asp:ListItem>
        <asp:ListItem Value="8">8</asp:ListItem>
        <asp:ListItem Value="9">9</asp:ListItem>
        <asp:ListItem Value="10">10</asp:ListItem>
        <asp:ListItem Value="11">11</asp:ListItem>
        <asp:ListItem Value="12">12</asp:ListItem>
      </asp:DropDownList> <asp:DropDownList ID="ddlDay" runat="server">      
      </asp:DropDownList> 
  </span> </div>
  
  <div class="item"><span style=" width:100px;display: inline-block;">Street1： </span><span class="info"><input type="text" id="street" value="<%=ViewState["street"] %>" /></span> </div>
  <div class="item"><span style=" width:100px;display: inline-block;">Street2： </span><span class="info"><input type="text" id="street2" value="<%=ViewState["street2"] %>" /></span> </div>
<div class="item"><span style=" width:100px;display: inline-block;">City： </span><span class="info"><input type="text" id="city" value="<%=ViewState["city"] %>" /></span> </div>
<div class="item"><span style=" width:100px;display: inline-block;">State： </span><span class="info"><input type="text" id="province" value="<%=ViewState["province"] %>" /></span> </div>

  <a onclick="return saveBase();" class="submit">Save</a>
</div>

</form>
</body>
</html>
<script type="text/javascript">
    function showImage(file, id) {
        var ext = file.value.toLowerCase().split('.').splice(-1);
        var div = document.getElementById(id);
        if (file.files && file.files[0]) {
            div.innerHTML = "<img id='img_" + id + "' class='photo' >";
            var img = document.getElementById("img_" + id);
            img.onload = function () {
                img.width = "100";
                img.height = "100";
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
    UpdateViews("Your Account设置", url, 2)
</script>
