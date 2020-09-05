// JavaScript Document
var isOpen = 0;
function center(obj) {
	var screenWidth = $(window).width(), screenHeigth = $(window).height();
	var scollTop = $(document).scrollTop();
	var objLeft = (screenWidth - obj.width()) / 2;
	var objTop = (screenHeigth - obj.height()) / 2 + scollTop;
	obj.css({
		left:objLeft + "px",
		top:objTop + "px"
	});
	obj.fadeIn(500);
	isOpen = 1;
}

//close
$(function(){
	$(".layerbox .layerclose").click(function(){
		$(this).parents(".layerbox").fadeOut(300);
		$("#layermask").fadeOut(300);
		isOpen = 0;
	});
	$(".layerbox .cancle").click(function(){
		$(this).parents(".layerbox").fadeOut(300);
		$("#layermask").fadeOut(300);
		isOpen = 0;
	});
});