
if (is_mobile()) { 
    
    //location.href = SiteConfigs.MobileIndex;
}
window.onload = OnPageLoad;
var scountpram = "";
function OnPageLoad() {
    GetUserLoginInfo();
   
}
jQuery(function ($) {
    var scounturl = SiteConfigs.UrlIISPath + "count.ashx?";
    if (scountpram)
        scounturl = scounturl + scountpram;
    run_ajax_async_json(scounturl + "&ran" + Math.random(), "", null);

    
    if (SiteConfigs.IsShowSql == 1) { 
        var divSql = $("<div>");
        divSql.appendTo("body");
        setTimeout(function () {
            runebws("GetSqlRun", null, function (msg) {
                
                divSql.html(msg.d);
            });
        }, 10000); 
       
    }
    //$("[data-toggle='tooltip']").tooltip();
});

function ChkSo(ob) {
    if (ob.k.value == "") {
        // alert("请输入要搜索的关键词!");
        tips("请输入要搜索的关键词!", 3, 2);
        return false;
    }
}
function GetUserLoginInfo() {
    if ($("#login_info").length > 0) {
        var Url = SiteConfigs.UrlIISPath + "ajaxget/CurrentUser.ashx?" + Math.random();

        var userinfo = run_ajax_unasync(Url);
        if (userinfo != undefined && userinfo != "" && userinfo != "no") {
            var isTel = false; //是否已添写手机
            var isEmail = false; //是否已添写email
            var isHeader = false; //是否已上传头像

            var isTTel = false;
            var isTEmail = false;
            var isTHeader = false;

            var strs = new Array();
            strs = userinfo.split("|");
            CurrentUserId = strs[1];
            CurrentUserNiName = strs[0];
            isTel = strs[2];
            isEmail = strs[3];
            isHeader = strs[4];

            isTTel = strs[5];
            isTEmail = strs[6];
            isTHeader = strs[7];
            if (strs[8] != "") {
                TSTel = strs[8];
            }
            if (strs[9] != "") {
                TSEmail = strs[9];
            }
            if (strs[10] != "") {
                TSHeader = strs[10];
            }
            var sHtml = "";
            sHtml += "欢迎您, <a href='" + SiteConfigs.UrlUcc + "' target=_blank'u' style=\" color:Red\" >" + CurrentUserNiName + "</a> | "; //SiteConfigs.Urluhome

            sHtml += "<a href=\"" + SiteConfigs.UrlUcc + "\" target=_blank'u'>我的帐户</a>|  ";
            sHtml += "<a href=\"" + SiteConfigs.LogOut + "\">退出</a>   ";

            if (isTTel == "True") {
                if (isTel == "False") {
                    opentisforupdatemobile(0);
                }
            }

            if (isTEmail == "True") {
                if (isEmail == "False") {

                    opentisforupdatemobile(2);
                }
            }
            if (isTHeader == "True") {
                if (isHeader == "False") {
                    opentisforupdatemobile(1);
                }
            }
            $("#login_info").html(sHtml);
            if (OnGetUserLoginInfoEnd != null) {
                OnGetUserLoginInfoEnd();
            }
        }
    }

}
var CurrentUserId = 0;
var CurrentUserNiName = "";
var TSTel = "为使您帐号得到安全保护，请绑定手机号";
var TSEmail = "修改一个头像可以多加10个积分";
var TSHeader = "为使您帐号得到安全保护，请绑定Email"; //是否已上传头像
var OnGetUserLoginInfoEnd = null; //在调用用户信息完成后触发,由于某些页面可能要实时获取 CurrentUserId,此获取为异步有延迟
 

//收藏内容
function FavContent(ContentID) {

    var url = FavoriteUrl(ContentID);
    var msgObj = runebws("GetUserCenter", null);

    if (msgObj.d != null || msgObj.d != undefined || msgObj.d != "") {
        window.open(msgObj.d + url);
    }
    else {
        window.open(url);
    }
}
function FavoriteUrl(ContentID) {
    var surl = GetModuleUrl("a9156956-8f57-4bce-b011-4f8107fcbb41", "cfa7c5d9-db68-4182-aec9-84d10b9f61f7");
    return surl + "&cid=" + ContentID + "&url=" + location.href;
}
function GetModuleUrl(ParentMenuID, SubMenuID) {
    var sdata = { pid: ParentMenuID, sid: SubMenuID };
    var msgObj = runebws("GetModuleUrl", sdata);
    if (msgObj != null || msgObj != undefined)
        return msgObj.d;
}
/*
获取模块的安装目录(重载)
一,带参 moduleid，指定获取某个模块的安装目录
二,不带参，获取当前模块的目录(只能在模块里使用)
三,完整方法有2个(用于指定模块api)
moduleid(模块ID), ThemesID(皮肤ID)
*/
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
            url = scriptob.replace("js/comm.js", "");
        }
    }


    return url;
}


