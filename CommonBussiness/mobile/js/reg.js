
//找回Password
function SetNewPass() {
    var tel = document.getElementById("tel").value;
    var password = document.getElementById("password").value;
    var code = document.getElementById("txtCode").value;
    if (tel.length == 0 || password.length == 0 || code.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    $.ajax(
	        {
	            url: "/JsData/user.aspx?action=SetNewPass&code=" + code + "&tel=" + tel + "&password=" + password + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if ($.trim(msg) == "success") {
	                    alert('Reset Successfully！');
	                    window.location.href = "login.html";
	                } else if ($.trim(msg) == "codeError") {
	                    alert('Verification Code is wrong！');
	                } else {
	                    alert('Failed to reset！');
	                }
	            }
	        }
	    );

    return false;
}
///Join
function FullShop() {
    var surname = document.getElementById("surname").value;
    var relname = document.getElementById("relname").value;
    var shoperName = document.getElementById("shoperName").value;
    var street = document.getElementById("street").value;
    var street2 = document.getElementById("street2").value;
    var city = document.getElementById("city").value;
    var province = document.getElementById("province").value;
    var email = document.getElementById("email").value;
    var remark = document.getElementById("remark").value;
    var imgUrl = document.getElementById("hidImg").value;

    var shopType = 1;
    if (document.getElementById("radShoperType_1").checked) {
        shopType = 2;
    }
    $.ajax(
	        {
	            type: 'POST',
	            url: "/JsData/user.aspx",
	            async: false,
	            data: {
	                "action": "FullShop",
	                "surname": surname,
	                "relname": relname,
	                "shoperName": shoperName,
	                "street": street,
	                "street2": street2,
	                "province": province,
	                "city": city,
	                "imgurl": imgUrl,
	                "email": email,
	                "remark": remark,
                    "shopType":shopType,
	                "time": new Date().getTime()
	            },
	            success: function (msg) {
	                if ($.trim(msg) == "success") {
	                    alert('Saved succesfully');
	                }
	                else {
	                    alert('Failed to save');
	                }

	            }
	        }
	    );

    return false;
}
///Join
function regShop() {
    var surname = document.getElementById("surname").value;
    var relname = document.getElementById("relname").value;
    var shoperName = document.getElementById("shoperName").value;
    var street = document.getElementById("street").value;

    var street2 = document.getElementById("street2").value;
    var city = document.getElementById("city").value;
    var province = document.getElementById("province").value;
    var email = document.getElementById("email").value;
    var remark = document.getElementById("remark").value;
    
    var tel = "1" + document.getElementById("tel").value;
    var password = document.getElementById("password").value;
    var code = document.getElementById("txtCode").value;
    if (tel.length == 0 || password.length == 0 || code.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    var shopType = 1;
    if (document.getElementById("radShoperType_1").checked) {
        shopType = 2;
    }
    $.ajax(
	        {
	            url: "/JsData/user.aspx?action=RegShop&street2=" + street2 + "&shopType=" + shopType + "&surname=" + surname + "&relname=" + relname + "&shoperName=" + shoperName + "&street=" + street + "&city=" + city + "&province=" + province + "&email=" + email + "&remark=" + remark + "&code=" + code + "&tel=" + tel + "&password=" + password + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if ($.trim(msg) == "success") {
	                    window.location.href = "shop_center.html";
	                } else if ($.trim(msg) == "existsMobile") {
	                    alert('Phone Exists！');
	                } else if ($.trim(msg) == "codeError") {
	                    alert('The Verification is wrong！');
	                } else {
	                    alert('Failed to join！');
	                }
	            }
	        }
	    );

    return false;
}
///Join
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
	                    window.location.href = "my_yuanxiang.html";
	                } else if ($.trim(msg) == "existsMobile") {
	                    alert(' Phone Has Already Registered！');
	                } else if ($.trim(msg) == "codeError") {
	                    alert('The Verification is wrong！');
	                } else {
	                    alert('Failed to join！');
	                }
	            }
	        }
	    );

    return false;
}

//登陆
function login(action) {
    var mobile = document.getElementById("mobile").value;
    var loginpass = document.getElementById("loginpass").value;
    if (mobile.length == 0 || loginpass.length == 0) {
        alert('The information cannot be blank！！');
        return false;
    }
    var remember = 0;
    var cboRemember = document.getElementById("cboRemember");
    if (cboRemember.checked) {
        remember = 1;
    }
    $.ajax(
	        {
	            url: "/JsData/user.aspx?action=Login&cboRemember=" + remember + "&mobile=" + mobile + "&password=" + loginpass + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if ($.trim(msg) == "success") {
	                    location.href = "my_yuanxiang.html";
	                } else {
	                    alert('Failed to login ！');
	                }
	            }
	        }
	    );


}