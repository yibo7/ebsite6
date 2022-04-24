
var feePay = 0; //支付费用
var feePay1 = 0; //暂时存
var Free = 0; //运费
var ticketFee = 0; //优惠券
var billFee = 0; //开具发票费用
var packFee = 0; //包装费

Zepto(function ($) {
    if ($("input[name=radioAddress]").length > 0) {
        $("#tabControlPanel").hide();
        $("#divsaveinfobtn").hide();
    }
    //初始化地址数据
    initclickforadress(1, "selProvice");
    //保存地址
    $("#btnSaveReceiveAddress").click(function () {
        var mSHR =$("#txtSHR").val();
        if (IsNullOrUndefined(mSHR))
        {
            alert("请填写收货人");
            $("#txtSHR").val("").focus();
            return;
        }
        var mMobile = $("#txtMobile").val();
        if (IsNullOrUndefined(mMobile)) {
            alert("请填写手机号码");
            $("#txtMobile").val("").focus();
            return;
        }
        else {
            //是否符合手机格式

        }
        var mPro = $("#selProvice").val();
        if (IsNullOrUndefined(mPro) || parseInt(mPro) <= 0)
        {
            alert("请选择省份");
            return;
        }
        var mCity = $("#selCity").val();
        if (IsNullOrUndefined(mCity) || parseInt(mCity) <= 0) {
            alert("请选择城市");
            return;
        }
        var mCoutry = $("#selcoutry").val();
        if (IsNullOrUndefined(mCoutry) || parseInt(mCoutry) <= 0) {
            alert("请选择地区");
            return;
        }
        var maddress = $("#txtaddress").val();
        if (IsNullOrUndefined(maddress))
        {
            alert("请填写详细地址");
            $("#txtaddress").val("").focus();
            return;
        }
        var mCode = $("#txtPostCode").val();
        if (IsNullOrUndefined(mCode))
        {
            alert("请填写邮政编码");
            $("#txtPostCode").val("").focus();
            return;
        }
        //保存我的收货地址
        var obPram = {
            UserRealName: mSHR,
            Phone:"",
            Mobile: mMobile,
            PostCode: mCode,
            AreaID: mCoutry,
            AreaName: "",
            AddressInfo: $("#selProvice").children("option[value='" + mPro + "']").text() + $("#selCity").children("option[value='" + mCity + "']").text() + $("#selcoutry").children("option[value='" + mCoutry + "']").text() + maddress,
            Email:"",
            Modyfiyid:0
        }
        runebws("SaveAddress", obPram, function (msg) {
            var addID = msg.d.Data;
            $("#tabControlPanel").hide();
            $("#divsaveinfobtn").hide();
            var sReceiveAddress = obPram.AddressInfo + "  收货人:" + obPram.UserRealName + "   手机:" + obPram.Mobile;
            var li = $("<li><input checked  name=\"radioAddress\" id=\"radioAddress\"" + addID + " areaid=\"" + obPram.AreaID + "\" parentids=\"\"  type=\"radio\" value=\"" + addID + "\" ><label for=\"radioAddress\"" + addID + "><b>" + sReceiveAddress + "</b></label></li>");
            $("#ulAddress").append(li);
        });
    });

    $("#selProvice").change(function () {
        var tID =parseInt($(this).val());
        if (tID > 0) {
            initclickforadress(tID, "selCity");
        }
        else {
            $("#selCity").html("<option value=\"0\" selected=\"selected\">请选择</option>");
            $("#selcoutry").html("<option value=\"0\" selected=\"selected\">请选择</option>");
        }
    });
    $("#selCity").change(function () {
        var tID = parseInt($(this).val());
        if (tID > 0) {
            initclickforadress(tID, "selcoutry");
        }
        else {
            $("#selcoutry").html("<option value=\"0\" selected=\"selected\">请选择</option>");
        }
    });

    $("input[name=rdoDelivery]").click(function () {

        var obReceiveAddress = $('input[name="radioAddress"]:checked').val();

        if (obReceiveAddress == undefined || obReceiveAddress < 1) {
            alert("请选择收货地址！");
            $(this).attr("checked", false);
            return;
        }
        else {
            var thisid = $(this).val();
            $(".tabptkd").hide();
            $("#DeliveryDemo" + thisid).show();
            var FreightTotalID = $("#FreightTotal" + $(this).val());


            if (!IsFreeEight) {  //是否满额免运费
                //已经有收货地址，计算运费
                var pramdata = { deliveryid: thisid, w: sumweight, id: obReceiveAddress, money: summoney };
                var obthis = $(this);
                runebws("GetFreeByWeight", pramdata, function (msg) {
                    var data = msg.d;
                    if (data.Success) {
                        Free = data.Data;
                        FreightTotalID.html(Free);
                        $("#ltlTrans").html(Free);
                        //data.Message = 102;
                        obthis.attr("codfree", data.Message);
                        feePay = data.Message;
                        feePay1 = data.Message;
                        var isum = Number(Free) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计
                        $("#ltlsummoney").html(isum); //合计 
                        settotalmoney(isum);
                    }
                    else { alert("运费计算出错!") }
                });
            }
            else {
                FreightTotalID.html("免运费");
                $(this).attr("codfree", 0); //货到付款为0元
            }

            //设置货到付款是否可选
            var rdoDeliveryV = $(this).attr("iscod");
            if (rdoDeliveryV == "True") {
                //  $("#rdo_payoffline2").attr("disabled", false);
                $("#rdo_payoffline2").removeAttr("disabled");

            }
            else {
                $("#rdo_payonline1").click();
                $("#rdo_payoffline2").attr("disabled", true);
                
            }
        }

    });
    $("input[name=rdoPayment]").click(function () {
        var rdoDelivery = $('input[name="rdoDelivery"]:checked');
        var rdoDeliveryV = rdoDelivery.attr("iscod");
        var thisid = $(this).attr("id");
        var CODTotalID = $("#CODTotal");
        if (rdoDeliveryV == undefined) {
            alert("请先选择配送方式！");
            $(this).attr("checked", false);
            return;
        }
        else {
            if (rdoDeliveryV == "False" && thisid == "rdo_payoffline2") {
                alert("所选配送方式不支持货到付款！");
                return false;
            }
            if (thisid == "rdo_payoffline2") {
                feePay = feePay1;
                CODTotalID.html(feePay); //支付方式
                $("#ltlShouXu").html(feePay);
                if (!IsFreePay) {
                    var isum = Number(Free) + Number(feePay) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计
                    $("#ltlsummoney").html(isum); //合计
                    settotalmoney(isum);
                }
            }
            else {
                $("#ltlShouXu").html("0.00");
                feePay = 0;
                if (!IsFreePay) {
                    var isum = Number(Free) + Number(feePay) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计
                    $("#ltlsummoney").html(isum); //合计

                    settotalmoney(isum);

                }
            }
            // $("#CODTotal" + $(this).val() + 1).html(rdoDelivery.attr("codfree"));
            $(".tabptkd").hide();
            $("#" + "PaymentDemo" + $(this).val()).show();
        }
    });
    $(".otherfree").click(function () {
        debugger;
        var objList = $("#" + $(this).attr("listid"));
        var text = $(this).text();
        if (objList.is(":hidden")) {
            objList.show();
            $(this).text(text.replace("+", "-"));
        }
        else {
            objList.hide();
            $(this).text(text.replace("-", "+"));
        }

    });
    $("#ulAddress input[type='radio']").click(function () {
        $("#address").val($(this).val());
    });
});
function IsNullOrUndefined(strInput)
{
    strInput=$.trim(strInput);
    if(strInput==""||strInput==undefined||strInput==null)
    {
        return true;
    }
    else
    {
        return false;
    }
}
//初始化地址数据
function initclickforadress(id,cid) {
    runebws("GetAlear", { pid: id }, function (data) {
        var tJson = eval(data.d);
        BindSelData(cid, tJson);
    });
}
//绑定指定控件数据
function BindSelData(controlID,dataSource)
{
    var tmpHtml = "";
    for (var i = 0; i < dataSource.length; i++)
    {
        var tItem=dataSource[i];
        tmpHtml += "<option value=\""+tItem.id+"\">"+tItem.Name+"</option>";
    }
    if (tmpHtml != "")
    {
        tmpHtml = "<option value=\"0\" selected=\"selected\">请选择</option>" + tmpHtml;
        $("#" + controlID).html(tmpHtml);
    }
}

