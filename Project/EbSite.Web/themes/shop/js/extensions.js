
var ExUsrID = 0; //用户ID
var currentpguserid = 0;

/*头部 登录信息===Begin*/
jQuery(function ($) {
    GetUserLoginInfobm();
    showcartinfo(); //显示菜单栏上的购物车信息

    var hanTimer = 0;
    $(".sort_1").live("mouseover", function () {

        var obj = $(this);
        clearTimeout(hanTimer);
        hanTimer = setTimeout(function () {

            $(".sort_1").removeClass("sort_1_sel");
            obj.addClass("sort_1_sel");
            $(".hide_sort").hide();
            obj.next(".hide_sort").show();

            obj.next(".hide_sort").hover(function () {
                $(this).show().prev().addClass("sort_1_sel");

            });
            obj.next(".hide_sort").mouseleave(function () {
                $(this).hide().prev().removeClass("sort_1_sel");
            });


        }, 300);




    });
    $(".sort_1").live("mouseleave", function () {

        $(this).removeClass("sort_1_sel");
        $(this).next(".hide_sort").hide();

        clearTimeout(hanTimer);
    });

    //导航选中样式
    var currenturl = location.href;
    if (currenturl != "") {
        var index = currenturl.lastIndexOf('/');
        var doname = currenturl.substring(index);
        var curobj = null;
        $(".bnr_dh a").each(function (i) {
            var obj = $(this);
            var url = obj.attr("href");
            if (doname == url) {
                curobj = obj;
            }
        });
        if (curobj != null) {

            curobj.parent().addClass("cur");
        }
    }



});
In.ready('textauto', function () {
    $("#k").textRemindAuto({ focusColor: "#8EBD00" });
});
In.ready('customtags', function () {//执行代码
    var Tags = new CustomTags();
    Tags.ParentObjName = "divindextag";
    Tags.SubObj = "li";
    Tags.CurrentClassName = "current";
    Tags.ClassName = "";
    Tags.InitOnclickInTags();
    Tags.InitOnclick(0);
    Tags.Effects = "slidedown";

});

function GetUserLoginInfobm() {
    if ($("#login_infobmshop").length > 0) {
        var Url = SiteConfigs.UrlIISPath + "ajaxget/CurrentUser.ashx?" + Math.random();
        run_ajax_async(Url, "", OutTopLoginInfobm);
    }

}

function searchkeyword(obj) {
    var key = $(obj).text();
    $("#k").val(key);
    $("#btnheadseach").click();
}

function OutTopLoginInfobm(msg) {
    var strs = new Array();
    strs = msg.split("|");
    CurrentUserId = strs[1];
    CurrentUserNiName = strs[0];

    var isEmail = strs[3];
    if (isEmail == "False") {
        $("#Dvem").css("visibility", "visible");
    } else {
        $("#Dvem").css("visibility", "hidden");
    }


    var sHtml = " <ul>";
    sHtml += "<a href='" + SiteConfigs.UrlIISPath + "loginapi.ashx?t=SINA'> <div class=\"sinalogin all2pic\"></div></a>";
    sHtml += "<a  href='" + SiteConfigs.UrlIISPath + "loginapi.ashx?t=QQ'> <div class=\"qqlogin all2pic\"></div></a>";
    sHtml += "<li ><a href=\"/login.ashx\" style=\"color:#076FA2\"  >登录</a> </li>";
    sHtml += "<li ><a href=\"" + SiteConfigs.UrlIISPath + "reg.ashx\"  >注册</a></li></ul>";
    if (msg != "" && msg != "no") {
        sHtml = "<div style=\"padding-top:0px;\"> ";
        sHtml += "欢迎您, <a href='" + SiteConfigs.UrlUcc + "' target=_blank'u' style=\" color:Red\" >" + CurrentUserNiName + "</a> | "; //SiteConfigs.Urluhome
        sHtml += "<a href=\"" + SiteConfigs.UrlUcc + "\" target=_blank'u'>我的帐户</a>|  ";
        sHtml += "<a href=\"" + SiteConfigs.UrlIISPath + "LogOut.aspx\">退出</a> </div>";
        //

    }
    $("#login_infobmshop").html(sHtml);
    if (OnGetUserLoginInfoEnd != null) {
        OnGetUserLoginInfoEnd();
    }
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

function showcartinfo() {
    if ($("#ebshowcartinfo").length > 0) {

        var pram = { "siteid": SiteConfigs.id };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetCartCount", pram,
                        function (result) {
                            if (result != null && result.d != null) {
                                var model = result.d;

                                var icount = model.Value;
                                var carturl = model.Text;

                                if (icount > 0)
                                    $("#ebshowcartinfo").html(String.format(" <li><a href=\"{1}\">({0})购物车</a></li><li class=\"tab6\"><a href=\"{1}\">去结算</a></li>", icount, carturl));
                            }
                            else {
                                alert("修改商品费用选项失败!");
                            }

                        });

    }

}

///首页
function show_tab(dv, li, to, cur, css) {
    for (i = 1; i <= to; i++) {
        var dvid = document.getElementById(dv + i);
        var liid = document.getElementById(li + i);
        if (i == cur) {
            dvid.style.display = "block";
            liid.className = css;
        } else {
            dvid.style.display = "none";
            liid.className = "";
        }
    }
}


