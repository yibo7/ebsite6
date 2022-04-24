var ModulePath = "";
jQuery(function ($) {
    ModulePath = GetModulePath();
});
In.add('ebsitechat', { path: GetModulePath() + 'js/chat.js', type: 'js', charset: 'utf-8' });
function TestAjax() {
    run_ajax_async(ModulePath + "Ajaxget/GetUserInfo.ashx", "", TestAjaxComplete);

}
function TestAjaxComplete(msg) { 
    alert(msg)
}