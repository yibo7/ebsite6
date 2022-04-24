//格式 {#UserName#}{\n}{#NiName#}{\n}#DateTime#}{\n}{#Msg#}
function AddOneMsgToChatList(msg) {

    var msgTem = '<div class="msglist" ><span class="msgtitle"><a target=_blank href="/u/index.aspx?uid={#UserName#}">{#NiName#}</a> {#DateTime#}</span><br /><span class="msgcontent">{#Msg#}</span></div> ';

    var aMsg = msg.split("{\n}");

    var msghtml = msgTem.replace("{#UserName#}", aMsg[0]).replace("{#NiName#}", aMsg[1]).replace("{#DateTime#}", aMsg[2]).replace("{#Msg#}", aMsg[3]);
    var obScroll = document.getElementById("ChatList");

    $("#ChatList").append(msghtml);
    obScroll.scrollTop = obScroll.scrollHeight;
    
}

//检测当前用户是否有新短信或有人邀请聊天
IsHaveNewMsgTimer = setInterval(IsHaveNewMsg, 10000);
function CurrentSendMsg(ob) {

    var msg = ob.value;
    if (ToSayUserName == "") {

        alert("请选择好友！");
        return;
    }
    if (msg == "") {

        alert("不能发送空信息！");
        return;
    }


    var aMsg = [];
    var CurrentDateTime = new Date();
    aMsg.push(CurrentUserName);
    aMsg.push(CurrentNiName);
    aMsg.push(CurrentDateTime.toLocaleString());
    aMsg.push(msg);

    document.getElementById("MsgSound").src = "/sound/send.wav";
    var newmsg = aMsg.join("{\n}");

    AddOneMsgToChatList(newmsg);

    SaveMsg(ToSayUserName, UserOnlineID, msg);

    ob.value = "";

}
//保存一条信息到服务器
function SaveMsg(Recipient, OlineID, msg) {


    var Url = SiteConfigs.UrlIISPath + "ajaxget/chatevent.ashx?t=1&u=" + Recipient + "&ol=" + OlineID + "&m=" + msg;
    run_ajax_async(Url, "", null);
}
//向服务器获取一条信息
function GetMsg(Sender) {

    var Url = SiteConfigs.UrlIISPath + "ajaxget/chatevent.ashx?t=2&u=" + Sender + "&i=" + Math.random();

    run_ajax_async(Url, "", Comp_GetMsg);
}
//多条信息用{*\n*} 格式 {#UserName#}{\n}{#NiName#}{\n}#DateTime#}{\n}{#Msg#}{*\n*} .....
function Comp_GetMsg(msg) {

    var aMsg = msg.split("{*\n*}");

    if (aMsg == "") return;

    for (var i = 0; i < aMsg.length; i++) {

        var sMsg = aMsg[i];

        if (sMsg != "") {
            AddOneMsgToChatList(sMsg);
        }

    }
    document.getElementById("MsgSound").src = "/sound/msg.wav";
}
var LoadMsgTimer = 0;
//载入某个人的最新信息
function LoadMsg(Sender) {


    LoadMsgTimer = setInterval('GetMsg("' + Sender + '")', 10000);
}

////////检测是否有新短信/////////////////
var g_blinkswitch = 0;
var g_blinktitle = document.title;
var IsHaveNewMsgTimer = 0;
var TimeoutShow = 0;
var MsgTip = "";
function blinkNewMsg() {

    document.title = g_blinkswitch % 2 == 0 ? "【】 - " + g_blinktitle : "【" + MsgTip + "】 - " + g_blinktitle;
    g_blinkswitch % 2 == 0 ? $("#msgtip").hide() : $("#msgtip").show();
    g_blinkswitch++;
    TimeoutShow = setTimeout(blinkNewMsg, 1000);
 }

function IsHaveNewMsg() {

    //这个将在模块中实现
    //    var Url = SiteConfigs.UrlIISPath + "ajaxget/IsNewsMsg.ashx?" + Math.random();

    //    run_ajax_async(Url, "", Comp_IsHaveNewMsg);
}


function Comp_IsHaveNewMsg(msg) {


    if (msg != undefined && msg != '') {

        var aMsg = msg.split("#\n#");
        var iType = aMsg[0]; //iType为1表示聊天，为2表示短信
        var sMsg = aMsg[1]; //聊天返回请求的用户，短信返回短信条数

        if (sMsg != "" && iType == 1) { //聊天

            var sUser = sMsg;
            //$("#tright").append("<li ><a  href=\"" + SiteConfigs.UrlIISPath + "u/chatonline.aspx?suid=" + sUser + "\" target=_blank'u'><div >【<font id='msgtip'>聊天</font>】</div></a></li>");
            //MsgTip = "有人想与你聊天，点击右上角的聊天即可展开聊天";
            //setTimeout(blinkNewMsg, 1000);
            clearInterval(IsHaveNewMsgTimer);
            var sHtmls = "<a onclick=\"CloseTipsToCenter()\"  href=\"" + SiteConfigs.UrlIISPath + "u/chatonline.aspx?suid=" + sUser + "\" target=_blank'u'>【接受进入聊天】</a>"
            sHtmls += " | <a  href=\"javascript:CloseTipsToCenter()\" >【拒绝】</a>";
            OpenTipsToCenter("有人想与你聊天", sHtmls, 300, 100);
            PlayCallSound();


        }
        else if (sMsg != "" && iType == 2) { //短信

            var iCount = parseInt(sMsg);

            if (iCount > 0) {

                $("#tright").append("<li ><a  href=\"" + SiteConfigs.UrlIISPath + "u/msglist.aspx\" target=_blank'u'><div >【<font id='msgtip'>短信</font>】</div></a></li>");
                setTimeout(blinkNewMsg, 1000);
                MsgTip = "你有新的短信，点击右上角的短信查收";
                clearInterval(IsHaveNewMsgTimer);
            }

        }


    }

}

function PlayCallSound() {

    var obMsgSound = $("#MsgSound");
    if (obMsgSound.id == undefined) {

        $("body").append(" <bgsound id=\"MsgSound\" src=\"/sound/call.wav\"  loop=\"1\"> ");

    }

}


function msgevent(iType, Recipient) {


    var Url = SiteConfigs.UrlIISPath + "ajaxget/msgevent.ashx?t=" + iType + "&u=" + Recipient;
    run_ajax_async(Url, "", null);

    alert("消息已经发送！");

}

function MsgEvWithpram(iType, Recipient, Pram) {


    var Url = SiteConfigs.UrlIISPath + "ajaxget/msgevent.ashx?t=" + iType + "&u=" + Recipient + "&p=" + Pram;
    run_ajax_async(Url, "", null);

    alert("消息已经发送！");

}