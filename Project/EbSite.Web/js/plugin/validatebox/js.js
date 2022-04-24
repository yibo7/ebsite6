
function ValidateByGPName(FormID, gName) {

    VlAllIsOK = true;
    //处理文本表单
    $("#" + FormID).find("input").each(
		function (i) {

		    var fOB = $(this);

		    var gropName = fOB.attr("vglp");

		    if ($.trim(gropName) == $.trim(gName)) {

		        var BoxType = fOB.attr("type");
		        switch (BoxType) {
		            case "text":
		                 $(this).keyup();
                         
		                break;
		        }
		    }


		}
		);

		return VlAllIsOK;
}
function ValidateForm(obid) {
    VlAllIsOK = true;
    //处理文本表单
    $("#" + obid).find("input").each(
		function (i) {

		    var fOB = $(this);
		    var BoxType = fOB.attr("type");
		    switch (BoxType) {
		        case "text":
		            $(this).keyup();

		            break;
		    }

		}
		);
		if (!VlAllIsOK) {
		    if ($("#wCenterWindow").length > 0) {
		        $("#wCenterWindow").html("提交失败，请确认输入的值是否正确，现在请按Esc键退出！");
		    }
        }
		return VlAllIsOK;
}
//验证一个控件的值是否合法
function ValidateCtr(ob)
{
    ob = $(ob);
    var vT = 1;
    var sValue = ""; // /^\s*$/
    var boxtagName = ob.prop("tagName");
    if (boxtagName == "INPUT") {
        var BoxType = ob.attr("type");
        switch (BoxType) {
            case "text":
                vT = ob.attr("valtype");
                sValue = ob.val();
                break;
        }
    }
    return RunReg(vT, sValue);
}
function ShowTips(ob, isvl,isok) {

    var _d = $(ob);
    //$.data(ob, "ebvalidatebox", { tip: Object});
    var _e = _d.attr("msg");
    var _f = $.data(ob, "ebvalidateboxtip");

    if (isvl) { //是否验证

        //如果是警告提示

        if (!isok) {
            if (!_d.hasClass("ebvalidatebox-invalid")) {

                _d.addClass("ebvalidatebox-invalid");
               
            }
            if (_d.hasClass("ebvalidatebox-ok")) {

                _d.removeClass("ebvalidatebox-ok");
            }
            _e = _d.attr("errmsg");
//            shake($(ob), "red", 3);
        }
        else {  //验证成功
            if (_d.hasClass("ebvalidatebox-invalid")) {
                _d.removeClass("ebvalidatebox-invalid")
            }
            if (!_d.hasClass("ebvalidatebox-ok")) {

                _d.addClass("ebvalidatebox-ok");
            } 
        }



    } 
    else {
        if (_d.hasClass("ebvalidatebox-invalid")) {
            _d.removeClass("ebvalidatebox-invalid")
        }
    }

    if (_e == "" || _e == undefined || _e == null) {
        //获取默认提示信息
        var iT = _d.attr("valtype");
        if (isvl) {
            if (!isok)
            _e = GetRegMsg(iT, true);
        }
        else {
            _e = GetRegMsg(iT, false);
        }

    }
    //如果已经合法输入，不用再提示
    if (_e == "" || _e == undefined || _e == null) {
        onVlFocusout(ob);
        return;
    }
    
    if (!_f) {

        _f = $("<div class=\"ebvalidatebox-tip\">" + "<span class=\"ebvalidatebox-tip-content\">" + "</span>" + "<span class=\"ebvalidatebox-tip-pointer\">" + "</span>" + "</div>").appendTo("body");

        $.data(ob, "ebvalidateboxtip", _f);
    }
    _f.find(".ebvalidatebox-tip-content").html(_e);
    
    var ileft = _d.offset().left + _d.outerWidth(true);
   
    _f.css({ display: "block", left: ileft, top: _d.offset().top });


}

