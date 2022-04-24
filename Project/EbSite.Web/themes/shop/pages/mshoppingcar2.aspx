<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mshoppingcar2" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls"
    TagPrefix="Shop" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title></title>
</head>
<body>
    <div class="gtop">
        <!--#include file="headersmall.inc"-->
        <div class="content">
            <div class="container">
                <div class="top2bnr">
                    <li><a href="<%=base.HostApi.CurrentSiteUrl %>">
                        <img src="<%=base.ThemeCss %>images/logo.png" /></a></li><li class="r">
                            <img src="<%=base.ThemeCss %>images/lin5.png" /></li></div>
            </div>
        </div>
    </div>
    <div class="center_x">
        <div class="container">
            <div class="linbg">
                <li><b>�ջ�����Ϣ</b>&nbsp;&nbsp;&nbsp;<a href="javascript:void(0);" onclick="UserNewAddress(this)">[ʹ���µ�ַ]</a></li></div>
            <div class="raone" id="ulAddress">
                <asp:Repeater ID="rpAddress" runat="server">
                    <ItemTemplate>
                        <li>
                            <input name="radioAddress" id="radioAddress<%# Eval("id") %>" areaid='<%# Eval("AreaID")%>' parentids="<%# Eval("CountryName")%>" value="<%# Eval("id") %>" type="radio">
                            <label for="radioAddress<%# Eval("id") %>">
                                <b>
                                    <%# Eval("AddressInfo")%>
                                    �ջ���:<%# Eval("UserRealName")%>
                                    �ֻ�:<%# Eval("Mobile")%></b>
                            </label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <form id="fmAdresss">
            <input id="btnSaveAdrress" style="display: none;" type="submit" />
            <div id="tabControlPanel" class="tabinfo">
                <ul>
                    <li>
                        <div class="tablidiv">
                            <font color="#FF0000"><b>*</b></font>��ַ��</div>
                        <dl>
                            <script type="text/javascript" src='/js/drplistbll.js'></script>
                            <span id="alReceiveAreaList">
                                <input type="hidden" name="alReceiveAreaList$hfValue" id="alReceiveAreaList_hfValue" />
                                <input type="hidden" name="alReceiveAreaList$hfValueP" id="alReceiveAreaList_hfValueP" /></span>
                            <script type="text/javascript">var objal_alReceiveAreaList = InitAreaList("alReceiveAreaList", 5, "alReceiveAreaList_hfValue", "wcf", "GetAlear", "", 1, 3, function (obj) { onReceiveAreaListSel(obj) });</script>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            <font color="#FF0000"><b>*</b></font>��ϸ��ַ��</div>
                        <dl style="width: 550px;">
                            <span id="lbReceiveAddress" style="font-size: 14px; color: #999999;"></span>
                            <input type="text" id="txtAddress" name="txtAddress" class="inp_dl" /><div id="errtxtAddress"
                                class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtAddress" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            �ʱࣺ</div>
                        <dl style="width: 450px;">
                            <input type="text" id="txtPostCode" name="txtPostCode" class="inp_dl inp_wid170" /></dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            <font color="#FF0000"><b>*</b></font>�ջ���������</div>
                        <dl style="width: 425px;">
                            <input type="text" id="txtSHR" name="txtSHR" class="inp_dl inp_wid170" /><div id="errtxtSHR"
                                class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtSHR" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            <font color="#FF0000"><b>*</b></font>�ֻ���</div>
                        <dl style="width: 390px;">
                            <input type="text" class="inp_dl" id="txtMobile" name="txtMobile" /><div id="errtxtMobile"
                                class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtMobile" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            ������</div>
                        <dl style="width: 600px;">
                            <input type="text" class="inp_dl" id="txtTel" name="txtTel" />
                            <span class="tabinfospan">����ʽ:010-3688898��</span><div id="errtxtTel" class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtTel" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            Email��</div>
                        <dl style="width: 560px;">
                            <input type="text" id="txtEmail" name="txtEmail" class="inp_dl" />
                            <span class="tabinfospan">���������ն���״̬���ѣ�</span><div id="errtxtEmail" class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtEmail" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                </ul>
            </div>
            <div id="divsaveinfobtn" style="margin-bottom: 10px;">
                <div id="btnSaveReceiveAddress" class="btn_save all" style="float: left; margin-right: 10px;">
                </div>
                <li class="btnsaver">��ȷ������д���ջ�����Ϣ׼ȷ���󣬷��������޷���ʱ�յ����</li>
            </div>
            </form>
            <form id="fmgotobuy" method="post" onsubmit="return vlorderinfo(this)" action="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GoToPayUrl(GetSiteID) %>">
            <!--ѡ�����ͷ�ʽ-->
            <div class="linbg">
                <li><b>ѡ�����ͷ�ʽ</b></li></div>
            <div style="padding: 20px;">
                <asp:Repeater ID="rpPeiSong" runat="server">
                    <ItemTemplate>
                        <div class="ratwo">
                            <li>
                                <input type="radio" name="rdoDelivery" iscod="<%# Eval("IsCod")%>" temid="<%# Eval("ShippingTemplatesId") %>"
                                    id="radioPeiSong<%# Eval("id") %>" value="<%# Eval("id") %>" />
                                <label for="radioPeiSong<%# Eval("id") %>">
                                    <b>
                                        <%# Eval("ModeName")%></b>&nbsp;&nbsp; �Ƿ�֧���������<font color="red"><%# Eval("IsCod").ToString() == "True"?"��":"��"%></font></label>
                            </li>
                        </div>
                        <div id="DeliveryDemo<%# Eval("id") %>" style="display: none;" class="tabptkd">
                            <ul>
                                <li>֧��������<%# Eval("PsCompanys")%></li>
                                <li>��ϸ˵����<%# Eval("Content")%></li>
                                <li>�˷Ѽ��㣺<font id="FreightTotal<%# Eval("id") %>" size="5" color="#ff0000">������...</font>Ԫ</li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="tabsfkd">
                    �ͻ�ʱ�䣺
                    <select name="drpSendDateTime" id="drpSendDateTime">
                        <option value="0">�ͻ�ʱ�䲻��</option>
                        <option value="1">ֻ�ڹ������ͻ���˫���ա����ղ��ͻ����ʺ��ڰ칫��ַ��</option>
                    </select>
                    <li><span>���ѣ�</span>����Ϣ��ӡ�ڿ���浥�ϣ���Ϊ��ݹ�˾�ͻ��Ĳο����ݣ�����������Ϳ��ܻ����������½⡣</li>
                </div>
            </div>
            <!--endѡ�����ͷ�ʽ-->
            <!--֧����ʽ-->
            <div class="linbg">
                <li><b>ѡ��֧����ʽ</b></li></div>
            <div style="padding: 20px;">
                <div class="ratwo">
                    <li>
                        <input type="radio" id="rdo_payonline1" name="rdoPayment" value="0" />
                        <label for="rdo_payonline1">
                            <b>����֧��</b>
                        </label>
                </div>
                <div id="PaymentDemo0" style="display: none;" class="tabptkd">
                    <ul>
                        <li>֧�� ֧���������������ÿ������֧��</li>
                    </ul>
                </div>
                <asp:PlaceHolder ID="phPayOffline" runat="server">
                    <div class="ratwo">
                        <li>
                            <input type="radio" disabled="disabled" id="rdo_payoffline2" name="rdoPayment" value="-1" />
                            <label for="rdo_payoffline2">
                                <b>��������</b></label>
                            <span style="display: none; color: red;">����ѡ������ͷ�ʽ��֧�ֻ������</span></li>
                    </div>
                    <div id="PaymentDemo-1" style="display: none;" class="tabptkd">
                        <ul>
                            <li>�����ֵ���֧��</li>
                            <li>�����ѣ�<font id="CODTotal" size="5" color="#ff0000">������...</font>Ԫ <span style="font-size: 12px;
                                color: #ccc;">(��ʾ���˷ѵĻ���������׷�ӵķ���)</span></li>
                        </ul>
                    </div>
                </asp:PlaceHolder>
            </div>
            <!--end֧����ʽ-->
            <!--��Ʒ�嵥-->
            <asp:Repeater ID="repShoppingCart" runat="server">
                <HeaderTemplate>
                    <div class="linbg">
                        <li><b>��Ʒ�嵥</b>[<a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ShoppingCarUrl(GetSiteID) %>">�޸���Ʒ�嵥</a>]</li></div>
                    <div style="border: none;" class="glst">
                        <div class="glst_top">
                            <li class="gw2">��Ʒ</li>
                            <li class="gw3">�۸�</li>
                            <li class="gw4">����</li>
                            <li class="gw4-1">ʵ�ʷ���</li>
                            <li class="gw5">����</li>
                            <li class="gw4">�ͻ���</li>
                        </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="glst_lst">
                        <li class="gw2">
                            <table>
                                <tr>
                                    <td>
                                        <img width="50" height="50" alt="" src="<%# Eval("ThumbnailsUrl") %>" />
                                    </td>
                                    <td>
                                        <div>
                                            <a target="_blank" href='<%# HostApi.GetContentLink(Eval("ProductId"),0)%>'>
                                                <%# Eval("ProductName")%></a>
                                        </div>
                                        <div>
                                            <!--���-->
                                            <font color="red" size="2">
                                                <%# Eval("SKUContent")%></font>
                                            <!--��������-->
                                            <font class="a-blue" size="2">
                                                <%# Eval("PurchaseGiftInfo")%></font>
                                            <!--��������-->
                                            <font class="a-blue" size="2">
                                                <%# Eval("WholesaleDiscountInfo")%></font>
                                        </div>
                                        <div>
                                            <asp:Repeater ID="rpGives" runat="server">
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                        <li class="gw3">&yen;<%# Eval("TotalRealSellPrice")%></li>
                        <li style="color: #33BB00" class="gw4">
                            <%# Eval("TotalRealSellPriceInfo")%>&nbsp;
                            <br>
                            <%# Eval("GiveQuantityInfo")%>
                        </li>
                        <li class="gw4-1">
                            <%# Eval("RealQuantity")%></li>
                        <li style="width: 100px;" class="gw5 quantity">
                            <%# Eval("Quantity") %></li>
                        <li class="gw4">
                            <%# Eval("TotalPoints")%></li>
                    </div>
                    <asp:Repeater ID="rpProductOptons" runat="server">
                        <ItemTemplate>
                            <div class="glst_lst_sub">
                                <li style="text-align: left; color: #ABABAB;" class="gw2">[<%# Eval("OptionName")%>]<%# Eval("ItemName")%>
                                </li>
                                <li class="gw3">&yen;<%# Eval("TotalPrice")%></li>
                                <li style="color: #33BB00" class="gw4">&nbsp;</li>
                                <li class="gw4-1">&nbsp;</li>
                                <li style="width: 17px; height: 18px; float: left; margin-top: 7px;">&nbsp;</li>
                                <li class="gw5 " style="width: 70px;">
                                    <%# Eval("Quantity") %>
                                </li>
                                <li style="width: 17px; height: 18px; float: left; margin-top: 7px;">&nbsp;</li>
                                <li class="gw4">&nbsp;</li>
                                <li class="gw6"></li>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="rpGiveProducts" runat="server">
                        <ItemTemplate>
                            <div class="glst_lst_sub">
                                <li style="text-align: left; color: #ABABAB;" class="gw2">[����] <a href='<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("GiftProductId").ToString()), GetSiteID)%>'>
                                    <img src='<%#Eval("SmallImg") %>' width='20' height='20' />
                                    <%#Eval("ProductName")%>
                                    ��<%#Eval("Quantity")%></a> </li>
                                <li class="gw3">&nbsp;</li>
                                <li style="color: #33BB00" class="gw4">&nbsp;</li>
                                <li class="gw4-1">&nbsp;</li>
                                <li style="width: 17px; height: 18px; float: left; margin-top: 7px;">&nbsp;</li>
                                <li class="gw5 " style="width: 70px;">
                                    <%# Eval("TotalGivQuantity")%>
                                </li>
                                <li style="width: 17px; height: 18px; float: left; margin-top: 7px;">&nbsp;</li>
                                <li class="gw4">&nbsp;</li>
                                <li class="gw6"></li>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <FooterTemplate>
                    <div style="width: 100%; text-align: center; color: #ccc; padding-top: 10px;">
                        <asp:Label ID="lblEmpty" Text="���Ĺ��ﳵû����Ʒ��<a href='javascript:history.back(-1)'>�������ȥ����</>"
                            runat="server" Visible='<%#bool.Parse((repShoppingCart.Items.Count==0).ToString())%>'></asp:Label>
                    </div>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="repCreditCart" runat="server">
                <HeaderTemplate>
                    <div class="linbg">
                        <li><b>���ֶһ���Ʒ�嵥</b></li></div>
                    <div style="border: none;" class="glst">
                        <div class="glst_top">
                            <li class="gw2">���ֶһ���Ʒ����</li>
                            <li class="gw3">�һ��������</li>
                            <li class="gw4-1">ʵ�ʷ���</li>
                            <li class="gw3">����</li>
                            <li class="gw4">����С��</li>
                        </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="glst_lst">
                        <li class="gw2">
                            <table>
                                <tr>
                                    <td>
                                        <img width="50" height="50" alt="" src="<%# Eval("smallpic") %>" />
                                    </td>
                                    <td>
                                        <div>
                                            <a target="_blank" href='<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.JiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("CreditProductID")) %>'>
                                                <%# Eval("ProductName")%></a>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                        <li class="gw3">
                            <%# Eval("Credit")%></li>
                        <li class="gw4-1 ">
                            <div>
                                <%# Eval("Quantity")%></div>
                        </li>
                        <li class="gw3 ">
                            <%# Eval("Quantity") %></li>
                        <li class="gw4">
                            <%# Convert.ToInt32( Eval("Credit").ToString())*Convert.ToInt32(  Eval("Quantity").ToString())%></li>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <!--end��Ʒ�嵥-->
            <!--begin Ԥ����-->
            <% if (Balance > 0)
               { %>
            <div style="margin-left: 30px;">
                <div>
                    <input id="CkUserWith" type="checkbox" /><label for="CkUserWith">ʹ�����(�˻���ǰ������<%=Balance%>Ԫ)</label> <input id="uCountMoney"  value="<%=Balance%>" type="hidden" /></div>
                <% if (!IsOpenBlance)
                   { %>
                <div style="margin-top: 9px;">
                    <span style="color: #662217;">Ϊ�˱������˻��ʽ�ȫ�������ʱ�����ã����ȿ�</span> 
                    <a href="<%=EbSite.Base.Host.Instance.GetOpenBalance %>" target="_blank" style="color: #204862">��֧������</a></div>
                <% }
                   else
                   { %>
                <div id="withPass" style="margin-top: 5px; display: none">
                    ����ʹ�ã�<input id="tbMoney" runat="server" type="text" style="width: 50px;" onblur="SetBalance(this)" />Ԫ ֧�����룺<input id="tbPassWord"  runat="server" type="password" />
                    <a href="<%=HostApi.GetModuleUrl("c65f0059-b345-4c0b-a437-37363f2fa4e9","c6dd03df-5606-41a2-b09e-6e6981dc3b2e")%>" target="_blank">����֧�����룿</a></div>
                <% }
                %>
            </div>
            <%} %>
            <!---endԤ����-->
            <!--��Ʒ��ѡ��ͽ���-->
            <div class="tabbill">
                <div class="billleft">
                    <div style="padding-bottom:10px;">
                        <a href="javascript:void(0);" listid="listyhqid" class="otherfree">+ʹ���Żݾ�</a>
                        <li id="listyhqid" style="display: none;"><span class="combo">
                            <input id="txtTick" name="txtTick" style="width: 125px;" class="combo-text validatebox-text" autocomplete="off"><span class="combo-arrow" onclick="opFun()"></span> </span>
                            <input id="btnCoupon" class="youhui_btn_sub" value="ʹ���Ż�ȯ" onclick="ckTicket()" type="button">
                            <div id="yhdiv" style="z-index: 2; border: 1px; position: relative; width: 155px; display: none; top: -1px; left:0px;*left:16px;" class="panel ">
                                <div style="width: 143px; height: 158px" class="combo-panel panel-body panel-body-noheader ">
                                    <asp:Repeater ID="rpTicket" runat="server">
                                        <ItemTemplate>
                                            <div class="combobox-item" tt="<%#Eval("ClaimCode")%>" onclick="setticket(this)">
                                                <%#EbSite.BLL.Coupons.Instance.GetEntity(Convert.ToInt32(Eval("couponid"))).CouponName %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </li>
                    </div>
                    <asp:Repeater ID="rpOrderOptions" runat="server">
                        <ItemTemplate>
                            <div style="padding-bottom:10px;">
                                <a href="javascript:void(0);" listid="listyhqid<%# Eval("id")%>" class="otherfree">+<%# Eval("OptionName")%></a>
                                <span style="color: #ccc;">(<%# Eval("Description")%>)</span>
                                <dl id="listyhqid<%# Eval("id")%>" style="display: none;">
                                    <Shop:OrderOptions ID="optionitems" runat="server"></Shop:OrderOptions>
                                </dl>
                                <asp:Repeater ID="rpUserInput" runat="server">
                                    <ItemTemplate>
                                        <dl style="display: none;" id="UserInput<%# Eval("id")%>" class="optionitems">
                                            <span>
                                                <%# Eval("UserInputTitle")%>:</span><span><input name="opv<%# Eval("id")%>" type="text"
                                                    style="width: 350px;" /></span>
                                            <br />
                                            <span style="line-height: 20px; color: #ccc;">˵����<%# Eval("Remark")%></span>
                                        </dl>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="billtwo color66">
                        <div class="billtwoline1">
                            <li>��������(�벻Ҫ����30��)</li>
                        </div>
                        <input type="text" name="txtRemark" id="txtRemark" style="width: 90%;" class="orderRemakInfo"
                            value="�ջ���Ϣ�����ͷ�ʽ��֧����ʽ��������ѡ��ֵΪ׼���ڴ˱�ע��Ч" />
                        <br />
                        <input id="txtgroup" runat="server" name="txtgroup" value="" type="hidden" />
                        <input id="txtrush" runat="server" name="txtrush" value="" type="hidden" />
                        <span>(������������������ڴ���д��ע�����ǻᾡ��Ϊ������)</span>
                    </div>
                </div>
                <div class="billright">
                    <table>
                        <tr>
                            <td>
                                ��Ʒ��
                            </td>
                            <td>
                                &yen;<asp:Literal ID="ltlTotalProduct" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ��Ʒ������
                            </td>
                            <td>
                                <font color="red" size="2">
                                    <asp:Literal ID="ltlCount" runat="server"></asp:Literal></font>
                            </td>
                        </tr>
                        <tr>
                            <td title="������ۻ,���������" valign="top">
                                �������
                            </td>
                            <td class="DiscountInfo">
                                <font class="a-blue" size="2">
                                    <asp:Literal ID="DiscountInfo" runat="server"></asp:Literal></font>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                �Żݺ��
                            </td>
                            <td>
                                <b style="font-size: 18px; color: Red;">
                                    <asp:Literal ID="ltlTotal" runat="server"></asp:Literal></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                �ɵû��֣�
                            </td>
                            <td>
                                <font color="red" size="2">
                                    <asp:Literal ID="ltlPoints" runat="server"></asp:Literal></font>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                �Ż�ȯ�ֿ۽�
                            </td>
                            <td>
                                <font color="red" size="2" id="ltlTicket">0.00</font> Ԫ
                            </td>
                        </tr>
                        <tr>
                            <td>
                                �˷ѣ�
                            </td>
                            <td>
                                <font color="red" size="2" id="ltlTrans">0.00</font>Ԫ
                            </td>
                        </tr>
                          <tr>
                            <td>
                                ʹ����
                            </td>
                            <td>
                                <font color="red" size="2" id="ltlBalance">0.00</font>Ԫ
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ֧�������ѣ�
                            </td>
                            <td>
                                <font color="red" size="2" id="ltlShouXu">0.00</font>Ԫ
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ����ѡ����ã�
                            </td>
                            <td>
                                <font color="red" size="2" id="ltlOrderFee">0.00</font> Ԫ
                            </td>
                        </tr>
                        <tr>
                            <td>
                                �����ܼ۸�
                            </td>
                            <td>
                                <font color="red" size="5" id="ltlsummoney">0.00</font> Ԫ
                            </td>
                        </tr>
                    </table>
                    <input type="submit" name="btnSaveOrder" style="border: none;  cursor: pointer;" value="" id="btnSaveOrder"
                        class="btnsave"  />
                </div>
            </div>
            <!--end��Ʒ��ѡ��ͽ���-->
            <input id="optionitemids" name="optionitemids" type="hidden" runat="server" />
            </form>
            <div class="clear">
            </div>
            <div class="linbg" style="border-bottom: none">
            </div>
        </div>
    </div>
    <script type="text/javascript">

        var alReceiveAreaListID = "alReceiveAreaList", hfReceiveAreaValueID = "alReceiveAreaList_hfValue", hfReceiveValueParentIDs = "alReceiveAreaList_hfValueP", alcObj = objal_alReceiveAreaList;
        //���ﳵ�����Ʒ��������
        var sumweight = <%=TotalWeight %>; 
        var summoney=<%=TotalMoney %>;
        var IsFreeEight = <%=IsFreeEight?"true":"false" %>;
        var IsFreePay = <%=IsFreePay?"true":"false" %>;
        var IsOrderOption = <%=IsFreeOrderOption?"true":"false" %>;
    </script>
    <script type="text/javascript" src="<% =ThemePage%>mshoppingcar2.js"></script>
</body>
</html>
