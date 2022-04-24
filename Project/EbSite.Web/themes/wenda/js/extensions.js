var ExUsrID = 0; //用户ID
var currentpguserid = 0;

/*头部 登录信息===Begin*/
jQuery(function ($) {
    GetUserLoginInfobm();
    $(".copyright a").hide();
});



function GetUserLoginInfobm() {
    if ($("#login_infobm").length > 0) {
        var Url = SiteConfigs.UrlIISPath + "ajaxget/CurrentUser.ashx?" + Math.random();
        run_ajax_async(Url, "", OutTopLoginInfobm);
    }

}


function OutTopLoginInfobm(msg) {
    var strs = new Array();
    strs = msg.split("|");
    CurrentUserId = strs[1];
    CurrentUserNiName = strs[0];

    var isEmail = strs[3];
   
    
    
    if (isEmail=="False"||isEmail==undefined) {
        $("#Dvem").css("visibility", "visible");
    } else {
        $("#Dvem").css("visibility", "hidden");
    }
   

    var sHtml = " <ul>";
    sHtml += "<a href='" + SiteConfigs.UrlIISPath + "loginapi.ashx?t=SINA'> <div class=\"sinalogin all2pic\"></div></a>";
    sHtml += "<a  href='" + SiteConfigs.UrlIISPath + "loginapi.ashx?t=QQ'> <div class=\"qqlogin all2pic\"></div></a>";
    sHtml += "<li ><a href=\"/login.ashx\" style=\"color:#076FA2\"  >登录</a> </li>";
    sHtml += "<li ><a href=\"" + SiteConfigs.UrlIISPath + "reg.ashx\"  >注册</a></li></ul>";
    //购物车信息
    $("#bm_gwc_count").text("0");
    $("#bm_chakan_do").html("<img src=\"/themes/default/css/images/js.jpg\" />");
    if (msg != "" && msg != "no") {
        sHtml = "<div style=\"padding-top:0px;\"> ";
        sHtml += "欢迎您, <a href='" + SiteConfigs.UrlUcc + "' target=_blank'u' style=\" color:Red\" >" + CurrentUserNiName + "</a> | "; //SiteConfigs.Urluhome
        sHtml += "<a href=\"" + SiteConfigs.UrlUcc + "\" target=_blank'u'>我的帐户</a>|  ";
        sHtml += "<a href=\"" + SiteConfigs.UrlIISPath + "LogOut.aspx\">退出</a> </div>";
        //
       
    }
    $("#login_infobm").html(sHtml);
    if (OnGetUserLoginInfoEnd != null) {
        OnGetUserLoginInfoEnd();
    }
}

/*头部 结束*/

$(document).ready(function () {
    if ($("#requestexpert").length > 0) {
        $("#requestexpert").click(function () {
            In.ready('tinybox', function () {                //执行代码
                if (CurrentUserId > 0) {
                    TINY.box.show(SiteConfigs.ThemePath + 'requestexpert.html', 1, 500, 300, 1);
                }
                else {
                    openlogin(function (uid) {
                        CurrentUserId = uid;
                        $("#requestexpert").click();
                    });
                }


            });
        });
    }
});
//申请专家
function btnRequestExpertClick(txtly,txtdq,txtExpertDemo) {
    var txtly = $("#" + txtly).val();
    var txtdq = $("#" + txtdq).val();
    var txtExpertDemo = $("#" + txtExpertDemo).val();
    if ($.trim(txtly) != "" && $.trim(txtdq) != "" && $.trim(txtExpertDemo) != "") {
        var pram = { ly: txtly, dq: txtdq, dm: txtExpertDemo };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "RequestExpert", pram, function (result) {
            if (result.d) {
                var obj = result.d;
                alert(obj.Message);
                TINYBoxClose();
            }
        });
    }
    else {
        alert("请完善申请资料再提交！");
    }
    
}

