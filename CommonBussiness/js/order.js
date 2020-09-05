



///PC端立即购买下单
function saveOrderPCRightNow1() {
    var sendDate = document.getElementById("choice").value;
    var hidAddrId = document.getElementById("hidAddrId").value;
    var hidTicketUse = document.getElementById("hidTicketUse").value;
    var hidCardUse = document.getElementById("hidCardUse").value;
    var hidScoreUse = document.getElementById("hidScoreUse").value;
    var hidBalanceUse = document.getElementById("hidBalanceUse").value;
    var orderTotal = document.getElementById("factTotal").value * 1;
    var zhekou = $("#zhekou").html().replace("¥", "").replace("-", "") * 1;
    $.ajax({
        url: "/JsData/order.aspx?action=SaveOrderPCRightNow1&hidAddrId=" + hidAddrId + "&orderTotal=" + orderTotal + "&zhekou=" + zhekou + "&hidBalanceUse=" + hidBalanceUse + "&hidScoreUse=" + hidScoreUse + "&hidCardUse=" + hidCardUse + "&hidTicketUse=" + hidTicketUse + "&sendDate=" + sendDate + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "nologin") {                
                location.href = "/register.html";
            } else {
                if (orderTotal != 0) {
                    location.href = "/zhifu_" + msg + ".html";
                }
                else {
                    location.href = "/orders_1.html";
                }

            }

        }
    });
}



///回复信息验证
function rightnow(id) {
    var procount = document.getElementById("procount").value;
    var priceItem = document.getElementById("priceItem").value;
    $.ajax({
        url: "/JsData/order.aspx?action=RightNow&priceItem=" + priceItem + "&procount=" + procount + "&id=" + id + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                location.href = "/jiesuan1.html?ids=" + id + "_" + procount + ",";
            } else if ($.trim(msg) == "noAddr") {
                location.href = "/jiesuan.html?ids=" + id + "_" + procount;
            } else if ($.trim(msg) == "nologin") {
                location.href = "/register.html";
            } else {
                ////////////////////// alert('Add To Cart失败');
            }

        }
    });
}

///回复信息验证
function saveOrder(ids) {
    var hidAddrId = document.getElementById("hidAddrId").value;
    $.ajax({
        url: "/JsData/order.aspx?action=SaveOrder&ids=" + ids + "&hidAddrId=" + hidAddrId + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                location.href = "/orders_0.html";
            } else if ($.trim(msg) == "nologin") {
                location.href = "/register.html";
            } else {
                alert('Faild To Cancel Order');
            }

        }
    });
}


 ///回复信息验证
function addToCart(id) {
    var procount = document.getElementById("procount").value;
    var priceItem = document.getElementById("priceItem").value;
    $.ajax({
        url: "/JsData/order.aspx?action=AddCart&priceItem=" + priceItem + "&procount=" + procount + "&id=" + id + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                location.href = "/shopping.html";
            }else if($.trim(msg) == "nologin"){                
                location.href="/register.html";
            }else {
                alert('Failed To Add Cart');
            }

        }
    });
}
function delCartTemp(id) {
    if (confirm("Are you sure you want to delete?")) {
        $.ajax({
            url: "/JsData/order.aspx?action=DelCartTemp&id=" + id + "&time=" + new Date().getTime() + "",
            type: 'GET',
            success: function (msg) {
                if ($.trim(msg) == "success") {
                    location.href = "/shopping.html";
                } else {
                    alert('Failed To Delete');
                }

            }
        });
    }
}

function saveOrder(orderId) {
    var location_p = document.getElementById("location_p").value;
    var location_c = document.getElementById("location_c").value;
    var location_a = document.getElementById("location_a").value;

    var name = document.getElementById("name").value;
    var address = document.getElementById("address").value;

    var labelname = document.getElementById("labelname").value;
    var mobile = document.getElementById("mobile").value;
    var telephone = document.getElementById("telephone").value;

    if (name.length == 0 || address.length == 0 || labelname.length == 0 || mobile.length == 0) {
        alert('The information cannot be blank！');
        return false;
    }
    $.ajax({
        url: "/JsData/user.aspx?action=SaveOrderAddr&orderId=" + orderId + "&location_p=" + location_p + "&location_c=" + location_c + "&location_a=" + location_a + "&mobile=" + mobile + "&telephone=" + telephone + "&name=" + escape(name) + "&address=" + escape(address) + "&labelname=" + escape(labelname) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                location.href = "/zhifu_" + orderId + ".html";
            }
            else {
                alert('Failed to save');
            }

        }
    });
}