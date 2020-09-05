
/*nav*/
$(function () {
    $('.allFood').hover(function () {
        $('.allFoodMenu').stop().fadeToggle(500);
        $('.overf').animate({ "opacity": 0.6 }, 300)
    }, function () {
        $('.overf').animate({ "opacity": 1 }, 100)
        $('.allFoodMenu').stop().fadeToggle(100);
    });

    /*find*/
    //$('.find-box-class-tit ul li').hover(function(){
    //  $(this).addClass('color').siblings().removeClass('color');
    //},function(){
    //  $(this).removeClass('color');
    //});
    //$('.find-box-class-tit-list ul li').hover(function(){
    //  $(this).addClass('color2').siblings().removeClass('color2');
    //},function(){
    //  $(this).removeClass('color2');
    //});
    //$('.find-box-class-tit-list2 ul li').hover(function(){
    //  $(this).addClass('color2').siblings().removeClass('color2');
    //},function(){
    //  $(this).removeClass('color2');
    //});
    $('.li01').click(function () {
        $('.li01').hide();
        $(this).show().addClass('color');
    });
    $('.li02').click(function () {
        $(this).siblings('.li02').hide();
        $(this).show().addClass('color');
    });
    $('.kind_cur').click(function () {
        $(this).siblings('.li02').show().removeClass('color');
    });
    $('.kind_cur').eq(0).click(function () {
        $('.li01').show().removeClass('color');
        $('.li02').show().removeClass('color');
    });
    var flag = 0;
    $('.find_p').click(function () {
        if (flag == 0) {
            $('.more').show();
            $(this).find('img').attr('src', 'images/find-img2.jpg');
            flag = 1;
        } else if (flag == 1) {
            $('.more').hide();
            $(this).find('img').attr('src', 'images/find-img1.jpg');
            flag = 0;
        }
    });
    //  $('.select li').click(function(){
    //    $(this).addClass('li_cur').siblings().removeClass('li_cur');
    //  });
    //  $('.select li').eq(0).addClass('li_cur');

    //sift
    //  var flag2=0;
    //  var arr2=['images/icon/proIcon_t2.png','images/icon/proIcon_t.png'];
    //  var arr=['images/icon/proIcon_b2.png','images/icon/proIcon_b.png'];
    //  $('.sift').click(function(){
    //    if(flag2==0){
    //      console.log(0);
    //      $(this).find('span').css('background','url('+arr2[flag2]+')');
    //      $(this).find('s').css('background','url('+arr[flag2]+')');
    //      flag2=1;
    //    }else if(flag2==1){
    //      $(this).find('span').css('background','url('+arr[flag2]+')');
    //      $(this).find('s').css('background','url('+arr2[flag2]+')');
    //      flag2=0;
    //    }
    //  });

    /*jiesuan*/
    function jiaodian(ele) {
        ele.blur(function () {
            if ($(this).val() == '') {
                $(this).css('border-color', '#f23737');
                $(this).focus();
                $(this).siblings().show();
            } else {
                $(this).css('border-color', '#999');
                $(this).siblings().hide();
            }
        });
    }
    jiaodian($('.username'));
    jiaodian($('.address'));

    $('.fen').keyup(function () {
        if (!isNaN($(this).val()) && $(this).val() != '') {
            $(this).parents('dt').siblings().addClass('usable_c');
        } else {
            $(this).parents('dt').siblings().removeClass('usable_c');
        }
    });

    $('.push').click(function () {
        $('.ticket option').show();
    });

    //select
    $('.ticket').change(function () {
        $(this).parents('dt').siblings().addClass('usable_c');
    });

    //$('.input-img2:last-child').css('border-bottom','solid 1px #f23737');
    //$('.input-img2:last-child input').css('height','35px');
    $('.input-img').eq(0).css('border-bottom', 'solid 1px #fff');

    /*zhifu*/
    $('.zhifu_cont form ul>li').eq(2).css('border-bottom', 'solid 1px #ededed');

    /*project_list*/
    $('.QC_renz ul li').click(function () {
        $('.renz').show();
        $('.yx_renz').show();
        $('.renz_close').show();
        //var top=$('body').scrollTop();
        //$(window).scroll(function(){ //滚动时，固定页面滚动条到页顶的高度，使其不滚动
        //  $('body').scrollTop(top);
        //});
        $('body,html').css('overflow', 'hidden');
    });
    $('.renz_close').click(function () {
        $('.renz').hide();
        $('.yx_renz').hide();
        $('.renz_close').hide();
        //var top=$('body').scrollTop();
        //$(window).off('scroll');
        $('body,html').css('overflow', 'auto');
    });
    $('.conment_b dd li img').click(function () {
        $('.renz').show();
        $('.yx_renz2').show();
        $('.renz_close2').show();
        $('body,html').css('overflow', 'hidden');
    });
    $(".conment_b dd").on("click", "img", function () {
        var thisimg = $(this).attr('src');
        $('.yx_renz2').attr('src', thisimg);
    });
    $('.renz_close2').click(function () {
        $('.renz').hide();
        $('.yx_renz2').hide();
        $('.renz_close2').hide();
        $('body,html').css('overflow', 'auto');
    });

    //project
    $('.pro_z').click(function () {
        $(this).addClass('color2').siblings().removeClass('color2');
    });


});






