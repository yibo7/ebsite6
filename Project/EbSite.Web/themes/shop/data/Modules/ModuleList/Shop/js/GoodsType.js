

///////////////////////////////////////////////////////////////////////////////////
// String Helper
///////////////////////////////////////////////////////////////////////////////////
String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}
var skuFields, cellFields;
var productTypeSelector;
// 以下为需要根据当前商品类型是否具有扩展属性控制显示隐藏的项目
var attributeRow; // 扩展属性操作区域（默认不显示）
var attributeContentHolder; //扩展属性内容显示和操作容器

// 以下为需要根据当前商品类型是否有规格控制显示隐藏的项目
var skuTitle; // “商品规格”标题显示（默认不显示）
var enableSkuRow; // 开启规格提示及操作按钮的显示（默认不显示）
var skuTableHolder, skuFieldHolder;
var skuTable, tableBody, tableHeader;



// 以下为需要根据当前商品类型是否有规格控制显示隐藏的项目
var skuTitle;
// “商品规格”标题显示（默认不显示）
var enableSkuRow;
// 开启规格提示及操作按钮的显示（默认不显示）

// 以下为点击开起规格以后需要显示的项目
var skuRow;
// 规格操作区域（默认不显示）

// 以下为开启规格需要隐藏，关闭规格后显示的项目
var skuCodeRow;
// 货号
var salePriceRow;
// 一口价
var costPriceRow;
// 成本价
var qtyRow;
// 库存
var weightRow;
// 重量

var skuEnabled = false;

var currentTypeId = 0;

var skuTableHolder, skuFieldHolder;
var skuTable, tableBody, tableHeader;
var htSkuFields = new jQuery.Hashtable();
var htSkuItems = new jQuery.Hashtable();
//key 修改标记
var key = 0, sDataId = 0; key1 = 0;


// 重新选择商品类型以后重置页面所有相关内容
function reset() {
    if (currentTypeId != "") {
        if (!confirm('切换商品类型将会导致已经编辑的品牌，属性和规格数据丢失，确定要切换吗？')) {
            productTypeSelector.val(currentTypeId);
            return false;
        }
    }
    currentTypeId = productTypeSelector.val();
    prepareControls(true);
    attributeContentHolder.empty();
    skuTableHolder.empty();
}

function init() {
    currentTypeId = productTypeSelector.val();

    if (currentTypeId.length == 0 || currentTypeId == "0")
        return;

    prepareControls(false);


}
function prepareControls(isReset) {
    if (currentTypeId.length == 0) {
        currentTypeId = "0";
        updateDisplayStatus(false, false);
    }
    else {
        updateDisplayStatus(true, true);
        var pram = { "id": currentTypeId };

        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "AddProduct", pram, function (resultData) {
            prepareAttributes(resultData.d.goodsAttribute);
            if (resultData.d.goodsNorms.length > 0) {
                cellFields = new Array(resultData.d.goodsNorms.length);

                $.each(resultData.d.goodsNorms, function (i, skuItem) {

                    cellFields[i] = skuItem.AttributeId;
                    htSkuFields.add(skuItem.AttributeId, skuItem);
                });
                if (key > 0) { //修改初使化
                    restoreState();
                }
                if (key1 > 0) {
                    AttributeBind();
                }
            }

        });


    }
}
var contentHolder_txtSkus;
var ctl00_contentHolder_txtAttributes = "";

function AttributeBind() {

    if (ctl00_contentHolder_txtAttributes != "") {

        // 属性值回发状态维护
        var selectedAttributes = eval(ctl00_contentHolder_txtAttributes); // $($("#ctl00_contentHolder_txtAttributes").val()).find("item");
        $.each(selectedAttributes, function (i) {
            var attributeId = selectedAttributes[i].attributeId;
            var valueList = selectedAttributes[i].item;
            if (selectedAttributes[i].usageMode == "1") {
                $.each(valueList, function () {
                    // alert($(this).attr("valueId"));
                    var ctl = $("input[name='vallist" + attributeId + "'][valueId='" + $(this).attr("valueId") + "']");
                    if ($(ctl).length > 0) $(ctl).attr("checked", "checked");
                });
            }
            else {
                // alert(selectedAttributes[i].item[0].valueId);
                var attributeControl = $("#attribute" + attributeId);
                if ($(attributeControl).length > 0) $(attributeControl).val(selectedAttributes[i].item[0].valueId);
            }
        });
    }
}
function restoreState() {
    if (key > 0) {//if ($("#ctl00_contentHolder_chkSkuEnabled").attr("checked")){
        // 规格值回发状态维护
        enableSku();
        var SKUList = eval(contentHolder_txtSkus);
        $.each($(".fieldCell"), function (i) {
            var skuId = $(this).attr("skuId");
            var k = 0;
            for (var j = 0; j < SKUList[0].skuFields.length; j++) {           
                if (skuId != SKUList[0].skuFields[j].attributeId) {
                    k = 1;
                }
                else {
                    k = 0;
                    break;
                }          
            }
            if (k == 1) {
                removeSkuField(skuId, $(this).children().eq(0).text(), false);
            }
        });
        $.each(SKUList, function (i) {
            var rowIndex = addItem();
            $("#skuCode_" + rowIndex).val(SKUList[i].skuCode); // $("#skuCode_" + rowIndex).val($(this).attr("skuCode"));
            $("#salePrice_" + rowIndex).val(SKUList[i].salePrice);
            $("#costPrice_" + rowIndex).val(SKUList[i].costPrice);
            $("#qty_" + rowIndex).val(SKUList[i].qty);
            $("#weight_" + rowIndex).val(SKUList[i].weight);


            $.each(SKUList[i].skuFields, function (j) {
                var attributeId = SKUList[i].skuFields[j].attributeId; //$(this).attr("attributeId");
                var valueId = SKUList[i].skuFields[j].valueId; // $(this).attr("valueId");
                selectSkuValue(rowIndex, attributeId, valueId, $("span[class='sku" + attributeId + "values'][valueId='" + valueId + "']").text());
            });


        });


    }
}

