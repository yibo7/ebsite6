/*
 var Tags = new CustomTags();
         Tags.ParentObjName = "tagsask";
              Tags.SubObj = "div";
              Tags.CurrentClassName = "focus";
              Tags.ClassName = "";
              TopTags.fun = fun
              Tags.InitOnclickInTags();
              //    Tags.InitOnclick(0);
              Tags.InitCurrent(); //跨页时调用
*/

//设计一个通用的Tags类
function CustomTags() {
    //tags列表的上一级元素名称
    this.ParentObjName = "";

    this.SubObj = "";
    this.CurrentClassName = "";
    this.ClassName = "";
    this.Effects = "show"; //显示效果 show,fadein,slidedown,slideupdown,upindown
    this.fun = null;
    this.BoxList = [];
    this.TagsList = null;
    if (typeof CustomTags._initialized == "undefined") {
        CustomTags.prototype.InitOnclickInTags = function () {

            var tags = this.GetTags();
            var _objThis = $.data(document.body, "ct", this);
            if (tags != null && tags.length > 0) 
            {
                for (var i = 0; i < tags.length; i++) {
                  
                    $(tags[i]).click(function () {
                        var isallow = true;

                        if (_objThis.fun != null && _objThis.fun != "undefined") {
                            isallow = _objThis.fun(this);
                        }
                        if (isallow == undefined && isallow == null) {
                            isallow = true;
                        }
                        if (isallow) {
                            _objThis.OnclickTags(this);
                        }

                    });

                    if ($(tags[i]).attr("name") != undefined && $(tags[i]).attr("name") != null) {

                        this.BoxList.push($(tags[i]).attr("name"));
                    }

                }
            }
           

        }
        CustomTags.prototype.OnclickTags = function (obj) {

            var Url = $(obj).attr("u");

            if (Url == undefined) {  //tag只在当前页面使用

                this.InitCurrentClass(obj);
                var tags = this.GetTags();

                if (this.BoxList.length > 0) {
                    if (this.Effects == 'upindown') {
                        for (var i = 0; i < tags.length; i++) {

                            if (this.BoxList[i] != null) {
                                $("#" + this.BoxList[i]).slideDown();
                            }
                        }
                    }

                    for (var i = 0; i < tags.length; i++) {

                        if (this.BoxList[i] != null) {
                            if (this.Effects == 'slideupdown' || this.Effects == 'upindown')
                            { $("#" + this.BoxList[i]).slideUp(); }
                            else { $("#" + this.BoxList[i]).hide(); }

                        }
                    }
                    if (this.Effects == '' || this.Effects == 'show') {
                        $("#" + $(obj).attr("name")).show();
                    }
                    else if (this.Effects == 'fadein') {
                        $("#" + $(obj).attr("name")).fadeIn();
                    }
                    else if (this.Effects == 'slidedown' || this.Effects == 'slideupdown' || this.Effects == 'upindown') {
                        $("#" + $(obj).attr("name")).slideDown();
                    }


                }

            }
            else { //tag跨页面使用

                location.href = Url + "&tagname=" + $(obj).attr("name");

            }


        }
        CustomTags.prototype.InitCurrentClass = function (obj) //初始化tag样式表
        {

            var tags = this.GetTags();
            if (tags != null && tags.length > 0) {
                for (var i = 0; i < tags.length; i++) {
                    if (tags[i] != obj) {
                        tags[i].className = this.ClassName;
                    }
                }
            }

            obj.className = this.CurrentClassName;

        }
        CustomTags.prototype.InitCurrent = function () //跨页tag初始化
        {
            var CurrentTagName = GetUrlParams("tagname");
            var obj = null;
            var tags = this.GetTags();
            for (var i = 0; i < tags.length; i++) {

                if ($(tags[i]).attr("name") == CurrentTagName) {
                    obj = tags[i];
                    break;
                }
            }
            if (obj == null)
                obj = tags[0];

            this.InitCurrentClass(obj);
        }
        CustomTags.prototype.InitOnclick = function (index) {
            var tags = this.GetTags();
            var obj = tags[index];
            if (obj == "undefined" || obj == null) {
                //alert("没有找到对应的Tag");
                return;
            }
            $(obj).click();
        }
        CustomTags.prototype.GetTags = function () {

            if (this.TagsList == null) {
                var Tags = [];
                var isid = (this.ParentObjName.charAt(0) != ".") ? "#" + this.ParentObjName : this.ParentObjName;

                $(isid).find(this.SubObj).each(
                    function (i) {
                        Tags.push(this);
                        $(this).css("cursor", "pointer");
                    }
                );
                this.TagsList = Tags;
            }
            return this.TagsList;
        }
    }
    CustomTags._initialized = true;

}
