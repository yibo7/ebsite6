
var SPLITTER_RECORD = "{\\r\\r*\\r\\r}";
var SPLITTER_FIELD = "{\\r*\\r}";
function inisite(siteid,themepath) {
    SiteConfigs.id = siteid;
    SiteConfigs.ThemePath = themepath;
    //document.writeln("<script type=\"text/javascript\" src=\"" + SiteConfigs.ThemePath + "js/extensions.js\"></script>");
}

/////////////////////////////////////////字符串操作///////////////////////////
function GetFileNameByPath(s) {
    if (s.indexOf("\\") > -1)
        return s.match(/\\([^\\^.]+)\.[^\\]*$/)[1];
    else
        return s;

}
//验证输入框输入的值是否不正整数,否置为1
function isint(ob) {
    var Reg = /^[1-9]\d*$/;
    return Reg.test($(ob).val());
}
///////////////////////////////////////////////////////////////////////////////////
// String Helper
///////////////////////////////////////////////////////////////////////////////////
String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g,
        function (m, i) {
            return args[i];
        });
}

String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}

/////////////////////////
///去前后空格
////////////////////////
String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.ltrim = function () {
    return this.replace(/(^\s*)/g, "");
}
String.prototype.rtrim = function () {
    return this.replace(/(\s*$)/g, "");
}

//定义一个字符stringbuilder类
function StringBuilder() {
    this.arrStr = new Array();
}
StringBuilder.prototype.Append = function (strVelue) {
    this.arrStr.push(strVelue);
}

StringBuilder.prototype.toString = function () {
    return this.arrStr.join("");

}
function getFileExt(str) {
    var d = /\.[^\.]+$/.exec(str);
    return d.toString().toLowerCase() ;
}

//html编码////////////
function HtmlEncode(text) {
    return text.replace(/&/g, '&amp').replace(/\"/g, '&quot;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
}
//html解码
function HtmlDecode(text) {

    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>').replace(/\n/g, '<br>').replace(/\t/g, '<br>').replace(/\r/g, '');

}

function GetJsPram(jsid, strArg) {
    var str = document.getElementById(jsid).src;
    var _url = str + "&";
    var regex = new RegExp("(\\?|\\&)" + strArg + "=([^\\&\\?]*)\\&", "gi");
    if (!regex.test(_url)) return "";
    var arr = regex.exec(_url);
    return (RegExp.$2);
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

function cut_string(strString, nLength) {
    var nTheLength = 0;
    for (var nIndex = 0; nIndex < strString.length; nIndex++) {
        if (strString.charCodeAt(nIndex) > 255)
            nTheLength += 2;
        else
            nTheLength += 1;
        if (nTheLength >= nLength)
            break;
    }
    var strResult = strString.substr(0, nIndex);
    if (strResult.length < strString.length)
        strResult = strResult + "...";
    return strResult;
}
function cut_str_mid(strString, iLength) {
    if (strString.length > iLength) {
        var iLength2 = parseInt(iLength / 2);
        var strtemp1 = strString.substr(0, iLength2);
        var strtemp2 = strString.substr(strString.length - iLength2);
        strString = "";
        strString = strtemp1 + "  ...  " + strtemp2;
    }
    return strString;
}
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
//复制文本
function CopyObText(thisobj) {
    var rng = document.body.createTextRange();
    rng.moveToElementText(thisobj);
    rng.scrollIntoView();
    rng.select();
    clipboardData.setData('text', thisobj.innerText);
    alert("复制成功!!");
}
function JsonToObj(sJson) {

    return eval("({" + sJson + "})");
}
/** 
* 检查是否为网址 
* 
* @param {} 
*            str_url 
* @return {boolean} true：是网址，false:<b>不是</b>网址; 
*/
function isurl(str_url) {// 验证url  
    var strregex = "^((https|http|ftp|rtsp|mms)?://)"
                + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" // ftp的user@  
                + "(([0-9]{1,3}.){3}[0-9]{1,3}" // ip形式的url- 199.194.52.184  
                + "|" // 允许ip和domain（域名）  
                + "([0-9a-z_!~*'()-]+.)*" // 域名- www.  
                + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]." // 二级域名  
                + "[a-z]{2,6})" // first level domain- .com or .museum  
                + "(:[0-9]{1,4})?" // 端口- :80  
                + "((/?)|" // a slash isn't required if there is no file name  
                + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
    var re = new RegExp(strregex);
    var isurl = re.test(str_url);
    if (!isurl) { //相对路径
        if (str_url.lastIndexOf(".htm") > 0 || str_url.lastIndexOf(".html") > 0 || str_url.lastIndexOf(".aspx") > 0 || str_url.lastIndexOf(".ashx") || str_url.lastIndexOf(".php") || str_url.lastIndexOf(".asp")) {
            isurl = true;
        }
    }
    return isurl;
}
//////////////////////////////////数组操作///////////////////////

//为数组添加一个删除指定索引项  
Array.prototype.contains = function (element) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] == element) {
            return true;
        }
    }
    return false;
} 
Array.prototype.removecount = 0;
Array.prototype.removedAt = function (index) {
    if (isNaN(index) || index < 0) {
        return;
    }
    if (index < this.length) {
        this.splice(index, 1);
        this.removecount++;
    }

}
//为数组添加一个新办法:删除重复数组项。
Array.prototype.unique = function () {
    var tempArray = this.slice(0); //复制数组到临时数组
    for (var i = 0; i < tempArray.length; i++) {
        for (var j = i + 1; j < tempArray.length; ) {
            if (tempArray[j].toString() == tempArray[i].toString())
            //后面的元素若和待比较的相同，则删除并计数；
            //删除后，后面的元素会自动提前，所以指针j不移动
            {
                tempArray.splice(j, 1);
            }
            else {
                j++;
            }
            //不同，则指针移动
        }
    }
    return tempArray;
}