function onVlFocusout(ob) {
    var tip = $.data(ob, "ebvalidateboxtip");
    if (tip) tip.remove();
    $.data(ob, "ebvalidateboxtip", null);
}
var VlAllIsOK = true;
function OnKeyupVl(ob) {

    //检测是否可以为空
    var isAllowNull = $(ob).attr("isnull");
    var obValue = $(ob).val();
    if (isAllowNull == 1 || !isAllowNull) { //可以为空值

        if ($.trim(obValue) == "") {
            return true;
        }
    }
    else {
        if ($.trim(obValue) == "") {
            ShowTips(ob, true, false); //正确
            VlAllIsOK = false;
            return false;
        }
    }

    //检测是否验证
    var vT = $(ob).attr("valtype");
    if (!vT) return true;
    
    
    var IsOK = false;
    if (!ValidateCtr(ob)) {  //不正确
        ShowTips(ob, true, false);
        
       
    }
    else {
        IsOK = true;
        ShowTips(ob,true, true); //正确
    }
    if (!IsOK) VlAllIsOK = IsOK;
    return IsOK;
}
function InitTextBoxVl(formID) {
    //处理文本表单
    $("#" + formID).find("input").each(
		function (i) {
		    var fOB = $(this);
		    switch (fOB.attr("type")) {
		        case "text":
		            fOB.bind('focusout', function () {
		                var IsOK = OnKeyupVl(fOB);
		                onVlFocusout(fOB);
//		                if (IsOK) {
//		                    onVlFocusout(fOB);
//                        }
		            });
		            fOB.bind('focus', function () {
		                ShowTips(fOB, false, false);

		            });
		            fOB.bind('keyup', function () {
                         
		                OnKeyupVl(fOB);
		            });
		            break;
		    }

		}
		);

}

function GetRegMsg(vT,IsErrMsg) { 
    var obReg = null;
        
        for (var i = 0; i < RegExpList.length; i++) {
            var ob = RegExpList[i];

            if (ob.id == parseInt(vT)) {

                obReg = ob;
                break
            }
        }
        var MSG = "";
        if (obReg != null) {

            if (IsErrMsg) {
                MSG = obReg.errmsg;
            }
            else {
                MSG = obReg.msg;
            }


        }

        return MSG;
    
    }
    function RunReg(vT,sValue) {
        var obReg = null;
//        if (parseInt(vT) == 1) {
//            if ($.trim(sValue) == "") {
//                return false;
//            }
//            else {
//                return true;
//            }
//        }
        for (var i = 0; i < RegExpList.length; i++) {
            var ob = RegExpList[i];

            if (ob.id == parseInt(vT)) {

                obReg = ob;
                break
            }
        }
        var IsOK = false;
        if (obReg != null) {
            //var reg = new RegExp(obReg.Reg);
            IsOK = obReg.Reg.test(sValue)

           
        }
        
        return IsOK;
    }


