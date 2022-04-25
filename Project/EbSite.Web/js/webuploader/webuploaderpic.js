﻿
function InitImgUpload(ext,  folder, userid, size, valstr, filedata, fileList, inputid, iWidth, iHeight, isBatch) {
    var thumbnailWidth = iWidth;
    var thumbnailHeight = iHeight;
    var $fileList = $("#" + fileList);
    var modifyVal = $("#" + inputid).val();
    if (modifyVal) {  
        if (isBatch) {
            var aUrl =  modifyVal.split(","); 
            aUrl.map(function (item, index) {
                $fileList.append(getImgBox(thumbnailWidth, thumbnailHeight, item, item));
            });
            
        } else {
            $fileList.html(getImgBox(thumbnailWidth, thumbnailHeight, modifyVal, modifyVal));
        }        
    }
    function getImgBox(width, height, src, info = '') {
        
        return $('<div  style="width:'+width+'px;height:'+height+'px  " class="file-item thumbnail">' +
            '<img data-toggle="tooltip" title=' + info+' src="' + src+'" />' +
            //'<div class="info">' + info+'</div>' +
            '</div>');
    }
    // 初始化Web Uploader
    var uploader = WebUploader.create({

        // 选完文件后，是否自动上传。
        auto: true,

        // swf文件路径
        swf: '/js/webuploader/Uploader.swf',

        // 文件接收服务端。tp=1兼容过去的flash上传,tp=1表示不使用过去的flash上传处理业务
        //bdup不空服务端知道是来自百度的上传控件,只因这个控件的fileinput名称是写死的，所以要加个标记,后端除了这个地方，几乎是没有变动
        server: '/ajaxget/upsinglefile.ashx?tp=1&bdup=1&folder=' + folder + '&userid=' + userid + '&valstr=' + valstr + '&sz=' + size + '&ext=' + ext,//'&issmallimg=' + issmallimg +

        // 选择文件的按钮。可选。
        // 内部根据当前运行是创建，可能是input元素，也可能是flash.
        pick: '#' + filedata,
        paste: document.body,
        // 只允许选择图片文件。
        accept: {
            title: 'Images',
            extensions: ext,
            mimeTypes: 'image/*'
        }
    });
     
    // 当有文件添加进来的时候
    uploader.on('fileQueued', function (file) { 
        var $li = getImgBox(thumbnailWidth, thumbnailHeight,'', file.name);
        $li.attr("id", file.id); 
        var $img = $li.find('img')
         
        
        if (isBatch) {
            $fileList.append($li);
        } else {
            $fileList.html($li); //只允许上传一个
        }
        // 创建缩略图
        // 如果为非图片文件，可以不用调用此方法。
        // thumbnailWidth x thumbnailHeight 为 100 x 100
        uploader.makeThumb(file, function (error, src) {
            if (error) {
                $img.replaceWith('<span>不能预览</span>');
                return;
            }

            $img.attr('src', src);
        }, thumbnailWidth, thumbnailHeight);
    });

    // 文件上传过程中创建进度条实时显示。
    uploader.on('uploadProgress', function (file, percentage) {
        //progress是html5特性
        var $li = $('#' + file.id),
            $percent = $li.find('progress'); 
        // 避免重复创建
        if (!$percent.length) {
            $percent = $('<progress value="0" max="100"></progress>').appendTo($li);//.find('span');
        } 
        $percent.val(percentage * 100);
        $percent.text(percentage * 100 + '%');
        if (percentage == 1)
            $percent.remove()
    });

    // 文件上传成功，给item添加成功class, 用样式标记上传成功。
    uploader.on('uploadSuccess', function (file, response) {
        var data = Object;
        try { data = eval('(' + response._raw + ')'); } catch (ex) { };
        if (isBatch) {
            var oldV = $("#" + inputid).val();
            if (oldV.length>3) {
                oldV = oldV + ',' + data.msg.url;
            } else {
                oldV = data.msg.url;
            }
            $("#" + inputid).val(oldV);
        } else {
            $("#" + inputid).val(data.msg.url);
        } 

        $('#' + file.id).addClass('upload-state-done');
    });

    // 文件上传失败，显示上传出错。
    uploader.on('uploadError', function (file) {
        var $li = $('#' + file.id),
            $error = $li.find('div.error');

        // 避免重复创建
        if (!$error.length) {
            $error = $('<div class="error"></div>').appendTo($li);
        }

        $error.text('上传失败');
    });

    // 完成上传完了，成功或者失败，先删除进度条。
    uploader.on('uploadComplete', function (file) {
        $('#' + file.id).find('.progress').remove();
    });
}

