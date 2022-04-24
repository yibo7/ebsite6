
function initapidata(obFormID) {

    var obform = $('#' + obFormID);
    $(obform).validate({
        rules: {
            reg_email: {
                required: true,
                email: true
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

            }

        },
        messages: {
            reg_email: {
                required: "请输入Email地址",
                email: "请输入正确的email地址"
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
        }

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

