/*head*/
$(function () {
    /*性别选择*/
    $('._sex li').click(function () {
        $('._sex li').find('span').removeClass('cur');
        $(this).find('span').addClass('cur');
        $('._sex li').find('i').hide();
        $(this).find('i').show();
        document.getElementById("sexValue").value = this.id;
        //alert(this.id);
        //        $('._sex li').find('input').attr('checked', 'false');
        //        $(this).find('input').attr('checked', 'true');
    });
    //默认选择
    //    $('._sex li').eq(2).find('span').addClass('cur');
    //    $('._sex li').eq(2).find('i').show();
    //    $('._sex li').eq(2).find('input').attr('checked','true');

    /*orders*/
    //    $('.r_title li').eq(0).addClass('title_cur');
    $('.r_shop ul').eq(0).show();
    //    $('.r_title li').click(function(){
    //        $(this).addClass('title_cur').siblings().removeClass('title_cur');
    //        $('.r_shop ul').hide();
    //        $('.r_shop ul').eq($(this).index()).show();
    //    });

    /*checkbox*/
    var flag = 1;
    $('.check_span').click(function () {
        if (flag == 1) {
            $('.check_span i').hide();
            $('.checkbox').prop('checked', false);
            document.getElementById("hidSelBaoZhuang").value = "0";
            flag = 0;
            // alert(document.getElementById("hidSelBaoZhuang").value);
        } else if (flag == 0) {
            $('.check_span i').show();
            $('.checkbox').prop('checked', true);
            flag = 1;
            document.getElementById("hidSelBaoZhuang").value = "1";
            //alert("感谢您为环保做出的贡献！");
            // alert(document.getElementById("hidSelBaoZhuang").value);
        }
    });
    //  $('.checkbox').prop('checked', false);
    /*jiesuan*/
    /*发票抬头*/
    $('.radio1').click(function () {
        $('.radio1').parents('.p1').find('.radio1').removeClass('cur2');
        $(this).parents('.p1').find('.radio1').addClass('cur2');
        $('.radio1').parents('.p1').find('.radio1 i').hide();
        $(this).parents('.p1').find('.radio1 i').show();
        $('.radio1').parents('.p1').find('input').attr('checked', 'false');
        $(this).parents('.p1').find('input').attr('checked', 'true');

        if (this.id == "person") {
            document.getElementById("invoiceUserType").value = 1;
        }
        else {
            document.getElementById("invoiceUserType").value = 2;
        }

    });
    /*发票内容*/
    $('.radio2').click(function () {
        $('.radio2').parents('.p2').find('.radio2').removeClass('cur2');
        $(this).parents('.p2').find('.radio2').addClass('cur2');
        $('.radio2').parents('.p2').find('.radio2 i').hide();
        $(this).parents('.p2').find('.radio2 i').show();
        $('.radio2').parents('.p2').find('input').attr('checked', 'false');
        $(this).parents('.p2').find('input').attr('checked', 'true');

        if (this.id == "content1") {
            document.getElementById("invoiceType").value = 1;
        }
        else if (this.id == "content2") {
            document.getElementById("invoiceType").value = 2;
        }
        else if (this.id == "content3") {
            document.getElementById("invoiceType").value = 3;
        }
        else if (this.id == "content4") {
            document.getElementById("invoiceType").value = 4;
        }
        else {
            document.getElementById("invoiceType").value = 5;
        }
    });
    //默认选择
    $('.p1').eq(0).find('.radio1').addClass('cur2');
    $('.p1').eq(0).find('.radio1 i').show();
    $('.p1').eq(0).find('input').attr('checked', 'true');
    $('.p2').eq(0).find('.radio2').addClass('cur2');
    $('.p2').eq(0).find('.radio2 i').show();
    $('.p2').eq(0).find('input').attr('checked', 'true');

    /*zhifu*/
    $('.zhifu1').click(function () {
        $('.zhifu1').find('span').removeClass('cur3');
        $(this).find('span').addClass('cur3');
        $('.zhifu1').find('i').hide();
        $(this).find('i').show();
        $('.zhifu1').find('input').attr('checked', 'false');
        $(this).find('input').attr('checked', 'true');
        if (this.id == "alipy") {
            $("#alipaysel").show();
            $("#mychatsel").hide();
        }
        else {
            var orderId = document.getElementById("hidOrderId").value;
            $.ajax({
                url: "/JsData/order.aspx?action=PreOrder&orderId=" + orderId + "&time=" + new Date().getTime() + "",
                type: 'GET',
                success: function (msg) {
                    if ($.trim(msg) != "") {
                        $("#mychatsel").find("img").attr("src", msg);
                    }
                    else {


                    }

                }
            });
            $("#mychatsel").show();
            $("#alipaysel").hide();
        }
    });
    //默认选择
    $('.zhifu1').eq(0).find('span').addClass('cur3');
    $('.zhifu1').eq(0).find('i').show();
    $('.zhifu1').eq(0).find('input').attr('checked', 'true');

});
$(function(){
    /*shopping*/
    function getTotal(){
        var z=0;
        for(var i = 0; i <$('.tr').length; i++){
            if($('.tr').eq(i).find('.li11 input').is(':checked')){
                z+=parseFloat($('.tr').eq(i).children('.li16').find('span i').text());
            }
        }
        $('.priceTotal').text(z.toFixed(2));
    }
    getTotal();

    var flag2;
    $('.check_img').click(function(){
        if(!$(this).parents('.li11').find('input').is(':checked')){
            flag2=0;
        }else{
            flag2=1;
        }
        if(flag2==0){
            $(this).attr('src','images/zhifu/checkbox02.png');
            $(this).parents('.li11').find('input').attr('checked',true);
            getSubtotal($(this).parents('.tr'));
            flag2=1;
        }else if(flag2==1){
            $(this).attr('src','images/zhifu/checkbox01.png');
            $(this).parents('.li11').find('input').attr('checked',false);
            flag2=0;
        }
        getTotal();
    });

    //check_all
    $('.checkedall').click(function() {
        if (!$(this).parents('.btm_l').find('input').is(':checked')) {
            flag2 = 0;
        } else {
            flag2 = 1;
        }
        if(flag2==0){
            $(this).children('.check_imgall').attr('src','images/zhifu/checkbox02.png');
            $(this).parents('.btm_l').find('input').attr('checked',true);
            getSubtotal($(this).parents('.tr'));
            $('.check').attr('checked',true);
            $('.check_img').attr('src','images/zhifu/checkbox02.png');
            flag2=1;
        }else if(flag2==1){
            $(this).children('.check_imgall').attr('src','images/zhifu/checkbox01.png');
            $(this).parents('.btm_l').find('input').attr('checked',false);
            $('.check').attr('checked',false);
            $('.check_img').attr('src','images/zhifu/checkbox01.png');
            flag2=0;
        }
        getTotal();
    });
    //默认
    //$('.check_imgall').attr('src','images/zhifu/checkbox02.png');
    //$('.check-all').attr('checked',true);

    /*计算单行价格*/
    function getSubtotal(tr){
        var dj=parseFloat(tr.children('.li14').find('span i').text());
        var num=parseInt(tr.children('.li15').find('span').text());
        tr.children('.li16').find('span i').html((dj*num).toFixed(2));
    }

    function jg(){
        if(!$('.tr').is(':animated')){
            j=$(this).siblings('.num').text();
            if($(this).hasClass('reduce')){
                j--;
                if(j<=0){
                    j=1;
                }$(this).siblings('.num').text(j);
            }else{
                j++;
                $(this).siblings('.num').text(j);
            }
            getSubtotal($(this).parents('.tr'));
            getTotal();
        }
    }
    $('.reduce').click(jg);
    $('.add').click(jg);


});

$(function(){
    $('.my_card_alert2 dd li:last-child').css('margin','0px');
    $('.youhui .push_pr .push_ul li').css('margin','0px');
});
