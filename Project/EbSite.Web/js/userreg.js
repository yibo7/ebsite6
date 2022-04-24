
//异步注册
function inivalidateregform(obFormID) {

    var obform = $('#' + obFormID);
    $(obform).validate({
        debug: true,
        rules: {
            reg_email: {
                required: true,
                email: true,
                remote: {
                    type: "POST",
                    url: "/ajaxget/email.ashx",
                    data: {
                        reg_email: function () {
                            return $("#reg_email").val();
                        }
                    }
                }
            },
            reg_pwd: {
                required: true,
                minlength: 6
            },
            reg_pwdr: {
                required: true,
                minlength: 6,
                equalTo: "#reg_pwd"
            },
            reg_yzm: {
                required: true,
                minlength: 4,
                remote: {
                    type: "POST",
                    url: "/ajaxget/yzm.ashx?t=0" + "&ran" + Math.random(),
                    data: {
                        reg_yzm: function () {
                            return $("#reg_yzm").val();
                        }
                    }
                }

            },
            reg_agree: {
                required: function (element) {
                    return $("input:checkbox[name='reg_agree']:checked");
                    //radio验证方法
                    //return $("input:radio[name='txtVSex']:checked").val()!="";              
                }
            },
            reg_yzmmobile: {
                required: true,
                minlength: 4,
                remote: {
                    type: "POST",
                    url: "/ajaxget/yzm.ashx?t=1" + "&ran" + Math.random(),
                    data: {
                        reg_yzmmobile: function () {
                            return $("#reg_yzmmobile").val();
                        }
                    }
                }

            }

        },
        messages: {
            reg_email: {
                required: "请输入Email地址",
                email: "请输入正确的email地址",
                remote: "此帐号已被注册"
            },
            reg_pwd: {
                required: "请输入密码",
                minlength: jQuery.format("密码不能小于{0}个字 符")
            },
            reg_pwdr: {
                required: "请输入确认密码",
                minlength: "确认密码不能小于{0}个字符",
                equalTo: "两次输入密码不一致不一致"
            },
            reg_yzm: {
                required: "请输入正确的验证码",
                minlength: jQuery.format("验证码为{0}个字符"),
                remote: "输入的验证码不正确"
            },
            reg_agree: {
                required: "请选择同意协议才能注册"
            },
            reg_yzmmobile: {
                required: "请输入正确的验证码",
                minlength: jQuery.format("验证码为{0}个字符"),
                remote: "输入的验证码不正确"
            }
        },
        errorPlacement: function (error, element) {
            
            var id = element.attr("id");
            $("#err" + id).empty();
            $("#err" + id).append("<img src=\"" + SiteConfigs.UrlIISPath + "themes/cw.jpg\" style=\"float:left; margin-right:5px; display:inline\" />");
            $("#err" + id).append(error);
        },
        success: function (label) {
            label.parent().html("<img src=\"" + SiteConfigs.UrlIISPath + "themes/zq.jpg\" style=\"float:left; margin-right:5px; display:inline\" />");
        },
        submitHandler: function (form) {


            var apram = $(form).serializeArray();

            var obpram = { reg_username: "", reg_email: "", reg_pwd: "", reg_yzm: "", reg_glkey: "", reg_vuid: 0, reg_formurl: "", reg_mobile: "", reg_type: 0, reg_yzmmobile:"" };

            for (var i = 0; i < apram.length; i++) {

                switch (apram[i].name) {
                    case "reg_username":
                        obpram.reg_username = apram[i].value;
                        break;
                    case "reg_email":
                        obpram.reg_email = apram[i].value;
                        break;
                    case "reg_pwd":
                        obpram.reg_pwd = apram[i].value;
                        break;
                    case "reg_yzm":
                        obpram.reg_yzm = apram[i].value;
                        break;
                    case "reg_mobile":
                        obpram.reg_mobile = apram[i].value;
                        break;
                    case "reg_type":
                        obpram.reg_type = apram[i].value;
                        break;
                    case "reg_yzmmobile":
                        obpram.reg_yzmmobile = apram[i].value;
                        break;
                        
                }
            }

            obpram.reg_vuid = $.trim(GetUrlParams("vuid")) == "" ? 0 : parseIntGetUrlParams("vuid");
            obpram.reg_formurl = GetUrlParams("ru");
            obpram.reg_glkey = GetUrlParams("gid");
            if (obpram.reg_glkey != "")
                obpram.reg_glkey = obpram.reg_glkey + "="; //获取不到参数里的=号,而加密后的标记有=号

            runebws("RegUser", obpram, userreged);

            $("#btnRegUser").attr("disabled", "disabled");

        }

    });

    // 手机号码验证
    jQuery.validator.addMethod("mobile", function (value, element) {
        var length = value.length;
        var mobile = /^(((18[0-9]{1})|(17[0-9]{1})|(13[0-9]{1})|(15[0-9]{1}))+\d{8})$/
        return this.optional(element) || (length == 11 && mobile.test(value));
    }, "手机号码格式错误");
    // 数字字母下划线的验证
    jQuery.validator.addMethod("username", function (value, element) {
        var chrnum = /^\w+$/;
        return this.optional(element) || (chrnum.test(value));
    }, "只能输入数字和字母或下划线");

     
    $("input:radio[name='reg_type']").change(function () {

        on_reg_type($(this).val());

    });
    

    obform.find("input").each(
		    function (i) {
		        var ob = $(this);
		        if (ob.attr("type") == "text" || ob.attr("type") == "password") {
		            ob.textRemindAuto({
		                chgClass: "inp_pwd"
		            });
		        }

		    }
		    );
		}