/*
此方法为重载方法，
一,完整方法有4个(用于指定模块api)
moduleid(模块ID), funname(接口的方法名称), postobj(方法参数), backfun(回调)
二,调用当前模块api(只能在模块里使用)
funname, postobj, backfun
三,完整方法有5个(用于指定模块api)
moduleid(模块ID), funname(接口的方法名称), postobj(方法参数), backfun(回调)，站点ID 
*/
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
        run_ajax_async_json(url, arguments[2], arguments[3]);
    }


}
//在js里执行当前页面里的一个方法 当前页面的方法要设置为静态statc 并加上属性WebMethod，
//注意:当前页面如果加载用户控件时，不能调用用户控件里的方法
function runwspg(funname, postobj, backfun) {


    var url = location.href;
    if (url.lastIndexOf("#") > 0) {
        url = url.substring(0, url.length - 1);
    }
    var urlPram = location.search; //获取url中"?"符后的字串
    if ($.trim(urlPram) == "") {
        url = url + "/" + funname;
    }
    else {
        var aUrl = url.split("?");
        url = aUrl[0];
        url = url + "/" + funname + urlPram;

    }
    run_ajax_async_json(url, postobj, backfun);
}

/*
调用ebsite里的wcf接口里的方法(重载)
参数一(异步):funname, postobj, backfun 

参数二(同步):funname, postobj
*/
//function runwcf(funname, postobj, backfun) {
//    var url = SiteConfigs.UrlIISPath + "api/Service.svc/" + funname;

//    if (arguments.length == 2) {

//        var vl = run_ajax_unasync_json(url, postobj);
//        return vl;
//    }
//    else if (arguments.length == 3) { //异步

//        run_ajax_async_json(url, postobj, backfun);
//    }

//}

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
function get_web_api(api,backfun) {
    var url = SiteConfigs.UrlIISPath + "api/" + api;  
    get_ajax(url, backfun);
}
function post_web_api(api, postprams, backfun) {
    var url = SiteConfigs.UrlIISPath + "api/" + api; 
    run_ajax_async_json(url, postprams, backfun);
}




//返回顶部 需要引用 jquery.scroll.js
var timeoutscroll = false;
function BackToTop() {

    In.ready('jqscroll', function () {

        $(window).bind('scroll', function () {
            $("#back-to-top").hide();
            if (timeoutscroll) { clearTimeout(timeoutscroll); }
            timeoutscroll = setTimeout(function () {

                var st = $(document).scrollTop(), winh = $(window).height();

                if (st > 100) {
                    if ($("#back-to-top").length < 1) {

                        $(document.body).append('<p style=" display:none;" id="back-to-top"><a href="#top"><span></span>返回顶部</a><a><em ></em></a><a><el><el></a></p>');
                        $("#back-to-top span").click(function () {
                            $("body").ScrollTo(800);
                            return false;
                        });
                        $("#back-to-top em").click(function () {
                            AddFavorite("http://www.ebsite.net", "社会化网络分享");
                            return false;
                        });
                        $("#back-to-top el").click(function () {
                            SetHome("http://www.ebsite.net", "社会化网络分享");
                            return false;
                        });
                        //try{$("#back-to-top").css("left", $(".container").offset().left + $(".container").width());}catch(e){}

                    }
                    $("#back-to-top").fadeIn(500);
                }
                else {
                    $("#back-to-top").fadeOut(500);
                }


            }, 100);

        });

    });
}
//加入收藏
function AddFavorite(sURL, sTitle) {

    sURL = encodeURI(sURL);
    try {

        window.external.addFavorite(sURL, sTitle);

    } catch (e) {

        try {

            window.sidebar.addPanel(sTitle, sURL, "");

        } catch (e) {

            alert("加入收藏失败，请使用Ctrl+D进行添加,或手动在浏览器里进行设置.");

        }

    }

}
function SetHome(sURL, sTitle) {

    var title = sTitle;
    var url = sURL;
    var desc = sTitle;
    if ((typeof window.sidebar == 'object') && (typeof window.sidebar.addPanel == 'function'))
    //Gecko
    {
        window.sidebar.addPanel(title, url, desc);
    }
    else
    //IE
    {
        window.external.AddFavorite(url, title);
    }


}

 

