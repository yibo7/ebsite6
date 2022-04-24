
In.ready('gmuw-dialog', 'gmue-highlight', 'gmue-parseTpl', function () {
    $('#dialogAnswer').dialog({
        autoOpen: false,
        closeBtn: true,
        scrollMove: false,
        width: 300,
        height: 190,
        buttons: {
            "关闭": function () {
                this.close();
            },
            '确定': function () {
                SubmitGoOnAnswer(this);
            }

        }
    });
});
m_dialog("panelMsg", "200", "130");
//取消回答
function CancelAnswer(obj) {
    $(obj).parent("div").parent("div").remove();
}
//继续回答
function GoOnAnswerEx(index, pid, aid) {
    var gaContext = $.trim($("#txtGoOnRef_" + index).val());
    if (gaContext != "" && gaContext != undefined && aid != "0" && aid != 0) {
        var param = { "answersid": aid, "ctent": gaContext, "typeid": 1, "eid": pid };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GoToAddAsk", param, function (data) {
            var result = data.d;
           
            if (result) {
                $('#panelMsg').html("回答成功");
                $('#panelMsg').dialog('open', 20, 20);
                Refesh();
            }
        });
    }
}
//继续追问
function SubmitGoOnAnswer(obj) {
    var tmpContext = $.trim($("#txtGoOn").val());
    var aid = $("#hidtmpaid").val();
    if (tmpContext != "" && tmpContext != undefined && aid != "0" && aid != 0) {
        var param = { "answersid": aid, "ctent": tmpContext, "typeid": 0, "eid": 0 };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GoToAddAsk", param, function (data) {
            var result = data.d;
           
            if (result) {
                $('#panelMsg').html("追问成功");
                $('#panelMsg').dialog('open', 20, 20);
                Refesh();
            }
        });
    }
}
//提交回答
function SubmitAnswer(qid, quid, auid) {
    var submitContext = $.trim($("#txCtent").val());
    if (submitContext == "" || submitContext == undefined) {
        $('#panelMsg').html("回答内容不能为空");
        $('#panelMsg').dialog('open', 20, 20);
    }
    else {
        //声明参数
        var param = { "qid": qid, "quid": quid, "auid": auid, "context": submitContext, "isanonymity": 0 };
        //提交数据
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "SubmitAnswer", param, function (data) {
            var result = data.d;
            if (result == "1") {
                //回答成功
                $('#panelMsg').html("提交成功");
                $('#panelMsg').dialog('open', 20, 20);
                Refesh();
            }
            else if (result == "2") {
                //您已经回答过此问题
                $('#panelMsg').html("您已经回答过此问题");
                $('#panelMsg').dialog('open', 20, 20);
            }
            else if (result.length > 1) {
                //$('#panelMsg').html("问题提交失败，请重新提交");
                //$('#panelMsg').dialog('open', 20, 20);
                window.location.href = result;
            }
        });
    }
}
function GoOnAnswer(id) {
    $('#dialogAnswer').dialog('open', 20, 20);
    $("#hidtmpaid").val(id);
}
function SetThankWord() {
    var tmpThankWord = $.trim($("#txtThankWord").val());
    if (tmpThankWord == "" || tmpThankWord == undefined) {
        tmpThankWord = "感谢您的回答!";
    }
    var tid = $("#tmpAnswerID").val();
    var param1 = { "answerid": tid, "thankInfo": tmpThankWord };
    //更新数据
    runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "SetBestAnswer", param1, function (data) {
        var result = data.d;
        if (result == "1" || result == 1) {
            togglePanel2();
            $("#btnPanel").hide();
            Refesh();
        }
        else if (result == "0" || result == 0) {
            $('#panelMsg').html("此问题已经有满意答案");
            $('#panelMsg').dialog('open', 20, 20);
        }
        else {
            $('#panelMsg').html("回答失败，请重新提交");
            $('#panelMsg').dialog('open', 20, 20);
        }
    });
}
function SetBestAnswer(tid) {
    $("#panelbar1").hide();
    $("#panelbar2").show();
    $("#tmpAnswerID").val(tid);

}
function togglePanel2() {
    $("#panelbar2").hide();
    $("#panelbar1").show();
}