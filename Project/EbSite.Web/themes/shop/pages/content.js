/*不能丢弃的样式 eb_tuijiancb  eb_zuhecb*/
In.ready('customtags', function () {
    var Tags = new CustomTags();
    Tags.ParentObjName = "contabs2";
    Tags.SubObj = "li";
    Tags.CurrentClassName = "cur2";
    Tags.ClassName = "";

    Tags.InitOnclickInTags();
    Tags.InitOnclick(0);

    var Tags3 = new CustomTags();
    Tags3.ParentObjName = "contabs3";
    Tags3.SubObj = "li";
    Tags3.CurrentClassName = "cur2";
    Tags3.ClassName = "";

    Tags3.InitOnclickInTags();
    Tags3.InitOnclick(0);

    var Tags4 = new CustomTags();
    Tags4.ParentObjName = "contabs4";
    Tags4.SubObj = "li";
    Tags4.CurrentClassName = "cur2";
    Tags4.ClassName = "";
    var my_element = $("#contabs4");
    if (my_element.length > 0) {
        Tags4.InitOnclickInTags();
        Tags4.InitOnclick(0);
    }
});
jQuery(function ($) {
    debugger;
    //适用车型
    $("#eXSuitCar").html($("#suitcar").html());

    $("#ebproductbigimgzoom").attr("href", $("#ebproductbigimg").attr("src"));
    $("#pic_smallimgsel img").click(
        function () {
            var bigimg = $(this).attr("bigimg"); //500*425 
            var oldimg = $(this).attr("oldimg"); //原始图片 也是放大器的图片
            var bigimgurl = $("#picurl").attr("href"); //相册地址

            $("#ebproductbigimg").attr("src", bigimg);
            $("#ebproductbigimgzoom").attr("jghref", oldimg); //右侧放大器的图片
            $("#ebproductbigimgzoom").attr("href", bigimgurl); //所有图片相册的地址
            $("#pic_smallimgsel li").removeClass("current");
            $($(this).parent()).addClass("current");

        });
    $("#pic_smallimgsel img").first().click();

    $("#productgglist li :input[type=button]").click(function () {
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
    $("#txtChangeBuyNum").change(function () {
        if (isint(this)) {
            CheckStocks();
        } else { $(this).val(1); tips("数量必须是大于0的整数！"); }


    });
    InitNormsToSel();

    In.ready('jqzoom', function () {
        $("#ebproductbigimg").jqueryzoom();
    });

    /*数量 加1*/
    $("#J_Amount .increase").click(function () {

        var i = $("#txtChangeBuyNum").val();
        $("#txtChangeBuyNum").val(i * 1 + 1);
        CheckStocks();

    });
    /*数量 减1*/
    $("#J_Amount .decrease").click(function () {

        var i = $("#txtChangeBuyNum").val();
        if (i == 1) {
            tips("对不起，数量最少为1个！", 1);
        }
        else {
            $("#txtChangeBuyNum").val(i * 1 - 1);
            CheckStocks();
        }

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





    //产品详情小图左右切 换

    var len = $(".little_move li").length;
    if (len <= 5) {
        $("#spec-backward").addClass("disabled");
    }


    var n = 0;
    $("#spec-forward").click(function () {
        var len = $(".little_move li").length;
        if (n > 0 && n < len) {
            n--;
            $("#spec-backward").removeClass("disabled");
            $(".little_move").animate({ left: "-" + (n * 54) + "px" }, 1000);
        }
        if (n == 0) {
            $(this).addClass("disabled");
        }
    });
    $("#spec-backward").click(function () {

        var len = $(".little_move li").length;
        if (n < len - 5) {
            n++;

            $("#spec-forward").removeClass("disabled");
            $(".little_move").animate({ left: "-" + (n * 54) + "px" }, 1000);
        }
        if (n == len - 5) {
            $(this).addClass("disabled");
        }
    });

});
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

function GetNormKeyByRow(obRow) {
    var skey = "";
    $(obRow).find("input[type=hidden]").each(function (i) {
        skey += $(this).attr("id") + "-" + $(this).val() + "--";

    });
    return skey;
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
    $("#productgglist li :input[type=button]").addClass("ggnoallow");
    $("#productgglist li :input[type=button]").prop("disabled", true);
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
    $("#productgglist li :input[type=button]").each(function () {
        if (!$(this).prop("disabled") && $(this).attr("class") == "ggcurrent")
            isreset = true;
    });
    if (isreset) {

        $("#productgglist li :input[type=button]").removeClass("ggcurrent");
        $("#selNormsValue").val($("#selNormsValue").attr("productid") + "_" + aDataList[0]);
        InitNormsToSel();
    }

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
function CheckStocks() {
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
        //如果商品库存不足,屏蔽购买按钮(flz 2013-12-13)
        //$("#btnpanel").html("<div onclick=\"KuCunMsg()\" class=\"btnbuy all\"></div><span onclick=\"KuCunMsg()\"><div class=\"btngwc all\"></div></span>");
        isCheckStocks = false;
        tips("对不起，库存量不足" + iInputValue + "个，建议减少购买量，或联系我们客服人员！", 1);
        $("#txtChangeBuyNum").val(iStocks);
    }
    return isCheckStocks;
}
function KuCunMsg()
{
    tips("对不起，库存量不足,请联系我们客服人员！", 1);
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

    });   //3为指定站点的ID,如果模块放在主站，把3去掉
}



/*计算 推荐配件*/
function calculatePrice(obj) {
    var iCount = 0;
    var wmeprice = parseFloat($("#hSalePrice").val()); //销售价格
    $(".eb_tuijiancb").each(function (i) {

        if ($(this).attr("checked")) {
            iCount++;
            var itemPrice = $(this).attr("wmeprice");
            if (itemPrice != "" && itemPrice != undefined) {
                wmeprice += parseFloat(itemPrice);
            }
            else {
                alert("价格异常，无法出售");
                $(obj).attr("checked", false);
            }
        }
    });
    $("#tjcount").text(iCount);
    $("#tjprice").text(wmeprice);
}

/*计算 最佳组合配件*/
function calBestPrice(obj) {

    var iCount = 0;

    var wmeprice = parseFloat($("#hSalePrice").val()); //销售价格

    $(".eb_zuhecb").each(function (i) {

        if ($(this).attr("checked")) {
            iCount++;
            wmeprice += parseFloat($(this).attr("wmeprice"));
        }

    });

    $("#bestPCount").text(iCount);
    $("#bestscj").text(wmeprice);



}

function getshoppingcarurl() {
    var shoppingcarurl = $("#ShoppingCarUrl").val();
    var NormsValues = $("#selNormsValue").val();
    var iBuyNum = $("#txtChangeBuyNum").val();
    var tmpKuCun = $("#spStocks").text();

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
        tips("正在执行", 1, 20);
        location.href = url;
    }
}

function addtoshoppingcarmore(csstag) {
    var url = getshoppingcarurl();
    if (url != "") {
        tips("正在执行", 1, 20);
        var pids = "";
        $("." + csstag).each(function (i) {

            if ($(this).attr("checked")) {
                pids += $(this).attr("skuid") + "_";
            }

        });

        url = url + "&pids=" + pids;

        location.href = url;

    }

}