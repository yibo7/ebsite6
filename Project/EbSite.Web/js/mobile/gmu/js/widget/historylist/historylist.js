(function(b,a){b.define("Historylist",{options:{container:document.body,deleteSupport:true,items:[]},template:{wrap:'<ul class="ui-historylist">',item:'<li data-id="<%=id%>"><p class="ui-historylist-itemwrap"><span class="ui-historylist-item"><%=context%></span></p></li>',clear:'<p class="ui-historylist-clear">\u6e05\u7a7a\u641c\u7d22\u5386\u53f2</p>'},_init:function(){var d=this,c=d._options;d.$el=c.container=c.container||document.body;d.items=[];d.on("ready",function(){d._bindUI()});d.on("itemDelete",function(){if(d.items.length===0){d.hide()}})},_create:function(){var d=this,c=d._options;d.$el.hide();d.$wrap=a(d.tpl2html("wrap")).appendTo(c.container);d.$clear=a(d.tpl2html("clear")).appendTo(c.container);!d._options.deleteSupport&&d.$clear.hide();d.addItems(c.items);d.show()},_filterItemsById:function(e,d){var c=this;c.items.forEach(function(g,f){if(g.id===e){d.call(c,g,f);return}})},_bindUI:function(){var o=this,m,h,q,n,j,f=false,r,e,i,d,g,l,k,p,c;o.$clear.on("tap"+o.eventNs,function(s){setTimeout(function(){b.Dialog({closeBtn:false,buttons:{"\u6e05\u7a7a":function(){o.clear();this.destroy()},"\u53d6\u6d88":function(){this.destroy()}},title:"\u6e05\u7a7a\u5386\u53f2",content:"<p>\u662f\u5426\u6e05\u7a7a\u641c\u7d22\u5386\u53f2\uff1f</p>",open:function(){this._options._wrap.addClass("ui-historylist-dialog")}})},10);s.preventDefault();s.stopPropagation()});o.$wrap.on("tap"+o.eventNs,function(s){if(o._options.deleteSupport){return}h=a(s.target);if(!h.hasClass("ui-historylist-itemwrap")&&!(h=h.parents(".ui-historylist-itemwrap")).length){h=null;return}q=h.parent().attr("data-id");o._filterItemsById(q,function(t){o.trigger("itemTouch",{item:t.value})})});o.$wrap.on("touchstart"+o.eventNs,function(s){if(!o._options.deleteSupport){return}m=s.touches[0];h=a(m.target);n=s.timeStamp;i=e=parseInt(m.pageX);g=d=parseInt(m.pageY);p=false;f=false;if(!h.hasClass("ui-historylist-itemwrap")&&!(h=h.parents(".ui-historylist-itemwrap")).length){h=null;return}h.addClass("ui-historylist-ontap");h.css("width",h.width()-parseInt(h.css("border-left-width"))-parseInt(h.css("border-right-width")))});o.$wrap.on("touchmove"+o.eventNs,function(s){if(!h){return}i=s.touches[0].pageX;g=s.touches[0].pageY;r===undefined&&(r=setTimeout(function(){if(Math.abs(g-d)>Math.abs(i-e)/2){f=false}else{f=true}},10));p=p||((i-e>=3||g-d>=3)?true:false);if(!f){setTimeout(function(){h&&h.removeClass("ui-historylist-ontap")},150);return}k=(i-e)/o.$wrap.width();h.addClass("ui-historylist-itemmoving");h.removeClass("ui-historylist-ontap");h.css("-webkit-transform","translate3d("+(i-e)+"px, 0, 0)");h.css("opacity",1-k);s.preventDefault();s.stopPropagation()});o.$wrap.on("touchend"+o.eventNs+" touchcancel"+o.eventNs,function(s){if(!h){return}clearTimeout(r);r=undefined;q=h.parent().attr("data-id");j=s.timeStamp;l=(i-e)/(j-n);c=Math.abs(i-e);h.removeClass("ui-historylist-ontap");h.removeClass("ui-historylist-itemmoving");if(((c<o.$wrap.width()/3&&Math.abs(l)>0.1)&&f)||(c>=o.$wrap.width()/3&&f)){o.removeItem(q,h)}else{h.css("width","auto");h.css("-webkit-transform","translate3d(0, 0, 0)");h.css("opacity",1);!p&&c<3&&o._filterItemsById(q,function(t){o.trigger("itemTouch",{item:t.value})})}h=null})},show:function(){var c=this;if(c.items.length===0){return}if(c.sync===false){c.$wrap.html("");c.addItems(c.syncitems);c.sync=true}c.$el.show();c.isShow=true;return c},hide:function(){var c=this;c.$el.hide();c.isShow=false;return c},_getItemId:function(){var c=this;c._itemId===undefined?(c._itemId=1):++c._itemId;return"__dd__"+c._itemId},_getFormatItem:function(d){var c=this;if(Object.prototype.toString.call(d)==="[object String]"){return{context:d,value:d,id:c._getItemId()}}else{return{context:d.context||d.value,value:d.value||d.context,id:c._getItemId()}}},addItem:function(d){var c=this,d=c._getFormatItem(d);c.items.forEach(function(f,e){if(f.value===d.value){c.items.splice(e,1);a(c.$wrap.children()[e]).remove();return}});c.$wrap.children().length===0?c.$wrap.append(c.tpl2html("item",d)):a(c.tpl2html("item",d)).insertBefore(c.$wrap.children()[0]);c.items.unshift(d);return c},addItems:function(c){var d=this;c.forEach(function(e){d.addItem(e)});return d},update:function(c){var d=this;if(d.isShow){d.$wrap.html("");d.addItems(c);d.sync=true}else{d.syncitems=c;d.sync=false}return d},removeItem:function(g,f){var e=this,h,d,c;d=f.css("-webkit-transform");c=/translate3d\((.*?),.*/.test(d)?RegExp.$1:0;h=parseInt(c,10)>=0?f.width():-f.width();f.css("-webkit-transform","translate3d("+h+"px, 0, 0)");f.on("transitionEnd"+e.eventNs+" webkitTransitionEnd"+e.eventNs,function(){f.parent().remove();e._filterItemsById(g,function(j,i){e.items.splice(i,1);e.trigger("itemDelete",{item:j.value})})})},clear:function(){var c=this;c.$wrap.html("");c.items=[];c.sync=true;c.hide();c.trigger("clear");return c},disableDelete:function(){var c=this;c._options.deleteSupport=false;c.$clear.hide();return c},enableDelete:function(){var c=this;c._options.deleteSupport=true;c.$clear.show();return c},destroy:function(){var c=this;c.$wrap.off(c.eventNs);c.$clear.off(c.eventNs);c.$wrap.remove();c.$clear.remove();return c.$super("destroy")}})})(gmu,gmu.$);