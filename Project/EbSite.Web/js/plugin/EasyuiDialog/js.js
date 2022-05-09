function IframeWinbox() {
    //this.PluginPath = SiteConfigs.UrlIISPath + "js/plugin/EasyuiDialog/";
    this.Width = 600;  //窗口宽
    this.Height = 250; //窗口高
    this.Title = "";   //窗口标题
    //this.IsColseReLoad = false; //是否关闭时刷新页面
    //this.IsModal = true;   //是否模式窗口
    //this.Collapsible = true;   //是否显示收缩功能
    //this.Minimizable = false;     //是否显示最小化功能
    //this.Maximizable = true;   //是否显示最大化功能
    //this.IsFull = false; //是否打开时最大化
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
            pram = obCurrent.attr("edhref");
            if (pram)
                this.Href = pram;
            pram = obCurrent.attr("savetext");
            if (pram)
                this.SaveText = pram;
            //pram = obCurrent.attr("edrefesh");
            //if (pram) {

            //    this.IsColseReLoad = pram;
            //}

            //pram = obCurrent.attr("edmodal");
            //if (pram)
            //    this.IsModal = pram;
            //pram = obCurrent.attr("edmax");
            //if (pram)
            //    this.Maximizable = pram;
            //pram = obCurrent.attr("edmin");
            //if (pram)
            //    this.Minimizable = pram;
            //pram = obCurrent.attr("edcoll");
            //if (pram)
            //    this.Collapsible = pram;

            //pram = obCurrent.attr("isfull"); 
            //this.IsFull = pram;
            

            obCurrent.click(function () {
                _this.OpenDialog();

            });
        }
       

    }
    this.OpenDialog = function () {
        //保存按钮文字为空时，不显示保存按钮
        OpenIframe(this.Href, this.Title, this.SaveText); 

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