function updateDisplayStatus(hasAttribute, hasSku) {
    attributeRow.style.display = hasAttribute ? "block" : "none";
    skuTitle.style.display = hasSku ? "block" : "none";
    enableSkuRow.style.display = hasSku ? "block" : "none";
    skuRow.style.display = "none";
}

function prepareAttributes(attributes) {

    if (attributes == null || attributes == undefined || attributes.length == 0)
        return;

    var ulTag = $("<ul><\/ul>");
    attributeContentHolder.append(ulTag);

    $.each(attributes, function (i, attribute) {
        var liTag = $(String.format("<li class=\"attributeItem\" attributeId=\"{0}\" usageMode=\"{1}\"><\/li>", attribute.AttributeId, attribute.UsageMode));
        var liLDiv = $("<div style=\"float:left\"></div>");
        var titleSpan = $(String.format("<span class=\"formitemtitle5\" style=\"float:left\">{0}：<\/span>", attribute.Name));
        liLDiv.append(titleSpan);

        if (attribute.UsageMode == "0") {
            var selectTag = $(String.format("<select id=\"attribute{0}\" class=\"formselect input162\" style=\"float:left\"><\/select>", attribute.AttributeId));
            selectTag.append($("<option value=\"\">--\u8BF7\u9009\u62E9--<\/option>"));

            if (attribute.AttributeValues.length > 0) {
                $.each(attribute.AttributeValues, function (vIndex, attributeValue) {
                    selectTag.append($(String.format("<option value=\"{0}\">{1}<\/option>", attributeValue.ValueId, attributeValue.ValueStr)));
                });
            }
            liLDiv.append(selectTag);
        }
        else if (attribute.UsageMode == "1") {
            if (attribute.AttributeValues.length > 0) {
                var checkGroupName = "vallist" + attribute.AttributeId;

                $.each(attribute.AttributeValues, function (vIndex, attributeValue) {
                    var cid = String.format("att_{0}_{1}", attribute.AttributeId, attributeValue.ValueId);
                    var valItem = $("<span class=\"valspan\"><\/span>")
                    valItem.append($(String.format("<input type=\"checkbox\" name=\"{0}\" id=\"{1}\" valueId=\"{2}\" \/>", checkGroupName, cid, attributeValue.ValueId)));
                    valItem.append($(String.format("<label for=\"{0}\">{1}<\/label>", cid, attributeValue.ValueStr)));
                    liLDiv.append(valItem);
                });
            }
        }
        liLDiv.append($("<a href=\"javascript:void(0)\" onclick=\"ShowAttributeValue(" + attribute.AttributeId + ",this)\" class=\"add\">添加</a>"));
        liTag.append(liLDiv);
        liTag.append($("<div id=\"div_" + attribute.AttributeId + "\" style=\"display:none;float:left;margin-left:10px;\"><input type=\"text\" id=\"txtvalue" + attribute.AttributeId + "\"/><input type=\"button\" value=\"保存\" onclick=\"javascript:AddValue('" + attribute.AttributeId + "','" + attribute.UsageMode + "',this)\"/></div>"));
        ulTag.append(liTag);
    });

    attributeRow.style.display = "";
}
//显示添加属性值的文本框
function ShowAttributeValue(attributeId, obja) {
    if ($(obja).text() == "添加") {
        $("#div_" + attributeId).show('slow');
        $(obja).text('取消');
        $(obja).attr('class', 'del');
    }
    else {
        $("#div_" + attributeId).hide();
        $(obja).text('添加');
        $(obja).attr('class', 'add');
    }
}

