
///SaveItems
function saveProduct() {
    var imgurl = document.getElementById("hidImg").value;
    var proType = document.getElementById("ddlProductType").value;
    var proname = document.getElementById("proname").value;
    var storeCount = document.getElementById("storeCount").value;

    var unit1 = document.getElementById("unit1").value;
    var price1 = document.getElementById("price1").value;
    var infoDesc = document.getElementById("infoDesc").value;

    var hidId = document.getElementById("hidId").value;

    $.ajax({
        type: 'POST',
        url: "/JsData/user.aspx",
        async: false,
        data: {
            "action": "SaveProduct",

            "proType": proType,
            "proname": proname,
            "storeCount": storeCount,

            "unit1": unit1,
            "price1": price1,
            "infoDesc": infoDesc,
            "hidId": hidId,
            "imgurl": imgurl,
            "time": new Date().getTime()
        },
        success: function (msg) {
            if ($.trim(msg) == "success") {
                location.href = "/shoper_product.html";
            }
            else {
                alert('Save Fail');
            }

        }
    });

}


///商户完善信息
function saveBaseShop() {
    //alert("aaaaaaaaaa");
    var sex = 1;
    var sexValue = document.getElementById("sexValue").value;
    if (sexValue == "man") {
        sex = 2;
    }
    var surname = document.getElementById("surname").value;
    var realname = document.getElementById("realname").value;

    var shopName = document.getElementById("shopName").value;
    var email = document.getElementById("email").value;
    var remark = document.getElementById("remark").value;

    var street = document.getElementById("street").value;
    var street2 = document.getElementById("street2").value;
    var city = document.getElementById("city").value;
    var province = document.getElementById("province").value;

    var imgurl = document.getElementById("hidImg").value;

    
   
    $.ajax({
        type: 'POST',
        url: "/JsData/user.aspx",
        async: false,
        data: {
            "action": "SaveBaseShop",
            "shopName": shopName,
            "email": email,
            "remark": remark,
            "sex": sex,
            "realname": realname,
            "surname": surname,
            "street": street,
            "street2": street2,

            "province": province,
            "city": city,
            "imgurl": imgurl,
            "time": new Date().getTime()
        },
        success: function (msg) {
            if ($.trim(msg) == "success") {
                alert('Save successfully');
            }
            else {
                alert(' Failed to save');
            }

        }
    });
}

///添加地址信息,
function addAddrNew() {
    var location_p = document.getElementById("location_p").value;
    var location_c = document.getElementById("location_c").value;
    var location_a = document.getElementById("location_a").value;

    var name = document.getElementById("name").value;
    var address = document.getElementById("address").value;

    var isdefault = 1;
    var labelname = document.getElementById("labelname").value;
    var mobile = document.getElementById("mobile").value;
    var telephone = document.getElementById("telephone").value;

    if (name.length == 0 || address.length == 0 || labelname.length == 0 || mobile.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    $.ajax({
        url: "/JsData/user.aspx?action=SaveAddrNew&isdefault=" + isdefault + "&location_p=" + location_p + "&location_c=" + location_c + "&location_a=" + location_a + "&mobile=" + mobile + "&telephone=" + telephone + "&name=" + escape(name) + "&address=" + escape(address) + "&labelname=" + escape(labelname) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg).indexOf("success") != -1) {
                alert('Saved succesfully！');
                var arr = msg.split('_');
                document.getElementById("hidAddr").value = arr[1];
            }
            else {
                alert('Failed to save');
            }

        }
    });
    return false;
}

//获取编辑三级地区信息
function getArea33(weixin,zipcode) {
    $.ajax({
        url: "/JsData/user.aspx?action=GetArea33&p=" + weixin + "&zipcode=" + zipcode + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            $("#location_a2").html(msg);
        }
    });
}

//获取编辑二级地区信息
function getArea22(weixin) {
    var location_p = document.getElementById("location_p2").value;
    $.ajax({
        url: "/JsData/user.aspx?action=GetArea22&p=" + location_p + "&cur=" + weixin + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            $("#location_c2").html(msg);
        }
    });
}


