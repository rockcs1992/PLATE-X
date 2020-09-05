
///反馈留言
function saveMess() {
    var mess = document.getElementById("txtMess").value;
    if (mess.length == 0) {
        alert('反馈信息不能为空！');
        return false;
    }
    $.ajax({
        url: "/JsData/user.aspx?action=SaveMess&mess=" + escape(mess) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                alert("反馈成功！");
                location.href = "/mobile/feedback.html";
            }
            else {
                alert('反馈失败！');
            }

        }
    });
}


///用户搜索
function search() {
    var keyword = document.getElementById("keyword").value;
    location.href = "search_result.html?keyword=" + escape(keyword);
}


///添加地址信息,
function addAddrUser(id) {
    var action = document.getElementById("hidAction").value;
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

    if (name.length == 0 || address.length == 0 || mobile.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    if (location_p == 0 || location_c == 0 || location_a == 0) {
        alert('请选择地址！');
        return false;
    }
    if (name.length > 10) {
        alert('收货人姓名不能超过10个字符');
        return false;
    }
    if (address.length > 100) {
        alert('收货地址不能超过100个字符');
        return false;
    }
    if (labelname.length > 0) {
        if (labelname.length > 20) {
            alert('标签不能超过20个字符');
            return false;
        }
    }
    
    if (mobile.length != 11) {
        alert('收货人Phone号输入有误！');
        return false;
    }
    if (telephone.length > 0) {
        if (telephone.length != 11) {
            alert('备用Phone号输入有误！');
            return false;
        }
    }

    $.ajax({
        url: "/JsData/user.aspx?action=SaveAddr&id=" + id + "&isdefault=" + isdefault + "&location_p=" + location_p + "&location_c=" + location_c + "&location_a=" + location_a + "&mobile=" + mobile + "&telephone=" + telephone + "&name=" + escape(name) + "&address=" + escape(address) + "&labelname=" + escape(labelname) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                if (action == "sel") {
                    location.href = "order_address.html";
                }
                else { 
                    location.href = "manage_address.html";
                }
                
            }
            else {
                alert('Failed to save');
            }

        }
    });
}
///添加地址信息,
function addAddrUser1(id) {
    var action = document.getElementById("hidAction").value;
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

    if (name.length == 0 || address.length == 0 || mobile.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    if (location_p == 0 || location_c == 0 || location_a == 0) {
        alert('请选择地址！');
        return false;
    }
    if (name.length > 10) {
        alert('收货人姓名不能超过10个字符');
        return false;
    }
    if (address.length > 100) {
        alert('收货地址不能超过100个字符');
        return false;
    }
    if (labelname.length > 0) {
        if (labelname.length > 20) {
            alert('标签不能超过20个字符');
            return false;
        }
    }

    if (mobile.length != 11) {
        alert('收货人Phone号输入有误！');
        return false;
    }
    if (telephone.length > 0) {
        if (telephone.length != 11) {
            alert('备用Phone号输入有误！');
            return false;
        }
    }
    console.log(111);
    
    $.ajax({
        url: "/JsData/user.aspx?action=SaveAddr1&id=" + id + "&isdefault=" + isdefault + "&location_p=" + location_p + "&location_c=" + location_c + "&location_a=" + location_a + "&mobile=" + mobile + "&telephone=" + telephone + "&name=" + escape(name) + "&address=" + escape(address) + "&labelname=" + escape(labelname) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                if (action == "sel") {
                    location.href = "order_address.html";
                }
                else {
                    location.href = "order_address.html";
                }

            }
            else {
                alert('Failed to save');
            }

        }
    });
}


///添加地址信息,
function addAddrOrder(ids) {
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

///回复信息验证
function saveBase() {
    var surname = document.getElementById("surname").value;
    var realname = document.getElementById("realname").value;
    var year = document.getElementById("ddlYear").value;
    var month = document.getElementById("ddlMonth").value;
    var day = document.getElementById("ddlDay").value;
    var street = document.getElementById("street").value;
    var city = document.getElementById("city").value;
    var province = document.getElementById("province").value;

    var imgurl = document.getElementById("hidImg").value;

    var sex = 1;
    var man = document.getElementById("man");
    if (man.checked) {
        sex = 2;
    }
    var secret = document.getElementById("secret");
    if (secret.checked) {
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
                    location.href = "/mobile/manage_address.html";
                }
                else {
                    alert('Failed to Delete');
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

//    document.getElementById("location_p2").value = qq;
//    document.getElementById("location_c2").value = weixin;
//    document.getElementById("location_a2").value = zipcode;

    document.getElementById("m_address").value = address;
    document.getElementById("m_labelname").value = addressDetail;

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
