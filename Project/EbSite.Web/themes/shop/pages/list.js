jQuery(function ($) {

    //上一页 下一页
    var upage = $(".uppage").attr('href');
    var npage = $(".nextpage").attr('href');

    if (upage != "" && upage != undefined) {
        $("#uppg").attr('href', upage);
    }
    else {
        $("#uppg").attr({ style: "visibility:hidden" });

    }


    if (npage != "" && npage != undefined) {
        $("#nextpg").attr('href', npage);
    }
    else {
        $("#nextpg").hide();
    }


    //排序
    var orderby = GetUrlParams("orderby");

    var special = GetUrlParams("special");
    var brand = GetUrlParams("brand");
    var valueStr = GetUrlParams("valueStr");
    var iurl = window.location.href;
    if (orderby == "" && special == "" && brand == "" && valueStr == "") {
        $("#sort1").attr("href", iurl + "?orderby=1");
        $("#sort2").attr("href", iurl + "?orderby=2");
        $("#sort3").attr("href", iurl + "?orderby=3");
        $("#sort4").attr("href", iurl + "?orderby=4");
        $("#sort5").attr("href", iurl + "?orderby=5");
    }
    else if (orderby == "") {
        $("#sort1").attr("href", iurl + "&orderby=1");
        $("#sort2").attr("href", iurl + "&orderby=2");
        $("#sort3").attr("href", iurl + "&orderby=3");
        $("#sort4").attr("href", iurl + "&orderby=4");
        $("#sort5").attr("href", iurl + "&orderby=5");
    }
    else {

        var ExUrl = "?"; //window.location.host + window.location.pathname +
        var xiurl = "";
        if (special != "") {
            xiurl += "&special=" + special;
        }
        if (brand != "") {
            xiurl += "&brand=" + brand;
        }
        if (valueStr != "") {
            xiurl += "&valueStr=" + valueStr;
        }
        if (xiurl !== "") {
            xiurl = xiurl.substring(1);
        }
        var url = ExUrl + xiurl;
        if (url.length > 1)
            url = url + "&";
        $("#sort1").attr("href", url + "orderby=1");
        $("#sort2").attr("href", url + "orderby=2");
        $("#sort3").attr("href", url + "orderby=3");
        $("#sort4").attr("href", url + "orderby=4");
        $("#sort5").attr("href", url + "orderby=5");

        $("#sort" + orderby).parent().addClass("cur");
    }

    //去掉商品筛选的最后一条 虚线

    $(".soclass div").first().removeClass("b");
});


