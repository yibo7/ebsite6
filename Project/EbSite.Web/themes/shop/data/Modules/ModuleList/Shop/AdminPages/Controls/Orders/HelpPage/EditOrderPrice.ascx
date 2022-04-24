<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditOrderPrice.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.EditOrderPrice" %>
<%@ Import Namespace="EbSite.Modules.Shop" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="divpanel">
    <div class="headtitle">修改订单价格</div>
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
                    <th style="width:100px;">
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
                            <td style="border-left:1px solid #E0DCCE;"><a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),SettingInfo.Instance.GetSiteID)%>" target="_blank"><img alt="" src="<%# Eval("ThumbnailsUrl") %>" width="60" height="60" /></a></td>
                            <td><a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),SettingInfo.Instance.GetSiteID)%>" target="_blank"><%# Eval("ProductName") %></a><br /><span>货号：<%# Eval("SKU") %>  <%# Eval("SKUContent") %></span></td>
                            <td>&yen;<%# Eval("MemberPrice")%></td>
                            <td><span id="btnaddcount">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;<input type="text" value="<%# Eval("Quantity")%>" class="TextBoxDefault" style="width:30px;" />&nbsp;&nbsp;<span id="btnacccount">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;
                                <a href="javascript:void(0);" tid="<%# Eval("id") %>" mp="<%# Eval("MemberPrice")%>" onclick="UpdatePrice(this)">修改</a></td>
                            <td><%# EbSite.Core.Utils.ObjectToInt(Eval("Quantity"),0)+EbSite.Core.Utils.ObjectToInt(Eval("GiveQuantity"),0)%></td>
                            <td style="border-right:1px solid #E0DCCE;">&yen;<%# ((decimal)Eval("MemberPrice")*(int)Eval("Quantity")) %></td>
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
                    <td></td><td></td><td></td><td></td><td align="right">商品金额：</td><td>&yen;<%=Model.Amount %></td>
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
    <div class="headtitle">订单费用</div>
    <div class="commpanel">
        <table class="orderpriceinfo" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <td align="right" width="150">满额打折优惠：</td><td width="150"><asp:Literal ID="litDisAmount" runat="server"></asp:Literal></td><td></td>
            </tr>
            <tr>
                <td align="right">满额免费用活动：</td><td><asp:Literal ID="litActName" runat="server"></asp:Literal></td><td></td>
            </tr>
            <tr>
                <td align="right">运费：&yen;</td><td><XS:TextBoxVl ID="txtYF" runat="server" Text="0.00" Width="100" ValidateType="金额"></XS:TextBoxVl></td><td><asp:Literal ID="litSendName" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td align="right">支付手续费：&yen;</td><td><XS:TextBoxVl ID="txtPayPrice" runat="server" Width="100" Text="0.00" ValidateType="金额" ></XS:TextBoxVl></td><td><asp:Literal ID="litPayName" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td align="right">订单选项费用：</td><td><asp:Literal ID="litOrderOptionPrice" runat="server"></asp:Literal></td>
                <td>&nbsp;<asp:Literal ID="litOrderOptionName" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td align="right">优惠券折扣：</td><td><asp:Literal ID="litCouponValue" runat="server"></asp:Literal></td><td></td>
            </tr>
            <tr>
                <td align="right">涨价或减价：</td><td><XS:TextBoxVl ID="txtAdjusted" runat="server" Width="100" Text="0.00" ValidateType="金额"></XS:TextBoxVl></td><td>为负代表折扣，为正代表涨价</td>
            </tr>
            <tr>
                <td align="right">订单可得积分：</td><td><asp:Literal ID="litOrderScore" runat="server"></asp:Literal></td><td></td>
            </tr>
            <tr>
                <td align="right">订单实收款：</td><td><asp:Literal ID="litOrderTotal" runat="server"></asp:Literal></td><td></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <asp:Button ID="btonSubmit" runat="server" Text=" 保存修改 " CssClass="AdminButton" onclick="btonSubmit_Click" />
        &nbsp;<input type="button" value=" 返回 " class="AdminButton" onclick="BackPage()" />
    </div>
</div>

<script type="text/javascript">
    $(document).ready(function () {
        $("#btnaddcount").click(function () {
            var c = parseInt($(this).siblings("input[type='text']").val());
            if (c >0) {
                $(this).siblings("input[type='text']").val(c + 1);
            }
            else {
                alert("数量不能小于1");
            }
        });
        $("#btnacccount").click(function () {
            var c = parseInt($(this).siblings("input[type='text']").val());
            if (c > 1) {
                $(this).siblings("input[type='text']").val(c - 1);
            }
            else {
                alert("数量不能小于1");
            }
        });
    });
    var rid = "<%=Model.id %>";
    function UpdatePrice(obj) {
        var tid = $(obj).attr("tid");
        var tcount = $(obj).siblings("input[type='text']").val();
        if (tcount != "" && tcount != undefined && parseInt(tcount) > 0) {
            var mp = $(obj).attr("mp");
            var params = { "id": tid, "gc": tcount, "tp": mp, "rid": rid };
            runws("UpdateOrderPrice", params, function (data) {
                if (data.d > 0) {
                    tips("修改成功", 1, 1);
                    var time = setTimeout(function () { clearTimeout(time); window.location = window.location; }, 1000);
                }
                else {
                    tips("操作失败,请重新操作", 3, 1);
                }
            });
        }
        else {
            alert("输入的数量不正确！");
            $(obj).siblings("input[type='text']").focus();
        }
    }
    function CloseOrder(flag) {
        if (flag > 0) {
            tips("修改成功", 1, 1);
            var time = setTimeout(function () { clearTimeout(time); window.location = window.location; }, 1000);

        }
        else {
            tips("保存失败,请重新操作!", 3, 2);
        }
    }
    function BackPage()
    {
        window.location = window.location.href.toString().replace("&t=4", "&t=8");
    }
</script>