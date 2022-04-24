/*
回调方法
function funback(id, txt, subid, subtxt)
*/

(function ($) {

    $.suggest = function (input, options, funback) {


        var $input = $(input).attr("autocomplete", "off");
        var $results = $(document.createElement("div"));

        var timeout = false; 	// hold timeout ID for suggestion results to appear	定义定时触发事件ID
        var prevLength = 0; 		// 文本框最后一次输入值的长度 $input.val()
        var cache = []; 			// 缓存数据 数组
        var cacheSize = 0; 		// 缓存大小（1条记录为1）

        var hideTimeout = false;

        if (options.valueids != null && options.valueids != undefined) {
            var modifyvalue = $("#" + options.valueids.txtid).val();
            if (modifyvalue != "") {
                $input.val(modifyvalue); //默认值 
            }
        }
        else {
            $input.val(options.defaultValue);
            $input.addClass(options.inputDefaultValueClass); //默认值 且加上默认值样式
        }
        //        $input.val(options.defaultValue).addClass(options.inputDefaultValueClass); //默认值 且加上默认值样式


        $input.attr("myid", " ").attr("carid", " ").attr("cartxt", " "); //添加自定义属性 供存值 经测试空值必须为" " 非""(中间需要空格 否则赋值不上，原因未知)

        $results.addClass(options.resultsClass).appendTo('body');

        resetPosition();
        $(window)
				.load(resetPosition)		// 当用户改变网页大小时触发
				.resize(resetPosition);

        //绑定值
        var tids = options.valueids;
        var $tMyid, $txtID, $carID, $carName;
        var $stfb = true;
        if (tids != null && tids != undefined) {
            $tMyid = $("#" + tids.acid);
            $txtID = $("#" + tids.txtid);
            $carID = $("#" + tids.aclassid);
            $carName = $("#" + tids.aclasstxt);
        }
        else {
            $stfb = false;
            $tMyid = null;
            $txtID = null;
            $carID = null;
            $carName = null;
        }

        //失去焦点事件
        $input.blur(function () {
            if ($.trim($input.val()) == '')
                $input.val(options.defaultValue).addClass(options.inputDefaultValueClass);

            hideTimeout = setTimeout(function () {
                //判断是否是未选取就离开（选取时会立即关闭层 故在200ms后能通过层的显示与否来判断）
                if ($results.is(':visible')) {
                    if (options.openAutoSelect) {//当未选取时 自动选择开启时 自动填充第一项为选中项
                        $currentResult = $results.children("ul").children('li:first-child');

                        //$input.val($currentResult.attr("txt"));
                        $input.val($currentResult.attr("txt"));
                        $input.attr("myid", $currentResult.attr("id"))
                            .attr("carid", $currentResult.attr("carid"))
                            .attr("cartxt", $currentResult.attr("cartxt"));
                        $input.removeClass(options.inputDefaultValueClass); //选择指定项后 去除默认值样式
                    }
                    $results.hide("fast");
                }
            }, 200); //延迟200MS关闭提示层，必须延迟 不能立即关闭（当键盘或鼠标选取值时以提示层是否存在来作为条件的，固离开立即关闭将获取不到选取值）

        });




        //获得焦点事件
        $input.focus(function () {
            resetPosition();
            if ($.trim($(this).val()) == options.defaultValue)
                $(this).val('').removeClass(options.inputDefaultValueClass);
            //alert(options.openFocusTip);
            if (options.openFocusTip) {
                if (timeout)
                    clearTimeout(timeout);
                timeout = setTimeout(suggest, options.delay);
            }
        });

        $input.click(function () {
            //
        });

        //绑定热门按钮事件
        if (options.hotBtnID.length && options.hotList.length) {
            var hotBtnID = options.hotBtnID;
            hotBtnID = (hotBtnID.substr(0, 1) != "#") ? "#" + hotBtnID : hotBtnID;

            $(hotBtnID).click(function () {
                if (hideTimeout)
                    clearTimeout(hideTimeout); //清除离开时自动隐藏结果层
                //判断当下是否是热门结果 是则关闭
                if ($results.is(':visible') && $results.hasClass(options.hotResultsClass)) {
                    $results.hide();
                }
                else {
                    if ($results.hasClass(options.resultsClass)) {
                        $results.removeClass(options.resultsClass).addClass(options.hotResultsClass); // 更改提示样式 为热门提示样式
                        var items = getHotItems(options.hotList);
                        displayItems(items);
                    }
                    else {
                        $results.show();
                    }
                }
            });
        }

        // 需要 bgiframe 插件 在IE下防止下拉框穿透等BUG
        try { $results.bgiframe(); } catch (e) { }

        // 键盘按下事件
        $input.keyup(processKey);

        function resetPosition() {
            // 需要引用 jquery.dimension 插件
            var offset = $input.offset();
            $results.css({
                top: (offset.top + input.offsetHeight) + 'px',
                left: offset.left + 'px'
            });
        }

        //截获按键
        function processKey(e) {

            // handling up/down/escape requires results to be visible
            // handling enter/tab requires that AND a result to be selected
            if ((/27$|38$|40$/.test(e.keyCode) && $results.is(':visible')) ||
					(/^13$|^9$/.test(e.keyCode) && getCurrentResult())) {

                //阻止冒泡传递
                //通知 Web 浏览器不要执行与事件关联的默认动作 （防止键冲突）
                if (e.preventDefault)
                    e.preventDefault();
                if (e.stopPropagation)
                    e.stopPropagation(); //阻止它被分派到其他 Document 节点

                e.cancelBubble = true; //设置为取消冒泡传递
                e.returnValue = false;

                switch (e.keyCode) {

                    case 38: // up
                        prevResult();
                        break;

                    case 40: // down
                        nextResult();
                        break;

                    case 9:  // tab
                    case 13: // return
                        selectCurrentResult();
                        break;

                    case 27: //	escape
                        $results.hide();
                        break;
                }

            }
            else if ($input.val().length != prevLength) {
                if (timeout)
                    clearTimeout(timeout);
                timeout = setTimeout(suggest, options.delay);
                prevLength = $input.val().length;

            }
        }

        //相关按键触发提示
        function suggest() {
            var q = $.trim($input.val());
            if (q.length >= options.minchars) {
                $results.removeClass(options.hotResultsClass).addClass(options.resultsClass); // 更改提示样式 为普通提示样式

                cached = checkCache(q);
                if (cached) {
                    displayItems(cached['items']);
                }
                else {

                    //==============ajax 获取数据 
                    //                    $.get(options.source, { q: q }, function(txt) {
                    //                        $results.hide();
                    //                        var items = parseTxt(txt, q);
                    //                        displayItems(items);
                    //                        addToCache(q, items, txt.length);
                    //                    });
                    //==================

                    //直接数据源
                    $results.hide();
                    var items = getItems(options.source, q);
                    displayItems(items);
                    addToCache(q, items, options.source.length);
                }
            }
            else if (!q.length && options.emptyDisplayHot && options.hotList.length) {//当查询字符串为空时 调用热门提示
                $results.removeClass(options.resultsClass).addClass(options.hotResultsClass); // 更改提示样式 为热门提示样式
                var items = getHotItems(options.hotList);
                displayItems(items);
            }
            else {
                $results.hide();
            }
        }

        //检查缓存 存在返回该缓存
        function checkCache(q) {

            for (var i = 0; i < cache.length; i++) {
                if (cache[i]['q'] == q) {
                    cache.unshift(cache.splice(i, 1)[0]); //unshift() 方法将把它的参数插入arrayObject 的头部 splice() 方法用于插入、删除或替换数组的元素。
                    return cache[0];
                }
            }
            return false;
        }

        //增加缓存
        function addToCache(q, items, size) {
            //当缓存数组存在 且 加上需要缓存的数据大于设定最大值时。删除缓存数组最后一个元素，且重置新缓存数组大小
            while (cache.length && (cacheSize + size > options.maxCacheSize)) {
                var cached = cache.pop(); //pop() 方法将删除 arrayObject 的最后一个元素，把数组长度减 1，并且返回它删除的元素的值
                cacheSize -= cached['size'];
            }
            cache.push({
                q: q,
                size: size,
                items: items
            });
            cacheSize += size;
        }

        //得到热门数据集合
        function getHotItems(jsonArr) {
            if (!jsonArr)
                return;

            var items = [];
            $.each(jsonArr, function (i, n) {
                if (i > options.hotMax - 1) {
                    return false; //跳出循环
                }
                //items[items.length] = "<li id='" + n.id + "' key='" + n.key + "' fullcode='" + n.fullcode + "' shortcode='" + n.shortcode + "'>" + n.key + "</li>";
                items[items.length] = { "id": n.id, "txt": n.txt, "carid": n.carid, "cartxt": n.cartxt, "displaystring": n.txt, "displaycode": n.pinyin };

            });
            return items;
        }

        //得到提示项集合
        function getItems(jsonArr, q) {

            var bigItems = []; //声明重要项数组（重要项将置顶于提示层）
            var items = [];
            var test = false;
            $.each(jsonArr, function (i, n) {

                var reg = new RegExp('.*' + q + '.*$', 'im');
                var reg1 = new RegExp(q, 'im'); // exec

                var strInKey = options.source[i].txt;
                var displayCode = options.source[i].pinyin;
                var flag = false;

                if (reg.test(options.source[i].txt)) {
                    strInKey = options.source[i].txt.replace(reg1, "<span class=\"" + options.matchClass + "\">" + reg1.exec(options.source[i].txt) + "</span>");
                    flag = true;

                }

                if (reg.test(options.source[i].pinyin)) {
                    displayCode = options.source[i].pinyin.replace(reg1, "<span class=\"" + options.matchClass + "\">" + reg1.exec(options.source[i].pinyin) + "</span>");
                    flag = true;
                }

                if (reg.test(options.source[i].py)) {
                    displayCode = options.source[i].py.replace(reg1, "<span class=\"" + options.matchClass + "\">" + reg1.exec(options.source[i].py) + "</span>");
                    flag = true;
                }

                if (flag) {

                    var tempItem = { "id": n.id, "txt": n.txt, "carid": n.carid, "cartxt": n.cartxt, "displaystring": strInKey, "displaycode": displayCode };

                    if (q.toLowerCase() == n.txt || q.toLowerCase() == n.pinyin.toLowerCase() || q.toLowerCase() == n.py.toLowerCase()) {
                        //判断是否重要项
                        if (isBigItem(n.txt)) {
                            bigItems[bigItems.length] = tempItem; //如果是重要项 
                        }
                        else {
                            //alert(n.key);
                            items.unshift(tempItem); //当完全相等时且非重要项时立即插入 将其放入第一行
                        }
                    }
                    else {
                        items[items.length] = tempItem;
                    }
                }

            });
            //alert(bigItems.length);
            if (bigItems.length > 0)
                items = bigItems.concat(items); //找到的大站加入到数组之前

            items = items.splice(0, options.itemsMax);

            return items;
        }

        //是否重要项
        function isBigItem(key) {
            var bigItemsSrc = options.bigItemsSource;
            if (bigItemsSrc != null && bigItemsSrc != undefined) {
                for (var j = 0; j < bigItemsSrc.length; j++) {
                    if (key == bigItemsSrc[j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        //显示智能提示结果
        function displayItems(items) {

            $input.attr("txt", " ").attr("myid", " ").attr("carid", " ").attr("cartxt", " "); //重置各属性值 经测试空值必须为" " 非""(中间需要空格 否则赋值不上，原因未知)
            if (!items)
                return;

            if (!items.length) {
                $results.hide();
                return;
            }

            var q = $.trim($input.val());
            var headerStr = '';
            var footerStr = '';
            if (!$.trim($input.val()).length) {
                if (options.hotHeaderText)
                    headerStr += "<div class='" + options.hotHeaderClass + "'>" + options.hotHeaderText + "</div>";
                if (options.hotHeaderText)
                    footerStr += "<div class='" + options.hotFooterClass + "'>" + options.hotFooterText + "</div>";
            }
            else {
                if (options.headerText)
                    headerStr += "<div class='" + options.headerClass + "'>" + options.headerText + "</div>";
                if (options.footerText)
                    footerStr += "<div class='" + options.footerClass + "'>" + options.footerText + "</div>";
            }

            var html = '';
            html += headerStr;
            html += "<ul>";

            for (var i = 0; i < items.length; i++) {
                //                html += "<li id='" + items[i].id + "' txt='" + items[i].txt + "' carid='" + items[i].carid + "' cartxt='" + items[i].cartxt + "'>" + items[i].displaystring + "<em>" + items[i].displaycode + "</em></li>";
                html += "<li id='" + items[i].id + "' txt='" + items[i].txt + "' carid='" + items[i].carid + "' cartxt='" + items[i].cartxt + "'>" + items[i].displaystring + "</li>";
                if (q.toLowerCase() == items[i].txt || q.toLowerCase() == items[i].carid || q.toLowerCase() == items[i].cartxt) {
                    $input.attr("txt", items[i].txt).attr("myid", items[i].id).attr("carid", items[i].carid).attr("cartxt", items[i].cartxt);
                }
            }
            html += "</ul>";
            html += footerStr;
            $results.html(html).show();

            var selectClass = $results.hasClass(options.resultsClass) ? options.selectClass : options.hotSelectClass;
            $results.children("ul")
					.children('li')
					.mouseover(function () {
					    $results.children("ul").children('li').removeClass(selectClass);
					    $(this).addClass(selectClass);
					})
					.click(function (e) {
					    e.preventDefault();
					    e.stopPropagation();
					    selectCurrentResult();
					});

        }

        //得到选中结果
        function getCurrentResult() {
            if (!$results.is(':visible'))
                return false;
            var selectClass = $results.hasClass(options.resultsClass) ? options.selectClass : options.hotSelectClass;

            var $currentResult = $results.children("ul").children('li.' + selectClass);

            if (!$currentResult.length)
                $currentResult = false;

            if ($currentResult != null && $currentResult != undefined && $currentResult != false) {
                //控件属性赋值
                var $id = $currentResult.attr("id");
                var $txt = $currentResult.attr("txt");
                var $subid = $currentResult.attr("carid");
                var $subtxt = $currentResult.attr("cartxt");
                if ($stfb) {
                    $tMyid.val($id);
                    $txtID.val($txt);
                    $carID.val($subid);
                    $carName.val($subtxt);
                }
                else {
                    $(input).attr("tid", $id);
                }
            }
            return $currentResult;

        }

        //选择结果 （回车）
        function selectCurrentResult() {
            $currentResult = getCurrentResult();

            if ($currentResult) {

                $input.val($currentResult.attr("txt"));
                $input.attr("txt", $currentResult.attr("txt"))
                .attr("myid", $currentResult.attr("id"))
                .attr("carid", $currentResult.attr("carid"))
                .attr("cartxt", $currentResult.attr("cartxt"));

                $input.removeClass(options.inputDefaultValueClass); //选择指定项后 去除默认值样式


                $results.hide();

                if (options.onSelect) {
                    //options.onSelect.apply($input[0]);
                    if ($stfb) {
                        $tMyid.val($currentResult.attr("id"));
                        $carID.val($currentResult.attr("carid"));
                        $carName.val($currentResult.attr("cartxt"));
                    }
                    else {
                        $(input).attr("tid", $currentResult.attr("id"));
                    }
                    options.onSelect.apply($input[0], [{ "txt": $currentResult.attr("txt"), "myid": $currentResult.attr("id"), "carid": $currentResult.attr("carid"), "cartxt": $currentResult.attr("cartxt")}]);
                }

                //alert($input.attr("txt"))

                //控件属性赋值
                var $id = $currentResult.attr("id");
                var $txt = $currentResult.attr("txt");
                var $subid = $currentResult.attr("carid");
                var $subtxt = $currentResult.attr("cartxt");
                if (funback != null && funback != undefined)
                    funback($id, $txt, $subid, $subtxt);
            }
        }
        //下一个结果 （下键）
        function nextResult() {
            var selectClass = $results.hasClass(options.resultsClass) ? options.selectClass : options.hotSelectClass;

            $currentResult = getCurrentResult();

            if ($currentResult)
                $currentResult.removeClass(selectClass).next().addClass(selectClass);
            else
                $results.children("ul").children('li:first-child').addClass(selectClass);

        }
        //上一个结果 （上键）
        function prevResult() {
            var selectClass = $results.hasClass(options.resultsClass) ? options.selectClass : options.hotSelectClass;
            $currentResult = getCurrentResult();
            if ($currentResult)
                $currentResult
						.removeClass(selectClass)
						.prev()
							.addClass(selectClass);
            else
                $results.children("ul").children('li:last-child').addClass(selectClass);
        }
    };

    //source 数据源（供智能提示）options 相关配置 json格式
    $.fn.suggest = function (source, options, funback) {

        if (!source)
            return;

        options = options || {};
        options.source = source;
        options.delay = options.delay || 100; //延时
        options.valueids = options.valueids;  //选择的值集合

        options.minchars = options.minchars || 1; //触发提示查询字符串的最小长度
        options.onSelect = options.onSelect || false; //选择后触发事件
        options.maxCacheSize = options.maxCacheSize || 65536; // 最大缓存值（1条记录为1）

        options.defaultValue = options.defaultValue || ""; //文本框为默认值
        options.inputDefaultValueClass = options.inputDefaultValueClass || "ac_inputDefaultValueClass"; //文本框为默认值时样式

        options.itemsMax = options.itemsMax || 15; //提示项最大记录数

        options.resultsClass = options.resultsClass || 'ac_results'; //普通显示区 样式
        options.selectClass = options.selectClass || 'ac_over'; //选中行 样式
        options.headerClass = options.headerClass || 'ac_header'; //提示层头栏 样式
        options.footerClass = options.footerClass || 'ac_footer'; //提示层脚栏 样式
        options.headerText = options.headerText; //头栏文字
        options.footerText = options.footerText; //脚栏文本

        //== hot 相关配置
        options.hotList = options.hotList || []; //热门数据源 当文本框为空时提示内容
        options.hotMax = options.hotMax || 10; //显示热门记录数最大值。
        options.hotResultsClass = options.hotResultsClass || 'ac_hotResults'; //热门显示区 样式
        options.hotSelectClass = options.hotSelectClass || 'ac_hotOver'; //热门 选中行 CSS
        options.hotHeaderClass = options.hotHeaderClass || 'ac_hotHeader'; //热门 提示层头栏 样式
        options.hotFooterClass = options.hotFooterClass || 'ac_hotFooter'; //热门 提示层头栏 样式
        options.hotHeaderText = options.hotHeaderText; //热门 头栏文字
        options.hotFooterText = options.hotFooterText; //热门 脚栏文本
        //== hot 相关配置 end

        options.matchClass = options.matchClass || 'ac_match'; //匹配上字符样式

        options.openFocusTip = options.openFocusTip || false; // 是否打开焦点提示
        options.openAutoSelect = options.openAutoSelect || false; //当未选取值并有提示内容时离开文本框 是否自动填充第一项为选中值
        options.bigItemsSource = options.bigItemsSource; // 大站数组|点击高的车站


        options.emptyDisplayHot = options.emptyDisplayHot || false; //空值时是否显示热门

        options.hotBtnID = options.hotBtnID || ""; //显示/关闭热门按钮ID

        this.each(function () {
            new $.suggest(this, options, funback);
        });

        return this;
    };


})(jQuery);