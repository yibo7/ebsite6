var atstep = -1;
var curUser = null;
var currentstep = null;
var tmpPhone = "";
var LastSendTime = null;
$(document).ready(function () {

    $("#toolbar li").click(function () {
        sendmsg("<img  src=\"" + $(this).attr("src") + "\">", "我", 1);
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



    //获取客服信息，之后才是一切操作的开始
    inituserinfo();

    $("#message").keydown(function () {
        //event.ctrlKey && window.event.keyCode
        if (window.event.keyCode == 13) {

            $("#btnsend").click();
        }
    });

    $("#btnsend").click(function () {
        var msg = $("#message").val();
        sendmsg(msg, "我", 1);
    });

    //离开时设为离线
    $(window).unload(function () {
        var dto = {
            "suid": curUser.id,
            "stepid": currentstep.id
        };
        runws("SetOffLine", dto, null);
    });

    //对上传控件的初始
    //上传目录
    var sSaveFolder = "/themes/default/data/Upload";
    sSaveFolder = location.href;
    sSaveFolder = sSaveFolder.replace("http://", "");
    sSaveFolder = sSaveFolder.replace(window.location.host, "");
    sSaveFolder = sSaveFolder.substring(0, sSaveFolder.lastIndexOf("/"));
    sSaveFolder = sSaveFolder + "/chatupload";


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
        openappraise();

    });

    $(window).focus();
});

//function window.onbeforeunload() {
//    openappraise();
//    var n = window.event.screenX - window.screenLeft;
//    var b = n > document.documentElement.scrollWidth - 20;
//    if (b && window.event.clientY < 0 || window.event.altKey) {
//        window.event.returnValue = "您确定要退出聊天窗口吗？";  //确定要退出本页吗？
//    }
//}

var force = false;
window.onbeforeunload = function () {

    //$("#con3").css("display", "block");
    openappraise();
    var n = window.event.screenX - window.screenLeft;
    var b = n > document.documentElement.scrollWidth - 20;
    if (b && window.event.clientY < 0 || window.event.altKey) 
    {
        var b = $.browser;
        if (!force || !(b.maxthon || b.se360 || b.theworld || b.sogou))
            return "您确定要退出聊天窗口吗";
    }
};




//打开满意度评价页面
function SendAppraise() {
    
    var star= $('input:radio[name="rdselitem"]:checked').val();
    var fa = 2;//意见
    var ct = $("#appraisemsg").val();
    var dto = {
        "suid": curUser.id,
        "suname": curUser.UserNiName,
        "typeid": fa,
        "ctent": ct,
        "starnum":star
    };
    runws("ComplanAdd", dto, function (msg) {
        if (msg.d) {
            closethiwin();
        }
    });
}
function openappraise() {
    
    
    if (chatsetting.IsOpenAppraise) {
        if (!IsAutoAddOrder) {
            $("#con3").css("display", "block");
            //var html = '<div class="appraise"><div class="title">您对此次服务是否满意？</div><div class="selitem"><input type="radio" value="5" name="rdselitem" checked id="rdselitem5" /><label for="rdselitem5">非常满意</label> <input type="radio" value="4" name="rdselitem" id="rdselitem4" /><label for="rdselitem4">满意</label> <input type="radio" value="3" name="rdselitem" id="rdselitem3" /><label for="rdselitem3">一般</label> <input type="radio" value="2" name="rdselitem" id="rdselitem2" /><label for="rdselitem2">不满意</label><input type="radio" value="1" name="rdselitem" id="rdselitem1" /><label for="rdselitem1">很差</label></div><div>您的意见:</div><div><textarea  id="appraisemsg" style="width:280px; height:50px;"  cols="10"></textarea></div><div class="btns"> <input type="button" onclick="SendAppraise()" value=" 提交评价 " /> <input onclick="closethiwin()" type="button" value=" 关闭窗口 " /></div></div>';
            //TINY.box.show(html, 0, 300, 200, 0);
        }
    }
    
    

}
function closethiwin() {
    self.close();
}

