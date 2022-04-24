(function (jQuery) {

    this.version = '@1.1';
    this.layer = { 'width': 200, 'height': 100 };
    this.title = '信息提示';
    this.time = 0;
    this.anims = { 'type': 'slide', 'speed': 600 };
    this.position = 1; // 0 左下角,1 右下角,2左上角,3右上角

    this.inits = function (title, text) {
        if ($("#message").is("div")) { return; }
        $(document.body).prepend('<div id="message" style="border:#b9c9ef 1px solid;z-index:100;width:' + this.layer.width + 'px;height:' + this.layer.height + 'px;position:absolute; display:none;background:#cfdef4;' + this.GetPosition() + '  overflow:hidden;"><div style="border:1px solid #fff;border-bottom:none;width:100%;height:25px;font-size:12px;overflow:hidden;color:#1f336b;"><span id="message_close" style="float:right;padding:5px 0 5px 0;width:16px;line-height:auto;color:red;font-size:12px;font-weight:bold;text-align:center;cursor:pointer;overflow:hidden;">×</span><div style="padding:5px 0 5px 5px;width:100px;line-height:18px;text-align:left;overflow:hidden;">' + title + '</div><div style="clear:both;"></div></div> <div style="padding-bottom:5px;border:1px solid #fff;border-top:none;width:100%;height:auto;font-size:12px;"><div id="message_content" style="margin:0 5px 0 5px;border:#b9c9ef 1px solid;padding:10px 0 10px 5px;font-size:12px;width:' + (this.layer.width - 17) + 'px;height:' + (this.layer.height - 50) + 'px;color:#1f336b;text-align:left;overflow:hidden;">' + text + '</div></div></div>');
        $(window).scroll(function () {
            var scrollTop = $(window).scrollTop();
            $("#message").css(GetPositionScroll(scrollTop));
        });

    };
    this.GetPositionScroll = function (scrollTop) {

        var sP = { bottom: -scrollTop, left: 0 };
        if (this.position == 0) {
            sP = { bottom: -scrollTop, left: 0 };
        } else if (this.position == 1) {
            sP = { bottom: -scrollTop, right: 0 };
        } else if (this.position == 2) {
            //            sP = "top:0; left:0;";
            sP = { top: +scrollTop, left: 0 };
        } else if (this.position == 3) {
            //            sP = "top:0; right:0;";
            sP = { top: +scrollTop, right: 0 };
        }
        return sP;
    };
    this.show = function (title, text, time, width, height, showType, ps) {

        if ($("#message").is("div")) { return; }
        if (title == 0 || !title) title = this.title;

        if (width) this.layer.width = width;
        if (height) this.layer.height = height;
        if (showType) this.anims.type = showType;
        //        if (ps) 
        this.position = ps;
        this.inits(title, text);
        switch (this.anims.type) {
            case 'slide': $("#message").slideDown(this.anims.speed); break;
            case 'fade': $("#message").fadeIn(this.anims.speed); break;
            case 'show': $("#message").show(this.anims.speed); break;
            default: $("#message").slideDown(this.anims.speed); break;
        }
        $("#message_close").click(function () {
            setTimeout('this.close()', 0);
        });
        this.rmmessage(this.time);
    };
    this.lays = function (width, height) {
        if ($("#message").is("div")) { return; }
        if (width != 0 && width) this.layer.width = width;
        if (height != 0 && height) this.layer.height = height;
    }
    this.anim = function (type, speed) {
        if ($("#message").is("div")) { return; }
        if (type != 0 && type) this.anims.type = type;
        if (speed != 0 && speed) {
            switch (speed) {
                case 'slow': ; break;
                case 'fast': this.anims.speed = 200; break;
                case 'normal': this.anims.speed = 400; break;
                default:
                    this.anims.speed = speed;
            }
        }
    }
    this.rmmessage = function (time) {
        if (time > 0) {

            setTimeout('this.close()', time);

        }


    };
    this.close = function () {
        switch (this.anims.type) {
            case 'slide': $("#message").slideUp(this.anims.speed); break;
            case 'fade': $("#message").fadeOut(this.anims.speed); break;
            case 'show': $("#message").hide(this.anims.speed); break;
            default: $("#message").slideUp(this.anims.speed); break;
        };
        setTimeout('$("#message").remove();', this.anims.speed);

        //this.original();
    };
    this.original = function () {
        this.layer = { 'width': 200, 'height': 100 };
        this.title = '信息提示';
        this.time = 4000;
        this.anims = { 'type': 'slide', 'speed': 600 };
    };

    this.GetPosition = function () {

        var sP = "bottom:0; left:0;";
        if (this.position == 0) {
            sP = "bottom:0; left:0;";
        } else if (this.position == 1) {
            sP = "bottom:0; right:0;";
        } else if (this.position == 2) {
            sP = "top:0; left:0;";
        } else if (this.position == 3) {
            sP = "top:0; right:0;";
        }
        return sP;
    };
    jQuery.messager = this;
    return jQuery;
})(jQuery);