
//常用插件的定义
var plugins = {
    Code: { c: 'btnCode', t: '插入代码', h: 1, e: function () {
        var _this = this;
        var htmlCode = '<div><select id="xheCodeType"><option value="html">HTML/XML</option><option value="js">Javascript</option><option value="css">CSS</option><option value="php">PHP</option><option value="java">Java</option><option value="py">Python</option><option value="pl">Perl</option><option value="rb">Ruby</option><option value="cs">C#</option><option value="c">C++/C</option><option value="vb">VB/ASP</option><option value="">其它</option></select></div><div><textarea id="xheCodeValue" wrap="soft" spellcheck="false" style="width:300px;height:100px;" /></div><div style="text-align:right;"><input type="button" id="xheSave" value="确定" /></div>';
        var jCode = $(htmlCode), jType = $('#xheCodeType', jCode), jValue = $('#xheCodeValue', jCode), jSave = $('#xheSave', jCode);
        jSave.click(function () {
            _this.loadBookmark();
            _this.pasteText('[code=' + jType.val() + ']\r\n' + jValue.val() + '\r\n[/code]');
            _this.hidePanel();
            return false;
        });
        _this.saveBookmark();
        _this.showDialog(jCode);
    }},
    Flv: { c: 'btnFlv', t: '插入Flv视频', h: 1, e: function () {
        var _this = this;
        var htmlFlv = '<div>Flv文件:&nbsp; <input type="text" id="xheFlvUrl" value="http://" class="xheText" /></div><div>宽度高度: <input type="text" id="xheFlvWidth" style="width:40px;" value="480" /> x <input type="text" id="xheFlvHeight" style="width:40px;" value="400" /></div><div style="text-align:right;"><input type="button" id="xheSave" value="确定" /></div>';
        var jFlv = $(htmlFlv), jUrl = $('#xheFlvUrl', jFlv), jWidth = $('#xheFlvWidth', jFlv), jHeight = $('#xheFlvHeight', jFlv), jSave = $('#xheSave', jFlv);
        jSave.click(function () {
            _this.loadBookmark();
            _this.pasteText('[flv=' + jWidth.val() + ',' + jHeight.val() + ']' + jUrl.val() + '[/flv]');
            _this.hidePanel();
            return false;
        });
        _this.saveBookmark();
        _this.showDialog(jFlv);
    }},
map: { c: 'btnMap', t: '插入Google地图', e: function () {

    var _this = this;
    _this.saveBookmark();
    var _Url = SiteConfigs.UrlIISPath + 'js/plugin/editbox/xheditor_plugins/googlemap/googlemap.html';
    _this.showIframeModal('Google 地图', _Url, function(v) {
        _this.loadBookmark();
        _this.pasteHTML('<img src="' + v + '" />');
    }, 538, 404);
    
    }
},
mapbaidu: {
    c: 'btnMapBaidu', t: '插入Baidu地图', e: function () {

        var _this = this;
        _this.saveBookmark();
        var _Url = SiteConfigs.UrlIISPath + 'js/plugin/editbox/xheditor_plugins/baidumap/show.html';
        _this.showIframeModal('插入Baidu地图', _Url, function (v) {
            _this.loadBookmark();
            _this.pasteHTML('<img src="' + v + '" />');
        }, 538, 404);

    }
},
searchpic: {
    c: 'btnSearchpic', t: '搜索网络图片', e: function () {

        var _this = this;
        _this.saveBookmark();
        var _Url = SiteConfigs.UrlIISPath + 'js/plugin/editbox/xheditor_plugins/searchpic/show.html';
        _this.showIframeModal('搜索网络图片', _Url, function (v) {
            _this.loadBookmark();
            var sHtml = "";
            for (var i = 0; i < v.length; i++) {
                sHtml += "<img src=\"" + v[i] + "\" /></br>";
            }
            _this.pasteHTML(sHtml);
        }, 538, 404);

    }
},
addPagesLine: {
    c: 'btnAddPagesLine', t: '插入分页符', e: function () {

        var _this = this;
        _this.saveBookmark();
        _this.pasteHTML("_ueditor_page_break_tag_");

    }
},
addEba: {
    c: 'btnaddEba', t: '插入定位符', e: function () {
        
        var _this = this;
        _this.saveBookmark();
        var ebatext = _this.getSelect('text');
        if (ebatext.indexOf("[eba]") == -1) {
            _this.pasteHTML("[eba]" + ebatext + ["[/eba]"]);
        }
        else {
            ebatext = ebatext.replace("[eba]", "").replace("[/eba]", "");
            _this.pasteHTML(ebatext);
        }

    }
},
saveData: {
    c: 'saveData', t: '保存到本地', e: function () {

        var _this = this;
        _this.saveBookmark();

        if (window.localStorage) { //支持html本地存储

            var html =  _this.getSource();
            localStorage.setItem(_this,html);
            

        }

    }
},
restoreUpData: {
    c: 'restoreUpData', t: '还原最后一次数据', e: function () {

        var _this = this;
        _this.saveBookmark();
        
        if (window.localStorage) { //支持html本地存储
            
            var html = localStorage.getItem(_this);
            _this.setSource(html);

        }

    }
}

};


