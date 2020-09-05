window.onload = function () {
    if (!document.getElementsByClassName) {
        document.getElementsByClassName = function (cls) {
            var ret = [];
            var els = document.getElementsByTagName('*');
            for (var i = 0, len = els.length; i < len; i++) {

                if (els[i].className.indexOf(cls + ' ') >=0 || els[i].className.indexOf(' ' + cls + ' ') >=0 || els[i].className.indexOf(' ' + cls) >=0) {
                    ret.push(els[i]);
                }
            }
            return ret;
        }
    }

    var table = document.getElementsByClassName('shop')[0]; // 购物车表格
    var selectInputs = document.getElementsByClassName('check'); // 所有勾选框
    var checkAllInputs = document.getElementsByClassName('check-all'); // 全选框
    var tr = table.getElementsByClassName('shop_li'); //行
    var priceTotal = document.getElementsByClassName('priceTotal')[0]; //总计
    var deleteAll = document.getElementsByClassName('deleteAll')[0]; // DeleteAll 按钮
    var foot = document.getElementsByClassName('foot')[0];
    console.log(tr);
    // 更新总数和Total Price格，已选浮层
    function getTotal() {
		var seleted = 0;
		var price = 0;
		var HTMLstr = '';
		for (var i = 0; i <tr.length; i++) {
            if (tr[i].getElementsByTagName('input')[0].checked) {
                tr[i].className = 'on';
                price += (parseFloat(tr[i].getElementsByClassName('li_15')[0].innerHTML))*(parseInt(tr[i].getElementsByTagName('input')[1].value));
			}
			//else {
			//	tr[i].className = '';
			//}
            priceTotal.innerText = price.toFixed(2);
		}
	}

    // 计算单行价格
    function getSubtotal(tr) {
        tr.getElementsByClassName('subtotal')[0].innerHTML =
            (parseInt(tr.getElementsByClassName('count-input')[0].value)*
            parseFloat(tr.getElementsByClassName('li_15')[0].innerHTML)).toFixed(2);
        //如果数目只有一个，把-号去掉
        var span=tr.getElementsByClassName('reduce')[0];
        if (tr.getElementsByClassName('count-input')[0].value == 1){
            span.innerHTML = '';
        }else{
            span.innerHTML = '-';
        }
    }

    // 点击选择框
    for(var i = 0; i < selectInputs.length; i++ ){
        selectInputs[i].onclick = function () {
            if (this.className.indexOf('check-all') >= 0) { //如果是全选，则吧所有的选择框选中
                for (var j = 0; j < selectInputs.length; j++) {
                    selectInputs[j].checked = this.checked;
                }
            }
            if (!this.checked) { //只要有一个未勾选，则取消全选框的选中状态
                for (var i = 0; i < checkAllInputs.length; i++) {
                    checkAllInputs[i].checked = false;
                }
            }
            getTotal();//选完更新总计
        }
    }


    //为每行$素添加事件
    for (var i = 0; i < tr.length; i++) {
        //将点击事件绑定到tr$素
        tr[i].onclick = function (e) {
            var e = e || window.event;
            var el = e.target || e.srcElement; //通过事件对象的target属性获取触发$素
            var cls = el.className; //触发$素的class
            var countInout = this.getElementsByTagName('input')[1];

             // 数目input
            var value = parseInt(countInout.value); //数目
            //通过判断触发$素的class确定用户点击了哪个$素
            switch (cls) {
                case 'add': //点击了加号
                    countInout.value = value + 1;
                    getSubtotal(this);
                    break;
                case 'reduce': //点击了减号
                    if (value > 1) {
                        countInout.value = value - 1;
                        getSubtotal(this);
                    }
                    break;
                case 'delete': //点击了Delete
                    var conf = confirm('确定Delete此商品吗？');
                    if (conf) {
                        this.parentNode.removeChild(this);
                    }
                    break;
            }
            getTotal();
        }
    }

    // 点击All Delete
    deleteAll.onclick = function () {
        if (selectedTotal.innerHTML != 0) {
            var con = confirm('确定Delete所选商品吗？'); //弹出确认框
            if (con) {
                for (var i = 0; i < tr.length; i++) {
                    // 如果被选中，就Delete相应的行
                    if (tr[i].getElementsByTagName('input')[0].checked) {
                        tr[i].parentNode.removeChild(tr[i]); // Delete相应节点
                        i--; //回退下标位置
                    }
                }
            }
        }
        else {
            alert('请选择商品！');
        }
        getTotal(); //更新总数
    }

    // 默认全选
    checkAllInputs[0].checked = true;
    checkAllInputs[0].onclick();
}
