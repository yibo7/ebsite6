
/////////////////////////////////////////////////////打印操作/////////////////////////////////////
function doPrint(ob) {
    var adBegin = "";
    var adEnd = "";
    var body;
    var css;
    var str;
    str += "<style media=print>.Noprint{display:none;}.PageNext{page-break-after: always;}</style>";
    str = "\n<script type='text/javascript'>\r\nfunction doPrint(){window.print();}\r\n</script>\r\n";
    str += "<center class='Noprint'><p><object id='WebBrowser'  classid='CLSID:8856F961-340A-11D0-A96B-00C04FD705A2'  height='0'  width='0'></object>";
    str += "<input type='button' value='打印' onclick='document.all.WebBrowser.ExecWB(6,1)'> ";
    str += "<input type='button' value='直接打印' onclick='document.all.WebBrowser.ExecWB(6,6)'> ";
    str += "<input  type='button' value='页面设置' onclick='document.all.WebBrowser.ExecWB(8,1)'> ";
    str += "</p><p><input type='button' value='打印预览' onclick='document.all.WebBrowser.ExecWB(7,1)'> ";
    str += "[字体：<input type='button' value='大' onclick='javascript:ContentSize(16,txtword)'> <input type='button' value='中' onclick='javascript:ContentSize(14,txtword)'> <input type='button' value='小' onclick='javascript:ContentSize(12,txtword)'>]";
    str += "</p><hr align='center' width='90%' size='1' noshade='noshade'></center>";
    str += "<div id=\"con\" contenteditable='true'>";
    body = ob.innerHTML;
    //去掉广告
    if (body.indexOf(adBegin) >= 0) {
        str += body.substr(0, body.indexOf(adBegin));
        str += body.substr(body.indexOf(adEnd) + adEnd.length, body.length);
    } else {
        str += body;
    }
    str += "</div>";
    str += "<span>(（EbSite）www.ebsite.net)</span>";
    str += "</p><p><input type='button' value='返回' href='javascript:void(null)' onclick='window.location.reload()'>";
    document.body.innerHTML = str;
}
// 内容样式用户定义
function ContentSize(size, obj) {
    //var obj=document.getElementById("txtword");
    obj.style.fontSize = size > 0 ? size + "px" : "";
    //	if (arguments.length==1){
    //		setCookie("iwmsFontSize",size,size==0?-1:1);
    //	}
}

function OnPrint(objid) {
    doPrint(objid);
    parent.CloseLeftAndTop();
}
function PrintReturn() {

    parent.OpenLeftAndTop();
    window.location.reload();

}
/////打印结束/////