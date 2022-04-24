//不需要载入 'jqui', 'jquicss',
//In.ready('jqeasyloader', function () {
//    easyloader.locale = "zh_CN"; // 本地化设置
//    //easyloader.theme = "default"; // 设置主题
//});

easyloader.locale = "zh_CN"; // 本地化设置


function OpenDialog_Simple(divID, Title) {
    OpenDialog(divID, Title, true, false, true, 0, 0, false);
}
function OpenDialog_Modal(divID, Title) {
    OpenDialog(divID, Title, true, false, true, 0, 0, true);
}

function OpenDialog(divID, Title, Iscollapsible, IsMinimizable, IsMaximizable, iwidth, iheight, ismodal) {

    var sOb = "modal: " + ismodal + ",collapsible: true,minimizable: false,maximizable: true";

    if (Title != "") sOb += ",title: '" + Title + "'";
    if (iwidth > 0) sOb += ",width: " + iwidth;
    if (iheight > 0) sOb += ",height: " + iheight;

    var obOpt = JsonToObj(sOb);

    using('dialog', function () {
        $('#' + divID).show();
        $('#' + divID).dialog(obOpt);

    });

}
function OpenDialog_Save(divID, SaveFun) {

    OpenDialog_OK(divID, SaveFun, "", "", false);

}


function OpenDialog_OK(divID, SaveFun, txtok, txtno, ismodal) {
    var _txtok = "提交";
    if (txtok != "")
        _txtok = txtok;
    var _txtno = "取消";
    if (txtno != "")
        _txtno = txtno;
    using('dialog', function () {
        $('#' + divID).show();
        $('#' + divID).dialog({
            modal: ismodal,
            buttons: [{
                text: _txtok,
                iconCls: 'icon-ok',
                handler: function () {
                    SaveFun();
                }
            },
                         {
                             text: _txtno,
                             handler: function () {
                                 $('#' + divID).dialog('close');
                             }
                         }]
        });

    });
}


//默认情况下，divID添加在body里，回发时将取不到值，所以要应用于服务器端控件要将添加divID添加到form
function OpenDialog_SavePost(divID, SaveFun, IsAddToForm) {

    using('dialog', function () {
        var dlg = $('#' + divID);
        dlg.show();
        dlg.dialog({
            buttons: [{
                text: '提交',
                iconCls: 'icon-ok',
                handler: function () {
                    //                    alert("fsdf")
                    SaveFun();
                }
            },
                             {
                                 text: '取消',
                                 handler: function () {
                                     $('#' + divID).dialog('close');
                                 }
                             }]
        });

        if (IsAddToForm)
            dlg.parent().appendTo(jQuery("form:first"));


    });
}

function OpenDialog_SaveSubmit(divID, btnSavePostID, Confirminfo) {

    using('dialog', function () {
        var dlg = $('#' + divID);
        dlg.show();
        dlg.dialog({
            buttons: [{
                text: '提交',
                iconCls: 'icon-ok',
                handler: function () {
                    if (Confirminfo != "") {
                        if (confirm(Confirminfo)) {
                            $("#" + btnSavePostID).click();
                        }
                    }
                    else {
                        $("#" + btnSavePostID).click();
                    }

                }
            },
                             {
                                 text: '取消',
                                 handler: function () {
                                     $('#' + divID).dialog('close');
                                 }
                             }]
        });

        dlg.parent().appendTo(jQuery("form:first"));


    });
}

function OpenDialog_Iframe(sUrl, sTitle, iWidth, iHeight, isModal) {
    var obDil = $("<div id=\"divDialog\" style=\"padding:5px;width:" + iWidth + "px;height:" + iHeight + "px; display:none\"  title=\"" + sTitle + "\"></div>");


    var obIFrame = $("<iframe  src=\"" + sUrl + "\"  style=\"width:100%;height:100%;\" frameborder=\"0\"  marginwidth=\"0\" marginheight=\"0\"  ></iframe>").appendTo(obDil);

    var ob = $("#divDialogP");

    if (ob.html() == null) {
        ob = $("<span id='divDialogP'></span>").appendTo('body');

        ob.html(obDil);
    }
    else {

        ob.html(obDil);
    }


    if (isModal) {
        OpenDialog_Modal("divDialog", sTitle);
    }
    else {
        OpenDialog_Simple("divDialog", sTitle);
    }
}
//以post方式打开窗口
function postwinopen(strUrl, postdata) {

    var contrlos = postdata.split("&");
    var form = document.createElement("form");
    for (var i = 0; i < contrlos.length; i++) {

        var strPram = contrlos[i];

        var cotrlosname = strPram.substring(0, strPram.indexOf("="));
        var sValue = strPram.substring(strPram.indexOf("=") + 1, strPram.length);

        var input = document.createElement("input");
        input.setAttribute("type", "text");
        input.setAttribute("style", "display:none");
        input.name = cotrlosname;
        input.value = sValue;

        form.appendChild(input);
    }

    document.body.appendChild(form);
    form.target = "_blank";
    form.method = "post";
    form.action = strUrl;
    form.submit();
    document.body.removeChild(form);
}