//获取二级地区信息
function getArea3() {
    var location_c = document.getElementById("location_c").value;
    $.ajax({
        url: "/JsData/user.aspx?action=GetArea3&p=" + location_c + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            $("#location_a").html(msg);
        }
    });
}


//获取二级地区信息
function getArea2() {
    var location_p = document.getElementById("location_p").value;

    $.ajax({
        url: "/JsData/user.aspx?action=GetArea2&p=" + location_p + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            $("#location_c").html(msg);
        }
    });
}


///添加地址信息,
function addAddrUser() {
    var location_p = document.getElementById("location_p").value;
    var location_c = document.getElementById("location_c").value;
    var location_a = document.getElementById("location_a").value;

    var name = document.getElementById("name").value;
    var address = document.getElementById("address").value;

    var isdefault = 0;
    var cbo = document.getElementById("cboDefault");
    if (cbo.checked) {
        isdefault = 1;
    }
    var labelname = document.getElementById("labelname").value;
    var mobile = document.getElementById("mobile").value;
    var telephone = document.getElementById("telephone").value;

    if (name.length == 0 || address.length == 0 || labelname.length == 0 || mobile.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    $.ajax({
        url: "/JsData/user.aspx?action=SaveAddr&isdefault=" + isdefault + "&location_p=" + location_p + "&location_c=" + location_c + "&location_a=" + location_a + "&mobile=" + mobile + "&telephone=" + telephone + "&name=" + escape(name) + "&address=" + escape(address) + "&labelname=" + escape(labelname) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                location.href = "/my_address.html";
            }
            else {
                alert('Failed to save');
            }

        }
    });
}

///添加地址信息,
function addAddrOrder() {
    var location_p = document.getElementById("location_p").value;
    var location_c = document.getElementById("location_c").value;
    var location_a = document.getElementById("location_a").value;

    var name = document.getElementById("name").value;
    var address = document.getElementById("address").value;

    var isdefault = 0;
    var cbo = document.getElementById("cboDefault");
    if (cbo.checked) {
        isdefault = 1;
    }
    var labelname = document.getElementById("labelname").value;
    var mobile = document.getElementById("mobile").value;
    var telephone = document.getElementById("telephone").value;

    if (name.length == 0 || address.length == 0 || labelname.length == 0 || mobile.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    $.ajax({
        url: "/JsData/user.aspx?action=SaveAddr&isdefault=" + isdefault + "&location_p=" + location_p + "&location_c=" + location_c + "&location_a=" + location_a + "&mobile=" + mobile + "&telephone=" + telephone + "&name=" + escape(name) + "&address=" + escape(address) + "&labelname=" + escape(labelname) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                location.href = "/jiesuan1.html?ids=" + ids;
            }
            else {
                alert('Failed to save');
            }

        }
    });
}

///回复信息验证
function modpass() {
    var oldp = document.getElementById("oldp").value;
    var newp = document.getElementById("newp").value;
    var newp2 = document.getElementById("newp2").value;
    if (oldp.length == 0 || newp.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    if (newp != newp2) {
        alert('The new password must be the same！');
        return false;
    }
    if (newp.length < 6) {
        alert('The password must exceed six characters！');
        return false;
    }
    $.ajax({
        url: "/JsData/user.aspx?action=ModPass&oldp=" + oldp + "&newp=" + newp + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                alert('Changed successfully');
            } else if ($.trim(msg) == "error") {
                alert(' The old password is wrong！');
            }
            else {
                alert('Failed to change password');
            }

        }
    });
    return false;
}