//从指定值获取数组索引,如有重复值，只取第一个索引
Array.prototype.GetIndex = function (obj) {
    var tempArray = this.slice(0); //复制数组到临时数组
    var iIndex = 0;
    for (var i = 0; i < tempArray.length; i++) {
        if (tempArray[i]==obj) {
            iIndex = i;
            break;
        }
    }

    return iIndex;
}


//table 常用操作,iTop为保留顶项

function clear_table_rows(obTable, iTop) {
    var delRows = obTable.rows.length;
    for (i = iTop; i < delRows; i++) obTable.deleteRow(1);
};

//////////////////////////////////////ajax操作////////////////
function onAjaxBeforeSend(jqXHR, settings) {

    // AJAX调用需要可直接向真正的物理位置
    // WEB服务/页面的方法。对于这一点，是用来IISPath。
    //如果一个AJAX调用是一个虚拟的URL（的博客实例），虽然
    // URL重写，重写这些URL，我们结束了一个“405不允许的方法”
    //错误的Web服务。在这里，我们设置的请求标头，因此调用服务器
    //是在正确的网站实例ID。

//    var soapMessage =
//            '<SecurityContext xmlns="http://tempuri.org/">\
//            <SafeKey>123456ebsite</SafeKey>\
//            </SecurityContext>';
//    
//    jqXHR.setRequestHeader('SecurityKey', soapMessage);

}
//GET办法运行异步http请求
function run_ajax_async(url, postdata, backfun) 
{
     
    $.ajax({
        type: "get",
        url: url,
        data: postdata,
        beforeSend: onAjaxBeforeSend,
        dataType: "html",
        success: function (msg) {
            if (backfun != null) backfun(msg);

        },
        async: true
    });
}
//GET/post办法运行异步http请求
function run_ajax_async_type(url, postdata, backfun, stype) {
    
    $.ajax({
        type: stype,
        url: url,
        data: postdata,
        beforeSend: onAjaxBeforeSend,
        dataType: "html",
        success: function (msg) {
            if (backfun != null) backfun(msg);

        },
        async: true
    });
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
        contentType: "application/json; charset=utf-8",//application/x-www-form-urlencoded, application/json; charset=utf-8
        dataType: "json",
        beforeSend: onAjaxBeforeSend,
        success: function (result) {

            if (backfun != null) backfun(result);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $.log("调用ajax发生错误:" + thrownError + " 调用地址:" + url);
            //alert("调用ajax发生错误:" + thrownError);
        }

    });
}

