
$("#DrpScore").change(function () {
    var obj = document.getElementById('DrpScore');
    var $iScore = obj.options[obj.selectedIndex].value; //获取分数的value

    $("#s_score").html($iScore);
});



$("#DrpBigClass").change(function () {
    var $carModel = $("#DrpSmallClass");
    var obj = document.getElementById('DrpBigClass');
    var $brandid = obj.options[obj.selectedIndex].value; //获取分类id

    if ($brandid != "-1") {
        var param1 = { "pid": $brandid, "bl": false };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetBmAskClassListCount", param1, function (result) {
            if (result.d > 0) {
                runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetBmAskClassList", param1, function (result) {
                    $carModel.html(" ");
                    $carModel.html(result.d);
                });
            } else {
                $carModel.html(" <option value=\"-1\" id=\"0\">请选择汽车车型</option>");
            }
        });
    }
});
//选择分类面板
function togglePanel() {
    $("#SelClass").attr("style", "display:block");
    $("#page").attr("style", "display:none");

}

// 关闭 选择分类面板
function togglePanel2() {
    $("#SelClass").attr("style", "display:none");
    $("#page").attr("style", "display:block");

}
//选中分类
function SuitClass() {

    var classType = "-1";
    var classTypeName = "";
    if (($("#DrpSmallClass").find("option").length) > 1) {
        //classType = $('#DrpSmallClass').val();
        var obj = document.getElementById('DrpSmallClass');
        classType = obj.options[obj.selectedIndex].value; //获取分类id
        classTypeName = obj.options[obj.selectedIndex].text;

    }
    if (classType == -1) {
        $("#dialog4").html("请选择子分类");
        $('#dialog4').dialog('open', 20, 20);
        return false;

    } else {
        $("#iCheckClass").html("问题分类: " + classTypeName);

        $("#HidClass").val(classType);

        togglePanel2();
    }

}