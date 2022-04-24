using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base
{
    public class CustomCssJs
    {
        public readonly static CustomCssJs Instance = new CustomCssJs();

        public Dictionary<string, string> PcJs = new Dictionary<string, string>();
        public Dictionary<string, string> PcCss = new Dictionary<string, string>();

        public Dictionary<string, string> MobileJs = new Dictionary<string, string>();
        public Dictionary<string, string> MobileCss = new Dictionary<string, string>();
        public CustomCssJs()
        {

            //pc端默认要加载的js
            PcJs.Add("jqui", "js/plugin/ui/jquery-ui.js");
            PcJs.Add("jqeasyloader", "js/plugin/easyui/easyloader.js");
            PcJs.Add("dialog", "js/dialog.js");
            PcJs.Add("datepicker", "js/plugin/ui/datepicker/js.js");
            PcJs.Add("jqcookie", "js/plugin/jquery.cookie.js");
            PcJs.Add("selectivizr", "js/selectivizr-min.js");
            PcJs.Add("jqscroll", "js/plugin/jquery.scroll.js");
            PcJs.Add("jqimpromptu", "js/plugin/impromptu.js");
            PcJs.Add("jqmasonry", "js/plugin/jquery.masonry.min.js");
            PcJs.Add("infinitescroll", "js/plugin/jquery.infinitescroll.min.js");
            PcJs.Add("jqwaypoints", "js/plugin/waypoints.min.js");
            PcJs.Add("jqcolor", "js/plugin/jquery.color.js");
            PcJs.Add("tinybox", "js/tinybox.js");
            PcJs.Add("jqisotope", "js/plugin/jquery.isotope.js");
            PcJs.Add("jqeasing", "js/plugin/jquery.easing.js");
            PcJs.Add("belatedPNG", "js/DD_belatedPNG.js");
            PcJs.Add("jquerymobile", "js/plugin/jquerymobile/js.js");
            PcJs.Add("easywidgetscjs", "js/plugin/easywidgets/js.js");
            PcJs.Add("curvycorners", "js/plugin/curvycorners.js");
            PcJs.Add("dlgzoom", "js/plugin/jquery.dlgzoom.js");
            PcJs.Add("lazyload", "js/plugin/jquery.lazyload.js");
            PcJs.Add("poshytip", "js/plugin/poshytip/jquery.poshytip.min.js");
            PcJs.Add("messager", "js/plugin/jquery.messager.js");
            PcJs.Add("less", "js/less.js");
            PcJs.Add("validate", "js/plugin/jquery.validate.js");
            PcJs.Add("textauto", "js/plugin/jquery.textauto.js");
            PcJs.Add("userreg", "js/userreg.js");
            PcJs.Add("userlogin", "js/userlogin.js");
            PcJs.Add("userapireg", "js/userapireg.js");
            PcJs.Add("customtags", "js/customtags.js");
            PcJs.Add("selectbox", "js/plugin/SelectSingle/select.js");
            PcJs.Add("topfixed", "js/plugin/jquery.topfixed.js");
            PcJs.Add("jqzoom", "js/plugin/jqzoom/jqzoom.js");



            //pc css
            PcCss.Add("jquicss", "js/plugin/ui/jquery-ui-1.8.4.custom.css");
            PcCss.Add("jquerymobilecss", "js/plugin/jquerymobile/css.css");
            PcCss.Add("easywidgetscss", "js/plugin/easywidgets/css.css");
            PcCss.Add("poshytipcss", "js/plugin/poshytip/tip-yellow/tip-yellow.css");
            PcCss.Add("jqzoomcss", "js/plugin/jqzoom/jquery.jqzoom.css");




            //手机端 可订制js
            MobileJs.Add("add2desktop", "js/mobile/js/widget/add2desktop.js");
            MobileJs.Add("button.input", "js/mobile/js/widget/button.input.js");
            MobileJs.Add("button", "js/mobile/js/widget/button.js");
            MobileJs.Add("dialog.container", "js/mobile/js/widget/dialog.container.js");
            MobileJs.Add("dialog", "js/mobile/js/widget/dialog.js");
            MobileJs.Add("dropmenu.iscroll", "js/mobile/js/widget/dropmenu.iscroll.js");
            MobileJs.Add("dropmenu", "js/mobile/js/widget/dropmenu.js");
            MobileJs.Add("gotop.iscroll", "js/mobile/js/widget/gotop.iscroll.js");
            MobileJs.Add("gotop", "js/mobile/js/widget/gotop.js");
            MobileJs.Add("more", "js/mobile/js/widget/more.js");
            MobileJs.Add("navigator.iscroll", "js/mobile/js/widget/navigator.iscroll.js");
            MobileJs.Add("navigator", "js/mobile/js/widget/navigator.js");
            MobileJs.Add("pageswipe", "js/mobile/js/widget/pageswipe.js");
            MobileJs.Add("progressbar", "js/mobile/js/widget/progressbar.js");
            MobileJs.Add("quickdelete", "js/mobile/js/widget/quickdelete.js");
            MobileJs.Add("refresh.iOS5", "js/mobile/js/widget/refresh.iOS5.js");
            MobileJs.Add("refresh.iscroll", "js/mobile/js/widget/refresh.iscroll.js");
            MobileJs.Add("refresh", "js/mobile/js/widget/refresh.js");
            MobileJs.Add("refresh.lite", "js/mobile/js/widget/refresh.lite.js");
            MobileJs.Add("slider", "js/mobile/js/widget/slider.js");
            MobileJs.Add("suggestion", "js/mobile/js/widget/suggestion.js");
            MobileJs.Add("tabs.ajax", "js/mobile/js/widget/tabs.ajax.js");
            MobileJs.Add("tabs", "js/mobile/js/widget/tabs.js");
            MobileJs.Add("tabs.swipe", "js/mobile/js/widget/tabs.swipe.js");
            MobileJs.Add("toolbar", "js/mobile/js/widget/toolbar.js");

            MobileJs.Add("zepto.iscroll", "js/mobile/js/zepto.iscroll.js");
            MobileJs.Add("zepto.fix", "js/mobile/js/zepto.fix.js");
            MobileJs.Add("zepto.highlight", "js/mobile/js/zepto.highlight.js");
            MobileJs.Add("zepto.imglazyload", "js/mobile/js/zepto.imglazyload.js");
            MobileJs.Add("zepto.location", "js/mobile/js/zepto.location.js");
            MobileJs.Add("zepto.position", "js/mobile/js/zepto.position.js");
            
            //手机端 可订制css
            MobileCss.Add("add2desktop", "js/mobile/css/widget/add2desktop/add2desktop.css");
            MobileCss.Add("button", "js/mobile/css/widget/button/button.css");
            MobileCss.Add("button.default", "js/mobile/css/widget/button/button.default.css");
            MobileCss.Add("dialog", "js/mobile/css/widget/dialog/dialog.css");
            MobileCss.Add("dialog.default", "js/mobile/css/widget/dialog/dialog.default.css");
            MobileCss.Add("dropmenu", "js/mobile/css/widget/dropmenu/dropmenu.css");
            MobileCss.Add("dropmenu.default", "js/mobile/css/widget/dropmenu/dropmenu.default.css");
            MobileCss.Add("gotop", "js/mobile/css/widget/gotop/gotop.css");
            MobileCss.Add("more", "js/mobile/css/widget/more/more.css");
            MobileCss.Add("more.default", "js/mobile/css/widget/more/more.default.css");
            MobileCss.Add("navigator", "js/mobile/css/widget/navigator/navigator.css");
            MobileCss.Add("navigator.default", "js/mobile/css/widget/navigator/navigator.default.css");
            MobileCss.Add("navigator.iscroll", "js/mobile/css/widget/navigator/navigator.iscroll.css");
            MobileCss.Add("navigator.iscroll.default", "js/mobile/css/widget/navigator/navigator.iscroll.default.css");
            MobileCss.Add("pageswipe", "js/mobile/css/widget/pageswipe/pageswipe.css");
            MobileCss.Add("progressbar", "js/mobile/css/widget/progressbar/progressbar.css");
            MobileCss.Add("quickdelete", "js/mobile/css/widget/quickdelete/quickdelete.css");
            MobileCss.Add("refresh.default", "js/mobile/css/widget/refresh/refresh.default.css");
            MobileCss.Add("refresh.iOS5.default", "js/mobile/css/widget/refresh/refresh.iOS5.default.css");
            MobileCss.Add("refresh.iscroll.default", "js/mobile/css/widget/refresh/refresh.iscroll.default.css");
            MobileCss.Add("slider", "js/mobile/css/widget/slider/slider.css");
            MobileCss.Add("slider.default", "js/mobile/css/widget/slider/slider.default.css");
            MobileCss.Add("suggestion", "js/mobile/css/widget/suggestion/suggestion.css");
            MobileCss.Add("suggestion.default", "js/mobile/css/widget/suggestion/suggestion.default.css");
            MobileCss.Add("tabs", "js/mobile/css/widget/tabs/tabs.css");
            MobileCss.Add("tabs.default", "js/mobile/css/widget/tabs/tabs.default.css");
            MobileCss.Add("toolbar", "js/mobile/css/widget/toolbar/toolbar.css");
            MobileCss.Add("toolbar.default", "js/mobile/css/widget/toolbar/toolbar.default.css");




        }
    }
}
