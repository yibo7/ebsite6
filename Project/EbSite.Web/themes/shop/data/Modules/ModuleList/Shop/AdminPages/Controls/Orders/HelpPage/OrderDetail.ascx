<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.OrderDetail" %>
<%@ Import Namespace="EbSite.Modules.Shop" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="divpanel">
    <div class="headtitle">
        ��������</div>
    <div class="commpanel">
        <asp:Literal ID="labStep" runat="server"></asp:Literal>
        <div class="orderstate">
            <span>��ǰ����״̬��<asp:Literal ID="litOrderState" runat="server"></asp:Literal></span><br />
            <br />
            <input type="button" value="�޸ļ۸�" class="btnedit" id="btnEditPrice" onclick="EditOrderPrice()" />
            <input type="button" value="��ע" class="btnmark" id="btnRemark" onclick="MarkOrder()" />
            <input type="button" value="�رն���" class="btnclorder" id="btnCloseOrder" onclick="CloseOrder()" />
            <input type="button" value="�˿�" class="btnrefundorder" id="btnRefOrder" onclick="RefundOrder()" style="display: none;" />
            <input type="button" value="��־" class="btnmark" id="btnLog" onclick="LogOrder()" />
            <input type="button" value="��ݴ�ӡ" class="btnprint" id="Button1" onclick="PrintOrder('KDD')" />
            <input type="button" value="������ӡ" class="btnprint" id="Button2" onclick="PrintOrder('GHD')" />
            <input type="button" value="���ʹ�ӡ" class="btnprint" id="Button3" onclick="PrintOrder('PSD')" />
            <br />
            <table width="600px" cellpadding="10">
                <tr>
                    <td align="right">
                        ������ţ�
                    </td>
                    <td>
                        <%=Model.OrderId %>
                    </td>
                    <td align="right">
                        ��ϵ�绰��
                    </td>
                    <td>
                        <%=Model.CellPhone %>
                    </td>
                    <td align="right">
                        ��Ա����
                    </td>
                    <td>
                        <%=Model.Username %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ��ʵ������
                    </td>
                    <td>
                        <%=Model.RealName %>
                    </td>
                    <td align="right">
                        �����ʼ���
                    </td>
                    <td>
                        <%=Model.EmailAddress %>
                    </td>
                    <td align="right">
                        �������룺
                    </td>
                    <td>
                        <%=Model.ZipCode %>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="headtitle">
        ��Ʒ�б�</div>
    <div class="commpanel">
        <table border="0" cellspacing="0" class="datalist_orderitem">
            <thead>
                <tr>
                    <th colspan="2" style="width: 580px;">
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
                                <span>���ţ�<%# Eval("SKU") %>
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
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        ��Ʒ��
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
                        ��Ʒ��������
                    </td>
                    <td>
                        <%=Model.Weight%>(��)
                    </td>
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
        ��������</div>
    <div class="commpanel">
        <table class="orderpriceinfo" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <td align="right" width="150">
                    ��������Żݣ�
                </td>
                <td width="130">
                    <asp:Literal ID="litDisAmount" runat="server"></asp:Literal>
                </td>
                <td>
                    <%= string.IsNullOrEmpty(Model.DiscountName)?"����":Model.DiscountName %>
                </td>
            </tr>
            <tr>
                <td align="right">
                    ��������û��
                </td>
                <td>
                    <asp:Literal ID="litActName" runat="server"></asp:Literal>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    �˷ѣ�
                </td>
                <td>
                    <asp:Literal ID="litAdjFrei" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="litAdjFreiName" runat="server"></asp:Literal>&nbsp;&nbsp;<a class="btnlink"
                        onclick="OpenEditSend()">�޸����ͷ�ʽ</a>
                </td>
            </tr>
            <tr>
                <td align="right">
                    ֧�������ѣ�
                </td>
                <td>
                    <asp:Literal ID="litPayFree" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="litPayFreeName" runat="server"></asp:Literal>&nbsp;&nbsp;<a class="btnlink"
                        onclick="OpenEditPay()">�޸�֧����ʽ</a>
                </td>
            </tr>
            <tr>
                <td align="right">
                    ����ѡ����ã�
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
                    �Ż�ȯ�ۿۣ�
                </td>
                <td>
                    <asp:Literal ID="litCouponValue" runat="server"></asp:Literal>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    �Ǽۻ���ۣ�
                </td>
                <td>
                    <asp:Literal ID="litAdjusted" runat="server"></asp:Literal>
                </td>
                <td>
                    Ϊ�������ۿۣ�Ϊ�������Ǽ�
                </td>
            </tr>
            <tr>
                <td align="right">
                    �����ɵû��֣�
                </td>
                <td>
                    <asp:Literal ID="litOrderScore" runat="server"></asp:Literal>
                </td>
                <td>
                </td>
            </tr>
              <tr>
                <td align="right">
                    ʹ��Ԥ���
                </td>
                <td>
                    <asp:Literal ID="litUserBalance" runat="server"></asp:Literal>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                    ����ʵ�տ
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
        ������Ϣ</div>
    <table class="orderpriceinfo" border="0" cellpadding="10" cellspacing="0">
        <tr>
            <td align="right" width="150">
                �ջ���ַ��
            </td>
            <td align="left">
                <%=Model.Address%>&nbsp;&nbsp;&nbsp;<a class="btnlink" onclick="OpenEditAddress()">�޸��ջ���ַ</a>
            </td>
        </tr>
        <tr>
            <td align="right" width="150">
                ���ͷ�ʽ��
            </td>
            <td align="left">
                <%=string.IsNullOrEmpty(Model.RealModeName) ? (string.IsNullOrEmpty(Model.ModeName) ? "����" : Model.ModeName) : Model.RealModeName%>
            </td>
        </tr>
        <tr>
            <td align="right" width="150">
                ������ԣ�
            </td>
            <td align="left">
                <%=Model.Remark%>
            </td>
        </tr>
    </table>
