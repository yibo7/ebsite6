<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderRefund.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.OrderRefund" %>
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
        <h1 class="title_height">订单退款</h1>
    </div>
    <div class="Emal">
        <ul>
            <li>订单号：<asp:Literal ID="litOrderNum" runat="server"></asp:Literal></li>
            <li>订单实付款(元)：<strong class="colorE" style="font-size:24px;">&yen;<asp:Literal ID="litFactPrice" runat="server"></asp:Literal></strong></li>
            <li>下单日期：<asp:Literal ID="litOrderDate" runat="server"></asp:Literal></li>
        </ul>
    </div>
    <div class="areaform td_bg2">
        <ul>
            <li><span class="formitemtitle Pw_198">退款方式：</span>
                <asp:RadioButtonList ID="rdoRefundReason" runat="server" RepeatDirection="Vertical" RepeatColumns="1">
                   <asp:ListItem Selected="True" Text="我已经跟买家联系，使用线下操作完成退款。" Value="1"></asp:ListItem>     
                   <asp:ListItem Text="使用预付款功能退款到买家的预付款账户。" Value="2"></asp:ListItem>
                 </asp:RadioButtonList></li>
            <li><span class="formitemtitle Pw_198">退款金额：</span><XS:TextBoxVl ID="txtRefundPrice" runat="server" IsAllowNull="false" ValidateType="金额" Width="150" Msg="退款金额不得大于订单总金额.已发货订单允许全额或部分退款,退款后订单自动变为交易成功状态。"></XS:TextBoxVl></li>
            <li><span class="formitemtitle Pw_198">备注说明：</span><XS:TextBox ID="txtReamrk" runat="server" TextMode="MultiLine" Width="260" Height="60"></XS:TextBox><br />
                <abbr class="colorE">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;在这里您可以填写相关买家的银行信息及相关退款事宜，以便日后查询。</abbr></li>
                <li><span class="formitemtitle Pw_198">&nbsp;</span><asp:Button ID="btnConfirmRefundPrice" runat="server" Text=" 确定退款 " CssClass="btnedit" OnClick="btnConfirmRefundPrice_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" value=" 关闭 " class="btnclose" onclick="CloseOrder()" /></li>
            <li style="padding-left:160px;">如何开启预付款？<br />
                <abbr class="colorE">系统默认新注册会员是没有开启预付款功能的。如果要开启，请会员进入前台的会员中心。点击左侧菜单“我的预付款”，
                在打开的页面中。然后点击“确认开启预付款”，输入交易密码，即可开通预付款功能。</abbr></li>
        </ul>
    </div>
</div>
<script type="text/javascript">
    function CloseOrder() {
        $(window.parent.document.body).find("div[class='panel-tool-close']").click();
    }
</script>