var GetMsgTimer = 0;
//定时获取当前选择用户的聊天记录
function GetMsg() {
    GetMsgTimer = setInterval(function (xx) {

        var dto = {
            "s": curUser.id,
            "r": curUser.CustomerID
        };
        runws("GetMsg", dto, function (msg) {
            var data = msg.d;

            if (data.length > 0) {

                for (var i = 0; i < data.length; i++) {
                    var md = data[i];
                    if (md.IsSetDG == 1) {
                        LastSendTime = null;//解决您正在与销售聊天不能切换的问题
                        $("#tags2").click();
                    }
                    sendmsg(md.Msg, curUser.ServiceName, 2);
                }

                blinkNewMsg();
            }
            else {  //没有到信息

                if (LastSendTime != null && LastSendTime != 1) {

                    LastSendTime = LastSendTime + (chatsetting.TimeSpan / 1000);
                    if (LastSendTime > chatsetting.TimeSpanToAuto) {

                        if (chatsetting.TimeSpanToAutoModel == 1) { //切换到空闲客服

                            GoToFreeServeicer();

                        }
                        else { //切换到自动下单
                            sendmsg("<font color=red>客服正忙,5秒钟后将进入自助下单模式...</font>", "系统", 2);
                            setTimeout(function (xx) {
                                $("#tags2").click();
                                $("#tags1").hide(); //不让客户再切换回来
                            }, 5000);
                        }
                    }


                }
                else {

                    var dtopram = { "suid": curUser.id, "cid": curUser.CustomerID };
                    runws("IsServiceOff", dtopram, function (msg) {
                        var data = msg.d;
                        if (data == 1) {
                            sendmsg("<font color=red>对方已经离开,如果您还希望跟此客服聊天请关闭窗口再重新打开,...</font>", "系统", 2);
                            clearInterval(GetMsgTimer);
                        }
                    });
                }

            }

        });

    }, chatsetting.TimeSpan);
}

function GoToFreeServeicer() {
    sendmsg("<font color=red>客服正忙,系统正在为您转移下一位客服...</font>", "系统", 2); //设为1是为了让客服知道已经转移到下一位客服

    setTimeout(function (xx) {

        runws("ServerForFree", { thisid: curUser.id }, function (msg) {
            var data = msg.d;

            if (data > 0) {

                var anewurl = location.href.split("?");
                var surl = anewurl[0] + "?u=" + data;
                location.href = surl;
            }
            else {
                sendmsg("<font color=red>抱歉，所有客服都在忙,即将进入自助下单模式...</font>", "系统", 1);
                setTimeout(function (xx) {
                    $("#tags2").click();
                    $("#tags1").hide(); //不让客户再切换回来
                }, 2000);

            }
        });

    }, 3000);

}



