
///注册
function reg() {
    var tel = document.getElementById("tel").value;
    var password = document.getElementById("password").value;
    var code = document.getElementById("txtCode").value;
    if (tel.length == 0 || password.length == 0 || code.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    $.ajax(
	        {
	            url: "/JsData/user.aspx?action=Reg&code=" + code + "&tel=" + tel + "&password=" + password + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if ($.trim(msg) == "success") {
	                    window.location.href = "/my_person.html";
	                } else if ($.trim(msg) == "existsMobile") {
	                    alert('Phone Has Already Registered！');
	                } else if ($.trim(msg) == "codeError") {
	                    alert('Verification is wrong！');
	                } else {
	                    alert('Failed to Join！');
	                }
	            }
	        }
	    );

    return false;
}

///登录
function login() {
    var mobile = document.getElementById("mobile").value;
    var loginpass = document.getElementById("loginpass").value;
    if (mobile.length == 0 || loginpass.length == 0) {
        alert('The information cannot be blank！');
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
	                    alert('Failed To Login！');
	                }
	            }
	        }
	    );


}