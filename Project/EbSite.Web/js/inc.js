
/*
功能:按需加载
使用方法:
1.加载一个文件 In.ready('tinybox');
2.单个加载完成后执行代码
In.ready('customtags', function () {
   //执行代码
});
3.多个加载完成后执行代码
In.ready('jqmasonry','jqmasonry2', function () {
   //执行代码
});
*/
~function () { var __head = document.head || document.getElementsByTagName("head")[0]; var __waterfall = {}; var __loaded = {}; var __loading = {}; var __configure = { autoload: false, core: "", serial: false }; var __in; var __load = function (url, type, charset, callback) { if (__loading[url]) { if (callback) { setTimeout(function () { __load(url, type, charset, callback) }, 1); return } return } if (__loaded[url]) { if (callback) { callback(); return } return } __loading[url] = true; var pureurl = url.split("?")[0]; var n, t = type || pureurl.toLowerCase().substring(pureurl.lastIndexOf(".") + 1); if (t === "js") { n = document.createElement("script"); n.type = "text/javascript"; n.src = url; n.async = "true"; if (charset) { n.charset = charset } } else { if (t === "css") { n = document.createElement("link"); n.type = "text/css"; n.rel = "stylesheet"; n.href = url; __loaded[url] = true; __loading[url] = false; __head.appendChild(n); if (callback) { callback() } return } } n.onload = n.onreadystatechange = function () { if (!this.readyState || this.readyState === "loaded" || this.readyState === "complete") { __loading[url] = false; __loaded[url] = true; if (callback) { callback() } n.onload = n.onreadystatechange = null } }; n.onerror = function () { __loading[url] = false; if (callback) { callback() } n.onerror = null }; __head.appendChild(n) }; var __analyze = function (array) { var riverflow = []; for (var i = array.length - 1; i >= 0; i--) { var current = array[i]; if (typeof (current) === "string") { if (!__waterfall[current]) {  continue } riverflow.push(current); var relylist = __waterfall[current].rely; if (relylist) { riverflow = riverflow.concat(__analyze(relylist)) } } else { if (typeof (current) === "function") { riverflow.push(current) } } } return riverflow }; var __stackline = function (blahlist) { var o = this; this.stackline = blahlist; this.current = this.stackline[0]; this.bag = { returns: [], complete: false }; this.start = function () { if (typeof (o.current) != "function" && __waterfall[o.current]) { __load(__waterfall[o.current].path, __waterfall[o.current].type, __waterfall[o.current].charset, o.next) } else { o.bag.returns.push(o.current()); o.next() } }; this.next = function () { if (o.stackline.length == 1 || o.stackline.length < 1) { o.bag.complete = true; if (o.bag.oncomplete) { o.bag.oncomplete(o.bag.returns) } return } o.stackline.shift(); o.current = o.stackline[0]; o.start() } }; var __parallel = function (blahlist, callback) { var length = blahlist.length; var hook = function () { if (! --length && callback) { callback() } }; if (length == 0) { callback && callback(); return } for (var i = 0; i < blahlist.length; i++) { var current = __waterfall[blahlist[i]]; if (typeof (blahlist[i]) == "function") { blahlist[i](); hook(); continue } if (current.rely && current.rely.length != 0) { __parallel(current.rely, (function (current) { return function () { __load(current.path, current.type, current.charset, hook) } })(current)) } else { __load(current.path, current.type, current.charset, hook) } } }; var __add = function (name, config) { if (!name || !config || !config.path) { return } __waterfall[name] = config }; var __adds = function (config) { if (!config.modules) { return } for (var module in config.modules) { var module_config = config.modules[module]; if (!config.modules.hasOwnProperty(module)) { continue } if (config.type && !module_config.type) { module_config.type = config.type } if (config.charset && !module_config.charset) { module_config.charset = config.charset } __add.call(this, module, module_config) } }; var __config = function (name, conf) { __configure[name] = conf }; var __css = function (csstext) { var css = document.getElementById("in-inline-css"); if (!css) { css = document.createElement("style"); css.type = "text/css"; css.id = "in-inline-css"; __head.appendChild(css) } if (css.styleSheet) { css.styleSheet.cssText = css.styleSheet.cssText + csstext } else { css.appendChild(document.createTextNode(csstext)) } }; var __later = function () { var args = [].slice.call(arguments); var timeout = args.shift(); window.setTimeout(function () { __in.apply(this, args) }, timeout) }; var __ready = function () { var args = arguments; __contentLoaded(window, function () { __in.apply(this, args) }) }; var __in = function () { var args = [].slice.call(arguments); if (__configure.serial) { if (__configure.core && !__loaded[__configure.core]) { args = ["__core"].concat(args) } var blahlist = __analyze(args).reverse(); var stack = new __stackline(blahlist); stack.start(); return stack.bag } if (typeof (args[args.length - 1]) === "function") { var callback = args.pop() } if (__configure.core && !__loaded[__configure.core]) { __parallel(["__core"], function () { __parallel(args, callback) }) } else { __parallel(args, callback) } }; var __contentLoaded = function (win, fn) { var done = false, top = true, doc = win.document, root = doc.documentElement, add = doc.addEventListener ? "addEventListener" : "attachEvent", rem = doc.addEventListener ? "removeEventListener" : "detachEvent", pre = doc.addEventListener ? "" : "on", init = function (e) { if (e.type == "readystatechange" && doc.readyState != "complete") { return } (e.type == "load" ? win : doc)[rem](pre + e.type, init, false); if (!done && (done = true)) { fn.call(win, e.type || e) } }, poll = function () { try { root.doScroll("left") } catch (e) { setTimeout(poll, 50); return } init("poll") }; if (doc.readyState == "complete") { fn.call(win, "lazy") } else { if (doc.createEventObject && root.doScroll) { try { top = !win.frameElement } catch (e) { } if (top) { poll() } } doc[add](pre + "DOMContentLoaded", init, false); doc[add](pre + "readystatechange", init, false); win[add](pre + "load", init, false) } }; void function () { var myself = (function () { var scripts = document.getElementsByTagName("script"); return scripts[scripts.length - 1] })(); var autoload = myself.getAttribute("autoload"); var core = myself.getAttribute("core"); if (core) { __configure.autoload = eval(autoload); __configure.core = core; __add("__core", { path: __configure.core }) } if (__configure.autoload && __configure.core) { __in() } } (); __in.add = __add; __in.adds = __adds; __in.config = __config; __in.css = __css; __in.later = __later; __in.load = __load; __in.ready = __ready; __in.use = __in; this.In = __in } ();

