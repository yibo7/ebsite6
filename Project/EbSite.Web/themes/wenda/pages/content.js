
//打开举报对话框
function openjubao() {

    In.ready('tinybox', function () {                //执行代码

        TINY.box.show(SiteConfigs.ThemePath + 'jubao.html', 1, 500, 300, 1);


    });
}



////打开感言
//function openSetBest() {

//    In.ready('tinybox', function () {                //执行代码

//        TINY.box.show(SiteConfigs.ThemePath + 'SetBestAnswer.html', 1, 450, 200, 1);


//    });
//}
//继续追问
//function openAddAsk() {

//    In.ready('tinybox', function () {                //执行代码

//        TINY.box.show(SiteConfigs.ThemePath + 'AddAsk.html', 1, 450, 200, 1);
//    });
//}
//继续追问 回答
function openGoAddAsk() {

    In.ready('tinybox', function () {                //执行代码

        TINY.box.show(SiteConfigs.ThemePath + 'GoAddAnswer.html', 1, 450, 200, 1);
    });
}



// ====================内容=begin======================//
// 同问 添加 ==begin
function sameOp() {
    var userid = CurrentUserId;
   
    if (userid > 0) {
        sampbak();
    }
    else {
        openlogin(sampbakfun);
    }
}
function sampbak() {
    if (CurrentUserId > 0) {
        var pram = { "cid": SiteConfigsX.contentIDX, "userid": CurrentUserId };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "SameQuestionOp", pram, function (result) {
            $("#follow-btn").html(result.d + "人同问");
        });
    }
}
function sampbakfun(uid) {
    currentpguserid = uid;
    sampbak();
}
// 同问end ====

//同问 检测同问 鼠标离开
function cksamefunout() {
    
    var pram = { "cid": SiteConfigsX.contentIDX };
    runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "SameQuestionOpSel", pram, function (result) {
        if (result.d == "0") {
            $("#follow-btn").html("同问");
        }
        else {
            $("#follow-btn").html(result.d + "人同问");
        }

    });
}

//同问 检测同问 鼠标放上去
function cksamefun() {
   
    if (CurrentUserId > 0) {
        var pram = { "cid": SiteConfigsX.contentIDX, "userid": CurrentUserId };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "IfSameQuestion", pram, function (result) {
            if (!result.d) {
                //            $("#follow-btn").unbind('click', sameOp)
                //  .text("已同问");
                $("#follow-btn").html("已同问");

            }
        });
    }
}


function editAnswer(askquestionID, answerUid) {
    // $("#edit" + answerUid).attr("disabled", "disabled");
    $("#edit" + answerUid).show();
    $("#bnSubit").show();
    $("#bnedit").hide();

}


function GetIfNi(result) {
    //是否匿名 发表
    if (result.d.NiMingAnswer) {
        $("#CKNiDiv").css("display", "block");
    }
}
function bk_IsHaveAnswer(result) {  //状态 为 未解决 如果 回答过 就隐藏

    if (result.d == true) {
        $("#answerdiv").hide();
    }
    else {
        $("#answerdiv").show();
    }
}




//无满意答案 关闭问题
function NoBestAnswer() {
    if (confirm("是否要关闭问题？")) {
        var contentid = SiteConfigsX.contentIDX; // <%=Model.ID  %> ;//问题ID
        var pram = { "ContentID": contentid };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "CloseAsk", pram, bk_CloseAsk);
    }
}
function bk_CloseAsk(result) {
    //无满意答案 的返回方法
    if (result.d == true) {

        $("#asktl").html("已关闭");
        $('#stateNo').hide();  //隐藏 无满意答案。  

        $("#EditQuestionDiv").attr("display", "none");
        $("#EditQuestionDiv").hide();
        $("#UpScoreDiv").attr("display", "none");
        $("#UpScoreDiv").hide();
        tips("问题成功关闭", 1, 2);
    }
    else {
        tips("问题关闭失败", 2, 2);
    }
}

