
//产品列表
function AddToCartIndexNew(id) {
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
//推荐
function AddToCartIndexTj(id) {
    $.ajax(
	        {
	            url: "/JsData/order.aspx?action=AddToCartIndexNew&id=" + id + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                $("#product_tj_" + id).html(msg);
	                document.getElementById("product_tj_" + id).className = "num";
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
