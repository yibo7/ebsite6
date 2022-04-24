<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.OrderDetail" %>
<%@ Import Namespace="EbSite.Modules.Shop" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="divpanel">
    <div class="headtitle">
        订单详情</div>
    <div class="commpanel">
        <asp:Literal ID="labStep" runat="server"></asp:Literal>
        <div class="orderstate">
            <span>当前订单状态：<asp:Literal ID="litOrderState" runat="server"></asp:Literal></span><br />
            <br />
            <input type="button" value="修改价格" class="btnedit" id="btnEditPrice" onclick="EditOrderPrice()" />
            <input type="button" value="备注" class="btnmark" id="btnRemark" onclick="MarkOrder()" />
            <input type="button" value="关闭订单" class="btnclorder" id="btnCloseOrder" onclick="CloseOrder()" />
            <input type="button" value="退款" class="btnrefundorder" id="btnRefOrder" onclick="RefundOrder()" style="display: none;" />
            <input type="button" value="日志" class="btnmark" id="btnLog" onclick="LogOrder()" />
            <input type="button" value="快递打印" class="btnprint" id="Button1" onclick="PrintOrder('KDD')" />
            <input type="button" value="购货打印" class="btnprint" id="Button2" onclick="PrintOrder('GHD')" />
            <input type="button" value="配送打印" class="btnprint" id="Button3" onclick="PrintOrder('PSD')" />
            <br />
            <table width="600px" cellpadding="10">
                <tr>
                    <td align="right">
                        订单编号：
                    </td>
                    <td>
                        <%=Model.OrderId %>
                    </td>
                    <td align="right">
                        联系电话：
                    </td>
                    <td>
                        <%=Model.CellPhone %>
                    </td>
                    <td align="right">
                        会员名：
                    </td>
                    <td>
                        <%=Model.Username %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        真实姓名：
                    </td>
                    <td>
                        <%=Model.RealName %>
                    </td>
                    <td align="right">
                        电子邮件：
                    </td>
                    <td>
                        <%=Model.EmailAddress %>
                    </td>
                    <td align="right">
                        邮政编码：
                    </td>
                    <td>
                        <%=Model.ZipCode %>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="headtitle">
        商品列表</div>
    <div class="commpanel">
        <table border="0" cellspacing="0" class="datalist_orderitem">
            <thead>
                <tr>
                    <th colspan="2" style="width: 580px;">
                        商品名称
                    </th>
                    <th style="width: 80px;">
                        商品单价(元)
                    </th>
                    <th style="width: 80px;">
                        购买数量
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
                <asp:Repeater ID="rptOrderItem" runat="server" OnItemDataBound="rptOrderItem_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td style="border-left: 1px solid #E0DCCE;">
                                <a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),SettingInfo.Instance.GetSiteID)%>"
                                    target="_blank">
                                    <img alt="" src="<%# Eval("ThumbnailsUrl") %>" width="60" height="60" /></a>
                            </td>
                            <td>
                                <a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),SettingInfo.Instance.GetSiteID)%>"
                                    target="_blank">
                                    <%# Eval("ProductName") %></a><br />
                                <span>货号：<%# Eval("SKU") %>
                                    <%# Eval("SKUContent") %></span>
                            </td>
                            <td>
                                &yen;<%# Eval("MemberPrice")%>
                            </td>
                            <td>
                                <%# Eval("Quantity") %>
                            </td>
                            <td>
                                <%# EbSite.Core.Utils.ObjectToInt(Eval("Quantity"),0)+EbSite.Core.Utils.ObjectToInt(Eval("GiveQuantity"),0)%>
                            </td>
                            <td style="border-right: 1px solid #E0DCCE;">
                                &yen;<%# ((decimal)Eval("MemberPrice")*(int)Eval("Quantity")) %>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Repeater ID="rptGiveaWay" runat="server">
                                    <HeaderTemplate>
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
                                                    <img alt="" src="<%# Eval("smallpic") %>" width="60" height="60" /></a>
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
                                        </tbody> </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        商品金额：
                    </td>
                    <td>
                        &yen;<%=Model.Amount %>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        商品总重量：
                    </td>
                    <td>
                        <%=Model.Weight%>(克)
                    </td>
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
                    <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.JiFenShow( SettingInfo.Instance.GetSiteID,Eval("CreditProductID")) %>"
                        target="_blank">
                        <img alt="" src="<%# Eval("SmallImg") %>" width="60" height="60" /></a>
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
    <div class="headtitle">
        订单费用</div>
    <div class="commpanel">
        <table class="orderpriceinfo" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <td align="right" width="150">
                    满额打折优惠：
                </td>
                <td width="130">
                    <asp:Literal ID="litDisAmount" runat="server"></asp:Literal>
                </td>
                <td>
                    <%= string.IsNullOrEmpty(Model.DiscountName)?"暂无":Model.DiscountName %>
                </td>
            </tr>
            <tr>
                <td align="right">
                    满额免费用活动：
                </td>
                <td>
                    <asp:Literal ID="litActName" runat="server"></asp:Literal>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    运费：
                </td>
                <td>
                    <asp:Literal ID="litAdjFrei" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="litAdjFreiName" runat="server"></asp:Literal>&nbsp;&nbsp;<a class="btnlink"
                        onclick="OpenEditSend()">修改配送方式</a>
                </td>
            </tr>
            <tr>
                <td align="right">
                    支付手续费：
                </td>
                <td>
                    <asp:Literal ID="litPayFree" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="litPayFreeName" runat="server"></asp:Literal>&nbsp;&nbsp;<a class="btnlink"
                        onclick="OpenEditPay()">修改支付方式</a>
                </td>
            </tr>
            <tr>
                <td align="right">
                    订单选项费用：
                </td>
                <td>
                    <asp:Literal ID="litOrderOptionPrice" runat="server"></asp:Literal>
                </td>
                <td>
                    &nbsp;<asp:Literal ID="litOrderOptionName" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td align="right">
                    优惠券折扣：
                </td>
                <td>
                    <asp:Literal ID="litCouponValue" runat="server"></asp:Literal>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    涨价或减价：
                </td>
                <td>
                    <asp:Literal ID="litAdjusted" runat="server"></asp:Literal>
                </td>
                <td>
                    为负代表折扣，为正代表涨价
                </td>
            </tr>
            <tr>
                <td align="right">
                    订单可得积分：
                </td>
                <td>
                    <asp:Literal ID="litOrderScore" runat="server"></asp:Literal>
                </td>
                <td>
                </td>
            </tr>
              <tr>
                <td align="right">
                    使用预付款：
                </td>
                <td>
                    <asp:Literal ID="litUserBalance" runat="server"></asp:Literal>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    订单实收款：
                </td>
                <td>
                    <asp:Literal ID="litOrderTotal" runat="server"></asp:Literal>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div class="headtitle">
        物流信息</div>
    <table class="orderpriceinfo" border="0" cellpadding="10" cellspacing="0">
        <tr>
            <td align="right" width="150">
                收货地址：
            </td>
            <td align="left">
                <%=Model.Address%>&nbsp;&nbsp;&nbsp;<a class="btnlink" onclick="OpenEditAddress()">修改收货地址</a>
            </td>
        </tr>
        <tr>
            <td align="right" width="150">
                配送方式：
            </td>
            <td align="left">
                <%=string.IsNullOrEmpty(Model.RealModeName) ? (string.IsNullOrEmpty(Model.ModeName) ? "暂无" : Model.ModeName) : Model.RealModeName%>
            </td>
        </tr>
        <tr>
            <td align="right" width="150">
                买家留言：
            </td>
            <td align="left">
                <%=Model.Remark%>
            </td>
        </tr>
    </table>
