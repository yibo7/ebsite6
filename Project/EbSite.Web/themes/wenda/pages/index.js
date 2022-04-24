
In.ready('infinitescroll', function () {
   
   $(".alldatalistbox").infinitescroll({
        navSelector:'.PagesClass', //分页导航的选择器
        nextSelector:'.PagesClass td .nextpage', //下页连接的选择器
        itemSelector:'.tab2_one',      //你要检索的所有项目的选择器,
        loadingImg:"/images/loading2.gif",     
        loadingText:"加载中...",  
        animate:false,
        donetext:"加载完成",
        extraScrollPx: 300
    
},
function (newElements) {
    //alert($(newElements).html())
        //var $newElems = $( newElements ).css({ opacity: 0 });

});

// 手动点击的元素
$(".loadingbtn input").click(function(){
    $(document).trigger('retrieve.infscr');
    return false;
});
//如果没有下一页，去掉分页，隐藏more按钮
$(document).ajaxError(function (e, xhr, opt) {
    alert(xhr.status)
    if (xhr.status == 404) $('.loadingbtn').remove();
});
// 取消scroll绑定
$(window).unbind(".infscr");

});
In.ready('customtags', function () {
    var Tags = new CustomTags();
    Tags.ParentObjName = "tagsask";
    Tags.SubObj = "div";
    Tags.CurrentClassName = "focus";
    Tags.ClassName = "";
    Tags.InitOnclickInTags();
    //    Tags.InitOnclick(0);
    Tags.InitCurrent(); //跨页时调用
});

 