//保存属性
function AddValue(attributeId, userMode, btnobj) {
    var valuename = $("#txtvalue" + attributeId).val().replace(/\s/g, "");
    if (valuename == "") {
        alert("请输入要添加的属性值");
        return false;
    }
    if (valuename.length > 15 || valuename.indexOf(',') >= 0) {
        alert("输入的属性值字符必须控制在15个字符并且不包含英文逗号");
        return false;
    }
    $("#div_" + attributeId).hide();
    $("#txtvalue" + attributeId).val('');
    $(btnobj).parent().parent().find("a").text('添加');
    $(btnobj).parent().parent().find("a").attr("class", "add");
    AddAttributeValue(attributeId, valuename, userMode);

}
//添加 属性 规格 
function AddAttributeValue(attributeId, valuename, userMode) {


    var pram = { "TypeNameValueID": attributeId, "value": valuename };

    runws("cfccc599-4585-43ed-ba31-fdb50024714b", "TypeRelationProduct", pram, function (data) {
        if (data.d > 0) {
            alert("添加属性值成功");
            if (userMode == "1") {
                $("#attribute" + attributeId).append($(String.format("<option value=\"{0}\">{1}<\/option>", data.d, valuename)));
                $("#attribute" + attributeId).val(data.d);
            }
            else {

                var checkGroupName = "vallist" + attributeId;
                var cid = String.format("att_{0}_{1}", attributeId, data.d);
                var valItem = $("<span class=\"valspan\"><\/span>")
                valItem.append($(String.format("<input type=\"checkbox\" name=\"{0}\" id=\"{1}\" valueId=\"{2}\" checked=\"checked\" \/>", checkGroupName, cid, data.d)));
                valItem.append($(String.format("<label for=\"{0}\">{1}<\/label>", cid, valuename)))

                $(".formitemtitle" + attributeId).after(valItem);
                // $(".formitemtitle"+attributeId).
            }
        }
    });


}
//    function setCtrlDisplay(displayCssStatus) {
//        skuCodeRow.style.display = displayCssStatus;
//        salePriceRow.style.display = displayCssStatus;
//        costPriceRow.style.display = displayCssStatus;
//        qtyRow.style.display = displayCssStatus;
//        weightRow.style.display = displayCssStatus;
//        enableSkuRow.style.display = displayCssStatus;
//    }

// 开启规格
function enableSku() {
    // setCtrlDisplay("none"); 隐藏｛货号，销售，成本价，商品库存，商品重量｝
    $("#tdAnnex1").parent().hide(); //货号
    $("#tdAnnex16").parent().hide(); //销售
    $("#tdAnnex17").parent().hide(); //成本
    $("#tdAnnex12").parent().hide(); //商品库存
    $("#tdAnnex18").parent().hide(); //商品重量

    $("#enableSkuRow").hide();
    skuRow.style.display = "";
    // cancelValid();
    prepareSkus();
    skuEnabled = true;
    $("#ctl00_contentHolder_chkSkuEnabled").attr("checked", "checked");
}

//    // 关闭规格
function closeSku() {
    if ($(".SpecificationTr").length > 0 && !confirm("关闭规格后现已添加的所有规格数据都会丢失，确定要关闭吗？"))
        return;

    $("#tdAnnex1").parent().show(); //货号
    $("#tdAnnex16").parent().show(); //销售
    $("#tdAnnex17").parent().show(); //成本
    $("#tdAnnex12").parent().show(); //商品库存
    $("#tdAnnex18").parent().show(); //商品重量

    skuRow.style.display = "none";
    skuTableHolder.empty();
    htSkuItems.clear();
    // reBindValid();
    skuEnabled = false;
    $("#ctl00_contentHolder_chkSkuEnabled").attr("checked", "");
    $("#enableSkuRow").show('slow');
}

