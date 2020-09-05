
//评论列表
function AddToCartComment(id) {
    $.ajax(
	        {
	            url: "/JsData/order.aspx?action=AddToCartIndexNew&id=" + id + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if (msg == "nostore") {
	                    alert("Not Enough");
	                    return false;
	                }
	                $("#product_" + id).html(msg);
	                document.getElementById("product_" + id).className = "num";
	                var total = $("#carttotal").html();
	                if (total != "0") {
	                    $("#carttotal").html(total * 1 + 1);
	                    $("#carttotal").removeClass("hideNum");
	                    var productCount = $("#product_" + id).text();

	                    $("#product_tj_" + id).html(productCount);
	                    if (productCount == "") {
	                        $("#product_tj_" + id).html(productCount * 1 + 1);

	                    }
	                    // $("#product_tj_" + id).html($("#product_tj_" + id).text() + 1);
	                }
	                else {
	                    $("#carttotal").html(1);
	                    document.getElementById("carttotal").className = "totleNum";

	                    var productCount = $("#product_" + id).text();
	                    $("#product_tj_" + id).html(productCount);
	                    document.getElementById("product_tj_" + id).className = "num";
	                }
	            }
	        }
	    );

    return false;
}
//产品列表
function AddToCartIndexNew(id) {
    $.ajax(
	        {
	            url: "/JsData/order.aspx?action=AddToCartIndexNew&id=" + id + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if (msg == "nostore") {
	                    alert("Not Enough");
	                    return false;
	                }
	                $("#product_" + id).html(msg);
	                document.getElementById("product_" + id).className = "num";
	                var total = $("#carttotal").html();
	                if (total != "0") {
	                    $("#carttotal").html(total * 1 + 1);
	                    $("#carttotal").removeClass("hideNum");
	                    var productCount = $("#product_" + id).text();
                        
	                    $("#product_tj_" + id).html(productCount);
                        if(productCount == ""){
                            $("#product_tj_" + id).html(productCount * 1 + 1);

                        }
	                    // $("#product_tj_" + id).html($("#product_tj_" + id).text() + 1);
	                }
	                else {
	                    $("#carttotal").html(1);
	                    document.getElementById("carttotal").className = "totleNum";

	                    var productCount = $("#product_" + id).text();
	                    $("#product_tj_" + id).html(productCount);
	                    document.getElementById("product_tj_" + id).className = "num";
	                }
	            }
	        }
	    );

    return false;
}
//推荐
function AddToCartIndexTj(id) {
    $.ajax(
	        {
	            url: "/JsData/order.aspx?action=AddToCartIndexNew&id=" + id + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                //alert(msg);
	                if (msg == "nostore") {
	                    alert("Not Enough");
	                    return false;
	                }
	                $("#product_tj_" + id).html(msg);
	                document.getElementById("product_tj_" + id).className = "num";
	                var total = $("#carttotal").html();
	                if (total != "0") {

	                    $("#carttotal").html(total * 1 + 1);
	                    var productCount = $("#product_tj_" + id).text();
	                    if (productCount == "") {
	                        document.getElementById("product_" + id).className = "num";
	                        $("#product_" + id).html(productCount * 1 + 1);
	                    }
	                    $("#product_" + id).html(productCount);

	                }
	                else {
	                    $("#carttotal").html(1);
	                    document.getElementById("carttotal").className = "totleNum";

	                    var productCount = $("#product_tj_" + id).text();
	                    $("#product_" + id).html(productCount);
	                    document.getElementById("product_" + id).className = "num";
	                }
	            }
	        }
	    );

    return false;
}
//详情页添加到购物车
function AddToCartIndexNewDetail(id) {
    var procount = document.getElementById("procount").value;
    $.ajax(
	        {
	            url: "/JsData/order.aspx?action=AddToCartIndexNewDetail&id=" + id + "&procount=" + procount + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                location.href = "/mobile/product_details_" + id + ".html";
	            }
	        }
	    );

    return false;
}
//搜索列表
function AddToCartIndexSearch(id) {
    $.ajax(
	        {
	            url: "/JsData/order.aspx?action=AddToCartIndexNew&id=" + id + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if (msg == "nostore") {
	                    alert("Not Enough");
	                    return false;
	                }
	                $("#product_" + id).html(msg);
	                document.getElementById("product_" + id).className = "num";
	                var total = $("#carttotal").html();
	                if (total != "0") {
	                    $("#carttotal").html(total * 1 + 1);
	                    $("#carttotal").removeClass("hideNum");
	                    var productCount = $("#product_" + id).text();

	                    $("#product_tj_" + id).html(productCount);
	                    if (productCount == "") {
	                        $("#product_tj_" + id).html(productCount * 1 + 1);

	                    }
	                    // $("#product_tj_" + id).html($("#product_tj_" + id).text() + 1);
	                }
	                else {
	                    $("#carttotal").html(1);
	                    document.getElementById("carttotal").className = "totleNum";

	                    var productCount = $("#product_" + id).text();
	                    $("#product_tj_" + id).html(productCount);
	                    document.getElementById("product_tj_" + id).className = "num";
	                }
	            }
	        }
	    );

    return false;
}