function sendMobileMsg(objthis) {
    var number = $("#reg_mobile").val();
    var obj =$(objthis);
    runebws("SendMobileValCode", { mbnumber: number}, function (data) {
        if (data.d) {
            if (data.d.Success) {
                var countdown = 60;
                settime(obj);
                function settime(obj) {
                    if (countdown == 0) {
                        obj.attr("disabled", false);
                        obj.val("获取验证码");
                        countdown = 60;
                        return;
                    } else {
                        obj.attr("disabled", true);
                        obj.val("重新发送(" + countdown + ")");
                        countdown--;
                    }

                    setTimeout(function () {
                        settime(obj)
                    }, 1000);
                }
            }
            else {
                alert(data.d.Message);
            }
        } else {
            alert("验证码发送错误！");
        }
    });
    
     
}
function on_reg_type(reg_typeval) {

    var regtype = reg_typeval;
    if (regtype == 0) { //email
        $("#reg_username").rules("remove");
        $("#reg_mobile").rules("remove");
        $("#reg_email").rules("add", { required: true, email: true, messages: { required: "请输入Email地址", email: "请输入正确的email地址", remote: "此帐号已被注册"
        }
        });
        //show_customcode
        //show_mobilecode
        $("#show_username").hide();
        $("#show_mobile").hide();
        $("#show_email").show();
        $("#show_customcode").show();
        $("#errreg_yzmshow").show();
        $("#show_mobilecode").hide();
        $("#errreg_mobileyzmshow").hide();
    }
    else if (regtype == 1) { //帐号


        $("#reg_username").rules("add",
                {
                    required: true,
                    username: true,
                    remote: {
                        type: "POST",
                        url: "/ajaxget/username.ashx",
                        data: {
                            reg_username: function () {
                                return $("#reg_username").val();
                            }
                        }
                    },

                    messages: { required: "请输入帐号名称", username: "只能输入数字和字母或下划线", remote: "此帐号已被注册" }
                });

        $("#reg_mobile").rules("remove");
        $("#reg_email").rules("add", { required: true, email: true, messages: { required: "请输入Email地址", email: "请输入正确的email地址", remote: "此Email已被注册"
        }
        });

        $("#show_username").show();
        $("#show_mobile").hide();
        $("#show_email").show();
        $("#show_customcode").show();
        $("#errreg_yzmshow").show();
        $("#show_mobilecode").hide();
        $("#errreg_mobileyzmshow").hide();
    }
    else if (regtype == 2) { //手机
        $("#reg_username").rules("remove");
        $("#reg_mobile").rules("add",
                { required: true,
                    mobile: true,
                    remote: {
                        type: "POST",
                        url: "/ajaxget/mobile.ashx",
                        data: {
                            reg_mobile: function () {
                                return $("#reg_mobile").val();
                            }
                        }
                    },

                    messages: { required: "请输入您的手机号码", mobile: "输入的手机号码不正确", remote: "此手机号码已经被注册" }
                });


        $("#reg_email").rules("remove");

        $("#show_username").hide();
        $("#show_mobile").show();
        $("#show_email").hide();
        $("#show_customcode").hide();
        $("#errreg_yzmshow").hide();
        $("#show_mobilecode").show();
        $("#errreg_mobileyzmshow").show();

    }
    $("#errreg_username").empty();
    $("#errreg_mobile").empty();
    $("#errreg_email").empty(); 
    //$("#reg_yzmmobile").empty();
    
}

function userreged(rz) {
    var msg = rz.d;
    if (msg.Success) {
        alert(msg.Message);
        document.location.href = msg.Message; //"UccIndex.ashx";

    }
    else { alert("注册发生错误！" + msg.Message); }

}