//提交 答案 提交 答案 提交 答案 ===================begin
function SubmitAnswer() {
    var userid = CurrentUserId;
   
    if (userid > 0) {
        SubmitAnswerBack();
    }
    else {
        openlogin(SubmitAnsweBackFun);
    }

}

function SubmitAnswerBack() {
    var userid = CurrentUserId;
    
    var content = $.trim($('#answercontent').val()); //document.getElementById("answercontent").value;
    var askcontentid = SiteConfigsX.contentIDX; //<%=Model.ID  %> ;
    var askuserid = SiteConfigsX.askuseridX; // <%=Model.UserID %>;
    // alert(content+"|"+userid+"|"+askcontentid+"|"+askuserid);

    if (userid > 0) {
        //这里要判断是否是发表人
        if (askuserid == userid) {
            tips("请注意，不能自问自答。", 2, 2);
        }
        else {
            //先判断是否为空
            if (content == "") {
                tips("回答不能为空", 2, 2);
                return;
            }
            //先判断该用户是否评论过
            var pram = { "UID": userid, "AskContentID": askcontentid };
            runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "UserHaveSay", pram, bk_UserHaveSay); //判断用户是否已经回答过                  
        }
    }
}
function SubmitAnsweBackFun(uid) {
    currentpguserid = uid;
    SubmitAnswerBack();

}
//====================end==========================
function bk_UserHaveSay(result) {
    //判断用户是否已经回答过
    if (result.d == true) {
        tips("已经回答过了", 2, 2);
    }
    else {
        //回答
        var userid = CurrentUserId; //<%=base.UserID %>;
       
        var content = document.getElementById("answercontent").value;
        var askcontentid = SiteConfigsX.contentIDX; //<%=Model.ID  %> ;
        var askuserid = SiteConfigsX.askuseridX; //<%=Model.UserID %>;
        var ifNM = "false";
        if ($("#CKNi").attr("checked")) //匿名
        {
            ifNM = "true";
        }
        var pram = { "Content": content, "UID": userid, "AskContentID": askcontentid, "AskUID": askuserid, "hideAnwer": ifNM };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "SubmitContentInfo", pram, bk_SubmitContentInfo); //提交问题回答 
    }
}

function bk_SubmitContentInfo(result) {
    //提交问题回答
    if (result.d.ID > 0) {

        if (result.d.IsCheck) {
            tips("提交回答成功！为了确保问答的质量，我们会对您的回答内容进行审核。请耐心等待......！", 3, 3);
            $("#answerdiv").hide();
        }
        else {
            $(".ans_listx").append(result.d.Info);
            $("#answerdiv").hide();
           // TINY.box.hide();
        }

    }
    else {
        tips("评论失败", 2, 2);
    }
}


// 修改答案
function MdfAnswer(askquestionID, answerUid) {
    var userid = CurrentUserId;
    var uid = answerUid;
    var content = $.trim($("#editCt" + answerUid).val());
    var askcontentid = askquestionID;
    if (userid > 0) {
        // 先判断是否为空
        if (content == "") {
            tips("回答不能为空", 2);
            return;
        }
        if (content == $("#xHf" + answerUid).html()) {
            tips("请修改回答内容", 2);
            return;
        }
        // 修改评论
        var pram = { "Content": content, "UID": userid, "AskContentID": askcontentid };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "UpdateContentInfo", pram, function (result) {
            if (result.d == 2) {
                $("#bnSubit").hide();
                $("#bnedit").show();
                $("#edit" + answerUid).hide();
                $("#xHf" + answerUid).html(content);
                tips("修改成功", 1, 2);

            }
            else if (result.d == 1) {
                $("#bnSubit").hide();
                $("#bnedit").show();
                $("#edit" + answerUid).hide();
                $("#xHf" + answerUid).html("本回答正在审核中...");
                tips("修改成功,您的回答正在审核中，请耐心等待。", 1, 2);
            }
            else {
                tips("修改失败", 2, 2);
            }
        });
    }
    else {
        openlogin(); //这种情况不会出 ，只有登录后才会现 修改
    }
}
//function MdfCancelAnswer() {
//    ////取消修改
//    $("#updatediv").hide();
//}



