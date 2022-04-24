
/*让某个元素绝对距顶：
$("#test").TopFixed({
top:500,
showtype: 0
});*/
(function ($) {
    $.fn.TopFixed = function (options) {
        options = options || {};
        var defaults = {
            top: 100,       //当滚动条滚到离顶部多少像素时显示
            showtype: 0 //0为正常hide show 1为fadeIn out
        };
        var settings = $.extend(defaults, options);
        $(this).each(function () {
            $(this).css("left", "0");
            $(this).css("top", "0");
            $(this).css("position", "fixed");
            $(this).css("top", "expression(eval(document.documentElement.scrollTop)) !important");
            var _thisob = this;
            $(window).bind('scroll', function () {

                if (timeoutscroll) { clearTimeout(timeoutscroll); }
                timeoutscroll = setTimeout(function () {

                    var st = $(document).scrollTop(), winh = $(window).height();

                    if (st > settings.top) {

                        if (settings.top == 0)
                            $(_thisob).show();
                        else
                            $(_thisob).fadeIn(500);
                    }
                    else {
                        if (settings.top == 0)
                            $(_thisob).hide();
                        else
                            $(_thisob).fadeOut(500);
                    }


                }, 100);

            });




        });
    };
})(jQuery);