///导购模式//
var isbind = false;
var IsAutoAddOrder = false;//是否自助下单模式
var currenttagname = "";
function OnTagsChange(obj) {

    if (!IsAutoAddOrder) {
        if (LastSendTime == 1) {
            alert("您在正与销售聊天，不能切换到自助下单模式!");
            return false;
        }
    }
    
    currenttagname = $(obj).attr("name");
    switch (currenttagname) {
        case "divmsgbox_tg1":
            $("#input_tags1").show();
            $("#input_tags2").hide();
            $("#btnsend").show();
            $("#btnclose").show();
            IsAutoAddOrder = false;

            break;
        case "divmsgbox_tg2":
            IsAutoAddOrder = true;
            LastSendTime = null;//不再执行转移操作
            $("#input_tags1").hide();
            $("#input_tags2").show();
            $("#btnsend").hide();
            $("#btnclose").hide();
            if (!isbind) {
                //客户的输入分为二种情况，一种为下拉列表，一种为文本输入
                //设置下拉列表
                $("#selbox").sSelect();
                $("#selbox").change(function () {
                    var selvalue = get_selected_value(this);
                    
                    if ($("#selbox").val() == -1) {
                        alert("请选择");
                    }
                    else {
                        var msg = currentstep.utem.replace("#用户输入#", selvalue);
                        currentstep.val = selvalue;
                        //currentstep.valid = $(this).val();
                        //var classid = $(this).children("option:selected").attr("id");
                        var classid = $(this.options[this.selectedIndex]).attr("id");
                        currentstep.valid = classid;
                        sendmsg(msg, "我", 1);
                        gotonextstep();
                    }

                });
                //设置文本输入
                $("#btnamsgboxstep").click(function () {

                    //yhl begin 验证
                    var selvalue = $("#txtamsgboxstep").val();
                    var iRule = currentstep.rule;
                    var inull = currentstep.isnull;
                    if (iRule == 1)//手机验证
                    {
                        var mobile = /^0{0,1}(13[0-9]|15[0-9]|18[0-9]|14[0-9])[0-9]{8}$/;
                        if (mobile.test(selvalue)) {
                            sendmsg(selvalue, "我", 1);
                            currentstep.val = selvalue;
                            $("#txtamsgboxstep").val("");
                            gotonextstep();
                        }
                        else {
                            alert("请输入正确的手机号码");
                            $("#txtamsgboxstep").focus();
                        }
                        tmpPhone = selvalue;
                    }
                    else if (inull == 0) {  //不能为空
                        if (selvalue == "") {
                            alert("请输入相关信息");
                        }
                        else {
                            var selvalue = $("#txtamsgboxstep").val();
                            sendmsg(selvalue, "我", 1);
                            currentstep.val = selvalue;
                            $("#txtamsgboxstep").val("");
                            gotonextstep();
                        }
                    }
                    else {
                        var selvalue = $("#txtamsgboxstep").val();
                        sendmsg(selvalue, "我", 1);
                        currentstep.val = selvalue;
                        $("#txtamsgboxstep").val("");
                        gotonextstep();
                    }
                    //yhl end

                });
                gotonextstep();
                isbind = true;
            }
            break;
    }

    return true;

}

function ShowUserLeaveMsg() {
    $("#ShowUserLeaveMsg").show();
}
    ///end导购模式//

function inituserinfo() {
    var userid = GetUrlParams("u");
    var sdata = { uid: userid };

    runws("GetChatUser", sdata,
            function (msg) {

                if (msg.d.Success) {
                    curUser = msg.d.Data;
                    $("#salephoto").attr("src", curUser.Photo);
                    $("#saleinfo").append("<li>姓名：" + curUser.ServiceName + "</li>");
                    $("#saleinfo").append("<li>职位：" + curUser.PostName + "</li>");
                    $("#saleinfo").append("<li>座机：" + curUser.Phone + "</li>");
                    $("#saleinfo").append("<li>手机：" + curUser.Mobile + "</li>");
                    $("#saleinfo").append("<li>邮件：" + curUser.Email + "</li>");
                    if ($.trim(curUser.Info) != "") {
                        $("#companyinfo").html("客服简介：<br>" + curUser.Info);
                    }


                    var Tags = new CustomTags();
                    Tags.ParentObjName = "tags";
                    Tags.SubObj = "li";
                    Tags.CurrentClassName = "current";
                    Tags.ClassName = "";
                    Tags.fun = OnTagsChange;
                    Tags.InitOnclickInTags();

                    if (chatsetting.ChatModel < 2) {
                        Tags.InitOnclick(chatsetting.ChatModel);
                        if (chatsetting.ChatModel == 1) {
                            ShowUserLeaveMsg();
                        }
                    }
                    else {
                        if (curUser.IsOnline) { //客服在线可以聊天

                            Tags.InitOnclick(0);
                            if (chatsetting.MaxReceive > 0) { // 是否限制客服接待数

                                var dto = {
                                    "suid": curUser.id
                                };

                                runws("CountCustomersOnline", dto, function (msg) {
                                    var data = msg.d;
                                    if (data >= chatsetting.MaxReceive) { //到达接待数顶限，转移下一客服

                                        GoToFreeServeicer();
                                    }
                                    else {
                                        SaveWelCome();
                                        AddCustomer();
                                    }
                                });
                            }
                            else {
                                SaveWelCome();
                                AddCustomer();

                            }




                        }
                        else {
                            Tags.InitOnclick(1);
                            $("#tags1").remove();
                            ShowUserLeaveMsg();
                        }
                    }





                }

            });

}
function SaveWelCome() {
    if ($.trim(chatsetting.welcome) != "") {  //防止切换时再次输出

        $("#toolbarbottom").html("系统正在输入...");
        setTimeout(function (xx) {  //发送欢迎语句
            sendmsg(chatsetting.welcome.replace("#客服#", curUser.ServiceName), curUser.ServiceName, 3);
            $("#toolbarbottom").html("");
            chatsetting.welcome = "";
        }, 1000);
    }
}
function AddCustomer() {
    //定时更新用户在线状态
    var dto = {
        "suid": curUser.id
    };
    runws("AddCustomer", dto, null);

    //定时获取信息
    GetMsg();

}

