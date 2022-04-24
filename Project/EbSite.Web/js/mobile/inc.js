/*
功能:按需加载
使用方法:
1.加载一个文件 In.ready('tinybox');
2.单个加载完成后执行代码
In.ready('dialog', function () {
//执行代码
});
3.多个加载完成后执行代码
In.ready('jqmasonry','jqmasonry2', function () {
//执行代码
});
*/
~function () { var __head = document.head || document.getElementsByTagName("head")[0]; var __waterfall = {}; var __loaded = {}; var __loading = {}; var __configure = { autoload: false, core: "", serial: false }; var __in; var __load = function (url, type, charset, callback) { if (__loading[url]) { if (callback) { setTimeout(function () { __load(url, type, charset, callback) }, 1); return } return } if (__loaded[url]) { if (callback) { callback(); return } return } __loading[url] = true; var pureurl = url.split("?")[0]; var n, t = type || pureurl.toLowerCase().substring(pureurl.lastIndexOf(".") + 1); if (t === "js") { n = document.createElement("script"); n.type = "text/javascript"; n.src = url; n.async = "true"; if (charset) { n.charset = charset } } else { if (t === "css") { n = document.createElement("link"); n.type = "text/css"; n.rel = "stylesheet"; n.href = url; __loaded[url] = true; __loading[url] = false; __head.appendChild(n); if (callback) { callback() } return } } n.onload = n.onreadystatechange = function () { if (!this.readyState || this.readyState === "loaded" || this.readyState === "complete") { __loading[url] = false; __loaded[url] = true; if (callback) { callback() } n.onload = n.onreadystatechange = null } }; n.onerror = function () { __loading[url] = false; if (callback) { callback() } n.onerror = null }; __head.appendChild(n) }; var __analyze = function (array) { var riverflow = []; for (var i = array.length - 1; i >= 0; i--) { var current = array[i]; if (typeof (current) === "string") { if (!__waterfall[current]) { continue } riverflow.push(current); var relylist = __waterfall[current].rely; if (relylist) { riverflow = riverflow.concat(__analyze(relylist)) } } else { if (typeof (current) === "function") { riverflow.push(current) } } } return riverflow }; var __stackline = function (blahlist) { var o = this; this.stackline = blahlist; this.current = this.stackline[0]; this.bag = { returns: [], complete: false }; this.start = function () { if (typeof (o.current) != "function" && __waterfall[o.current]) { __load(__waterfall[o.current].path, __waterfall[o.current].type, __waterfall[o.current].charset, o.next) } else { o.bag.returns.push(o.current()); o.next() } }; this.next = function () { if (o.stackline.length == 1 || o.stackline.length < 1) { o.bag.complete = true; if (o.bag.oncomplete) { o.bag.oncomplete(o.bag.returns) } return } o.stackline.shift(); o.current = o.stackline[0]; o.start() } }; var __parallel = function (blahlist, callback) { var length = blahlist.length; var hook = function () { if (! --length && callback) { callback() } }; if (length == 0) { callback && callback(); return } for (var i = 0; i < blahlist.length; i++) { var current = __waterfall[blahlist[i]]; if (typeof (blahlist[i]) == "function") { blahlist[i](); hook(); continue } if (current.rely && current.rely.length != 0) { __parallel(current.rely, (function (current) { return function () { __load(current.path, current.type, current.charset, hook) } })(current)) } else { __load(current.path, current.type, current.charset, hook) } } }; var __add = function (name, config) { if (!name || !config || !config.path) { return } __waterfall[name] = config }; var __adds = function (config) { if (!config.modules) { return } for (var module in config.modules) { var module_config = config.modules[module]; if (!config.modules.hasOwnProperty(module)) { continue } if (config.type && !module_config.type) { module_config.type = config.type } if (config.charset && !module_config.charset) { module_config.charset = config.charset } __add.call(this, module, module_config) } }; var __config = function (name, conf) { __configure[name] = conf }; var __css = function (csstext) { var css = document.getElementById("in-inline-css"); if (!css) { css = document.createElement("style"); css.type = "text/css"; css.id = "in-inline-css"; __head.appendChild(css) } if (css.styleSheet) { css.styleSheet.cssText = css.styleSheet.cssText + csstext } else { css.appendChild(document.createTextNode(csstext)) } }; var __later = function () { var args = [].slice.call(arguments); var timeout = args.shift(); window.setTimeout(function () { __in.apply(this, args) }, timeout) }; var __ready = function () { var args = arguments; __contentLoaded(window, function () { __in.apply(this, args) }) }; var __in = function () { var args = [].slice.call(arguments); if (__configure.serial) { if (__configure.core && !__loaded[__configure.core]) { args = ["__core"].concat(args) } var blahlist = __analyze(args).reverse(); var stack = new __stackline(blahlist); stack.start(); return stack.bag } if (typeof (args[args.length - 1]) === "function") { var callback = args.pop() } if (__configure.core && !__loaded[__configure.core]) { __parallel(["__core"], function () { __parallel(args, callback) }) } else { __parallel(args, callback) } }; var __contentLoaded = function (win, fn) { var done = false, top = true, doc = win.document, root = doc.documentElement, add = doc.addEventListener ? "addEventListener" : "attachEvent", rem = doc.addEventListener ? "removeEventListener" : "detachEvent", pre = doc.addEventListener ? "" : "on", init = function (e) { if (e.type == "readystatechange" && doc.readyState != "complete") { return } (e.type == "load" ? win : doc)[rem](pre + e.type, init, false); if (!done && (done = true)) { fn.call(win, e.type || e) } }, poll = function () { try { root.doScroll("left") } catch (e) { setTimeout(poll, 50); return } init("poll") }; if (doc.readyState == "complete") { fn.call(win, "lazy") } else { if (doc.createEventObject && root.doScroll) { try { top = !win.frameElement } catch (e) { } if (top) { poll() } } doc[add](pre + "DOMContentLoaded", init, false); doc[add](pre + "readystatechange", init, false); win[add](pre + "load", init, false) } }; void function () { var myself = (function () { var scripts = document.getElementsByTagName("script"); return scripts[scripts.length - 1] })(); var autoload = myself.getAttribute("autoload"); var core = myself.getAttribute("core"); if (core) { __configure.autoload = eval(autoload); __configure.core = core; __add("__core", { path: __configure.core }) } if (__configure.autoload && __configure.core) { __in() } } (); __in.add = __add; __in.adds = __adds; __in.config = __config; __in.css = __css; __in.later = __later; __in.load = __load; __in.ready = __ready; __in.use = __in; this.In = __in } ();


