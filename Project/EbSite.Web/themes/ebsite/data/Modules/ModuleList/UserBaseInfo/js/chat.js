//////////////////////////////聊天处理////////////////////////////////////
function isMaxLen(o) {
    var nMaxLen = o.getAttribute ? parseInt(o.getAttribute("maxlength")) : "";
    if (o.getAttribute && o.value.length > nMaxLen) {
        o.value = o.value.substring(0, nMaxLen);
    }
}
function CurrentSendMsg(ob) {

    var msg = ob.value;

    if (msg == "") {
        alert("不能发送空信息！");
        return;
    }

    var aMsg = [];
    aMsg.push(CurrentUserID);
    aMsg.push(CurrentNiName);
    aMsg.push(getdatetime());
    aMsg.push(msg);

    document.getElementById("MsgSound").src = "/sound/send.wav";
    var newmsg = aMsg.join("{\n}");

    AddOneMsgToChatList(newmsg);
    //发送一条消息给朋友
    SaveMsg(FriendId, msg);
    ob.value = "";

}
//保存一条信息到服务器
function SaveMsg(FriendId, msg) {

    var Url = SiteConfigs.UrlIISPath + "ajaxget/chatevent.ashx?t=1&u=" + FriendId + "&m=" + msg + "&uid=" + FriendUserId;
    run_ajax_async(Url, "", function (msg) {

        if (msg != "") {
            if (msg == "0") {
                alert("消息不能为空");
            }
            else if (msg == "1") {
                //消息发送成功
            }
            else if (msg == "2") {
                $("#tdUserInfo b").html("对方离线，发送消息将会给他留言!");
            }
            else if (msg == "3") {
                $("#tdUserInfo b").html("对方已经下线    ，聊天断开!");
            }

        } else {
            alert("发生未知错误！");
        }

    });
}
//向服务器获取一条信息
function GetMsg(iFriendId) {

    var Url = SiteConfigs.UrlIISPath + "ajaxget/chatevent.ashx?t=2&u=" + iFriendId + "&i=" + Math.random();
    //多条信息用{*\n*} 格式 {#UserName#}{\n}{#NiName#}{\n}#DateTime#}{\n}{#Msg#}{*\n*} .....
    run_ajax_async(Url, "", function (msg) {
        var aMsg = msg.split("{*\n*}");
        if (aMsg == "") return;
        for (var i = 0; i < aMsg.length; i++) {

            var sMsg = aMsg[i];
            if (sMsg != "") {
                AddOneMsgToChatList(sMsg);
            }

        }
        document.getElementById("MsgSound").src = SiteConfigs.UrlIISPath + "sound/msg.wav";

    });
}

var LoadMsgTimer = 0;
//载入某个人的最新信息
function LoadMsg(iFriendId) {

    LoadMsgTimer = setInterval('GetMsg("' + iFriendId + '")', 5000);
}

//格式 {#UserName#}{\n}{#NiName#}{\n}#DateTime#}{\n}{#Msg#}
function AddOneMsgToChatList(msg) {

    var msgTem = '<div class="msglist" ><span class="msgtitle">{#NiName#}({#DateTime#})</span><br /><span class="msgcontent">{#Msg#}</span></div> ';

    var aMsg = msg.split("{\n}");

    var msghtml = msgTem.replace("{#NiName#}", aMsg[1]).replace("{#DateTime#}", aMsg[2]).replace("{#Msg#}", aMsg[3]);
    var obScroll = document.getElementById("ChatList");

    $("#ChatList").append(msghtml);
    obScroll.scrollTop = obScroll.scrollHeight;

}


var ie = (document.all) ? true : false;
if (ie) {
    function quickpost(eventobject) {
        if ((event.ctrlKey && window.event.keyCode == 13) || (event.altKey && window.event.keyCode == 83)) {
            $("#bntSend").click();
        }
    }
}

LoadMsg(FriendId);