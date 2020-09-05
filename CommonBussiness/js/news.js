$(function () {
    /*????*/

    $('.clickbut .news-left-word').click(function () {
        if($(this).siblings('.hide').hasClass('show')){


            $(this).css('background-color', '#fff');
            $(this).find('img').attr('src', 'images/news-img3.png');
            $(this).siblings('.hide').removeClass('show');
            $(this).siblings('.hide').slideUp(500);

        }else{
            $('.clickbut .news-left-word').css('background-color', '#fff');
            $('.clickbut .news-left-word').find('img').attr('src', 'images/news-img3.png');
            $('.clickbut .news-left-word').siblings('.show').slideUp(500);
            $('.clickbut .news-left-word').siblings('.show').removeClass('show');
            $(this).css('background-color', '#cfd4d9');
            $(this).find('img').attr('src', 'images/news-img5.png');
            $(this).siblings('.hide').addClass('show');
            $(this).siblings('.hide').slideDown(500);
        }

    });


    $('.news-left-box2').click(function(){
        $(this).find('img').attr('src','images/news-img4.png');
        $(this).siblings().find('img').attr('src','images/news-img6.png');
    });
    //
    ///*youze*/
    //$('.news_li').click(function(){
    //    $('.news_li').removeClass('news_licur');
    //    $('.news_li').children('.news_time2').hide();
    //    $(this).addClass('news_licur');
    //    $(this).children('.news_time2').stop().slideDown(500);
    //});
    $('.news_li ol li').click(function(){
        $('.news_li ol li').removeClass('time_cur');
        $(this).addClass('time_cur');
        $(this).parents('.news_li').addClass('news_licur');
    });
    //moren
//    $('.news_li:first-child').addClass('news_licur');
    $('.news_li:first-child .hide2').addClass('show2');
    /*????*/
    $('.news_li .a_wz').click(function () {
        if($(this).siblings('.hide2').hasClass('show2')){
            $(this).parents('.news_li').removeClass('news_licur');
            $(this).siblings('.hide2').removeClass('show2');
            $(this).siblings('.hide2').slideUp(500);
        }
        else{
            $('.news_li').removeClass('news_licur');
            $('.news_li .a_wz').siblings('.hide2').slideUp(500);
            $('.news_li .a_wz').siblings('.hide2').removeClass('show2');
            $(this).parents('.news_li').addClass('news_licur');
            $(this).siblings('.hide2').slideDown(500);
            $(this).siblings('.hide2').addClass('show2');

        }

    });
    

});


/*file*/
function setImagePreview(avalue) {
    var docObj=document.getElementById("doc");

    var imgObjPreview=document.getElementById("preview");
    if(docObj.files &&docObj.files[0])
    {
//»ðºüÏÂ£¬Ö±½ÓÉèimgÊôÐÔ
        imgObjPreview.style.display = 'block';
        imgObjPreview.style.width = '120px';
        imgObjPreview.style.height = '120px';
//imgObjPreview.src = docObj.files[0].getAsDataURL();

//»ðºü7ÒÔÉÏ°æ±¾²»ÄÜÓÃÉÏÃæµÄgetAsDataURL()·½Ê½»ñÈ¡£¬ÐèÒªÒ»ÏÂ·½Ê½
        imgObjPreview.src = window.URL.createObjectURL(docObj.files[0]);
    }
    else
    {
//IEÏÂ£¬Ê¹ÓÃÂË¾µ
        docObj.select();
        var imgSrc = document.selection.createRange().text;
        var localImagId = document.getElementById("localImag");
//±ØÐëÉèÖÃ³õÊ¼´óÐ¡
        localImagId.style.width = "120px";
        localImagId.style.height = "120px";
//Í¼Æ¬Òì³£µÄ²¶×½£¬·ÀÖ¹ÓÃ»§ÐÞ¸Äºó×ºÀ´Î±ÔìÍ¼Æ¬
        try{
            localImagId.style.filter="progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)";
            localImagId.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgSrc;
        }
        catch(e)
        {
            alert("ÄúÉÏ´«µÄÍ¼Æ¬¸ñÊ½²»ÕýÈ·£¬ÇëÖØÐÂÑ¡Ôñ!");
            return false;
        }
        imgObjPreview.style.display = 'none';
        document.selection.empty();
    }
    return true;
}