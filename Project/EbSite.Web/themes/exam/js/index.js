
jQuery(function ($) {
    //    $('.bbs-ctent .left-bbs img').attr("onerror", "this.onerror='';this.src='images/nopic.gif';");
    $("#btnSubmit").hover(function () {
        //鼠标移入
        $(this).attr("class", "jiaoex");
    }, function () {
        //鼠标移出
        $(this).attr("class", "jiao");
    });
    //选项ABCD
    $(".A").hover(function () {
        $(this).attr("class", "AA");
    }, function () {
        $(this).attr("class", "A");
    });
    // 上面的选择框
    $(".xuanz").hover(function () {
        $(this).attr("class", "xianz2");
    }, function () {
        $(this).attr("class", "xuanz");
    });

    $(".bia1-6").hover(
    function () {
        $(this).attr("class", "li-6-6");
    }, function () {
        $(this).attr("class", "bia1-6");
    });
    $(".li-2").hover(function () {
        $(this).attr("class", "li-2-2")
    }, function () {
        $(this).attr("class", "li-2");
    });
    $(".li-1").hover(function () {
        $(this).attr("class", "li-1-1")
    }, function () {
        $(this).attr("class", "li-1");
    });


    $(".li-3").hover(function () {
        $(this).attr("class", "li-3-3")
    }, function () {
        $(this).attr("class", "li-3");
    });
    $(".li-4").hover(function () {
        $(this).attr("class", "li-4-4")
    }, function () {
        $(this).attr("class", "li-4");
    });
    $(".li-5").hover(function () {
        $(this).attr("class", "li-5-5")
    }, function () {
        $(this).attr("class", "li-5");
    });

});