function UpSpecial(objid, contentid) {
    In.ready('poshytip', function () {

        //       var contentid= <%=Model.ID  %>;
        $('#' + objid).poshytip(
            {

                content: ' <iframe  src="' + SiteConfigs.UrlIISPath + 'dialog/upspecial.html?site=' + SiteConfigs.id + '&id=' + contentid + '" frameborder="0" width="300" height="180" scrolling="no" >'
            }
        );

    });
}
//------------------登录---
function tologin() {

    var user = $("input[name='txtUserName']").val();
    var pass = $("#txtPassword").val();
    if (user == "") {
        $("#lbErrInfo").text("请输入登录用户名");
        $("#txtUserName").focus();
        return false;
    }
    if (pass == "") {
        $("#lbErrInfo").text("请输入登录密码");
        $("#txtPassword").focus();
        return false;
    }

    var pram = { "sUserName": user, "sPass": pass };
    runebws("LoginClick", pram, cp_bk);
}
function toCancelFavClass() {
    TINY.box.hide();
}

function openagree() {
    tb_get_url(SiteConfigs.UrlIISPath + 'agree.htm', 500, 300);
}
function tb_div(divid, w, h) {
    var htmlc = $("#" + divid).html()
    In.ready('tinybox', function () {
        TINY.box.show({ html: htmlc, width: w, height: h, opacity: 20, topsplit: 3 })
    });
}
function tb_err(msg) {
    In.ready('tinybox', function () {
        TINY.box.show({ html: msg, animate: false, close: false, boxid: 'error', top: 5, width:200 })
    });    
}
function tb_info(msg) {
    In.ready('tinybox', function () {
        TINY.box.show({ html: msg, animate: false, close: false, mask: false, boxid: 'success', autohide: 2, top: -14, left: -17 })
    });
}
function tb_get_url(weburl,w,h) {
    In.ready('tinybox', function () {
        TINY.box.show({ url: weburl,  width: w, height: h, opacity: 20, topsplit: 3 })
    });    
}
function tb_post_url(weburl, prams, w, h) {
    In.ready('tinybox', function () {
        TINY.box.show({ url: weburl, post: prams, width: w, height: h, opacity: 20, topsplit: 3 })
    });
}

function tb_iframe(weburl,w,h,callback) {
    In.ready('tinybox', function () {
        TINY.box.show({ iframe: weburl, boxid: 'frameless', width: w, height: h, fixed: false, maskid: 'bluemask', maskopacity: 40, closejs: callback})
    });
}
function tb_img(imgurl,  callback) {
    In.ready('tinybox', function () {
        TINY.box.show({ image: imgurl, boxid: 'frameless', animate: true, openjs: callback })
    });
}
function unBlock() {
    In.ready('blockui', function () {
        $.unblockUI();
    });
}
function blockTips(msg, time) { 
    var iTime = 0;
    if (arguments.length == 2) {
        iTime = time;
    } 
     
    var msgHtml = '<div class="blockTips">' + msg + '</div>';
    iTime = iTime * 1000;
    In.ready('blockui', function () {
        //执行代码
        $.blockUI({
            message: msgHtml,
            timeout: iTime, //unblock after 2 seconds
            overlayCSS: {
                backgroundColor: '#1b2024',
                opacity: 0.8,
                cursor: 'wait'
            },
            css: {
                border: 0,
                color: '#fff',
                padding: 0,
                backgroundColor: 'transparent'
            }
        });
    });

}
//Title标题, Msg信息内容, iwidth宽, iheight高, itime显示时间, position位置0 左下角,1 右下角,2左上角,3右上角
function MsgPop(Title, Msg, iwidth, iheight, itime, position) {
    In.ready('messager', function () {
        $.messager.show(Title, Msg, itime, iwidth, iheight, 'slide', position);
    });
}
function opentisforupdatemobile(itype) {
    var shtml = "";
    var title = "";
    if (itype == 0) {
        title = "手机号码更新";
        shtml = TSTel + "<br/><br/><a class='button' href=\"" + ChangeUserMobile() + "\" target=_blank'u'>马上更新我的手机号</a>";
    }
    else if (itype == 1) {
        title = "头像更新";
        shtml = TSHeader + "<br/><br/><a class='button' href=\"" + ChangeUserICO() + "\" target=_blank'u'>马上修改我的头像</a>";
    }
    else if (itype == 2) {
        title = "Email更新";
        shtml = TSEmail + "<br/><br/><a class='button' href=\"" + ChangeUserEmail() + "\" target=_blank'u'>马上修改我的Email</a>";
    }
    if (shtml != "")
        MsgPop(title, shtml, 250, 130, 0, 1);
}

function ChangeUserICO() {
    var surl = GetModuleUrl("bf371bdd-f674-4077-a9ed-e2896fb4c857", "af371bdd-a674-4077-a9ed-e2896fb4c857");
    return surl;
}

