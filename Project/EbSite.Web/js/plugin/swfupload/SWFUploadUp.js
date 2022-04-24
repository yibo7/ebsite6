 
function EBSWFUpload() {
    this.UpPluginPath = UploadPluginPath;
    this.upSwfPath = "swfupload.swf";
    this.upLoadurl = 'ajaxget/upsinglefile.ashx';   
    this.selQueue = [];
    this.FileSize = 0;
    this.SWFOB = null;
    this.FileTextBoxID = "txtFilePath";
    this.Ext = "所有文件 (*.*)";
    this.AllSize = "1024 MB";
    this.AllCount = 0;
    this.UseGet = 0;
    this.Params = {};
    this.AddBntID = "";
    this.ProgressID = "ProgressBar";
    this.SaveFolder = "";
    this.PostDataBntID = ""; //提交按钮的ID，因为上传是导步，所以如果没有上传完将不允许提交
    this.SavePathCtrID = "";
    this.OldNameCtrID = "";
    this.FileidCtrID = "";
    this.IsUploading = false;
    this.BatchOB = null;
    this.onUploadComplete = null;
    this.UserID = "";//加密文
    this.IsSmallImg = "";
    this.ValStr = "";
    this.value = "";
    if (typeof EBSWFUpload._initialized == "undefined") {
        EBSWFUpload.prototype.Init = function () {

            var sExtPost = "";

            

            if (this.Ext != "") {
                sExtPost = this.Ext.match(/([^\(]+?)\s*\(\s*([^\)]+?)\s*\)/i);
                sExtPost = "," + sExtPost[2];

                var aExt = $.trim(sExtPost).split(',');
                aExt = aExt.slice(1); //删除第一个
                sExtPost = aExt.toString();
            }
            this.Ext = this.Ext.match(/([^\(]+?)\s*\(\s*([^\)]+?)\s*\)/i);

            this.Params = { "folder": this.SaveFolder, "issmallimg": this.IsSmallImg, "userid": this.UserID, "valstr": this.ValStr, "sz":  parseInt(this.AllSize), "ext": sExtPost };
            var sExt = this.Ext[2];
            if (sExt != "") {
                var aExt = sExt.split(",");

                sExt = "*."+aExt.join(";*.");
            }
           
             
            this.SWFOB = new SWFUpload({
                // Flash组件
                flash_url: this.UpPluginPath + this.upSwfPath,
                prevent_swf_caching: false, //是否缓存SWF文件

                // 服务器端
                upload_url: SiteConfigs.UrlIISPath + this.upLoadurl,
                file_post_name: "filedata",
                post_params: this.Params, //随文件上传一同向上传接收程序提交的Post数据
                use_query_string: this.UseGet == '1' ? true : false, //是否用GET方式发送参数

                // 文件设置
                file_types: sExt, //文件格式限制
                file_types_description: this.Ext[1], //文件格式描述
                file_size_limit: this.AllSize, // 文件大小限制
                file_upload_limit: this.AllCount, //上传文件总数
                file_queue_limit: 0, //上传队列总数
                custom_settings: {
                    OB: this
                },

                // 事件处理
                file_queued_handler: this.fileQueued, //添加成功
                file_queue_error_handler: this.fileQueueError, //添加失败
                upload_start_handler: this.uploadStart, //上传开始
                upload_progress_handler: this.uploadProgress, //上传进度
                upload_error_handler: this.uploadError, //上传失败
                upload_success_handler: this.uploadSuccess, //上传成功
                upload_complete_handler: this.uploadComplete, //上传结束

                // 按钮设置
                button_placeholder_id: this.AddBntID,
                button_width: 69,
                button_height: 18,
                button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT,
                button_cursor: SWFUpload.CURSOR.HAND,
                button_image_url: this.UpPluginPath + "sikn/add.gif",
                button_text: '上传文件',
                button_text_style: ".theFont { font-size: 12px; }",
                button_text_left_padding: 20,
                button_text_top_padding: -1,

                // 调试设置
                debug: false
            });
            
            //$.data(this.FileTextBoxID, "OB", this);

        }

        EBSWFUpload.prototype.fileQueued = function (file) {
           
            if (this.customSettings.OB.IsUploading) {
                alert("文件正在上传中...");
                return false;
            }
            if (this.customSettings.OB.PostDataBntID != "") {
                // 屏蔽提交
                $("#" + this.customSettings.OB.PostDataBntID).attr("disabled", true);
            }
            
            //this.customSettings.OB.ClearQueued(); //造成有时可以上传，有时不可以上传的原因
            //初始化值到文本框
            $("#" + this.customSettings.OB.FileTextBoxID).val(this.customSettings.OB.formatBytes(file.size) + "|" + file.name);
            //添加文件到队列
            this.customSettings.OB.selQueue.push(file);
            this.customSettings.OB.FileSize = file.size;
            //开始上传
            this.customSettings.OB.SWFOB.startUpload();


        }
        EBSWFUpload.prototype.fileQueueError = function (file, errorCode, message) {
           
            var errorName = '';
            switch (errorCode) {
                case SWFUpload.QUEUE_ERROR.QUEUE_LIMIT_EXCEEDED:
                    errorName = "只能同时上传 " + this.settings.file_upload_limit + " 个文件";
                    break;
                case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
                    errorName = "选择的文件超过了当前大小限制：" + this.settings.file_size_limit;
                    break;
                case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
                    errorName = "零大小文件";
                    break;
                case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
                    errorName = "文件扩展名必需为：" + this.settings.file_types_description + " (" + this.settings.file_types + ")";
                    break;
                default:
                    errorName = "未知错误";
                    break;
            }
            alert(errorName);
        }
        EBSWFUpload.prototype.uploadStart = function (file) {
           

            this.customSettings.OB.IsUploading = true;
            this.customSettings.OB.setFileState("文件上传中...");
        }
        EBSWFUpload.prototype.uploadProgress = function (file, bytesLoaded, bytesTotal) {
            var percent = Math.ceil((bytesLoaded) / this.customSettings.OB.FileSize * 100);

            $('#' + this.customSettings.OB.ProgressID + ' span').text(percent + '% (' + this.customSettings.OB.formatBytes(bytesLoaded) + ' / ' + this.customSettings.OB.formatBytes(this.customSettings.OB.FileSize) + ')');
            $('#' + this.customSettings.OB.ProgressID + ' div').css('width', percent + '%');
        }
        EBSWFUpload.prototype.uploadError = function (file, errorCode, message) {
                
            alert("文件上传失败:" + message+"，可能是没有上传权限，确认你是否已经登录");
            this.customSettings.OB.setFileState("文件上传失败！");
            this.customSettings.OB.IsUploading = false;
            
        }
        EBSWFUpload.prototype.uploadSuccess = function (file, serverData) {
            var data = Object;
            try { data = eval('(' + serverData + ')'); } catch (ex) { };
            
            if (data.err != undefined) {
                if (!data.err) {
                    //uploadSize += file.size;
                    //arrMsg.push(data.msg);

                   
                    this.customSettings.OB.setFileState("文件上传成功！");

                }
                else {
                    this.customSettings.OB.setFileState("文件上传失败！");
                    alert(decodeURI(data.err));
                }
            }
            else {
                this.customSettings.OB.setFileState("文件上传失败！");
            };

            if (this.customSettings.OB.PostDataBntID != "") {
                // 取消屏蔽提交
                $("#" + this.customSettings.OB.PostDataBntID).attr("disabled", false);
            }
            if (this.customSettings.OB.SavePathCtrID != "") {
                $("#" + this.customSettings.OB.SavePathCtrID).val(data.savepath);

                $("#" + this.customSettings.OB.FileTextBoxID).val(data.savepath);

                this.customSettings.OB.value = data.savepath;
            }
            if (this.customSettings.OB.OldNameCtrID != "") {

                $("#" + this.customSettings.OB.OldNameCtrID).val(decodeURIComponent(data.oldname));
            }
            if (this.customSettings.OB.FileidCtrID != "") {

                $("#" + this.customSettings.OB.FileidCtrID).val(data.id);
            }
            if (this.customSettings.OB.BatchOB != null) {
               //alert(decodeURIComponent(data.oldname))
                this.customSettings.OB.BatchOB.AddRow(data.id, data.savepath, decodeURIComponent(data.oldname));
            }
            this.customSettings.OB.IsUploading = false;

        }
        EBSWFUpload.prototype.uploadComplete = function (file) {
            
            if (this.customSettings.OB.SWFOB.getStats().files_queued > 0) {
                //swfu.startUpload();
            }
            else {
                
                this.customSettings.OB.setFileState("所有文件上传成功！");
                if (this.customSettings.OB.onUploadComplete != null)
                    this.customSettings.OB.onUploadComplete();
            }
        }
        EBSWFUpload.prototype.setFileState = function (msg) {
            $($.parseHTML('# ' + this.ProgressID + ' span')).text(msg);
        }
        //清空所有队列
        EBSWFUpload.prototype.ClearQueued = function () {
            var file;
            for (var i in this.selQueue) {
                file = this.selQueue[i];
                this.selQueue.splice(i, 1);
                this.SWFOB.cancelUpload(file.id);
            }
        }
        EBSWFUpload.prototype.formatBytes = function (bytes) {
            var s = ['Byte', 'KB', 'MB', 'GB', 'TB', 'PB'];
            var e = Math.floor(Math.log(bytes) / Math.log(1024));
            return (bytes / Math.pow(1024, Math.floor(e))).toFixed(2) + " " + s[e];
        }
    }
    EBSWFUpload._initialized = true;
}
