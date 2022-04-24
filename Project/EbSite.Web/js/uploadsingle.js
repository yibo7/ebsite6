
function ImgSingleUpload() {
    this.ext = "jpg,jpeg,gif,png";
    this.folder = "";
    this.userIdEncode = "";
    this.size = 1024;
    this.valstr = "";
    this.btnSelFiles = "";  
    this.onComplete = null;
    this.onUploadding = null;
    this.currentSelBtn = null;
    this.Init = function () {
        var imgxsFile;
        var _this = this;
        $(this.btnSelFiles).click(function () { 
            _this.currentSelBtn = $(this);
            imgxsFile.click();
            
        });
        if ($("#imgxsFile").length > 0) {
            imgxsFile = $("#imgxsFile");
        } else {
            imgxsFile = $("<input style=\"display:none\" type=\"file\" name=\"filedata\" id=\"filedata\"  />");
            $("body").append(imgxsFile);
        };
    
        imgxsFile.change(function () {
            
            var xhr = new XMLHttpRequest();
            if (_this.onUploadding) {
                _this.onUploadding(_this.currentSelBtn);
            }
            xhr.upload.addEventListener("load", function (e) {
                //console.log("上传完毕...")
            }, false);

            xhr.open("POST", '/ajaxget/upsinglefile.ashx?tp=1&folder=' + _this.folder + '&issmallimg=false&userid=' + _this.userIdEncode + '&valstr=' + _this.valstr + '&sz=' + _this.size + '&ext=' + _this.ext);
            xhr.overrideMimeType('text/plain; charset=x-user-defined-binary');
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    var obj = eval("(" + xhr.responseText + ")");//转换为json对象 
                    if (obj && obj.err=='') {
                        if (_this.onComplete) {
                            _this.onComplete(_this.currentSelBtn, obj);
                        }
                        //$("#imgMyIco").attr("src", obj.msg + "?ran" + Math.random());
                        //$("#btnModifyIco").removeClass("disabled");
                        //$("#btnModifyIco").text("修改头像");
                       
                    } else {
                        if (obj) { alert(obj.msg) };
                    }

                }
            };
            var file = document.getElementById("filedata");
            var fd = new FormData(); 
            fd.append("filedata", file.files[0]);
            xhr.send(fd);
        });

    }
}

