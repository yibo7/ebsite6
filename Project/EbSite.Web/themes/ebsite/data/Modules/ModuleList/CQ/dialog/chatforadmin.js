
function iFrameHeight() {

    var ifm = document.getElementById("chatplugin");
    var subWeb = document.frames ? document.frames["chatplugin"].document : ifm.contentDocument;
    if (ifm != null && subWeb != null) {
        ifm.height = subWeb.body.scrollHeight;
    }
}
//当前客服信息对象
var obService = null;
var currentboxid = ""; //当前用户ID ，也是当前信息显示框

//当前客户信息
var userID = 0;
var userIp = "";
var userName = "";
var userNiName = "";
//运行同步http请求
function run_ajax_unasync(url) {
    var html = $.ajax({
        url: url,
        async: false
    }).responseText;

    return html;
}
jQuery(function ($) {
    obService = opener.obService;
    $("#toolbar li").click(function () {
        orderboxonesendmsg("<img  src=\"" + $(this).attr("src") + "\">", "我说", "m", 0);
    });

    //获取当前客户信息
    userID = GetUrlParams("uid");
    userIp = GetUrlParams("ip");
    userName = GetUrlParams("uname");
    userNiName = GetUrlParams("niname");

    currentboxid = userName;

    if ($.trim(userName) != "") {
        //初始化ip信息
        changeuserorderbox(userIp, userName);
        orderboxonesendmsg("<font color=#ff0000>与对方连接成功,如果您在" + chatsetting.TimeSpanToAuto + "秒钟内不回应，系统将转接到下一客服,...</font>", "系统", "s", 0);
        GetMsg();
        CheckCustomerIsOnline(userName);

    }

    $("#changetoauto").click(
        function () {
            if (confirm("确认要将当前客户置为导购模式，设置后此客户不能聊天，只能选择流程下单！")) {
                var msg = $("#message").val();
                if ($.trim(msg) == "") {
                    msg = "系统切换到自助下单模式";
                }
                orderboxonesendmsg(msg, "我说", "m", 1);
            }

        });
    $("#btncustomword").click(

        function () {
            var custtomword = $(".custtomword");
            if ($.trim(custtomword.html()) == "") {
            }
            var html = run_ajax_unasync("customword/index.html");

            TINY.box.show(html, 0, 500, 300, 0);

            $(".custtomword li").click(
                function () {

                    orderboxonesendmsg($(this).html(), "我说", "m", 0);
                    TINY.box.hide();
                });
        });

    $("#message").keydown(function () {
        //event.ctrlKey && window.event.keyCode
        if (window.event.keyCode == 13) {

            $("#btnsend").click();
        }
    });

    $("#btnsend").click(function () {
        var msg = $("#message").val();
        orderboxonesendmsg(msg, "我说", "m", 0);
    });

    $("#btnShowOrCloseUpload").click(function () {
        var isshow = $(this).attr("isshow");
        if (isshow == undefined || isshow == "0") {
            $("#pSWFUPBox").show();
            $(this).html("关闭上传");
            $(this).attr("isshow", "1");

        }
        else {
            $("#pSWFUPBox").hide();
            $(this).html("上传文件或图片");
            $(this).attr("isshow", "0");
        }

    });

    //对上传控件的初始
    //上传目录
    var sSaveFolder = "/themes/default/data/Upload";
    sSaveFolder = location.href;
    sSaveFolder = sSaveFolder.replace("http://", "");
    sSaveFolder = sSaveFolder.replace(window.location.host, "");
    sSaveFolder = sSaveFolder.substring(0, sSaveFolder.lastIndexOf("/"));
    sSaveFolder = sSaveFolder + "/chatupload"


    var EBUPtxtMdPath = new EBSWFUpload();
    EBUPtxtMdPath.FileTextBoxID = "txtMdPath_fltxtMdPath";
    EBUPtxtMdPath.AddBntID = "AddtxtMdPath";
    EBUPtxtMdPath.ProgressID = "ProctxtMdPath";
    EBUPtxtMdPath.FileidCtrID = "txtMdPath_fidtxtMdPath";
    EBUPtxtMdPath.SaveFolder = sSaveFolder;
    EBUPtxtMdPath.AllSize = "1024 KB";
    EBUPtxtMdPath.Ext = "选择文件 (png,gif,jpg,docx,doc,xls,txt,rar,zip)";
    EBUPtxtMdPath.SavePathCtrID = "txtMdPath_sptxtMdPath";
    EBUPtxtMdPath.OldNameCtrID = "txtMdPath_oltxtMdPath";
    EBUPtxtMdPath.onUploadComplete = onUploadComp;
    EBUPtxtMdPath.Init();



    $(window).focus(function () {
        ClearBlinkNewMsg();
    });
    $(document).click(function () {
        ClearBlinkNewMsg();
    });
    $("#btnclose").click(function () {
        if (confirm("确定要关闭窗口吗?")) {
            opener.RemoveCustomerID(currentboxid);
            self.close();
        }


    });
    window.onbeforeunload = function close() {
        var strJson = JSON.stringify(aChatList).toString();
        opener.SaveChatList(strJson);
        //清空记录
        aChatList = null;
        opener.RemoveCustomerID(currentboxid);
        //return "点击【确定】将关闭此页面，点击【取消】停留在此页面！";
    }
    //载入插件
    loadplugins(userName, userIp, userID, userNiName);


});

