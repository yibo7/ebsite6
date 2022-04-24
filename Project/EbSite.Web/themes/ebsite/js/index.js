
jQuery(function ($) {
    //    $('.bbs-ctent .left-bbs img').attr("onerror", "this.onerror='';this.src='images/nopic.gif';");
    $("#btnSubmit").hover(function () {
        //鼠标移入
        $(this).attr("class", "jiaoex");
    }, function () {
        //鼠标移出
        $(this).attr("class", "jiao");
    });
    

});


