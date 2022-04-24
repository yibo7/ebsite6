//var CurrentEasyuiDialog = null;
//function ColseWinbox() {

//    if (CurrentEasyuiDialog) {
//        CurrentEasyuiDialog.dialog('close');
//    }
//}
function IframeWinbox() {
    this.PluginPath = SiteConfigs.UrlIISPath + "js/plugin/EasyuiDialog/";
    this.Width = 600;  //窗口宽
    this.Height = 250; //窗口高
    this.Title = "";   //窗口标题
    this.IsColseReLoad = false; //是否关闭时刷新页面
    this.IsModal = true;   //是否模式窗口
    this.Collapsible = true;   //是否显示收缩功能
    this.Minimizable = false;     //是否显示最小化功能
    this.Maximizable = true;   //是否显示最大化功能
    this.IsFull = false; //是否打开时最大化
    this.Href = ""; //Iframe 的地址
    this.SaveText = "保存"; //保存按钮文本
    this.obLoading = null;
    var _this = this;
    this.Init = function (ob) {
        var obCurrent = $(ob);
        if (ob) {
            var pram = obCurrent.attr("edwidth");
            if (pram)
                this.Width = pram;
            pram = obCurrent.attr("edheight");
            if (pram)
                this.Height = pram;
            pram = obCurrent.attr("edtitle");
            if (pram)
                this.Title = pram;
            pram = obCurrent.attr("edrefesh");
            if (pram) {

                this.IsColseReLoad = pram;
            }

            pram = obCurrent.attr("edmodal");
            if (pram)
                this.IsModal = pram;
            pram = obCurrent.attr("edmax");
            if (pram)
                this.Maximizable = pram;
            pram = obCurrent.attr("edmin");
            if (pram)
                this.Minimizable = pram;
            pram = obCurrent.attr("edcoll");
            if (pram)
                this.Collapsible = pram;
            pram = obCurrent.attr("edhref");
            if (pram)
                this.Href = pram;

            pram = obCurrent.attr("isfull");
//            if (pram)
            this.IsFull = pram;

            pram = obCurrent.attr("savetext");
            
                this.SaveText = pram;

            obCurrent.click(function () {
                _this.OpenDialog();

            });
        }
       

    }
    this.OpenDialog = function () {
        //保存按钮文字为空时，不显示保存按钮
        OpenIframe(this.Href, this.Title, this.SaveText);
        /*OpenIframe(this.Href, this.Title, parseInt(this.Width), parseInt(this.Height), this.SaveText);*/

        //var obDil = $("<div  style=\"padding:5px;width:" + this.Width + "px;height:" + this.Height + "px; display:none\"  title=\"" + this.Title + "\"></div>");
        //CurrentEasyuiDialog = obDil;
        //this.obLoading = $("<div style='width:100%; height:100%; margin-top:50px; text-align:center'><img src='" + this.PluginPath + "loading.gif' /><br>页面载入中...</div>").appendTo(obDil);

        //var obIFrame = $("<iframe  src=\"" + this.Href + "\"  style=\"width:100%;height:100%;\" frameborder=\"0\"  marginwidth=\"0\" marginheight=\"0\"  ></iframe>").appendTo(obDil);

        //var ob = $(".divEasyuiDialogP");

        //if (ob.html() == null) {

        //    ob = $("<span class='divEasyuiDialogP'></span>").appendTo('body');

        //}
        //ob.html(obDil);
        //var sOb = "resizable:true,collapsible: " + this.Collapsible + ",minimizable: " + this.Minimizable + ",maximizable: " + this.Maximizable;

        //sOb += ",title: '" + this.Title + "'";
        //sOb += ",width: " + parseInt(this.Width);
        //sOb += ",height: " + parseInt(this.Height);
        //sOb += ",modal:" + this.IsModal;

        //if (this.IsColseReLoad == "True" || this.IsColseReLoad == "true") {

        //    sOb += ",onClose:Refesh";
        //}

        //var obOpt = JsonToObj(sOb);
        //In.ready('dialog', function () {
        //    using('dialog', function () {
        //        //var win = ob.children("div:first");

        //        obDil.show();
        //        obDil.dialog(obOpt);

        //        if (_this.IsFull) {
        //            obDil.dialog('maximize'); //最大化窗口
        //        }


        //    });
        //});

        //obIFrame.load(this.Loaded);

    }

    this.Loaded = function () {
        if (_this.obLoading)
            _this.obLoading.remove();
        
    }

}
function Refesh() {
    //最后带个#号不能定向，不知道为什么

    document.location.href = document.location.href.replace("#", "");

}

jQuery(function ($) {

    $(".EasyuiDialog").each(function (i) {
        var _f = new IframeWinbox();
        _f.Init(this);
    });

    $("body").css("height", document.body.scrollHeight);

});