function show_tab(dv, li, to, cur, css) {
    for (i = 1; i <= to; i++) {
        //var dvid = document.getElementById(dv + i);
        var liid = document.getElementById(li + i);
        if (i == cur) {
            //dvid.style.display = "block";
            liid.className = css;
        } else {
            //dvid.style.display = "none";
            liid.className = "";
        }
    }
}
///uid 发表人的ID obj 是问题的id
function showHF(obj, uid) {
   
    var userid = CurrentUserId;
    if (userid > 0) {
        if (userid == uid) {
            tips("自己不能回答自己的提问。");
        } else {
            var pram = { "UID": userid, "AskContentID": obj }; //判断用户是否已经回答过 
            runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "UserHaveSay", pram, function (result) {
                if (result.d) {
                    tips("您已经回过此问题。");
                }
                else {
                    $("#sh_" + obj).hide();
                    $("#cl_" + obj).show();
                    $("#hf" + obj).css("display", "block");
                }
            });
        }
    }
    else {
        $("#sh_" + obj).hide();
        $("#cl_" + obj).show();
        $("#hf" + obj).css("display", "block");
        
    }
}
function ColseHF(obj) {
    $("#hf" + obj).css("display", "none");
    $("#sh_" + obj).show();
    $("#cl_" + obj).hide();

}
function show_red(nowid, imgid, src) {
    var eleid1 = document.getElementById(nowid);
    var eleid2 = document.getElementById(imgid);
    eleid1.setAttribute("className", 'mainp4');
    eleid1.setAttribute("class", 'mainp4');
    eleid2.setAttribute("src", src);
}
function hid_red(nowid, imgid, src) {
    var eleid1 = document.getElementById(nowid);
    var eleid2 = document.getElementById(imgid);
    eleid1.setAttribute("className", 'mainp3');
    eleid1.setAttribute("class", 'mainp3');
    eleid2.setAttribute("src", src);
}

function show_ceng(id) {
    document.getElementById(id).style.display = "block";
}
function hidden_ceng(id) {
    document.getElementById(id).style.display = "none";
}

function Foo() {
    //do something
}




//登录的返回方法
function cp_bk(result) {
    if (result > 0) {
        $("#lbErrInfo").text("登录");
        toCancelFavClass();
        OnPageLoad();
        CurrentUserId = result;
        var userid = CurrentUserId; //<%=base.UserID %>;
        userid = result;
        if (userid > 0) {
            var pram = { "UserID": userid };
            runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetUserCredits", pram, GetScore);
        }
    }
    else {
        $("#lbErrInfo").text("登录失败");
    }
}
   


/*搜索事件*/
$(document).ready(function () {
    $("#k").focus(function () {
        if ($(this).val() == "输入问题关键词") {
            $(this).val("");
            $(this).css("color", "#000000");
        }
    });
    $("#k").blur(function () {
        if ($.trim(this.value) == '') {
            $(this).val("输入问题关键词");
            $(this).css("color", "#cccccc");
        }
    });
    $("#selectAsk").click(function () {
        var sWord = $.trim($("#k").val());
        if (sWord == "" || sWord == "输入问题关键词" || sWord == undefined) {
            tips("请输入要搜索的关键字", 3, 2);
            return false;
            //$("#k").focus();
        }
    });
});



/*回答问题 回抛方法*/
var xsObj = 0;
var xsUid = 0;
function askfun(obj, uid) {
    xsObj = obj;
    xsUid = uid;
    var userid = SiteConfigsY.askuseridY; // CurrentUserId; //<%=base.UserID %>;
    if (CurrentUserId > 0) {
        userid = CurrentUserId;
    }
    if (userid <= 0) {
        openlogin(askbackfun);
        return;
    }
    else {
        AddAnswer(obj, uid);
    }
}
function askbackfun(uid) {

    currentpguserid = uid;
    AddAnswer(xsObj, xsUid);
}
//==================end================
///提交答案 首页   =========begin=================================================2012-10-30
function AddAnswer(obj, uid) {
    var userid = CurrentUserId;
   
    if (userid > 0) {
        var ct = $("#answerinfo" + obj).val();
        if (ct == "") {
            tips("回复内容不能为空。", 2);
        }
        else {
            var pram = { "Content": ct, "UID": userid, "AskContentID": obj, "AskUID": uid, "hideAnwer": "false" };
            runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "SubmitContentInfo", pram, function (result) {

                if (result.d.ID > 0) {
                    $("#hf" + obj).hide();
                    ColseHF(obj);
                    tips("回复成功！");
                }
                else {
                    tips("评论失败", 2, 2);
                }
            });    //提交问题回答 
        }
    }

}