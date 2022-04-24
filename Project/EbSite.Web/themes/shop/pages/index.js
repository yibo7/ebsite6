
$(function () {

});

//function showIndex(obj, num) {
//    tm = window.setTimeout(function () {
//        obj.className = 'on';
//        document.getElementById('index-' + num).style.display = 'block';
//    }, 0);
//}
//function hideIndex(obj, num, e) {
//    clearTimeout(tm);
//    var owrap = document.getElementById('index-' + num);
//    if (/Firefox/.test(window.navigator.userAgent)) {
//        if (!(owrap.compareDocumentPosition(e.relatedTarget) & 16) && owrap != e.relatedTarget) {
//            obj.className = "";
//            owrap.style.display = 'none';
//            return;
//        }
//        owrap.onmouseout = function (evt) {
//            if (!(this.compareDocumentPosition(evt.relatedTarget) & 16) && this != evt.relatedTarget) {
//                obj.className = "";
//                this.style.display = 'none';
//            }
//        }
//        return;
//    }
//    if (owrap.contains(e.toElement)) {
//        owrap.onmouseout = function () {
//            if (this.contains(event.toElement)) {
//                return;
//            }
//            this.style.display = 'none';
//            obj.className = '';
//        }
//        return;
//    }
//    obj.className = '';
//    owrap.style.display = 'none';
//}
//   