function UserNewAddress(obj) {
    $("#ulAddress input[type='radio']").attr("checked", false);
    $("#txtSHR").val("");
    $("#txtTel").val("");
    $("#txtMobile").val("");
    $("#txtPostCode").val("");
    $("#txtAddress").val("");
    $("#txtEmail").val("");
    $("#lbReceiveAddress").html("");
   
    $("#tabControlPanel").show();
    $("#divsaveinfobtn").show();
    $("#" + alReceiveAreaListID + " select :first").change();
}



//开具发票
function On_OrderOptionItem1(obj) {

    var isinput = false;
    var itemid = "";
    isinput = $(obj.options[obj.selectedIndex]).attr("isinput");
    itemid = $(obj.options[obj.selectedIndex]).val();
    $(".optionitems", $(obj).parent().parent()).hide();
    On_OrderOptionItem(isinput, itemid);


    if (!IsOrderOption) {
        //计算 费用
        var billValue = 0; //value 值
        var billType = 0; //类型 1：百分比 0：数字
        billValue = $(obj.options[obj.selectedIndex]).attr("appendmoney");
        billType = $(obj.options[obj.selectedIndex]).attr("percent");
        var ibillmoney = 0;
        if (billType == undefined) {
            billFee = 0;
            var iAnnexMoney = Number(billFee) + Number(packFee); //订单可选项
            //            $("#ltlOrderFee").html(iAnnexMoney);
            setOrderFee(iAnnexMoney);

            var isum = Number(Free) + Number(feePay) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计
            $("#ltlsummoney").html(isum); //合计
            settotalmoney(isum);
        } else {
            if (billType == 0) {
                ibillmoney = billValue;
            } else {
                ibillmoney = summoney * billValue / 100
            }
            billFee = ibillmoney;
            var iAnnexMoney = Number(billFee) + Number(packFee); //订单可选项
            //            $("#ltlOrderFee").html(iAnnexMoney);
            setOrderFee(iAnnexMoney);

            var isum = Number(Free) + Number(feePay) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计
            $("#ltlsummoney").html(isum); //合计
            settotalmoney(isum);

        }
    }
}
//特殊包装
function On_OrderOptionItem2(obj) {
    var isinput = false;
    var itemid = "";
    isinput = $(obj).attr("isinput");
    itemid = $(obj).val();
    $(".optionitems", $(obj).parent().parent().parent().parent().parent().parent()).hide();
    On_OrderOptionItem(isinput, itemid);

    //计算费用
    var packValue = 0; //value 值
    var packType = 0; //类型 1：百分比 0：数字
    packValue = $('input[name="opi11"]:checked').attr("appendmoney");
    packType = $('input[name="opi11"]:checked').attr("percent");

    var ipackmoney = 0;

    if (packType == 0) {
        ipackmoney = packValue;
    }
    else {
        ipackmoney = summoney * packValue / 100;
    }
    packFee = ipackmoney;
    if (!IsOrderOption) {
        var iAnnexMoney = Number(billFee) + Number(packFee); //订单可选项
        //        $("#ltlOrderFee").html(iAnnexMoney);
        setOrderFee(iAnnexMoney);

        var isum = Number(Free) + Number(feePay) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计
        $("#ltlsummoney").html(isum); //合计
        settotalmoney(isum);
    }


}

