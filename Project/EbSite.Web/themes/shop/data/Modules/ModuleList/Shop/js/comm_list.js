$(document).ready(function () {
    var objPro = $("#ctl00_ctphBody_ctl00_hidProvince");
    var objCity = $("#ctl00_ctphBody_ctl00_hidCity");
    var objCou = $("#ctl00_ctphBody_ctl00_hidCounty");
    var defaultOption = "<option value=\"-1\">-请选择-</option>";
    $("#selProvince").change(function () {
        var proID = $(this).children("option:selected").val();
        objPro.val(proID);
        objCity.val("");
        objCou.val("");
        $("#selCity").html(defaultOption);
        $("#selCounty").html(defaultOption);
        GetAreaData(3, proID, "selCity");
    });
    $("#selCity").change(function () {
        var proID = $(this).children("option:selected").val();
        objCity.val(proID);
        objCou.val("");
        $("#selCounty").html(defaultOption);
        GetAreaData(4, proID, "selCounty");
    });
    $("#selCounty").change(function () {
        var proID = $(this).children("option:selected").val();
        objCou.val(proID);
    });
});
InitProvinceData();
//初始化数据
function InitProvinceData() {
    GetAreaData(2, 1, "selProvince");
}
//获取地区数据
function GetAreaData(level, pid, controlID) {
    runws("GetAreaOption", { "level": level, "pid": pid }, function (data) {
        $("#" + controlID).html(data.d);
    });
}
//全选
function SelectAll(flag) {
    if (flag > 0) {
        $("input[type='checkbox'][name='chkItem']").attr("checked", true);
    }
    else {
        $("input[type='checkbox'][name='chkItem']").attr("checked", !$("input[type='checkbox'][name='chkItem']:eq(0)").attr("checked"));
    }
}
//打印
function PrintOrder(obj, actonname) {
    var rid = $(obj).parent("div").parent("td").parent("tr").attr("tid");
    if (actonname == "KDD") {
        //快递单
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=12&id=" + rid, "打印快递单", 900, 200, true);
    }
    else if (actonname == "GHD") {
        //购货单
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=13&id=" + rid, "打印购货单", 600, 200, true);
    }
    else if (actonname == "PSD") {
        //配送单
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=14&id=" + rid, "打印配送单", 600, 200, true);
    }
}
//删除(支持单个、批量删除)
function DeleteItem() {
    if (window.confirm("确定要执行该删除操作吗？删除后将不可能恢复!")) {
        var ids = "";
        var cItems = $("input[type='checkbox'][name='ebcheckboxname']:checked");
        if (cItems != null && cItems != undefined && cItems.length > 0) {
            $.each(cItems, function (i, item) {
                ids += $(item).val() + ",";
            });
        }
        if (ids != "") {
            runws("AsynDelOrder", { "rIDs": ids }, function (data) {
                if (data.d > 0) {
                    alert("操作成功");
                    window.location.reload();
                }
            });
        }
        else {
            tips("请选择要删除的订单", 3, 2);
        }
    }
}
//订单详情
function ViewOrderDetail(obj) {
    var rid = $(obj).parent("div").parent("td").parent("tr").attr("tid");
    if (rid != "" && rid != undefined) {
        window.location.href = "Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=8&id=" + rid;
    }
}
//修改订单
function EditOrder(obj) {
    var rid = $(obj).parent("div").parent("td").parent("tr").attr("tid");
    if (rid != "" && rid != undefined) {
        window.location.href = "Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=4&id=" + rid;
    }
}
//关闭订单
function CloseOrder(obj) {
    var rid = $(obj).parent("div").parent("td").parent("tr").attr("tid");
    OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=5&id=" + rid, "关闭订单", 600, 200, true);
}
//订单退款
function RefundOrder(obj) {
    var rid = $(obj).parent("div").parent("td").parent("tr").attr("tid");
    OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=6&id=" + rid, "订单退款信息", 750, 460, true);
}
//标注订单
function MarkOrder(obj) {
    var rid = $(obj).parent("td").parent("tr").attr("tid");
    OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=7&id=" + rid, "编辑备注信息", 500, 360, true);
}
//订单已线下收款
function PayedOrder(obj) {
    var rid = $(obj).parent("div").parent("td").parent("tr").attr("tid");
    if (rid != "" && rid != undefined) {
        if (window.confirm("如果客户已经通过其他途径支付了订单款项,您可以使用此操作修改订单状态\n\n此操作成功完成以后，订单的状态将变为已付款状态，确认客户已付款？")) {
            runws("AsynOffLinePayed", { "rid": rid }, function (data) {
                if (data.d > 0) {
                    tips("提交成功,此订单已经变为已付款状态", 1, 3);
                    window.location.reload();
                }
                else {
                    tips("提交失败,请重新操作", 3, 2);
                }
            });
        }
    }
}
//发货
function SendOrder(obj) {
    var rid = $(obj).parent("td").parent("tr").attr("tid");
    if (rid != "" && rid != undefined) {
        window.location.href = "Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=15&id=" + rid;
    }
    //OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=15&id=" + rid, "发货",800, 360, true);
}
//退款
function RefundOrderEx(obj) {
    var rid = $(obj).parent("td").parent("tr").attr("tid");
    OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=16&id=" + rid, "团购订单退款操作", 730, 500, true);
}
//通过审核
function ApprovedOrder(obj) {
    var rid = $(obj).parent("td").parent("tr").attr("tid");
    if (rid != "" && rid != undefined) {
        if (window.confirm("确定通过审核吗？")) {
            runws("ApprovedOrder", { "rid": rid }, function (data) {
                if (data.d > 0) {
                    tips("订单审核成功，已经进入下一步，准备发货", 1, 3);
                    window.location.reload();
                }
                else {
                    tips("提交失败,请重新操作", 3, 2);
                }
            });
        }
    }
}
//交易完成
function FinishOrder(obj)
{
    var rid = $(obj).parent("td").parent("tr").attr("tid");
    if (rid != "" && rid != undefined) {
        if (window.confirm("确定要交易完成吗？")) {
            runws("FinishOrder", { "rid": rid }, function (data) {
                if (data.d > 0) {
                    tips("操作成功，订单已完成交易！", 1, 3);
                    window.location.reload();
                }
                else {
                    tips("提交失败,请重新操作", 3, 2);
                }
            });
        }
    }
}