function ChangeUserMobile() {
    var surl = GetModuleUrl("bf371bdd-f674-4077-a9ed-e2896fb4c857", "3840b798-44a5-49a0-af7e-9e48f5be8508");
    return surl;
}

function ChangeUserEmail() {
    var surl = GetModuleUrl("bf371bdd-f674-4077-a9ed-e2896fb4c857", "477c77b4-be69-4d37-9593-90884fabc19c");
    return surl;
}
function TINYBoxClose() {
    TINY.box.hide();
}

//打开登录对话框
function openlogin(backfun) {


    clwinajax(SiteConfigs.UrlIISPath + 'dialog/logoin.html', function () {
        In.ready('userlogin', function () {
            initlogin('fUserLogin', true, backfun);
        });
    });
} 
function clwindiv(sdivid) {
    var divid = "#" + sdivid;
    In.ready('fancybox', function () {
        var iframeobj = $("#fancyboxhref");
        if (iframeobj.length == 0) {
            iframeobj = $("<a id=\"fancyboxhref\"  style=\"display: none\" ></a>").appendTo('body');
        }
        console.log(iframeobj)
        iframeobj.attr("href", divid);
        iframeobj.fancybox();
        iframeobj.click();

    });
}

function closefancybox() {
    $.fancybox.close();
}

function clwinajax(url, oncp) {
    var arglen = arguments.length;
    In.ready('fancybox', function () {
        var iframeobj = $("#fancyboxhref");

        if (iframeobj.length > 0) {
            iframeobj.attr("href", url);
        } else {
            iframeobj = $("<a id=\"fancyboxhref\"   style=\"display: none; \" href=\"" + url + "\"></a>").appendTo('body');
        }

        if (arglen == 1) {

            iframeobj.fancybox();

        } else if (arglen == 2) {
            alert(0); 
            iframeobj.fancybox({
                onComplete: oncp
            });
            //,width:500,height:300
        } else {
            alert("出错了，传入的参数个数不正确");
        }


        iframeobj.click();

        //onComplete

    });

}

function clwiniframe(url, w, h, oncp) {
    var arglen = arguments.length;
    In.ready('fancybox', function () {

        var iframeobj = $("#fancyboxhref");
        if (iframeobj.length > 0) {
            iframeobj.attr("href", url);
        } else {
            iframeobj = $("<a id=\"fancyboxhref\" style=\"display: none\" href=\"" + url + "\"></a>").appendTo('body');
        }

        if (arglen == 3) {
            iframeobj.fancybox({
                'width': w,
                'height': h,
                'autoScale': false,
                'transitionIn': 'none',
                'transitionOut': 'none',
                'type': 'iframe'
            });
        } else if (arglen == 4) {
            iframeobj.fancybox({
                'width': w,
                'height': h,
                'autoScale': false,
                'transitionIn': 'none',
                'transitionOut': 'none',
                'type': 'iframe',
                onComplete: oncp
            });
        } else {
            alert("出错了，传入的参数个数不正确");
        }


        iframeobj.click();

    });

}

function PostVote(ismoresel, vaoteid, vitemsboxid, maxsel, SiteID) {
    if (!ismoresel) {//单选
        var selvalue = $('input[name="voteitem"]:checked', $("#" + vitemsboxid)).val();
        if (selvalue != undefined) {
            var pram = { vid: vaoteid, itemid: selvalue, siteid: SiteID };
            runebws("PostVoteSingle", pram, PostVoteComp);
        } else {
            alert("请选择!");
        }


    } else {//多选
        var aValues = [];
        $("#" + vitemsboxid).find("input[type=checkbox]").each(
		function (i) {
		    if (this.checked) {
		        aValues.push($(this).val());
		    }
		});

        if (aValues.length > maxsel) {

            alert("抱歉，最多只能选择" + maxsel, "项!");
            return;
        }

        var selvalue = aValues.join(",");
        if (selvalue != "") {
            var pram = { vid: vaoteid, itemids: selvalue, siteid: SiteID };
            runebws("PostVoteMore", pram, PostVoteComp);
        } else {
            alert("请选择!");
        }

    }
}

function PostVoteComp(rz) {
    var d = rz.d;
    if (d.Success) {
        location.href = d.Message;
    } else {
        alert("抱歉，投票的过程发生错误!");
    }

}
function ShowBarcode(imgid,content) {
    $("#" + imgid).attr("src", SiteConfigs.UrlIISPath + "ajaxget/barcode.ashx?t=0&c=" + content);
}

function is_mobile(){
    if (navigator.platform.indexOf('Win32') != -1) {
        return false;

    } else {
        return true;
    } 
}