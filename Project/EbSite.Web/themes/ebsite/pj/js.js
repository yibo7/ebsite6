
jQuery(function ($) {

    In.ready('customtags', function() {
        var Tags = new CustomTags();
        Tags.ParentObjName = "tagsask";
        Tags.SubObj = "div";
        Tags.CurrentClassName = "focus";
        Tags.ClassName = "";
        Tags.InitOnclickInTags();
        //    Tags.InitOnclick(0);
        Tags.InitCurrent(); //跨页时调用

        ShowPjDlg(".btn-comment");

        ShowPjHfDlg(".btn-reply");
    });
});


    function cp_bk(result) {
    if (result > 0) {
        $("#lbErrInfo").text("登录");
    }
    else {
        $("#lbErrInfo").text("登录失败");
    }
}

    function btnagree(obj) {
        if (CurrentUserId > 0) {
          var pram = { "id": obj, "key": 1 };
          runebws("RemarkSupport", pram, function (result) {
            $("#support-k").html("有用("+result.d+")");
          });  
        }
        else {
            openlogin(); // alert("请先登录！");
        }
    }
    function btnoppose(obj) {
        if (CurrentUserId > 0) {
          var pram = { "id": obj, "key": 2 };
          runebws("RemarkSupport", pram, function (result) {
            $("#oppose-k").html("没用("+result.d+")");
          });  
        }
        else {
            openlogin(); // alert("请先登录！"); 
        }
       
    }

//    function btnreply(obj){
//      
//      $("#<%=HDReply.ClientID %>").val(obj);
//  }



    
     //当用iframe时可以用这个来重新设置高度，以自动适应
    function resizeFrame() {
        
        
            var xscomment = parent.document.getElementById("xscomment");
            if (xscomment != null || xscomment != undefined) {
                xscomment.style.height = document.body.scrollHeight + 200 + "px";
                var topPos = location.href.indexOf("#top");
                if (topPos > 0) {
                    location.href = location.href.substring(0, topPos) + "#top1"
                }
            }	

    }



    /*发表评论*/
    //获取url?号后的参数
    function GetUrlParams(ParamName) {
        var URLParams = new Object();
        var aParams = document.location.search.substr(1).split('&');
        for (i = 0; i < aParams.length; i++) {
            var aParam = aParams[i].split('=');
            URLParams[aParam[0]] = aParam[1];
        }

        var sValue = URLParams[ParamName];
        if (sValue == undefined)
            return "";
        return sValue;
    }
    function getScore() {
        var value = "";
        var radio = document.getElementsByName("RdScore");
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked == true) {
                value = radio[i].value;
                break;
            }
        }
        return value;
    }
    function toAddEvaluate() {
        debugger;
        var sCid = PjConfigs.cid;//  GetUrlParams("cid");
        var sClassid = PjConfigs.classid; // GetUrlParams("classid");
        var sContentid = PjConfigs.contentid;//  GetUrlParams("contentid");

        var stxtExperience = document.getElementById("txtExperience").value;
       
        var sRdScore = getScore();
       
        if (stxtExperience == "") {
            alert("请添写使用心得！");
            return;
        }
      
        if (sRdScore == "") {
            alert("请选择评价分数！");
            return;
        }
        parent.PjAddPost(  stxtExperience, sCid, sClassid,sContentid ,sRdScore);
//        if (CurrentUserId > 0) {
//            parent.PjAddPost(stxtTitle, sMK, stxtExperience, stxtAdvantage, stxtDefect, sCid, sRdScore);

//        }
//        else {
//            openlogin(); // alert("请先登录！");
//        }

    }
    /*打开回复*/
    var rfid = 0;
    function rply(obj) {

        rfid = obj;

        if (CurrentUserId > 0) {
            In.ready('tinybox', function () {                //执行代码
                TINY.box.show(SiteConfigs.UrlIISPath + 'pjx/huifu.htm?id=' + obj, 1, 360, 165, 1);
            });
        }
        else {
            openlogin(); // alert("请先登录！");
        }

        
    }


    /*添加回复*/
    function huifu() {
      parent.PjHfAddPost(rfid, document.getElementById("txtMsg").value);
    }
   