//禁止刷新页面
//禁止右键
function document.oncontextmenu() { event.returnValue = false; }
//禁止用F5键   
function document.onkeydown() {
    if (event.keyCode == 116) {
        event.keyCode = 0;
        event.cancelBubble = true;
        return false;
    }
}   
//function window.onbeforeunload() {
//    var n = window.event.screenX - window.screenLeft;
//    var b = n > document.documentElement.scrollWidth - 20;
//    if (b && window.event.clientY < 0 || window.event.altKey) {
//        window.event.returnValue = "您确定要退出聊天窗口吗？";  //确定要退出本页吗？
//    }
//}


var isleave = false;
function CheckCustomerIsOnline(uid) {

    setInterval(function (xx) {
        var dto = {
            "suid": obService.id,
            "cid": uid
        };

        runws("CustomersIsLeave", dto,
            function (msg) {

                var data = msg.d;
                if (data == 1) {
                    if (!isleave) {
                        orderboxonesendmsg("<font color=#ff0000>对方已经离开...</font>", "系统", "s", 0);
                        isleave = true;
                    }

                }
                else {
                    if (isleave) {
                        orderboxonesendmsg("<font color=#ff0000>对方再次进入,并且连接成功,你可以开始与对方聊天...</font>", "系统", "s", 0);
                        isleave = false;
                    }

                }

            }
        );

    }, 10000);

}

function loadplugins(username, ip, uid, niname) {
    if (plugins.length > 0) {
        for (var i = 0; i < plugins.length; i++) {
            var obTag = plugins[i];
            $("#plugin-tabs").append("<li url='" + obTag.url + "?u=" + username + "&ip=" + ip + "&uid=" + uid + "&niname=" + niname + "'>" + obTag.title + "</li>");
        }

        var Tags = new CustomTags();
        Tags.ParentObjName = "plugin-tabs";
        Tags.SubObj = "li";
        Tags.CurrentClassName = "current";
        Tags.ClassName = "";
        Tags.fun = function (obj) {
            var url = $(obj).attr("url");
            $("#chatplugin").attr("src", url);

        }
        Tags.InitOnclickInTags();
        Tags.InitOnclick(0);
    }
}
//定时获取当前选择用户的聊天记录
function GetMsg() {
    setInterval(function (xx) {
        var dto = {
            "s": currentboxid,
            "r": obService.id
        };

        runws("GetMsg", dto,
            function (msg) {

                var data = msg.d;
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var md = data[i];

                        orderboxonesendmsg(md.Msg, md.Sender, "u", 0);
                    }
                    blinkNewMsg();

                }
            }
        );

    }, chatsetting.TimeSpan);
}




//选择一个客户时触发
//function OnTagsChange(obj) {

//    currentboxid = $(obj).attr("name");
//    changeuserorderbox(obj);
//}

