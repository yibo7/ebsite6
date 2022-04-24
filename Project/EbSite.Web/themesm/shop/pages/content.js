
Zepto(function ($) {

    var it = GetUrlParams('t');
    if (it != 0) {
        $("#PJianjie").hide();
    }


    InitNormsToSel();
    /*数量 加1*/
    $(".increase").click(function () {

        var i = $("#txtChangeBuyNum").val();
        $("#txtChangeBuyNum").val(i * 1 + 1);
        CheckStocks();

    });
    /*数量 减1*/
    $(".decrease").click(function () {

        var i = $("#txtChangeBuyNum").val();
        if (i == 1) {
            $("#panelMsg").html("数量最少为1个！");
            $('#panelMsg').dialog('open', 20, 20);
        }
        else {
            $("#txtChangeBuyNum").val(i * 1 - 1);
            CheckStocks();
        }

    });




    $("#productgglist li input[type=button]").click(function () {

        debugger;
        var DataID = $(this).attr("pid"); //当前规格ID,非规格值ID
        var RowID = "PNorm" + DataID; //获取选规格值所在的规格ID
        $("#" + RowID).find("input[type=button]").removeClass("ggcurrent"); //将其下的样式全部清空
        $(this).addClass("ggcurrent"); //设置选中项的样式
        //保存所选值到隐藏控件
        //$(this).parent().parent().find("input[type=hidden]").first().val($(this).attr("ValueId"));
        $("#PNormValue" + DataID, $($("#" + RowID))).val($(this).attr("ValueId"));

        //start以下拼接所有选中的规格值到selNormsValue隐藏控件 
        var iProductID = $("#selNormsValue").attr("productid"); //获取产品ID
        var skey = iProductID + "_";
        var iRowIndex = 0;
        var aRows = [];

        $("#productgglist li").each(function (i) {
            aRows.push(this);
            var iid = $(this).attr("dataid");
            if (iid) {

                skey += iid + "-" + $("#PNormValue" + iid).val() + "--"; //342_4-11--5-13

                if ($(this).attr("id") == RowID) {
                    iRowIndex = i;
                }
            }
        });
        var NormsValue = skey.substring(0, skey.length - 2);
        $("#selNormsValue").val(NormsValue);
        //end

        GetDataListBySelIndex($(this).attr("pid"), $(this).attr("ValueId"), $(this));

        updateprice();
        this.blur();


    });


    //商品附加费用选项
    $("#ProductOption .ebProductOptionItem li").each(function (i) {
        var IsGive = $(this).attr("IsGive");
        $(this).click(function () {
            $(this).siblings().removeClass("cur"); //将兄弟节点样式清空
            if ($(this).attr("class") == "cur" && IsGive != "True")      //判断该元素的class值 IsGive 赠送的不用删除
            {
                $(this).removeClass("cur");
            } else {
                $(this).addClass("cur");
            }

            var RowID = $(this).attr("RowID"); //值对应的选项ID
            //设置所选项的值到隐藏控件
            $("#OptionRowSelValue" + RowID).val($(this).attr("DataID"));
            var aSelValue = [];
            $("#ProductOption").find("input[type=hidden]").each(function (j) {
                var dValue = $(this).val();

                if (dValue > 0) {
                    aSelValue.push(dValue);
                }
            });
            if (aSelValue.length > 0) {
                $("#selProductOption").val(aSelValue.join("_"));
            }

            CheckStocks();
        });


        if (IsGive == "True") {
            $(this).click();
        }
    });



});


function CheckStocks() {
    //debugger;
    //库存量
    var iStocks = $("#spStocks").text();
    //用户输入购买数量
    var iInputValue = $("#txtChangeBuyNum").val();
    //剩下库存量
    var rz = iStocks - iInputValue;

    var isCheckStocks = true;  //可以在后台设置是否验证库存，库存数量不足不允许购买

    if (iStocks > 0 && (rz >= 0)) {//isCheckStocks暂时不用
        var ChangePrice = $("#spSalePrice").text() * iInputValue;
        ChangePrice += GetProductOptinsFree(); //加上商品附加选项费用
        $("#spAllPrice").text(ChangePrice);
    } else {
        isCheckStocks = false;
        $("#panelMsg").html("抱歉,库存量不足" + iInputValue + "个！");
        $('#panelMsg').dialog('open', 90, 90);
        
       
        $("#txtChangeBuyNum").val(iStocks);
    }
    return isCheckStocks;
}