//出使化 表格的表头
function prepareSkus() {
    skuTable = $("<table width=\"860px\" border=\"0\" cellSpacing=\"0\" cellPadding=\"2\" class=\"SpecificationTable\"><\/table>");
    tableBody = $("<tbody><\/tbody>");
    tableHeader = $("<tr class=\"SpecificationTh\"><\/tr>");

    for (cellIndex = 0;
    cellIndex < cellFields.length;
    cellIndex++) {
        var skuId = cellFields[cellIndex];
        var skuItem = htSkuFields.get(skuId);
        var fieldCell = createFieldCell(skuId, skuItem.Name);
        tableHeader.append(fieldCell);
        var skuBox = $(String.format("<div style=\"display: none; position: absolute; z-index: 999;\" id=\"skuBox_{0}\" class=\"target_box\"><\/div>", skuId));
        fillSkuBox(skuBox, skuId, skuItem.AttributeValues);
        skuTableHolder.append(skuBox);
    }

    tableHeader.append($("<td align=\"center\">货号<\/td>"));
    tableHeader.append($("<td align=\"center\" style=\"width:120px\"><em >*<\/em>销售价<br\/>(元)<\/td>"));
    tableHeader.append($("<td align=\"center\" style=\"width:60px\">成本价<br\/>(元)<\/td>"));
    tableHeader.append($("<td align=\"center\" style=\"width:45px\"><em >*<\/em>库存<\/td>"));
    tableHeader.append($("<td align=\"center\" style=\"width:45px\">重量<br\/>(克)<\/td>"));
    tableHeader.append($("<td align=\"center\" style=\"width:30px\">操作<\/td>"));
    tableBody.append(tableHeader);

    skuTable.append(tableBody);
    skuTableHolder.append(skuTable);
}
//
function fillSkuBox(box, skuId, skuValues) {
    $.each(skuValues, function (valIndex, val) {
        box.append($(String.format("<span valueId=\"{0}\" class=\"sku{1}values\" style=\"padding:3px;\">{2}<\/span>", val.ValueId, skuId, val.ValueStr)));
    });
}
// 表头 中 单一一个规格 
function createFieldCell(skuId, skuName) {
    var fieldCell = $(String.format("<td align=\"center\" class=\"fieldCell\" style=\"width:50px\" skuId=\"{0}\"><span>{1}<\/span><\/td>", skuId, skuName));
    var delCtl = $("<a href=\"javascript:;\" onclick=\"removeSkuField(" + skuId + ",'" + skuName + "', true);\" title=\"删除此规格项\" style=\"color:red;\"><sup>×<\/sup><\/a>");
    fieldCell.append(delCtl);
    return fieldCell;
}

function createSkuCell(rowIndex, skuId) {
    var cell = createCell();
    var panel = $(String.format("<div id=\"skuDisplay_{0}_{1}\" rowId=\"{0}\" skuId=\"{1}\" valueId=\"\" class=\"specdefault\">请选择<\/div>", rowIndex, skuId));
    //debugger;
    $(panel).powerFloat({
        eventType: "click",
        target: $("#skuBox_" + skuId),
        showCall: adjustSkuBox
    });
    cell.append(panel);
    return cell;
}
//商品编号
function createSkuCodeCell(rowIndex) {
    var cell = createCell();
    var skuCodeCell = $(String.format("<input type=\"text\" class=\"skuItem_SkuCode\" id=\"skuCode_{0}\" \/>", rowIndex));
    if ($("#ctphBody_ctl00_Annex1_2704b317f2594f48b312fbd191c6e4ab_GoodsNum").val().length > 0) $(skuCodeCell).val($("#ctphBody_ctl00_Annex1_2704b317f2594f48b312fbd191c6e4ab_GoodsNum").val() + "-" + rowIndex);
    
    cell.append(skuCodeCell);
    return cell;
}
//成本价
function createCostPriceCell(rowIndex) {
    var cell = createCell();
    var priceCell = $(String.format("<input type=\"text\" class=\"skuItem_CostPrice\" id=\"costPrice_{0}\" style=\"width:50px;\" \/>", rowIndex));
    $(priceCell).val($("#ctphBody_ctl00_Annex17_aefbce9ae742411296f93e95dd2ae5a6_txtBox").val());
    cell.append(priceCell);
    return cell;
}
//销售价
function createSalePriceCell(rowIndex) {
    var cell = createCell();
    var priceCell = $(String.format("<input type=\"text\" class=\"skuItem_SalePrice\" id=\"salePrice_{0}\"\ style=\"width:50px;\" \/>", rowIndex));
    var gradePrice = $(String.format("<input type=\"text\" id=\"gradeSalePrice_{0}\"\ style=\"width:50px;display:none\" \/>", rowIndex));
    // var btnSkuMemberPrice = $("<input type=\"button\" value=\"会员价\" onclick=\"editSkuMemberPrice(" + rowIndex + ");\" \/>");
    $(priceCell).val($("#ctphBody_ctl00_Annex16_aefbce9ae742411296f93e95dd2ae5a6_txtBox").val());
    $(gradePrice).val($("#ctl00_contentHolder_txtMemberPrices").val());
    cell.append(priceCell);
    cell.append(gradePrice);
    // cell.append(btnSkuMemberPrice);
    return cell;
}
//商品库存
function createQtyCell(rowIndex) {
    var cell = createCell();
    var quantityCell = $(String.format("<input type=\"text\" class=\"skuItem_Qty\" id=\"qty_{0}\" style=\"width:35px;\" \/>", rowIndex));
    $(quantityCell).val($("#ctphBody_ctl00_Annex12_06f03d9b054741798d1e942d9808e996_txtBox").val());

    cell.append(quantityCell);
    return cell;
}
//商品重量
function createWeightCell(rowIndex) {
    var cell = createCell();
    var weightCell = $(String.format("<input type=\"text\" class=\"skuItem_Weight\" id=\"weight_{0}\" style=\"width:35px;\" \/>", rowIndex));
    $(weightCell).val($("#ctphBody_ctl00_Annex18_aefbce9ae742411296f93e95dd2ae5a6_txtBox").val());

    cell.append(weightCell);
    return cell;
}
function createActionCell(rowIndex) {
    var cell = createCell();
    var actionCell = $(String.format("<a href=\"javascript:;\" onclick=\"removeSku({0});\"><img src=\"/themes/shop/data/Modules/ModuleList/Shop/css/ta.gif\" title=\"删除此商品规格\" border=\"0\" \/><\/a>", rowIndex));
    cell.append(actionCell);
    return cell;
}
function adjustSkuBox() {
    var rowId = $(this).attr("rowId");
    var skuId = $(this).attr("skuId");
    var skuBox = $("#skuBox_" + skuId);
    var valueList = $(String.format(".sku{0}values", skuId));

    $.each(valueList, function (i, listItem) {
        $(listItem).unbind("click");
        //因为每个规格都是用的同一个弹出层，所以必须先取消上一次事件绑定
        if (checkValue(rowId, skuId, $(this).attr("valueId"))) {
            $(listItem).addClass("specsna");
        }
        else {
            $(listItem).addClass("specspan").removeClass("specsna");
            $(listItem).bind("click", function () {
                selectSkuValue(rowId, skuId, $(this).attr("valueId"), $(this).html());
            });
        }
    });
}

