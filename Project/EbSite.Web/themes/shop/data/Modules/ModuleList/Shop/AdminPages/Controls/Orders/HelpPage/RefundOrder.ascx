<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RefundOrder.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.RefundOrder" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls" TagPrefix="XE" %>
<style type="text/css">
    body
    {
        font-size: 12px;
        line-height: 24px;
        font-family: "宋体" , "Arial Narrow";
        background: #fff;
        margin: 0px;
    }
    form, ul, li, ol, li, dl, dt, dd, img, p, h1, h2, h3, h4, h5, h6
    {
        margin: 0;
        padding: 0;
        border: 0;
        list-style: none;
    }
    a
    {
        text-decoration: none;
    }
    a:hover
    {
        text-decoration: underline;
    }
    .dataarea
    {
        border-bottom: #ccc 1px solid;
        border-left: #ccc 1px solid;
        padding-bottom: 15px;
        margin: auto;
        padding-left: 15px;
        width:650px;
        padding-right: 15px;
        height: auto;
        overflow: auto;
        border-top: #ccc 1px;
        border-right: #ccc 1px solid;
        padding-top: 15px;
        _height: 1px;
        _overflow: visible;
    }
    .dataarea .toptitle
    {
        font-size: 14px;
        font-weight: 700;
        overflow: hidden;
        padding-bottom: 10px;
    }
    .dataarea .toptitle em
    {
        float: left;
        padding-top: 3px;
        width: 43px;
    }
    .dataarea .toptitle h1
    {
        line-height: 20px;
        font-size: 14px;
    }
    .dataarea .toptitle span
    {
        color: #888888;
        font-size: 12px;
        font-weight: normal;
        line-height: 20px;
    }
    .dataarea .Emal
    {
        padding: 5px 10px;
        border: 1px #dfdfdf solid;
        font-size: 14px;
        overflow: hidden;
        margin-bottom: 15px;
        background: #f5f5f5;
        height: 25px;
    }
    .dataarea .Emall
    {
        padding: 5px 10px;
        font-size: 14px;
        overflow: hidden;
        margin-bottom: 15px;
        border: 1px #e1e1e1 solid;
        margin-bottom: 0px;
        border-bottom: 0;
        background: #fafafa;
    }
    .dataarea .Emal li, .Emall li
    {
        float: left;
        margin-right: 30px;
    }
    .dataarea .areaform li
    {
        margin-bottom: 18px;
        text-align: left;
        clear: both;
    }
    .dataarea .areaform em
    {
        color: #F00;
        padding-right: 5px;
        font-family: Georgia, "Times New Roman" , Times, serif;
    }
    .areaform span
    {
        float: left;
        display: block;
    }
    .td_bg2
    {
        background: #fff9ee;
        border: 1px solid #ffe8ba;
        padding-top: 15px;
        margin-bottom: 15px;
    }
    .formitemtitle
    {
        text-align: right;
        font-size: 14px;
        line-height: 28px;
    }
    .Pw_198
    {
        width: 198px;
    }
    .colorA
    {
        color: #ff0000 !important;
    }
    .colorB
    {
        color: #006b0a;
    }
    .colorC
    {
        color: #785540;
    }
    .colorD
    {
        color: #888;
        padding: 10px 0px 0px 12px;
    }
    .colorE
    {
        color: #ff7f00 !important;
    }
    .colorF
    {
        color: #666;
    }
    .colorG
    {
        color: #ff4800;
    }
    .colorO
    {
        color: #fff;
    }
    .colorP
    {
        color: #ffff00;
    }
    .colorQ
    {
        color: #666;
    }
    .colorR
    {
        color: #888;
        line-height: 30px;
    }
    .colorH
    {
        border-bottom: 1px solid #CCCCCC;
        font-size: 14px;
        line-height: 30px;
        margin: 20px 0;
        width: 745px;
        color: #FF7F00 !important;
    }
    .fonts
    {
        font-size: 14px;
        color: #000;
    }
</style>
<div class="dataarea td_top_ccc">
    <div class="toptitle">
        <h1 class="title_height">
            <asp:Literal ID="litRefundStateEx" runat="server"></asp:Literal></h1>
    </div>
    <div class="Emal">
        <ul>
            <li>订单号：<asp:Literal ID="litOrderNum" runat="server"></asp:Literal></li>
            <li>成交时间：<asp:Literal ID="litSuccesDate" runat="server"></asp:Literal></li>
            <li>订单实付款(元)：<strong class="colorE">&yen;<asp:Literal ID="litFactPrice" runat="server"></asp:Literal></strong></li>
        </ul>
    </div>
    <div class="areaform td_bg2">
        <ul>
            <li><span class="formitemtitle Pw_198">退款时间：</span><asp:Literal ID="litRefundDate" runat="server"></asp:Literal></li>
            <li><span class="formitemtitle Pw_198">退款状态：</span><asp:Literal ID="litRefundState" runat="server"></asp:Literal></li>
            <li><span class="formitemtitle Pw_198">退款给买家的金额(元)：</span><strong class="colorE fonts">&yen;<asp:Literal ID="litRefundPrice" runat="server"></asp:Literal></strong></li>
            <li><span class="formitemtitle Pw_198">退款方式：</span><asp:Literal ID="litRefundMothd" runat="server"></asp:Literal></li>
            <li><span class="formitemtitle Pw_198">退款说明：</span><asp:Literal ID="litRefundMark" runat="server"></asp:Literal></li>
            <li><span class="formitemtitle Pw_198"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong class="colorA">提示：</strong><abbr class="colorE"><asp:Literal ID="litRefundMothdEx" runat="server"></asp:Literal></abbr></li>
                <li><span class="formitemtitle Pw_198">&nbsp;</span><input type="button" value=" 关闭 " onclick="CloseOrder()" class="btnclose" /></li>
        </ul>
    </div>
</div>
<script type="text/javascript">
    function CloseOrder() {
        $(window.parent.document.body).find("div[class='panel-tool-close']").click();
    }
</script>
