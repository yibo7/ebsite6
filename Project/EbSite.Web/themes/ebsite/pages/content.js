var ispostup = false;
var ispostuphfs = [];
jQuery(function ($) {
    $("#btnSavePost").click(function () {
        if (CurrentUserId > 0) {
            addrepost();
        }
        else {
            openlogin(function (msg) {
                CurrentUserId = msg;
                addrepost();
            });
        }


    });
    $("#gotoreply").click(function () {
        In.ready('jqscroll', function () {
            $("#btnSavePost").ScrollTo(800);
        });
    });

    $(".ebid-postbttoolbarright a").click(function () {
        var iupindex = parseInt($(this).attr("t"));
        var ipostid = $(this).attr("dataid");


        if (iupindex == 3 || iupindex == 12) {

            openpostreport(ipostid);
        }
        else if (iupindex == 13) {
            In.ready('jqscroll', function () {
                $("body").ScrollTo(800);
            });
        }
        else {

            if (iupindex == 1 || iupindex == 2) {

                if (ispostup) {
                    tb_err("您已经操作过此主题！");
                    return;
                }

            } else {
                if (ispostuphfs.contains(ipostid)) {
                    if (ispostup) {
                        tb_err("您已经操作过此帖子！");
                        return;
                    }
                }
            }

            var igoodbad = 1;
            var blispost = true;
            var value = parseInt($(this).attr("v"));
            value = value + 1;
            switch (iupindex) {
                case 1:
                    igoodbad = 1;
                    $(this).text("支持" + value);
                    ispostup = true;
                    break;
                case 2:
                    igoodbad = 0;
                    $(this).text("反对" + value);
                    ispostup = true;
                    break;
                case 10:
                    $(this).text("支持" + value);
                    blispost = false;
                    igoodbad = 1;
                    ispostuphfs.push(ipostid);
                    break;
                case 11:
                    blispost = false;
                    igoodbad = 0;
                    $(this).text("反对" + value);
                    ispostuphfs.push(ipostid);
                    break;
            }



            var pram = { id: ipostid, goodbad: igoodbad, ispost: blispost, site: SiteID };

            runws("b3eef4b1-6c2c-4528-9e15-ad33716238ce", "PostGoodBad", pram, function (msg) {
                var obj = msg.d;

            });


        }

    });

});

function postreport(pistid) {
    alert(pistid)
}

function openpostreport(pistid) {
        
    In.ready('tinybox', function () {
        //执行代码
        //reportpost
        //TINY.box.show('<div id="reportpost"><textarea  rows="2" cols="8" ></textarea></div>', 1, 600, 430, 0, 0);
        TINY.box.show("<div>请输入举报原因:</div><div > <textarea  rows=\"2\" cols=\"8\" style=\"width:100%; height: 50px;margin-bottom: 10px;\"  ></textarea></div><div><input type=\"button\" onclick='postreport(" + pistid + ")' value=\" 提 交 \" />&nbsp;&nbsp;<input onclick='TINYBoxClose()' type=\"button\" value=\" 取 消 \" /></div>", 0, 300, 120, 1);
    });
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
function addrepost() {
    var endPage = getEndPageIndex();
    var scontent = $("#edtContentInfo_ID").val();
    if ($.trim(scontent) != "") {
        var pram = { postid: postid, c: scontent, ep: endPage, count: pAllCount, site: SiteConfigs.id };
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
        tb_err("请输入正确回复内容！");
    }
 
}