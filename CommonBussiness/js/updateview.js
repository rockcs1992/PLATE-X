///更新浏览
function UpdateViews(pageName, pageValue, typeId) {
    $.ajax(
	    {
	        type: 'POST',
	        url: "/jsData/common.aspx",
	        data: { action: "UpdateView", pageName: pageName, pageValue: pageValue, typeId: typeId },
	        success: function () {

	        }
	    }
	    );
}