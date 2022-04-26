In.ready('gmuw-panel', function () {
    $(function ($) {
        $('.panel').panel({
            contentWrap: $('.cont')
        });

        $('#push-right').on('click', function () {
            document.body.scrollTop = 0;
            document.documentElement.scrollTop = 0;
            $('.panel').panel('toggle', 'push', 'right');

        });
    } (Zepto));
});
Zepto(function ($) {
   
    var rpindex = 0;
    $(".post-box img").click(function () {
        var src = $(this).attr("src");
        if (rpindex == 0) {

            src = src.replace("-ebsmallimg", "-ebmiddleimg");
            rpindex++;
        }
        else if (rpindex == 1) {
            src = src.replace("-ebmiddleimg", "-ebbigimg");
            rpindex++;
        }
        else if (rpindex == 2) {
            src = src.replace("-ebbigimg", "-ebbaseimg");
            rpindex++;
        } else {
            src = src.replace("-ebbaseimg", "-ebsmallimg");
            rpindex = 0;
        }

        $(this).attr("src", src);
    });

    $(window).bind('scroll', function () {
        if ($(window).scrollTop() > 50) {
            $("#posttipsfirst").css("top", 0);
        }
    });


    $("#btnSavePost").click(function () {
      
        if (CurrentUserId > 0) {
            addrepost();
        }
        else {

            location.href = SiteConfigs.UrlLogin + "?ru=" + location.href;
        } 
    });

    var idex = $("#push-right").text();
     idex = idex.replace(/[^0-9]/ig, ""); 
     if (idex == 0) {
         $("#push-right").hide();
     }
     BigFont();
     playhtml5();

    

});

 function playhtml5() {
    
     In.ready('html5audio', function () {
         
         $("embed").each(function () {
             var url = $(this).attr("src");
             var smp3 = get_type_of_url(url);
             if (smp3 == "mp3") {
                 var html = "<audio src='" + url + "'  autoplay></audio>";
                 $(this).replaceWith(html);
                 audiojs.events.ready(function () {
                     audiojs.createAll();
                     audio.play();
                 });
             }

         });
         
         
     });
      
    
}
function addrepost() {
    var endPage = getEndPageIndex();
    var scontent = $("#edtContentInfo_ID").val();
    if ($.trim(scontent) != "") {
        var pram = { postid: postid, c: scontent, ep: endPage, count: pAllCount, site: SiteConfigs.id, cid: ClassID, rs: IsReSendEmail, uid: ModelUserID };
        runws("b3eef4b1-6c2c-4528-9e15-ad33716238ce", "Hf", pram, function (msg) {
            var obj = msg.d;
            if (obj.Success) {
                location.href = obj.Message;
            }
            else {
                alert(obj.Message);
            }
        });
    }
    else {
        tb_err("请输入正确回复内容！", 1, 2);
    }

}

//获取最后页url,便于发表后定向
function getEndPageIndex() {
    var iPageIndex = 1;
    if (pAllCount <= 0 || pPageSize <= 0) {
        iPageIndex = 1;
    }
    else {
        iPageIndex = ((pAllCount + 1 + pPageSize) - 1) / pPageSize;
    }
    return parseInt(iPageIndex);

}

var indexfontbig = 0;
function BigFont() {

    $("#fontbig").click(function () {
        indexfontbig++;
        var thisEle = $(".post-box").css("font-size");
        var textFontSize = parseInt(thisEle);
        if (indexfontbig <= 3) {
            textFontSize = textFontSize + 8;
        } else {
            textFontSize = 16;
            indexfontbig = 0;
        }

        $(".post-box").css("font-size", textFontSize);
        $(".post-box").children().css("font-size", textFontSize);
        $(".post-box").children().children().css("font-size", textFontSize);
        $(".post-box").children().children().children().css("font-size", textFontSize);
    });
}