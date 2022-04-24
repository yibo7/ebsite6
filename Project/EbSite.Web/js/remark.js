var CountScore = 0;
//当用iframe时可以用这个来重新设置高度，以自动适应
function resizeFrame() {

    var xscomment = parent.document.getElementById("win");
    //alert(document.documentElement.scrollHeight);
    xscomment.style.height = document.body.scrollHeight + "px";
    var topPos = location.href.indexOf("#top");
    if (topPos > 0) {
        location.href = location.href.substring(0, topPos) + "#top1";;
    }

}

function reply(postid) {
    $("#postfoot" + postid).show();
}
function canclreply(postid) {
    $("#postfoot" + postid).hide();
}

function replypost(postid) {
    var sContent = $("#replybox" + postid).val();
    if (sContent.length > 300) {
        alert("对不起，你输入的字数太多，请限制在300字以内！");
        return;
    }
    var sdata = { postid: postid, msg: sContent };
    runebws("ReplyRemark", sdata, function (data) {
        if (data.d.Success) {
            Refesh();
        } else {
            alert(data.d.Message);
        }


    });
}


function replysub(postid) {
    $("#postfootsub" + postid).show();
}
function canclreplysub(postid) {
    $("#postfootsub" + postid).hide();
}



function replypostsub(postid) {
    var sContent = $("#replybox" + postid).val();
    if (sContent.length > 300) {
        alert("对不起，你输入的字数太多，请限制在300字以内！");
        return;
    }
    var sdata = { subid: postid, msg: sContent };
    runebws("ReplyRemarkSub", sdata, function (data) {
        if (data.d.Success) {
            Refesh();
        } else {
            alert(data.d.Message);
        }
    });
}





function ClientExecutePost(flag, postid, ob) {
    //flag:0支持，1返对，2举报
    var sdata = { postid: postid, flag: flag };
    runebws("ExecutePost", sdata, function (data) {
        if (data.d.Success) {
            $(ob).html("已提交");
        } else {
            alert(data.d.Message);
        }
    });
}
function ClientExecutePostSub(flag, postid, ob) {
    //flag:0支持，1返对，2举报
    var sdata = { postid: postid, flag: flag };
    runebws("ExecutePostSub", sdata, function (data) {
        if (data.d.Success) {
            $(ob).html("已提交");
        } else {
            alert(data.d.Message);
        }
    });
}

function savepl(RemarkClassID,ClassID,ContentId) {
    var smsg = $("#txtRemark").val();

    if ($.trim(smsg) == "") {
        alert("话太少，不能发表！");
    }
        

    var isNiName = $("#cbNiName").val();
    var txtEvaluationScore = parseInt($("#txtEvaluationScore").val());
   
    var sdata = { msg: smsg, niname: isNiName==1?true:false, rmcid: RemarkClassID, classid: ClassID, contentid: ContentId, score: txtEvaluationScore };
    runebws("SaveRemark", sdata, function (data) {
        if (data.d.Success) {
            if (data.d.Message != null && data.d.Message!="") {
                alert(data.d.Message);
            } else {
                Refesh();
            }
                
        } else {
            alert(data.d.Message);
        }
    });
}