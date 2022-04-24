<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendOrder.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.SendOrder" %>
<%@ Import Namespace="EbSite.Modules.Shop" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="divpanel">
    <div class="headtitle">
        订单详情</div>
    <div class="commpanel">
        <div class="orderstate">
            <table width="600px" cellpadding="10">
                <tr>
                    <td align="right">
                        订单编号：
                    </td>
                    <td>
                        <%=Model.OrderId %>
                    </td>
                    <td align="right">
                        下单时间：
                    </td>
                    <td>
                        <%=Model.OrderAddDate %>
                    </td>
                </tr>
                </table>
            </div>
    </div>
    <div class="headtitle">
        订单发货</div>
    <div class="commpanel">
        <table width="800px" cellpadding="10">
                <tr>
                    <td style="width:60px; text-align:right;">配送方式：</td><td style="text-align:left;"><asp:RadioButtonList ID="rdoSendList" runat="server" RepeatDirection="Horizontal" RepeatColumns="10" AutoPostBack="true" OnSelectedIndexChanged="rdoSendList_SelectedIndexChanged" ValidationGroup="pswl"></asp:RadioButtonList></td>
                </tr>
            <tr>
                <td style="width:60px; text-align:right;">物流公司：</td><td style="text-align:left;"><asp:RadioButtonList ID="rdoWlCompanyList" runat="server" RepeatDirection="Horizontal" RepeatColumns="10"></asp:RadioButtonList></td>
            </tr>
            <tr>
                    <td style="width:60px; text-align:right;">运单号码：</td><td style="text-align:left;"><XS:TextBoxVl ID="txtSendNum" runat="server" IsAllowNull="false" Msg="运单号码不能为空，在1至20个字符之间" MsgErr="运单号码不能为空，在1至20个字符之间" ValidationGroup="ydnum"></XS:TextBoxVl></td>
                </tr>
            <tr><td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSendOrder" runat="server" Text=" 确认发货 " OnClick="btnSendOrder_Click" ValidationGroup="ydnum" /></td>
            </tr>
        </table>
    </div>
    <div class="headtitle">
        商品列表</div>
    <div class="commpanel">
        <table border="0" cellspacing="0" class="datalist_orderitem">
            <thead>
                <tr>
                    <th colspan="2" style="width:580px;">
                        商品名称
                    </th>
                    <th style="width:80px;">
                        商品单价(元)
                    </th>
                    <th style="width:80px;">
                        购买数量
                    </th>
                    <th style="width:80px;">
                        发货数量
                    </th>
                    <th style="width:80px;">
                        总价(元)
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptOrderItem" runat="server" OnItemDataBound="rptOrderItem_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td style="border-left:1px solid #E0DCCE;"><a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),SettingInfo.Instance.GetSiteID)%>" target="_blank"><img alt="" src="<%# Eval("ThumbnailsUrl") %>" /></a></td>
                            <td>
                                <a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),SettingInfo.Instance.GetSiteID)%>" target="_blank"><%# Eval("ProductName") %></a><br />
                                <span>货号：<%# Eval("SKU") %>  <%# Eval("SKUContent") %></span>
                            </td>
                            <td>&yen;<%# Eval("MemberPrice")%></td>
                            <td><%# Eval("Quantity")%></td>
                            <td><%# EbSite.Core.Utils.ObjectToInt(Eval("Quantity"),0)+EbSite.Core.Utils.ObjectToInt(Eval("GiveQuantity"),0)%></td>
                            <td style="border-right:1px solid #E0DCCE;">&yen;<%# ((decimal)Eval("MemberPrice")*(int)Eval("Quantity")) %></td>
                        </tr>
                                <asp:Repeater ID="rptGiveaWay" runat="server">
                                    <HeaderTemplate>
                                        <tr>
                            <td colspan="6">
                                        <table border="0" cellspacing="0" class="datalist_orderitem">
                                            <thead>
                                                <tr>
                                                    <th colspan="2" style="width: 500px;">
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
                                            <td style="border-left: 1px solid #E0DCCE;">
                                                <a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("GiftProductId").ToString()),SettingInfo.Instance.GetSiteID)%>"
                                                    target="_blank">
                                                    <img alt="" src="<%# Eval("smallpic") %>" /></a>
                                            </td>
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
                                        </td>
                        </tr>
                                        </tbody> </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td></td><td></td><td></td><td></td><td align="right">商品金额：</td><td>&yen;<%=Model.OrderTotal %></td>
                </tr>
                <tr>
                    <td></td><td></td><td></td><td></td><td align="right">商品总重量：</td><td><%=Model.Weight%>(克)</td>
                </tr>
            </tbody>
        </table>
    </div>
    <asp:Repeater ID="RepCredits" runat="server">
        <HeaderTemplate>
            <div class="headtitle">
                积分兑换商品列表</div>
            <div class="commpanel">
                <table border="0" cellspacing="0" class="datalist_orderitem">
                    <thead>
                        <tr>
                            <th colspan="2" style="width: 580px;">
                                礼品名称
                            </th>
                            <th style="width: 80px;">
                                兑换数量
                            </th>
                        </tr>
                    </thead>
                    <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="border-left: 1px solid #E0DCCE;">
                    <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.JiFenShow(SettingInfo.Instance.GetSiteID,Eval("CreditProductID")) %>"
                        target="_blank">
                        <img alt="" src="<%# Eval("SmallImg") %>" /></a>
                </td>
                <td>
                    <%# Eval("ProductName")%><br />
                </td>
                <td>
                    <%# Eval("Quantity")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table> </div>
        </FooterTemplate>
    </asp:Repeater>
    <div class="headtitle">物流信息</div>
     <table class="orderpriceinfo" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <td align="right" width="150">收货地址：</td><td align="left"><%=Model.Address%>&nbsp;&nbsp;&nbsp;<a class="btnlink" onclick="OpenEditAddress()">修改收货地址</a></td>
            </tr>
            <tr>
                <td align="right" width="150">配送方式：</td><td align="left"><%=Model.ModeName%></td>
            </tr>
            <tr>
                <td align="right" width="150">买家留言：</td><td align="left"><%=Model.Remark%></td>
            </tr>
     </table>
</div>
<div style="text-align: center">
    <input type="button" value=" 返 回 列 表 " class="AdminButton" onclick="BackUpList()" />
</div>
<script type="text/javascript">
    var rid = "<%=Model.id %>";
    function OpenEditAddress() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=9&id=" + rid, "编辑收货地址信息", 500, 360, true);
    }
    function OpenEditSend() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=10&id=" + rid, "编辑配送方式", 500, 200, true);
    }
    function OpenEditPay() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=11&id=" + rid, "编辑支付方式", 500, 200, true);
    }
    //关闭订单
    function CloseOrder() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=5&id=" + rid, "关闭订单", 600, 200, true);
    }

    //标注订单
    function MarkOrder() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=7&id=" + rid, "编辑备注信息", 500, 360, true);
    }
    function EditOrderPrice() {
        window.location.href = "Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=4&id=" + rid;
    }
    function BackUpList()
    {
        window.location.href = "Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b";
    }
    var ostatus = "<%=Model.OrderStatus %>";
    if (ostatus == "4")
    {
        $("#btnEditPrice").hide();
        $("#btnCloseOrder").hide();
    }
</script>