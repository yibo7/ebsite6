
function BatchUpload() {
    this.BatchID = "";
    this.BatchValueID = "";
    var _this = this;
    this.IsSmallImg = false;
    this.AddBtnName = ""; //如果指定,要在当前页面定义一个AddBtnName方法来接收此事件，带有一个参数（当前行的value控件ID,通过他可以取出当前行的相关信息）
    this.Init = function () {
        //Initupdata

        $("#" + this.BatchID).find("tr").each(
		function (i) {
		   
		    if ($(this).find("input[type=hidden]")[0] != undefined) {
		      
		        var obVal = $(this).find("input[type=hidden]")[0];
		        var sID = $(obVal).val();
		        var snewname = $(obVal).attr("newname");
		        var soldname = $(obVal).attr("oldname");
		        
		        if ($.trim(sID) != "") {
		            if (_this.IsSmallImg)
		            {
		                
		                var smallimgurl =_this.GetSmallImgFileName(snewname);

		              
		               
		                $(obVal).after("<img  src='" + smallimgurl + "' />");
		            }
		            else {
		                $(obVal).after(soldname);
		            }

		            var ty = get_type_of_url(snewname);
		            $(obVal).parent().next().text(ty);
		            var bntDel = $('.batchdel', this);
		          
		            var _Row = this;
		            bntDel.click(function () {
                       
		                _this.DeleteTr(_Row);
		            });

		            var bntDown = $('.batchdown', this);

		            bntDown.click(function () {
		                window.open(snewname);
		            });
		        }
		    }

		});
}
this.GetValueInputByRowIndex = function (rowindex) {
    var imgurl = "";
    $("#" + this.BatchID).find("tr").each(
		function (i) {
		    if (i == rowindex) {
		        if ($(this).find("input[type=hidden]")[0] != undefined) {

		            var obVal = $(this).find("input[type=hidden]")[0];
		            imgurl = $(obVal).attr("newname");
		           
		        }
		    }

		});
		return imgurl;
}
this.TypeToImg = function (sPostfix) {
    var sImg = "<img width=16 src='" + SiteConfigs.UrlIISPath + "images/type/";
    if (sPostfix == "") sImg += "other.gif";
    switch ($.trim(sPostfix)) {
        case ".gtp":
        case ".gp3":
        case ".gp4":
        case ".gp5":
            sImg += "gtp.gif";
            break;
        case ".ove":
            sImg += "ove.gif";
            break;
        case ".txt":
            sImg += "txt.gif";
            break;
        case ".rar":
        case ".zip":
            sImg += "rar.gif";
            break;
        case ".bmp":
        case ".gif":
        case ".jpg":
        case ".png":
            sImg += "pic.gif";
            break;
        case ".jcx":
            sImg += "jcx.gif";
            break;
        case ".pdf":
            sImg += "pdf.gif";
            break;
        case ".swf":
        case ".flv":
            sImg += "flv.png";
            break;
        case ".mp4":
            sImg += "real18.gif";
            break;
        case ".mp3":
            sImg += "wmp18.gif";
            break;
        default:
            sImg += "other.gif";
            break;

    }

    return sImg += "'>";
}
this.GetSmallImgFileName = function (newName) {
    //var newName = this.value;
     
    var sExt = getFileExt(newName);
    return newName.toString().toLowerCase().replace("ebbaseimg"+sExt, "ebsmallimg" + sExt);
}
this.GetMiddlemgFileName = function (newName) {
    //var newName = this.value;
    var sExt = getFileExt(newName);
    return newName.toString().toLowerCase().replace("ebbaseimg" + sExt, "ebmiddleimg" + sExt);
}
this.GetBigImgFileName = function (newName) {
    //var newName = this.value;
    var sExt = getFileExt(newName);
    return newName.toString().toLowerCase().replace("ebbaseimg" + sExt, "ebmiddleimg" + sExt);
}
this.IsImg = function (newName) {
    var istrue = false;
    var sPostfix = getFileExt(newName);
    switch ($.trim(sPostfix)) {
        case ".bmp":
        case ".gif":
        case ".jpg":
        case ".jpeg":
        case ".png":
            istrue = true;
            break;

    }
    return istrue;
}
this.AddRow = function (id, newName, oldName) {

    var OldName = GetFileNameByPath(oldName);
    var smallImgUrl = this.GetSmallImgFileName(newName);

    var FileType = getFileExt(newName);
    FileType = this.TypeToImg(FileType);
    var NewName = newName;

    var ShowHtml = OldName;

    if (this.IsSmallImg && this.IsImg(newName)) {
        ShowHtml = "<img  src='" + smallImgUrl + "' />";
    }
    var valueid = "buploadrow" + id;
    var htmltr = "<tr><td><input id=" + valueid + " type=\"hidden\" newname=\"" + NewName + "\" oldname=\"" + OldName + "\" value=\"" + id + "\" />" + ShowHtml + "</td><td>" + FileType + "</td><td><span class='batchdel'>删除</span>｜<span class='batchdown'>打开</span></td></tr>";

    var row = $(htmltr).insertAfter("#" + this.BatchID + " tr:eq(0)");   //在第一个tr后加一行
   
    var bntDel = $('.batchdel', row);
    bntDel.click(function () {
         
        _this.DeleteTr(row);
    });
    var bntDown = $('.batchdown', row);
    bntDown.click(function () {
        window.open(newName);
    });

    if (this.AddBtnName != "") {
        var obAddBtnName = $("<span>" + this.AddBtnName + "</span>");
        $('.batchdown', row).after(obAddBtnName);
        obAddBtnName.click(
            function () {
                AddBtnName(valueid);
            });
    }

    this.InitValue();

}
    this.DeleteTr = function (ob) {

        $(ob).remove();

        this.InitValue();
    }
    this.InitValue = function () {
        var sb = "";
        $("#" + this.BatchID).find("tr").each(
		function (i) {

		    if ($(this).find("input[type=hidden]")[0] != undefined) {
		        var obVal = $(this).find("input[type=hidden]")[0];
		        var sID = $(obVal).val();
		        var snewname = $(obVal).attr("newname");
		        var soldname = $(obVal).attr("oldname");
		        sb += sID + ":" + snewname +":"+soldname+ "*";
		    }

		}
		);

		$("#" + this.BatchValueID).val(sb);
    }

}
//批量上传----------------------------------------


