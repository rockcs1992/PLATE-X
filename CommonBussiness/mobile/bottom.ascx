<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bottom.ascx.cs" Inherits="CommonBussiness.mobile.bottom" %>
<div class="foot">
  <ul class="clearfix">
    <li class="<%=GetClass(1) %>"><a href="/mobile/index.html"><b class="foot_icon1"></b><span>Home</span></a></li>
    <li class="<%=GetClass(2) %>"><a href="classify_details_1_0_0_0_0_0_0.html"><b class="foot_icon2"></b><span>Categories</span></a></li>
    <li class="<%=GetClass(3) %>"><a href="join.html"><b class="foot_icon3"></b><span>Join Us</span></a></li>
    <li class="<%=GetClass(4) %>"><a href="car.html"><b class="foot_icon4"></b><span>Cart</span><%=GetCarTotal() %></a></li>
    <li class="<%=GetClass(5) %>"><a href="<%=GetUrl() %>"><b class="foot_icon5"></b><span>Account</span></a></li>
  </ul>
</div>
<script type="text/javascript">
    ///更新浏览
    function UpdateViews(pageName, pageValue, typeId) {
        $.ajax(
	    {
	        type: 'POST',
	        url: "/jsData/common.aspx",
	        data: { action: "UpdateView", pageName: pageName, pageValue: pageValue, typeId: typeId },
	        success: function () {

	        }
	    }
	    );
    }

</script>