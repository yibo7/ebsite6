

function getFileExt(str) {
    var d = /\.[^\.]+$/.exec(str);
    return d;
}

function HtmlDecode(text) {

    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>').replace(/\n/g, '<br>').replace(/\t/g, '<br>').replace(/\r/g, '');

}
function get_selected_value(ob) {

    return ob.options[ob.selectedIndex].text;
}

//运行ebsite本身的web服务
function runebws(funname, postobj, backfun) {
    var url = "/api/ws.asmx/" + funname;
    if (arguments.length == 2) {
        var vl = run_ajax_unasync_json(url, postobj);
        return vl;
    }
    else if (arguments.length == 3) { //异步

        run_ajax_async_json(url, postobj, backfun);
    }
}
function runws(funname, postobj, backfun) {
    var url = "../ajaxget/api.asmx/" + funname;
    run_ajax_async_json(url, postobj, backfun);

}
//异步json
function run_ajax_async_json(url, postobj, backfun) {

    var obpram = postobj;
    if (postobj == null || postobj == "")
        obpram = {};
    $.ajax({
        url: url,
        data: JSON.stringify(obpram),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (backfun != null) backfun(result);
        },
        error: function (xhr, ajaxOptions, thrownError) {

            alert("调用ajax发生错误:" + thrownError);
        }

    });
}
//获取url?号后的参数
function GetUrlParams(ParamName) {
    var URLParams = new Object();
    var aParams = document.location.search.substr(1).split('&');
    for (i = 0; i < aParams.length; i++) {
        var aParam = aParams[i].split('=');
        URLParams[aParam[0]] = aParam[1];
    }

    var sValue = URLParams[ParamName];
    if (sValue == undefined)
        return "";
    return sValue;
}

function getdatetime() {
    var myDate = new Date();
    return myDate.toLocaleDateString() + " " + myDate.toLocaleTimeString();
}

//信息提示
var g_blinkswitch = 0;
var g_blinktitle = document.title;
var TimeoutShow = 0;
function ClearBlinkNewMsg() {
    document.title = g_blinktitle;
    clearTimeout(TimeoutShow);
}
function blinkNewMsg() {

    document.title = g_blinkswitch % 2 == 0 ? "【您有新的信息】" : g_blinktitle;
    g_blinkswitch++;
    TimeoutShow = setTimeout(blinkNewMsg, 1000);
}
///////end/////////
function CloseForm() {
    if(confirm("确定要关闭窗口吗?"))
    {
//        self.opener = null;
        self.close();
    }
  
}