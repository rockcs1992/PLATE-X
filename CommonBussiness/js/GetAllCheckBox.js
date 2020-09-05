
function GetAllCheckBox(CheckAll) {
    var items = document.getElementsByTagName("input");
    for (i = 0; i < items.length; i++) {
        if (items[i].type == "checkbox") {
            items[i].checked = CheckAll.checked;
        }
    }
}

