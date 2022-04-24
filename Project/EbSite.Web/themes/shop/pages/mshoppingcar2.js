var feePay = 0; //支付费用
var CachefeePay = 0; //暂时存
var CacheFree = 0;//暂存运费
var Free = 0; //运费
var ticketFee = 0; //优惠券
var billFee = 0; //开具发票费用
var packFee = 0; //包装费

$(function () {

    settotalmoney(summoney);
    //    $("#ltlsummoney").html(summoney); //合计

    if ($("input[name=radioAddress]").length > 0) {
        $("#tabControlPanel").hide();
        $("#divsaveinfobtn").hide();
    }
    $("#btnSaveReceiveAddress").click(function () {
        $("#btnSaveAdrress").click();


    });
    initclickforadress();

    In.ready('validate', 'textauto', function () {
        $("#txtRemark").textRemindAuto();
        inivalidatesaveaddressform("fmAdresss");
    });

    $("input[name=rdoDelivery]").click(function () {

        var obReceiveAddress = $('input[name="radioAddress"]:checked').val();

        if (obReceiveAddress == undefined || obReceiveAddress < 1) {
            alert("请先保存收货地址！");
            return false;
        }
        else {
          
            var thisid = $(this).val();
            $(".tabptkd").hide();
            $("#DeliveryDemo" + thisid).show();
            var FreightTotalID = $("#FreightTotal" + $(this).val());

            //因为 有时免运费 ，支付方式有 支付手续费，在请求 方法时 一同把运费 和支付手续费 算出。2014-3-24 YHL
            var pramdata = { deliveryid: thisid, w: sumweight, id: obReceiveAddress, money: summoney };
            var obthis = $(this);
            runebws("GetFreeByWeight", pramdata, function (msg) {
                var data = msg.d;
                if (data.Success) {
                    CacheFree = data.Data;

                    CachefeePay = data.Message;
                }
                else { alert("运费计算出错!") }
            });

            if (!IsFreeEight) {  //是否满额免运费
                //已经有收货地址，计算运费
                //                var pramdata = { deliveryid: thisid, w: sumweight, id: obReceiveAddress, money: summoney };
                //                var obthis = $(this);
                //                runebws("GetFreeByWeight", pramdata, function (msg) {
                //                    var data = msg.d;
                //                    if (data.Success) {
                //                        Free = data.Data;
                //                        FreightTotalID.html(Free);
                //                        $("#ltlTrans").html(Free);
                //                        //data.Message = 102;
                //                        obthis.attr("codfree", data.Message);
                //                        feePay = data.Message;
                //                        feePay1 = data.Message;

                //                        var isum = Number(Free) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计
                //                        //                        $("#ltlsummoney").html(isum); //合计 
                //                        settotalmoney(isum);
                //                    }
                //                    else { alert("运费计算出错!") }
                //                });
                Free = CacheFree;
                $("#ltlTrans").html(Free); obthis.attr("codfree", data.Message);
                var isum = Number(Free) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计

                settotalmoney(isum);
            }
            else {
                FreightTotalID.html("免运费");
                $(this).attr("codfree", 0); //货到付款为0元
            }

            //设置货到付款是否可选
            var rdoDeliveryV = $(this).attr("iscod");
            if (rdoDeliveryV == "True") {
                $("#rdo_payoffline2").attr("disabled", false);
            }
            else {
                $("#rdo_payoffline2").attr("disabled", true);
                $("#rdo_payonline1").attr("checked", true);
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
            return false;
        }
        else {
            if (rdoDeliveryV == "False" && thisid == "rdo_payoffline2") {
                alert("所选配送方式不支持货到付款！");
                return false;
            }
            if (thisid == "rdo_payoffline2") {
               
                feePay = CachefeePay;
                CODTotalID.html(feePay); //支付方式
                $("#ltlShouXu").html(feePay);
                if (!IsFreePay) {
                    var isum = Number(Free) + Number(feePay) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计
                    //                    $("#ltlsummoney").html(isum); //合计
                    settotalmoney(isum);
                }
            }
            else {
                $("#ltlShouXu").html("0.00");
                feePay = 0;
                if (!IsFreePay) {
                    var isum = Number(Free) + Number(feePay) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计
                    //                    $("#ltlsummoney").html(isum); //合计

                    settotalmoney(isum);

                }
            }
            // $("#CODTotal" + $(this).val() + 1).html(rdoDelivery.attr("codfree"));
            $(".tabptkd").hide();
            $("#" + "PaymentDemo" + $(this).val()).show();
        }
    });
    $(".otherfree").click(function () {
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

    //2013-10-14 yhl 用预付款
    $("#CkUserWith").change(function () {
        if (!$("#CkUserWith").attr("checked")) {
            $("#withPass").css("display", "none");
        } else if ($("#CkUserWith").attr("checked")) {
            $("#tbMoney").val("");
            $("#tbPassWord").val("");
            $("#withPass").css("display", "block");




        }
    });


});

//设置预付款
function SetBalance(obj)
{
    var balancemoney = Number($.trim($(obj).val()));
    if (isNaN(balancemoney))
    {
        alert("输入的金额有误，请重新输入！");
        $(obj).val("");
    }
    else if(balancemoney>0)
    {
        //判断是否已经用过预付款
        var tmpTotal = Number($("#ltlsummoney").text());
        if (tmpTotal > 0) {
            $("#ltlBalance").text(-balancemoney);
            var tmpSumResult = tmpTotal - balancemoney;
            if (tmpSumResult < 0) {
                alert("您使用的预付款金额超出了商品的总金额！");
                $(obj).val("");
            }
            else {
                $("#ltlsummoney").text(tmpSumResult);
            }
        }
    }
}

function setOrderFee(dmoney) {

    $("#ltlOrderFee").html(dmoney.toFixed(2)); //订单选项费用
}

function settotalmoney(dmoney) {

    $("#ltlsummoney").html(dmoney.toFixed(2)); //合计
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
                var buyCountMoney = $("#ltlsummoney").html();//本次要付总金额

                if (parseFloat(uMoney) > parseFloat(iCountMoney)) {
                    alert("可用余额不足！");
                    $("#tbMoney").focus();
                    return false;
                }

                //if (parseFloat(uMoney) > parseFloat(buyCountMoney)) {
                //    alert("请不要大于总付款金额！");
                //    $("#tbMoney").focus();
                //    return false;
                //}

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
//开具发票
function On_OrderOptionItem1(obj) {

    var isinput = false;
    var itemid = "";
    isinput = $(obj.options[obj.selectedIndex]).attr("isinput");
    itemid = $(obj.options[obj.selectedIndex]).val();
    $(".optionitems", $(obj).parent().parent()).hide();
    On_OrderOptionItem(isinput, itemid);
    debugger;

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
            //            $("#ltlsummoney").html(isum); //合计
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
            //            $("#ltlsummoney").html(isum); //合计
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
        //        $("#ltlsummoney").html(isum); //合计
        settotalmoney(isum);
    }


}
function On_OrderOptionItem(isinput, itemid) {
    if (isinput)
        $("#UserInput" + itemid).show();
}
function initclickforadress() {
    $("#ulAddress input[type=radio]").click(function () {
        var dataid = $(this).attr("areaid");
        var pids = $(this).attr("parentids");
        //设置下拉选择项的值
        $("#" + hfReceiveAreaValueID).val(dataid);
        $("#" + hfReceiveValueParentIDs).val(pids);
       
        alcObj.BindModify();

        runebws("GetAddress", { id: $(this).val() }, function (msg) {
            var data = msg.d;
            if (data.Success) {
                var md = data.Data;

                $("#txtSHR").val(md.UserRealName);
                $("#txtTel").val(md.Phone);
                $("#txtMobile").val(md.Mobile);
                $("#txtPostCode").val(md.PostCode);
                $("#txtAddress").val(md.AddressInfo);
                $("#txtEmail").val(md.Email);

                $("#tabControlPanel").show();
                $("#divsaveinfobtn").show();
            }
            else { alert("地址调用出错!") }
        });
    });
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

function UserNewAddress(obj) {
    $("#ulAddress input[type=radio]").attr("checked", false);
    $("#txtSHR").val("");
    $("#txtTel").val("");
    $("#txtMobile").val("");
    $("#txtPostCode").val("");
    $("#txtAddress").val("");
    $("#txtEmail").val("");
    $("#lbReceiveAddress").html("");
    $("#" + alReceiveAreaListID + " select :first").change();
    $("#tabControlPanel").show();
    $("#divsaveinfobtn").show();
}


function inivalidatesaveaddressform(obFormID) {

    var obform = $('#' + obFormID);
    $(obform).validate({
        debug: true,
        rules: {
            txtAddress: {
                required: true,
                minlength: 3
            },
            txtSHR: {
                required: true,
                minlength: 2
            },
            txtMobile: {
                mobile: true
            },
            txtEmail: {
                memail: true
            },
            txtTel: {
                tel: true
            }

        },
        messages: {
            txtAddress: {
                required: "收货地址不能为空",
                minlength: "收货地址不能短于3位"
            },
            txtSHR: {
                required: "收货人姓名不能为空",
                minlength: jQuery.format("收货人姓名不能小于{0}个字符")
            }
        },
        errorPlacement: function (error, element) {

            var id = element.attr("id");

            $("#err" + id).attr("class", "infono gbpic");
            $("#err" + id).show();
            $("#errmsg" + id).html(error);
        },
        success: function (label) {
            //label 这个对象是 errorPlacement 里的html(error);
            var msgid = label.parent().attr("id");
            var icoid = msgid.replace("errmsg", "err");
            $("#" + icoid).attr("class", "infook gbpic");
        },
        submitHandler: function (form) {

            var sTel = $("#txtTel").val();
            var sMobile = $("#txtMobile").val();
            if ($.trim(sTel) == "" && $.trim(sMobile) == "") {
                alert("手机号码与座机必须要填写一个!")
            }
            else {
                var obReceiveAddress = $('input[name="radioAddress"]:checked');
                var AddressModifyID = obReceiveAddress.val();
                if (AddressModifyID == undefined || AddressModifyID == null)
                    AddressModifyID = 0;
                var obPram = {
                    UserRealName: $("#txtSHR").val(),
                    Phone: $("#txtTel").val(),
                    Mobile: $("#txtMobile").val(),
                    PostCode: $("#txtPostCode").val(),
                    AreaID: $("#" + hfReceiveAreaValueID).val(),
                    AreaName: "",
                    AddressInfo: $("#lbReceiveAddress").text() + $("#txtAddress").val(),
                    Email: $("#txtEmail").val(),
                    Modyfiyid: AddressModifyID
                }

                //var sReceiveAddress = obPram.AddressInfo + "  收货人:" + obPram.UserRealName + "   手机:" + obPram.Mobile;
                //if (AddressModifyID == 0) {

                //    var li = $("<li><input checked  name=\"radioAddress\" type=\"radio\" ><label for=\"rbReceiveAddress\"><b>" + sReceiveAddress + "</b></label></li>");

                //    $("#ulAddress").append(li);

                //}
                //else {
                //    obReceiveAddress.next().html("<b>" + sReceiveAddress + "<b>");
                //}


                $("#tabControlPanel").hide();
                $("#divsaveinfobtn").hide();
                runebws("SaveAddress", obPram, function (msg) {
                    var addID = msg.d.Data;
             
                    //更新运费价格

                    //修改第一次没有收货地址时，地址参数传输错误的问题 flz(2013-12-12)
                    var sReceiveAddress = obPram.AddressInfo + "  收货人:" + obPram.UserRealName + "   手机:" + obPram.Mobile;
                    if (AddressModifyID == 0) {
                        var li = $("<li><input checked  name=\"radioAddress\" id=\"radioAddress\"" + addID + " areaid=\"" + obPram.AreaID + "\" parentids=\"\"  type=\"radio\" value=\"" + addID + "\" ><label for=\"radioAddress\"" + addID + "><b>" + sReceiveAddress + "</b></label></li>");

                        $("#ulAddress").append(li);

                    }
                    else {
                        obReceiveAddress.next().html("<b>" + sReceiveAddress + "<b>");
                    }
                });

            }




        }

    });

    // 手机号码验证
    jQuery.validator.addMethod("mobile", function (value, element) {
        var length = value.length;
        var mobile = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1}))+\d{8})$/
        return this.optional(element) || (length == 11 && mobile.test(value));
    }, "手机号码格式错误");
    // 手机号码验证
    jQuery.validator.addMethod("tel", function (value, element) {
        var length = value.length;
        var tel = /^\d{3}-\d{7}|\d{3}-\d{8}|\d{4}-\d{7}|\d{4}-\d{8}$/
        return this.optional(element) || (tel.test(value));
    }, "电话号码格式错误,格式为:号码+区号 如:010-88888888");

    // 可填写email,但如果填写的话，需要验证正确性
    jQuery.validator.addMethod("memail", function (value, element) {
        var svalue = $.trim(value);
        if (svalue == "") return true;
        var tel = /^[0-9a-zA-Z]+@[0-9a-zA-Z]+[\.]{1}[0-9a-zA-Z]+[\.]?[0-9a-zA-Z]+$/
        return this.optional(element) || (tel.test(svalue));
    }, "Email的格式不正确");



}
opFun();
//切换
function opFun() {
    if ($(".combobox-item").length > 0) {
        $("#yhdiv").toggle();
    }
}

