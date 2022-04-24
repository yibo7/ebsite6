var chaturl = "";
var scriptob = $("#orderboxchat").attr("src");


if (scriptob != null && scriptob != undefined) {
    var csschaturl = scriptob.replace("js/odc.js", "dialog/float.css");
    document.writeln("<link type=\"text/css\" href=\"" + csschaturl + "\" rel=\"stylesheet\" />");
    csschaturl = scriptob.replace("odc.js", "chatcf.js");
    document.writeln("<script type=\"text/javascript\" src=\"" + csschaturl + "\"></script>");

    csschaturl = csschaturl.replace("chatcf.js", "chatsetting.js");
    document.writeln("<script type=\"text/javascript\" src=\"" + csschaturl + "\"></script>");
    csschaturl = csschaturl.replace("chatsetting.js", "serviceclass.js");
    document.writeln("<script type=\"text/javascript\" src=\"" + csschaturl + "\"></script>");
   var servstatejsurl = csschaturl.replace("js/serviceclass.js", "ajaxget/servstatejs.ashx");
    chaturl = scriptob.replace("js/odc.js", "dialog/chat2.htm");

}
function getservicebygroupid(groupid) {
    var observicebygroup = [];
    var icount = chatsetting.maxnum;
    var iIndex = 0;
    for (var i = 0; i < chatcf.length; i++) {

        var obs = chatcf[i];
        if (obs.gid == groupid) {

            if (iIndex == icount) break;
            observicebygroup.push(obs);
            iIndex++;

        }

    }
    return observicebygroup;
}
function getgroupforserveicehtml(groupid) {
    var obchatcf = null;
    if (groupid > 0) {

        obchatcf = getservicebygroupid(groupid);

    }
    else {
        obchatcf = chatcf;

    }
    var strhtml = "";

    if (obchatcf != null && obchatcf.length > 0) {

        for (var i = 0; i < obchatcf.length; i++) {
            var md = obchatcf[i];
            strhtml += "<li id=\"chatli" + md.id + "\" uid=\"" + md.id + "\">" + md.realname + "[<span>自动</span>]</li>";
        }

    }
    return strhtml;
}
jQuery(function ($) {

  

    var kfico = scriptob.replace("js/odc.js", "dialog/kf01.png");
    var htmlParent = $('<div class="duilian duilian_right"><div class="photoico"><img src="' + kfico + '"></img></div></div>');
    if (chatsetting.fx == "l") {
        htmlParent = $('<div class="duilian duilian_left">');
    }

    if (sclass.length > 0) {

        for (var i = 0; i < sclass.length; i++) {
            var obs = sclass[i];
            htmlParent.append('<div class="duiliantitle">' + obs.title + '</div><div class="duilian_con"><ul></ul></div>');
            var sghtml = getgroupforserveicehtml(obs.id);
            var oblist = htmlParent.find(".duilian_con ul")[i];
            $(oblist).append(sghtml);
        }

    }
    else {

        htmlParent.append('<div class="duiliantitle">' + chatsetting.title + '</div><div class="duilian_con"><ul></ul></div>');
        var sghtml = getgroupforserveicehtml(obs.id);
        htmlParent.find(".duilian_con ul").append(sghtml);


    }
    if (chatsetting.showmore) {
        htmlParent.append("<a target=_blank href=\"" + chatsetting.outlink + "\" class=\"duilian_more\">更多..</a>");
    }
    if (chatsetting.showclose) {
        htmlParent.append("<a href=\"#\" class=\"duilian_close\">X关闭</a>");
    }

    htmlParent.css("top", chatsetting.top);
    $(document.body).append(htmlParent);



    var duilian = $("div.duilian");
    var duilian_close = $("a.duilian_close");

    var screen_w = screen.width;
    //    if (screen_w > 1024) { duilian.show(); }
    duilian.show();
    $(window).scroll(function () {
        var scrollTop = $(window).scrollTop();
        duilian.stop().animate({ top: scrollTop + chatsetting.top });
    });
    duilian_close.click(function () {
        $(this).parent().hide();
        return false;
    });
    $(".photoico img").click(function () {
        if ($.trim(chatsetting.outlink) != "") {
            window.open(chatsetting.outlink);
        }
    });
    $(".duilian_con li").click(function () {

        OpenChatWin($(this).attr("uid"),false);
    });
    //更新用户在线情况
    $.getScript(servstatejsurl, function () {
       
        updateservstate();

    }); 

    
    if (chatsetting.IsOpenInvite) {

        var itime = chatsetting.InviteTimeSpan * 1000;
        setTimeout(OpenInviteDialog, itime);

//        In.ready('jqcookie', function () {
//            var noinvitetips = $.cookie("noinvitetips");
//            if (noinvitetips == null) {
//                var itime = chatsetting.InviteTimeSpan * 1000;
//                setTimeout(OpenInviteDialog, itime);
//            }
//            
//        });

    }
   



});
//打开聊天窗口
function OpenChatWin(iUserID, Isforce) {
    var winname = "winnameuserchat";
    if (!chatsetting.isoutlink || Isforce) {
        var openurl = chaturl + "?u=" + iUserID;
        if (chatsetting.isfull) {
            window.open(openurl, winname);
        }
        else {

            OpenCusttomWin(openurl, 600, 500, 300, 100);
//            In.ready('tinybox', function () {
//                TINY.box.show("", 1, 600, 500, 1);
//            });
        }
    }
    else {
        window.open(chatsetting.outlink, winname);
    }
}

