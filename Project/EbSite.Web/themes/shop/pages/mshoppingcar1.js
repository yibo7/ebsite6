
jQuery(function ($) {
    InitShopingCar();
});

function InitShopingCar() {

    $('.quantity input').keypress(function (event) {
        if (event.charCode && (event.charCode < 48 || event.charCode > 57)) {
            event.preventDefault();
        }
    }).change(function () {

        if (isint(this)) {
            var iQuantity = $(this).val();
//            updatedata();
            //更新到数据库
            SetQuantity($(this).attr("pid"), iQuantity);
        }
        else { $(this).val(1); tips("数量必须是大于0的整数!",1); }


    });

}

//function updatedata() {
//    var totalQuantity = 0;
//    var totalCost = 0;
//    $('.gdListContent').each(function () {
//        var price = parseFloat($('.price', this).text().replace(/^[^\d.]*/, ''));

//        price = isNaN(price) ? 0 : price;
//        var quantity = parseInt($('.quantity input', this).val());
//        quantity = isNaN(quantity) ? 0 : quantity;
//        var cost = quantity * price;

//        $('.cost', this).text(cost.toFixed(2));
//        totalQuantity += parseInt(quantity);
//        totalCost += cost;

//    });

//    $('.carcount .quantity').text(String(totalQuantity));
//    $('.carcount .cost').text(totalCost.toFixed(2));
//}
//商品的 加减 
function addnum(obj,id) {
    var iadd = $('#' + obj).val();
    iadd = isNaN(iadd) ? 0 : iadd;
    var paramAdd = { "productId": id, "pNumber": obj.replace("s", "") };
    runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetProductCount", paramAdd, function (data) {
        if (iadd < data.d) {
            iadd = parseInt(iadd) + 1;
            $('#' + obj).val(iadd).trigger('change').end();
        }
        else 
        {
            tips("购买数量不能超过库存数量！",3);
        }
    });
    
}
function remoiviecart(obj1,id) {

    var iremove = $('#' + obj1).val();
    iremove = isNaN(iremove) ? 0 : iremove;
    iremove = parseInt(iremove) - 1;
    
    $('#' + obj1).val(iremove).trigger('change').end();
}


//积分兑换商品 
//减
function downNum(obj1) {
    var iremove = $('#' + obj1).val();
    iremove = isNaN(iremove) ? 0 : iremove;
    iremove = parseInt(iremove) - 1;
    $('#' + obj1).val(iremove);
    if (isint($('#' + obj1))) {
        var iQuantity = iremove;
        SetCreaditQuantity($('#' + obj1).attr("pid"), iQuantity);
    } else {
        $('#' + obj1).val("1");
        tips("数量必须是大于0的整数!", 1);       
    }
}
//加
function upnum(obj, icount, icredit) {
    
    var iadd = $('#' + obj).val();
    iadd = isNaN(iadd) ? 0 : iadd;
    iadd = parseInt(iadd) + 1;
    $('#' + obj).val(iadd);
    if (isint($('#' + obj))) {
        if (iadd > icount) {
            $('#' + obj).val(iadd-1);
            tips("数量必须是小于库存量!", 1);       
        } else {
            var iQuantity = iadd;
            
            //yhl 这时要检测 用户积分是否充足
            //未完成
            SetCreaditQuantity($('#' + obj).attr("pid"), iQuantity);
        }
    }
}

function SetQuantity(spid, pnum) {
    //如果两秒内没有响应，将提示用户等待
    setTimeout(function() {
        tips("价格重新计算中...", 1, 20);
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
//更改 积分商品数据源
    function SetCreaditQuantity(spid,pnum) {
        setTimeout(function() {
        tips("价格重新计算中...", 1, 20);
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

    function delcraditcart(id, obj) {
       
         if (confirm("确认从购物车中移除此商品吗?")) {
        SetCreaditQuantity(id, 0);
        $(obj).parent().parent().remove();
        //updatedata();
        }
    }

function delcart(sku,obj) {
   
    if (confirm("确认从购物车中移除此商品吗?")) {
        SetQuantity(sku, 0);
        $(obj).parent().parent().remove();
        //updatedata();
        }
    
}

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
//ProductId 商品自增ID, SKU 商品库存编号
function editeproductoption(ProductId, SKU) {
    
    //通过ProductOptionId获取选项列表，初始到divEditeProductOption

    var pram = { "pid": ProductId };
    runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetProductOptionItems", pram,
            function (result) {
                if (result != null && result.d != null) {
                    var lst = result.d;
                    if (lst.length > 0) {

                        var sbHtml = new StringBuilder();
                        sbHtml.Append("<table>");

                        for (var i = 0; i < lst.length; i++) {
                            var model = lst[i];
                            sbHtml.Append("<tr><td><b>" + model.OptionName + "：</b></td><td>");
                            var sublist = model.ProductItems;
                            if (sublist.length > 0) {
                                sbHtml.Append(String.format("<input type=\"radio\" checked value=\"0\" id=\"optitem{0}\" name=\"optitem{0}\"/><label for=\"optitem{0}\" >不选择</label>", model.id));
                                for (var j = 0; j < sublist.length; j++) {
                                    var modelsub = sublist[j];
                                    sbHtml.Append(String.format("<input type=\"radio\" value=\"{0}\" id=\"optitem{0}\" name=\"optitem{2}\"/><label for=\"optitem{0}\" >{1}</label>", modelsub.id, modelsub.ItemName, modelsub.ProductOptionID));
                                    
                                }
                            }

                            sbHtml.Append("</td></tr>");

                        }

                        sbHtml.Append("</table>");
                        sbHtml.Append("<div style=\"padding-top: 20px; width: 100%; text-align: center;\"><input type=\"button\" style=\"padding: 8px;\" onclick=\"saveproductoption('" + SKU + "')\" value=\" 确认修改  \"/></div>");
                        

                        $("#divProductOptionItems").html(sbHtml.toString());
                        clwindiv("divEditeProductOption");
                    } else {
                        alert("调用商品选项数据为空!");
                    }
                }
                else {
                    alert("调用商品选项数据出错!");
                }

            });
    //GetProductOptionItems

        }
        //保存商品费用选项
        function saveproductoption(SKU) {
            var aValues = [];
            $("#divProductOptionItems").find("input[type=radio]").each(
		        function (i) {
		            if (this.checked) {
		                aValues.push($(this).val());
		            }
		        });
		        var isshel = false;
            if (aValues.length > 0) {

                for (var j = 0; j < aValues.length; j++) {
                    var item = aValues[j];
                    if (item > 0) {
                        isshel = true;
                    }
                }
            }
            var ispost = true;
            if (!isshel) {
                if (!confirm("确认不选择任何服务选项吗")) {
		                    ispost = false;
		                }
            }
		    if (ispost) {
		                var ids = aValues.join("_"); //ID用_分开
		                var pram = { "sku": SKU, "optids": ids };
		                runws("cfccc599-4585-43ed-ba31-fdb50024714b", "ModifyProductOptions", pram,
                        function (result) {
                            if (result != null && result.d != null) {
                                Refesh();
                            }
                            else {
                                alert("修改商品费用选项失败!");
                            }

                        });
		            }

        }

//yhl 2013-08-27 加验证登录 beign
function gotopay() {
    var userid = CurrentUserId;
   
    if (userid > 0) {
        var pram = { "userId": userid };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetUserScore", pram, gtUserScore);
    }
    else {
        openlogin(sampbakfun);
    }
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
//------end