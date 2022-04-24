<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditOrderPrice.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.EditOrderPrice" %>
<%@ Import Namespace="EbSite.Modules.Shop" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="divpanel">
    <div class="headtitle">�޸Ķ����۸�</div>
    <div class="commpanel">
        <table border="0" cellspacing="0" class="datalist_orderitem">
            <thead>
                <tr>
                    <th colspan="2" style="width:580px;">
                        ��Ʒ����
                    </th>
                    <th style="width:80px;">
                        ��Ʒ����(Ԫ)
                    </th>
                    <th style="width:100px;">
                        ��������
                    </th>
                    <th style="width:80px;">
                        ��������
                    </th>
                    <th style="width:80px;">
                        �ܼ�(Ԫ)
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptOrderItem" runat="server" OnItemDataBound="rptOrderItem_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td style="border-left:1px solid #E0DCCE;"><a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),SettingInfo.Instance.GetSiteID)%>" target="_blank"><img alt="" src="<%# Eval("ThumbnailsUrl") %>" width="60" height="60" /></a></td>
                            <td><a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),SettingInfo.Instance.GetSiteID)%>" target="_blank"><%# Eval("ProductName") %></a><br /><span>���ţ�<%# Eval("SKU") %>  <%# Eval("SKUContent") %></span></td>
                            <td>&yen;<%# Eval("MemberPrice")%></td>
                            <td><span id="btnaddcount">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;<input type="text" value="<%# Eval("Quantity")%>" class="TextBoxDefault" style="width:30px;" />&nbsp;&nbsp;<span id="btnacccount">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;
                                <a href="javascript:void(0);" tid="<%# Eval("id") %>" mp="<%# Eval("MemberPrice")%>" onclick="UpdatePrice(this)">�޸�</a></td>
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
                                                        ��Ʒ����
                                                    </th>
                                                    <th style="width: 80px;">
                                                        ��Ʒ����(Ԫ)
                                                    </th>
                                                    <th style="width: 80px;">
                                                        ��������
                                                    </th>
                                                    <th style="width: 80px;">
                                                        ��������
                                                    </th>
                                                    <th style="width: 80px;">
                                                        �ܼ�(Ԫ)
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
                    <td></td><td></td><td></td><td></td><td align="right">��Ʒ��</td><td>&yen;<%=Model.Amount %></td>
                </tr>
                <tr>
                    <td></td><td></td><td></td><td></td><td align="right">��Ʒ��������</td><td><%=Model.Weight%>(��)</td>
                </tr>
            </tbody>
        </table>
    </div>
    <asp:Repeater ID="RepCredits" runat="server">
        <HeaderTemplate>
            <div class="headtitle">
                ���ֶһ���Ʒ�б�</div>
            <div class="commpanel">
                <table border="0" cellspacing="0" class="datalist_orderitem">
                    <thead>
                        <tr>
                            <th colspan="2" style="width: 580px;">
                                ��Ʒ����
                            </th>
                            <th style="width: 80px;">
                                �һ�����
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
    <div class="headtitle">��������</div>
    <div class="commpanel">
        <table class="orderpriceinfo" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <td align="right" width="150">��������Żݣ�</td><td width="150"><asp:Literal ID="litDisAmount" runat="server"></asp:Literal></td><td></td>
            </tr>
            <tr>
                <td align="right">��������û��</td><td><asp:Literal ID="litActName" runat="server"></asp:Literal></td><td></td>
            </tr>
            <tr>
                <td align="right">�˷ѣ�&yen;</td><td><XS:TextBoxVl ID="txtYF" runat="server" Text="0.00" Width="100" ValidateType="���"></XS:TextBoxVl></td><td><asp:Literal ID="litSendName" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td align="right">֧�������ѣ�&yen;</td><td><XS:TextBoxVl ID="txtPayPrice" runat="server" Width="100" Text="0.00" ValidateType="���" ></XS:TextBoxVl></td><td><asp:Literal ID="litPayName" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td align="right">����ѡ����ã�</td><td><asp:Literal ID="litOrderOptionPrice" runat="server"></asp:Literal></td>
                <td>&nbsp;<asp:Literal ID="litOrderOptionName" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td align="right">�Ż�ȯ�ۿۣ�</td><td><asp:Literal ID="litCouponValue" runat="server"></asp:Literal></td><td></td>
            </tr>
            <tr>
                <td align="right">�Ǽۻ���ۣ�</td><td><XS:TextBoxVl ID="txtAdjusted" runat="server" Width="100" Text="0.00" ValidateType="���"></XS:TextBoxVl></td><td>Ϊ�������ۿۣ�Ϊ�������Ǽ�</td>
            </tr>
            <tr>
                <td align="right">�����ɵû��֣�</td><td><asp:Literal ID="litOrderScore" runat="server"></asp:Literal></td><td></td>
            </tr>
            <tr>
                <td align="right">����ʵ�տ</td><td><asp:Literal ID="litOrderTotal" runat="server"></asp:Literal></td><td></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <asp:Button ID="btonSubmit" runat="server" Text=" �����޸� " CssClass="AdminButton" onclick="btonSubmit_Click" />
        &nbsp;<input type="button" value=" ���� " class="AdminButton" onclick="BackPage()" />
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
                alert("��������С��1");
            }
        });
        $("#btnacccount").click(function () {
            var c = parseInt($(this).siblings("input[type='text']").val());
            if (c > 1) {
                $(this).siblings("input[type='text']").val(c - 1);
            }
            else {
                alert("��������С��1");
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
                    tips("�޸ĳɹ�", 1, 1);
                    var time = setTimeout(function () { clearTimeout(time); window.location = window.location; }, 1000);
                }
                else {
                    tips("����ʧ��,�����²���", 3, 1);
                }
            });
        }
        else {
            alert("�������������ȷ��");
            $(obj).siblings("input[type='text']").focus();
        }
    }
    function CloseOrder(flag) {
        if (flag > 0) {
            tips("�޸ĳɹ�", 1, 1);
            var time = setTimeout(function () { clearTimeout(time); window.location = window.location; }, 1000);

        }
        else {
            tips("����ʧ��,�����²���!", 3, 2);
        }
    }
    function BackPage()
    {
        window.location = window.location.href.toString().replace("&t=4", "&t=8");
    }
</script>