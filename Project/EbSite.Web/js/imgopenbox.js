////////////////////////////////////内容页的图片浏览//////////////////


function ImgObj() {

    this.caption = "";
    this.url = "";
    //    if (typeof CustomTags._initialized == "undefined") {
    //       
    //    }
    //    CustomTags._initialized = true;

}
var GB_ROOT_DIR = "/js/openbox/";
function ContentImgShow(obContentName, sWidth, sHeigth) {

    var image_set = [];
    var SelectOb = "#" + obContentName;
    if (obContentName == null) {
        SelectOb = "body";
    }

    $(SelectOb).find("img").each(
		function (i) {
		    var obImg = new ImgObj();

		    obImg.caption = "图片浏览";
		    obImg.url = this.src;

		    image_set.push(obImg);
		    if (sWidth != "") this.style.width = sWidth;
		    if (sHeigth != "") this.style.height = sHeigth;
		    this.style.cursor = "pointer"
		    this.alt = "点击一下放大图片";
		    this.onclick = function () { ShowImg(image_set, i) };

		}
		);

    if (image_set.length > 0) {

        document.writeln('<script type="text/javascript" src="/js/openbox/AJS.js"></script>');
        document.writeln('<script type="text/javascript" src="/js/openbox/AJS_fx.js"></script>');
        document.writeln('<script type="text/javascript" src="/js/openbox/gb_scripts.js"></script>');
        document.writeln('<link href="/js/openbox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />');

    }

}
function ShowImg(aImage_set, Index) {

    GB_showImageSet(aImage_set, Index + 1);

}