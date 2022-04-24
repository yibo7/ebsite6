var sumscore = 0;
//var currentpguserid = 0;//用户登录ID
$(document).ready(function () {



    var imaxlen = 30;
    $("#NewsTitle").keyup(function () {
        var lab = $("#labWord");
        var txt = $.trim($(this).val());
        if (txt != "" && txt != undefined) {
            if (txt.length <= imaxlen) {
                lab.text(imaxlen - parseInt(txt.length));
            }
            else {
                $(this).val(txt.substr(0, imaxlen));
                //                tips("已经超出30个字,请在[补充问题]里完善您的问题", 1, 5);
                alert("已经超出30个字,请在[补充问题]里完善您的问题");
                $("#btnshowhide").click();
            }
        }
        else {
            lab.text(imaxlen);
        }



    });

    $("#ContentInfo_42be44b30062470eb3410fc474ef221c_editorBox").keyup(function () {
        var lab = $("#labWordEx");
        var txt = $.trim($(this).val());
        if (txt != "" && txt != undefined) {
            if (txt.length <= 1000) {
                lab.text(1000 - parseInt(txt.length));
            }
            else {
                $(this).val(txt.substr(0, 1000));
            }
        }
        else {
            lab.text("1000");
        }
    });


    $("#btnshowhide").click(function () {
        showhidepanel(this);
    });

    if (GetUrlParams("k") != "") {
        $('#NewsTitle').val($.trim(decodeURI(GetUrlParams("k"))));
    }

    In.ready('textauto', function () {
        $("#NewsTitle").textRemindAuto();
    });






    $("#ScoreDDList>select").change(function () {
        var score = $("#ScoreDDList").find("option:selected").val();
        if (sumscore < score) {

            tips("您的分数不足", 2, 2);
        }
    });


    OnGetUserLoginInfoEnd = function () {

        if (CurrentUserId > 0) {
            var pram = { "UserID": CurrentUserId };
            runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetUserCredits", pram, GetScore);
        }
    }


});
function showhidepanel(obj) {
    $("#panelex").slideToggle("fast");
    if ($("#panelex").height() > 5) {
        //$(obj).css({ "background": "url(image/iknow-bmask.gif) no-repeat 0px -46px" });
        $(obj).attr("class", "wtbc");
        $("#NewsTitle").focus();
        var srcUrl = $("#btnshowhide img").attr("src").replace("23.png", "23_1.png");
        $("#btnshowhide img").attr("src", srcUrl);
    }
    else {
        //$(obj).css({ "background": "url(image/iknow-bmask.gif) no-repeat 0px -70px" });
        $(obj).attr("class", "wtbc");
        $("#ContentInfo_42be44b30062470eb3410fc474ef221c_editorBox").focus();
        var srcUrl = $("#btnshowhide img").attr("src").replace("23_1.png", "23.png");
        $("#btnshowhide img").attr("src", srcUrl);
    }
}

function GetScore(result) {
    sumscore = result.d;
    $("#scoref").html(sumscore);

}

function AddAsk() {

    var userid = SiteConfigsY.askuseridY;// CurrentUserId; //<%=base.UserID %>;// //
    if (CurrentUserId > 0) {
        userid = CurrentUserId;
    }
    if (userid <= 0) {
        openlogin(regbackfun);
        return;
    }
    var isOk = true;
    var msg = "";
    //获取参数值
    var title = $.trim($('#NewsTitle').val());
    var content = $.trim($("#ContentInfo_42be44b30062470eb3410fc474ef221c_editorBox").val()); //$.trim($('#ContentInfo').val());

    var score = $("#ScoreDDList").find("option:selected").val();
    var classType = $('#ddlBrand').val();
    var iEmail = $.trim($('#tbEmail').val());
    var iValidCode = $("#reg_yzm").val();
    if (($("#ddlCarModel").find("option").length) > 1) {
        classType = $('#ddlCarModel').val();
    }
    if (title === null || title === "") {
        msg += "标题不能为空  " + '\r';
        isOk = false;
    }
    if (content === null || content === "") {
        content = "";
    }
    if (score == "" || score == null) {
        msg += "请选择一个分数  " + '\r';
        isOk = false;
    }
    if (classType == "" || classType == -1) {
        msg += "请选择分类  " + '\r';
        isOk = false;
    }
    if (classType == 0) {
        msg += "请选择问答分类下的子分类  " + '\r';
        isOk = false;
    }

    if (sumscore < score) {
        msg += "您的分数不足  " + '\r';
        isOk = false;
    }
    if ($("#Dvem").css("visibility") == "visible") {
       
        if (iEmail == "" || iEmail == null) {
            msg += "Email不能为空  " + '\r';
            isOk = false;

        } else {
          
            if(!checkemail(iEmail)) {
                msg += "您输入Email地址不正确!  " + '\r';
                isOk = false;
            }
        }
    }
    if (iValidCode == "") {
        msg += "请输入验证码  " + '\r';
        isOk = false;
    } else {
        
    }
    if (isOk) {
        var ifNM = "0";
        var xuid = 0;
        if (GetUrlParams("uid") != "") {
            xuid = GetUrlParams("uid");
        }

        var pram = { "NewsTitle": title, "ContentInfo": content, "ScoreDDList": score, "AskClassType": classType, "UserID": userid, "IsAnonymity": ifNM, "tagUserId": xuid, "iemail": iEmail,"ValidCode":iValidCode };
       
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "AddAskContent", pram, aac_runws);
    }
    else {
        tips(msg, 2);
    }
}
function checkemail(str) {
    //在JavaScript中，正则表达式只能使用"/"开头和结束，不能使用双引号
    var Expression = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
    var objExp = new RegExp(Expression);
    if (objExp.test(str) == true) {
        return true;
    } else {
        return false;
    }
}
function aac_runws(result) {
    if (result.d.IsAddSuccess == true) {

        //yhl 2012-10-17
        if (GetUrlParams("uid") != "") {
            var pram = { "Qid": result.d.ID, "Uid": GetUrlParams("uid") };
            runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "ExpertsAdd", pram, null);
        }


        if (result.d.IsCheck == false) {
            tips("发表问题成功 <a href='" + result.d.WenPath + "'>查看</a>", 1, 10);
        }
        else {
            tips("问题正在审核中，请耐心等待！", 1, 2);
        }

    }
    else {
        if (result.d.EmailMsg != "" && result.d.EmailMsg!=null) {
            tips(result.d.EmailMsg , 2, 2);
        }
        else if (result.d.sSafeCoder != "" && result.d.sSafeCoder != null) {
            tips(result.d.sSafeCoder, 2, 2);
        }
        else {
            tips("请于" + result.d.WenPath + "分钟后 再发布。", 2, 2);
        }
       
    }
}

function subitfun() {
    var userid = CurrentUserId; //<%=base.UserID %>;//SiteConfigsY.askuseridY; //


    if (userid <= 0 || userid == undefined) {
        userid = SiteConfigsY.askuseridY;
    }
    if (userid <= 0 || userid == undefined) {
        openlogin(regbackfun);
        return;
    }
    else {
        AddAsk();
    }
}
/*提交问题 回抛方法*/
function regbackfun(uid) {
    SiteConfigsY.askuseridY = uid;
    AddAsk();
}