function InitUploadBatchValue(obHidBox, obTableID) {
    var sb = "";
    $("#" + obTableID).find("tr").each(
		function (i) {

		    if ($(this).find("input[type=hidden]")[0] != undefined) {
		        var obVal = $(this).find("input[type=hidden]")[0];
		        var sv = $(obVal).val();
		        var sT = $(obVal).attr("txt");
		        sb += sT + ":" + sv + "*";
		    }

		}
		);

    $("#" + obHidBox).val(sb);

}

//function DeleteFile(obHid, TableID, pram) {

//    var Url = SiteConfigs.UrlIISPath + "Ajaxget/FileFso.ashx?ran=" + Math.random() + "&p=" + pram.trim();

//    var msgs = run_ajax_unasync(Url);

//    if (msgs == "删除成功!") {

//        DeleteTr(TableID, obHid, pram);
//    }


//}
function DeleteTr(obTableID, obHid, sValue) {


    $("#" + obTableID).find("tr").each(
		function (i) {

		    if ($(this).find("input[type=hidden]")[0] != undefined) {
		        var sv = $(this).find("input[type=hidden]")[0].value;

		        if (sValue == sv) {
		            $(this).remove();

		        }
		    }

		}
		);

    InitUploadBatchValue(obHid, obTableID);
}
function getFileExt(str) {
    if (str) {
        var d = /\.[^\.]+$/.exec(str);

        return d.toString().toLowerCase();
    }
    return "";
    //return d.toString().toLowerCase();
}

