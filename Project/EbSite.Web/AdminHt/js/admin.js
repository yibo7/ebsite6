
///////////////页面main.aspx的菜单处理//////////////////

In.ready('customtags', function () {
    //执行代码
    //GetMenus("00000000-0000-0000-0000-000000000000");
    if ($("#LeftMenuList").length > 0) {
        var TopTags = new CustomTags();
        TopTags.ParentObjName = "line";
        TopTags.SubObj = "span";
        TopTags.CurrentClassName = "current";
        TopTags.ClassName = "";

        TopTags.fun = OnMainTags; // function () { OnMainTags(this) };

        TopTags.InitOnclickInTags();

        TopTags.InitOnclick(0);
    }
    

    $("[data-toggle='tooltip']").tooltip();

});
 
function OnMainTags(obj) {
    var lurl = $(obj).attr("lui");
    var rurl = $(obj).attr("rui");
    var sID = $(obj).attr("id");
    GetMenus(sID);
    if (rurl != "") 
    {
        rform.location.href = SiteConfigs.UrlIISPath + rurl;
    }
    //TopTags.OnclickTags(obj);

}



function GetMenus(MenuParentID) {
    var dt = new Date();
    LeftMenuList.innerHTML = "<div><img  src='../Images/loading.gif' /></div>";
    run_ajax_async("ajaxget/GetMenu.ashx", "pid=" + MenuParentID + "&dt=" + dt.getSeconds(), CompGetMenus);
}
function CompGetMenus(msg) {

    var aMenus = eval(msg);

    if (aMenus == null || aMenus == undefined || aMenus.length < 1) {
        LeftMenuList.innerHTML = "<font color='red'>您还没有安装任何模块</font>";
        return;
    }
    var sbMenuList = new StringBuilder();
    sbMenuList.Append("<table id=\"tdMenuList\"  border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" >");
    for (var i = 0; i < aMenus.length; i++) {
        var CurrentMenu = aMenus[i];

        sbMenuList.Append("<tr onclick=\"OnMenuTitle(this)\"><td  class=\"treeview_unfocus\">");
        sbMenuList.Append(" <img src=\"" + CurrentMenu.img + "\"/>&nbsp;");
        sbMenuList.Append(CurrentMenu.MenuTitle);
        sbMenuList.Append("</td></tr><tr style=\"display:none\"><td><div  class=\"BasicinfoShow\"><ul>");
        sbMenuList.Append(BindLeftMenuItems(CurrentMenu.Items));
        sbMenuList.Append("</ul></div></td></tr>");
    }
    sbMenuList.Append("</table>");
    LeftMenuList.innerHTML = sbMenuList.toString();

    $("#tdMenuList tr:first").click();

}

function BindLeftMenuItems(Items) {
    var sbItems = new StringBuilder();
    // alert(Items)
    for (var i = 0; i < Items.length; i++) {
        var CurrentItem = Items[i];
        sbItems.Append("<li  onclick='OnSubMenu(this)'>");

        sbItems.Append("<a   href=\"");
        sbItems.Append(CurrentItem.url);
        sbItems.Append("\" target=rform  >");//target=rform
        sbItems.Append(" <img src=\"" + CurrentItem.img + "\"/>");
        sbItems.Append(CurrentItem.ItemName);
        sbItems.Append("</a></li>");
    }
    return sbItems.toString();
}

function OnSubMenu(ob) {
    $("#tdMenuList").find("li").each(
		function (i) {
		    $(this).attr("class", "");
		}
		);
    $(ob).attr("class", "selectThisItemsStyle");
}
function OnMenuTitle(ob) {

    var onTitle = $(ob);
    var IsOpen = onTitle.attr("isop");
    var onNext = onTitle.next();

    if (IsOpen == null || IsOpen == undefined || IsOpen == "0") {
        onNext.show();
        onTitle.attr("isop", "1");
    }
    else {
        onNext.hide();
        onTitle.attr("isop", "0");
    }
}

function MouseOver(menuItem) {
    menuItem.className = "hover";
}

function MouseOut(menuItem) {
    menuItem.className = "";
}

function SavesTheme(Theme) {
    
    var Url = "Ajaxget/UserConfigsSet.ashx?t=" + Theme + "&tmp=" + Math.random();
    run_ajax_async(Url, "", Comp_SavesTheme);
}
function Comp_SavesTheme(msg) {


    CloseTipsToCenter();

    location.href = location.href;
}
//运行ebsite后台的web服务
function runadminws(funname, postobj, backfun) {
    var url = "ajaxget/wsapi.asmx/" + funname;
    if (arguments.length == 2) {
        var vl = run_ajax_unasync_json(url, postobj);
        return vl;
    }
    else if (arguments.length == 3) { //异步

        run_ajax_async_json(url, postobj, backfun);
    }
}
function InserFieldToBox(ob, txtboxid) {

   
    var txt = ob;

    try
    {
        txt = ob.options[ob.selectedIndex].value;

        
    }
    catch(e)
    {
        txt = ob;
         
    }
    insertAtCursor(ob, txt); //editor
    //var txtbox = document.getElementById(txtboxid);
//        txtbox.focus();
//        var tarobj = document.selection.createRange();
    //        tarobj.text = txt;

        //使用了代码高亮编辑器后要这样写
    
}
function oCopy(obj){ 
    obj.select(); 
    js=obj.createTextRange(); 
    js.execCommand("Copy") 
    alert("复制成功!");
}
function OpenLeftMenu() {
    //thisID = document.getElementById(thisID);
    var ob = $("#leftList")
    var tg = ob.attr("tg");


    if (tg == null || tg == undefined || tg == 1) {
        ob.fadeOut("slow");
        ob.attr("tg", "0");


    }
    else {
        ob.fadeIn("slow");
        ob.attr("tg", "1");


    }

}

function insertAtCursor(smyField, myValue) {

    var myField = document.getElementById(smyField);
    alert(myValue)
    //IE support   
    if (document.selection) {
        myField .focus();
        sel = document.selection.createRange();
        myValue =  myValue;
        sel.text = myValue;
        sel.select();
    }
    //MOZILLA/NETSCAPE support   
    else if (myField.selectionStart || myField.selectionStart == '0') {
        var startPos = myField.selectionStart;
        var endPos = myField.selectionEnd;
        // save scrollTop before insert   
        var restoreTop = myField.scrollTop;
        myValue = myValue;
        myField.value = myField.value.substring(0, startPos) + myValue + myField.value.substring(endPos, myField.value.length);
        if (restoreTop > 0) {
            // restore previous scrollTop   
            myField.scrollTop = restoreTop;
        }
        myField.focus();
        myField.selectionStart = startPos + myValue.length;
        myField.selectionEnd = startPos + myValue.length;
    } else {
        myField.value += myValue;
        myField.focus();
    }   
}
//////////////////////////分类选择/////////////////////////


function AddClassSelInit() {
    $('#dataloading').ajaxComplete(function () {
        $(this).hide();

    });
    $("#dataloading").ajaxStart(function () {
        $(this).show();
    });
    $('#dataloading').ajaxError(function () {
        $(this).hide();
    });
    $('#dataloading').ajaxSuccess(function () {
        $(this).hide();
        OnDataBind();
    });
    
}

function OnDataBind() {
    $(".selbox").find("option").each(
		function (i) {
		    var selItem = $(this);
		    var pram = selItem.attr("pram");
		    if (pram == 0) {
		        selItem.css("color", "#ccc");
		    }


		});
}
function scrolltocmenu(obj) {
    
    //var container = $(".slimscrollleft");
    //container.scrollTop(100);//滚动到div 100px
   
}
function savesubmenuindex(obj) {
   
    $.cookie('lastmenuid', obj.id);
    
}

function GoToUpdate() {
    //location.href = "Update.aspx";
    rform.location.href = "Update.aspx";
}
function ChangePass() {
    //location.href = "ChangePass.aspx";
    rform.location.href = "ChangePass.aspx";
}
function SetSites() {
    //location.href = "Admin_Sites.aspx?t=0";
    rform.location.href = "Admin_Sites.aspx?t=0";
}

function ChangeSite(sid) {
    runadminws("ChangeSite", { siteid: sid }, function(msg) {
        Refesh();
    });
}

$(function () {
  
    var lastsubmenuid = $.cookie('lastmenuid'); 
    if (lastsubmenuid) {
        $("#" + lastsubmenuid).addClass("active");
        $("#" + lastsubmenuid).parent().show();
        $("#" + lastsubmenuid).parent().prev().addClass("active");

    }
});

////将原来/js/dialog.js重写在这里，主要是工具条用到，前台不用////
function OpenDialog_SavePost(divID, SaveFun, IsAddToForm) {
    var dlg = $('#' + divID);
    dlg.modal('toggle');

    dlg.find(".btn-primary").click(function () {
        SaveFun();
    });
     
}
function OpenDialog_Save(divID, SaveFun) {
    OpenDialog_SavePost(divID, SaveFun, false);

}

function OpenIframe(sUrl, sTitle, btnText) {
    var height = 600;
    var sbHtml = new StringBuilder();
    sbHtml.Append("<div class='modal fade' id='ebiframewin' tabindex='-1' aria-hidden='true' >");
    sbHtml.Append("<div class='modal-dialog modal-lg'>");
    sbHtml.Append("<div class='modal-content'>");
    sbHtml.Append("<div class='modal-header'>");
    sbHtml.Append("<h5 class='modal-title'>{0}</h5>");
    sbHtml.Append("<button type='button' class='btn-close' data-bs-dismiss='modal'></button> ");
    sbHtml.Append("</div>");
    sbHtml.Append("<div style='height:{3}px' class='modal-body'>");
    sbHtml.Append("<iframe id='flOpenIframe' src='{1}' width='100%' height='100%' frameborder='0'></iframe>");
    sbHtml.Append("</div>");
    sbHtml.Append("<div class='modal-footer'>");
    sbHtml.Append("<button type='button' class='btn btn-default' data-bs-dismiss='modal'>关闭</button>");
    if (btnText != "")
        sbHtml.Append("<button type='button'  class='btn btn-primary'>{2}</button>");
    sbHtml.Append("</div></div></div></div> ");
    var sHtml = sbHtml.toString().format(sTitle, sUrl, btnText, height);


    var ob = $(".divEasyuiDialogP");

    if (ob.html() == null) {
        ob = $("<span class='divEasyuiDialogP'></span>").appendTo('body');
    }
    ob.html(sHtml);
    ob.find(".btn-primary")
        .click(function () {
            // var subwin = $(window.parent.document).contents().find("#flOpenIframe")[0]; 
            var subwin = ob.find('iframe')[0];
            subwin.contentWindow.SaveFrame();
        });
    $('#ebiframewin').modal('toggle');
}