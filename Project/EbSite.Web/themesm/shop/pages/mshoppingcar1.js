


Zepto(function ($) {
   // InitShopingCar();
});

//function InitShopingCar() {

//    //debugger;
//    $('.ItemQty input').keypress(function (event) {
//        if (event.charCode && (event.charCode < 48 || event.charCode > 57)) {
//            event.preventDefault();
//        }
//    }).change(function () {

//        if (isint(this)) {
//            var iQuantity = $(this).val();
//         
//            //更新到数据库
//            SetQuantity($(this).attr("pid"), iQuantity);
//        }
//        else { $(this).val(1); alert("数量必须是大于0的整数!"); }


//    });

//}

function clearshoppingcar() {

    if (confirm("您确认要清除购物车内所有商品吗?")) {
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "ClearCart", null,
            function (result) {
                if (result != null && result.d != null) {
                    Refesh();
                }
                else {
                    alert("清除购物车失败!");
                }

            });
    }
}


function delcart(sku, obj) {

    if (confirm("确认从购物车中移除此商品吗?")) {
        SetQuantity(sku, 0);
        $(obj).parent().parent().remove();
        //updatedata();
    }

}
function SetQuantity(spid, pnum) {
    //如果两秒内没有响应，将提示用户等待
    setTimeout(function () {
       
    }, 2000);
    var prid = spid;
    //修改商品数量
    var pram = { "sku": prid, "qty": pnum };
    runws("cfccc599-4585-43ed-ba31-fdb50024714b", "SetQuantity", pram,
    function (result) {

        if (result != null && result.d != null) {
            Refesh();
        }
        else {
            alert("修改商量数量失败!");
        }
    });
}





function sampbakfun(uid) {
    if (uid > 0) {
        var pram = { "userId": uid };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetUserScore", pram, gtUserScore);
    }
}

function gtUserScore(result) {
    var iscore = $("#HiScore").val();
    if (iscore == 0) {
        window.location.href = $("#GoNext").attr("kaurl");
    } else {
        if (iscore > result.d) {
            tips("您的积分总数不够！", 1);
        } else {
            window.location.href = $("#GoNext").attr("kaurl");
        }
    }

}



function delcraditcart(id, obj) {

    if (confirm("确认从购物车中移除此商品吗?")) {
        SetCreaditQuantity(id, 0);
        $(obj).parent().parent().remove();
        //updatedata();
    }
}


//更改 积分商品数据源
function SetCreaditQuantity(spid, pnum) {
    setTimeout(function () {
        
    }, 2000);
    var prid = spid;
    //修改商品数量
    var pram = { "id": prid, "qty": pnum };
    runws("cfccc599-4585-43ed-ba31-fdb50024714b", "SetCreaditQuantity", pram,
    function (result) {

        if (result != null && result.d != null) {
            Refesh();
        }
        else {
            alert("修改积分兑换商品数量失败!");
        }

    });
}