//extend
In.add('gmue-detect', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/detect.js', type: 'js', charset: 'utf-8' });
In.add('gmue-ortchange', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/event.ortchange.js', type: 'js', charset: 'utf-8' });
In.add('gmue-scrollStop', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/event.scrollStop.js', type: 'js', charset: 'utf-8' });
In.add('gmue-fix', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/fix.js', type: 'js', charset: 'utf-8' });
In.add('gmue-highlight', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/highlight.js', type: 'js', charset: 'utf-8' });
In.add('gmue-imglazyload', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/imglazyload.js', type: 'js', charset: 'utf-8' });
In.add('gmue-iscroll', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/iscroll.js', type: 'js', charset: 'utf-8' });
In.add('gmue-matchMedia', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/matchMedia.js', type: 'js', charset: 'utf-8' });
In.add('gmue-offset', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/offset.js', type: 'js', charset: 'utf-8' });
In.add('gmue-parseTpl', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/parseTpl.js', type: 'js', charset: 'utf-8' });
In.add('gmue-position', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/position.js', type: 'js', charset: 'utf-8' });
In.add('gmue-support', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/support.js', type: 'js', charset: 'utf-8' });
In.add('gmue-throttle', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/throttle.js', type: 'js', charset: 'utf-8' });
In.add('gmue-touch', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/extend/touch.js', type: 'js', charset: 'utf-8' });

//widget
In.add('gmuw-add2desktop', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/add2desktop/add2desktop.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-button', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/button/button.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-calendar', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/calendar/calendar.js', type: 'js', charset: 'utf-8' });



In.add('dialogcss', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/css/widget/dialog/dialog.css' });
In.add('dialogdefaultcss', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/css/widget/dialog/dialog.default.css' });
In.add('gmuw-dialog', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/dialog/dialog.js', type: 'js', charset: 'utf-8', rely: ['dialogcss', 'dialogdefaultcss'] });

In.add('dropmenucss', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/css/widget/dropmenu/dropmenu.css' });
In.add('dropmenudefaultcss', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/css/widget/dropmenu/dropmenu.default.css' });
In.add('gmuw-dropmenu', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/dropmenu/dropmenu.js', type: 'js', charset: 'utf-8', rely: ['dropmenucss', 'dropmenudefaultcss'] });
In.add('gmuw-horizontal', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/dropmenu/horizontal.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-placement', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/dropmenu/placement.js', type: 'js', charset: 'utf-8' });

In.add('gmuw-gotop', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/gotop/gotop.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-historylist', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/historylist/historylist.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-navigator', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/navigator/navigator.js', type: 'js', charset: 'utf-8' });


In.add('panelcss', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/css/widget/panel/panel.css' });
//In.add('paneldefaultcss', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/css/widget/panel/panel.default.css' });
In.add('paneldemocss', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/css/widget/panel/panel_demo.css' });
In.add('gmuw-panel', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/panel/panel.js', type: 'js', charset: 'utf-8', rely: ['panelcss'] });

In.add('gmuw-popover', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/popover/popover.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-progressbar', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/progressbar/progressbar.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-refresh', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/refresh/refresh.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-refreshlite', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/refresh/$lite.js', type: 'js', charset: 'utf-8' });

In.add('gmuw-slider', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/slider/slider.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-imgzoom', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/slider/imgzoom.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-dots', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/slider/dots.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-arrow', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/slider/arrow.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-touch', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/slider/touch.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-autoplay', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/slider/autoplay.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-lazyloadimg', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/slider/lazyloadimg.js', type: 'js', charset: 'utf-8' });

In.add('gmuw-suggestion', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/suggestion/suggestion.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-tabs', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/tabs/tabs.js', type: 'js', charset: 'utf-8' });
In.add('gmuw-toolbar', { path: SiteConfigs.UrlIISPath + 'js/mobile/gmu/js/widget/toolbar/toolbar.js', type: 'js', charset: 'utf-8', rely: ['gmue-parseTpl', 'gmue-fix'] });

In.add('html5audio', { path: SiteConfigs.UrlIISPath + 'js/mobile/plugins/html5audio/audio.min.js', type: 'js', charset: 'utf-8' });

