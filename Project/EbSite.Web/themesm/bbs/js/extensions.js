
Zepto(function ($) {
    $("embed").attr("width", "100%");
    //$('#btnallclass').html("分类");
    $('#btnallclass').click(function () {
        location.href = $(this).attr("url");
    });
    $('#gotoindex').click(function () {
        location.href = $(this).attr("url");
    });

    $(".backpage").click(function () {
        history.go(-1);
    });

//    In.ready('gmuw-toolbar', function () {
//     
//    });


})
