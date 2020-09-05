// JavaScript Document
$(document).ready(function(e) {
	//懒加载
   $('.lazyImg').lazyload({
		effect : 'fadeIn'
	 });
	 //显示Total Price
	 
	     function setTotal(){
				var s=0;
				$(".orderInfo ul li").each(function(){
				s+=parseInt($(this).find('.num').val())*parseFloat($(this).find('.unit_price').text());
				});
				$("#totalPrice").html(s.toFixed(2));
				}
				setTotal();
	 
	 
	 $(".product .proList li .quantity .num").each(function(index, element) {
         var inputVal = $(this).val();
		 if(inputVal==0){
		   $(this).hide();
		   $(this).prev(".decrease").hide();
		 }
		 if(inputVal > 0){
		  $(this).parents("li").addClass("kind"); 
	       var inputnumber = $(".kind").length;
	       
		   $(".foot .kinds .kindsNum").text(inputnumber);
		 }
		 
    }); 
	  $(".orderInfo ul li .quantity .num").each(function(index, element) {
         var inputVal = $(this).val();
		 if(inputVal==0){
		   $(this).hide();
		   $(this).prev(".decrease").hide();
		 }
	    $(this).siblings(".con").find(".s_num").text(inputVal);
		 
    }); 
	  
	 
	//计算Quantity
	 $(".increase").click(function(){
	    var totalPrice= 0.00;	
		var input = $(this).parents(".quantity").find("input");
		var val =input.val();
		val++;
		input.val(val);
	   $(this).parent().siblings(".con").find(".s_num").text(val);
	   if(input.val() >0){
		 $(this).parents("li").find(".decrease").show();
		 input.show();
		 $(this).parents("li").addClass("kind"); 
	     var inputnumber = $(".kind").length;
	   
		 $(".foot .kinds .kindsNum").text(inputnumber);		  
		}	
		//Total Price
		    setTotal();
			  
			 
	   });
	 $(".decrease").click(function(){
		var input = $(this).parents(".quantity").find("input");
		var val =input.val();
		if(val>0){ 
		   val--;
		   $(this).parent().siblings(".con").find(".s_num").text(val);
    	}    
		input.val(val);	
	    if(input.val() == 0){
		  $(this).parents("li").find(".decrease").hide();
		 input.hide();
		 $(this).parents("li").removeClass("kind"); 
	     var inputnumber = $(".kind").length;
	    
		 $(".foot .kinds .kindsNum").text(inputnumber);
		 
		 
		}
	     setTotal(); 
			
	 });	
	
	//地址选择样式切换
	$(".receiving ul li .info").click(function(){
		$(this).find(".choiceBtn").addClass("active").parents().siblings("").find(".choiceBtn").removeClass("active");
		});
	 
});