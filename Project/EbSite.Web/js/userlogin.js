
var alllogin_type = 0;//0帐号 1email 手机 2快速注册(目前弹出用)
function OnTagChange(obj) {
   
    var sID = $(obj).attr("tid");
    alllogin_type = parseInt(sID);
    //$("#btnLoginUser").attr("disabled", "");

    if (alllogin_type == 2) {
        $("#lostpasswordreme").hide();
        $("#btnOpLoginUser").val("快速注册");
        $("#btnOpLoginUser").css("background-color", "#CC0000");
    }
    else {
        $("#lostpasswordreme").show();
        $("#btnOpLoginUser").val("快速登录");
        $("#btnOpLoginUser").css("background-color", "#E66400");
    }
}
function custtomlogin(obFormID) {
    
    initlogin(obFormID,false);
}
function initlogin(obFormID,isbackcurrentapage,bakfun) {

    In.ready('customtags', function() {
        var Tags = new CustomTags();
        Tags.ParentObjName = ".sj_top";
        Tags.SubObj = "li";
        Tags.CurrentClassName = "cur";
        Tags.ClassName = "";
        Tags.InitOnclickInTags();
        Tags.InitOnclick(0);
        Tags.fun = OnTagChange;
    });
    var obform = $('#' + obFormID);
   
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

		    // 手机号或者邮箱
		    jQuery.validator.addMethod("emailmobile", function (value, element) {
		        var mobile = /^0{0,1}(13[0-9]|15[0-9]|18[0-9]|14[0-9])[0-9]{8}$/;
		        var email = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;

		        var vemail = this.optional(element) || (email.test(value));
		        var vmobile = this.optional(element) || (mobile.test(value));
		        return (vemail || vmobile);

		    }, "只能输入email地址或手机号");


		    $(obform).validate({
		        debug: true,
		        rules: {
		            login_username: {
		                required: true,
		                minlength: 3
		            },
		            login_em: {
		                required: true,
		                emailmobile: true
		            },
		            login_pwd: {
		                required: true,
		                minlength: 6
		            },
		            login_yzm: {
		                required: true,
		                minlength: 4,
		                remote: {
		                    type: "POST",
                            url: "/ajaxget/yzm.ashx?t=0" + "&ran" + Math.random(),
		                    data: {
		                        reg_yzm: function () {
		                            return $("#login_yzm").val();
		                        }
		                    }
		                }

		            }

		        },
		        messages: {
		            login_username: {
		                required: "请输入帐号",
		                minlength: jQuery.format("帐号不能小于{0}个字 符")
		            },
		            login_em: {
		                required: "请输入Email地址",
		                emailmobile: "请输入正确的email地址或手机号"
		            },
		            login_pwd: {
		                required: "请输入密码",
		                minlength: jQuery.format("密码不能小于{0}个字 符")
		            },
		            login_yzm: {
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

		            if (alllogin_type == 2) { //快速注册
		                var obpram = { username: "", pwd: "", yzm: "", formurl: "", regtype: 1 };
		                for (var i = 0; i < apram.length; i++) {

		                    switch (apram[i].name) {

		                        case "login_em":
		                            obpram.username = apram[i].value;
		                            break;
		                        case "login_pwd":
		                            obpram.pwd = apram[i].value;
		                            break;
		                        case "login_yzm":
		                            obpram.yzm = apram[i].value;
		                            break;
		                    }
		                }

		                obpram.regtype = GetReg_Type(obpram.username);

		                if (isbackcurrentapage) {
		                    obpram.formurl = location.href;
		                } else {
		                    obpram.formurl = GetUrlParams("ru");
		                }
		                $("#requesttips").show();
		                runebws("FastReg", obpram, function (rz) {
		                    var msg = rz.d;
		                    if (msg.Success) {
		                        $("#requesttips").hide();
		                        if (bakfun == null || bakfun == undefined)
		                            location.href = msg.Message;
		                        else
		                            bakfun(msg.Data);
		                    }
		                    else {
		                        //alert("快速注册发生错误:" + msg.Message);
		                        $("#btnLoginUser").attr("disabled", "");
		                        $("#requesttips").html("快速注册发生错误:" + msg.Message);

		                    }


		                });


		            }
		            else { //快速登录

		                var obpram = { login_username: "", login_pwd: "", login_yzm: "", isremember: false, login_type: 0, login_formurl: "" };
		                var emailmobile = "";
		                for (var i = 0; i < apram.length; i++) {

		                    switch (apram[i].name) {
		                        case "login_username":
		                            obpram.login_username = apram[i].value;
		                            break;
		                        case "login_em":
		                            emailmobile = apram[i].value;
		                            break;
		                        case "login_pwd":
		                            obpram.login_pwd = apram[i].value;
		                            break;
		                        case "login_yzm":
		                            obpram.login_yzm = apram[i].value;
		                            break;
		                    }
		                }
		                obpram.isremember = $("#isremember").attr("checked") == undefined ? false : true;
		                if (isbackcurrentapage) {
		                    obpram.login_formurl = location.href;
		                } else {
		                    obpram.login_formurl = GetUrlParams("ru");
		                }


		                if (GetLogin_Type(emailmobile) > 0) {
		                    obpram.login_type = GetLogin_Type(emailmobile);
		                    obpram.login_username = emailmobile;
		                }
		                else {
		                    obpram.login_type = 0;
		                }
		                $("#requesttips").show();
		                runebws("LoginUser", obpram, function (rz) {
		                    var msg = rz.d;
		                    if (msg.Success) {
		                        $("#requesttips").hide();
		                        if (bakfun == null || bakfun == undefined)
		                            location.href = msg.Message;
		                        else
		                            bakfun(msg.Data);
		                    }
		                    else {
		                        //alert("登录发生错误！" + msg.Message); 
		                        $("#btnLoginUser").attr("disabled", false);
		                        $("#requesttips").html("登录发生错误:" + msg.Message);
		                        $("#show_yzm").show();
		                        $("#errshow_yzm").show();
		                        $("#ValidateCode").click();
		                        $("#btnLoginUser").attr("src", $("#btnLoginUser").attr("src").replace("dl_img2.jpg", "dl_img1.jpg"));

		                    }


		                });

		            }

		            $("#btnLoginUser").attr("src", $("#btnLoginUser").attr("src").replace("dl_img1.jpg", "dl_img2.jpg"));

		            $("#btnLoginUser").attr("disabled", "disabled");

		        }

		    });


		 }




		 function GetLogin_Type(semailmobile) {
		    
		    if (alllogin_type == 0) {
		        return alllogin_type;
            }
		    else {
		        var mobile = /^0{0,1}(13[0-9]|15[0-9]|18[0-9]|14[0-9])[0-9]{8}$/;
		        var email = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;
		       
                if (email.test(semailmobile)) {
		            alllogin_type = 1;
		        }
		        else if (mobile.test(semailmobile)) {
		            alllogin_type = 2;
                }
                else{
                    alllogin_type = 0;
                }

            }
            return alllogin_type;
        }
        function GetReg_Type(semailmobile) {

            if (alllogin_type == 0) {
                return 1;
            }
            else {
                var mobile = /^0{0,1}(13[0-9]|15[0-9]|18[0-9]|14[0-9])[0-9]{8}$/;
                var email = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;

                if (email.test(semailmobile)) {
                    return 0;
                }
                else if (mobile.test(semailmobile)) {
                return 2;
                }
                else {
                    return 1;
                }

            }
            return 1;
        }