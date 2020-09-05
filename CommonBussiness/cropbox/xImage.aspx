﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xImage.aspx.cs" Inherits="CommonBussiness.cropbox.xImage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>jQuery头像裁剪插件cropbox</title>

<link rel="stylesheet" href="css/style.css" type="text/css" />

</head>
<body>

<script type="text/javascript" src="js/jquery-1.11.1.min.js"></script>
<script type="text/javascript" src="js/cropbox.js"></script>

<div class="container">
    <div class="imageBox">
        <div class="thumbBox"></div>
        <div class="spinner" style="display: none">Loading...</div>
    </div>
	
    <div class="action">
        <input type="file" id="file" style="float:left; width: 250px">
        <input type="button" id="btnCrop" value="Crop" style="float: right">
        <input type="button" id="btnZoomIn" value="+" style="float: right">
        <input type="button" id="btnZoomOut" value="-" style="float: right">
    </div>
	
    <div class="cropped"></div>
	
</div>

<script type="text/javascript">
    $(window).load(function () {
        var options =
	{
	    thumbBox: '.thumbBox',
	    spinner: '.spinner',
	    imgSrc: 'images/avatar.png'
	}
        var cropper = $('.imageBox').cropbox(options);
        $('#file').on('change', function () {
            var reader = new FileReader();
            reader.onload = function (e) {
                options.imgSrc = e.target.result;
                cropper = $('.imageBox').cropbox(options);
            }
            reader.readAsDataURL(this.files[0]);
            this.files = [];
        })
        $('#btnCrop').on('click', function () {
            var img = cropper.getDataURL();
            $('.cropped').append('<img src="' + img + '">');
        })
        $('#btnZoomIn').on('click', function () {
            cropper.zoomIn();
        })
        $('#btnZoomOut').on('click', function () {
            cropper.zoomOut();
        })
    });
</script>
<div style="text-align:center;">
<p>来源:<a href="http://www.mycodes.net/" target="_blank">源码之家</a></p>
</div>
</body>
</html>