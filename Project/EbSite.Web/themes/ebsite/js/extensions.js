In.add('bbsindexjs', { path: SiteConfigs.ThemePath + 'js/index.js', type: 'js', charset: 'utf-8' });
/*industry sort*/
jQuery(function ($) {
    $(".ebacss").each(function(i) {
        $(this).attr("id", "ebabox"+i);
    });
});

function gotoeba(iIndex) {
    In.ready('jqscroll', function () {

        $("#ebabox" + iIndex).ScrollTo(800);

    });
}

function classcolor() {
    var obj = $(".subtitle a");

    for (var len = obj.length, i = len; i--; ) {
        obj[i].style.color = "#" + randomcolor();
    }
}

function tagcolor() {

    var obj = $(".datalist span");

    for (var len = obj.length, i = len; i--; ) {
        obj[i].style.left = rand(600) + "px";
        obj[i].style.top = rand(400) + "px";
        obj[i].className = "color" + rand(5);
        obj[i].style.zIndex = rand(5);
        obj[i].style.fontSize = rand(12) + 12 + "px";
        obj[i].style.color = "#" + randomcolor();
    }

}
function rand(num) {
    return parseInt(Math.random() * num + 1);
}
function randomcolor() {
    var str = Math.ceil(Math.random() * 16777215).toString(16);
    if (str.length < 6) {
        str = "0" + str;
    }
    return str;
}