function onUploadComp() {
    var furl = $("#txtMdPath_sptxtMdPath").val();
    var sExt = getFileExt(furl);

    sExt = sExt.toString().toLowerCase();

    var sHTML = "";

    switch ($.trim(sExt)) {
        case ".png":
        case ".gif":
        case ".jpg":
        case ".jpeg":
            sHTML = "<a target=_blank href=\"" + furl + "\"><img  src=\"" + furl + "\"></a>";
            break;
        case ".docx":
        case ".doc":
            sHTML = "<a target=_blank href=\"" + furl + "\"><img  src=\"/images/type/word.png\">点击下载</a>";
            break;
        case ".xls":
            sHTML = "<a target=_blank href=\"" + furl + "\"><img  src=\"/images/type/excel.png\">点击下载</a>";
            break;
        case ".txt":
            sHTML = "<a target=_blank href=\"" + furl + "\"><img  src=\"/images/type/txt.gif\">点击下载</a>";
            break;
        case ".rar":
        case ".zip":
            sHTML = "<a target=_blank href=\"" + furl + "\"><img  src=\"/images/type/winrar.gif\">点击下载</a>";
            break;

    }
    orderboxonesendmsg(sHTML, "我说", "m", 0);
    $("#btnShowOrCloseUpload").click();
}

function orderboxsendmsg() {
    var msg = $("#message").val();

    orderboxonesendmsg(msg, obService.Name, "m", 0);
}

function orderboxonesendmsg(msg, username, ismy, issetdg) {

    if ($.trim(currentboxid) == "") {
        alert("请先选择客户");
        return;
    }

    if ($.trim(msg) == "") {
        //tips("请输入内容！")
        return;
    }
    var datetime = getdatetime();

    var tem = "<div class='" + (ismy == "m" ? "userspeak" : "myspeak") + "'><div class=\"title\">" + username + " " + datetime + "</div><div class=\"msg\">" + HtmlDecode(msg) + "</div></div>";

    var msgbox = document.getElementById("divmsgbox");
    $("#divmsgbox").append(tem);

    msgbox.scrollTop = msgbox.scrollHeight;
    $("#message").val("");
    if (ismy == "m") {
        var dto = {
            "s": obService.id,
            "r": currentboxid,
            "m": msg,
            "dg": issetdg
        };
        runws("AddMsg", dto, null);
    }
    if (ismy != "s") { //非系统信息保存聊天记录

        AddToChatList(ismy, msg, datetime);
    }


}

var aChatList = [];
function AddToChatList(ismy, msg, datetime) {
    var nChateModel = new ChatModel();
    nChateModel.DateTime = datetime;
    nChateModel.IsSalerSay = (ismy == "m") ? 1 : 0;
    nChateModel.Msg = msg;
    nChateModel.SalerName = obService.Name;
    nChateModel.SalerUserID = obService.UserID;
    nChateModel.SalerUserName = obService.UserName;
    nChateModel.UserID = userID;
    nChateModel.UserName = userName;
    nChateModel.UserNiName = userNiName;
    nChateModel.UserIP = userIp;
    aChatList.push(nChateModel);
}

function txtmsginputkeydown() {
    if (event.ctrlKey && window.event.keyCode == 13) {
        orderboxsendmsg();
    }

}

function changeuserorderbox(ip, susername) {

    if (ip != "" && ip != undefined) {

        //获取IP信息
        $.getScript('http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js&ip=' + ip, function (_result) {
            var urlUserInfo = "../AdminPages/OrderBox.aspx?muid=b4cd6904-3576-451c-a79b-5917b4d32f0f&mid=b456beef-6b3e-4caf-b282-fd17fc4c8684&u=" + susername;
            var urlUserRecord = "";
            var userinfotem = "姓名：" + susername + " <a target=_blank href='" + urlUserInfo + "'>详细...</a> </br>";
            userinfotem += "IP:" + ip + "</br>";
            if (remote_ip_info.ret == '1') {
                userinfotem += "所在地:" + remote_ip_info.country + remote_ip_info.province + remote_ip_info.city + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;其他信息:" + remote_ip_info.desc;
            }
            $("#userinfo").html(userinfotem);
        });
    }
}

function ChatModel() {

    this.SalerName = "";
    this.SalerUserName = "";
    this.SalerUserID = 0;

    this.UserID = 0;
    this.UserName = "";
    this.UserNiName = "";
    this.UserIp = "";

    this.DateTime = null;
    this.Msg = "";
    this.IsSalerSay = 0;
}