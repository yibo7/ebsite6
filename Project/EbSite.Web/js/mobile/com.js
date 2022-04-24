
//window.onload = OnPageLoad;
//function OnPageLoad() {
//    GetUserLoginInfo();

//}
Zepto(function ($) {
    GetUserLoginInfo();

    var scounturl = SiteConfigs.UrlIISPath + "count.ashx?";
    if (scountpram)
        scounturl = scounturl + scountpram;
    run_ajax_async_json(scounturl, "", null);
})
//从url中获取文件类型
function get_type_of_url(sUrl) {
    var strType = "";
    if (sUrl != "") {
        var iLastIndex = sUrl.lastIndexOf(".") + 1;
        strType = sUrl.substring(iLastIndex, sUrl.length);

    }
    if (strType.length > 5) return "";
    return strType;
}
function GetUserLoginInfo() {
    if ($("#Mlogin_info").length > 0) {
        var url = SiteConfigs.UrlIISPath + "ajaxget/CurrentUser.ashx?" + Math.random();
        var userinfo = run_ajax_unasync(url);
        if (userinfo != undefined && userinfo != "" && userinfo != "no") {
            var sHtml = "";
            var strs = new Array();
            strs = userinfo.split("|");
           
            var CurrentUserNiName = strs[0];
            sHtml += "欢迎您," + CurrentUserNiName + " ";
            $("#Mlogin_info").html(sHtml);
        }  
    }

}

function inisite(siteid, themepath) {
    SiteConfigs.id = siteid;
    SiteConfigs.ThemePath = themepath;
}

//运行同步http请求
function run_ajax_unasync(url) {
  
    var html = $.ajax({
        url: url,
        //beforeSend: onAjaxBeforeSend,
        async: false
    }).responseText;
   
    return html;
}
//同步json
function run_ajax_unasync_json(url, postobj) {
    var vlMsg;
    var obpram = postobj;
    if (postobj == null || postobj == "")
        obpram = {};
   
    $.ajax({
        url: url,
        async: false,
        data: JSON.stringify(obpram),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
//        beforeSend: onAjaxBeforeSend,
        success: function (result) {
            vlMsg = result;
        },
        error: function (xhr, ajaxOptions, thrownError) {

            //alert("调用ajax发生错误:" + thrownError);
        }

    });
    return vlMsg;
}

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

            //alert("调用ajax发生错误:" + thrownError);
        }

    });
}

function IISPath() {
    return SiteConfigs.UrlIISPath;
}


//反向选取
function on_checkback(ob) {
    var obHtml = $(ob);

    obHtml.find("input[type=checkbox]").each(
		function (i) {
		    if (this.checked) {
		        this.checked = false;
		    }
		    else {
		        this.checked = true;
		    }
		});
}


function GetModulePath() {
    var url = "";
    if (arguments.length == 1) { //指定模块
        var pram = { mid: arguments[0], siteid: SiteConfigs.id };

        var msgObj = runebws("GetModulePath", pram);
        //alert(msgObj.Message)

        if (msgObj != null || msgObj != undefined) {
            url = msgObj.d.Message;

        }
        
    }
    else if (arguments.length == 2) { //指定模块
       
        var pram = { mid: arguments[0], siteid: arguments[1] };

        var msgObj = runebws("GetModulePath", pram);
        //alert(msgObj.Message)
        if (msgObj != null || msgObj != undefined) {
            url = msgObj.d.Message;
        }
    }
    else { //当前模块
        var scriptob = $("#ebsitemodulescript").attr("src");

        if (scriptob != null && scriptob != undefined) {
            url = scriptob.replace("js/commmobile.js", "");
        }
    }


    return url;
}

function runws(funname, postobj, backfun) {
  
    if (arguments.length == 2) {
        var url = GetModulePath() + "ajaxget/api.asmx/" + funname;
        var vl = run_ajax_unasync_json(url, postobj);
        return vl;
    }
    else if (arguments.length == 3) {
        var url = GetModulePath() + "ajaxget/api.asmx/" + funname;

        run_ajax_async_json(url, postobj, backfun);
    }
    else if (arguments.length == 4) {
       
        var url = GetModulePath(arguments[0]) + "ajaxget/api.asmx/" + arguments[1];
       
        run_ajax_async_json(url, arguments[2], arguments[3]);
    }
    else if (arguments.length == 5) {
      
        var url = GetModulePath(arguments[0], arguments[4]) + "ajaxget/api.asmx/" + arguments[1];
        alert(url);
        run_ajax_async_json(url, arguments[2], arguments[3]);
    }


}
//运行ebsite本身的web服务
function runebws(funname, postobj, backfun) {
    var url = SiteConfigs.UrlIISPath + "api/ws.asmx/" + funname;
    if (arguments.length == 2) {
        var vl = run_ajax_unasync_json(url, postobj);
        return vl;
    }
    else if (arguments.length == 3) { //异步
       
        run_ajax_async_json(url, postobj, backfun);
    }

}

