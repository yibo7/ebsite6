﻿/*!
* jQuery Mobile v1.0rc1
* http://jquerymobile.com/
*
* Copyright 2010, jQuery Project
* Dual licensed under the MIT or GPL Version 2 licenses.
* http://jquery.org/license
*/
(function (a, d) {
    if (a.cleanData) { var c = a.cleanData; a.cleanData = function (b) { for (var e = 0, d; (d = b[e]) != null; e++) a(d).triggerHandler("remove"); c(b) } } else { var b = a.fn.remove; a.fn.remove = function (c, e) { return this.each(function () { e || (!c || a.filter(c, [this]).length) && a("*", this).add([this]).each(function () { a(this).triggerHandler("remove") }); return b.call(a(this), c, e) }) } } a.widget = function (b, c, d) {
        var h = b.split(".")[0], j, b = b.split(".")[1]; j = h + "-" + b; if (!d) d = c, c = a.Widget; a.expr[":"][j] = function (c) {
            return !!a.data(c,
b)
        }; a[h] = a[h] || {}; a[h][b] = function (a, b) { arguments.length && this._createWidget(a, b) }; c = new c; c.options = a.extend(!0, {}, c.options); a[h][b].prototype = a.extend(!0, c, { namespace: h, widgetName: b, widgetEventPrefix: a[h][b].prototype.widgetEventPrefix || b, widgetBaseClass: j }, d); a.widget.bridge(b, a[h][b])
    }; a.widget.bridge = function (b, c) {
        a.fn[b] = function (g) {
            var h = typeof g === "string", j = Array.prototype.slice.call(arguments, 1), k = this, g = !h && j.length ? a.extend.apply(null, [!0, g].concat(j)) : g; if (h && g.charAt(0) === "_") return k;
            h ? this.each(function () { var c = a.data(this, b); if (!c) throw "cannot call methods on " + b + " prior to initialization; attempted to call method '" + g + "'"; if (!a.isFunction(c[g])) throw "no such method '" + g + "' for " + b + " widget instance"; var e = c[g].apply(c, j); if (e !== c && e !== d) return k = e, !1 }) : this.each(function () { var d = a.data(this, b); d ? d.option(g || {})._init() : a.data(this, b, new c(g, this)) }); return k
        }
    }; a.Widget = function (a, b) { arguments.length && this._createWidget(a, b) }; a.Widget.prototype = { widgetName: "widget", widgetEventPrefix: "",
        options: { disabled: !1 }, _createWidget: function (b, c) { a.data(c, this.widgetName, this); this.element = a(c); this.options = a.extend(!0, {}, this.options, this._getCreateOptions(), b); var d = this; this.element.bind("remove." + this.widgetName, function () { d.destroy() }); this._create(); this._trigger("create"); this._init() }, _getCreateOptions: function () { var b = {}; a.metadata && (b = a.metadata.get(element)[this.widgetName]); return b }, _create: function () { }, _init: function () { }, destroy: function () {
            this.element.unbind("." + this.widgetName).removeData(this.widgetName);
            this.widget().unbind("." + this.widgetName).removeAttr("aria-disabled").removeClass(this.widgetBaseClass + "-disabled ui-state-disabled")
        }, widget: function () { return this.element }, option: function (b, c) { var g = b; if (arguments.length === 0) return a.extend({}, this.options); if (typeof b === "string") { if (c === d) return this.options[b]; g = {}; g[b] = c } this._setOptions(g); return this }, _setOptions: function (b) { var c = this; a.each(b, function (a, b) { c._setOption(a, b) }); return this }, _setOption: function (a, b) {
            this.options[a] = b; a === "disabled" &&
this.widget()[b ? "addClass" : "removeClass"](this.widgetBaseClass + "-disabled ui-state-disabled").attr("aria-disabled", b); return this
        }, enable: function () { return this._setOption("disabled", !1) }, disable: function () { return this._setOption("disabled", !0) }, _trigger: function (b, c, d) {
            var h = this.options[b], c = a.Event(c); c.type = (b === this.widgetEventPrefix ? b : this.widgetEventPrefix + b).toLowerCase(); d = d || {}; if (c.originalEvent) for (var b = a.event.props.length, j; b; ) j = a.event.props[--b], c[j] = c.originalEvent[j]; this.element.trigger(c,
d); return !(a.isFunction(h) && h.call(this.element[0], c, d) === !1 || c.isDefaultPrevented())
        }
    }
})(jQuery); (function (a, d) { a.widget("mobile.widget", { _createWidget: function () { a.Widget.prototype._createWidget.apply(this, arguments); this._trigger("init") }, _getCreateOptions: function () { var c = this.element, b = {}; a.each(this.options, function (a) { var e = c.jqmData(a.replace(/[A-Z]/g, function (a) { return "-" + a.toLowerCase() })); e !== d && (b[a] = e) }); return b } }) })(jQuery);
(function (a) { a(window); var d = a("html"); a.mobile.media = function () { var c = {}, b = a("<div id='jquery-mediatest'>"), f = a("<body>").append(b); return function (a) { if (!(a in c)) { var g = document.createElement("style"), h = "@media " + a + " { #jquery-mediatest { position:absolute; } }"; g.type = "text/css"; g.styleSheet ? g.styleSheet.cssText = h : g.appendChild(document.createTextNode(h)); d.prepend(f).prepend(g); c[a] = b.css("position") === "absolute"; f.add(g).remove() } return c[a] } } () })(jQuery);
(function (a, d) {
    function c(a) { var b = a.charAt(0).toUpperCase() + a.substr(1), a = (a + " " + e.join(b + " ") + b).split(" "), c; for (c in a) if (f[a[c]] !== d) return !0 } var b = a("<body>").prependTo("html"), f = b[0].style, e = ["Webkit", "Moz", "O"], g = "palmGetResource" in window, h = window.blackberry; a.mobile.browser = {}; a.mobile.browser.ie = function () { for (var a = 3, b = document.createElement("div"), c = b.all || []; b.innerHTML = "<\!--[if gt IE " + ++a + "]><br><![endif]--\>", c[0]; ); return a > 4 ? a : !a } (); a.extend(a.support, { orientation: "orientation" in
window, touch: "ontouchend" in document, cssTransitions: "WebKitTransitionEvent" in window, pushState: "pushState" in history && "replaceState" in history, mediaquery: a.mobile.media("only all"), cssPseudoElement: !!c("content"), touchOverflow: !!c("overflowScrolling"), boxShadow: !!c("boxShadow") && !h, scrollTop: ("pageXOffset" in window || "scrollTop" in document.documentElement || "scrollTop" in b[0]) && !g, dynamicBaseTag: function () {
    var c = location.protocol + "//" + location.host + location.pathname + "ui-dir/", f = a("head base"), e = null,
d = "", g; f.length ? d = f.attr("href") : f = e = a("<base>", { href: c }).appendTo("head"); g = a("<a href='testurl'></a>").prependTo(b)[0].href; f[0].href = d ? d : location.pathname; e && e.remove(); return g.indexOf(c) === 0
} ()
    }); b.remove(); g = function () { var a = window.navigator.userAgent; return a.indexOf("Nokia") > -1 && (a.indexOf("Symbian/3") > -1 || a.indexOf("Series60/5") > -1) && a.indexOf("AppleWebKit") > -1 && a.match(/(BrowserNG|NokiaBrowser)\/7\.[0-3]/) } (); a.mobile.ajaxBlacklist = window.blackberry && !window.WebKitPoint || window.operamini &&
Object.prototype.toString.call(window.operamini) === "[object OperaMini]" || g; g && a(function () { a("head link[rel=stylesheet]").attr("rel", "alternate stylesheet").attr("rel", "stylesheet") }); a.support.boxShadow || a("html").addClass("ui-mobile-nosupport-boxshadow")
})(jQuery);
(function (a, d, c, b) {
    function f(a) { for (; a && typeof a.originalEvent !== "undefined"; ) a = a.originalEvent; return a } function e(b) { for (var c = {}, f, u; b; ) { f = a.data(b, l); for (u in f) if (f[u]) c[u] = c.hasVirtualBinding = !0; b = b.parentNode } return c } function g() { s && (clearTimeout(s), s = 0); s = setTimeout(function () { D = s = 0; w.length = 0; C = !1; A = !0 }, a.vmouse.resetTimerDuration) } function h(c, u, e) {
        var d, g; if (!(g = e && e[c])) { if (e = !e)a: { for (e = u.target; e; ) { if ((g = a.data(e, l)) && (!c || g[c])) break a; e = e.parentNode } e = null } g = e } if (g) {
            d = u; var e = d.type,
i, h; d = a.Event(d); d.type = c; g = d.originalEvent; i = a.event.props; if (g) for (h = i.length; h; ) c = i[--h], d[c] = g[c]; if (e.search(/mouse(down|up)|click/) > -1 && !d.which) d.which = 1; if (e.search(/^touch/) !== -1 && (c = f(g), e = c.touches, c = c.changedTouches, e = e && e.length ? e[0] : c && c.length ? c[0] : b)) { g = 0; for (len = y.length; g < len; g++) c = y[g], d[c] = e[c] } a(u.target).trigger(d)
        } return d
    } function j(b) {
        var c = a.data(b.target, B); if (!C && (!D || D !== c)) if (c = h("v" + b.type, b)) c.isDefaultPrevented() && b.preventDefault(), c.isPropagationStopped() && b.stopPropagation(),
c.isImmediatePropagationStopped() && b.stopImmediatePropagation()
    } function k(b) { var c = f(b).touches, d; if (c && c.length === 1 && (d = b.target, c = e(d), c.hasVirtualBinding)) D = u++, a.data(d, B, D), s && (clearTimeout(s), s = 0), v = A = !1, d = f(b).touches[0], x = d.pageX, t = d.pageY, h("vmouseover", b, c), h("vmousedown", b, c) } function n(a) { A || (v || h("vmousecancel", a, e(a.target)), v = !0, g()) } function q(b) {
        if (!A) {
            var c = f(b).touches[0], d = v, u = a.vmouse.moveDistanceThreshold; v = v || Math.abs(c.pageX - x) > u || Math.abs(c.pageY - t) > u; flags = e(b.target); v &&
!d && h("vmousecancel", b, flags); h("vmousemove", b, flags); g()
        }
    } function p(a) { if (!A) { A = !0; var b = e(a.target), c; h("vmouseup", a, b); if (!v && (c = h("vclick", a, b)) && c.isDefaultPrevented()) c = f(a).changedTouches[0], w.push({ touchID: D, x: c.clientX, y: c.clientY }), C = !0; h("vmouseout", a, b); v = !1; g() } } function m(b) { var b = a.data(b, l), c; if (b) for (c in b) if (b[c]) return !0; return !1 } function i() { } function o(b) {
        var c = b.substr(1); return { setup: function () {
            m(this) || a.data(this, l, {}); a.data(this, l)[b] = !0; r[b] = (r[b] || 0) + 1; r[b] === 1 && z.bind(c,
j); a(this).bind(c, i); if (E) r.touchstart = (r.touchstart || 0) + 1, r.touchstart === 1 && z.bind("touchstart", k).bind("touchend", p).bind("touchmove", q).bind("scroll", n)
        }, teardown: function () { --r[b]; r[b] || z.unbind(c, j); E && (--r.touchstart, r.touchstart || z.unbind("touchstart", k).unbind("touchmove", q).unbind("touchend", p).unbind("scroll", n)); var f = a(this), d = a.data(this, l); d && (d[b] = !1); f.unbind(c, i); m(this) || f.removeData(l) }
        }
    } var l = "virtualMouseBindings", B = "virtualTouchID", d = "vmouseover vmousedown vmousemove vmouseup vclick vmouseout vmousecancel".split(" "),
y = "clientX clientY pageX pageY screenX screenY".split(" "), r = {}, s = 0, x = 0, t = 0, v = !1, w = [], C = !1, A = !1, E = "addEventListener" in c, z = a(c), u = 1, D = 0; a.vmouse = { moveDistanceThreshold: 10, clickDistanceThreshold: 10, resetTimerDuration: 1500 }; for (var F = 0; F < d.length; F++) a.event.special[d[F]] = o(d[F]); E && c.addEventListener("click", function (b) {
    var c = w.length, f = b.target, d, e, u, g, i; if (c) {
        d = b.clientX; e = b.clientY; threshold = a.vmouse.clickDistanceThreshold; for (u = f; u; ) {
            for (g = 0; g < c; g++) if (i = w[g], u === f && Math.abs(i.x - d) < threshold &&
Math.abs(i.y - e) < threshold || a.data(u, B) === i.touchID) { b.preventDefault(); b.stopPropagation(); return } u = u.parentNode
        }
    }
}, !0)
})(jQuery, window, document);
(function (a, d, c) {
    function b(b, c, f) { var d = f.type; f.type = c; a.event.handle.call(b, f); f.type = d } a.each("touchstart touchmove touchend orientationchange throttledresize tap taphold swipe swipeleft swiperight scrollstart scrollstop".split(" "), function (b, c) { a.fn[c] = function (a) { return a ? this.bind(c, a) : this.trigger(c) }; a.attrFn[c] = !0 }); var f = a.support.touch, e = f ? "touchstart" : "mousedown", g = f ? "touchend" : "mouseup", h = f ? "touchmove" : "mousemove"; a.event.special.scrollstart = { enabled: !0, setup: function () {
        function c(a,
e) { d = e; b(f, d ? "scrollstart" : "scrollstop", a) } var f = this, d, e; a(f).bind("touchmove scroll", function (b) { a.event.special.scrollstart.enabled && (d || c(b, !0), clearTimeout(e), e = setTimeout(function () { c(b, !1) }, 50)) })
    }
    }; a.event.special.tap = { setup: function () {
        var c = this, f = a(c); f.bind("vmousedown", function (d) {
            function e() { clearTimeout(o) } function g() { e(); f.unbind("vclick", h).unbind("vmouseup", e).unbind("vmousecancel", g) } function h(a) { g(); i == a.target && b(c, "tap", a) } if (d.which && d.which !== 1) return !1; var i = d.target, o;
            f.bind("vmousecancel", g).bind("vmouseup", e).bind("vclick", h); o = setTimeout(function () { b(c, "taphold", a.Event("taphold")) }, 750)
        })
    }
    }; a.event.special.swipe = { scrollSupressionThreshold: 10, durationThreshold: 1E3, horizontalDistanceThreshold: 30, verticalDistanceThreshold: 75, setup: function () {
        var b = a(this); b.bind(e, function (f) {
            function d(b) {
                if (p) {
                    var c = b.originalEvent.touches ? b.originalEvent.touches[0] : b; m = { time: (new Date).getTime(), coords: [c.pageX, c.pageY] }; Math.abs(p.coords[0] - m.coords[0]) > a.event.special.swipe.scrollSupressionThreshold &&
b.preventDefault()
                }
            } var e = f.originalEvent.touches ? f.originalEvent.touches[0] : f, p = { time: (new Date).getTime(), coords: [e.pageX, e.pageY], origin: a(f.target) }, m; b.bind(h, d).one(g, function () {
                b.unbind(h, d); p && m && m.time - p.time < a.event.special.swipe.durationThreshold && Math.abs(p.coords[0] - m.coords[0]) > a.event.special.swipe.horizontalDistanceThreshold && Math.abs(p.coords[1] - m.coords[1]) < a.event.special.swipe.verticalDistanceThreshold && p.origin.trigger("swipe").trigger(p.coords[0] > m.coords[0] ? "swipeleft" : "swiperight");
                p = m = c
            })
        })
    }
    }; (function (a, b) {
        function c() { var a = d(); a !== e && (e = a, f.trigger("orientationchange")) } var f = a(b), d, e; a.event.special.orientationchange = { setup: function () { if (a.support.orientation) return !1; e = d(); f.bind("throttledresize", c) }, teardown: function () { if (a.support.orientation) return !1; f.unbind("throttledresize", c) }, add: function (a) { var b = a.handler; a.handler = function (a) { a.orientation = d(); return b.apply(this, arguments) } } }; a.event.special.orientationchange.orientation = d = function () {
            var a = document.documentElement;
            return a && a.clientWidth / a.clientHeight < 1.1 ? "portrait" : "landscape"
        }
    })(jQuery, d); (function () { a.event.special.throttledresize = { setup: function () { a(this).bind("resize", b) }, teardown: function () { a(this).unbind("resize", b) } }; var b = function () { d = (new Date).getTime(); e = d - c; e >= 250 ? (c = d, a(this).trigger("throttledresize")) : (f && clearTimeout(f), f = setTimeout(b, 250 - e)) }, c = 0, f, d, e })(); a.each({ scrollstop: "scrollstart", taphold: "tap", swipeleft: "swipe", swiperight: "swipe" }, function (b, c) {
        a.event.special[b] = { setup: function () {
            a(this).bind(c,
a.noop)
        }
        }
    })
})(jQuery, this);
(function (a, d, c) {
    function b(a) { a = a || location.href; return "#" + a.replace(/^[^#]*#?(.*)$/, "$1") } var f = "hashchange", e = document, g, h = a.event.special, j = e.documentMode, k = "on" + f in d && (j === c || j > 7); a.fn[f] = function (a) { return a ? this.bind(f, a) : this.trigger(f) }; a.fn[f].delay = 50; h[f] = a.extend(h[f], { setup: function () { if (k) return !1; a(g.start) }, teardown: function () { if (k) return !1; a(g.stop) } }); g = function () {
        function g() {
            var c = b(), e = l(m); if (c !== m) o(m = c, e), a(d).trigger(f); else if (e !== m) location.href = location.href.replace(/#.*/,
"") + e; j = setTimeout(g, a.fn[f].delay)
        } var h = {}, j, m = b(), i = function (a) { return a }, o = i, l = i; h.start = function () { j || g() }; h.stop = function () { j && clearTimeout(j); j = c }; a.browser.msie && !k && function () {
            var c, d; h.start = function () { if (!c) d = (d = a.fn[f].src) && d + b(), c = a('<iframe tabindex="-1" title="empty"/>').hide().one("load", function () { d || o(b()); g() }).attr("src", d || "javascript:0").insertAfter("body")[0].contentWindow, e.onpropertychange = function () { try { if (event.propertyName === "title") c.document.title = e.title } catch (a) { } } };
            h.stop = i; l = function () { return b(c.location.href) }; o = function (b, d) { var g = c.document, h = a.fn[f].domain; if (b !== d) g.title = e.title, g.open(), h && g.write('<script>document.domain="' + h + '"<\/script>'), g.close(), c.location.hash = b }
        } (); return h
    } ()
})(jQuery, this); (function (a) { a.widget("mobile.page", a.mobile.widget, { options: { theme: "c", domCache: !1 }, _create: function () { this._trigger("beforecreate"); this.element.attr("tabindex", "0").addClass("ui-page ui-body-" + this.options.theme) } }) })(jQuery);
(function (a, d) {
    a.extend(a.mobile, { ns: "", subPageUrlKey: "ui-page", activePageClass: "ui-page-active", activeBtnClass: "ui-btn-active", ajaxEnabled: !0, hashListeningEnabled: !0, defaultPageTransition: "slide", minScrollBack: 250, defaultDialogTransition: "pop", loadingMessage: "loading", pageLoadErrorMessage: "Error Loading Page", autoInitializePage: !0, pushStateEnabled: !0, gradeA: function () { return a.support.mediaquery || a.mobile.browser.ie && a.mobile.browser.ie >= 7 }, keyCode: { ALT: 18, BACKSPACE: 8, CAPS_LOCK: 20, COMMA: 188, COMMAND: 91,
        COMMAND_LEFT: 91, COMMAND_RIGHT: 93, CONTROL: 17, DELETE: 46, DOWN: 40, END: 35, ENTER: 13, ESCAPE: 27, HOME: 36, INSERT: 45, LEFT: 37, MENU: 93, NUMPAD_ADD: 107, NUMPAD_DECIMAL: 110, NUMPAD_DIVIDE: 111, NUMPAD_ENTER: 108, NUMPAD_MULTIPLY: 106, NUMPAD_SUBTRACT: 109, PAGE_DOWN: 34, PAGE_UP: 33, PERIOD: 190, RIGHT: 39, SHIFT: 16, SPACE: 32, TAB: 9, UP: 38, WINDOWS: 91
    }, silentScroll: function (b) {
        if (a.type(b) !== "number") b = a.mobile.defaultHomeScroll; a.event.special.scrollstart.enabled = !1; setTimeout(function () {
            d.scrollTo(0, b); a(document).trigger("silentscroll",
{ x: 0, y: b })
        }, 20); setTimeout(function () { a.event.special.scrollstart.enabled = !0 }, 150)
    }, nsNormalize: function (b) { if (b) return a.camelCase(a.mobile.ns + b) }
    }); a.fn.jqmData = function (b, c) { var d; typeof b != "undefined" && (d = this.data(b ? a.mobile.nsNormalize(b) : b, c)); return d }; a.jqmData = function (b, c, d) { var g; typeof c != "undefined" && (g = a.data(b, c ? a.mobile.nsNormalize(c) : c, d)); return g }; a.fn.jqmRemoveData = function (b) { return this.removeData(a.mobile.nsNormalize(b)) }; a.jqmRemoveData = function (b, c) {
        return a.removeData(b,
a.mobile.nsNormalize(c))
    }; a.fn.removeWithDependents = function () { a.removeWithDependents(this) }; a.removeWithDependents = function (b) { b = a(b); (b.jqmData("dependents") || a()).remove(); b.remove() }; a.fn.addDependents = function (b) { a.addDependents(a(this), b) }; a.addDependents = function (b, c) { var d = a(b).jqmData("dependents") || a(); a(b).jqmData("dependents", a.merge(d, c)) }; a.fn.getEncodedText = function () { return a("<div/>").text(a(this).text()).html() }; var c = a.find; a.find = function (b, d, e, g) {
        b = b.replace(/:jqmData\(([^)]*)\)/g,
"[data-" + (a.mobile.ns || "") + "$1]"); return c.call(this, b, d, e, g)
    }; a.extend(a.find, c); a.find.matches = function (b, c) { return a.find(b, null, null, c) }; a.find.matchesSelector = function (b, c) { return a.find(c, null, null, [b]).length > 0 }
})(jQuery, this);
(function (a, d) {
    function c(a) { var c = a.find(".ui-title:eq(0)"); c.length ? c.focus() : a.focus() } function b(c) { o && (!o.closest(".ui-page-active").length || c) && o.removeClass(a.mobile.activeBtnClass); o = null } function f() { y = !1; B.length > 0 && a.mobile.changePage.apply(null, B.pop()) } function e(b, d, e, f) {
        var h = a.mobile.urlHistory.getActive(), i = a.support.touchOverflow && a.mobile.touchOverflowEnabled, j = h.lastScroll || (i ? 0 : a.mobile.defaultHomeScroll), h = g(); window.scrollTo(0, a.mobile.defaultHomeScroll); d && d.data("page")._trigger("beforehide",
null, { nextPage: b }); i || b.height(h + j); b.data("page")._trigger("beforeshow", null, { prevPage: d || a("") }); a.mobile.hidePageLoadingMsg(); i && j && (b.addClass("ui-mobile-pre-transition"), c(b), b.is(".ui-native-fixed") ? b.find(".ui-content").scrollTop(j) : b.scrollTop(j)); e = (a.mobile.transitionHandlers[e || "none"] || a.mobile.defaultTransitionHandler)(e, f, b, d); e.done(function () {
    i || (b.height(""), c(b)); i || a.mobile.silentScroll(j); d && (i || d.height(""), d.data("page")._trigger("hide", null, { nextPage: b })); b.data("page")._trigger("show",
null, { prevPage: d || a("") })
}); return e
    } function g() { var b = jQuery.event.special.orientationchange.orientation() === "portrait", c = b ? screen.availHeight : screen.availWidth, b = Math.max(b ? 480 : 320, a(window).height()); return Math.min(c, b) } function h() { (!a.support.touchOverflow || !a.mobile.touchOverflowEnabled) && a("." + a.mobile.activePageClass).css("min-height", g()) } function j(b, c) { c && b.attr("data-" + a.mobile.ns + "role", c); b.page() } function k(a) { for (; a; ) { if (a.nodeName.toLowerCase() == "a") break; a = a.parentNode } return a }
    function n(b) { var b = a(b).closest(".ui-page").jqmData("url"), c = t.hrefNoHash; if (!b || !i.isPath(b)) b = c; return i.makeUrlAbsolute(b, c) } var q = a(window), p = a("html"), m = a("head"), i = { urlParseRE: /^(((([^:\/#\?]+:)?(?:(\/\/)((?:(([^:@\/#\?]+)(?:\:([^:@\/#\?]+))?)@)?(([^:\/#\?\]\[]+|\[[^\/\]@#?]+\])(?:\:([0-9]+))?))?)?)?((\/?(?:[^\/\?#]+\/+)*)([^\?#]*)))?(\?[^#]+)?)(#.*)?/, parseUrl: function (b) {
        if (a.type(b) === "object") return b; b = i.urlParseRE.exec(b || "") || []; return { href: b[0] || "", hrefNoHash: b[1] || "", hrefNoSearch: b[2] ||
"", domain: b[3] || "", protocol: b[4] || "", doubleSlash: b[5] || "", authority: b[6] || "", username: b[8] || "", password: b[9] || "", host: b[10] || "", hostname: b[11] || "", port: b[12] || "", pathname: b[13] || "", directory: b[14] || "", filename: b[15] || "", search: b[16] || "", hash: b[17] || ""
        }
    }, makePathAbsolute: function (a, b) {
        if (a && a.charAt(0) === "/") return a; for (var a = a || "", c = (b = b ? b.replace(/^\/|(\/[^\/]*|[^\/]+)$/g, "") : "") ? b.split("/") : [], d = a.split("/"), e = 0; e < d.length; e++) {
            var f = d[e]; switch (f) {
                case ".": break; case "..": c.length && c.pop(); break;
                default: c.push(f)
            }
        } return "/" + c.join("/")
    }, isSameDomain: function (a, b) { return i.parseUrl(a).domain === i.parseUrl(b).domain }, isRelativeUrl: function (a) { return i.parseUrl(a).protocol === "" }, isAbsoluteUrl: function (a) { return i.parseUrl(a).protocol !== "" }, makeUrlAbsolute: function (a, b) {
        if (!i.isRelativeUrl(a)) return a; var c = i.parseUrl(a), d = i.parseUrl(b), e = c.protocol || d.protocol, f = c.protocol ? c.doubleSlash : c.doubleSlash || d.doubleSlash; authority = c.authority || d.authority; hasPath = c.pathname !== ""; pathname = i.makePathAbsolute(c.pathname ||
d.filename, d.pathname); search = c.search || !hasPath && d.search || ""; hash = c.hash; return e + f + authority + pathname + search + hash
    }, addSearchParams: function (b, c) { var d = i.parseUrl(b), e = typeof c === "object" ? a.param(c) : c, f = d.search || "?"; return d.hrefNoSearch + f + (f.charAt(f.length - 1) !== "?" ? "&" : "") + e + (d.hash || "") }, convertUrlToDataUrl: function (a) { var b = i.parseUrl(a); if (i.isEmbeddedPage(b)) return b.hash.split(r)[0].replace(/^#/, ""); else if (i.isSameDomain(b, t)) return b.hrefNoHash.replace(t.domain, ""); return a }, get: function (a) {
        if (a ===
d) a = location.hash; return i.stripHash(a).replace(/[^\/]*\.[^\/*]+$/, "")
    }, getFilePath: function (b) { var c = "&" + a.mobile.subPageUrlKey; return b && b.split(c)[0].split(r)[0] }, set: function (a) { location.hash = a }, isPath: function (a) { return /\//.test(a) }, clean: function (a) { return a.replace(t.domain, "") }, stripHash: function (a) { return a.replace(/^#/, "") }, cleanHash: function (a) { return i.stripHash(a.replace(/\?.*$/, "").replace(r, "")) }, isExternal: function (a) { a = i.parseUrl(a); return a.protocol && a.domain !== x.domain ? !0 : !1 }, hasProtocol: function (a) { return /^(:?\w+:)/.test(a) },
        isFirstPageUrl: function (b) { var b = i.parseUrl(i.makeUrlAbsolute(b, t)), c = a.mobile.firstPage, c = c && c[0] ? c[0].id : d; return (b.hrefNoHash === x.hrefNoHash || v && b.hrefNoHash === t.hrefNoHash) && (!b.hash || b.hash === "#" || c && b.hash.replace(/^#/, "") === c) }, isEmbeddedPage: function (a) { a = i.parseUrl(a); if (a.protocol !== "") return a.hash && (a.hrefNoHash === x.hrefNoHash || v && a.hrefNoHash === t.hrefNoHash); return /^#/.test(a.href) }
    }, o = null, l = { stack: [], activeIndex: 0, getActive: function () { return l.stack[l.activeIndex] }, getPrev: function () {
        return l.stack[l.activeIndex -
1]
    }, getNext: function () { return l.stack[l.activeIndex + 1] }, addNew: function (a, b, c, d, e) { l.getNext() && l.clearForward(); l.stack.push({ url: a, transition: b, title: c, pageUrl: d, role: e }); l.activeIndex = l.stack.length - 1 }, clearForward: function () { l.stack = l.stack.slice(0, l.activeIndex + 1) }, directHashChange: function (b) { var c, e, f; this.getActive(); a.each(l.stack, function (a, d) { b.currentUrl === d.url && (c = a < l.activeIndex, e = !c, f = a) }); this.activeIndex = f !== d ? f : this.activeIndex; c ? (b.either || b.isBack)(!0) : e && (b.either || b.isForward)(!1) },
        ignoreNextHashChange: !1
    }, B = [], y = !1, r = "&ui-state=dialog", s = m.children("base"), x = i.parseUrl(location.href), t = s.length ? i.parseUrl(i.makeUrlAbsolute(s.attr("href"), x.href)) : x, v = x.hrefNoHash !== t.hrefNoHash, w = a.support.dynamicBaseTag ? { element: s.length ? s : a("<base>", { href: t.hrefNoHash }).prependTo(m), set: function (a) { w.element.attr("href", i.makeUrlAbsolute(a, t)) }, reset: function () { w.element.attr("href", t.hrefNoHash) } } : d, C = !0, A, E, z; A = function () {
        var b = q; a.support.touchOverflow && a.mobile.touchOverflowEnabled &&
(b = a(".ui-page-active"), b = b.is(".ui-native-fixed") ? b.find(".ui-content") : b); return b
    }; E = function (b) { if (C) { var c = a.mobile.urlHistory.getActive(); if (c) b = b && b.scrollTop(), c.lastScroll = b < a.mobile.minScrollBack ? a.mobile.defaultHomeScroll : b } }; z = function () { setTimeout(E, 100, a(this)) }; q.bind(a.support.pushState ? "popstate" : "hashchange", function () { C = !1 }); q.one(a.support.pushState ? "popstate" : "hashchange", function () { C = !0 }); q.one("pagecontainercreate", function () {
        a.mobile.pageContainer.bind("pagechange", function () {
            var a =
A(); C = !0; a.unbind("scrollstop", z); a.bind("scrollstop", z)
        })
    }); A().bind("scrollstop", z); a.mobile.getScreenHeight = g; a.fn.animationComplete = function (b) { return a.support.cssTransitions ? a(this).one("webkitAnimationEnd", b) : (setTimeout(b, 0), a(this)) }; a.mobile.path = i; a.mobile.base = w; a.mobile.urlHistory = l; a.mobile.dialogHashKey = r; a.mobile.noneTransitionHandler = function (b, c, d, e) { e && e.removeClass(a.mobile.activePageClass); d.addClass(a.mobile.activePageClass); return a.Deferred().resolve(b, c, d, e).promise() }; a.mobile.defaultTransitionHandler =
a.mobile.noneTransitionHandler; a.mobile.transitionHandlers = { none: a.mobile.defaultTransitionHandler }; a.mobile.allowCrossDomainPages = !1; a.mobile.getDocumentUrl = function (b) { return b ? a.extend({}, x) : x.href }; a.mobile.getDocumentBase = function (b) { return b ? a.extend({}, t) : t.href }; a.mobile._bindPageRemove = function () {
    var b = a(this); !b.data("page").options.domCache && b.is(":jqmData(external-page='true')") && b.bind("pagehide.remove", function () {
        var b = a(this), c = new a.Event("pageremove"); b.trigger(c); c.isDefaultPrevented() ||
b.removeWithDependents()
    })
}; a.mobile.loadPage = function (b, c) {
    var e = a.Deferred(), f = a.extend({}, a.mobile.loadPage.defaults, c), g = null, h = null, r = i.makeUrlAbsolute(b, a.mobile.activePage && n(a.mobile.activePage) || t.hrefNoHash); if (f.data && f.type === "get") r = i.addSearchParams(r, f.data), f.data = d; if (f.data && f.type === "post") f.reloadPage = !0; var m = i.getFilePath(r), l = i.convertUrlToDataUrl(r); f.pageContainer = f.pageContainer || a.mobile.pageContainer; g = f.pageContainer.children(":jqmData(url='" + l + "')"); g.length === 0 && !i.isPath(l) &&
(g = f.pageContainer.children("#" + l).attr("data-" + a.mobile.ns + "url", l)); g.length === 0 && a.mobile.firstPage && i.isFirstPageUrl(r) && (g = a(a.mobile.firstPage)); w && w.reset(); if (g.length) { if (!f.reloadPage) return j(g, f.role), e.resolve(r, c, g), e.promise(); h = g } var p = f.pageContainer, k = new a.Event("pagebeforeload"), o = { url: b, absUrl: r, dataUrl: l, deferred: e, options: f }; p.trigger(k, o); if (k.isDefaultPrevented()) return e.promise(); if (f.showLoadMsg) var s = setTimeout(function () { a.mobile.showPageLoadingMsg() }, f.loadMsgDelay);
    !a.mobile.allowCrossDomainPages && !i.isSameDomain(x, r) ? e.reject(r, c) : a.ajax({ url: m, type: f.type, data: f.data, dataType: "html", success: function (d) {
        var p = a("<div></div>"), k = d.match(/<title[^>]*>([^<]*)/) && RegExp.$1, t = RegExp("\\bdata-" + a.mobile.ns + "url=[\"']?([^\"'>]*)[\"']?"); RegExp("(<[^>]+\\bdata-" + a.mobile.ns + "role=[\"']?page[\"']?[^>]*>)").test(d) && RegExp.$1 && t.test(RegExp.$1) && RegExp.$1 && (b = m = i.getFilePath(RegExp.$1)); w && w.set(m); p.get(0).innerHTML = d; g = p.find(":jqmData(role='page'), :jqmData(role='dialog')").first();
        g.length || (g = a("<div data-" + a.mobile.ns + "role='page'>" + d.split(/<\/?body[^>]*>/gmi)[1] + "</div>")); k && !g.jqmData("title") && g.jqmData("title", k); if (!a.support.dynamicBaseTag) { var n = i.get(m); g.find("[src], link[href], a[rel='external'], :jqmData(ajax='false'), a[target]").each(function () { var b = a(this).is("[href]") ? "href" : a(this).is("[src]") ? "src" : "action", c = a(this).attr(b), c = c.replace(location.protocol + "//" + location.host + location.pathname, ""); /^(\w+:|#|\/)/.test(c) || a(this).attr(b, n + c) }) } g.attr("data-" +
a.mobile.ns + "url", i.convertUrlToDataUrl(m)).attr("data-" + a.mobile.ns + "external-page", !0).appendTo(f.pageContainer); g.one("pagecreate", a.mobile._bindPageRemove); j(g, f.role); r.indexOf("&" + a.mobile.subPageUrlKey) > -1 && (g = f.pageContainer.children(":jqmData(url='" + l + "')")); f.showLoadMsg && (clearTimeout(s), a.mobile.hidePageLoadingMsg()); o.page = g; f.pageContainer.trigger("pageload", o); e.resolve(r, c, g, h)
    }, error: function () {
        w && w.set(i.get()); var b = new a.Event("pageloadfailed"); f.pageContainer.trigger(b, o); b.isDefaultPrevented() ||
(f.showLoadMsg && (clearTimeout(s), a.mobile.hidePageLoadingMsg(), a("<div class='ui-loader ui-overlay-shadow ui-body-e ui-corner-all'><h1>" + a.mobile.pageLoadErrorMessage + "</h1></div>").css({ display: "block", opacity: 0.96, top: q.scrollTop() + 100 }).appendTo(f.pageContainer).delay(800).fadeOut(400, function () { a(this).remove() })), e.reject(r, c))
    }
    }); return e.promise()
}; a.mobile.loadPage.defaults = { type: "get", data: d, reloadPage: !1, role: d, showLoadMsg: !1, pageContainer: d, loadMsgDelay: 50 }; a.mobile.changePage = function (c,
g) {
    if (y) B.unshift(arguments); else {
        var h = a.extend({}, a.mobile.changePage.defaults, g); h.pageContainer = h.pageContainer || a.mobile.pageContainer; h.fromPage = h.fromPage || a.mobile.activePage; var m = h.pageContainer, k = new a.Event("pagebeforechange"), o = { toPage: c, options: h }; m.trigger(k, o); if (!k.isDefaultPrevented()) if (c = o.toPage, y = !0, typeof c == "string") a.mobile.loadPage(c, h).done(function (b, c, d, f) { y = !1; c.duplicateCachedPage = f; a.mobile.changePage(d, c) }).fail(function () {
            y = !1; b(!0); f(); h.pageContainer.trigger("pagechangefailed",
o)
        }); else {
            var k = h.fromPage, s = h.dataUrl && i.convertUrlToDataUrl(h.dataUrl) || c.jqmData("url"), t = s; i.getFilePath(s); var n = l.getActive(), x = l.activeIndex === 0, v = 0, q = document.title, w = h.role === "dialog" || c.jqmData("role") === "dialog"; if (k && k[0] === c[0] && !h.allowSamePageTransition) y = !1, m.trigger("pagechange", o); else {
                j(c, h.role); h.fromHashChange && l.directHashChange({ currentUrl: s, isBack: function () { v = -1 }, isForward: function () { v = 1 } }); try { a(document.activeElement || "").add("input:focus, textarea:focus, select:focus").blur() } catch (A) { } w &&
n && (s = (n.url || "") + r); if (h.changeHash !== !1 && s) l.ignoreNextHashChange = !0, i.set(s); var z = c.jqmData("title") || c.children(":jqmData(role='header')").find(".ui-title").text(); z && q == document.title && (q = z); v || l.addNew(s, h.transition, q, t, h.role); document.title = l.getActive().title; a.mobile.activePage = c; h.transition = h.transition || (v && !x ? n.transition : d) || (w ? a.mobile.defaultDialogTransition : a.mobile.defaultPageTransition); h.reverse = h.reverse || v < 0; e(c, k, h.transition, h.reverse).done(function () {
    b(); h.duplicateCachedPage &&
h.duplicateCachedPage.remove(); p.removeClass("ui-mobile-rendering"); f(); m.trigger("pagechange", o)
})
            }
        }
    }
}; a.mobile.changePage.defaults = { transition: d, reverse: !1, changeHash: !0, fromHashChange: !1, role: d, duplicateCachedPage: d, pageContainer: d, showLoadMsg: !0, dataUrl: d, fromPage: d, allowSamePageTransition: !1 }; a.mobile._registerInternalEvents = function () {
    a("form").live("submit", function (b) {
        var c = a(this); if (a.mobile.ajaxEnabled && !c.is(":jqmData(ajax='false')")) {
            var d = c.attr("method"), f = c.attr("target"), e = c.attr("action");
            if (!e && (e = n(c), e === t.hrefNoHash)) e = x.hrefNoSearch; e = i.makeUrlAbsolute(e, n(c)); !i.isExternal(e) && !f && (a.mobile.changePage(e, { type: d && d.length && d.toLowerCase() || "get", data: c.serialize(), transition: c.jqmData("transition"), direction: c.jqmData("direction"), reloadPage: !0 }), b.preventDefault())
        }
    }); a(document).bind("vclick", function (c) {
        if (!(c.which > 1) && (c = k(c.target)) && i.parseUrl(c.getAttribute("href") || "#").hash !== "#") b(!0), o = a(c).closest(".ui-btn").not(".ui-disabled"), o.addClass(a.mobile.activeBtnClass),
a("." + a.mobile.activePageClass + " .ui-btn").not(c).blur()
    }); a(document).bind("click", function (c) {
        var f = k(c.target); if (f && !(c.which > 1)) {
            var e = a(f), g = function () { window.setTimeout(function () { b(!0) }, 200) }; if (e.is(":jqmData(rel='back')")) return window.history.back(), !1; var h = n(e), f = i.makeUrlAbsolute(e.attr("href") || "#", h); if (!a.mobile.ajaxEnabled && !i.isEmbeddedPage(f)) g(); else {
                if (f.search("#") != -1) if (f = f.replace(/[^#]*#/, "")) f = i.isPath(f) ? i.makeUrlAbsolute(f, h) : i.makeUrlAbsolute("#" + f, x.hrefNoHash); else {
                    c.preventDefault();
                    return
                } var h = e.is("[rel='external']") || e.is(":jqmData(ajax='false')") || e.is("[target]"), r = a.mobile.allowCrossDomainPages && x.protocol === "file:" && f.search(/^https?:/) != -1; h || i.isExternal(f) && !r ? g() : (g = e.jqmData("transition"), h = (h = e.jqmData("direction")) && h === "reverse" || e.jqmData("back"), e = e.attr("data-" + a.mobile.ns + "rel") || d, a.mobile.changePage(f, { transition: g, reverse: h, role: e }), c.preventDefault())
            }
        }
    }); a(".ui-page").live("pageshow.prefetch", function () {
        var b = []; a(this).find("a:jqmData(prefetch)").each(function () {
            var c =
a(this).attr("href"); c && a.inArray(c, b) === -1 && (b.push(c), a.mobile.loadPage(c))
        })
    }); a.mobile._handleHashChange = function (b) {
        var c = i.stripHash(b), f = { transition: a.mobile.urlHistory.stack.length === 0 ? "none" : d, changeHash: !1, fromHashChange: !0 }; if (!a.mobile.hashListeningEnabled || l.ignoreNextHashChange) l.ignoreNextHashChange = !1; else {
            if (l.stack.length > 1 && c.indexOf(r) > -1) if (a.mobile.activePage.is(".ui-dialog")) l.directHashChange({ currentUrl: c, either: function (b) {
                var d = a.mobile.urlHistory.getActive(); c = d.pageUrl;
                a.extend(f, { role: d.role, transition: d.transition, reverse: b })
            }
            }); else { l.directHashChange({ currentUrl: c, isBack: function () { window.history.back() }, isForward: function () { window.history.forward() } }); return } c ? (c = typeof c === "string" && !i.isPath(c) ? i.makeUrlAbsolute("#" + c, t) : c, a.mobile.changePage(c, f)) : a.mobile.changePage(a.mobile.firstPage, f)
        }
    }; q.bind("hashchange", function () { a.mobile._handleHashChange(location.hash) }); a(document).bind("pageshow", h); a(window).bind("throttledresize", h)
}
})(jQuery);
(function (a, d) {
    var c = {}, b = a(d), f = a.mobile.path.parseUrl(location.href); a.extend(c, { initialFilePath: f.pathname + f.search, initialHref: f.hrefNoHash, hashchangeFired: !1, state: function () { return { hash: location.hash || "#" + c.initialFilePath, title: document.title, initialHref: c.initialHref} }, resetUIKeys: function (b) { var c = "&" + a.mobile.subPageUrlKey, d = b.indexOf(a.mobile.dialogHashKey); d > -1 ? b = b.slice(0, d) + "#" + b.slice(d) : b.indexOf(c) > -1 && (b = b.split(c).join("#" + c)); return b }, nextHashChangePrevented: function (b) {
        a.mobile.urlHistory.ignoreNextHashChange =
b; c.onHashChangeDisabled = b
    }, onHashChange: function () { if (!c.onHashChangeDisabled) { var b, d; b = location.hash; var f = a.mobile.path.isPath(b); b = f ? b.replace("#", "") : b; d = c.state(); b = a.mobile.path.makeUrlAbsolute(b, location.href); f && (b = c.resetUIKeys(b)); history.replaceState(d, document.title, b) } }, onPopState: function (b) { var d = b.originalEvent.state; d && (c.nextHashChangePrevented(!0), setTimeout(function () { c.nextHashChangePrevented(!1); a.mobile._handleHashChange(d.hash) }, 100)) }, init: function () {
        b.bind("hashchange",
c.onHashChange); b.bind("popstate", c.onPopState); location.hash === "" && history.replaceState(c.state(), document.title, location.href)
    }
    }); a(function () { a.mobile.pushStateEnabled && a.support.pushState && c.init() })
})(jQuery, this);
(function (a) {
    function d(c, b, d, e) { var g = new a.Deferred, h = b ? " reverse" : "", j = "ui-mobile-viewport-transitioning viewport-" + c; d.animationComplete(function () { d.add(e).removeClass("out in reverse " + c); e && e[0] !== d[0] && e.removeClass(a.mobile.activePageClass); d.parent().removeClass(j); g.resolve(c, b, d, e) }); d.parent().addClass(j); e && e.addClass(c + " out" + h); d.addClass(a.mobile.activePageClass + " " + c + " in" + h); return g.promise() } a.mobile.css3TransitionHandler = d; if (a.mobile.defaultTransitionHandler === a.mobile.noneTransitionHandler) a.mobile.defaultTransitionHandler =
d
})(jQuery, this);
(function (a) {
    a.mobile.page.prototype.options.degradeInputs = { color: !1, date: !1, datetime: !1, "datetime-local": !1, email: !1, month: !1, number: !1, range: "number", search: "text", tel: !1, time: !1, url: !1, week: !1 }; a.mobile.page.prototype.options.keepNative = ":jqmData(role='none'), :jqmData(role='nojs')"; a(document).bind("pagecreate enhance", function (d) {
        var c = a(d.target).data("page").options; a(d.target).find("input").not(c.keepNative).each(function () {
            var b = a(this), d = this.getAttribute("type"), e = c.degradeInputs[d] || "text";
            if (c.degradeInputs[d]) { var g = a("<div>").html(b.clone()).html(), h = g.indexOf(" type=") > -1; b.replaceWith(g.replace(h ? /\s+type=["']?\w+['"]?/ : /\/?>/, ' type="' + e + '" data-' + a.mobile.ns + 'type="' + d + '"' + (h ? "" : ">"))) }
        })
    })
})(jQuery);
(function (a, d) {
    a.widget("mobile.dialog", a.mobile.widget, { options: { closeBtnText: "Close", theme: "a", initSelector: ":jqmData(role='dialog')" }, _create: function () {
        var c = this, b = this.element, d = b.attr("class").match(/ui-body-[a-z]/), e = a("<a href='#' data-" + a.mobile.ns + "icon='delete' data-" + a.mobile.ns + "iconpos='notext'>" + this.options.closeBtnText + "</a>"); d.length && b.removeClass(d[0]); b.addClass("ui-body-" + this.options.theme); b.attr("role", "dialog").addClass("ui-dialog").find(":jqmData(role='header')").addClass("ui-corner-top ui-overlay-shadow").prepend(e).end().find(":jqmData(role='content'),:jqmData(role='footer')").last().addClass("ui-corner-bottom ui-overlay-shadow");
        e.bind("vclick", function () { c.close() }); b.bind("vclick submit", function (b) { var b = a(b.target).closest(b.type === "vclick" ? "a" : "form"), c; b.length && !b.jqmData("transition") && (c = a.mobile.urlHistory.getActive() || {}, b.attr("data-" + a.mobile.ns + "transition", c.transition || a.mobile.defaultDialogTransition).attr("data-" + a.mobile.ns + "direction", "reverse")) }).bind("pagehide", function () { a(this).find("." + a.mobile.activeBtnClass).removeClass(a.mobile.activeBtnClass) })
    }, close: function () { d.history.back() }
    }); a(a.mobile.dialog.prototype.options.initSelector).live("pagecreate",
function () { a(this).dialog() })
})(jQuery, this);
(function (a) {
    a.mobile.page.prototype.options.backBtnText = "Back"; a.mobile.page.prototype.options.addBackBtn = !1; a.mobile.page.prototype.options.backBtnTheme = null; a.mobile.page.prototype.options.headerTheme = "a"; a.mobile.page.prototype.options.footerTheme = "a"; a.mobile.page.prototype.options.contentTheme = null; a(":jqmData(role='page'), :jqmData(role='dialog')").live("pagecreate", function () {
        var d = a(this).data("page").options, c = d.theme; a(":jqmData(role='header'), :jqmData(role='footer'), :jqmData(role='content')", this).each(function () {
            var b =
a(this), f = b.jqmData("role"), e = b.jqmData("theme"), g, h, j; b.addClass("ui-" + f); if (f === "header" || f === "footer") {
                e = e || (f === "header" ? d.headerTheme : d.footerTheme) || c; b.addClass("ui-bar-" + e); b.attr("role", f === "header" ? "banner" : "contentinfo"); g = b.children("a"); h = g.hasClass("ui-btn-left"); j = g.hasClass("ui-btn-right"); if (!h) h = g.eq(0).not(".ui-btn-right").addClass("ui-btn-left").length; j || g.eq(1).addClass("ui-btn-right"); d.addBackBtn && f === "header" && a(".ui-page").length > 1 && b.jqmData("url") !== a.mobile.path.stripHash(location.hash) &&
!h && (f = a("<a href='#' class='ui-btn-left' data-" + a.mobile.ns + "rel='back' data-" + a.mobile.ns + "icon='arrow-l'>" + d.backBtnText + "</a>").prependTo(b), f.attr("data-" + a.mobile.ns + "theme", d.backBtnTheme || e)); b.children("h1, h2, h3, h4, h5, h6").addClass("ui-title").attr({ tabindex: "0", role: "heading", "aria-level": "1" })
            } else if (f === "content") { if (e || d.contentTheme) b.addClass("ui-body-" + (e || d.contentTheme)); b.attr("role", "main") }
        })
    })
})(jQuery);
(function (a) {
    a.widget("mobile.collapsible", a.mobile.widget, { options: { expandCueText: " click to expand contents", collapseCueText: " click to collapse contents", collapsed: !0, heading: ">:header,>legend", theme: null, contentTheme: null, iconTheme: "d", initSelector: ":jqmData(role='collapsible')" }, _create: function () {
        var d = this.element, c = this.options, b = d.addClass("ui-collapsible"), f = d.find(c.heading).eq(0), e = b.wrapInner("<div class='ui-collapsible-content'></div>").find(".ui-collapsible-content"), g = d.closest(":jqmData(role='collapsible-set')").addClass("ui-collapsible-set"),
d = g.children(":jqmData(role='collapsible')"); f.is("legend") && (f = a("<div role='heading'>" + f.html() + "</div>").insertBefore(f), f.next().remove()); if (g.length) { if (!c.theme) c.theme = g.jqmData("theme"); if (!c.contentTheme) c.contentTheme = g.jqmData("content-theme") } e.addClass(c.contentTheme ? "ui-body-" + c.contentTheme : ""); f.insertBefore(e).addClass("ui-collapsible-heading").append("<span class='ui-collapsible-heading-status'></span>").wrapInner("<a href='#' class='ui-collapsible-heading-toggle'></a>").find("a:eq(0)").buttonMarkup({ shadow: !1,
    corners: !1, iconPos: "left", icon: "plus", theme: c.theme
}); g.length ? (g.jqmData("collapsiblebound") || g.jqmData("collapsiblebound", !0).bind("expand", function (b) { a(b.target).closest(".ui-collapsible").siblings(".ui-collapsible").trigger("collapse") }), d.first().find("a:eq(0)").addClass("ui-corner-top").find(".ui-btn-inner").addClass("ui-corner-top"), d.last().jqmData("collapsible-last", !0).find("a:eq(0)").addClass("ui-corner-bottom").find(".ui-btn-inner").addClass("ui-corner-bottom"), b.jqmData("collapsible-last") &&
f.find("a:eq(0), .ui-btn-inner").addClass("ui-corner-bottom")) : f.find("a:eq(0), .ui-btn-inner").addClass("ui-corner-top ui-corner-bottom"); b.bind("expand collapse", function (d) {
    if (!d.isDefaultPrevented()) {
        d.preventDefault(); var j = a(this), d = d.type === "collapse", k = c.contentTheme; f.toggleClass("ui-collapsible-heading-collapsed", d).find(".ui-collapsible-heading-status").text(c.expandCueText).end().find(".ui-icon").toggleClass("ui-icon-minus", !d).toggleClass("ui-icon-plus", d); j.toggleClass("ui-collapsible-collapsed",
d); e.toggleClass("ui-collapsible-content-collapsed", d).attr("aria-hidden", d); if (k && (!g.length || b.jqmData("collapsible-last"))) f.find("a:eq(0), .ui-btn-inner").toggleClass("ui-corner-bottom", d), e.toggleClass("ui-corner-bottom", !d)
    }
}).trigger(c.collapsed ? "collapse" : "expand"); f.bind("click", function (a) { var c = f.is(".ui-collapsible-heading-collapsed") ? "expand" : "collapse"; b.trigger(c); a.preventDefault() })
    }
    }); a(document).bind("pagecreate create", function (d) {
        a(a.mobile.collapsible.prototype.options.initSelector,
d.target).collapsible()
    })
})(jQuery); (function (a) { a.fn.fieldcontain = function () { return this.addClass("ui-field-contain ui-body ui-br") }; a(document).bind("pagecreate create", function (d) { a(":jqmData(role='fieldcontain')", d.target).fieldcontain() }) })(jQuery);
(function (a) { a.fn.grid = function (d) { return this.each(function () { var c = a(this), b = a.extend({ grid: null }, d), f = c.children(), e = { solo: 1, a: 2, b: 3, c: 4, d: 5 }, b = b.grid; if (!b) if (f.length <= 5) for (var g in e) e[g] === f.length && (b = g); else b = "a"; e = e[b]; c.addClass("ui-grid-" + b); f.filter(":nth-child(" + e + "n+1)").addClass("ui-block-a"); e > 1 && f.filter(":nth-child(" + e + "n+2)").addClass("ui-block-b"); e > 2 && f.filter(":nth-child(3n+3)").addClass("ui-block-c"); e > 3 && f.filter(":nth-child(4n+4)").addClass("ui-block-d"); e > 4 && f.filter(":nth-child(5n+5)").addClass("ui-block-e") }) } })(jQuery);
(function (a, d) {
    a.widget("mobile.navbar", a.mobile.widget, { options: { iconpos: "top", grid: null, initSelector: ":jqmData(role='navbar')" }, _create: function () {
        var c = this.element, b = c.find("a"), f = b.filter(":jqmData(icon)").length ? this.options.iconpos : d; c.addClass("ui-navbar").attr("role", "navigation").find("ul").grid({ grid: this.options.grid }); f || c.addClass("ui-navbar-noicons"); b.buttonMarkup({ corners: !1, shadow: !1, iconpos: f }); c.delegate("a", "vclick", function () {
            b.not(".ui-state-persist").removeClass(a.mobile.activeBtnClass);
            a(this).addClass(a.mobile.activeBtnClass)
        })
    }
    }); a(document).bind("pagecreate create", function (c) { a(a.mobile.navbar.prototype.options.initSelector, c.target).navbar() })
})(jQuery);
(function (a) {
    var d = {}; a.widget("mobile.listview", a.mobile.widget, { options: { theme: "c", countTheme: "c", headerTheme: "b", dividerTheme: "b", splitIcon: "arrow-r", splitTheme: "b", inset: !1, initSelector: ":jqmData(role='listview')" }, _create: function () { var a = this; a.element.addClass(function (b, d) { return d + " ui-listview " + (a.options.inset ? " ui-listview-inset ui-corner-all ui-shadow " : "") }); a.refresh(!0) }, _itemApply: function (c, b) {
        var d = b.find(".ui-li-count"); d.length && b.addClass("ui-li-has-count"); d.addClass("ui-btn-up-" +
(c.jqmData("counttheme") || this.options.countTheme) + " ui-btn-corner-all"); b.find("h1, h2, h3, h4, h5, h6").addClass("ui-li-heading").end().find("p, dl").addClass("ui-li-desc").end().find(">img:eq(0), .ui-link-inherit>img:eq(0)").addClass("ui-li-thumb").each(function () { b.addClass(a(this).is(".ui-li-icon") ? "ui-li-has-icon" : "ui-li-has-thumb") }).end().find(".ui-li-aside").each(function () { var b = a(this); b.prependTo(b.parent()) })
    }, _removeCorners: function (a, b) {
        a = a.add(a.find(".ui-btn-inner, .ui-li-link-alt, .ui-li-thumb"));
        b === "top" ? a.removeClass("ui-corner-top ui-corner-tr ui-corner-tl") : b === "bottom" ? a.removeClass("ui-corner-bottom ui-corner-br ui-corner-bl") : a.removeClass("ui-corner-top ui-corner-tr ui-corner-tl ui-corner-bottom ui-corner-br ui-corner-bl")
    }, _refreshCorners: function (a) {
        var b; this.options.inset && (b = this.element.children("li"), a = a ? b.not(".ui-screen-hidden") : b.filter(":visible"), this._removeCorners(b), b = a.first().addClass("ui-corner-top"), b.add(b.find(".ui-btn-inner")).find(".ui-li-link-alt").addClass("ui-corner-tr").end().find(".ui-li-thumb").addClass("ui-corner-tl"),
b = a.last().addClass("ui-corner-bottom"), b.add(b.find(".ui-btn-inner")).find(".ui-li-link-alt").addClass("ui-corner-br").end().find(".ui-li-thumb").addClass("ui-corner-bl"))
    }, refresh: function (c) {
        this.parentPage = this.element.closest(".ui-page"); this._createSubPages(); var b = this.options, d = this.element, e = d.jqmData("dividertheme") || b.dividerTheme, g = d.jqmData("splittheme"), h = d.jqmData("spliticon"), j = d.children("li"), k = a.support.cssPseudoElement || !a.nodeName(d[0], "ol") ? 0 : 1, n, q, p, m, i; k && d.find(".ui-li-dec").remove();
        for (var o = 0, l = j.length; o < l; o++) {
            n = j.eq(o); q = "ui-li"; if (c || !n.hasClass("ui-li")) p = n.jqmData("theme") || b.theme, m = n.children("a"), m.length ? (i = n.jqmData("icon"), n.buttonMarkup({ wrapperEls: "div", shadow: !1, corners: !1, iconpos: "right", icon: m.length > 1 || i === !1 ? !1 : i || "arrow-r", theme: p }), i != !1 && m.length == 1 && n.addClass("ui-li-has-arrow"), m.first().addClass("ui-link-inherit"), m.length > 1 && (q += " ui-li-has-alt", m = m.last(), i = g || m.jqmData("theme") || b.splitTheme, m.appendTo(n).attr("title", m.text()).addClass("ui-li-link-alt").empty().buttonMarkup({ shadow: !1,
                corners: !1, theme: p, icon: !1, iconpos: !1
            }).find(".ui-btn-inner").append(a("<span />").buttonMarkup({ shadow: !0, corners: !0, theme: i, iconpos: "notext", icon: h || m.jqmData("icon") || b.splitIcon })))) : n.jqmData("role") === "list-divider" ? (q += " ui-li-divider ui-btn ui-bar-" + e, n.attr("role", "heading"), k && (k = 1)) : q += " ui-li-static ui-body-" + p; k && q.indexOf("ui-li-divider") < 0 && (p = n.is(".ui-li-static:first") ? n : n.find(".ui-link-inherit"), p.addClass("ui-li-jsnumbering").prepend("<span class='ui-li-dec'>" + k++ + ". </span>"));
            n.add(n.children(".ui-btn-inner")).addClass(q); this._itemApply(d, n)
        } this._refreshCorners(c)
    }, _idStringEscape: function (a) { return a.replace(/[^a-zA-Z0-9]/g, "-") }, _createSubPages: function () {
        var c = this.element, b = c.closest(".ui-page"), f = b.jqmData("url"), e = f || b[0][a.expando], g = c.attr("id"), h = this.options, j = "data-" + a.mobile.ns, k = this, n = b.find(":jqmData(role='footer')").jqmData("id"), q; typeof d[e] === "undefined" && (d[e] = -1); g = g || ++d[e]; a(c.find("li>ul, li>ol").toArray().reverse()).each(function (b) {
            var d = a(this),
e = d.attr("id") || g + "-" + b, b = d.parent(), k = a(d.prevAll().toArray().reverse()), k = k.length ? k : a("<span>" + a.trim(b.contents()[0].nodeValue) + "</span>"), l = k.first().text(), e = (f || "") + "&" + a.mobile.subPageUrlKey + "=" + e, B = d.jqmData("theme") || h.theme, y = d.jqmData("counttheme") || c.jqmData("counttheme") || h.countTheme; q = !0; d.detach().wrap("<div " + j + "role='page' " + j + "url='" + e + "' " + j + "theme='" + B + "' " + j + "count-theme='" + y + "'><div " + j + "role='content'></div></div>").parent().before("<div " + j + "role='header' " + j + "theme='" + h.headerTheme +
"'><div class='ui-title'>" + l + "</div></div>").after(n ? a("<div " + j + "role='footer' " + j + "id='" + n + "'>") : "").parent().appendTo(a.mobile.pageContainer).page(); d = b.find("a:first"); d.length || (d = a("<a/>").html(k || l).prependTo(b.empty())); d.attr("href", "#" + e)
        }).listview(); q && b.is(":jqmData(external-page='true')") && b.data("page").options.domCache === !1 && b.unbind("pagehide.remove").bind("pagehide.remove", function (c, d) {
            var e = d.nextPage; d.nextPage && (e = e.jqmData("url"), e.indexOf(f + "&" + a.mobile.subPageUrlKey) !== 0 &&
(k.childPages().remove(), b.remove()))
        })
    }, childPages: function () { var c = this.parentPage.jqmData("url"); return a(":jqmData(url^='" + c + "&" + a.mobile.subPageUrlKey + "')") }
    }); a(document).bind("pagecreate create", function (c) { a(a.mobile.listview.prototype.options.initSelector, c.target).listview() })
})(jQuery);
(function (a) {
    a.mobile.listview.prototype.options.filter = !1; a.mobile.listview.prototype.options.filterPlaceholder = "Filter items..."; a.mobile.listview.prototype.options.filterTheme = "c"; a.mobile.listview.prototype.options.filterCallback = function (a, c) { return a.toLowerCase().indexOf(c) === -1 }; a(":jqmData(role='listview')").live("listviewcreate", function () {
        var d = a(this), c = d.data("listview"); if (c.options.filter) {
            var b = a("<form>", { "class": "ui-listview-filter ui-bar-" + c.options.filterTheme, role: "search" });
            a("<input>", { placeholder: c.options.filterPlaceholder }).attr("data-" + a.mobile.ns + "type", "search").jqmData("lastval", "").bind("keyup change", function () {
                var b = a(this), e = this.value.toLowerCase(), g = null, g = b.jqmData("lastval") + "", h = !1, j = ""; b.jqmData("lastval", e); j = e.replace(RegExp("^" + g), ""); g = e.length < g.length || j.length != e.length - g.length ? d.children() : d.children(":not(.ui-screen-hidden)"); if (e) {
                    for (var k = g.length - 1; k >= 0; k--) b = a(g[k]), j = b.jqmData("filtertext") || b.text(), b.is("li:jqmData(role=list-divider)") ?
(b.toggleClass("ui-filter-hidequeue", !h), h = !1) : c.options.filterCallback(j, e) ? b.toggleClass("ui-filter-hidequeue", !0) : h = !0; g.filter(":not(.ui-filter-hidequeue)").toggleClass("ui-screen-hidden", !1); g.filter(".ui-filter-hidequeue").toggleClass("ui-screen-hidden", !0).toggleClass("ui-filter-hidequeue", !1)
                } else g.toggleClass("ui-screen-hidden", !1); c._refreshCorners()
            }).appendTo(b).textinput(); a(this).jqmData("inset") && b.addClass("ui-listview-filter-inset"); b.bind("submit", function () { return !1 }).insertBefore(d)
        }
    })
})(jQuery);
(function (a) { a(document).bind("pagecreate create", function (d) { a(":jqmData(role='nojs')", d.target).addClass("ui-nojs") }) })(jQuery);
(function (a, d) {
    a.widget("mobile.checkboxradio", a.mobile.widget, { options: { theme: null, initSelector: "input[type='checkbox'],input[type='radio']" }, _create: function () {
        var c = this, b = this.element, f = b.closest("form,fieldset,:jqmData(role='page')").find("label").filter("[for='" + b[0].id + "']"), e = b.attr("type"), g = e + "-on", h = e + "-off", j = b.parents(":jqmData(type='horizontal')").length ? d : h; if (!(e !== "checkbox" && e !== "radio")) {
            a.extend(this, { label: f, inputtype: e, checkedClass: "ui-" + g + (j ? "" : " " + a.mobile.activeBtnClass),
                uncheckedClass: "ui-" + h, checkedicon: "ui-icon-" + g, uncheckedicon: "ui-icon-" + h
            }); if (!this.options.theme) this.options.theme = this.element.jqmData("theme"); f.buttonMarkup({ theme: this.options.theme, icon: j, shadow: !1 }); b.add(f).wrapAll("<div class='ui-" + e + "'></div>"); f.bind({ vmouseover: function () { if (a(this).parent().is(".ui-disabled")) return !1 }, vclick: function (a) {
                if (b.is(":disabled")) a.preventDefault(); else return c._cacheVals(), b.prop("checked", e === "radio" && !0 || !b.prop("checked")), c._getInputSet().not(b).prop("checked",
!1), c._updateAll(), !1
            }
            }); b.bind({ vmousedown: function () { this._cacheVals() }, vclick: function () { var b = a(this); b.is(":checked") ? (b.prop("checked", !0), c._getInputSet().not(b).prop("checked", !1)) : b.prop("checked", !1); c._updateAll() }, focus: function () { f.addClass("ui-focus") }, blur: function () { f.removeClass("ui-focus") } }); this.refresh()
        }
    }, _cacheVals: function () { this._getInputSet().each(function () { var c = a(this); c.jqmData("cacheVal", c.is(":checked")) }) }, _getInputSet: function () {
        if (this.inputtype == "checkbox") return this.element;
        return this.element.closest("form,fieldset,:jqmData(role='page')").find("input[name='" + this.element.attr("name") + "'][type='" + this.inputtype + "']")
    }, _updateAll: function () { var c = this; this._getInputSet().each(function () { var b = a(this); (b.is(":checked") || c.inputtype === "checkbox") && b.trigger("change") }).checkboxradio("refresh") }, refresh: function () {
        var c = this.element, b = this.label, d = b.find(".ui-icon"); a(c[0]).prop("checked") ? (b.addClass(this.checkedClass).removeClass(this.uncheckedClass), d.addClass(this.checkedicon).removeClass(this.uncheckedicon)) :
(b.removeClass(this.checkedClass).addClass(this.uncheckedClass), d.removeClass(this.checkedicon).addClass(this.uncheckedicon)); c.is(":disabled") ? this.disable() : this.enable()
    }, disable: function () { this.element.prop("disabled", !0).parent().addClass("ui-disabled") }, enable: function () { this.element.prop("disabled", !1).parent().removeClass("ui-disabled") }
    }); a(document).bind("pagecreate create", function (c) { a(a.mobile.checkboxradio.prototype.options.initSelector, c.target).not(":jqmData(role='none'), :jqmData(role='nojs')").checkboxradio() })
})(jQuery);
(function (a, d) {
    a.widget("mobile.button", a.mobile.widget, { options: { theme: null, icon: null, iconpos: null, inline: null, corners: !0, shadow: !0, iconshadow: !0, initSelector: "button, [type='button'], [type='submit'], [type='reset'], [type='image']" }, _create: function () {
        var c = this.element, b = this.options, f, e; this.button = a("<div></div>").text(c.text() || c.val()).buttonMarkup({ theme: b.theme, icon: b.icon, iconpos: b.iconpos, inline: b.inline, corners: b.corners, shadow: b.shadow, iconshadow: b.iconshadow }).insertBefore(c).append(c.addClass("ui-btn-hidden"));
        b = c.attr("type"); f = c.attr("name"); b !== "button" && b !== "reset" && f && c.bind("vclick", function () { e === d && (e = a("<input>", { type: "hidden", name: c.attr("name"), value: c.attr("value") }).insertBefore(c), a(document).submit(function () { e.remove() })) }); this.refresh()
    }, enable: function () { this.element.attr("disabled", !1); this.button.removeClass("ui-disabled").attr("aria-disabled", !1); return this._setOption("disabled", !1) }, disable: function () {
        this.element.attr("disabled", !0); this.button.addClass("ui-disabled").attr("aria-disabled",
!0); return this._setOption("disabled", !0)
    }, refresh: function () { this.element.attr("disabled") ? this.disable() : this.enable() }
    }); a(document).bind("pagecreate create", function (c) { a(a.mobile.button.prototype.options.initSelector, c.target).not(":jqmData(role='none'), :jqmData(role='nojs')").button() })
})(jQuery);
(function (a, d) {
    a.widget("mobile.slider", a.mobile.widget, { options: { theme: null, trackTheme: null, disabled: !1, initSelector: "input[type='range'], :jqmData(type='range'), :jqmData(role='slider')" }, _create: function () {
        var c = this, b = this.element, f = b.parents("[class*='ui-bar-'],[class*='ui-body-']").eq(0), f = f.length ? f.attr("class").match(/ui-(bar|body)-([a-z])/)[2] : "c", e = this.options.theme ? this.options.theme : f, g = this.options.trackTheme ? this.options.trackTheme : f, h = b[0].nodeName.toLowerCase(), f = h == "select" ? "ui-slider-switch" :
"", j = b.attr("id"), k = j + "-label", j = a("[for='" + j + "']").attr("id", k), n = function () { return h == "input" ? parseFloat(b.val()) : b[0].selectedIndex }, q = h == "input" ? parseFloat(b.attr("min")) : 0, p = h == "input" ? parseFloat(b.attr("max")) : b.find("option").length - 1, m = window.parseFloat(b.attr("step") || 1), i = a("<div class='ui-slider " + f + " ui-btn-down-" + g + " ui-btn-corner-all' role='application'></div>"), o = a("<a href='#' class='ui-slider-handle'></a>").appendTo(i).buttonMarkup({ corners: !0, theme: e, shadow: !0 }).attr({ role: "slider",
    "aria-valuemin": q, "aria-valuemax": p, "aria-valuenow": n(), "aria-valuetext": n(), title: n(), "aria-labelledby": k
}); a.extend(this, { slider: i, handle: o, dragging: !1, beforeStart: null, userModified: !1 }); h == "select" && (i.wrapInner("<div class='ui-slider-inneroffset'></div>"), b.find("option"), b.find("option").each(function (b) {
    var c = !b ? "b" : "a", d = !b ? "right" : "left", b = !b ? " ui-btn-down-" + g : " " + a.mobile.activeBtnClass; a("<div class='ui-slider-labelbg ui-slider-labelbg-" + c + b + " ui-btn-corner-" + d + "'></div>").prependTo(i);
    a("<span class='ui-slider-label ui-slider-label-" + c + b + " ui-btn-corner-" + d + "' role='img'>" + a(this).text() + "</span>").prependTo(o)
})); j.addClass("ui-slider"); b.addClass(h === "input" ? "ui-slider-input" : "ui-slider-switch").change(function () { c.refresh(n(), !0) }).keyup(function () { c.refresh(n(), !0, !0) }).blur(function () { c.refresh(n(), !0) }); a(document).bind("vmousemove", function (a) { if (c.dragging) return c.refresh(a), c.userModified = c.userModified || c.beforeStart !== b[0].selectedIndex, !1 }); i.bind("vmousedown", function (a) {
    c.dragging =
!0; c.userModified = !1; if (h === "select") c.beforeStart = b[0].selectedIndex; c.refresh(a); return !1
}); i.add(document).bind("vmouseup", function () { if (c.dragging) return c.dragging = !1, h === "select" && !c.userModified && (o.addClass("ui-slider-handle-snapping"), c.refresh(!c.beforeStart ? 1 : 0)), !1 }); i.insertAfter(b); this.handle.bind("vmousedown", function () { a(this).focus() }).bind("vclick", !1); this.handle.bind("keydown", function (b) {
    var d = n(); if (!c.options.disabled) {
        switch (b.keyCode) {
            case a.mobile.keyCode.HOME: case a.mobile.keyCode.END: case a.mobile.keyCode.PAGE_UP: case a.mobile.keyCode.PAGE_DOWN: case a.mobile.keyCode.UP: case a.mobile.keyCode.RIGHT: case a.mobile.keyCode.DOWN: case a.mobile.keyCode.LEFT: if (b.preventDefault(),
!c._keySliding) c._keySliding = !0, a(this).addClass("ui-state-active")
        } switch (b.keyCode) { case a.mobile.keyCode.HOME: c.refresh(q); break; case a.mobile.keyCode.END: c.refresh(p); break; case a.mobile.keyCode.PAGE_UP: case a.mobile.keyCode.UP: case a.mobile.keyCode.RIGHT: c.refresh(d + m); break; case a.mobile.keyCode.PAGE_DOWN: case a.mobile.keyCode.DOWN: case a.mobile.keyCode.LEFT: c.refresh(d - m) }
    }
}).keyup(function () { if (c._keySliding) c._keySliding = !1, a(this).removeClass("ui-state-active") }); this.refresh(d, d, !0)
    }, refresh: function (a,
b, d) {
        if (!this.options.disabled) {
            var e = this.element, g, h = e[0].nodeName.toLowerCase(), j = h === "input" ? parseFloat(e.attr("min")) : 0, k = h === "input" ? parseFloat(e.attr("max")) : e.find("option").length - 1; if (typeof a === "object") { if (!this.dragging || a.pageX < this.slider.offset().left - 8 || a.pageX > this.slider.offset().left + this.slider.width() + 8) return; g = Math.round((a.pageX - this.slider.offset().left) / this.slider.width() * 100) } else a == null && (a = h === "input" ? parseFloat(e.val()) : e[0].selectedIndex), g = (parseFloat(a) - j) / (k - j) *
100; if (!isNaN(g) && (g < 0 && (g = 0), g > 100 && (g = 100), a = Math.round(g / 100 * (k - j)) + j, a < j && (a = j), a > k && (a = k), this.handle.css("left", g + "%"), this.handle.attr({ "aria-valuenow": h === "input" ? a : e.find("option").eq(a).attr("value"), "aria-valuetext": h === "input" ? a : e.find("option").eq(a).text(), title: a }), h === "select" && (a === 0 ? this.slider.addClass("ui-slider-switch-a").removeClass("ui-slider-switch-b") : this.slider.addClass("ui-slider-switch-b").removeClass("ui-slider-switch-a")), !d)) d = !1, h === "input" ? (d = e.val() !== a, e.val(a)) :
(d = e[0].selectedIndex !== a, e[0].selectedIndex = a), !b && d && e.trigger("change")
        }
    }, enable: function () { this.element.attr("disabled", !1); this.slider.removeClass("ui-disabled").attr("aria-disabled", !1); return this._setOption("disabled", !1) }, disable: function () { this.element.attr("disabled", !0); this.slider.addClass("ui-disabled").attr("aria-disabled", !0); return this._setOption("disabled", !0) }
    }); a(document).bind("pagecreate create", function (c) { a(a.mobile.slider.prototype.options.initSelector, c.target).not(":jqmData(role='none'), :jqmData(role='nojs')").slider() })
})(jQuery);
(function (a) {
    a.widget("mobile.textinput", a.mobile.widget, { options: { theme: null, initSelector: "input[type='text'], input[type='search'], :jqmData(type='search'), input[type='number'], :jqmData(type='number'), input[type='password'], input[type='email'], input[type='url'], input[type='tel'], textarea, input:not([type])" }, _create: function () {
        var i; var d = this.element, c = this.options, b = c.theme, f, e; b || (b = this.element.closest("[class*='ui-bar-'],[class*='ui-body-']"), i = (b = b.length && /ui-(bar|body)-([a-z])/.exec(b.attr("class"))) &&
b[2] || "c", b = i); b = " ui-body-" + b; a("label[for='" + d.attr("id") + "']").addClass("ui-input-text"); d.addClass("ui-input-text ui-body-" + c.theme); f = d; typeof d[0].autocorrect !== "undefined" && !a.support.touchOverflow && (d[0].setAttribute("autocorrect", "off"), d[0].setAttribute("autocomplete", "off")); d.is("[type='search'],:jqmData(type='search')") ? (f = d.wrap("<div class='ui-input-search ui-shadow-inset ui-btn-corner-all ui-btn-shadow ui-icon-searchfield" + b + "'></div>").parent(), e = a("<a href='#' class='ui-input-clear' title='clear text'>clear text</a>").tap(function (a) {
    d.val("").focus();
    d.trigger("change"); e.addClass("ui-input-clear-hidden"); a.preventDefault()
}).appendTo(f).buttonMarkup({ icon: "delete", iconpos: "notext", corners: !0, shadow: !0 }), c = function () { d.val() ? e.removeClass("ui-input-clear-hidden") : e.addClass("ui-input-clear-hidden") }, c(), d.keyup(c).focus(c)) : d.addClass("ui-corner-all ui-shadow-inset" + b); d.focus(function () { f.addClass("ui-focus") }).blur(function () { f.removeClass("ui-focus") }); if (d.is("textarea")) {
            var g = function () {
                var a = d[0].scrollHeight; d[0].clientHeight < a && d.css({ height: a +
15
                })
            }, h; d.keyup(function () { clearTimeout(h); h = setTimeout(g, 100) })
        }
    }, disable: function () { (this.element.attr("disabled", !0).is("[type='search'],:jqmData(type='search')") ? this.element.parent() : this.element).addClass("ui-disabled") }, enable: function () { (this.element.attr("disabled", !1).is("[type='search'],:jqmData(type='search')") ? this.element.parent() : this.element).removeClass("ui-disabled") }
    }); a(document).bind("pagecreate create", function (d) { a(a.mobile.textinput.prototype.options.initSelector, d.target).not(":jqmData(role='none'), :jqmData(role='nojs')").textinput() })
})(jQuery);
(function (a) {
    var d = function (c) {
        var b = c.selectID, d = c.label, e = c.select.closest(".ui-page"), g = a("<div>", { "class": "ui-selectmenu-screen ui-screen-hidden" }).appendTo(e), h = c._selectOptions(), j = c.isMultiple = c.select[0].multiple, k = b + "-button", n = b + "-menu", q = a("<div data-" + a.mobile.ns + "role='dialog' data-" + a.mobile.ns + "theme='" + c.options.menuPageTheme + "'><div data-" + a.mobile.ns + "role='header'><div class='ui-title'>" + d.getEncodedText() + "</div></div><div data-" + a.mobile.ns + "role='content'></div></div>").appendTo(a.mobile.pageContainer).page(),
p = a("<div>", { "class": "ui-selectmenu ui-selectmenu-hidden ui-overlay-shadow ui-corner-all ui-body-" + c.options.overlayTheme + " " + a.mobile.defaultDialogTransition }).insertAfter(g), m = a("<ul>", { "class": "ui-selectmenu-list", id: n, role: "listbox", "aria-labelledby": k }).attr("data-" + a.mobile.ns + "theme", c.options.theme).appendTo(p), i = a("<div>", { "class": "ui-header ui-bar-" + c.options.theme }).prependTo(p), o = a("<h1>", { "class": "ui-title" }).appendTo(i), l = a("<a>", { text: c.options.closeText, href: "#", "class": "ui-btn-left" }).attr("data-" +
a.mobile.ns + "iconpos", "notext").attr("data-" + a.mobile.ns + "icon", "delete").appendTo(i).buttonMarkup(), B = q.find(".ui-content"), y = q.find(".ui-header a"); a.extend(c, { select: c.select, selectID: b, buttonId: k, menuId: n, thisPage: e, menuPage: q, label: d, screen: g, selectOptions: h, isMultiple: j, theme: c.options.theme, listbox: p, list: m, header: i, headerTitle: o, headerClose: l, menuPageContent: B, menuPageClose: y, placeholder: "", build: function () {
    var b = this; b.refresh(); b.select.attr("tabindex", "-1").focus(function () {
        a(this).blur();
        b.button.focus()
    }); b.button.bind("vclick keydown", function (c) { if (c.type == "vclick" || c.keyCode && (c.keyCode === a.mobile.keyCode.ENTER || c.keyCode === a.mobile.keyCode.SPACE)) b.open(), c.preventDefault() }); b.list.attr("role", "listbox").delegate(".ui-li>a", "focusin", function () { a(this).attr("tabindex", "0") }).delegate(".ui-li>a", "focusout", function () { a(this).attr("tabindex", "-1") }).delegate("li:not(.ui-disabled, .ui-li-divider)", "click", function (c) {
        var d = b.select[0].selectedIndex, e = b.list.find("li:not(.ui-li-divider)").index(this),
f = b._selectOptions().eq(e)[0]; f.selected = b.isMultiple ? !f.selected : !0; b.isMultiple && a(this).find(".ui-icon").toggleClass("ui-icon-checkbox-on", f.selected).toggleClass("ui-icon-checkbox-off", !f.selected); (b.isMultiple || d !== e) && b.select.trigger("change"); b.isMultiple || b.close(); c.preventDefault()
    }).keydown(function (b) {
        var c = a(b.target), d = c.closest("li"); switch (b.keyCode) {
            case 38: return b = d.prev(), b.length && (c.blur().attr("tabindex", "-1"), b.find("a").first().focus()), !1; case 40: return b = d.next(), b.length &&
(c.blur().attr("tabindex", "-1"), b.find("a").first().focus()), !1; case 13: case 32: return c.trigger("click"), !1
        }
    }); b.menuPage.bind("pagehide", function () { b.list.appendTo(b.listbox); b._focusButton(); a.mobile._bindPageRemove.call(b.thisPage) }); b.screen.bind("vclick", function () { b.close() }); b.headerClose.click(function () { if (b.menuType == "overlay") return b.close(), !1 }); b.thisPage.addDependents(this.menuPage)
}, _isRebuildRequired: function () { var a = this.list.find("li"); return this._selectOptions().text() !== a.text() },
    refresh: function (b) { var c = this; this._selectOptions(); this.selected(); var d = this.selectedIndices(); (b || this._isRebuildRequired()) && c._buildList(); c.setButtonText(); c.setButtonCount(); c.list.find("li:not(.ui-li-divider)").removeClass(a.mobile.activeBtnClass).attr("aria-selected", !1).each(function (b) { a.inArray(b, d) > -1 && (b = a(this), b.attr("aria-selected", !0), c.isMultiple ? b.find(".ui-icon").removeClass("ui-icon-checkbox-off").addClass("ui-icon-checkbox-on") : b.addClass(a.mobile.activeBtnClass)) }) }, close: function () {
        if (!this.options.disabled &&
this.isOpen) this.menuType == "page" ? window.history.back() : (this.screen.addClass("ui-screen-hidden"), this.listbox.addClass("ui-selectmenu-hidden").removeAttr("style").removeClass("in"), this.list.appendTo(this.listbox), this._focusButton()), this.isOpen = !1
    }, open: function () {
        if (!this.options.disabled) {
            var b = this, c = b.list.parent().outerHeight(), d = b.list.parent().outerWidth(), e = a(".ui-page-active"), f = a.support.touchOverflow && a.mobile.touchOverflowEnabled, e = e.is(".ui-native-fixed") ? e.find(".ui-content") : e; scrollTop =
f ? e.scrollTop() : a(window).scrollTop(); btnOffset = b.button.offset().top; screenHeight = window.innerHeight; screenWidth = window.innerWidth; b.button.addClass(a.mobile.activeBtnClass); setTimeout(function () { b.button.removeClass(a.mobile.activeBtnClass) }, 300); if (c > screenHeight - 80 || !a.support.scrollTop) {
                b.thisPage.unbind("pagehide.remove"); if (scrollTop == 0 && btnOffset > screenHeight) b.thisPage.one("pagehide", function () { a(this).jqmData("lastScroll", btnOffset) }); b.menuPage.one("pageshow", function () {
                    a(window).one("silentscroll",
function () { b.list.find(a.mobile.activeBtnClass).focus() }); b.isOpen = !0
                }); b.menuType = "page"; b.menuPageContent.append(b.list); a.mobile.changePage(b.menuPage, { transition: a.mobile.defaultDialogTransition })
            } else {
                b.menuType = "overlay"; b.screen.height(a(document).height()).removeClass("ui-screen-hidden"); var e = btnOffset - scrollTop, g = scrollTop + screenHeight - btnOffset, h = c / 2, f = parseFloat(b.list.parent().css("max-width")), c = e > c / 2 && g > c / 2 ? btnOffset + b.button.outerHeight() / 2 - h : e > g ? scrollTop + screenHeight - c - 30 : scrollTop +
30; d < f ? f = (screenWidth - d) / 2 : (f = b.button.offset().left + b.button.outerWidth() / 2 - d / 2, f < 30 ? f = 30 : f + d > screenWidth && (f = screenWidth - d - 30)); b.listbox.append(b.list).removeClass("ui-selectmenu-hidden").css({ top: c, left: f }).addClass("in"); b.list.find(a.mobile.activeBtnClass).focus(); b.isOpen = !0
            }
        }
    }, _buildList: function () {
        var b = this, c = this.options, d = this.placeholder, e = [], f = [], g = b.isMultiple ? "checkbox-off" : "false"; b.list.empty().filter(".ui-listview").listview("destroy"); b.select.find("option").each(function (h) {
            var i =
a(this), j = i.parent(), m = i.getEncodedText(), p = "<a href='#'>" + m + "</a>", l = [], k = []; j.is("optgroup") && (j = j.attr("label"), a.inArray(j, e) === -1 && (f.push("<li data-" + a.mobile.ns + "role='list-divider'>" + j + "</li>"), e.push(j))); if (!this.getAttribute("value") || m.length == 0 || i.jqmData("placeholder")) c.hidePlaceholderMenuItems && l.push("ui-selectmenu-placeholder"), d = b.placeholder = m; this.disabled && (l.push("ui-disabled"), k.push("aria-disabled='true'")); f.push("<li data-" + a.mobile.ns + "option-index='" + h + "' data-" + a.mobile.ns +
"icon='" + g + "' class='" + l.join(" ") + "' " + k.join(" ") + ">" + p + "</li>")
        }); b.list.html(f.join(" ")); b.list.find("li").attr({ role: "option", tabindex: "-1" }).first().attr("tabindex", "0"); this.isMultiple || this.headerClose.hide(); !this.isMultiple && !d.length ? this.header.hide() : this.headerTitle.text(this.placeholder); b.list.listview()
    }, _button: function () { return a("<a>", { href: "#", role: "button", id: this.buttonId, "aria-haspopup": "true", "aria-owns": this.menuId }) }
})
    }; a("select").live("selectmenubeforecreate", function () {
        var c =
a(this).data("selectmenu"); c.options.nativeMenu || d(c)
    })
})(jQuery);
(function (a) {
    a.widget("mobile.selectmenu", a.mobile.widget, { options: { theme: null, disabled: !1, icon: "arrow-d", iconpos: "right", inline: null, corners: !0, shadow: !0, iconshadow: !0, menuPageTheme: "b", overlayTheme: "a", hidePlaceholderMenuItems: !0, closeText: "Close", nativeMenu: !0, initSelector: "select:not(:jqmData(role='slider'))" }, _button: function () { return a("<div/>") }, _theme: function () {
        if (this.options.theme) return this.options.theme; var a; a = this.select.closest("[class*='ui-bar-'], [class*='ui-body-']"); return a.length ?
/ui-(bar|body)-([a-z])/.exec(a.attr("class"))[2] : "c"
    }, _setDisabled: function (a) { this.element.attr("disabled", a); this.button.attr("aria-disabled", a); return this._setOption("disabled", a) }, _focusButton: function () { var a = this; setTimeout(function () { a.button.focus() }, 40) }, _selectOptions: function () { return this.select.find("option") }, _preExtension: function () {
        this.select = this.element.wrap("<div class='ui-select'>"); this.selectID = this.select.attr("id"); this.label = a("label[for='" + this.selectID + "']").addClass("ui-select");
        this.isMultiple = this.select[0].multiple; this.options.theme = this._theme()
    }, _create: function () {
        this._preExtension(); this._trigger("beforeCreate"); this.button = this._button(); var d = this, c = this.options, b = this.button.text(a(this.select[0].options.item(this.select[0].selectedIndex == -1 ? 0 : this.select[0].selectedIndex)).text()).insertBefore(this.select).buttonMarkup({ theme: c.theme, icon: c.icon, iconpos: c.iconpos, inline: c.inline, corners: c.corners, shadow: c.shadow, iconshadow: c.iconshadow }); c.nativeMenu && window.opera &&
window.opera.version && this.select.addClass("ui-select-nativeonly"); if (this.isMultiple) this.buttonCount = a("<span>").addClass("ui-li-count ui-btn-up-c ui-btn-corner-all").hide().appendTo(b.addClass("ui-li-has-count")); c.disabled && this.disable(); this.select.change(function () { d.refresh() }); this.build()
    }, build: function () {
        var d = this; this.select.appendTo(d.button).bind("vmousedown", function () { d.button.addClass(a.mobile.activeBtnClass) }).bind("focus vmouseover", function () { d.button.trigger("vmouseover") }).bind("vmousemove",
function () { d.button.removeClass(a.mobile.activeBtnClass) }).bind("change blur vmouseout", function () { d.button.trigger("vmouseout").removeClass(a.mobile.activeBtnClass) }).bind("change blur", function () { d.button.removeClass("ui-btn-down-" + d.options.theme) })
    }, selected: function () { return this._selectOptions().filter(":selected") }, selectedIndices: function () { var a = this; return this.selected().map(function () { return a._selectOptions().index(this) }).get() }, setButtonText: function () {
        var d = this, c = this.selected();
        this.button.find(".ui-btn-text").text(function () { if (!d.isMultiple) return c.text(); return c.length ? c.map(function () { return a(this).text() }).get().join(", ") : d.placeholder })
    }, setButtonCount: function () { var a = this.selected(); this.isMultiple && this.buttonCount[a.length > 1 ? "show" : "hide"]().text(a.length) }, refresh: function () { this.setButtonText(); this.setButtonCount() }, open: a.noop, close: a.noop, disable: function () { this._setDisabled(!0); this.button.addClass("ui-disabled") }, enable: function () {
        this._setDisabled(!1);
        this.button.removeClass("ui-disabled")
    }
    }); a(document).bind("pagecreate create", function (d) { a(a.mobile.selectmenu.prototype.options.initSelector, d.target).not(":jqmData(role='none'), :jqmData(role='nojs')").selectmenu() })
})(jQuery);
(function (a) {
    function d(b) { for (; b; ) { var c = a(b); if (c.hasClass("ui-btn") && !c.hasClass("ui-disabled")) break; b = b.parentNode } return b } a.fn.buttonMarkup = function (b) {
        return this.each(function () {
            var d = a(this), e = a.extend({}, a.fn.buttonMarkup.defaults, { icon: d.jqmData("icon"), iconpos: d.jqmData("iconpos"), theme: d.jqmData("theme"), inline: d.jqmData("inline") }, b), g = "ui-btn-inner", h, j; c && c(); if (!e.theme) h = d.closest("[class*='ui-bar-'],[class*='ui-body-']"), e.theme = h.length ? /ui-(bar|body)-([a-z])/.exec(h.attr("class"))[2] :
"c"; h = "ui-btn ui-btn-up-" + e.theme; e.inline && (h += " ui-btn-inline"); if (e.icon) e.icon = "ui-icon-" + e.icon, e.iconpos = e.iconpos || "left", j = "ui-icon " + e.icon, e.iconshadow && (j += " ui-icon-shadow"); e.iconpos && (h += " ui-btn-icon-" + e.iconpos, e.iconpos == "notext" && !d.attr("title") && d.attr("title", d.text())); e.corners && (h += " ui-btn-corner-all", g += " ui-btn-corner-all"); e.shadow && (h += " ui-shadow"); d.attr("data-" + a.mobile.ns + "theme", e.theme).addClass(h); e = ("<D class='" + g + "'><D class='ui-btn-text'></D>" + (e.icon ? "<span class='" +
j + "'></span>" : "") + "</D>").replace(/D/g, e.wrapperEls); d.wrapInner(e)
        })
    }; a.fn.buttonMarkup.defaults = { corners: !0, shadow: !0, iconshadow: !0, inline: !1, wrapperEls: "span" }; var c = function () {
        a(document).bind({ vmousedown: function (b) { var b = d(b.target), c; b && (b = a(b), c = b.attr("data-" + a.mobile.ns + "theme"), b.removeClass("ui-btn-up-" + c).addClass("ui-btn-down-" + c)) }, "vmousecancel vmouseup": function (b) {
            var b = d(b.target), c; b && (b = a(b), c = b.attr("data-" + a.mobile.ns + "theme"), b.removeClass("ui-btn-down-" + c).addClass("ui-btn-up-" +
c))
        }, "vmouseover focus": function (b) { var b = d(b.target), c; b && (b = a(b), c = b.attr("data-" + a.mobile.ns + "theme"), b.removeClass("ui-btn-up-" + c).addClass("ui-btn-hover-" + c)) }, "vmouseout blur": function (b) { var b = d(b.target), c; b && (b = a(b), c = b.attr("data-" + a.mobile.ns + "theme"), b.removeClass("ui-btn-hover-" + c).addClass("ui-btn-up-" + c)) }
        }); c = null
    }; a(document).bind("pagecreate create", function (b) { a(":jqmData(role='button'), .ui-bar > a, .ui-header > a, .ui-footer > a, .ui-bar > :jqmData(role='controlgroup') > a", b.target).not(".ui-btn, :jqmData(role='none'), :jqmData(role='nojs')").buttonMarkup() })
})(jQuery);
(function (a) {
    a.fn.controlgroup = function (d) {
        return this.each(function () {
            function c(a) { a.removeClass("ui-btn-corner-all ui-shadow").eq(0).addClass(g[0]).end().filter(":last").addClass(g[1]).addClass("ui-controlgroup-last") } var b = a(this), f = a.extend({ direction: b.jqmData("type") || "vertical", shadow: !1, excludeInvisible: !0 }, d), e = b.find(">legend"), g = f.direction == "horizontal" ? ["ui-corner-left", "ui-corner-right"] : ["ui-corner-top", "ui-corner-bottom"]; b.find("input:eq(0)").attr("type"); e.length && (b.wrapInner("<div class='ui-controlgroup-controls'></div>"),
a("<div role='heading' class='ui-controlgroup-label'>" + e.html() + "</div>").insertBefore(b.children(0)), e.remove()); b.addClass("ui-corner-all ui-controlgroup ui-controlgroup-" + f.direction); c(b.find(".ui-btn" + (f.excludeInvisible ? ":visible" : ""))); c(b.find(".ui-btn-inner")); f.shadow && b.addClass("ui-shadow")
        })
    }; a(document).bind("pagecreate create", function (d) { a(":jqmData(role='controlgroup')", d.target).controlgroup({ excludeInvisible: !1 }) })
})(jQuery); (function (a) { a(document).bind("pagecreate create", function (d) { a(d.target).find("a").not(".ui-btn, .ui-link-inherit, :jqmData(role='none'), :jqmData(role='nojs')").addClass("ui-link") }) })(jQuery);
(function (a, d) {
    a.fn.fixHeaderFooter = function () { if (!a.support.scrollTop || a.support.touchOverflow && a.mobile.touchOverflowEnabled) return this; return this.each(function () { var c = a(this); c.jqmData("fullscreen") && c.addClass("ui-page-fullscreen"); c.find(".ui-header:jqmData(position='fixed')").addClass("ui-header-fixed ui-fixed-inline fade"); c.find(".ui-footer:jqmData(position='fixed')").addClass("ui-footer-fixed ui-fixed-inline fade") }) }; a.mobile.fixedToolbars = function () {
        function c() {
            !j && h === "overlay" && (g ||
a.mobile.fixedToolbars.hide(!0), a.mobile.fixedToolbars.startShowTimer())
        } function b(a) { var b = 0, c, d; if (a) { d = document.body; c = a.offsetParent; for (b = a.offsetTop; a && a != d; ) { b += a.scrollTop || 0; if (a == c) b += c.offsetTop, c = a.offsetParent; a = a.parentNode } } return b } function f(c) {
            var d = a(window).scrollTop(), e = b(c[0]), f = c.css("top") == "auto" ? 0 : parseFloat(c.css("top")), g = window.innerHeight, h = c.outerHeight(), j = c.parents(".ui-page:not(.ui-page-fullscreen)").length; return c.is(".ui-header-fixed") ? (f = d - e + f, f < e && (f = 0), c.css("top",
j ? f : d)) : c.css("top", j ? d + g - h - (e - f) : d + g - h)
        } if (a.support.scrollTop && (!a.support.touchOverflow || !a.mobile.touchOverflowEnabled)) {
            var e, g, h = "inline", j = !1, k = null, n = !1, q = !0; a(function () {
                var b = a(document), d = a(window); b.bind("vmousedown", function () { q && (k = h) }).bind("vclick", function (b) { q && !a(b.target).closest("a,input,textarea,select,button,label,.ui-header-fixed,.ui-footer-fixed").length && !n && (a.mobile.fixedToolbars.toggle(k), k = null) }).bind("silentscroll", c); (b.scrollTop() === 0 ? d : b).bind("scrollstart", function () {
                    n =
!0; k === null && (k = h); var b = k == "overlay"; if (j = b || !!g) a.mobile.fixedToolbars.clearShowTimer(), b && a.mobile.fixedToolbars.hide(!0)
                }).bind("scrollstop", function (b) { a(b.target).closest("a,input,textarea,select,button,label,.ui-header-fixed,.ui-footer-fixed").length || (n = !1, j && (a.mobile.fixedToolbars.startShowTimer(), j = !1), k = null) }); d.bind("resize", c)
            }); a(".ui-page").live("pagebeforeshow", function (b, c) {
                var d = a(b.target).find(":jqmData(role='footer')"), g = d.data("id"), h = c.prevPage, h = h && h.find(":jqmData(role='footer')"),
h = h.length && h.jqmData("id") === g; g && h && (e = d, f(e.removeClass("fade in out").appendTo(a.mobile.pageContainer)))
            }).live("pageshow", function () { var b = a(this); e && e.length && setTimeout(function () { f(e.appendTo(b).addClass("fade")); e = null }, 500); a.mobile.fixedToolbars.show(!0, this) }); a(".ui-collapsible-contain").live("collapse expand", c); return { show: function (c, d) {
                a.mobile.fixedToolbars.clearShowTimer(); h = "overlay"; return (d ? a(d) : a.mobile.activePage ? a.mobile.activePage : a(".ui-page-active")).children(".ui-header-fixed:first, .ui-footer-fixed:not(.ui-footer-duplicate):last").each(function () {
                    var d =
a(this), e = a(window).scrollTop(), g = b(d[0]), h = window.innerHeight, j = d.outerHeight(), e = d.is(".ui-header-fixed") && e <= g + j || d.is(".ui-footer-fixed") && g <= e + h; d.addClass("ui-fixed-overlay").removeClass("ui-fixed-inline"); !e && !c && d.animationComplete(function () { d.removeClass("in") }).addClass("in"); f(d)
                })
            }, hide: function (b) {
                h = "inline"; return (a.mobile.activePage ? a.mobile.activePage : a(".ui-page-active")).children(".ui-header-fixed:first, .ui-footer-fixed:not(.ui-footer-duplicate):last").each(function () {
                    var c = a(this),
d = c.css("top"), d = d == "auto" ? 0 : parseFloat(d); c.addClass("ui-fixed-inline").removeClass("ui-fixed-overlay"); if (d < 0 || c.is(".ui-header-fixed") && d !== 0) b ? c.css("top", 0) : c.css("top") !== "auto" && parseFloat(c.css("top")) !== 0 && c.animationComplete(function () { c.removeClass("out reverse").css("top", 0) }).addClass("out reverse")
                })
            }, startShowTimer: function () { a.mobile.fixedToolbars.clearShowTimer(); var b = [].slice.call(arguments); g = setTimeout(function () { g = d; a.mobile.fixedToolbars.show.apply(null, b) }, 100) }, clearShowTimer: function () {
                g &&
clearTimeout(g); g = d
            }, toggle: function (b) { b && (h = b); return h === "overlay" ? a.mobile.fixedToolbars.hide() : a.mobile.fixedToolbars.show() }, setTouchToggleEnabled: function (a) { q = a }
            }
        }
    } (); a(document).bind("pagecreate create", function (c) {
        a(":jqmData(position='fixed')", c.target).length && a(c.target).each(function () {
            if (!a.support.scrollTop || a.support.touchOverflow && a.mobile.touchOverflowEnabled) return this; var b = a(this); b.jqmData("fullscreen") && b.addClass("ui-page-fullscreen"); b.find(".ui-header:jqmData(position='fixed')").addClass("ui-header-fixed ui-fixed-inline fade");
            b.find(".ui-footer:jqmData(position='fixed')").addClass("ui-footer-fixed ui-fixed-inline fade")
        })
    })
})(jQuery);
(function (a) {
    a.mobile.touchOverflowEnabled = !1; a.mobile.touchOverflowZoomEnabled = !1; a(document).bind("pagecreate", function (d) {
        a.support.touchOverflow && a.mobile.touchOverflowEnabled && (d = a(d.target), d.is(":jqmData(role='page')") && d.each(function () {
            var c = a(this), b = c.find(":jqmData(role='header'), :jqmData(role='footer')").filter(":jqmData(position='fixed')"), d = c.jqmData("fullscreen"), e = b.length ? c.find(".ui-content") : c; c.addClass("ui-mobile-touch-overflow"); e.bind("scrollstop", function () {
                e.scrollTop() >
0 && window.scrollTo(0, a.mobile.defaultHomeScroll)
            }); b.length && (c.addClass("ui-native-fixed"), d && (c.addClass("ui-native-fullscreen"), b.addClass("fade in"), a(document).bind("vclick", function () { b.removeClass("ui-native-bars-hidden").toggleClass("in out").animationComplete(function () { a(this).not(".in").addClass("ui-native-bars-hidden") }) })))
        }))
    })
})(jQuery);
(function (a, d) {
    function c() { var b = a("meta[name='viewport']"); b.length ? b.attr("content", b.attr("content") + ", user-scalable=no") : a("head").prepend("<meta>", { name: "viewport", content: "user-scalable=no" }) } var b = a("html"); a("head"); var f = a(d); a(d.document).trigger("mobileinit"); if (a.mobile.gradeA()) {
        if (a.mobile.ajaxBlacklist) a.mobile.ajaxEnabled = !1; b.addClass("ui-mobile ui-mobile-rendering"); var e = a("<div class='ui-loader ui-body-a ui-corner-all'><span class='ui-icon ui-icon-loading spin'></span><h1></h1></div>");
        a.extend(a.mobile, { showPageLoadingMsg: function () { if (a.mobile.loadingMessage) { var c = a("." + a.mobile.activeBtnClass).first(); e.find("h1").text(a.mobile.loadingMessage).end().appendTo(a.mobile.pageContainer).css({ top: a.support.scrollTop && f.scrollTop() + f.height() / 2 || c.length && c.offset().top || 100 }) } b.addClass("ui-loading") }, hidePageLoadingMsg: function () { b.removeClass("ui-loading") }, initializePage: function () {
            var b = a(":jqmData(role='page')"); b.length || (b = a("body").wrapInner("<div data-" + a.mobile.ns + "role='page'></div>").children(0));
            b.add(":jqmData(role='dialog')").each(function () { var b = a(this); b.jqmData("url") || b.attr("data-" + a.mobile.ns + "url", b.attr("id") || location.pathname + location.search) }); a.mobile.firstPage = b.first(); a.mobile.pageContainer = b.first().parent().addClass("ui-mobile-viewport"); f.trigger("pagecontainercreate"); a.mobile.showPageLoadingMsg(); !a.mobile.hashListeningEnabled || !a.mobile.path.stripHash(location.hash) ? a.mobile.changePage(a.mobile.firstPage, { transition: "none", reverse: !0, changeHash: !1, fromHashChange: !0 }) :
f.trigger("hashchange", [!0])
        }
        }); a.support.touchOverflow && a.mobile.touchOverflowEnabled && !a.mobile.touchOverflowZoomEnabled && c(); a.mobile._registerInternalEvents(); a(function () { d.scrollTo(0, 1); a.mobile.defaultHomeScroll = !a.support.scrollTop || a(d).scrollTop() === 1 ? 0 : 1; a.mobile.autoInitializePage && a.mobile.initializePage(); f.load(a.mobile.silentScroll) })
    }
})(jQuery, this);
