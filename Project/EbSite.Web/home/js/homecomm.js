
//个人空间
//添加标签
In.ready('dialog');
In.ready('jqui');
In.ready('easywidgetscjs');
//-------------------------------------------------
function AddSpaceTab(ob, tid) {
   
    if (tid > 0) {
        $("#txtPlaceClassName").val($(ob).attr("title"));
        $("#CustomValueHidden").val(tid);
        OpenDialog_Save("divAddClass", ModifySpaceTab);
    }
    else {
        OpenDialog_Save("divAddClass", SaveSpaceTab);
    }
}

function SaveSpaceTab() {

    var ClassName = $("#txtPlaceClassName").val();
    var Url = SiteConfigs.UrlIISPath + "home/ajaxget/AddTab.ashx?c=" + ClassName;

    run_ajax_async(Url, "", SaveSpaceTabCom);

}
function ModifySpaceTab() {

    var ClassName = $("#txtPlaceClassName").val();
    var TabID = $("#CustomValueHidden").val();
    var Url = SiteConfigs.UrlIISPath + "home/ajaxget/AddTab.ashx?tid=" + TabID + "&c=" + ClassName;

    run_ajax_async(Url, "", SaveSpaceTabCom);

}
function AddSpaceTabSub(ob, tid) {
    $("#txtPlaceClassName").val($(ob).attr("title"));
    $("#CustomValueHidden").val(tid);
    OpenDialog_Save("divAddClass", ToAddSpaceTabSub);
}
function ToAddSpaceTabSub() {
    var ClassName = $("#txtPlaceClassName").val();
    var TabID = $("#CustomValueHidden").val();
    var Url = SiteConfigs.UrlIISPath + "home/ajaxget/AddTab.ashx?sub=1&tid=" + TabID + "&c=" + ClassName;
    run_ajax_async(Url, "", SaveSpaceTabCom);
}


function SaveSpaceTabCom(msg) {
    if (msg == "ok") {
        parent.parent.document.location.href = parent.parent.document.location.href;
    }
    else {
        alert("标签添加失败!");
    }
}
//--------------------------------------------------------------------

function SaveTabsSortList(sSortstr) {

    var Url = SiteConfigs.UrlIISPath + "home/ajaxget/AddTab.ashx?sort=" + sSortstr + "&time=" + Math.random();
    run_ajax_async(Url, "", SaveTabsSortListCom);

}
function SaveTabsSortListCom(msg) {
    if (msg == "ok") {
        parent.parent.document.location.href = parent.parent.document.location.href;
    }
    else {
        alert("保存排序数据失败!");
    }
}
//-------------------------------------------------------------------------
function DeleteTab(id) {
    if (confirm("确认要删除此标签吗?")) {
        var Url = SiteConfigs.UrlIISPath + "home/ajaxget/AddTab.ashx?del=1&tid=" + id;
        run_ajax_async(Url, "", DeleteTTabCom);
    }

}
function DeleteTTabCom(msg) {
    if (msg == "ok") {
        parent.parent.document.location.href = parent.parent.document.location.href;
    }
    else {
        alert("删除失败!" + msg);
    }
}
//---------------------------------------------------------------------------
function OpenLayout() {
    var tabid = GetUrlParams("tab");
    var t = GetUrlParams("t");
    var sUrl = SiteConfigs.UrlIISPath + "home/LayoutPanne.aspx?t=" + t + "&tid=" + tabid;
    OpenDialog_Iframe(sUrl, "选择版式", 600, 600);
}
function OpenTheme() {
    var sUrl = SiteConfigs.UrlIISPath + "home/ChangeTheme.aspx";
    OpenDialog_Iframe(sUrl, "选择皮肤", 600, 600);
}
function OpenWidgets(UserId) {

    var tabid = GetUrlParams("tab");
    var t = GetUrlParams("t");
    var sUrl = SiteConfigs.UrlIISPath + "home/ChangeWidgets.aspx?t=" + t + "&tid=" + tabid;
    OpenDialog_Iframe(sUrl, "当前标签可选部件列表", 600, 600);
}
function MoveSpaceTab() {
    var sUrl = SiteConfigs.UrlIISPath + "home/MoveItems.aspx";
    OpenDialog_Iframe(sUrl, "排序标签", 380, 600);
}
function EditTheme() {
    var sUrl = SiteConfigs.UrlIISPath + "home/EditTheme.aspx";
    OpenDialog_Iframe(sUrl, "编辑皮肤", 800, 600);
}
////////////////////////

function ToolsBarFloatTop() {

    var IO = document.getElementById('float-toptools'), Y = IO, H = 0, IE6;
    IE6 = window.ActiveXObject && !window.XMLHttpRequest;
    while (Y) { H += Y.offsetTop; Y = Y.offsetParent };
    if (IE6)
        IO.style.cssText = "position:absolute;top:expression(this.fix?(document" +
        ".documentElement.scrollTop-(this.javascript||" + H + ")):0)";
    window.onscroll = function () {
        var d = document, s = Math.max(d.documentElement.scrollTop, document.body.scrollTop);
        if (s > H && IO.fix || s <= H && !IO.fix) return;
        if (!IE6) IO.style.position = IO.fix ? "" : "fixed";
        IO.fix = !IO.fix;
    };
    try { document.execCommand("BackgroundImageCache", false, true) } catch (e) { };


}

