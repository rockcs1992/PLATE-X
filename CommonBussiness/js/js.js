/*head*/
$(function(){
    $('.head_r li li:last').css("border","none");

    $('.my_yx').hover(function(){
      $(this).find('ul').stop().slideToggle(100);
    });
});
/*nav*/
$(function(){
  // $('.allFood').hover(function(){
  //   $('.allFoodMenu').stop().fadeToggle(500);
  //   $('.overf').animate({"opacity":0.6},300)
  // },function(){
  //   $('.overf').animate({"opacity":1},100)
  //   $('.allFoodMenu').stop().fadeToggle(100);
  // });
  $('.allFood_menu').hover(function(){
      $(this).children('.allFood_menu_main').stop().fadeToggle();
  });
  $('.allFood_menu').mouseover(function(){
    $(this).children('.allFood_menu_main').css('top',-$(this).index()*60+'px');
    $(this).find('.menu_xg').stop().animate({"left":15},280);
  }).mouseout(function(){
    $(this).find('.menu_xg').stop().animate({"left":0},280);
  })
});
/*banner*/
$(function(){
      var num = 0;
      var num1 = 0;
      var liNum = $('.banner ul li').length;
      $('.banner ol li:first').addClass('bannerLi_cur');
      $('.banner ul').width((liNum+1)*100+'%');
      $('.banner ul').append($('.banner ul li:first').clone());
      $('.banner ul li').width((100/(liNum+1))+'%');
      function play(){
          if(!$('.banner ul').is(':animated')){
            if($(this).hasClass('btn_l')){
              num--;
              num1--;
              if(num == -1){
                $('.banner ul').css('left',-liNum*100+'%')
                num = liNum-1;
                num1 = liNum-1; 
              }$('.banner ul').animate({'left':-num*100+'%'},500)
            }else{
              num++;
              num1++;
              if(num == liNum+1){
              $('.banner ul').css('left',0)
              num = 1;
              }
              if(num1 == liNum)
              {num1=0};
              $('.banner ul').animate({'left':-num*100+'%'},500)  
            } 
          } 
      $('.banner ol li').eq(num1).addClass('bannerLi_cur').siblings().removeClass('bannerLi_cur');
      }
      var timer = null;
      timer = setInterval(play,5000)
      $('.banner').mouseover(function(){
          clearInterval(timer);
          $('.banner span').stop().show();
      }).mouseout(function(){
          timer = setInterval(play,5000)
          $('.banner span').stop().hide();
      });
      $('.btn_l').click(play);
      $('.btn_r').click(play);
      $('.banner ol li').hover(function(){
          num = $(this).index();
          num1 = $(this).index();
          $('.banner ul').stop().animate({'left':-num*100+'%'},500);
          $('.banner ol li').eq(num1).addClass('bannerLi_cur').siblings().removeClass('bannerLi_cur');
      });
});
/*main*/
$(function(){
    $('.main  li').hover(function(){
        $(this).find('.xiangJ_liNone').stop().fadeToggle();
    })
});
/*returnTop*/
$(function(){
  $(".returnTop").click(function(){
    $("html,body").animate({"scrollTop":0},500);
  });
  $(".returnTop2").click(function(){
    $("html,body").animate({"scrollTop":0},500);
  });
  $(window).scroll(function(){
    var Sctop = $(window).scrollTop();
    var navhei = $(document.body).height();
    if(Sctop > 300 && Sctop < navhei - 950){
     $(".returnTop").fadeIn(0);
     $(".returnTop2").fadeOut(500);
    }else if(Sctop >= navhei - 950){
      $(".returnTop").fadeOut(0);
      $(".returnTop2").fadeIn(0);
    }else{
      $(".returnTop").fadeOut(0);
      $(".returnTop2").fadeOut(0);
    }
  });
  //$('.float_nav li').eq(4).css('background-position','12px 2px');
});
/*float_nav*/
$(function(){
  $(window).scroll(function(){
    var navH = $(window).scrollTop();
    var navhei = $(document.body).height();
    if(navH > 905 && navH < navhei - 950){
      $('.float_nav').fadeIn(200);
    }else if( navH > navhei - 950){
      $('.float_nav').fadeOut(200);
    }else{
      $('.float_nav').fadeOut(200);
    };
    $('.float_nav li').css('background-size','inherit');
    if(navH >= 905 && navH < 1720){
      $('.float_nav01').addClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $('.float_nav01').css("background-image","url(images/icon/menu_1b.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    };
    if(navH >= 1720 && navH < 2550){
      $('.float_nav02').addClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2b.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    };
    if(navH >= 2550 && navH < 3370){
      $('.float_nav03').addClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3b.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    };
    if(navH >= 3370 && navH < 4215){
      $('.float_nav04').addClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4b.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    };
    if(navH >= 4215 && navH < 5025){
      $('.float_nav05').addClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5b.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    };
    if(navH >= 5025 && navH < 5620){
      $('.float_nav06').addClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6b.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    };
    if(navH >= 5620 && navH < 6180){
      $('.float_nav07').addClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7b.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    };
    if(navH >= 6180){
      $('.float_nav08').addClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8b.png)");
    };
  });
  $(function(){
    $('.float_nav li').click(function(){
        $(this).removeClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $(this).addClass('float_nav_cur').siblings().removeClass('float_nav_cur');
    });
    $('.float_nav01 ').click(function(){
        $(this).removeClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $("html,body").animate({"scrollTop":910},500);
      $(this).css("background-image","url(images/icon/menu_1b.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    });
    
    $('.float_nav02 ').click(function(){
         $(this).removeClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $("html,body").animate({"scrollTop":1745},500);
      $(this).css("background-image","url(images/icon/menu_2b.png)");
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    });
    $('.float_nav03 ').click(function(){
         $(this).removeClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $("html,body").animate({"scrollTop":2575},500);
      $(this).css("background-image","url(images/icon/menu_3b.png)");
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    });
    $('.float_nav04 ').click(function(){
         $(this).removeClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $("html,body").animate({"scrollTop":3400},500);
      $(this).css("background-image","url(images/icon/menu_4b.png)");
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    });
    $('.float_nav05 ').click(function(){
         $(this).removeClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $("html,body").animate({"scrollTop":4225},500);
      $(this).css("background-image","url(images/icon/menu_5b.png)");
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    });
    $('.float_nav06 ').click(function(){
        $(this).removeClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $("html,body").animate({"scrollTop":5050},500);
      $(this).css("background-image","url(images/icon/menu_6b.png)");
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    });
    $('.float_nav07 ').click(function(){
         $(this).removeClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $("html,body").animate({"scrollTop":5625},500);
      $(this).css("background-image","url(images/icon/menu_7b.png)");
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
      $('.float_nav08').css("background-image","url(images/icon/menu_8.png)");
    });
    $('.float_nav08 ').click(function(){ 
        $(this).removeClass('float_nav_cur').siblings().removeClass('float_nav_cur');
      $("html,body").animate({"scrollTop":6200},500);
      $(this).css("background-image","url(images/icon/menu_8b.png)");
      $('.float_nav01').css("background-image","url(images/icon/menu_1.png)");
      $('.float_nav03').css("background-image","url(images/icon/menu_3.png)");
      $('.float_nav04').css("background-image","url(images/icon/menu_4.png)");
      $('.float_nav05').css("background-image","url(images/icon/menu_5.png)");
      $('.float_nav06').css("background-image","url(images/icon/menu_6.png)");
      $('.float_nav07').css("background-image","url(images/icon/menu_7.png)");
      $('.float_nav02').css("background-image","url(images/icon/menu_2.png)");
    });
  })
})
/*foot*/
$(function(){
  $('.foot_t_c h2').eq(1).css({"background":"none"});
  $('.foot_t_c h2').eq(0).css({"padding-bottom":0});
});

$(function(){
  $('.help_l li').click(function(){
    $(this).addClass('left_nav_cur').siblings().removeClass('left_nav_cur');
  })
});

/*project*/
$(function () {
    $('.project_t li:last span').html("");

    $('.min_img li:last').css("margin", 0);
    $('.min_img li:first').addClass("imgCur");
    var url1 = $('.min_img li:first').find('img').attr("src");
    $('.big_img img').attr("src", url1);

    $('.min_img li').click(function () {
        $(this).addClass("imgCur").siblings().removeClass("imgCur");
        var surl = $(this).find('img').attr("src");
        $('.big_img img').attr("src", surl);
    });

    var flag = false;
    $("#zoom1 img").hover(function () {
        flag = true;
    });
    if (document.all) {
        $('#zoom1 img').mouseenter(function (e) {
            $(this).css('width', '1120px');
            $(this).css('height', '940px');
            if (flag == false) return;
            var x = e.clientX - $("#zoom1").offset().left;
            var y = e.clientY - $("#zoom1").offset().top;
            if (x >= 0 && x <= 560) {
                $(this).css('margin-left', -x + 'px');
            }
            if (y >= 0 && y <= 470) {
                $(this).css('margin-top', -y + 'px');
            }
        });
        $('#zoom1 img').mouseleave(function (e) {
            $(this).css('width', '560px');
            $(this).css('height', '470px');
            $(this).css('margin-left', '0');
            $(this).css('margin-top', '0');
        });
    } else {
        $('#zoom1 img').mousemove(function (e) {
            $(this).css('width', '1120px');
            $(this).css('height', '940px');
            if (flag == false) return;
            var x = e.clientX - $("#zoom1").offset().left;
            var y = e.clientY - $("#zoom1").offset().top;
            if (x >= 0 && x <= 560) {
                $(this).css('margin-left', -x + 'px');
            }
            if (y >= 0 && y <= 470) {
                $(this).css('margin-top', -y + 'px');
            }
        });
        $('#zoom1 img').mouseout(function (e) {
            $(this).css('width', '560px');
            $(this).css('height', '470px');
            $(this).css('margin-left', '0');
            $(this).css('margin-top', '0');
        });
    }



    //$('.rmb :first').addClass('rmb_cur');
    $('.rmb').eq(0).addClass('rmb_cur');
    $('.buy li:first').addClass('selected');
    count(1);
    function count(inputNum) {
        $('.jia').click(function () {
            inputNum++;
            $('.rmb_num input').val(inputNum);
        });
        $('.jian').click(function () {
            inputNum--;
            if (inputNum < 1) {
                $('.rmb_num input').val("1");
                inputNum = 1;
            } else {
                $('.rmb_num input').val(inputNum);
            }
        });
    }
    $('.buy li').click(function () {
        document.getElementById("priceItem").value = this.id;
        $('.rmb_num input').val(1);
        var n = $('.rmb_num input').val();
        var buyLi = $(this).index();
        $(this).addClass('selected').siblings().removeClass('selected');
        $('.rmb').eq(buyLi).addClass('rmb_cur').siblings().removeClass('rmb_cur');
        count(n);
    });

    $('.conment_t li:first').addClass('conment_t_cur');
    $('.conment_b:first').addClass('conment_cur');
    $('.conment_t li').click(function () {
        $(this).addClass('conment_t_cur').siblings().removeClass('conment_t_cur');
        var nus = $(this).index();
        $('.conment_b').eq(nus).addClass('conment_cur').siblings().removeClass('conment_cur');
    })
});
/*project_list*/
$(function () {
    $('.project_pro_scro').append($('.project_pro_scro li').clone());
    $('.project_pro_scro').append($('.project_pro_scro li').clone());
    var num2 = 0;
    function _play() {
        if (!$('.project_pro_scro').is(':animated')) {
            if ($(this).hasClass('list_l')) {
                num2--;
                if (num2 == -1) {
                    num2 = 2;
                } $('.project_pro_scro').animate({ 'left': -1000 * num2 }, 1000);
            } else {
                num2++;
                if (num2 == 3) {
                    num2 = 0;
                } $('.project_pro_scro').animate({ 'left': -1000 * num2 }, 1000);
            }
        }
    }
    $('.list_l').click(_play);
    $('.list_r').click(_play);



    $('.hp').addClass('hp_cur');
    $('.csyy ul li').click(function () {
        $(this).find('dl').addClass('hp_cur');
        if (this.id == "type1") {
            document.getElementById("hidCommentType").value = "1";
        }
        if (this.id == "type2") {
            document.getElementById("hidCommentType").value = "2";
        }
        if (this.id == "type3") {
            document.getElementById("hidCommentType").value = "3";
        }
        
        $(this).siblings().find('dl').removeClass('hp_cur');
    });

    $(window).scroll(function () {
        var navList = $(window).scrollTop();
        if (navList > 926) {
            $('.leftmenu').fadeIn(200);
        } else {
            $('.leftmenu').fadeOut(200);
        }
    });
})
/*jiesuan*/
$(function () {
    $('.jiesuan1_l li').click(function () {
        $(this).addClass('jiesuan1_cur').siblings().removeClass('jiesuan1_cur');
        document.getElementById("hidAddrId").value = this.id;
       
    });
    $('.jiesuan1_l li:first').addClass('jiesuan1_cur');
    //$('.jiesuan_l dl').eq(2).find('input').css("width","360");
    $('.sh_main:last').css("border", "none");
    for (var i = 0; i < $('.youhui li').length; i++) {
        if (i % 2 == 1) {
            $('.youhui li').eq(i).css("margin-left", 13);
        }
    };
    $('.fp a').click(function () {
        $('.show_bg').show();
        $('.alert_fp').show();
    });
    $('.close_fp').click(function () {
        $('.alert_fp').hide();
        $('.show_bg').hide();
    })

    //$('input[name="radio-btn"]').wrap('<div class="radio-btn"><i></i></div>');
    //$(".radio-btn").on('click', function () {
    //    var _this = $(this),
    //        block = _this.parent().parent();
    //    block.find('input:radio').attr('checked', false);
    //    block.find(".radio-btn").removeClass('checkedRadio');
    //    _this.addClass('checkedRadio');
    //    _this.find('input:radio').attr('checked', true);
    //});
    $('input[name="check-box"]').wrap('<div class="check-box"><i></i></div>');
    $.fn.toggleCheckbox = function () {
        this.attr('checked', !this.attr('checked'));
    }
    $('.check-box').on('click', function () {
        $(this).find(':checkbox').toggleCheckbox();
        $(this).toggleClass('checkedBox');
    });
    $('.danwei').click(function () {
        $('.danwei_box').fadeIn(500);
    });
    $('.geren').click(function () {
        $('.danwei_box').fadeOut(100);
    });

    $('.jiesuan1_l h1 a').click(function () {
        $('.show_bg').show();
        $('.new_dizhi').show();
    });
    $('.close_fp').click(function () {
        $('.new_dizhi').hide();
        $('.show_bg').hide();
    });

    $('.up a').click(function () {
        $('.show_bg').show();
        $('.up_dizhi').show();

    });
    $('.close_fp2').click(function () {
        $('.up_dizhi').hide()
        $('.show_bg').hide();
    });

    /*news_list*/
    $('.news-right-box-img-list a img').click(function () {
        $('.xq').show(); $('.xq_img').show(); $('.xq_close').show();
    });
    $('.xq_close').click(function () {
        $('.xq').hide(); $('.xq_img').hide(); $('.xq_close').hide();
    });

});
/*login*/
$(function(){
//  $('.login01 a').click(function(){
//    $('.login').show();
//    $('.show_bg').show();
//  });
  $('.close_fp').click(function(){
    $('.login').hide();
    $('.changePassword').hide();
    $('.findPassword').hide();
    $('.show_bg').hide();
    $('.my_card_alert').hide();
    $('.my_card_alert2').hide();
    $('.overf').animate({"opacity":1},1);
  })
});
/*changePassword*/
$(function(){
  $('.changePass a').click(function(){
    $('.findPassword').fadeIn(100);
    $('.overf').animate({"opacity":0.4},100);
  });

  $('.find_btn').click(function(){
    $('.changePassword').fadeIn(300);
  });
});

/*my_yuanX*/
$(function(){
  $('.my_card_main li:last').css("border-right",0);
  $('.my_card_alert dd li:last').css("margin",0);
  $('.my_card_alert dd span').parent().css("border",0);
  $('.my_yuanX_t h3').click(function(){
    $('.my_card_alert').show();
    $('.show_bg').show();
  });

  $('.my_mail ul li:first').addClass('my_mail_cur');
  $('.safty_password:first').addClass('my_mail_block');
  $(function(){
    $('.my_mail01').click(function(){
      $('.safty_password').eq(1).addClass('my_mail_block').siblings().removeClass('my_mail_block');
      $('.my_mail ul li').eq(1).addClass('my_mail_cur').siblings().removeClass('my_mail_cur');
    });
    
    $('.mail_btn').click(function(){
      $('.safty_password').eq(0).addClass('my_mail_block').siblings().removeClass('my_mail_block');
      $('.my_mail ul li').eq(0).addClass('my_mail_cur').siblings().removeClass('my_mail_cur');
    });
    $('.mail_btn2').click(function(){
      $('.safty_password').eq(0).addClass('my_mail_block').siblings().removeClass('my_mail_block');
      $('.my_mail ul li').eq(0).addClass('my_mail_cur').siblings().removeClass('my_mail_cur');
    });
    $('.mail_btn_01').click(function(){
      $('.safty_password').eq(1).addClass('my_mail_block').siblings().removeClass('my_mail_block');
      $('.my_mail ul li').eq(1).addClass('my_mail_cur').siblings().removeClass('my_mail_cur');
    });

    $('.my_mail02').click(function(){
      $('.safty_password').eq(2).addClass('my_mail_block').siblings().removeClass('my_mail_block');
      $('.my_mail ul li').eq(2).addClass('my_mail_cur').siblings().removeClass('my_mail_cur');
    });
  })
});

//jiesuan
$(function(){
  $('.xink1').click(function(){
    $('.my_card_alert2').show();
    $('.show_bg').show();
  });
  $('.xink2').click(function(){
    $('.my_card_alert').show();
    $('.show_bg').show();
  });
});



/*file*/
function setImagePreview(avalue) {
var docObj=document.getElementById("doc");
 
var imgObjPreview=document.getElementById("preview");
if(docObj.files &&docObj.files[0])
{
//火狐下，直接设img属性
imgObjPreview.style.display = 'block';
imgObjPreview.style.width = '120px';
imgObjPreview.style.height = '120px'; 
//imgObjPreview.src = docObj.files[0].getAsDataURL();
 
//火狐7以上版本不能用上面的getAsDataURL()方式获取，需要一下方式
imgObjPreview.src = window.URL.createObjectURL(docObj.files[0]);

}
else
{
//IE下，使用滤镜
docObj.select();
var imgSrc = document.selection.createRange().text;
var localImagId = document.getElementById("localImag");
//必须设置初始大小
localImagId.style.width = "120px";
localImagId.style.height = "120px";
//图片异常的捕捉，防止用户修改后缀来伪造图片
try{
localImagId.style.filter="progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)";
localImagId.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgSrc;
}
catch(e)
{
alert("您Upload的图片格式不correct，请重新选择!");
return false;
}
imgObjPreview.style.display = 'none';
document.selection.empty();
}
return true;
}

function setImagePreview02(avalue) {
var docObj=document.getElementById("judgeF");
 
var imgObjPreview=document.getElementById("preview");
if(docObj.files &&docObj.files[0])
{
//火狐下，直接设img属性
imgObjPreview.style.display = 'block';
imgObjPreview.style.width = '70px';
imgObjPreview.style.height = '70px';
//imgObjPreview.src = docObj.files[0].getAsDataURL();
 
//火狐7以上版本不能用上面的getAsDataURL()方式获取，需要一下方式
imgObjPreview.src = window.URL.createObjectURL(docObj.files[0]);
}
else
{
//IE下，使用滤镜
docObj.select();
var imgSrc = document.selection.createRange().text;
var localImagId = document.getElementById("localImag");
//必须设置初始大小
localImagId.style.width = "70px";
localImagId.style.height = "70px";
//图片异常的捕捉，防止用户修改后缀来伪造图片
try{
localImagId.style.filter="progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)";
localImagId.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgSrc;
}
catch(e)
{
alert("您Upload的图片格式不correct，请重新选择!");
return false;
}
imgObjPreview.style.display = 'none';
document.selection.empty();
}
return true;
}


$(function(){
  $('.modalLink').hover(function(){
    $('.modal').fadeToggle(500);
  })
})
$(function () {
    $(".timechoice").mouseover(function () {
        $(".input-img2").show();
        $(".input-img2").css("background", "#ffffff");
    });

    $(".timechoice").mouseout(function () {
        $(".input-img2").hide();
        $(".input-img2").css("background", "#ffffff");
    });
    $("#choice1").click(function () {
        var news = $("#choice1").val();
        $("#choice").val(news);
        $(".input-img2").css("display", "none");
        document.getElementById("hidSendTime").value = news;
    });
    $("#choice2").click(function () {
        var news = $("#choice2").val();
        $("#choice").val(news);
        $(".input-img2").css("display", "none");
        document.getElementById("hidSendTime").value = news;
    });
    $("#choice3").click(function () {
        var news = $("#choice3").val();
        $("#choice").val(news);
        $(".input-img2").css("display", "none");
        document.getElementById("hidSendTime").value = news;
    });
    $("#choice4").click(function () {
        var news = $("#choice4").val();
        $("#choice").val(news);
        $(".input-img2").css("display", "none");
        document.getElementById("hidSendTime").value = news;
    });

});
