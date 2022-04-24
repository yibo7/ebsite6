var iscore = 0;
var iurl = "";
function addtoshoppingcar(shoppingcarurl, iCredit) {
    var userid = CurrentUserId;
    iscore = iCredit;
    iurl = shoppingcarurl;
    if (userid > 0) {
        var pram = { "userId": userid };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetUserScore", pram, function (result) {
            if (iCredit > result.d) {
                tips("您的积分总数不够！", 1);
            } else {
                tips("正在执行", 1, 20);
                var url = shoppingcarurl;
                location.href = url;
            }
        });
    }
    else {
        openlogin(bakfun);
    }
}

function bakfun(uid) {
    if (uid > 0) {
        var pram = { "userId": uid };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetUserScore", pram, function (result) {
            if (iscore > result.d) {
                tips("您的积分总数不够！", 1);
            } else {
                tips("正在执行", 1, 20);
                var url = iurl;
                location.href = url;
            }
        });
    }
}