</div>
<div style="text-align: center">
    <a href="javascript:history.go(-1);" class="AdminButton" style="display:block; height: 33px;width: 140px;">�� �� �� ��</a> 
<%--    <input type="button" value=" �� �� �� �� " class="AdminButton" onclick="BackUpList()" />--%>
</div>
<script type="text/javascript">
    var rid = "<%=Model.id %>";
    var oid = "<%=Model.OrderId %>";
    function OpenEditAddress() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=9&id=" + rid, "�༭�ջ���ַ��Ϣ", 500, 360, true);
    }
    function OpenEditSend() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=10&id=" + rid, "�༭���ͷ�ʽ", 500, 200, true);
    }
    function OpenEditPay() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=11&id=" + rid, "�༭֧����ʽ", 500, 200, true);
    }
    //�رն���
    function CloseOrder() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=5&id=" + rid, "�رն���", 600, 200, true);
    }
    //�˿�
    function RefundOrder() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=16&id=" + rid, "�����˿����", 730, 500, true);
    }

    //��־
    function LogOrder() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=17&id=" + oid, "������־", 730, 500, true);
    }

    //��ע����
    function MarkOrder() {
        OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=7&id=" + rid, "�༭��ע��Ϣ", 500, 360, true);
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
        //����վ
        $("#btnEditPrice").hide();
        $("#btnCloseOrder").hide();
        $("#btnRemark").hide();
        $("#btnLog").hide();
        $("#Button1").hide();
        $("#Button2").hide();
        $("#Button3").hide();
        $(".btnlink").hide();
    }


    //��ӡ
    function PrintOrder(actonname) {

        if (actonname == "KDD") {
            //��ݵ�
            OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=12&id=" + rid, "��ӡ��ݵ�", 900, 200, true);
        }
        else if (actonname == "GHD") {
            //������
            OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=13&id=" + rid, "��ӡ������", 600, 200, true);
        }
        else if (actonname == "PSD") {
            //���͵�
            OpenDialog_Iframe("Orders.aspx?muid=5f770597-e2bd-4c19-b206-97eebadb573a&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=14&id=" + rid, "��ӡ���͵�", 600, 200, true);
        }
    }
</script>
