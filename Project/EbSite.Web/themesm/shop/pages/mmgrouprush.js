Zepto(function ($) {

    var it = GetUrlParams('t');
    if (it != 0) {
        $("#PJianjie").hide();
    }

    InitNormsToSel();
    /*数量 加1*/
    $(".ui-number .increase").click(function () {

        var i = $("#Number1").val();
        $("#Number1").val(i * 1 + 1);
        CheckStocks();

    });
    /*数量 减1*/
    $(".ui-number .decrease").click(function () {

        var i = $("#Number1").val();

        if (i == 1) {
            tips("对不起，购买量最少为1个！", 1);
        }
        else {
            $("#Number1").val(i * 1 - 1);
            CheckStocks();
        }

    });
    $("#productgglist li input[type=\"button\"]").click(function () {

        var DataID = $(this).attr("pid"); //当前规格ID,非规格值ID
        var RowID = "PNorm" + DataID; //获取选规格值所在的规格ID
        $("#" + RowID).find("input[type=\"button\"]").removeClass("ggcurrent"); //将其下的样式全部清空
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
});
function updateprice() {

    var NormsValues = $("#selNormsValue").val();
    var pram = { "id": NormsValues };

    runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetPriceByNormID", pram, function (msg) {
        $("#spCostPrice").html(msg.d.CostPrice);
        $("#spPNumber").html(msg.d.PNumber);
        //$("#spSalePrice").html(msg.d.SalePrice);
        $("#spStocks").html(msg.d.Stocks);
        $("#spWeight").html(msg.d.Weight);
        CheckStocks();

    });
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
    var iInputValue = $("#Number1").val();
    //剩下库存量
    var rz = iStocks - iInputValue;
    var isSave = true;
    if (iStocks > 0 && (rz >= 0)) {
        var ChangePrice = $("#spSalePrice").text().replace("¥", "") * iInputValue;
        $("#spAllPrice").text(ChangePrice);
    } else {
        alert("对不起，库存量不足" + iInputValue + "个，建议减少购买量,或联系我们客户！");
        $("#Number1").val(iStocks);
        isSave = false;
    }
    return isSave;
}

function addtoshoppingcar(shoppingcarurl) {

    debugger;
    var NormsValues = $("#selNormsValue").val();
    var iBuyNum = $("#txtChangeBuyNum").val();
    //var ProductOption = $("#selProductOption").val();

    var isok = CheckStocks();


    if (isok) {
       
        if (NormsValues == '') {
            var url = shoppingcarurl + "&num=" + iBuyNum;
        } else {
            var url = shoppingcarurl + "&num=" + iBuyNum + "&normid=" + NormsValues;
        }
        location.href = url;
    }
    else {

    }
}

//*******************倒计时方法*********************
var SysSecond;
var InterValObj;
$(document).ready(function () {
    SysSecond = parseInt($("#goodsendsecond").text()); //这里获取倒计时的起始时间 
    InterValObj = window.setInterval(SetRemainTime, 996); //间隔函数，1秒执行 
});
//将时间减去1秒，计算天、时、分、秒 
function SetRemainTime() {
    if (SysSecond > 0) {
        SysSecond = SysSecond - 1;
        var second = Math.floor(SysSecond % 60);             // 计算秒     
        var minite = Math.floor((SysSecond / 60) % 60);      //计算分 
        var hour = Math.floor((SysSecond / 3600) % 24);      //计算小时 
        var day = Math.floor((SysSecond / 3600) / 24);        //计算天 

        $("#remainTime").html("<span>" + day + "</span>天<span>" + hour + "</span>小时<span>" + minite + "</span>分钟<span>" + second + "</span>秒");
    } else {//剩余时间小于或等于0的时候，就停止间隔函数 
        window.clearInterval(InterValObj);
        //这里可以添加倒计时时间为0后需要执行的事件
        $("#remainTime").html("此活动已结束!");
    }
}