function OpenCusttomWin(url, w, h, m, s,sname) {
    var left = (screen.width - w) / 2;
    var top = m ? (screen.height - h) / 2 : 0;

    left = left - m;
    top = top - s;
    return window.open(url, sname, 'width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + ',scrollbars=1,resizable=0,status=' + s);

}

function updateservstate() {
    for (var i = 0; i < ebservstate.length; i++) {
        var aData = ebservstate[i];
        var isonline = aData.Value;
        if (isonline == 1) {

            var li = $("#chatli" + aData.Text + " span");
            li.text("在线");
            li.css("color", "#ff0000");

        }
    }
}

function CloseOpenInviteDialog() {
    if (chatsetting.InviteModel == 4) {
        $("#wInviteCenterWindow").remove();
    }
    else {
        $.messager.close();
    }
    
    
}
function AcceptInvite() {

    OpenChatWin(RandUserID,true);
    CloseOpenInviteDialog();
//    runws("b456beef-6b3e-4caf-b282-fd17fc4c8684", "RandServerID", null, function (msg) {
//        if (msg.d) {
//            var RandUserID = msg.d;
//            OpenChatWin(RandUserID);
//        }
//    });

}
//function NoInviteTips() {
//    if (confirm("记得点击在线客服，我们的随叫随到哦，确认不再邀请吗？")) {

//        CloseOpenInviteDialog();
//        In.ready('jqcookie', function () {
//            $.cookie("noinvitetips", 1, {expires:1});//一天过期
//        });
//    }
//}
function OpenInviteDialog() {

   
    
    //<span onclick='NoInviteTips()' > 不再提醒我 </span>
    var stitle = "客服邀请您聊天";
    var msg = $.trim(chatsetting.InviteInfo) == "" ? "请问有什么需要帮忙的吗" : chatsetting.InviteInfo;
    var iWidth = 300;
    var iHeight = 120;
    var msgHtml ="<div class='InviteMsg'>" + msg + "</div><div class='InviteBtns'><span onclick='AcceptInvite()' > 接受聊天 </span><span onclick='CloseOpenInviteDialog()' > 取 消 </span></div>";
    if (chatsetting.InviteModel == 4) {


        var obwin = $("body").append("<div  id=\"wInviteCenterWindow\" title=\"" + stitle + "\"  style=\"text-align:center; font-size:14px; font-weight:bold;color:#000; background-color:#FFA44A;display:none;\" >" + msgHtml + "</div>");


        In.ready('jqui', function () {
            $("#wInviteCenterWindow").dialog({
                draggable: false,
                resizable: false,
                modal: false,
                width: iWidth,
                height: iHeight
            });

        });
    }
    else {
        var iposition = chatsetting.InviteModel; //position位置0 左下角,1 右下角,2左上角,3右上角

        OrderMsgPop(stitle, msgHtml, iWidth, iHeight, 0, iposition);
    
    }



}
function OrderMsgPop(Title, Msg, iwidth, iheight, itime, position) {

    var messagerurl = scriptob.replace("odc.js", "jquery.messager.js");

    $.getScript(messagerurl, function () {
        $.messager.show(Title, Msg, itime, iwidth, iheight, 'slide', position);
    
    }); 
    
}