function gotonextstep() {
    atstep++;
    $("#input_tags2").hide();
    if (atstep < orderstep.length) {
        currentstep = orderstep[atstep];
        initselbox();
    }
    else { //如果是最后一步
        $("#con2 .inputer").html("");
        var acolumvals = "";
        for (var i = 0; i < orderstep.length; i++) {
            var md = orderstep[i];
            acolumvals += md.id + "{#-#}" + md.val + "{#-#}" + md.valid + "{#-#}" + md.fildname + "{---}";
        }

        var dto = {
            "suid": curUser.id,
            "suname": curUser.UserNiName,
            "columvals": acolumvals
        };
        runws("AddOrderBox", dto,
            function (msg) {
                if (msg.d != "") {
                    //dgtoshowmsg("您的订单" + msg.d + "已经提交，我们工作人员正在处理中，稍后将以短信的形式发送报价");
                    dgtoshowmsg("您的询价记录已经提交成功!稍后我们的销售专员将与您取得联系!");
                    //添加按钮
                    var newHtml = "<input type=\"button\"  onclick=\"GoOnOrder()\" value=\"继续下单\" /><input type=\"button\"  onclick=\"CloseForm()\" value=\"关闭\" />";
                    //<input type=\"button\" class=\"newBtn\" onclick=\"LookMyOrder()\" value=\"查看我的订单\" />
                    $("#input_tags2").html(newHtml);
                    currentstep.id = 0;//不记流失 
                }
            }

        );
        
    }
}
function dgtoshowmsg(msg) {
    $("#toolbarbottom").html("系统正在输入...");
    setTimeout(function (xx) {
        sendmsg(msg, curUser.ServiceName, 2);
        $("#input_tags2").show();
        $("#toolbarbottom").html("");
    }, 1000);

}



//新添加方法开始

function LookMyOrder() {
    runws("IsLogin", null, function (result) {
        var rUrl = "http://www.beimai.com";
        if (result.d <= 0) {
            runws("GetNoLoginURL", null, function (url) {
                if (url.d != "") {
                    rUrl = url.d + "?ph=" + tmpPhone;
                }
                window.open(rUrl);
            });
        }
        else {
            rUrl = "http://www.beimai.com/UccIndex.ashx";
            window.open(rUrl);
        }

    });
}
function GoOnOrder() {
    window.location = window.location;
}