///回复信息验证
function saveBase() {
    var surname = document.getElementById("surname").value;
    var realname = document.getElementById("realname").value;
    var year = document.getElementById("ddlYear").value;
    var month = document.getElementById("ddlMonth").value;
    var day = document.getElementById("ddlDay").value;
    var street = document.getElementById("street").value;
    var street2 = document.getElementById("street2").value;
    var city = document.getElementById("city").value;
    var province = document.getElementById("province").value;

    var imgurl = document.getElementById("hidImg").value;

    var sex = 1;
    var sexValue = document.getElementById("sexValue").value;
    if (sexValue == "man") {
        sex = 2;
    }
    if (sexValue == "secret") {
        sex = 3;
    }
    $.ajax({
        type: 'POST',
        url: "/JsData/user.aspx",
        async: false,
        data: {
            "action": "SaveBase",
            "birthday": (year + "-" + month + "-" + day),
            "sex": sex,
            "realname": realname,
            "surname": surname,
            "street": street,
            "street2": street2,
            "province": province,
            "city": city,
            "imgurl": imgurl,
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
    });
}
///添加地址信息,
function addAddr(ids) {
    var location_p = document.getElementById("location_p").value;
    var location_c = document.getElementById("location_c").value;
    var location_a = document.getElementById("location_a").value;

    var name = document.getElementById("name").value;
    var address = document.getElementById("address").value;

    var isdefault = 0;
    var cbo = document.getElementById("cboDefault");
    if (cbo.checked) {
        isdefault = 1;
    }
    var labelname = document.getElementById("labelname").value;
    var mobile = document.getElementById("mobile").value;
    var telephone = document.getElementById("telephone").value;

    if (name.length == 0 || address.length == 0 || labelname.length == 0 || mobile.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    $.ajax({
        url: "/JsData/user.aspx?action=SaveAddr&isdefault=" + isdefault + "&location_p=" + location_p + "&location_c=" + location_c + "&location_a=" + location_a + "&mobile=" + mobile + "&telephone=" + telephone + "&name=" + escape(name) + "&address=" + escape(address) + "&labelname=" + escape(labelname) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                location.href = "/jisuan1.html?ids=" + ids;
            }
            else {
                alert('Failed to save');
            }

        }
    });
}

///添加地址信息,
function delAddress(id) {
    if (confirm("Are you sure you want to delete?")) {
        $.ajax({
            url: "/JsData/user.aspx?action=DelAddr&id=" + id + "&time=" + new Date().getTime() + "",
            type: 'GET',
            success: function (msg) {
                if ($.trim(msg) == "success") {
                    // alert('Delete成功');
                    location.href = "/my_address.html";
                }
                else {
                    alert('Failed To Delete');
                }

            }
        });
    }
}
function setHidId(infoType,id, relName, mobile, tel, qq, weixin, zipcode, address, addressDetail) {
    // alert(address);
    if (infoType == 1) {
        document.getElementById("cboModDefault").checked = true;        
    }
    document.getElementById("hidId").value = id.toString();
    document.getElementById("m_name").value = relName;

    document.getElementById("m_mobile").value = mobile;
    document.getElementById("m_telephone").value = tel;

    document.getElementById("m_address").value = address;
    document.getElementById("m_labelname").value = addressDetail;

    document.getElementById("location_p2").value = qq;
    getArea22(weixin);
    getArea33(weixin,zipcode);
//    document.getElementById("location_c2").value = weixin;
//    document.getElementById("location_a2").value = zipcode;

    

}

///添加地址信息,
function modAddr() {
    var hidId = document.getElementById("hidId").value;
    var location_p = document.getElementById("location_p2").value;
    var location_c = document.getElementById("location_c2").value;
    var location_a = document.getElementById("location_a2").value;

    var name = document.getElementById("m_name").value;
    var address = document.getElementById("m_address").value;

    var labelname = document.getElementById("m_labelname").value;
    var mobile = document.getElementById("m_mobile").value;
    var telephone = document.getElementById("m_telephone").value;
    var isdefault = 0;
    var cbo = document.getElementById("cboModDefault");
    if (cbo.checked) {
        isdefault = 1;
    }
    if (name.length == 0 || address.length == 0 || labelname.length == 0 || mobile.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    $.ajax({
        url: "/JsData/user.aspx?action=ModAddr&isdefault=" + isdefault + "&hidId=" + hidId + "&location_p=" + location_p + "&location_c=" + location_c + "&location_a=" + location_a + "&mobile=" + mobile + "&telephone=" + telephone + "&name=" + escape(name) + "&address=" + escape(address) + "&labelname=" + escape(labelname) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                alert('Saved succesfully');
                location.href = "/my_address.html";
            }
            else {
                alert('Failed to save');
            }

        }
    });
}