/***加入对比***/
var COOKIE_NAME = "contrast_cookie";
InitContrastList();
function InitContrastList()
{
    var tmp_html = "";
    var tmpCookVal = GetCookies(COOKIE_NAME);
    if (tmpCookVal != "" && tmpCookVal != null && tmpCookVal != undefined) {
        var arrList = tmpCookVal.split("※");
        if (arrList != null && arrList != undefined && arrList.length > 0) {
            //判断是否显示
            if ($("#pop-compare").css("display") == "none") {
                $("#pop-compare").fadeIn(300);
            }
            if (arrList.length > 2)
            {
                $("#goto-contrast").attr("class", "btn-compare-b compare-active");
            }
            for (var i = 1; i < 5; i++) {
                if (arrList.length >= i) {
                    var itemhtml = arrList[i - 1];
                    if (itemhtml != "" && itemhtml != undefined) {
                        tmp_html += "<dl class=\"item-empty\" onmouseover='showhidelink(this,1)' onmouseout='showhidelink(this,0)'>" + itemhtml + "</dl>";
                        //反选已选择项
                        var tmpid = $("<div>" + itemhtml + "</div>").children("dt").attr("tid");
                        if (tmpid != undefined && tmpid != "")
                        {
                            $("#comp_" + tmpid).attr("class", "btn-compare  btn-compare-s-active");
                        }
                    }
                    else {
                        tmp_html += "<dl class=\"item-empty\"><dt>" + i + "</dt><dd>您可以继续添加</dd></dl>";
                    }
                }
                else {
                    tmp_html += "<dl class=\"item-empty\"><dt>" + i + "</dt><dd>您可以继续添加</dd></dl>";
                }
            }
            if (tmp_html != "") {
                $("#diff-items").html(tmp_html);
            }
        }
    }
    else {
        $("#diff-items").html("<dl class=\"item-empty\"><dt>1</dt><dd>您可以继续添加</dd></dl><dl class=\"item-empty\"><dt>2</dt><dd>您可以继续添加</dd></dl><dl class=\"item-empty\"><dt>3</dt><dd>您可以继续添加</dd></dl><dl class=\"item-empty\"><dt>4</dt><dd>您可以继续添加</dd></dl>");
    }
}
function showhidelink(obj,flag)
{
    if (flag > 0) {
        $(obj).children("dd").children("span").children("a").show();
    }
    else {
        $(obj).children("dd").children("span").children("a").hide();
    }
}
function AppendContrast(obj)
{
    //判断是否显示
    if ($("#pop-compare").css("display") == "none") {
        $("#pop-compare").fadeIn(300);
    }

    var tid = $(obj).attr("id").replace("comp_", "");
    //取出Cookie
    var tmpCookVal = GetCookies(COOKIE_NAME);
    //判断是否重复添加
    if (tmpCookVal.toLowerCase().indexOf("<dt tid=\""+tid+"\">")>-1)
    {
        //$(".pop-compare-tips").text("此商品已经添加过，不能重复添加！").fadeIn(300);
        ////3秒后自动隐藏
        //window.setTimeout(function () { $(".pop-compare-tips").fadeOut(500) }, 3000);

        var tmpCookVal = $.trim(GetCookies(COOKIE_NAME).toString().toLowerCase());
        //var tVal = $.trim(($(obj).parent("span").parent("dd").parent("dl").html().toString().toLowerCase() + "※").replace("<a class=\"del-comp-item\" style=\"display: inline;\" onclick=\"deleteitem(this)\">删除</a>", "<a class=\"del-comp-item\" style=\"display:none;\" onclick=\"deleteitem(this)\">删除</a>"));
        var tVal = $.trim($("#diff-items").children("dl").children("dt[tid=\"" + tid + "\"]").parent("dl").html().toLowerCase() + "※");
        tmpCookVal = tmpCookVal.replace(tVal, "").toLowerCase();
        if (tmpCookVal == "" || tmpCookVal == undefined || tmpCookVal == null) {
            $("#goto-contrast").attr("class", "btn-compare-b");
        }
        else {
            var tmparr = tmpCookVal.split("※");
            if (tmparr.length < 3) {
                $("#goto-contrast").attr("class", "btn-compare-b");
            }
        }
        $(obj).attr("class", "btn-compare");
        SetCookies(COOKIE_NAME, tmpCookVal, 1);
        InitContrastList();

        return false;
    }

    var $clist = $(obj).parent("div").parent("dl").parent("li");
    //图片
    var $img = $clist.children("dl:eq(0)").children("a").children("img").attr("src");
    var imgHref = $clist.children("dl:eq(0)").children("a").attr("href");
    //标题
    $clist.children("dl:eq(1)").children("a").attr("class", "diff-item-name");
    var $title = $clist.children("dl:eq(1)").html();
    //价格
    var $price = $clist.children("dl:eq(2)").children("span").text();
    
    var tmp_html = "<dt tid=\""+tid+"\"><a href=\"" + imgHref + "\" target=\"_blank\"><img width=\"38\" src=\"" + $img + "\" heigh=\"48px\"></a></dt>";
    tmp_html += "<dd>" + $title + "<span class=\"p-price\"><strong>" + $price + "</strong><a class=\"del-comp-item\" style=\"display: none;\" onclick=\"deleteitem(this)\">删除</a></span>" + "</dd>";

    //$("#diff-items").children("dl:eq(0)").html(tmp_html);
    
    if (tmpCookVal != "" && tmpCookVal != null && tmpCookVal != undefined) {
        tmp_html = tmpCookVal + tmp_html + "※";
    }
    else {
        tmp_html = tmp_html + "※";
    }

    var arrList = tmp_html.split("※");
    if (arrList.length >5) {
        $(".pop-compare-tips").text("对比栏已满，您可以删除不需要的栏内商品再继续添加哦！").fadeIn(300);
        //5秒后自动隐藏
        window.setTimeout(function () { $(".pop-compare-tips").fadeOut(500) }, 5000);
    }
    else {
        if (arrList.length > 2)
        {
            $("#goto-contrast").attr("class", "btn-compare-b compare-active");
        }
        SetCookies(COOKIE_NAME, tmp_html, 1);
        $(obj).attr("class", "btn-compare  btn-compare-s-active");
        if (arrList != null && arrList != undefined && arrList.length > 0) {
            //<dl class="item-empty"><dt>1</dt><dd>您可以继续添加</dd></dl>l
            tmp_html = "";
            for (var i = 1; i < 5; i++) {
                if (arrList.length >= i) {
                    if (arrList[i - 1] != "" && arrList[i - 1] != undefined) {
                        tmp_html += "<dl class=\"item-empty\" onmouseover='showhidelink(this,1)' onmouseout='showhidelink(this,0)'>" + arrList[i - 1] + "</dl>";
                    }
                    else {
                        tmp_html += "<dl class=\"item-empty\"><dt>" + i + "</dt><dd>您可以继续添加</dd></dl>";
                    }
                }
                else {
                    tmp_html += "<dl class=\"item-empty\"><dt>" + i + "</dt><dd>您可以继续添加</dd></dl>";
                }
            }
            if (tmp_html != "") {
                $("#diff-items").html(tmp_html);
            }
        }
        else {
            $(".pop-compare-tips").text("操作失败").fadeIn(300);
            //5秒后自动隐藏
            window.setTimeout(function () { $(".pop-compare-tips").fadeOut(500) }, 5000);
        }
    }
    return false;
}
function deleteitem(obj)
{
    var tmpCookVal = $.trim(GetCookies(COOKIE_NAME).toString().toLowerCase());
    var tVal = $.trim(($(obj).parent("span").parent("dd").parent("dl").html().toString().toLowerCase() + "※").replace("<a class=\"del-comp-item\" style=\"display: inline;\" onclick=\"deleteitem(this)\">删除</a>", "<a class=\"del-comp-item\" style=\"display: none;\" onclick=\"deleteitem(this)\">删除</a>"));
    tmpCookVal = tmpCookVal.replace(tVal, "").toLowerCase();
    if (tmpCookVal == "" || tmpCookVal == undefined || tmpCookVal == null) {
        $("#goto-contrast").attr("class", "btn-compare-b");
    }
    else {
        var tmparr = tmpCookVal.split("※");
        if (tmparr.length <3)
        {
            $("#goto-contrast").attr("class", "btn-compare-b");
        }
    }
    var tmpid = $("<div>" + tVal + "</div>").children("dt").attr("tid");
    if (tmpid != undefined && tmpid != "") {
        $("#comp_" + tmpid).attr("class", "btn-compare");
    }
    
    SetCookies(COOKIE_NAME, tmpCookVal, 1);
    InitContrastList();
}
function gotocompare(obj)
{
    var link = $(obj).attr("class");
    if (link == "btn-compare-b compare-active")
    {
        var initLink = $(obj).attr("hrefex");
        var $dtList = $("#diff-items").children("dl").children("dt[tid!='']");
        if ($dtList != null && $dtList != undefined&&$dtList.length>1)
        {
            var ids = "";
            $.each($dtList, function (i, item) {
                var tmpid = $(item).attr("tid");
                if (tmpid != undefined) {
                    ids += $(item).attr("tid") + ",";
                }
                else {
                    ids += "0,";
                }
            });
            ids = ids.substr(0, ids.length - 1);
            //
            window.open($(obj).attr("hrefex") + "?t=" + ids, "");
        }
    }
}
function SetCookies(c_name, value, expiredays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + expiredays);
    document.cookie = c_name + "=" + escape(value) + ((expiredays == null) ? "" : ";expires=" + exdate.toGMTString());
}
function GetCookies(c_name) {
    if (document.cookie.length > 0) {　　//先查询cookie是否为空，为空就return ""
        c_start = document.cookie.indexOf(c_name + "=")　　//通过String对象的indexOf()来检查这个cookie是否存在，不存在就为 -1　　
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1　　//最后这个+1其实就是表示"="号啦，这样就获取到了cookie值的开始位置
            c_end = document.cookie.indexOf(";", c_start)　　//其实我刚看见indexOf()第二个参数的时候猛然有点晕，后来想起来表示指定的开始索引的位置...这句是为了得到值的结束位置。因为需要考虑是否是最后一项，所以通过";"号是否存在来判断
            if (c_end == -1) c_end = document.cookie.length
            return unescape(document.cookie.substring(c_start, c_end))　　//通过substring()得到了值。想了解unescape()得先知道escape()是做什么的，都是很重要的基础，想了解的可以搜索下，在文章结尾处也会进行讲解cookie编码细节
        }
    }
    return ""
}
function ClearCookies()
{
    SetCookies(COOKIE_NAME, "", -1);
    $("a[id^=\"comp_\"]").attr("class", "btn-compare");
    $("#goto-contrast").attr("class", "btn-compare-b");
    $("#diff-items").html("<dl class=\"item-empty\"><dt>1</dt><dd>您可以继续添加</dd></dl><dl class=\"item-empty\"><dt>2</dt><dd>您可以继续添加</dd></dl><dl class=\"item-empty\"><dt>3</dt><dd>您可以继续添加</dd></dl><dl class=\"item-empty\"><dt>4</dt><dd>您可以继续添加</dd></dl>");
}
function hidecontrast(flag)
{
    if (flag > 0) {
        $("#pop-compare").fadeIn(300);
    }
    else {
        $("#pop-compare").fadeOut(300);
    }
}
/***加入对比***/