//使用优惠券
function ckTicket() {
    
    var ticknum = $("#txtTick").val();
    if (ticknum == "") {
        alert("请添写优惠券！");
        $("#ltlTicket").html("0.00");
        var isum = Number(Free) + Number(feePay) + Number(summoney); //合计
        //        $("#ltlsummoney").html(isum); //合计
        settotalmoney(isum);
    }
    else {

        var obPram = {
            number: ticknum,
            imoney: summoney
        }
        runebws("CheckTicket", obPram, function (msg) {
            var data = msg.d;
            var inum = 0; //优惠价
            if (data.Success) {
                var md = data.Data;
                //判断优惠券(flz 2013-12-13)
                if (-Number(md) > Number($("#ltlsummoney").text()))
                {
                    md = -$("#ltlsummoney").text();
                }
                ticketFee = md;
                inum = md;
                $("#ltlTicket").html(md);
                var isum = Number(Free) + Number(feePay) + Number(summoney) + Number(ticketFee) + Number(billFee) + Number(packFee); //合计
                //                $("#ltlsummoney").html(isum); //合计 
                settotalmoney(isum);
            }
            else {
                $("#ltlTicket").html("0.00");
                var isum = Number(Free) + Number(feePay) + Number(summoney); //合计
                //                $("#ltlsummoney").html(isum); //合计 
                settotalmoney(isum);
                alert("您的优惠券编号无效，或者您的商品金额不够!");
            }
        });
    }
}
//选中 优惠券
function setticket(obj) {
    var num = $(obj).attr("tt");
    $("#txtTick").val(num);
    $(".combobox-item").removeClass("combobox-item-selected");
    $(obj).addClass("combobox-item combobox-item-selected ");


}

