<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SaleTargets.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.SelReport.SaleTargets" %>
<style type="text/css">
    .ordertoolbar {
        background-color:#FAFAFA;
        border:1px solid #DDDDDD;
        width:988px;
        height:30px;
        line-height:30px;
        vertical-align:middle;
        margin-left:10px;
        margin-top:10px;
        color:#666666;
        font-weight:bold;
        font-size:14px;
        padding-left:10px;
    }

    .orderdetail {
    border-collapse:collapse;
    margin-left:10px;
    width:1000px;
    }
    .orderdetail thead tr{
    background-color:#ECE9E0;
    }
    .orderdetail thead tr td {
    color:#666666;
    font-weight:bold;
    font-size:12px;
    padding:5px 10px;
    border-left:1px solid #DDDDDD;
    }
    .orderdetail tbody tr{
    background-color:#FFFFFF;
    }
    .orderdetail tbody tr td {
    color:#666666;
    font-weight:bold;
    font-size:12px;
    padding:5px 10px;
    border-left:1px solid #DDDDDD;
    border-bottom:1px solid #DDDDDD;
    }

</style>
<div class="ordertoolbar">平均每位客户订单金额</div>
<table class="orderdetail">
    <thead>
        <tr><td width="330px">订单总金额</td><td>总会员数</td><td style="border-right:1px solid #DDDDDD;width:330px;">平均每位客户订单金额</td></tr>
    </thead>
    <tbody>
        <tr>
            <td>&yen;<asp:Literal ID="litOrderTotalPrice" runat="server"></asp:Literal></td>
            <td><asp:Literal ID="litMemberQuantity" runat="server"></asp:Literal></td>
            <td style="border-right:1px solid #DDDDDD;">&yen;<asp:Literal ID="litMemberPrice" runat="server"></asp:Literal></td>
        </tr>
    </tbody>
</table>

<div class="ordertoolbar">平均每次访问订单金额</div>
<table class="orderdetail">
    <thead>
        <tr><td width="330px">订单总金额</td><td>总访问次数</td><td style="border-right:1px solid #DDDDDD;width:330px;">平均每次访问订单金额</td></tr>
    </thead>
    <tbody>
        <tr>
            <td>&yen;<asp:Literal ID="litOrderTotalPrice1" runat="server"></asp:Literal></td>
            <td><asp:Literal ID="litViewTimes" runat="server"></asp:Literal></td>
            <td style="border-right:1px solid #DDDDDD;">&yen;<asp:Literal ID="litTimesPrice" runat="server"></asp:Literal></td></tr>
    </tbody>
</table>

<div class="ordertoolbar">订单转化率</div>
<table class="orderdetail">
    <thead>
        <tr><td width="330px">总订单数</td><td>总访问次数</td><td style="border-right:1px solid #DDDDDD;width:330px;">订单转化率</td></tr>
    </thead>
    <tbody>
        <tr>
            <td><asp:Literal ID="litTotalOrderQuantity" runat="server"></asp:Literal></td>
            <td><asp:Literal ID="litViewTimes2" runat="server"></asp:Literal></td>
            <td style="border-right:1px solid #DDDDDD;"><asp:Literal ID="litOrderRate" runat="server"></asp:Literal>%</td></tr>
    </tbody>
</table>

<div class="ordertoolbar">注册会员购买率</div>
<table class="orderdetail">
    <thead>
        <tr><td width="330px">有过订单的会员</td><td>总会员数</td><td style="border-right:1px solid #DDDDDD;width:330px;">注册会员购买率</td></tr>
    </thead>
    <tbody>
        <tr>
            <td><asp:Literal ID="litHaveOrderMember" runat="server"></asp:Literal></td>
            <td><asp:Literal ID="litMemberQuantity2" runat="server"></asp:Literal></td>
            <td style="border-right:1px solid #DDDDDD;"><asp:Literal ID="litMemberBuyRate" runat="server"></asp:Literal>%</td></tr>
    </tbody>
</table>

<div class="ordertoolbar">平均会员订单量</div>
<table class="orderdetail">
    <thead>
        <tr><td width="330px">总订单数</td><td>总会员数</td><td style="border-right:1px solid #DDDDDD;width:330px;">平均会员订单量</td></tr>
    </thead>
    <tbody>
        <tr>
            <td><asp:Literal ID="litTotalOrderQuantity2" runat="server"></asp:Literal></td>
            <td><asp:Literal ID="litMemberQuantity3" runat="server"></asp:Literal></td>
            <td style="border-right:1px solid #DDDDDD;"><asp:Literal ID="litMemberOrderQuantity" runat="server"></asp:Literal></td></tr>
    </tbody>
</table>