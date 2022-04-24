﻿(function ($) {
    $.fn.infinitescroll = function (options, callback) {

        function debug() {
            if (opts.debug) { window.console && console.log.call(console, arguments) }
        }
        function areSelectorsValid(opts) {
            for (var key in opts) {
                if (key.indexOf && key.indexOf('Selector') > -1 && $(opts[key]).length === 0) { debug('Your ' + key + ' found no elements.'); return false; }
                return true;
            }
        }
        function determinePath(path) {
            path.match(relurl) ? path.match(relurl)[2] : path; if (path.match(/^(.*?)\b2\b(.*?$)/)) { path = path.match(/^(.*?)\b2\b(.*?$)/).slice(1); } else
                if (path.match(/^(.*?)2(.*?$)/)) {
                    if (path.match(/^(.*?page=)2(\/.*|$)/)) { path = path.match(/^(.*?page=)2(\/.*|$)/).slice(1); return path; }
                    debug('Trying backup next selector parse technique. Treacherous waters here, matey.'); path = path.match(/^(.*?)2(.*?$)/).slice(1);
                } else {
                    if (path.match(/^(.*?page=)1(\/.*|$)/)) { path = path.match(/^(.*?page=)1(\/.*|$)/).slice(1); return path; }
                    debug('Sorry, we couldn\'t parse your Next (Previous Posts) URL. Verify your the css selector points to the correct A tag. If you still get this error: yell, scream, and kindly ask for help at infinite-scroll.com.'); props.isInvalidPage = true;
                }
            return path;
        }
        function getDocumentHeight() {
            return opts.localMode ? ($(props.container)[0].scrollHeight && $(props.container)[0].scrollHeight) : $(document).height()
        }
        function isNearBottom() {
            var pixelsFromWindowBottomToBottom = 0 +
                getDocumentHeight() - (opts.localMode ? $(props.container).scrollTop() : ($(props.container).scrollTop() || $(props.container.ownerDocument.body).scrollTop())) - $(opts.localMode ? props.container : window).height(); debug('math:', pixelsFromWindowBottomToBottom, props.pixelsFromNavToBottom); return (pixelsFromWindowBottomToBottom - opts.bufferPx < props.pixelsFromNavToBottom);
        }
        function showDoneMsg() {
            //props.loadingMsg.find('img').hide().parent().find('div').html(opts.donetext).animate({ opacity: 1 }, 2000).fadeOut('normal');
            //$("#infscr-loading img").hide().parent().find('div').html(opts.donetext).animate({ opacity: 1 }, 2000).fadeOut('normal');
            props.loadingMsg.hide();
            opts.errorCallback();
        }
        function infscrSetup() {

            if (props.isDuringAjax || props.isInvalidPage || props.isDone) return;
            if (!isNearBottom(opts, props)) return;
            $(document).trigger('retrieve.infscr');
        }
        function kickOffAjax() {
            //alert("触发了 kickOffAjax")
            props.isDuringAjax = true;
            props.loadingMsg.appendTo(opts.contentSelector).show();
            $(opts.navSelector).hide();
            props.currPage++;
            debug('heading into ajax', path);
            box = $(opts.contentSelector).is('table') ? $('<tbody/>') : $('<div/>');
            frag = document.createDocumentFragment();
            box.load(path.join(props.currPage) + ' ' + opts.itemSelector, null, loadCallback);
        }
        function loadCallback() {

            if (props.isDone) {
                showDoneMsg(); return false;
            }
            else {
                var children = box.children().get();

                if (children.length == 0 || $.trim($(children).html()) == "") {

                    showDoneMsg(); return false;
                    //return $.event.trigger("ajaxError", [{ status: 404}]);
                }

                while (box[0].firstChild) { frag.appendChild(box[0].firstChild); }

                $(opts.contentSelector)[0].appendChild(frag);

                //                props.loadingMsg.fadeOut('normal');
                props.loadingMsg.hide();
                if (opts.animate) {
                    var scrollTo = $(window).scrollTop() + $('#infscr-loading').height() + opts.extraScrollPx + 'px';
                    $('html,body').animate({ scrollTop: scrollTo }, 800, function () { props.isDuringAjax = false; });
                }
                callback.call($(opts.contentSelector)[0], children);
                if (!opts.animate) props.isDuringAjax = false;

            }
        }
        $.browser.ie6 = $.browser.msie && $.browser.version < 7;
        var opts = $.extend({}, $.infinitescroll.defaults, options), props = $.infinitescroll, box, frag; callback = callback || function () { };
        if (!areSelectorsValid(opts)) { return false; }

        props.container = opts.localMode ? this : document.documentElement;
        opts.contentSelector = opts.contentSelector || this;

        var relurl = /(.*?\/\/).*?(\/.*)/, path = $(opts.nextSelector).attr('href');

        if (!path) { debug('Navigation selector not found'); return; }
        path = determinePath(path);

        if (opts.localMode) $(props.container)[0].scrollTop = 0;

        props.pixelsFromNavToBottom = getDocumentHeight() + (props.container == document.documentElement ? 0 : $(props.container).offset().top) - $(opts.navSelector).offset().top;

        props.loadingMsg = $('<div id="infscr-loading" style="text-align: center;"><img alt="Loading..." src="' + opts.loadingImg + '" /><div>' + opts.loadingText + '</div></div>');

        (new Image()).src = opts.loadingImg;


        //        $(document).ajaxError(function(e, xhr, opt) {
        //             debug('Page not found. Self-destructing...'); if (xhr.status == 404) { showDoneMsg(); props.isDone = true; $(opts.localMode ? this : window).unbind('scroll.infscr'); }
        //         }); 

        //$(opts.localMode ? this : window).bind('scroll.infscr', infscrSetup).trigger('scroll.infscr');
        //$(document).bind('retrieve.infscr', kickOffAjax);

        $(options.clickBtn).click(function () {
            kickOffAjax();
        });
        return this;

    }
    $.infinitescroll =
        {
            defaults:
            {
                debug: false,
                preload: false,
                nextSelector: "div.navigation a:first",
                loadingImg: "/images/loading2.gif",
                loadingText: "<em>Loading the next set of posts...</em>",
                donetext: "<em>Congratulations, you've reached the end of the internet.</em>",
                navSelector: "div.navigation",
                contentSelector: null,
                extraScrollPx: 150,
                itemSelector: "div.post",
                animate: false,
                localMode: false,
                bufferPx: 40,
                errorCallback: function () { }
            },
            loadingImg: undefined,
            loadingMsg: undefined,
            container: undefined,
            currPage: 1,
            currDOMChunk: null,
            isDuringAjax: false,
            isInvalidPage: false,
            isDone: false,
            clickBtn: ""
        };
})(Zepto);