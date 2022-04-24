
function gotoChangePass(obj) {
    var number = $("#emailormobile").val();
    var safecode = $("#yzmmobile").val();
    $(obj).attr("disabled", false);
    runebws("FindPassMobile", { mbnumber: number, code: safecode }, function (data) {
        if (data.d) {
            if (data.d.Success) {
                window.location.href = data.d.Message;
            }
            else {
                alert(data.d.Message);
            }
        } else {
            alert("提交错误！");
        }
    });
}
function getSafeCode(objthis) {

    var number = $("#emailormobile").val();
    var obj = $(objthis);
    runebws("SendMobileValCode", { mbnumber: number }, function (data) {
        if (data.d) {
            if (data.d.Success) {
                var countdown = 60;
                settime(obj);
                function settime(obj) {
                    if (countdown == 0) {
                        obj.attr("disabled", false);
                        obj.val("获取验证码");
                        countdown = 60;
                        return;
                    } else {
                        obj.attr("disabled", true);
                        obj.val("重新发送(" + countdown + ")");
                        countdown--;
                    }

                    setTimeout(function () {
                        settime(obj)
                    }, 1000);
                }
            }
            else {
                alert(data.d.Message);
            }
        } else {
            alert("验证码发送错误！");
        }
    });


}