function selectSkuValue(rowId, skuId, valueId, valueStr) {
    var displayCtl = $(String.format("#skuDisplay_{0}_{1}", rowId, skuId));
    $(displayCtl).html(valueStr);
    $(displayCtl).attr("valueId", valueId);
    $(displayCtl).addClass("specdiv").removeClass("specdefault");

    var rowIdentity = getRowIdentity(rowId);
    if (htSkuItems.containsKey(rowId))
        htSkuItems.items[rowId] = rowIdentity;
    else
        htSkuItems.add(rowId, rowIdentity);

    $.powerFloat.hide();
}


var newRowIndex = 0;

// 增加一个规格
function addItem() {
    if (cellFields.length == 0) {
        alert("增加一个规格前必须先选择一个规格名！");
        return false;
    }
    newRowIndex++;
    var dataRow = $(String.format("<tr id=\"sku_{0}\" rowindex=\"{0}\" class=\"SpecificationTr\"><\/tr>", newRowIndex));

    for (itemIndex = 0;
    itemIndex < cellFields.length;
    itemIndex++) {
        dataRow.append(createSkuCell(newRowIndex, cellFields[itemIndex]));
    }
    dataRow.append(createSkuCodeCell(newRowIndex));
    dataRow.append(createSalePriceCell(newRowIndex));
    dataRow.append(createCostPriceCell(newRowIndex));
    dataRow.append(createQtyCell(newRowIndex));
    dataRow.append(createWeightCell(newRowIndex));
    dataRow.append(createActionCell(newRowIndex));

    tableBody.append(dataRow);
    return newRowIndex;
}
//删除一个规格
function removeSku(rowIndex) {
    if (!confirm("规格数据删除以后不能恢复，确定要删除吗？"))
        return;

    $("#sku_" + rowIndex).remove();
    htSkuItems.remove(rowIndex);
}

function createCell() {
    return $("<td align=\"center\"><\/td>");
}


function checkValue(rowId, skuId, valueId) {
    var rowIdentity = "";
    for (index = 0;
    index < cellFields.length;
    index++) {
        if (cellFields[index] == skuId)
            rowIdentity += valueId + "-";
        else
            rowIdentity += $(String.format("#skuDisplay_{0}_{1}", rowId, cellFields[index])).attr("valueId") + "-";
    }
    return htSkuItems.containsValue(rowIdentity);
}

function getRowIdentity(rowId) {
    var rowIdentity = "";
    for (index = 0;
    index < cellFields.length;
    index++) {
        rowIdentity += $(String.format("#skuDisplay_{0}_{1}", rowId, cellFields[index])).attr("valueId") + "-";
    }
    return rowIdentity;
}


//移出规格 如：（颜色）