</div>
<div style="text-align: center">
    <a href="javascript:history.go(-1);" class="AdminButton" style="display:block; height: 33px;width: 140px;">返 回 列 表</a> 
<%--    <input type="button" value=" 返 回 列 表 " class="AdminButton" onclick="BackUpList()" />--%>
</div>
<script type="text/javascript">
    var rid = "<%=Model.id %>";
    var oid = "<%=Model.OrderId %>";
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
    //退款
    function RefundOrder() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=16&id=" + rid, "订单退款操作", 730, 500, true);
    }

    //日志
    function LogOrder() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=17&id=" + oid, "订单日志", 730, 500, true);
    }

    //标注订单
    function MarkOrder() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=7&id=" + rid, "编辑备注信息", 500, 360, true);
    }
    function EditOrderPrice() {
        window.location.href = "Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=4&id=" + rid;
    }
//    function BackUpList() {
//        window.location.href = "Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b";
//    }
    var ostatus = "<%=Model.OrderStatus %>";
    if ( ostatus == "21"||ostatus=="1") {
        $("#btnEditPrice").hide();
        $("#btnCloseOrder").hide();
        $("#btnRemark").hide();
    }
    else if(ostatus == "3")
    {
        $("#btnEditPrice").hide();
        $("#btnrefundorder").hide();
    }
    else if (ostatus == "4" || ostatus == "5") {
        $("#btnEditPrice").hide();
        $("#btnRefOrder").show();
        $(".btnlink").hide();
    }
    else if (ostatus == "6") {
        //回收站
        $("#btnEditPrice").hide();
        $("#btnCloseOrder").hide();
        $("#btnRemark").hide();
        $("#btnLog").hide();
        $("#Button1").hide();
        $("#Button2").hide();
        $("#Button3").hide();
        $(".btnlink").hide();
    }


    //打印
    function PrintOrder(actonname) {

        if (actonname == "KDD") {
            //快递单
            OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=12&id=" + rid, "打印快递单", 900, 200, true);
        }
        else if (actonname == "GHD") {
            //购货单
            OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=13&id=" + rid, "打印购货单", 600, 200, true);
        }
        else if (actonname == "PSD") {
            //配送单
            OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=14&id=" + rid, "打印配送单", 600, 200, true);
        }
    }
</script>