function get_ajax(url,backfun) {
     
    $.ajax({
        url: url, 
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: onAjaxBeforeSend,
        success: function (result) {
            if (backfun != null) backfun(result);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $.log("调用ajax发生错误:" + thrownError + " 调用地址:" + url);
            //alert("调用ajax发生错误:" + thrownError);
        }

    });
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
        beforeSend: onAjaxBeforeSend,
        success: function (result) {
            vlMsg = result;
        },
        error: function (xhr, ajaxOptions, thrownError) {

            $.log("调用ajax发生错误:" + thrownError);
            //alert("调用ajax发生错误:" + thrownError);
        }

    });
    return vlMsg;
}

//运行同步http请求
function run_ajax_unasync(url) {
    var html = $.ajax({
        url: url,
        beforeSend: onAjaxBeforeSend,
        async: false
    }).responseText;

    return html;
}
//GET办法运行异步http请求 javascript
function run_ajax_async_js(url, postdata, backfun) {

    $.ajax({
        type: "get",
        url: url,
        data: postdata,
        dataType: "script",
        beforeSend: onAjaxBeforeSend,
        success: function (msg) {
            if (backfun != null) backfun(msg);

        },
        async: true
    })
}
function run_ajax_xml(url, postdata, backfun) {

    $.ajax({
        type: "POST",
        url: url,
        data: postdata,
        beforeSend: onAjaxBeforeSend,
        dataType: "xml",
        success: function (msg) {
            if (backfun != null) backfun(msg);

        },
        async: true
    })
}

//可以动态载入js的json对象
function get_json(sPath, fun) {
    $.getJSON(sPath,
                fun
        );
}

function JsonToObj(sJson) {

    return eval("({" + sJson + "})");
}
//批量操作----------------------------------------
//获取某个元素下的所有check值，用逗号分开
function GetCheckValues(obid) {
    var aValues = [];
    var obHtml = $("#" + obid);
    obHtml.find("input[type=checkbox]").each(
		function (i) {
		    if (this.checked) {
		        aValues.push($(this).val());
		    }
		}
		);

    return aValues.join(",");
}
//全选
function on_checkall(ob) {

    $(ob).find("input[type=checkbox]").each(
		function (i) {
		    this.checked = true;
		}
		);
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
		}
		);
}

//反向选取
function on_check(obchk) {
    var ob = $(obchk).parent().parent().parent();
    $(ob).find("input[type=checkbox]").each(
		function (i) {
		    this.checked = obchk.checked;
		}
		);
}


