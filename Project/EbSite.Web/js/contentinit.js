
function InitOrderSum() {

    $("#dayhitssum").html("载入中...");
    run_ajax_async(SiteConfigs.UrlIISPath + "Ajax/HitsSum.ashx", "", InitOrderSum_Comp)

}
function InitOrderSum_Comp(msg) {

    $("#dayhitssum").html(msg);
}

function initContentHits(sid) {
    $("#dayhits").html("载入中...");
    $("#allhits").html("载入中...");

    run_ajax_async_type(SiteConfigs.UrlIISPath + "Ajax/ContentHits.ashx", "id=" + sid, initContentHits_comp, "post");
}
function initContentHits_comp(msg) {
    if (msg != null && msg != '') {

        var aHitsInfo = msg.split(SPLITTER_FIELD);
        if (aHitsInfo.length == 2) {
            $("#dayhits").html(aHitsInfo[1]);
            $("#allhits").html(aHitsInfo[0]);
        }
    }
}