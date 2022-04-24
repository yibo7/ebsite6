$(document).ready(function () {

    OnGetUserLoginInfoEnd = function () {

        if (CurrentUserId > 0) {
            //2013-03-21 yhl 只用于问答
            var sid = jQuery.trim($("#sid").html());

            if (sid == CurrentUserId) {
                $("#menucheck").show(); $("#menumyask").show();

                $("#menutiwen a").html(" 我的提问");
                $("#menutongwen a").html(" 我的同问");
                $("#menujieda a").html(" 我的解答");
                $("#t_tw").hide();

            }
            else {
                $("#menucheck").hide(); $("#menumyask").hide();
            }


        }
    }


});