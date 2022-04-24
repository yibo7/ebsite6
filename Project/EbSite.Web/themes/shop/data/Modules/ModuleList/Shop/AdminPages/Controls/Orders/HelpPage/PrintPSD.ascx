<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintPSD.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.PrintPSD" %>
<%@ Import Namespace="EbSite.Modules.Shop" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div style="width:80%; margin-left:auto; margin-right:auto;">
<div class="divclear">&nbsp;</div>
<table class="printnocss" border="0" cellspacing="0">
    <tr>
        <th>订购日期:</th><td><asp:Literal ID="litAddDate" runat="server"></asp:Literal></td>
        <th>收货人:</th><td><asp:Literal ID="litRecevUName" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <th>支付方式:</th><td><asp:Literal ID="litPayType" runat="server"></asp:Literal></td>
        <th>订单号:</th><td><asp:Literal ID="litOrderNum" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <th>邮政编码:</th><td><asp:Literal ID="litZipCode" runat="server"></asp:Literal></td>
        <th>配送方式:</th><td><asp:Literal ID="litSendType" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <th>发货单号:</th><td><asp:Literal ID="litSendNum" runat="server"></asp:Literal></td>
        <th>电话号码:</th><td><asp:Literal ID="litPhoneNum" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <th>收货地址:</th><td><asp:Literal ID="litRecevAddress" runat="server"></asp:Literal></td>
        <th>手机号码:</th><td><asp:Literal ID="litMobilNum" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <th>订单状态:</th><td><asp:Literal ID="litOrderState" runat="server"></asp:Literal></td>
        <th>备注:</th><td><asp:Literal ID="litOrderRemark" runat="server"></asp:Literal></td>
    </tr>
</table>
<table class="printlist">
    
    <asp:Repeater ID="rptDataList" runat="server" OnItemDataBound="rptDataList_ItemDataBound">
        <HeaderTemplate>
<thead><tr><th>货号</th><th>商品</th><th>商品单价</th><th>购买数量</th><th>发货数量</th><th>小计</th></tr></thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="text-align:center"><%# Eval("SKU") %>  <%# Eval("SKUContent") %></td>
                <td style="text-align:center"><%# Eval("ProductName") %></td>
                <td style="text-align:center">&yen;<%# Eval("MemberPrice")%></td>
                <td style="text-align:center"><%# Eval("Quantity")%></td>
                <td><%# EbSite.Core.Utils.ObjectToInt(Eval("Quantity"),0)+EbSite.Core.Utils.ObjectToInt(Eval("GiveQuantity"),0)%></td>
                <td style="text-align:center">&yen;<%# ((decimal)Eval("MemberPrice")*(int)Eval("Quantity")) %></td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:right;">
                    <asp:Repeater ID="rptGiveaWay" runat="server">
                            <HeaderTemplate>
                                <table>
                                    <thead>
                                        <tr>
                                            <th style="width:200px;">
                                                赠品名称
                                            </th>
                                            <th style="width: 80px;">
                                                商品单价(元)
                                            </th>
                                            <th style="width: 80px;">
                                                赠送数量
                                            </th>
                                            <th style="width: 80px;">
                                                发货数量
                                            </th>
                                            <th style="width: 80px;">
                                                总价(元)
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("GiftProductId").ToString()),SettingInfo.Instance.GetSiteID)%>"
                                            target="_blank">
                                            <%#Eval("newstitle") %></a><br />
                                    </td>
                                    <td>
                                        <%#Eval("annex16") %>
                                    </td>
                                    <td>
                                        <%# Eval("Quantity")%>
                                    </td>
                                    <td>
                                        <%# Eval("Quantity")%>
                                    </td>
                                    <td>
                                        &yen;<%# (Convert.ToDecimal( Eval("annex16").ToString())*(int)Eval("Quantity")) %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
        <asp:Repeater ID="rptCoreOrder" runat="server">
                        <HeaderTemplate>
                            <tr><th style="width:200px;">
                                                序号
                                            </th>
                                            <th style="width:360px;" colspan="4">
                                                名称
                                            </th>
                                            <th style="width: 80px;">
                                                数量
                                            </th></tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr><td style="width:80px;">
                                                <%# Container.ItemIndex+1 %>
                                            </td>
                                            <td style="width:360px;" colspan="4">
                                                <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.JiFenShow(SettingInfo.Instance.GetSiteID,Eval("CreditProductID")) %>" target="_blank"><%# Eval("ProductName")%></a>
                                            </td>
                                            <td style="width: 80px;">
                                                <%# Eval("quantity") %>
                                            </td></tr>
                        </ItemTemplate>
                    </asp:Repeater>
</table>
<div style="height:20px;"></div>
<div class="divclear">&nbsp;</div>
<div class="writename">签名：</div>
<div style="width:100%; text-align:center;">
    <asp:Button ID="btnPrint" runat="server" Text=" 打 印 " OnClick="btnPrint_Click" />
</div>
</div>
<script type="text/javascript">
    function PrintOrder() {
        window.print();
    }
    //自动放大
    $(window.parent.document.body).find("div[class='panel-tool-max']").click();
</script>