function removeSkuField(skuId, skuName, showConfirm) {
    if (showConfirm && !confirm("确定要从商品规格中删除 \"" + skuName + "\" 吗？"))
        return;

    var fieldCell = $(".SpecificationTable td[skuId='" + skuId + "']");
    var cellIndex = fieldCell.parent("tr").children().index(fieldCell);

    $(".SpecificationTable tr").each(function () {
        $("td:eq(" + cellIndex + ")", $(this)).remove();
    });

    var tmpArr = new Array(cellFields.length - 1);
    var counter = 0;
    for (i = 0;
    i < cellFields.length;
    i++) {
        if (cellFields[i] != skuId) {
            tmpArr[counter] = cellFields[i];
            counter++;
        }
    }
    cellFields = tmpArr;

    var skuField = $(String.format("<span class=\"skufield\" onclick=\"addSkuField($(this));\" cellIndex=\"{0}\" skuId=\"{1}\" skuName=\"{2}\"><a href=\"javascript:;\">{2}<sup>＋<\/sup><\/a><\/span>", cellIndex, skuId, skuName));
    skuFieldHolder.append(skuField);
    skuFieldHolder.css("display", "");

    htSkuItems.clear();

    $.each($(".SpecificationTr"), function () {
        var rowId = $(this).attr("rowindex");
        var rowIdentity = getRowIdentity(rowId);
        if (htSkuItems.containsValue(rowIdentity))
            $(this).remove();
        else
            htSkuItems.add(rowId, rowIdentity);
    });
}

//添加 规格 

function addSkuField(skuField) {
    var skuId = $(skuField).attr("skuId");
    var fieldCell = createFieldCell(skuId, $(skuField).attr("skuName"));

    $(fieldCell).insertBefore($("td:eq(0)", $(tableHeader)));
    $.each($(".SpecificationTr"), function () {
        var skuCell = createSkuCell($(this).attr("rowindex"), skuId);
        $(skuCell).insertBefore($("td:eq(0)", $(this)));
    });

    var tmpArr = new Array(cellFields.length + 1);
    tmpArr[0] = skuId;
    for (i = 1;
    i <= cellFields.length;
    i++) {
        tmpArr[i] = cellFields[i - 1];
    }
    cellFields = tmpArr;

    $(skuField).remove();
    if ($(skuFieldHolder).children().length == 0)
        skuFieldHolder.css("display", "none");
}

// 展示要生成的部分规格内容
function showSkuValue() {
    if (cellFields.length == 0) {
        alert("生成部分规格以前至少需要加入一个规格项！");
        return;
    }

    $("#skuItems").empty();

    var ulTag = $("<ul><\/ul>");
    $("#skuItems").append(ulTag);

    var values;
    for (index = 0;
    index < cellFields.length;
    index++) {
        var liTag = $(String.format("<li class=\"skuItem\" skuId=\"{0}\"><\/li>", cellFields[index]));
        var titleSpan = $(String.format("<span class=\"formitemtitle4\">{0}：<\/span>", htSkuFields.get(cellFields[index]).Name));

        values = htSkuFields.get(cellFields[index]).AttributeValues;
        var contentSpan = $("<span class=\"skuItemList\"><\/span>");
        var contentUl = $("<ul><\/ul>");
        contentSpan.append(contentUl);
        liTag.append(titleSpan);
        liTag.append(contentSpan);
        ulTag.append(liTag);

        $.each(values, function (i, skuValue) {
            var contentLi = $("<li style=\"clear:none;\"><\/li>");
            var chkItem = $(String.format("<input type=\"checkbox\" name=\"cp_{0}\" id=\"prop_{0}_{1}\" value=\"{0}:{1}\" valueId=\"{1}\" valueStr=\"{2}\" \/>",
                            cellFields[index], skuValue.ValueId, skuValue.ValueStr));
            var valueSpan = $(String.format("<span itemId=\"prop_{1}_{2}\">{0}<\/span>", skuValue.ValueStr, cellFields[index], skuValue.ValueId));
            contentLi.append(chkItem);
            contentLi.append(valueSpan);
            contentUl.append(contentLi);
        });
    }

    //    // 已经生成的规格默认选中
    $.each($(".specdiv"), function (itemIndex, itemNode) {
        var skuItems = $("input[type='checkbox']");
        $.each(skuItems, function (attIndex, attNode) {
            if ($(itemNode).attr("valueId") == $(attNode).attr("valueId"))
                $(attNode).attr("checked", true);
        });
    });

    DivWindowOpen(750, 500, 'skuValueBox');
}

