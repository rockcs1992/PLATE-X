

//产品列表
function saveComment(id, orderId) {
    var commentLevel = document.getElementById("hidCommentType").value;
    var hidImgUrl = document.getElementById("hidImgUrl").value;
    var messInfo = document.getElementById("messInfo").value;
    $.ajax(
	        {
	            url: "/JsData/order.aspx?action=SaveComment&orderId=" + orderId + "&messInfo=" + messInfo + "&hidImgUrl=" + hidImgUrl + "&id=" + id + "&commentLevel=" + commentLevel + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if ($.trim(msg) == "success") {
	                    alert('评论成功');
	                      location.href = "/mobile/ordercomment_" + orderId + ".html";
	                } else if ($.trim(msg) == "nologin") {
	                    alert('请Log In');
	                    location.href = "/mobile/login.html";
	                } else {
	                    alert('评论失败');
	                }
	            }
	        }
	    );

    return false;
}

//产品列表
function addToCartProductDetail(id) {
    $.ajax(
	        {
	            url: "/JsData/order.aspx?action=AddToCartIndexNew&id=" + id + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                $("#product_" + id).html(msg);
	                document.getElementById("product_" + id).className = "num";
	                var total = $("#carttotal").html();
	                if (total != "0") {
	                    $("#carttotal").html(total * 1 + 1);
	                }
	                else {
	                    $("#carttotal").html(1);
	                    document.getElementById("carttotal").className = "totleNum";
	                }
	            }
	        }
	    );

    return false;
}
///回复信息验证
function addToCartIndex(id) {
    $.ajax({
        url: "/JsData/order.aspx?action=AddCartIndex&id=" + id + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                //  alert('Add To Cart成功');
                location.href = "car.html";
            } else if ($.trim(msg) == "nologin") {                
                location.href = "login.html";
            } else {
                alert('Failed to Add Cart');
            }

        }
    });
}


///回复信息验证
function rightnow(id) {
    var procount = document.getElementById("procount").value;
    $.ajax({
        url: "/JsData/order.aspx?action=RightNow&procount=" + procount + "&id=" + id + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                location.href = "/jiesuan1.html?ids=" + id + "_" + procount + ",";
            } else if ($.trim(msg) == "noAddr") {
                location.href = "/jiesuan.html?ids=" + id + "_" + procount;
            } else if ($.trim(msg) == "nologin") {
                alert('请Log In');
                location.href = "/register.html";
            } else {
                ////////////////////// alert('Add To Cart失败');
            }

        }
    });
}

///移动端提交订单
function saveOrderMobile() {   
    $.ajax({
        url: "/JsData/order.aspx?action=SaveOrderMobile&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) != "") {
                if ($.trim(msg) == "noproduct") {
                    alert("C！");
                    location.href = "/mobile/car.html";
                }
                else {
                    location.href = "payment_" + msg + ".html";
                }

            } else if ($.trim(msg) == "nologin") {
                location.href = "login.html";
            } else {
                alert('Faild To Submit Order');
            }
        }
    });
}

///回复信息验证
function cancelOrder(id) {
    if (confirm("您确定要取消吗？")) {
        $.ajax({
            url: "/JsData/order.aspx?action=CancelOrder&orderId=" + id + "&time=" + new Date().getTime() + "",
            type: 'GET',
            success: function (msg) {
                if ($.trim(msg) == "success") {
                    location.href = "/orders_0.html";
                } else if ($.trim(msg) == "nologin") {
                    location.href = "/register.html";
                } else {
                    alert('取消订单失败');
                }

            }
        });
    }
    
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
                 location.href = "car.html";
            } else if ($.trim(msg) == "nologin") {
                location.href = "login.html";
            } else {
                alert('Add To Cart失败');
            }

        }
    });
}
function delCartTemp(productId) {
    if (confirm("Are you sure you want to delete?")) {
        $.ajax({
            url: "/JsData/order.aspx?action=DelCartTemp&productId=" + productId + "&time=" + new Date().getTime() + "",
            type: 'GET',
            success: function (msg) {
                if ($.trim(msg) == "success") {
                    location.href = "car.html";
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