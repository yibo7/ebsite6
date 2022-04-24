
//ShopCar.ascx
//function stripe() {
//    $('#cart tbody tr:visible:even').removeClass('odd').addClass('even');
//    $('#cart tbody tr:visible:odd').removeClass('even').addClass('odd');
//};

function InitShopingCar() {

    $('.quantity input').keypress(function (event) {
        if (event.charCode && (event.charCode < 48 || event.charCode > 57)) {
            event.preventDefault();
        }
    }).change(function () {
        var totalQuantity = 0;
        var totalCost = 0;
        $('.gdListContent').each(function () {
            var price = parseFloat($('.price', this).text().replace(/^[^\d.]*/, ''));

            price = isNaN(price) ? 0 : price;
            var quantity = parseInt($('.quantity input', this).val());
            quantity = isNaN(quantity) ? 0 : quantity;
            var cost = quantity * price;

            $('.cost', this).text(cost.toFixed(2));
            totalQuantity += parseInt(quantity);
            totalCost += cost;

        });

        $('.carcount .quantity').text(String(totalQuantity));
        $('.carcount .cost').text(totalCost.toFixed(2));

        //更新到数据库
        SetQuantity($(this).attr("pid"), totalQuantity);
    });
//    stripe();

}


function addnum(obj) {

    var iadd = $('#' + obj).val();
    iadd = isNaN(iadd) ? 0 : iadd;
    iadd = parseInt(iadd) + 1;
    $('#' + obj).val(iadd).trigger('change').end();

    
}
function remoiviecart(obj1) {

    var iremove = $('#' + obj1).val();
    iremove = isNaN(iremove) ? 0 : iremove;
    iremove = parseInt(iremove) - 1;
    $('#' + obj1).val(iremove).trigger('change').end();
}

function SetQuantity(spid, pnum) {
    var prid = parseInt(spid);
    //修改商品数量
    var pram = { "pid": prid, "qty": pnum };    
    runws("SetQuantity", pram,
    function(result) {
        if (result != null && result.d != null) {

        }
        else {
            alert("修改商量数量失败!");
        }

    });
}

function delcart(obj2) {

    if (confirm("确认从购物车中移除此商品吗?")) {
        //设置为0将删除
        $('#' + obj2).val(0).trigger('change').end();
        $('#' + obj2).parent().parent().parent().parent().remove();
    }

}

function clearshoppingcar() {

    if (confirm("您确认要清除购物车内所有商品吗?")) {
        runws("ClearCart", null,
            function (result) {
                if (result != null && result.d != null) {
                    $(".gdListContent").remove();
                }
                else {
                    alert("清除购物车失败!");
                }

            });
    }
}

//end ShopCar.ascx

