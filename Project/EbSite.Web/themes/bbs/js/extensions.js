In.add('bbsindexjs', { path: SiteConfigs.ThemePath + 'js/index.js', type: 'js', charset: 'utf-8' });
/*industry sort*/
jQuery(function ($) {
    $("a[href*='http://']:not([href*='" + location.hostname + "']),[href*='https://']:not([href*='" + location.hostname + "'])").addClass("external").attr("target", "_blank");
    $(".ebacss").each(function (i) {
        $(this).attr("id", "ebabox" + i);
    });
    
});
function gotoeba(iIndex) {
    In.ready('jqscroll', function () {

        $("#ebabox" + iIndex).ScrollTo(800);

    });
}
function ebshare() {
    document.write('<div id="bdshare" class="bdshare_t bds_tools get-codes-bdshare">');
document.write('<span class="bds_more">分享到：</span>');
document.write('<a class="bds_qzone"></a>');
document.write('<a class="bds_tsina"></a>');
document.write('<a class="bds_tqq"></a>');
document.write('<a class="bds_renren"></a>');
document.write('<a class="bds_t163"></a>');
document.write('<a class="shareCount"></a>');
document.write('</div>');
document.write('<script type="text/javascript" id="bdshare_js" data="type=tools&amp;uid=353143" ></script>');
document.write('<script type="text/javascript" id="bdshell_js"></script>');
document.write('<script type="text/javascript">');
document.write('document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + Math.ceil(new Date()/3600000)');
document.write('</script>');
    
    
}