//设为 最佳 答案
//var iansweruid = 0;
function SetBestAnswer(answeruid) {

    $("#best" + answeruid).show();
    $("#zw" + answeruid).hide();


}
function toSetBestAnswer(answeruid) {
    // var answeruid = iansweruid;

    var ictent = $("#mc" + answeruid).val();
    if (ictent == "") {
        tips("不能为空！", 2);
    }
    else {
        var askcontentid = SiteConfigsX.contentIDX; //<%=Model.ID  %> ;
        var pram = { "AskContentID": askcontentid, "AnswerUid": answeruid, "ctent": ictent };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "SetTheBestAnswer", pram, bk_SetTheBestAnswer);
    }
}
function bk_SetTheBestAnswer(result) {
    if (result.d.Key == true) {
        //        tips("感言成功", 1);
        //        toCancelFavClass();
        window.location.href = ('../../index.aspx?site=2');
        window.location.reload();
    }
    else {
        tips("设置失败", 2);
    }
}



// 投票
var key = 0;
function vote(obj) {
    if (key == 0) {
        key = 1;
        var pram = { "answerid": obj };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "OppVote", pram, bk_vote);
    }
    else {
        tips("您已评价", 3);
    }
}
//投票
function bk_vote(result) {
    $("#goodcount").text(result.d);
}

//补充问题
function EditQuestion() {
    $("#EditQuestionDiv").attr("display", "disabled");
    $("#EditQuestionDiv").show();
    $("#UpScoreDiv").attr("display", "none");
    $("#UpScoreDiv").hide();
}
function MdfAsk() {
    var iid = SiteConfigsX.contentIDX;
    var icid = SiteConfigsX.contentCIDX;
    var content = $.trim($('#EditEdAsk').val());
    // 先判断是否为空
    if (content == "") {
        tips("补充内容不能为空", 2);
        return;
    }
    // 补充内容
    var pram = { "id": iid, "info": content, "classid": icid };
    alert(icid);
    runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "AddedAskInfo", pram, bk_addedAskInfo);
}
//补充问题
function bk_addedAskInfo(result) {
    if (result.d != "") {
        tips("补充问题成功！");
        $("#EditQuestionDiv").attr("disabled", "none");
        $("#EditQuestionDiv").hide();
        $("#newcontentinfo").html(result.d);
        //$("#oldcontentinfo").html("");

    }
}
///==================begin==========换了另一种  收藏 方式 FavContent（）进去可以分类的
////添加到收藏夹
//function FavAdd() {
//    var userid = ExUsrID;
//    if (currentpguserid > 0) {
//        userid = currentpguserid;
//    }
//    if (userid > 0) {
//        //要判断用户的级别
//        var pram = { "UserID": userid };
//        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetIfFav", pram, bk_GetIfFav);
//    }
//    else {
//        openlogin(); // alert("请先登录！");
//    }
//}
//function bk_GetIfFav(result) {
//    if (result.d) {
//        var ifavType = 0;
//        var iuserid = ExUsrID;
//        if (currentpguserid > 0) {
//            iuserid = currentpguserid;
//        }
//        var iclassId = 0;
//        var icontentId = SiteConfigsX.contentIDX;
//        var pram = { "contentId": icontentId, "classId": iclassId, "favType": ifavType, "userId": iuserid };
//        runebws("IfAddFavorite", pram, function (result) {
//            if (result.d) {
//                runebws("AddFavorite", pram, bk_AddFavorite);
//            }
//            else {
//                tips("您已经收藏过此信息。", 1);
//            }
//        });
//    }
//    else {
//        tips("您所在的级别(新手)无法进行此操作。", 2);
//    }
//}

//function bk_AddFavorite(result) {
//    if (result.d) {
//        tips("收藏成功！", 1);
//    }
//    else {
//        tips("失败！", 1);
//    }
//}
//=======================================end

