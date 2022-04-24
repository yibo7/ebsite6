<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyChangeCoupons.ascx.cs"
    Inherits="EbSite.Modules.Shop.UserPages.Controls.OrderManage.MyChangeCoupons" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div class="gdList_title">
    <div style="width: 200px;">
        优惠券名称</div>
    <div style="width: 100px;">
        满足金额</div>
    <div style="width: 100px;">
        面值</div>
    <div style="width: 100px;">
        兑换所需积分</div>
    <div style="width: 160px;">
        有效期(止)</div>
    <div style="width: 100px;">
        操作</div>
</div>
<XS:Repeater ID="gdList" runat="server" OnItemCommand="gdList_ItemCommand"   >
    <ItemTemplate>
        <div class="gdListContent">
            <div style="width: 200px;">
                <%#Eval("CouponName")%></div>
            <div style="width: 100px;">
                <%#Eval("Amount")%></div>
            <div style="width: 100px;">
                <%#Eval("DiscountPrice")%></div>
            <div style="width: 100px;">
                <%#Eval("NeedPoint")%></div>
            <div style="width: 160px;">
                <%#Eval("EndDateTime")%></div>
            <div style="width: 100px;">
                 <XS:LinkButton ID="lbExChange" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="ExChangeModel" Text="兑换"></XS:LinkButton> </div>
        </div>
    </ItemTemplate>
</XS:Repeater>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