var emots = {
    msn: { name: 'MSN', count: 40, width: 22, height: 22, line: 8 },
    pidgin: { name: 'Pidgin', width: 22, height: 25, line: 8, list: { smile: '微笑', cute: '可爱', wink: '眨眼', laugh: '大笑', victory: '胜利', sad: '伤心', cry: '哭泣', angry: '生气', shout: '大骂', curse: '诅咒', devil: '魔鬼', blush: '害羞', tongue: '吐舌头', envy: '羡慕', cool: '耍酷', kiss: '吻', shocked: '惊讶', sweat: '汗', sick: '生病', bye: '再见', tired: '累', sleepy: '睡了', question: '疑问', rose: '玫瑰', gift: '礼物', coffee: '咖啡', music: '音乐', soccer: '足球', good: '赞同', bad: '反对', love: '心', brokenheart: '伤心'} },
    ipb: { name: 'IPB', width: 20, height: 25, line: 8, list: { smile: '微笑', joyful: '开心', laugh: '笑', biglaugh: '大笑', w00t: '欢呼', wub: '欢喜', depres: '沮丧', sad: '悲伤', cry: '哭泣', angry: '生气', devil: '魔鬼', blush: '脸红', kiss: '吻', surprised: '惊讶', wondering: '疑惑', unsure: '不确定', tongue: '吐舌头', cool: '耍酷', blink: '眨眼', whistling: '吹口哨', glare: '轻视', pinch: '捏', sideways: '侧身', sleep: '睡了', sick: '生病', ninja: '忍者', bandit: '强盗', police: '警察', angel: '天使', magician: '魔法师', alien: '外星人', heart: '心动'} }
}



function OnFileUpload(arrMsg, obID) {
    var sParentSplit = "}*{";
    var sSubSplit = "*";
    var i, msg; for (i = 0; i < arrMsg.length; i++) {
        msg = arrMsg[i];
        var obJson = msg.id + sSubSplit + msg.url + sSubSplit + msg.localname;
        var ob = $("#" + obID);
        if (ob.val() != "") {
            var oldVal = ob.val();

            ob.val(oldVal + sParentSplit + obJson);
        }
        else {
            ob.val(obJson);
        }
        //alert(obID+"--"+ ob.val());
        //$("#uploadList").append('<option value="' + msg.id + '">' + msg.localname + '</option>');
    }
}

function InitUpload(objebox, imgpram, linkpram, flashpram, mediapram, valstrimg, valstrlink, valstrflash, valstrmediap, allpram, urlreg)
{
    var Url = SiteConfigs.UrlIISPath + "ajaxget/uploadcheck.ashx?" + Math.random();

    run_ajax_async(Url, "", function (msg) {
         
        if (msg != undefined && msg == "1") {
            
            var upapi = SiteConfigs.UrlIISPath + "ajaxget/upsinglefile.ashx?" + allpram + "&ext=";
            objebox.settings.upImgUrl = upapi + imgpram + "&valstr=" + valstrimg;
            objebox.settings.upImgExt = imgpram;

            objebox.settings.upLinkUrl = upapi + linkpram + "&valstr=" + valstrlink;
            objebox.settings.upLinkExt = linkpram;

            objebox.settings.upFlashUrl = upapi + flashpram + "&valstr=" + valstrflash;
            objebox.settings.upFlashExt = flashpram;

            objebox.settings.upMediaUrl = upapi + mediapram + "&valstr=" + valstrmediap;
            objebox.settings.upMediaExt = mediapram;

            objebox.settings.localUrlTest = /^https?:\/\/[^\/]*?(ebsite\.net)\//i; //urlreg
            objebox.settings.remoteImgSaveUrl = SiteConfigs.UrlIISPath + "ajaxget/saveremoteimg.ashx?" + allpram;

             

        }     


    });
    //setInterval(function () {
    //    if (window.localStorage) { //支持html本地存储
    //        var sHtml = objebox.getSource();
    //        localStorage.setItem(objebox, sHtml);
    //    }
       
    //},10000);
};

 