function On_OrderOptionItem(isinput, itemid) {
    if (isinput)
        $("#UserInput" + itemid).show();
}

function onReceiveAreaListSel(obj) {
    var address = "";
    $("#" + alReceiveAreaListID + " select").each(function (i) {
        if (!$(this).is(":hidden")) {
            var s = get_selected_text(this);
            if (s != "" && s != "请选择")
                address += s;
        }
    });
    $("#lbReceiveAddress").html(address);
}





function vlorderinfo(obj) {

    //地址是否有选择
    var obReceiveAddressv = $('input[name="radioAddress"]:checked').val();
    //配送方式是否有选择
    var rdoDeliveryv = $('input[name="rdoDelivery"]:checked').val();
    //支付方式是否有选择
    var rdoPaymentv = $('input[name="rdoPayment"]:checked').val();
    if (obReceiveAddressv == undefined || obReceiveAddressv == "" || obReceiveAddressv == null) {
        alert("请选择配送地址再提交订单！");
        return false;
    }
    else {
        var obAddress = $("#address");

        if (obAddress.length == 0) {
            obAddress = $(" <input name=\"address\" id=\"address\" value=\"" + obReceiveAddressv + "\" type=\"hidden\" />");
            $(obj).append(obAddress);
        }
        else {


            obAddress.val(obReceiveAddressv);
        }


    }
    if (rdoDeliveryv == undefined || rdoDeliveryv == "" || rdoDeliveryv == null) {
        alert("请选择配送方式再提交订单！");
        return false;
    }
    if (rdoPaymentv == undefined || rdoPaymentv == "" || rdoPaymentv == null) {
        alert("请选择支付方式再提交订单！");
        return false;
    }
    if ($("#txtRemark").val() == "收货信息、配送方式、支付方式等以上述选定值为准，在此备注无效") {
        $("#txtRemark").val("");

    }
    //先判断是否选择了使用余款 flz 2013-12-12
    if ($("#CkUserWith").attr("checked") == "checked" || $("#CkUserWith").attr("checked") == true || $("#CkUserWith").attr("checked") == "true") {
        //2013-11-04 若开启了使用余款
        var uMoney = $("#tbMoney").val(); //本次使用金额
        if (uMoney != "") {
            var result = uMoney.match(/^[0-9]+([.]{1}[0-9]{1,2})?$/);
            if (result == null) {
                alert("请输入正确的金额");
                $("#tbMoney").focus();
                return false;
            } else {
                var iCountMoney = $("#uCountMoney").val(); //可用总余款
                var buyCountMoney = $("#ltlsummoney").html(); //本次要付总金额

                if (parseFloat(uMoney) > parseFloat(iCountMoney)) {
                    alert("可用余额不足！");
                    $("#tbMoney").focus();
                    return false;
                }


                var uPass = $("#tbPassWord").val();
                if (uPass == null || uPass == "") {
                    alert("请输入支付密码");
                    $("#tbPassWord").focus();
                    return false;
                }
                else {
                    //验证支付密码 
                    var pramex = { "pass": uPass };
                    runws("cfccc599-4585-43ed-ba31-fdb50024714b", "CheckUserPayPass", pramex, function (resultex) {
                        var tmpflag = resultex.d;
                        if (tmpflag == 0 || tmpflag == "0") {
                            alert("支付密码输入不正确!");
                            $("#tbPassWord").focus();
                            return false;
                        } else {
                            return true;
                        }
                    });
                }
            }
        }
    }
    else {
        $("#tbMoney").val("0");
    }
}