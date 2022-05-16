<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="gather.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_SEO.gather" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="XSD" Namespace="EbSite.ControlData" Assembly="EbSite.ControlData" %>
<div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="active nav-link" href="#tg1" data-bs-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-bug"></i></span>
                    <span class="hidden-xs">选择分类生成采集接口地址</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#tg2" data-bs-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-legal"></i></span>
                    <span class="hidden-xs">字段附加说明</span>
                </a>
            </li>
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <div class="alert alert-success">
                请选择以下分类，会在下面自动生成采集的api地址，其中参数与数据库内容表的字段对应，目前支持入库的内容表字段请参数下在的附加说明
            </div>
            <div>
                <XSD:SelectClass ID="selClass" Size="8" BackFun="onselcomp" runat="server"></XSD:SelectClass>

            </div>
                 <h4 class="m-t-0 m-b-20 header-title"><b>所选分类对应的接口ID</b></h4>
            <div id="tipsApiUrl"></div>
            </div>
            <div id="tg2" class="tab-pane">
                字段附加说明:

SmallPic
            <br />
            NewsTitle<br />
            TitleStyle<br />
            Keywords<br />
            Description<br />
            ClassID<br />
            hits<br />
            IsGood<br />
            ContentInfo<br />
            dayHits<br />
            weekHits<br />
            monthhits<br />
            lasthitstime<br />
            TagIDs<br />
            OrderID<br />
            AddTime<br />
            IsAuditing<br />
            Annex1<br />
            Annex2<br />
            Annex3<br />
            Annex4<br />
            Annex5<br />
            Annex6<br />
            Annex7<br />
            Annex8<br />
            Annex9<br />
            Annex10<br />
            Annex11<br />
            Annex12<br />
            Annex13<br />
            Annex14<br />
            Annex15<br />
            Annex16<br />
            Annex17<br />
            Annex18<br />
            Annex19<br />
            Annex20<br />
            Annex21<br />
            Annex22<br />
            Annex23<br />
            Annex24<br />
            Annex25<br />
            TagIDs
            </div>
        </div>
    </div>
</div>
 

 <script>
                var ThisSiteId = <%=base.GetSiteID%>;
                var ThisSiteDomain = '<%=HostApi.Domain%>';
                var sitekey =  '<%=EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey%>';
                var UserID =  <%=base.UserID%>;
                function onselcomp() {
        
                    var selID = $("#<%=selClass.hfValue.ClientID%>").val();
        var url = ThisSiteDomain + "/mvceb/" + ThisSiteId + "/addcontent/" + selID+"/"+UserID+"/"+sitekey+"/" + "?参数1=值1&参数2=值2";
       
        $("#tipsApiUrl").html(url);
    }
            </script>