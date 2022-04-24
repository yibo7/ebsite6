
//检测当前用户是否有新短信或有人邀请聊天


function IsHaveNewMsg() {

    var Url = SiteConfigs.UrlIISPath + "ajaxget/IsNewsMsg.ashx?" + Math.random();

    run_ajax_async(Url, "", function (msg) {
        if (msg != undefined && msg != '') {
            
             var iWidth = 300;
             var iHeight = 120;

            var aMsg = msg.split("#\n#");
            var iType = aMsg[0]; //iType为1表示聊天，为2表示短信
            var surl = aMsg[1]; //聊天返回请求的用户，短信返回短信条数

            if (surl != "" && iType == 1) { //聊天


                clearInterval(IsHaveNewMsgTimer);
                var sHtmls = "<div class='InviteMsg'></div><div class='InviteBtns'><a onclick=\"CloseOpenInviteDialog()\"  href=\"" + surl + "\" target=_blank'u'>【进入聊天】</a>";
                sHtmls += "  <a  href=\"javascript:CloseOpenInviteDialog()\" >【拒绝】</a>";
                //OpenTipsToCenter("有人想与你聊天", sHtmls, 300, 100, "#EB8C05", "#E5F5C9");
                TipsMsgPop("有人跟你说话了啦", sHtmls, iWidth, iHeight,0,1);


            }
            else if (surl != "" && iType == 2) { //短信


                var sHtmls = "<li ><a  href=\"" + surl + "\" target=_blank'u'><div >【<font id='msgtip'>点击查看</font>】</div></a></li>";
                OpenTipsToCenter("你有新消息", sHtmls, 300, 100, "#EB8C05", "#E5F5C9");
                clearInterval(IsHaveNewMsgTimer);

            }

        }

    });

}
function CloseOpenInviteDialog() {
    $.messager.close();
}
 //position位置0 左下角,1 右下角,2左上角,3右上角
function TipsMsgPop(Title, Msg, iwidth, iheight, itime, position) {
    In.ready('messager', function () {
        $.messager.show(Title, Msg, itime, iwidth, iheight, 'slide', position);
    });
}

var IsHaveNewMsgTimer = setInterval(IsHaveNewMsg, 3000);