//-----------------------------------------设置------------------------------------//
//设置为串行加载模式，兼容旧的写法
//In.config('serial', true);
//设置核心库，核心库会被所有模块依赖
//In.config('core', '/js/comm.js');

In.add('jquicss', { path: SiteConfigs.UrlIISPath + 'js/plugin/ui/jquery-ui.css' });
In.add('jqui', { path: SiteConfigs.UrlIISPath + 'js/plugin/ui/jquery-ui.js', type: 'js', charset: 'utf-8', rely: ['jquicss'] }); //依赖
In.add('jqeasyloader', { path: SiteConfigs.UrlIISPath + 'js/plugin/easyui/easyloader.js', type: 'js', charset: 'utf-8' });
In.add('dialog', { path: SiteConfigs.UrlIISPath + 'js/dialog.js', type: 'js', charset: 'utf-8', rely: ['jqeasyloader'] }); //依赖
In.add('datepicker', { path: SiteConfigs.UrlIISPath + 'js/plugin/ui/datepicker/js.js', type: 'js', charset: 'utf-8' });
In.add('jqcookie', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.cookie.js', type: 'js', charset: 'utf-8' });
In.add('ebcookie', { path: SiteConfigs.UrlIISPath + 'js/cnCookie.js', type: 'js', charset: 'utf-8' });
//In.add('json2', { path: SiteConfigs.UrlIISPath+'js/json2.js', type: 'js', charset: 'utf-8' });
//让IE6~8支持CSS3伪类和属性选择器
//In.add('selectivizr', { path: SiteConfigs.UrlIISPath + 'js/selectivizr-min.js', type: 'js', charset: 'utf-8' });
//定位跳转 goto("元素ID")
In.add('jqscroll', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.scroll.js', type: 'js', charset: 'utf-8' });
//不一样的jQuery提示对话框插件Impromptu
In.add('jqimpromptu', { path: SiteConfigs.UrlIISPath + 'js/plugin/impromptu.js', type: 'js', charset: 'utf-8' });
//轻量瀑布流插件 是isotope的简化版
In.add('jqmasonry', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.masonry.min.js', type: 'js', charset: 'utf-8' });
//无刷新 无限加载 一般用来配合jqmasonry使用
In.add('infinitescroll', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.infinitescroll.js', type: 'js', charset: 'utf-8' });

//一个 jQuery 用来实现捕获各种滚动事件的插件，例如实现无翻页的内容浏览，或者固定某个元素不让滚动等等。支持主流浏览器版本
In.add('jqwaypoints', { path: SiteConfigs.UrlIISPath + 'js/plugin/waypoints.min.js', type: 'js', charset: 'utf-8' });
//颜色做动画效果插件
In.add('jqcolor', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.color.js', type: 'js', charset: 'utf-8' });

//一个很酷的弹出窗,非jq插件
In.add('tinyboxcss', { path: SiteConfigs.UrlIISPath + 'js/tinybox/style.css' });
In.add('tinybox', { path: SiteConfigs.UrlIISPath + 'js/tinybox/tinybox2.js', type: 'js', charset: 'utf-8', rely: ['tinyboxcss'] });

//非常神奇的智能布局插件,也可以实现瀑布流，是jqmasonry的完整版
In.add('jqisotope', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.isotope.js', type: 'js', charset: 'utf-8' });
//动画处理插件
In.add('jqeasing', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.easing.js', type: 'js', charset: 'utf-8' });
//在ie6下可使用png透明效果
//In.add('belatedPNG', { path: SiteConfigs.UrlIISPath + 'js/DD_belatedPNG.js', type: 'js', charset: 'utf-8' });

In.add('jquerymobile', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquerymobile/js.js', type: 'js', charset: 'utf-8' });
//jquerymobile 的样式文件
In.add('jquerymobilecss', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquerymobile/css.css' });
//easywidgets
In.add('easywidgetscss', { path: SiteConfigs.UrlIISPath + 'js/plugin/easywidgets/css.css' });
In.add('easywidgetscjs', { path: SiteConfigs.UrlIISPath + 'js/plugin/easywidgets/js.js', type: 'js', charset: 'utf-8' });
//用于创建圆角的jQuery插件
In.add('curvycorners', { path: SiteConfigs.UrlIISPath + 'js/plugin/curvycorners.js', type: 'js', charset: 'utf-8' });

//一个效果不错的弹出框(蹦出效果)
In.add('dlgzoom', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.dlgzoom.js', type: 'js', charset: 'utf-8' });

//图片异步加载效果
In.add('lazyload', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.lazyload.js', type: 'js', charset: 'utf-8' });

//一个效果不错的气泡提示
In.add('poshytipcss', { path: SiteConfigs.UrlIISPath + 'js/plugin/poshytip/tip-yellow/tip-yellow.css' });
In.add('poshytip', { path: SiteConfigs.UrlIISPath + 'js/plugin/poshytip/jquery.poshytip.min.js', type: 'js', charset: 'utf-8', rely: ['poshytipcss'] });
//消息提示插件
In.add('messager', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.messager.js', type: 'js', charset: 'utf-8' });
//一种 动态 样式 语言.LESS 将 CSS 赋予了动态语言的特性，如 变量， 继承， 运算， 函数. LESS 既可以在 客户端 上运行 (支持IE 6+, Webkit, Firefox)，也可以借助Node.js或者Rhino在服务端运行。 
In.add('less', { path: SiteConfigs.UrlIISPath + 'js/less.js', type: 'js', charset: 'utf-8' });
//jquery的验证插件
In.add('validate', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.validate.js', type: 'js', charset: 'utf-8' });
//文本框文本域提示文字的自动显示与隐藏
In.add('textauto', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.textauto.js', type: 'js', charset: 'utf-8' });
//用户注册
In.add('userreg', { path: SiteConfigs.UrlIISPath + 'js/userreg.js', type: 'js', charset: 'utf-8', rely: ['validate','textauto'] });
//用户登录
In.add('userlogin', { path: SiteConfigs.UrlIISPath + 'js/userlogin.js', type: 'js', charset: 'utf-8', rely: ['validate', 'textauto'] });
//第三方用户登录完善资料
In.add('userapireg', { path: SiteConfigs.UrlIISPath + 'js/userapireg.js', type: 'js', charset: 'utf-8', rely: ['validate', 'textauto'] });
//一个常用的tag切换效果
In.add('customtags', { path: SiteConfigs.UrlIISPath + 'js/customtags.js', type: 'js', charset: 'utf-8', rely: ['validate', 'textauto'] });
//一个模拟的下拉列表框
In.add('selectbox', { path: SiteConfigs.UrlIISPath + 'js/plugin/SelectSingle/select.js', type: 'js', charset: 'utf-8' });
//让某个元素绝对距顶
In.add('topfixed', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.topfixed.js', type: 'js', charset: 'utf-8' });
In.add('jqzoomcss', { path: SiteConfigs.UrlIISPath + 'js/plugin/jqzoom/jquery.jqzoom.css' });
In.add('jqzoom', { path: SiteConfigs.UrlIISPath + 'js/plugin/jqzoom/jqzoom.js', type: 'js', charset: 'utf-8', rely: ['jqzoomcss'] }); //依赖
//一个非常棒的jQuery 评分插件 
In.add('raty', { path: SiteConfigs.UrlIISPath + 'js/plugin/raty/jquery.raty.js', type: 'js', charset: 'utf-8' });


//类似tinybox的弹出窗，但有带关闭按钮 jquery 1.9.1 不能使用了，所以要依赖于jquery-migrate来解决老版jquery的问题
//其他插件如果有同样的问题也可以这样解决
In.add('jquery-migrate', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery-migrate-1.2.1.min.js', type: 'js', charset: 'utf-8' });
In.add('fancyboxcss', { path: SiteConfigs.UrlIISPath + 'js/plugin/fancybox/fancybox.css' });
In.add('fancybox', { path: SiteConfigs.UrlIISPath + 'js/plugin/fancybox/fancyboxpack.js', type: 'js', charset: 'utf-8', rely: ['jquery-migrate','fancyboxcss'] }); //依赖
 

In.add('xslider', { path: SiteConfigs.UrlIISPath + 'js/plugin/jquery.xslider.js', type: 'js', charset: 'utf-8' });
//In.add('upload', { path: SiteConfigs.UrlIISPath + 'js/plugin/ajaxfileupload.js', type: 'js', charset: 'utf-8' });

In.add('ebvalidate', { path: SiteConfigs.UrlIISPath + 'js/plugin/validatebox/js.js', type: 'js', charset: 'utf-8' });
In.add('vue', { path: SiteConfigs.UrlIISPath + 'js/vue.js', type: 'js', charset: 'utf-8' });
//遮罩显示插件
In.add('blockui', { path: SiteConfigs.UrlIISPath + 'js/plugin/blockui.min.js', type: 'js', charset: 'utf-8' });