// 生成部分规格
function generateSku() {
    var dataRows = $(".SpecificationTr");
    var currentSkuFields = getSkuFields();
    var skuValues = currentSkuFields.get(cellFields[0]).SKUValues;

    var skuArray = new Array(skuValues.length);

    $.each(skuValues, function (i, skuValue) {
        skuArray[i] = new Array(1);
        skuArray[i][0] = skuValue;
    });

    for (index = 1;
    index < cellFields.length;
    index++) {
        skuValues = currentSkuFields.get(cellFields[index]).SKUValues;
        var tmpArray = new Array(skuArray.length * skuValues.length);
        var rowCounter = 0;

        for (sindex = 0;
        sindex < skuValues.length;
        sindex++) {
            for (cindex = 0;
            cindex < skuArray.length;
            cindex++) {
                tmpArray[rowCounter] = new Array(index + 1);
                for (rindex = 0;
                rindex < (index + 1);
                rindex++) {
                    if (rindex == index)
                        tmpArray[rowCounter][rindex] = skuValues[sindex];
                    else {
                        tmpArray[rowCounter][rindex] = skuArray[cindex][rindex];
                    }
                }
                rowCounter++;
            }
        }

        skuArray = tmpArray;
    }


    $.each(dataRows, function () {
        $(this).remove();
    });
    for (i = 0;
    i < skuArray.length;
    i++) {
        var rowIndex = addItem();
        for (j = 0;
        j < cellFields.length;
        j++) {
            var skuItem = skuArray[i][j];
            selectSkuValue(rowIndex, cellFields[j], skuItem.ValueId, skuItem.ValueStr);
        }
    }

    CloseDiv('skuValueBox');
}
// 获取要生成哪些规格
function getSkuFields() {
    var currentSkuFields = new jQuery.Hashtable();
    for (i = 0;
    i < cellFields.length;
    i++) {
        var skuItems = $(String.format("input[type='checkbox'][name='cp_{0}']:checked", cellFields[i]));
        var skuStr = "({";
        skuStr += String.format("\"Name\":\"{0}\",", htSkuFields.get(cellFields[i]).Name);
        skuStr += String.format("\"AttributeId\":\"{0}\",", cellFields[i]);

        var skuValueStr = "";
        $.each(skuItems, function (itemIndex, skuItem) {
            skuValueStr += "{" + String.format("\"ValueId\":\"{0}\",\"ValueStr\":\"{1}\"", $(skuItem).attr("valueId"), $(skuItem).attr("valueStr")) + "},";
        });
        if (skuValueStr != "")
            skuValueStr = skuValueStr.substring(0, skuValueStr.length - 1);
        skuStr += String.format("\"SKUValues\":[{0}]", skuValueStr);
        skuStr += "})"
        currentSkuFields.add(cellFields[i], eval(skuStr));
    }

    return currentSkuFields;
}

//生成全部规格
function generateAll() {
    if (cellFields.length == 0) {
        alert("生成所有规格以前至少需要加入一个规格项！");
        return;
    }

    var dataRows = $(".SpecificationTr");
    if (dataRows.length > 0 && !confirm("生成所有规格前会先删除已编辑的所有规格，确定吗？"))
        return;

    var skuValues = htSkuFields.get(cellFields[0]).AttributeValues;
    var skuArray = new Array(skuValues.length);

    $.each(skuValues, function (i, skuValue) {
        skuArray[i] = new Array(1);
        skuArray[i][0] = skuValue;
    });

    for (index = 1;
    index < cellFields.length;
    index++) {
        skuValues = htSkuFields.get(cellFields[index]).AttributeValues;
        var tmpArray = new Array(skuArray.length * skuValues.length);
        var rowCounter = 0;

        for (sindex = 0;
        sindex < skuValues.length;
        sindex++) {
            for (cindex = 0;
            cindex < skuArray.length;
            cindex++) {
                tmpArray[rowCounter] = new Array(index + 1);
                for (rindex = 0;
                rindex < (index + 1);
                rindex++) {
                    if (rindex == index)
                        tmpArray[rowCounter][rindex] = skuValues[sindex];
                    else {
                        tmpArray[rowCounter][rindex] = skuArray[cindex][rindex];
                    }
                }
                rowCounter++;
            }
        }

        skuArray = tmpArray;
    }

    $.each(dataRows, function () {
        $(this).remove();
    });

    for (i = 0;
    i < skuArray.length;
    i++) {
        var rowIndex = addItem();
        for (j = 0;
        j < cellFields.length;
        j++) {
            var skuItem = skuArray[i][j];
            selectSkuValue(rowIndex, cellFields[j], skuItem.ValueId, skuItem.ValueStr);
        }
    }
}



function doCheck() {
    //要检查 成本价要低于 一口价 市场价
    var cb = $("#tdAnnex17").children().first().val(); //成本价

    var xs = $("#tdAnnex16").children().first().val(); //销售价

    var sc = $("#tdAnnex2").children().first().val(); //市场价
   // alert("成本价" + parseInt(cb)); alert("销售价" + xs); alert("市场价" + sc);
    //没有开启规格时 检查
   // alert(!skuEnabled);
    if (!skuEnabled) {
       // alert(0);
        if (parseInt(cb) > parseInt(xs)) {
            alert("成本价要低于销售价！");
            return false;
        }
        if (parseInt(cb) > parseInt(sc)) {

            alert("成本价要低于市场价！");
            return false;
        }
    }
    // 1.先执行jquery客户端验证检查其他表单项
    if (!PageIsValid())
        return false;

    // 2.如果开启了规格，则做以下检查
    if (skuEnabled) {
        // 商品规格数量需大于等于2
        if ($(".SpecificationTr").length < 2) {
            alert("开启规格以后，您至少需要增加两个商品规格！");
            return false;
        }

        // 检查有无规格值为空的情况
        if ($(".specdefault").length > 0) {
            alert("您需要为每一个规格项选择一个值！");
            return false;
        }

        // 检查规格字段输入数据的有效性
        if (!checkSkuCode()) return false;
        if (!checkSalePrice()) return false;
        if (!checkCostPrice()) return false;
        if (!checkQty()) return false;
        if (!checkWeight()) return false;
    }

    // 收集扩展属性和规格数据
    loadAttributes(); //属性
    loadSkus(); //规格

    return true;
}

