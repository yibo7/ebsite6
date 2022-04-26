
function AspNetUpload() {
    this.UpPluginPath = UploadPluginPath;
    this.upLoadurl = 'ajaxget/upsinglefile.ashx?tp=1';
    this.FileTextBoxID = "txtFilePath";
    this.SavePathCtrID = "";
    this.OldNameCtrID = "";
    this.FileidCtrID = "";
    this.uploadInputname = 'filedata';
    this.IsUploading = false;
    this.ProgressID = "ProgressBar";
    this.AddBntID = "";
    this.SaveFolder = "";
    this.PostDataBntID = ""; //提交按钮的ID，因为上传是导步，所以如果没有上传完将不允许提交
    this.SavePathCtrID = "";
    this.OldNameCtrID = "";
    this.FileidCtrID = "";
    this.Ext = "";
    this.AllSize = "1024 KB";
    this.AllCount = 0;
    var _this = this; //这样可以让事件在外部调用此实例
    this.onUploadComplete = null;
    this.BatchOB = null;
    this.UserID = ""; //暂时没用到
    this.OutBtnID = "";
    this.value = "";
    this.ValStr = "";
    this.Init = function () {



        var sExt = "";


        if (this.Ext != "") {
            this.Ext = this.Ext.match(/([^\(]+?)\s*\(\s*([^\)]+?)\s*\)/i);
            this.Ext = "," + this.Ext[2];

            var aExt = $.trim(this.Ext).split(',');
            aExt = aExt.slice(1); //删除第一个
            sExt = aExt.toString();
            this.upLoadurl += "&ext=" + sExt;

        }
        this.upLoadurl += "&sz=" + parseInt(this.AllSize);

        if (this.SaveFolder != "")
            this.upLoadurl += "&folder=" + this.SaveFolder;
        
        var jUpBnt = $("#" + this.AddBntID); 
        jUpBnt.append('<input   type="file" size="13"  name="' + this.uploadInputname + '"  tabindex="-1"  class="AspNetUpFile"   />');
        //jUpBnt.append('<input type="button"   value="上传"  class="AspNetBtn" tabindex="-1" />');
        jUpBnt.append('<span   class="AspNetBtn" >选择文件</span>');
        var jFile = $('.AspNetUpFile', jUpBnt);
        var jNetBtn = $('.AspNetBtn', jUpBnt);
        if (this.OutBtnID != "") {
            $("#" + this.OutBtnID).click(function () {
                jFile.click();
            });

        } 
        //设置控件长度
        var dWidth = parseInt($("#" + this.FileTextBoxID).css("width"));
        //if (dWidth) {

        //    jNetBtn.css("left", dWidth);
        //    jFile.css("left", dWidth);
        //}
        jFile.click(function () {

            if (_this.IsUploading) {
                alert("文件正在上传中...");
                return false;
            }
        }); 
        jFile.change(function () {
            
            if (!_this.checkFileExt(jFile.val(), sExt)) {

                return false;
            }
            if (_this.PostDataBntID != "") {
                // 屏蔽提交
                $("#" + _this.PostDataBntID).attr("disabled", true);
            }
            
            var up_url = SiteConfigs.UrlIISPath + _this.upLoadurl + "&userid=" + _this.UserID + "&valstr=" + _this.ValStr;// + "&issmallimg" + _this.IsSmallImg;
            //console.log(up_url)
            var upload = new _this.html4Upload(jFile[0], up_url, _this.onUploadCallback);
            upload.start();
            _this.ShowProcess(function () { upload.remove(); });

        });

    }
    this.checkFileExt = function (filename, limitExt) {
        if (limitExt === '*' || filename.match(new RegExp('\.(' + limitExt.replace(/,/g, '|') + ')$', 'i'))) return true;
        else {
            alert('上传文件扩展名必需为: ' + limitExt);
            return false;
        }
    }
    this.html4Upload = function (fromfile, toUrl, callback) {

        var uid = new Date().getTime(), _this = this;
        var idIO = 'jUploadFrame' + uid;
        var jIO = $('<iframe name="' + idIO + '"  class="AspNetUpHideArea" />').appendTo('body');
        var jForm = $('<form action="' + toUrl + '" target="' + idIO + '" method="post" enctype="multipart/form-data" class="AspNetUpHideArea"></form>').appendTo('body');
        var jOldFile = $(fromfile);

        var jOldFile = $(fromfile), jNewFile = jOldFile.clone();//.attr('disabled', 'true');
        jOldFile.before(jNewFile).appendTo(jForm);

        this.remove = function () {  //上传完成后去除
            if (_this !== null) {
                jNewFile.before(jOldFile).remove();
                jIO.remove();
                jForm.remove();
                _this = null;
            }
        }
        this.onLoad = function () { callback($(jIO[0].contentWindow.document.body).text(), true); }
        this.start = function () {
            jForm.submit();
            jIO.load(_this.onLoad);

        }
        return this;
    }
    this.ShowProcess = function (callbak) {
        _this.IsUploading = true;
        var sLoading = '<img width="190" src="' + _this.UpPluginPath + 'loading.gif">';
        $("#" + _this.FileTextBoxID).val("文件正在上传中...");
        $("#" + _this.ProgressID).append(sLoading);

        //_this.onUploadComplete = callbak;


    }
    this.CloseProcess = function (msg) {
        $("#" + _this.ProgressID).html("");
        $("#" + _this.FileTextBoxID).val(msg);
        _this.IsUploading = false;



        if (_this.PostDataBntID != "") {
            // 取消屏蔽提交
            $("#" + _this.PostDataBntID).attr("disabled", false);
        }
    }
    this.GetSmallImgFileName = function () {
        var newName = this.value;
        var sExt = getFileExt(newName);
        return newName.toString().toLowerCase().replace("ebbaseimg" + sExt, "ebsmallimg" + sExt);
    }
    this.GetMiddlemgFileName = function () {
        var newName = this.value;
        var sExt = getFileExt(newName);
        return newName.toString().toLowerCase().replace("ebbaseimg" + sExt, "ebmiddleimg" + sExt);
    }
    this.GetBigImgFileName = function () {
        var newName = this.value;
        var sExt = getFileExt(newName);
        return newName.toString().toLowerCase().replace(sExt, "-ebbigimg" + sExt);
    }
    this.onUploadCallback = function (sText, bFinish) {
        var data = Object, bOK = false;
        try { data = eval('(' + sText + ')'); } catch (ex) { };
        if (data.err === undefined || data.msg === undefined) {
            alert(' 上传接口发生错误！\r\n\r\n返回的错误内容为: \r\n\r\n' + sText);
            _this.CloseProcess("文件上传失败！");
        }
        else {
            if (data.err) {
                alert(data.err);
                _this.CloseProcess("文件上传失败:" + data.err);
            }
            else {
                var arrMsg = data.msg;
                _this.CloseProcess(arrMsg.url);
                bOK = true; //继续下一个文件上传
                _this.value = arrMsg.url;

                if (_this.onUploadComplete != null) {

                    _this.onUploadComplete();
                }

                if (_this.SavePathCtrID != "") {
                    $("#" + _this.SavePathCtrID).val(arrMsg.url);
                }
                if (_this.OldNameCtrID != "") {
                    $("#" + _this.OldNameCtrID).val(arrMsg.localname);
                }
                if (_this.FileidCtrID != "") {

                    $("#" + _this.FileidCtrID).val(arrMsg.id);
                }

                if (_this.BatchOB != null) {
                    _this.BatchOB.AddRow(arrMsg.id, arrMsg.url, arrMsg.localname);
                }

            }
        }


        return bOK;
    }

}
