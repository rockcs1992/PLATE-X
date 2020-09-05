// JavaScript Document\
$(document).ready(function () {

    /*banner------*/
    $('#demo01').flexslider({
        animation: "slide",
        direction: "horizontal",
        easing: "swing",
        touch: true
    });
    $('#demo02').flexslider({
        animation: "slide",
        direction: "horizontal",
        easing: "swing",
        touch: true
    });
    //    $('#demo03').flexslider({
    //        animation: "slide",
    //        direction: "horizontal",
    //        easing: "swing",
    //        touch: true
    //    });
    $('.lazyImg').lazyload({
        effect: 'fadeIn'
    });
    //Category详情
    $(".sub_nav .sub_top .arrow_btn").click(function () {
        $(this).toggleClass("active")
        $(".sub_nav .subList").slideToggle(300);
    });
    $(".sub_nav .listCon").eq(0).show();
    $(".sub_nav .sub_top ul li").click(function () {
        $(".sub_nav .sub_top ul li").eq($(this).index()).addClass("on").siblings().removeClass('on');
        $(".sub_nav .listCon").hide().eq($(this).index()).show();
    });

    //搜索结果页 
    $(".result_title .triangle").click(function () {
        $(this).addClass("active").siblings().removeClass("active");
        $(this).siblings().removeClass("arrow_up");
        $(this).siblings().removeClass("arrow_down");
        if ($(this).hasClass("arrow_up")) {
            $(this).removeClass("arrow_up").addClass("arrow_down");
        } else {
            $(this).addClass("arrow_up").removeClass("arrow_down");
        }
    });
    //产品详情页
    $(".wifiBox .event").eq(0).show();
    $(".pro_details .wifi .wifi_con").click(function () {
        $(".wifiBox").fadeIn(200);
        $(".wifiBox .event").hide().eq($(this).index()).show();

    });
    $(".wifiBox .closeDiv").click(function () {
        $(this).parent().fadeOut(200);
    });


    $(".wifiBox2 .event").eq(0).show();
    $(".pro_details .authentication .flexslider .slides li .image").click(function () {
        $(".wifiBox2").fadeIn(200);
        $(".wifiBox2 .event").hide().eq($(this).index()).show();

    });
    $(".wifiBox2 .closeDiv").click(function () {
        $(this).parent().fadeOut(200);
    });


    //产品详情页input加减
    $(".countBox .count .plus").click(function () {
        var input = $(".countBox .count .num");
        var val = input.val();
        val++;
        input.val(val);
        //        alert(this.id);
        //        $.ajax({
        //            url: "/JsData/order.aspx?action=UpdateCartCount&productId=" + this.id + "&count=" + val + "&time=" + new Date().getTime() + "",
        //            type: 'GET',
        //            success: function (msg) {
        //                var[] arr = this.id.split('_');
        //                location.href = "/mobile/product_details_" + arr[1] + ".html";
        //            }
        //        });
    });
    $(".countBox .count .minus").click(function () {
        var input = $(".countBox .count .num");
        var val = input.val();
        if (val > 0) { val--; }
        //        if (val == 0) {
        //            alert('Quantity必须大于0');
        //            return false;
        //        }
        input.val(val);

        //        $.ajax({
        //            url: "/JsData/order.aspx?action=UpdateCartCount&productId=" + this.id + "&count=" + val + "&time=" + new Date().getTime() + "",
        //            type: 'GET',
        //            success: function (msg) {
        //                 var[] arr = this.id.split('_');
        //                location.href = "/mobile/product_details_" + arr[1] + ".html";
        //            }
        //        });
    });
    //购物车
    $(function () {
        $(".check_label").each(function (i, elem) {
            if ($(this).find("input").get(0).checked == true) {
                $(this).addClass("on");
            }

        });
        $(".inner_footer .cal_cell .check_label").click(function () {
            if ($(this).hasClass("on")) {
                $(this).removeClass("on").find("input").get(0).checked = false;
            } else {
                $(this).addClass("on").find("input").get(0).checked = true;
            }

        });
        $(".shopCart .check_label").click(function () {
            if ($(this).hasClass("on")) {
                $(this).removeClass("on").find("input").get(0).checked = false;
                //更新选中状态到服务器                
                $.ajax({
                    url: "/JsData/order.aspx?action=UpdateSel&status=0&tempId=" + this.id + "&time=" + new Date().getTime() + "",
                    type: 'GET',
                    success: function (msg) {
                        location.href = "/mobile/car.html";
                    }
                });
            } else {
                $(this).addClass("on").find("input").get(0).checked = true;
                $.ajax({
                    url: "/JsData/order.aspx?action=UpdateSel&status=1&tempId=" + this.id + "&time=" + new Date().getTime() + "",
                    type: 'GET',
                    success: function (msg) {
                        location.href = "/mobile/car.html";
                    }
                });
            }

        });

        $(".shopCart .list .abs .price_bar .amount_bar a.addNum").click(function () {
            var input = $(this).parents(".amount_bar").find("input");
            var val = input.val();
            val++;
            input.val(val);
            $.ajax({
                url: "/JsData/order.aspx?action=UpdateCartCount&productId=" + this.id + "&count=" + val + "&time=" + new Date().getTime() + "",
                type: 'GET',
                success: function (msg) {
                    location.href = "/mobile/car.html";
                }
            });
        });
        $(".shopCart .list .abs .price_bar .amount_bar a.reduceNum").click(function () {
            var input = $(this).parents(".amount_bar").find("input");
            var val = input.val();
            if (val > 0) { val--; }
            if (val == 0) {
                alert('Quantity必须大于0');
                return false;
            }
            input.val(val);

            $.ajax({
                url: "/JsData/order.aspx?action=UpdateCartCount&productId=" + this.id + "&count=" + val + "&time=" + new Date().getTime() + "",
                type: 'GET',
                success: function (msg) {
                    location.href = "/mobile/car.html";
                }
            });
        });
    });
    //发票信息
    $(".invoice h2").click(function () {
        $(this).toggleClass("active").parents().siblings().find("h2").removeClass("active");
    })
    //Join
    $(".register ul li").click(function () {
        $(this).toggleClass("active").siblings().removeClass("active");
    });
    //我的卡
    $(".binding").click(function () {
        $(".cardBox").fadeIn(200);
        $(".mask").fadeIn(200);
    });
    $(".cardBox p .cancel").click(function () {
        $(".cardBox").fadeOut(200);
        $(".mask").fadeOut(200);
    });
    //发票信息
    $(".invoice .invo ul li").click(function () {
        $(this).toggleClass("active").siblings().removeClass("active");
        if (this.id == "user1") {
            document.getElementById("invoiceUserType").value = "1";
        }
        if (this.id == "user2") {
            document.getElementById("invoiceUserType").value = "2";
        }
        if (this.id == "content1") {
            document.getElementById("invoiceType").value = "1";
        }
        if (this.id == "content2") {
            document.getElementById("invoiceType").value = "2";
        }
        if (this.id == "content3") {
            document.getElementById("invoiceType").value = "3";
        }
        if (this.id == "content4") {
            document.getElementById("invoiceType").value = "4";
        }
        if (this.id == "content5") {
            document.getElementById("invoiceType").value = "5";
        }
        if (this.id == "content6") {
            document.getElementById("invoiceType").value = "6";
        }
    });
    //管理收货地址
    $(".manage .list .title .default").click(function () {
        $(this).toggleClass("on").parents(".manage .list").siblings().find(".default").removeClass("on");
        $.ajax({
            url: "/JsData/user.aspx?action=UpdateDefaultAddr&id=" + this.id + "&time=" + new Date().getTime() + "",
            type: 'GET',
            success: function (msg) {
            }
        });
    });
    //切换按钮
    $(".writeOrder .address .quan li .switch").click(function () {
        var typeName = this.id;
        var orderTotal = document.getElementById("hidOrderTotal").value * 1;
        if (typeName == "ticket") {
            var ticketValue = document.getElementById("hidTicket").value * 1;
            if (ticketValue == 0) {
                alert("没有可用的优惠券了");
            }
            else {
                var s = document.getElementById("hidZheKouType").value;
                $(this).toggleClass("on");
                if (document.getElementById("hidTicketUse").value == "1") {
                    document.getElementById("hidTicketUse").value = "0";
                    var zhekou = $("#zhekou").html().replace("¥", "") * 1;
                    zhekou -= ticketValue * 1;
                    $("#zhekou").html("$" + zhekou.toFixed(2));

                    var fact = orderTotal - zhekou; //$("#fact").html().replace("¥", "") * 1;
                    //                    fact += ticketValue * 1;
                    if (fact < 0) {
                        fact = 0;
                    }
                    $("#fact").html("$" + fact.toFixed(2));
                    document.getElementById("hidZheKouType").value = "0";
                } else {
                    if (s == 1) {
                        alert("只能选择1中折扣方式！");
                        $(this).toggleClass("on");
                        return false;
                    }
                    document.getElementById("hidZheKouType").value = "1";

                    var fact = $("#fact").html().replace("¥", "") * 1;
                    if (fact == 0) {
                        alert("当前实付金额为0$");
                        $(this).toggleClass("on");
                        return;
                    }
                    document.getElementById("hidTicketUse").value = "1";
                    var zhekou = $("#zhekou").html().replace("¥", "") * 1;

                    zhekou += ticketValue * 1;
                    $("#zhekou").html("$" + zhekou.toFixed(2));


                    fact -= ticketValue * 1;
                    if (fact < 0) {
                        fact = 0.00;
                    }
                    $("#fact").html("$" + fact.toFixed(2));

                }
                //alert(document.getElementById("hidTicketUse").value);
            }
        }
        if (typeName == "card") {
            var cardValue = document.getElementById("hidCard").value * 1;
            if (cardValue == 0) {
                alert("没有可用的优惠卡了");
            }
            else {
                var s = document.getElementById("hidZheKouType").value;
                $(this).toggleClass("on");
                if (document.getElementById("hidCardUse").value == "1") {
                    document.getElementById("hidCardUse").value = "0";
                    $("#zhekou").html("$0.00");
                    var fact = orderTotal;
                    $("#fact").html("$" + fact);
                    document.getElementById("hidZheKouType").value = "0";
                } else {
                    if (s == 1) {
                        alert("只能选择1中折扣方式！");
                        $(this).toggleClass("on");
                        return false;
                    }
                    document.getElementById("hidZheKouType").value = "1";

                    var fact = $("#fact").html().replace("¥", "") * 1;
                    if (fact == 0) {
                        alert("当前实付金额为0$");
                        $(this).toggleClass("on");
                        return;
                    }
                    document.getElementById("hidCardUse").value = "1";
                    var zhekou = $("#zhekou").html().replace("¥", "") * 1;
                    zhekou += cardValue * 1;
                    if (zhekou > fact) {
                        $("#zhekou").html("$" + fact.toFixed(2));
                        $("#fact").html("$0.00");
                    }
                    else {
                        $("#zhekou").html("$" + zhekou.toFixed(2));
                        fact -= cardValue * 1;
                        if (fact < 0) {
                            fact = 0.00;
                        }
                        $("#fact").html("$" + fact.toFixed(2));
                    }

                }

            }
        }
        if (typeName == "score") {
            var scoreValue = document.getElementById("hidScore").value;
            if (scoreValue == 0) {
                alert("没有可用的积分了");
            }
            else {
                var s = document.getElementById("hidZheKouType").value;
                $(this).toggleClass("on");
                if (document.getElementById("hidScoreUse").value == "1") {
                    document.getElementById("hidScoreUse").value = "0";
                    var zhekou = $("#zhekou").html().replace("¥", "") * 1;
                    zhekou -= scoreValue * 1;
                    $("#zhekou").html("$0.00");
                    var fact = orderTotal;
                    $("#fact").html("$" + fact.toFixed(2));
                    document.getElementById("hidZheKouType").value = "0";
                } else {
                    if (s == 1) {
                        alert("只能选择1中折扣方式！");
                        $(this).toggleClass("on");
                        return false;
                    }
                    document.getElementById("hidZheKouType").value = "1";

                    var fact = $("#fact").html().replace("¥", "") * 1;
                    if (fact == 0) {
                        alert("当前实付金额为0$");
                        $(this).toggleClass("on");
                        return;
                    }
                    document.getElementById("hidScoreUse").value = "1";
                    var zhekou = $("#zhekou").html().replace("¥", "") * 1;
                    zhekou += scoreValue * 1;
                    if (zhekou > fact) {
                        $("#zhekou").html("$" + fact.toFixed(2));
                        $("#fact").html("$0.00");
                    }
                    else {
                        $("#zhekou").html("$" + zhekou.toFixed(2));

                        fact -= scoreValue * 1;
                        if (fact < 0) {
                            fact = 0.00;
                        }
                        $("#fact").html("$" + fact.toFixed(2));
                    }

                }
                //alert(document.getElementById("hidScoreUse").value);
            }
        }
        if (typeName == "balance") {
            var balanceValue = document.getElementById("hidBalance").value;
            if (balanceValue == 0) {
                alert("没有可用的余额了");
            }
            else {
                var s = document.getElementById("hidZheKouType").value;
                $(this).toggleClass("on");
                if (document.getElementById("hidBalanceUse").value == "1") {
                    document.getElementById("hidBalanceUse").value = "0";

                    var zhekou = $("#zhekou").html().replace("¥", "") * 1;
                    $("#zhekou").html("$0.00");
                    //                    zhekou -= balanceValue * 1;
                    //                    $("#zhekou").html("$" + zhekou.toFixed(2));

                    //                    var fact = orderTotal - zhekou;
                    //                    if (fact < 0) {
                    //                        fact = 0;
                    //                    }
                    $("#fact").html("$" + orderTotal.toFixed(2));
                    document.getElementById("hidZheKouType").value = "0";
                } else {
                    if (s == 1) {
                        alert("只能选择1中折扣方式！");
                        $(this).toggleClass("on");
                        return false;
                    }
                    document.getElementById("hidZheKouType").value = "1";

                    document.getElementById("hidBalanceUse").value = "1";
                    var fact = $("#fact").html().replace("¥", "") * 1;
                    if (fact == 0) {
                        alert("当前实付金额为0$");
                        $(this).toggleClass("on");
                        return;
                    }

                    var zhekou = $("#zhekou").html().replace("¥", "") * 1;
                    zhekou += balanceValue * 1;
                    if (zhekou > fact) {
                        $("#zhekou").html("$" + fact.toFixed(2));

                        fact = 0;
                        $("#fact").html("$" + fact.toFixed(2));
                    }
                    else {
                        $("#zhekou").html("$" + zhekou.toFixed(2));

                        fact -= balanceValue * 1;
                        if (fact < 0) {
                            fact = 0.00;
                            $("#zhekou").html("$" + zhekou.toFixed(2));
                        }
                        $("#fact").html("$" + fact.toFixed(2));
                    }

                }
                //alert(document.getElementById("hidBalanceUse").value);
            }
        }
    })
    //on
    $(".guige ul li").click(function () {
        $(this).addClass("on").siblings().removeClass("on");
        var arr = this.id.split('_');
       document.getElementById("priceItem").value = arr[0];
        $("#currentPrice").html("$" + arr[1]);
    });

    $(window).scroll(function () {
        var scrollHeight = $(document).scrollTop();
        if (scrollHeight > 0) {
            $('.index_header').addClass('fix');
        } else {
            $('.index_header').removeClass('fix');
        }
    });

    $(".security .item .labelBox").click(function () {
        $(this).find(".circle").toggleClass("active");
    })
});



