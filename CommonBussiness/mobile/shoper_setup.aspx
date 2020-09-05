<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoper_setup.aspx.cs" Inherits="CommonBussiness.mobile.shoper_setup" %>
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
<script src="/js/html5shiv.min.js"></script>
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
    .setup .item{padding:5px 3%;}
    </style>
</head>
<body style="background:#fbfbfb;">
<form id="form1" runat="server">
 <div class="result_top">
  <div class="top_con"> <a href="/mobile/my_yuanxiang.html" class="arrow_left"></a>
    <div class="title">My Business Center</div>
  </div>
</div>

<div class="setup">
  <div class="item" id="headUrl"><span style=" margin-right:10%; line-height:120px;vertical-align: text-bottom;">LOGO：</span><img src="images/p8.png" class="photo"/>
  <asp:FileUpload ID="filepic" runat="server"  onchange="javascript:__doPostBack('lbUploadPhoto','')" style="display:none;" />
  <asp:LinkButton ID="lbUploadPhoto" runat="server" OnClick="lbUploadPhoto_Click"></asp:LinkButton>
   </div>
    
   <asp:HiddenField ID="hidImg" runat="server" />
  <div class="item"><plateyang style=" text-align:right; width:50px; display:inline-block;">Item Name：</plateyang> <span class="info"><input type="text" id="nicheng" value="<%=ViewState["nicheng"] %>" /></span> </div>
  
  
  <div class="item"><plateyang style=" text-align:right; width:50px; display:inline-block;">Restaurant：</plateyang> <span class="info"><input type="text" id="realname" value="<%=ViewState["realname"] %>" /></span> </div>
    <div class="item"><plateyang style=" text-align:right; width:50px; display:inline-block;">邮箱：</plateyang> <span class="info"><input type="text" id="Text1" value="<%=ViewState["realname"] %>" /></span> </div>
      <div class="item"><plateyang style=" text-align:right; width:50px; display:inline-block;">电话：</plateyang> <span class="info"><input type="text" id="Text2" value="<%=ViewState["realname"] %>" /></span> </div>
      <div class="item"><plateyang style=" text-align:right; width:50px; display:inline-block;">街道：</plateyang> <span class="info"><input type="text" id="Text6" value="<%=ViewState["realname"] %>" placeholder="" /></span> </div>
      <div class="item"><plateyang style=" text-align:right; width:50px; display:inline-block;">城市：</plateyang> <span class="info"><input type="text" id="Text5" value="<%=ViewState["realname"] %>" placeholder=""  /></span> </div>
        <div class="item"><plateyang style=" text-align:right; width:50px; display:inline-block;">州：</plateyang> <span class="info"><input type="text" id="Text3" value="<%=ViewState["realname"] %>" placeholder=""  /></span> </div>
          <div class="item"><plateyang style=" text-align:right; width:50px; display:inline-block;">邮编：</plateyang> <span class="info"><input type="text" id="Text4" value="<%=ViewState["realname"] %>" /></span> </div>
<div class="item"><span style=" margin-right:1%; line-height:90px;vertical-align: text-bottom;">介绍：</span><textarea></textarea></div>

  <a onclick="return saveBase();" class="submit">提交</a>
</div>

</form>
</body>
</html>
<script type="text/javascript">
    var url = document.location.href;
    UpdateViews("My Business Center完善", url, 2)
</script>