/////邦定下拉列表框///////
var selclassid = 0;
function initselbox() {
    if (currentstep != null) {
        switch (currentstep.itype) {
            case 1: //数据来源于上一步客户选择下拉ID
                var sdata = { pid: $("#selbox").val(), st: currentstep.souretable, type: currentstep.itype, stepid: currentstep.id };
                runws("GetEbClassList", sdata, initselbox_end);
                                $("#selboxparent").show();
                                $("#txtparent").hide();
                break;
            case 2: //数据来源于指定父ID     
                var sdata = { pid: currentstep.pid, st: currentstep.souretable, type: currentstep.itype, stepid: currentstep.id };
                runws("GetEbClassList", sdata, initselbox_end);
                $("#selboxparent").show();
                $("#txtparent").hide();
                break;
            case 100:
                $("#selboxparent").hide();
                $("#txtparent").show();
                break;
        }
        var msg = currentstep.name.replace("#客服#", curUser.ServiceName);
        dgtoshowmsg(msg);
    }
}

function initselbox_end(msg) {
    var html = "<option  value=\"-1\">" + currentstep.seltip + "</option>"
    for (var i = 0; i < msg.d.length; i++) {
        var obItem = msg.d[i];
        html += "<option value=\"" + obItem.id + "\" id=\"" + obItem.Level + "\">" + obItem.Name + "</option>";
    }
    $("#selbox").html(html);
    $("#selbox").sSelect();

}

/////end邦定下拉列表框///////

function onUploadComp() {
    //png,gif,jpg,docx,doc,xls,txt,rar,zip
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

    sendmsg(sHTML, "我", 1);

    $("#btnShowOrCloseUpload").click();

}

//itype=1表示发送者是当前用户，itype=2表示发送者是对方
function sendmsg(dmsg, username, itype) {

    var iswelcomeinfo = (itype == 3);
    if (iswelcomeinfo)
        itype = 2;
    var msg = '<div class="' + ((itype == 1) ? "userspeak" : "myspeak") + '"><div class="title">' + username + '说：(' + getdatetime() + ')</div><div class="msg" >' + HtmlDecode(dmsg) + '</div>';
    
    $("#" + currenttagname).append(msg);
    var scrollTop = $("#" + currenttagname)[0].scrollHeight;
    $("#" + currenttagname).scrollTop(scrollTop);

    if (itype == 1 && curUser.IsOnline) { 
        var dto = {
            "s": curUser.CustomerID,
            "r": curUser.id,
            "m": dmsg,
            "dg":0
        };
        runws("AddMsg", dto, null);
        if (currenttagname == "divmsgbox_tg1")
            $("#message").val("");
    }
    if (itype == 1 && LastSendTime != 1) {
        
        LastSendTime = parseInt(chatsetting.TimeSpan / 1000);
    }
    else {
        if (!iswelcomeinfo)
            LastSendTime = 1;
    }

}
//function showinput(obstep) {
//    switch (obstep.itype)
//    {
//        case 1:
//        case 2: //指定父分类ID           
//            $(".selboxparent").show();
//            $(".txtparent").hide();
//        
//            break;
//        case 100:
//            $(".selboxparent").hide();
//            $(".txtparent").show();
//            break;
//    }

//}


//投诉
function complaints() {
    $("#con1").hide();
    $("#con2").hide();
    $("#con3").show();
}
function ComplainAdd() {
    var fa = $('input:radio[name="t"]:checked').val();
    var ct = $("#Ctent").val();
    if (ct == "") {
        $("#Ctent").focus();
        return;
    }
    var dto = {
        "suid": curUser.id,
        "suname": curUser.UserNiName,
        "typeid": fa,
        "ctent":ct
    };
    runws("ComplanAdd", dto, function (msg) {
        if (msg.d) {
            alert("成功");
        }
    });
}
function ComplainCancel() {
    $("#con1").show();
    $("#con2").show();
    $("#con3").hide();
}

//评价
function addMessage() {
    var ct = $("#txpj").val();
    if (ct == "") {
        alert("请输入留言内容");
        $("#txpj").focus();
    }
    else {
        var dto = {
            "msgct":ct,
            "customid": curUser.UserID
        };
        runws("AddMsgCt", dto, function (msg) {
            if (msg.d) {
                alert("提交成功，感谢您的留言!");
                $("#txpj").val("");
            }
        });
    }

}