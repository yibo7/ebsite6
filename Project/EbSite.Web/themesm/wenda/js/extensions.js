
Zepto(function ($) {

    $('#btnallclass').html("分类");
    $('#btnallclass').click(function () {
        location.href = $(this).attr("url");
    });

    $(".backpage").click(function () {
        history.go(-1);
    });

    In.ready('gmuw-toolbar', function () {

        //创建toolbar
        //        $('#toolbar').toolbar();

    });


})

function OpenSearch(obid) {
    var ob = $("#" + obid);
    if (ob.css("display") == "none") {
        ob.css("display", "block");
    } else {
        ob.css("display", "none");
    }
}