//面板弹出方法，clickbtncss 触发按钮样式，panelcss页板内容样式, contentcss 推移元素样式,way推出方式，right为右边推出，left为左边推出
function toggleright2(clickbtncss, panelcss, contentcss, way,siteid) {
    In.ready('gmue-touch', 'gmue-throttle', 'gmue-scrollStop', 'gmue-ortchange', 'gmue-matchMedia', 'gmuw-panel', function () {
        $(function ($) {
            $('.' + panelcss).panel({
                contentWrap: $('.' + contentcss)
            });
            //点击事件
            $('.' + clickbtncss).on('click', function () {
                var tid = $(this).attr("id");
                var tmpURL = $(this).attr("url");
                runebws("GetClassMobile", { "pid": tid, "siteid": siteid }, function (data) {
                    var result = data.d;
                    if ($("<div>"+result+"</div>").children("ul").children("li").length > 0) {
                        $(".rightpanel").html(result);
                        //弹出面板
                        $('.' + panelcss).panel('toggle', 'push', way);
                    }
                    else {
                        if (tmpURL != undefined && tmpURL != "") {
                            window.location.href = tmpURL;
                        }
                        else {
                            alert("URL错误!");
                        }
                    }
                });
            });
        } (Zepto));
    });
}

//面板弹出方法，clickbtncss 触发按钮样式，panelcss页板内容样式, contentcss 推移元素样式,way推出方式，right为右边推出，left为左边推出
function toggleright(clickbtncss, panelcss, contentcss, way) {
    In.ready('gmue-touch', 'gmue-throttle', 'gmue-scrollStop', 'gmue-ortchange', 'gmue-matchMedia', 'gmuw-panel', function () {
        $(function ($) {
            $('.' + panelcss).panel({
                contentWrap: $('.' + contentcss)
            });

            $('.' + clickbtncss).on('click', function () {
                $('.' + panelcss).panel('toggle', 'push', way);
            });
        } (Zepto));
    });
}
//提示窗口 dialogDiv 弹出层的Div的id iWidth 宽度  iHeight 高度 //reg.aspx mobileaskpost.aspx
function m_dialog(dialogDiv, iWidth, iHeight) {
    In.ready('gmuw-dialog', 'gmue-highlight', 'gmue-parseTpl', function () {
        $('#' + dialogDiv).dialog({
            autoOpen: false,
            closeBtn: true,
            scrollMove: false,
            width: +iWidth,
            height: +iHeight,
            buttons: {
                "关闭": function () {
                    this.close();
                }
            }
        });
    });
}


//function m_dialog(dialogDiv, iWidth, iHeight) {
//    In.ready('gmuw-dialog', 'gmue-highlight', 'gmue-parseTpl', function () {
//        $('#' + dialogDiv).dialog({
//            autoOpen: false,
//            closeBtn: false,
//            scrollMove: false,
//            width: +iWidth,
//            height: +iHeight,
//            buttons: {
//                "关闭": function () {
//                    this.close();
//                }
//            }
//        });
//    });
//}

function loadpage(box, btn, boxitem) {

    $(box).infinitescroll({
        navSelector: '.PagesClass', //分页导航的选择器
        nextSelector: '.PagesClass td .nextpage', //下页连接的选择器
        itemSelector: boxitem,      //你要检索的所有项目的选择器,
        loadingImg: "/images/loading2.gif",
        loadingText: "加载中...",
        animate: true,
        extraScrollPx: 300,
        clickBtn: btn,
        errorCallback: function () { //到最后一页，没有数据可以载入时触发
            var obbtn = $(btn);
            obbtn.html("已经是最后一条记录了!");
            obbtn.unbind("click");
            
        }

    }, function (newElements) { });

}

////////////////模块工具条控件js///////////////////
function onopenmdsearch() {
    var ob = $(".w-home-search");
    if (ob.css("display") == "none") {
        ob.css("display", "block");
    } else {
        ob.css("display", "none");
    }
}

function onselmdcheckbox() {

    $("body").find("input[name=cbdataid]").each(
		function (i) {
		    if (this.checked) {
		        this.checked = false;
		    }
		    else {
		        this.checked = true;
		    }
		});
}

function onmddelete() {
    return confirm("确定要删除所选数据吗？");
}

function onmdedit(url) {
    var isselone = 0;
    var dataid = 0;
    $("body").find("input[name=cbdataid]").each(
		function (i) {
		    if (this.checked) {
		        isselone++;
		        dataid = $(this).val();
		    }
		});

    if (isselone == 1) {

        location.href = url + dataid;
    }
    else if (isselone == 0) {
        alert("请选择一条记录后再点编辑！");
    }
    else if (isselone > 1) {
        alert("不能同时编辑多条数据，请选择一条！");
    }
}

function onmdadd(url) {
    location.href = url;
}

function onmdsubmenusClick() {
    $('#ebSubMenus').dialog('open', 20, 20);
}
////////////////end模块工具条控件js///////////////////


/////////////刷新本页面 begin/////////////////

function Refesh() {
    var url = location.href;
    if (url.lastIndexOf("#") > 0) {
        url = url.substring(0, url.length - 1);
    }

    document.location.href = url;
}
/////////////end 刷新////////////////



//pos = -1 为添加,pos=0为插入
function add_selecte_option(obID, svalue, stext, pos) {

    var strName = stext;
    var strValue = svalue;
    $("#" + obID).append("<option pram=\"" + pos + "\" value=\"" + strValue + "\">" + strName + "</option>");
}
// 删除选项,type 为采用不同的方法
function delete_selecte_option(obID, keepindex) {

    $("#" + obID).find("option").each(
		function (i) {

		    if (i != keepindex)
		        $(this).remove();

		}
		);
}
//获取下拉列表项
function get_selected_value(ob) {

    return ob.options[ob.selectedIndex].value;
}
function get_selected_text(ob) {

    return ob.options[ob.selectedIndex].text;
}
function set_selected_value(ob, value) {
    $(ob).attr("value", value);

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
