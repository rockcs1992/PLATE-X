<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bottom.ascx.cs" Inherits="CommonBussiness.bottom" %>
<div class="foot_b_bg">
    <div class="foot_b wrap">
        <p><%=DAL.BaseConfigService.GetById(14)%> <a href="protocol_6.html" style="text-decoration:none; margin-left: 20px;">【Privacy Policy】</a> &amp; <a href="protocol_7.html" style="text-decoration:none;">【Terms of Use】</a></p>

        <p>Contact：<%=DAL.BaseConfigService.GetById(17) %> <a rel="nofollow" style="margin-left:20px;">Email：<%=DAL.BaseConfigService.GetById(15)%></a></p>
    </div>
</div>
<script src="js/updateview.js" type="text/javascript"></script>