///正则表达式


    var RegExpList =
    [
        {
            id: 1,
            Reg: /^[0-9]+([.]{1}[0-9]{1,2})?$/,
            msg: "请输入整数或者一位小数或两位小数",
            errmsg: "输入的格式不对，可以是整数也可以是一位小数或两位小数！"
        },
        {
            id: 2,
            Reg: /^[0-9a-zA-Z]+@[0-9a-zA-Z]+[\.]{1}[0-9a-zA-Z]+[\.]?[0-9a-zA-Z]+$/,
            msg: "请输入您的email",
            errmsg: "email格式不正确"
        }
        ,
        {
            id: 3,
            Reg: /^(\+86)?(1[0-9]{10})$/,
            msg: "请输入正确手机号",
            errmsg: "手机号不正确"
        }
        ,
        {
            id: 4,
            Reg: /^[1-9][0-9]{4,}$/,
            msg: "请输入QQ号码",
            errmsg: "QQ号码不正确"
        }
         ,
        {
            id: 5,
            Reg: /^(\w+):\/\/([^/:]+)(:\d*)?([^# ]*)$/,
            msg: "请输入网址，完整地址，如http://ebsite.cn ",
            errmsg: "输入的网址的格式不对"
        }
             ,
        {
            id: 6,
            Reg: /^[1-9]\d*$/,
            msg: "请输入正整数",
            errmsg: "输入的正整数格式不对"
        }
        ,
        {
            id: 7,
            Reg: /^\d+\.\d+\.\d+\.\d+$/,
            msg: "请输入ip地址",
            errmsg: "输入的ip地址格式不对，请输入正确的ip地址"
        }
             ,
        {
            id: 8,
            Reg: /^\d{15}|\d{18}$/,
            msg: "请输入身份证号",
            errmsg: "输入的身份证号不对,请输入正确的身份证号"
        }
             ,
        {
            id: 9,
            Reg: /^[1-9]\d{5}(?!\d)$/,
            msg: "请输入中国邮政编码",
            errmsg: "输入的邮政编码格式不对,请输入中国邮政编码"
        }
              ,
        {
            id: 10,
            Reg: /^\d{3}-\d{7}|\d{3}-\d{8}|\d{4}-\d{7}|\d{4}-\d{8}$/,
            msg: "请输入国内电话号码+区号 如:010-1265689",
            errmsg: "输入的格式不对,请输入国内电话号码+区号 如:010-1265689"
        }
         ,
        {
            id: 11,
            Reg: /^[a-zA-Z][a-zA-Z0-9_]{2,15}$/,
            msg: "请输入由字母开头，允许3-16字的字符，允许字母数字下划线",
            errmsg: "输入的格式不对,请输入由字母开头，允许3-16字的字符，允许字母数字下划线"
        }
        ,
        {
            id: 12,
            Reg: /^[1-9]\d*$/,
            msg: "请输入正整数",
            errmsg: "输入的格式不对，请输入正整数，如125"
        }
         ,
        {
            id: 13,
            Reg: /^-[1-9]\d*$/,
            msg: "请输入负整数",
            errmsg: "输入的格式不对,请输入负整数,如-56"
        }
         ,
        {
            id: 14,
            Reg: /^-?[0-9]\d*$/,
            msg: "请输入整数",
            errmsg: "输入的格式不对,请输入整数，可以是正整数也可以是负整数"
        }
         ,
        {
            id: 15,
            Reg: /^[1-9]\d*|0$/,
            msg: "请输入一个正整数，可以是0",
            errmsg: "输入的格式不对,请输入一个正整数，可以是0,如:12"
        }
         ,
        {
            id: 16,
            Reg: /^-[1-9]\d*|0$/,
            msg: "请输入一个负整数,可以是0",
            errmsg: "输入的格式不对,请输入一个负整数，可以是0,如:-12"
        }
         ,
        {
            id: 17,
            Reg: /^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$/,
            msg: "请输入一个正小数",
            errmsg: "输入的格式不对,请输入一个正小数,如:23.68"
        }
         ,
        {
            id: 18,
            Reg: /^-([1-9]\d*\.\d*|0\.\d*[1-9]\d*)$/,
            msg: "请输入一个负小数",
            errmsg: "输入的格式不对,请输入一个负小数,如:-23.68"
        }
         ,
        {
            id: 19,
            Reg: /^[A-Za-z]+$/,
            msg: "请输入英文字母,由a-Z组成,大小写都可以",
            errmsg: "输入的格式不对,请输入英文字母,由a-z组成,如:eBsite"
        }
         ,
        {
            id: 20,
            Reg: /^[A-Z]+$/,
            msg: "请输入英文字母,由A-Z组成,注意只能输入大写",
            errmsg: "输入的格式不对,请输入英文字母,由A-Z组成,注意只能输入大写,如:EBSITE"
        }
         ,
        {
            id: 21,
            Reg: /^[a-z]+$/,
            msg: "请输入英文字母,由a-z组成,注意只能输入小写",
            errmsg: "输入的格式不对,请输入英文字母,由a-z组成,注意只能输入小写,如:ebsite"
        }
         ,
        {
            id: 22,
            Reg: /^[A-Za-z0-9]+$/,
            msg: "请输入由英文字母与数字组合的字符,注意第一个字符不能为数字",
            errmsg: "输入的格式不对,请输入由英文字母与数字组合的字符,注意第一个字符不能为数字,如:eBsite123"
        }
         ,
        {
            id: 23,
            Reg: /^\w+$/,
            msg: "请输入数字、26个英文字母或者下划线组成的字符串",
            errmsg: "输入的格式不对,请输入数字、26个英文字母或者下划线组成的字符串,如:eBsite_123"
        }
         ,
        {
            id: 24,
            Reg: /^[1-2][0-9][0-9][0-9]-[0-1]{0,1}[0-9]-[0-3]{0,1}[0-9]$/,
            msg: "请输入日期,格式为yyyy-mm-dd 如 2010-10-18",
            errmsg: "日期格式不正确，请输入正确的日期格式 如 2010-10-18"
        }
          ,
        {
            id: 25,
            Reg: /^[^<>&/'\|\\]+$/,
            msg: "这里不能输入特殊字符,如 ' < > & 等",
            errmsg: "输入的内容不能包含特殊字符"
        }
    ];