//获取销售价格
function GetSalePrice() {
    var ProcuctSalePrice = $("#spSalePrice").text();
    return parseFloat(ProcuctSalePrice);
}
//获取商品附加选项费用
function GetProductOptinsFree() {
    var Price = 0;
    var ProcuctSalePrice = GetSalePrice();
    $("#ProductOption .ebProductOptionItem li").each(function (i) {
        var IsGive = $(this).attr("IsGive");
        var IsCheck = ($(this).attr("class") == "cur");
        if (IsGive == "False" && IsCheck) {
            var CalculateMode = parseInt($(this).attr("CalculateMode")); //计算方式
            var AppendMoney = parseFloat($(this).attr("AppendMoney")); //计算值

            if (CalculateMode == 0) {

                Price += AppendMoney;
            } else {
                var pcen = AppendMoney / 100;
                Price += ProcuctSalePrice * pcen;
            }
        }

    });
    return Price;
}



function InitNormsToSel() {

   
    var sv = $("#selNormsValue").val();

    var aNormIDs = [];
    if ($.trim(sv) != "") {

        var arr1 = sv.split('_');

        if (arr1.length == 2) {
            var aidandvalue = arr1[1].split('--');
            if (aidandvalue.length > 0) {
                for (var i = 0; i < aidandvalue.length; i++) {
                    var av = aidandvalue[i].split('-');
                    if (av.length == 2) {

                        aNormIDs.push(av[1]);

                    }
                }


            }

        }
        if (aNormIDs.length > 0) {
            for (var i = 0; i < aNormIDs.length; i++) {
                $("#SNorm" + aNormIDs[i]).parent().parent().find("input[type=hidden]").first().val(aNormIDs[i]);
                $("#SNorm" + aNormIDs[i]).addClass("ggcurrent");
            }
        }
    }

}



function GetDataListBySelIndex(rowid, columid, selob) {

    var aProductAllNormkey = $("#hpAllNormkey").val().split("#");

    var aDataList = [];
    if (aProductAllNormkey.length > 0) {
        for (var i = 0; i < aProductAllNormkey.length; i++) {

            var dataRow = aProductAllNormkey[i].split("_");
            if (dataRow.length == 2) {
                var aRowvalue = dataRow[1].split("--");
                for (var j = 0; j < aRowvalue.length; j++) {
                    var aColum = aRowvalue[j].split("-");
                    if (aColum[0] == rowid && aColum[1] == columid)
                        aDataList.push(dataRow[1]);
                }
            }
        }

    }
    $("#productgglist li input[type=button]").addClass("ggnoallow");
    $("#productgglist li input[type=button]").prop("disabled", true);
    for (var j = 0; j < aDataList.length; j++) {
        var aidandvalue = aDataList[j].split('--');
        if (aidandvalue.length > 0) {
            for (var i = 0; i < aidandvalue.length; i++) {
                var av = aidandvalue[i].split('-');
                if (av.length == 2) {

                    $("#SNorm" + av[1]).removeClass("ggnoallow");
                    $("#SNorm" + av[1]).prop("disabled", false);

                }
            }


        }

    }
    $("input[type=button]", selob.parent()).removeClass("ggnoallow");
    $("input[type=button]", selob.parent()).prop("disabled", false);
    var isreset = false;
    $("#productgglist li input[type=button]").each(function () {
        if (!$(this).prop("disabled") && $(this).attr("class") == "ggcurrent")
            isreset = true;
    });
    if (isreset) {

        $("#productgglist li input[type=button]").removeClass("ggcurrent");
        $("#selNormsValue").val($("#selNormsValue").attr("productid") + "_" + aDataList[0]);
        InitNormsToSel();
    }

}


function updateprice() {

    var NormsValues = $("#selNormsValue").val();
    var pram = { "id": NormsValues };

    runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetPriceByNormID", pram, function (msg) {

        $("#spCostPrice").html(msg.d.CostPrice);
        //        $("#spMarketPrice").html(msg.d.MarketPrice);
        $("#spPNumber").html(msg.d.PNumber);
        $("#spSalePrice").html(msg.d.SalePrice);
        $("#spStocks").html(msg.d.Stocks);
        $("#spWeight").html(msg.d.Weight);
        CheckStocks();

    });   
}

//2013-12-31

function getshoppingcarurl() {
    
    var shoppingcarurl = $("#ShoppingCarUrl").val();
    var NormsValues = $("#selNormsValue").val();
    var iBuyNum = parseInt($("#txtChangeBuyNum").val());
    var tmpKuCun = parseInt($("#spStocks").text());
    
    //判断购买数量和库存数量
    if (iBuyNum > tmpKuCun) {
        KuCunMsg();
    }
    else {
        var ProductOption = $("#selProductOption").val();
        var isok = CheckStocks();
        if (isok) {
            return shoppingcarurl + "&num=" + iBuyNum + "&normid=" + NormsValues + "&otp=" + ProductOption;
        }
    }
    return "";
}

function addtoshoppingcar() {
    var url = getshoppingcarurl();
    if (url != "") {
        location.href = url;
    }
}


function KuCunMsg() {
    $("#panelMsg").html("抱歉,库存量不足!");
    $('#panelMsg').dialog('open', 90, 90);
}