//添加举报
//添加到举报
//key 0 问题。 1为回答
function JuBaoAdd(obj, key) {

    var userid = CurrentUserId;
   
    if (userid > 0) {
        //要判断用户的级别
        var pram = { "UserID": userid };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetIfJuBao", pram, bk_GetIfJuBao);
    }
    else {
        openlogin(); // alert("请先登录！");
    }
}
function bk_GetIfJuBao(result) {
    if (result.d) {
        openjubao();
    }
    else {
        tips("您所在的级别(新手)无法进行此操作。", 2);

    }

}
//    function bk_AddFavorite(result)
//    {
//        if(result)
//        {
//          alert("举报成功！");
//        }
//        else
//        {
//          alert("失败");
//        }
//    }

//=============提高悬赏=============
var sumscore = 0;
//提高悬赏
function UpScore() {
    $("#EditQuestionDiv").css("display", "none");
    $("#EditQuestionDiv").hide();
    $("#UpScoreDiv").css("display", "block");
    $("#UpScoreDiv").show();
    var userid = CurrentUserId;
  

    if (userid > 0) {
        var pram = { "UserID": userid };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetUserCredits", pram, GetScore);
    }
    runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "UpScoreModel", pram, GetUpScoreModel);
}

function GetUpScoreModel(result) {
    $("#dysa").html(result.d.Days);
    $("#iscore").html(result.d.Score);
    $("#xscore").html(result.d.Score);
}
function GetScore(result) {
    sumscore = result.d;
    $("#scoref").html(sumscore);
}
//取消
function ClearUpScore() {
    $("#UpScoreDiv").css("display", "none");
    $("#UpScoreDiv").hide();
}
//确定追加悬赏分
function OkUpScore() {

    var iscore = $("#ScoreDDList").find("option:selected").val();
    var icid = SiteConfigsX.contentIDX; //<%=Model.ID  %> ; 
    var pram = { "cid": icid, "score": iscore };
    runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "UpScoreOp", pram, GetUpScoreOP);
}
function GetUpScoreOP(result) {
    if (result.d) {
        tips("悬赏成功", 1);
        $("#UpScoreDiv").css("display", "none");
    }
}



//===继续追问 和 回答
var ianswerid = 0; //暂存 回答id 
var iansweridx = 0; //暂存 回答id 
//继续追问
function SetAddAsk(answeruid, obj) {
    ianswerid = obj;
    // openAddAsk();
    // $("#best" + answeruid).attr("disabled", "none");
    $("#best" + answeruid).hide();
    $("#zw" + answeruid).show();

}
function toAddAsk(answeruid, obj) {
    var ct = $("#adaskct" + answeruid).val();
    if (ct == "") {
        tips("追问不能为空", 2);
        return;
    }
    var pram = { "answersid": obj, "ctent": ct, "typeid": 0, "eid": 0 };
    runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GoToAddAsk", pram, function (result) {
        if (result.d) {
            $("#zw" + answeruid).hide();
            $("#bxZw" + answeruid).hide();
            $("#xResult" + answeruid).html("<li>[<font color=\"#FF0000\"> " + $("#xResult" + answeruid).attr("d") + "</font>]追问：" + ct + "?</li>");
            tips("追问成功", 1);

        }
    });

}


function GoSetAddAsk(obj) {

    $("#ToHf" + obj).show();


}

///回答追问
function GoToAddAsk(obj, pid) {
    var ct = $("#adawct" + obj).val();
    if (ct == "") {
        tips("回答不能为空", 2); //iansweridx
        return;
    }
    var pram = { "answersid": pid, "ctent": ct, "typeid": 1, "eid": obj };
    runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GoToAddAsk", pram, function (result) {
        if (result.d) {
            $("#ToHf" + obj).hide();
            $("#fs" + obj).hide();

            $("#xResult1").html("<div class=\"clear\"></div> <div class=\"normal\" style=\"width: 620px; margin-left: 0px;\"> <div class=\"normalarrow\"> </div> 回答：" + ct + "</div>");

            tips("回答成功", 1);

        }
    });
}


// ====================内容=end======================//  
