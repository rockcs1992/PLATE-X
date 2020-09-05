



$(function () {
    // JavaScript Document
    $(document).ready(function () {


        //创建一个*
        $(".a1").each(function () {

            var hdw = $("<strong class='reda'></strong>");

            $(this).parent().append(hdw);

        });
        //end


        $("form :input").blur(function () {

            $(this).parent().find(".a2").remove();


            //判断        
            if ($(this).is("#password")) {

                if (this.value == "" || this.value.length < 6 || this.value.length > 12) {

                    var hdw1 = $("<span class='a2 error'>The password must exceed six characters</span>");

                    $(this).parent().append(hdw1);

                } else {

                    var hdw1 = $("<span class='a2 righta'>correct</span>");

                    $(this).parent().append(hdw1);
                }

            }
            //end

            //判断        
            if ($(this).is("#passwords")) {

                if (this.value == "" || this.value != $("#password").val()) {

                    var hdw1 = $("<span class='a2 error'>The new password must be the same</span>");

                    $(this).parent().append(hdw1);

                } else {

                    var hdw1 = $("<span class='a2 righta'>correct</span>");

                    $(this).parent().append(hdw1);
                }

            }
            //end   



            //判断        
            if ($(this).is("#tel")) {

                if (this.value == "" || this.value.length != 10) {

                    var hdw1 = $("<span class='a2 error'>Phone is Error</span>");

                    $(this).parent().append(hdw1);

                } else {

                    var hdw1 = $("<span class='a2 righta'>correct</span>");

                    $(this).parent().append(hdw1);
                }

            }
            //end

            //判断        
            if ($(this).is("#username")) {
                if (this.value == "") {
                    var hdw1 = $("<span class='a2 error'>Verification Code is Error，Try Again！</span>");
                    $(this).parent().append(hdw1);
                } else {
                    getCode(this.value);
                }

            }
            //end

            //判断        
            /*if ($(this).is("#telusername")){
                
            if (this.value==""){
                    
            var hdw1 = $("<span class='a2 error'>Image Verification Code不得为空</span>");
                    
            $(this).parent().append(hdw1);
                    
            }

            }*/
            //end

        });
        //blur  end


        //提交
        $("#send").click(function () {

            $("form :input").trigger("blur");
            var hdw3 = $(".error").length;

            if (hdw3) {

                return false;

            }
            return reg();
            //alert("Join成功");

        });
        //end 
    });


    $('.telYzm').click(function () {
        $(this).html("Sended");
    });
    $('.telYzm2').click(function () {
        $(this).html("Sended");
    });


});

function getCode(obj) {
    $.ajax(
	        {
	            url: "/JsData/user.aspx?action=GetCode&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if ($.trim(msg) != "") {
	                    code = $.trim(msg);
	                    if (code != obj) {
	                        var hdw1 = $("<span class='a2 error'>Verification Code is Error，Try Again！</span>");
	                        $(("#username")).parent().append(hdw1);
	                       // alert("error");
	                    } else {
	                       // alert("right");
	                        var hdw1 = $("<span class='a2 righta'>correct</span>");
	                        $(("#username")).parent().append(hdw1);
	                    }

	                }
	            }
	        }
	    );
	    }
//	    function reg() {
//	        var tel = document.getElementById("tel").value;
//	        var password = document.getElementById("password").value;
//	        var code = document.getElementById("txtCode").value;
//	        if (tel.length == 0 || password.length == 0 || code.length == 0) {
//	            alert('The information cannot be blank！');
//	            return false;
//            }
//	        $.ajax(
//	        {
//	            url: "/JsData/user.aspx?action=Reg&code=" + code + "&tel=" + tel + "&password=" + password + "&t=" + new Date().getTime() + "",
//	            type: 'GET',
//	            success: function (msg) {
//	                if ($.trim(msg) == "success") {
//	                    window.location.href = "/my_person.html";
//	                } else if ($.trim(msg) == "existsMobile") {
//	                    alert('该用户已Join！');
//	                } else if ($.trim(msg) == "codeError") {
//	                    alert('PhoneImage Verification Code错误！');
//	                } else {
//	                    alert('Join失败！');
//	                }
//	            }
//	        }
//	    );

//	        return false;
//	    }

	   
	    function checkMobile() {
	        var tel = document.getElementById("tel").value;
	        if (tel.length != 11) {
	            alert('Phone is Error！');
	            return false;
	        }
            $.ajax(
	        {
	            url: "/JsData/user.aspx?action=Login&mobile=" + mobile + "&password=" + loginpass + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if ($.trim(msg) == "success") {
	                    location.href = "/my_person.html";
	                } else if ($.trim(msg) == "noexists") {
	                    alert('Phone does not exist！');
	                } else {
	                    alert('Failed To Login ！');
	                }
	            }
	        }
	    );


	    }
