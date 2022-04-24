jQuery(function ($) {

    var re = new RegExp("^([A-Za-z0-9-/]+)(-small)([.A-Za-z]+)$");
    var firstpic = $("#p0").attr("src");

    var r = firstpic.match(re);
    var ifirstpic = r[1] + "-big" + r[3];


    $("#biger img").attr("src", ifirstpic);

    $("#list-img img").unbind("click").bind("click", function () {

        var ind = $("#list-img img").index($(this)),
             src = $(this).attr('src');


        $("#list-img li").each(function (i) {
            $(this).removeClass("hover");
        });
        $(this).parent().addClass("hover");


        var re = new RegExp("^([A-Za-z0-9-/]+)(-small)([.A-Za-z]+)$");


        var r = src.match(re);
        var xfirstpic = r[1] + "-big" + r[3];
        $("#biger img").attr("src", xfirstpic).attr("index", $(this).parent().attr("index"));



    });
});