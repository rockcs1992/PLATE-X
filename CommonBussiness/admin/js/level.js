
function GetSel() {    
    var departId = document.getElementById("hidDepartId").value;
    var roleId = document.getElementById("hidRoleId").value;
    var str = "";
    var items = document.getElementsByTagName("input");
    for (i = 0; i < items.length; i++) {
        if (items[i].type == "checkbox") {
            if (items[i].checked) {
                str += items[i].value + ",";          
            }
        }
    }
    $.ajax(
	        {
	            url: "/JsData/Level.aspx?action=level&roleId=" + roleId + "&departId=" + departId + "&str=" + str + "&t=" + new Date().getTime() + "",
	            type: 'GET',
	            success: function (msg) {
	                if ($.trim(msg) == "success") {
	                    alert('操作成功');
	                    window.location.href = 'RolePermissions.aspx?roleId=' + roleId;
	                } else {
	                    alert(arguments[0]);
	                }
	            }
	        }
	    );
}

function check(obj, count) {
    var arr = new Array();
    arr = document.getElementById("hidRowsCount").value.split(',');
    for (var i = 0; i < count; i++) {
        document.getElementById(obj.id + "_" + i).checked = obj.checked; //子一级
        for (var j = 0; j < arr.length; j++) {
            if (arr[j].indexOf(obj.id + "_" + i) == 0) {
                document.getElementById(arr[j]).checked = obj.checked; //子二级
            }
        }
    }

}
function check2(obj, count) {
    var arr = new Array();
    arr = obj.id.split('_');
    if (obj.checked) {
        document.getElementById(arr[0]).checked = obj.checked;
    }
    for (var i = 0; i < count; i++) {
        document.getElementById(obj.id + "_" + i).checked = obj.checked;
    }
}
function check3(obj) {
    var arr = new Array();
    arr = obj.id.split('_');
    if (obj.checked) {
        document.getElementById(arr[0]).checked = obj.checked;
        document.getElementById(arr[0] + "_" + arr[1]).checked = obj.checked;
    }
}