function checkSkuCode() {
    var validated = true;
    $.each($(".skuItem_SkuCode"), function () {
        if ($(this).val().length > 20) {
            alert("商品规格货号的长度不能超过20个字符！");
            $(this).focus();
            validated = false;
            return false;
        }
    });

    return validated;
}

function checkSalePrice() {
    return checkPrice($(".skuItem_SalePrice"), true, "销售价");
}

function checkCostPrice() {
    return checkPrice($(".skuItem_CostPrice"), true, "成本价");
}

function checkQty() {
    return checkNumber($(".skuItem_Qty"), true, "库存");
}

function checkWeight() {
    return checkPrice($(".skuItem_Weight"), true, "重量");
}

function checkPrice(inputItems, required, priceName) {
    var validated = true;
    var exp = new RegExp("^(0|(0+(\\.[0-9]{1,2}))|[1-9]\\d*(\\.\\d{1,2})?)$", "i");

    $.each(inputItems, function () {
        var val = $(this).val();

        // 检查必填项是否填了
        if (required && val.length == 0) {
            alert(String.format("商品规格的{0}为必填项！", priceName));
            $(this).focus();
            validated = false;
            return false;
        }

        if (val.length > 0) {
            // 检查输入的是否是有效的金额
            if (!exp.test(val)) {
                alert(String.format("商品规格的{0}输入有误！", priceName));
                $(this).focus();
                validated = false;
                return false;
            }

            // 检查金额是否超过了系统范围
            var num = parseFloat(val);
            if (!((num >= 0.01) && (num <= 10000000))) {
                alert(String.format("商品规格的{0}超出了系统表示范围！", priceName));
                $(this).focus();
                validated = false;
                return false;
            }
        }
    });

    return validated;
}

function checkNumber(inputItems, required, numberName) {
    var validated = true;
    var exp = new RegExp("^-?[0-9]\\d*$", "i");

    $.each(inputItems, function () {
        var val = $(this).val();

        // 检查必填项是否填了
        if (required && val.length == 0) {
            alert(String.format("商品规格的{0}为必填项！", numberName));
            $(this).focus();
            validated = false;
            return false;
        }

        if (val.length > 0) {
            // 检查输入的是否是有效的数字
            if (!exp.test(val)) {
                alert(String.format("商品规格的{0}输入有误！", numberName));
                $(this).focus();
                validated = false;
                return false;
            }

            // 检查数字是否超过了系统范围
            var num = parseFloat(val);
            if (!((num >= 0) && (num <= 9999999))) {
                alert(String.format("商品规格的{0}超出了系统表示范围！", numberName));
                $(this).focus();
                validated = false;
                return false;
            }
        }
    });
    return validated;
}


function PageIsValid() {
    /* var isValid = true;
    var validateGroup = "default"; // 默认分组

    if (arguments.length > 0)
    validateGroup = arguments[0];

    var ctls = $("[ValidateGroup='" + validateGroup + "']");
    ctls.each(function() {
    if ($("#" + this["id"]).get(0).validator != undefined && $("#" + this["id"]).get(0).validator != null) {
    for (var i = 0; i < $("#" + this["id"]).get(0).validator.length; i++) {
    if ($("#" + this["id"]).get(0).validator[i]._IsValid == false) {
    $("#" + this["id"]).get(0).validator[i].UpdateStatus();
    isValid = false;
    }
    }
    }
    });
    return isValid;*/

    var isValid = true;
    var validateGroup = "default"; // 默认分组

    if (arguments.length > 0)
        validateGroup = arguments[0];
    var ctls = $("[ValidateGroup='" + validateGroup + "']");
    ctls.each(function () {
        if ($("#" + this["id"]).get(0).validator != undefined && $("#" + this["id"]).get(0).validator != null) {
            for (var i = 0; i < $("#" + this["id"]).get(0).validator.length; i++) {
                if ($("#" + this["id"]).get(0).validator[i]._IsValid == false) {
                    $("#" + this["id"]).get(0).validator[i].UpdateStatus();
                    isValid = false;
                }
            }
        }
    });
    return isValid;
}


