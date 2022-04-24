var iscore = 0;
var iurl = "";
function addtoshoppingcar(shoppingcarurl, iCredit,iuserid) {
   
    iscore = iCredit;
    iurl = shoppingcarurl;
    if (iuserid > 0) {
        var pram = { "userId": iuserid };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetUserScore", pram, function (result) {
            if (iCredit > result.d) {
                $("#panelMsg").html("您的积分总数不够");
                $('#panelMsg').dialog('open', 20, 20);
              
            } else {
               
                var url = shoppingcarurl;
                location.href = url;
            }
        });
    }
    else {
       
//        $("#panelMsg").html("先登录");
//        $('#panelMsg').dialog('open', 20, 20);
    }
}

function bakfun(uid) {
    if (uid > 0) {
        var pram = { "userId": uid };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetUserScore", pram, function (result) {
            if (iscore > result.d) {
                $("#panelMsg").html("您的积分总数不够");
                $('#panelMsg').dialog('open', 20, 20);
            } else {
               
                var url = iurl;
                location.href = url;
            }
        });
    }
}