//获取选择的radio值
function get_checkedradio_value(radios) {
    for (var i = 0; i <= radios.length; i++) {
        if (radios[i].checked) return radios[i].value;
    }
    return null;
}
function set_radio_checked(obradio, v) {
    var radios = $(obradio);
    for (var i = 0; i < radios.length; i++) {
        
        if (radios[i].value == v) {
            radios[i].checked = true;
        }
    }
    return null;
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
//删除所选项
function delete_sel_item(obID) {
    $("#" + obID).find("option:selected").remove();
}

// 实现一个类似委托特性的类(js里面function可以相当于一个类)，add方法相当于运算符"+"重载,run相当执行委托链上所有的回调函数

function delegate(func) {
    this.arr = new Array(); // 回调函数数组
    this.add = function (func) {
        this.arr[this.arr.length] = func;
    };
    this.run = function () {
        for (var i = 0; i < this.arr.length; i++) {
            var func = this.arr[i];
            if (typeof func == "function") {
                func(); // 遍历所有方法以及调用
            }
        }
    }
    this.add(func);
}

//窗口操作----------------------------------------------
//function ColseGreyBox() {


//    if (parent.ColseWinbox != undefined) {
//        parent.ColseWinbox();
//    }
//    else {
//        window.close();
//    }
//}
//function OpenGreyBoxFull(sTitle, Url) {

//    GB_showFullScreen(sTitle, Url);
//}

//function OpenGreyBoxCenter(sTitle, Url, width, height) {

//    GB_showCenter(sTitle, Url, height, width);

//}
 

function getposition(obj) {
    var r = new Array();
    r['x'] = obj.offsetLeft;
    r['y'] = obj.offsetTop;
    while (obj = obj.offsetParent) {
        r['x'] += obj.offsetLeft;
        r['y'] += obj.offsetTop;
    }
    return r;
}

//显示提示层
function showhintinfo(obj, objleftoffset, objtopoffset, title, info, objheight, showtype, objtopfirefoxoffset) {

    var p = getposition(obj);

    if ((showtype == null) || (showtype == "")) {
        showtype == "up";
    }

    document.getElementById('hintiframe' + showtype).style.height = objheight + "px";
    document.getElementById('hintinfo' + showtype).innerHTML = info;
    document.getElementById('hintdiv' + showtype).style.display = 'block';



    if (objtopfirefoxoffset != null && objtopfirefoxoffset != 0 && !isie()) {
        document.getElementById('hintdiv' + showtype).style.top = p['y'] + parseInt(objtopfirefoxoffset) + "px";
    }
    else {
        if (objtopoffset == 0) {
            if (showtype == "up") {
                document.getElementById('hintdiv' + showtype).style.top = p['y'] - document.getElementById('hintinfo' + showtype).offsetHeight - 40 + "px";
            }
            else {
                document.getElementById('hintdiv' + showtype).style.top = p['y'] + obj.offsetHeight + 5 + "px";
            }
        }
        else {
            document.getElementById('hintdiv' + showtype).style.top = p['y'] + objtopoffset + "px";
        }
    }
    document.getElementById('hintdiv' + showtype).style.left = p['x'] + objleftoffset + "px";
}



//隐藏提示层
//function hidehintinfo() {
//    document.getElementById('hintdivup').style.display = 'none';
//    document.getElementById('hintdivdown').style.display = 'none';
//}

//function wo(url, w, h, m, s) {
//    var left = (screen.width - w) / 2;
//    var top = m ? (screen.height - h) / 2 : 0;
//    return window.open(url, 'player', 'width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + ',scrollbars=0,resizable=0,status=' + s);

//}
//function woshowbar(url, w, h, m, s) {
//    var left = (screen.width - w) / 2;
//    var top = m ? (screen.height - h) / 2 : 0;
//    return window.open(url, '', 'width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + ',scrollbars=1,resizable=0,status=' + s);

//}
//function OpenWinCenter(url, w, h) {
//    woshowbar(url, w, h, 1, 1);
//}
//function wo_href(url, w, h, m, s, name) {
//    var left = (screen.width - w) / 2;
//    var top = m ? (screen.height - h) / 2 : 0;
//     window.open(url, name, 'width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + ',scrollbars=0,resizable=0,status=' + s);
    
//}



//关闭一个距于页面中间的提示框
function CloseTipsToCenter() {

    $("#wCenterWindow").remove();
}
//打开一个距于页面中间的提示框
function OpenTipsToCenter(stitle, msg, iWidth, iHeight) { //titlecolor, backgcolor

    $("body").append("<div  id=\"wCenterWindow\" title=\"" + stitle + "\"  style=\"text-align:center; font-size:14px; font-weight:bold;color:#000; background-color:#FFA44A;display:none;\" >" + msg + "</div>");


    In.ready('jqui', function () {                //执行代码

        $("#wCenterWindow").dialog({
            draggable: false,
            resizable: false,
            modal: false,
            width: iWidth,
            height: iHeight
        });
        //去掉标题
        if ($.trim(stitle) == '')
            $(".ui-dialog-titlebar").hide();

    });
}
function Refesh() {
    var url = location.href;
    if (url.lastIndexOf("#") > 0) {
        url = url.substring(0, url.length - 1);
    }
    
    document.location.href = url;
}
function RefeshParent() {
    parent.parent.document.location.href = parent.parent.document.location.href;
}
function RefeshParent1() {
    parent.document.location.href = parent.document.location.href;
}
function gotourl(url) {
    document.location.href = url;
}
//提示操作类--------


function searchsubmit(ob) {
    if (ob.q.value == "") return false;
}

//提示--------------------

function CustomTipsWithCl(ob, sHtml) {
    var ct = "<table style='width:100%;'><tr><td style='text-align:right;'><img id='imTipsColse' style='cursor:pointer;' src='" + SiteConfigs.UrlIISPath + "images/menus/Delete.gif'></td></tr><tr><td>" + sHtml + "</td></tr></table>";
    CustomTips(ob, ct);


    $("#imTipsColse").bind('click', function () {
        CloseCustomTips(ob);
    });
}
function TipsAutoClose(ob, sHtml) {
    $(ob).bind('mouseout', function () {
        CloseCustomTips(ob);
    });
    CustomTips(ob, sHtml);
}



//var tipsTimer = null;
function TipsClickClose(ob, sHtml) {
    $(document).bind('click', function () {
        CloseCustomTips(ob);
    });
    CustomTips(ob, sHtml);
    //tipsTimer = window.setTimeout(CustomTips, 1000, ob, sHtml);
    $(ob).bind('mouseout', function () {
        //        if (tipsTimer != null) {
        //            clearTimeout(tipsTimer);
        //        }


    });


}
function CustomTips(ob, sHtml) {
    var _f = $.data(ob, "ebtips");
    var _d = $(ob);
    if (!_f) {

        //
        _f = $("<div class=\"ebcustom-tip\">" + "<span class=\"ebcustom-tip-content\">" + "</span>" + "<span class=\"ebcustom-tip-pointer\">" + "</span>" + "</div>").appendTo("body");

        $.data(ob, "ebtips", _f);

    }
    _f.find(".ebcustom-tip-content").html(sHtml);
    _f.css({ display: "block", left: _d.offset().left + _d.outerWidth(true), top: _d.offset().top });

}
function CloseCustomTips(ob) {
    var tip = $.data(ob, "ebtips");
    if (tip) tip.remove();
    $.data(ob, "ebtips", null);
}

/*
让某个元素闪烁
ele : jQuery Object [object] 要闪动的元素 
times : Number [Number] 闪动几次     
*/
function shake(obj, times) {
    cls = 'red';
    var ele = obj;
    var i = 0, t = false, o = ele.attr("class") + " ", c = "", times = times || 2;
    if (t) return;
    t = setInterval(function () {
        i++;
        c = i % 2 ? o + cls : o;
        ele.attr("class", c);
        if (i == 2 * times) {
            clearInterval(t);
            ele.removeClass(cls);
        }
    }, 300);
};

//提示结束-----------------------

function ishave(objid) {
    return $("#" + objid).length > 0;
}

function getdate() {
    var myDate = new Date();
    return  myDate.toLocaleDateString(); 
}
function getdatetime() {
    var myDate = new Date();
    return myDate.toLocaleDateString() + " " + myDate.toLocaleTimeString(); 
}


//常用插件开发

; (function ($, window, document, undefined) {
    $.extend({
        log: function (message) {
            var now = new Date(),
                y = now.getFullYear(),
                m = now.getMonth() + 1,
                d = now.getDate(),
                h = now.getHours(),
                min = now.getMinutes(),
                s = now.getSeconds(),
                time = y + '/' + m + '/' + d + ' ' + h + ':' + min + ':' + s;
            console.log("日志输出: " + message + "       时间:" + time);
        }

    });
    $.extend({
        logobj: function (obj) {
            $.log(JSON.stringify(obj));
        }

    });

    $.fn.LoadNoRefresh = function (options) {
        var defaults = {
            'itembox': '#panelzxtab1',//listview 盒子
            'nextpagebox': '.pagination',//分页盒子
            'nextpage': '.nextpage',//下页带href的元素
            'loadingtxt': '正在加载中...'//点击加载提示
        };
        var settings = $.extend({}, defaults, options);//将一个空对象做为第一个参数,保护默认设置
        $(settings.nextpagebox).hide();
        var nextpage = $(settings.nextpage).attr("href");

        var btnoldtxt = $(this).html();
        var _this = this;
        this.click(function () {
            $(this).html(settings.loadingtxt);
            $('<div/>').appendTo(settings.itembox).load(nextpage + " " + settings.itembox, function (responseText) {

                var obj = $(responseText).find(settings.nextpage);

                nextpage = obj.attr("href");
                _this.html(btnoldtxt);

                if (!nextpage) {
                    _this.hide();
                }


            });
        });
    }
})(jQuery, window, document);
