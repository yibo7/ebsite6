<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mshoppingcar1" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .gdListContent
        {
            height: 100px;
            line-height: 100px;
            background-color: #fff;
        }
    </style>
</head>
<body>
    <div class="gtop">
        <!--#include file="headersmall.inc"-->
        <div class="eb-content">
            <div class="container">
                <div class="top2bnr">
                    <li><a href="<%=HostApi.GetMainIndexHref(GetSiteID) %>">
                        <img src="<% =ThemeCss%>images/logo.png" /></a></li><li class="r">
                            <img src="<% =ThemeCss%>images/lin6.png" /></li></div>
                <div class="top3 container">
                    <li><span>�ҵĹ��ﳵ</span></li>
                    <li>
                        <%-- <div class="fleft">
                            ����</div>
                        <div class="bg2 all">
                            ��¼</div>--%>
                    </li>
                    <li>�����ﳵ�е���Ʒ�������ñ��档</li>
                </div>
            </div>
        </div>
    </div>
    <div class="eb-content">
        <div class="container">
            <div class="glst">
                <asp:Repeater ID="repShoppingCart" runat="server">
                    <HeaderTemplate>
                        <div class="glst_top">
                            <li class="gw2">��Ʒ</li>
                            <li class="gw3">�۸�</li>
                            <li class="gw4">����</li>
                            <li class="gw4-1">ʵ�ʷ���</li>
                            <li class="gw5">����</li>
                            <li class="gw4">�ͻ���</li>
                            <li class="gw6">ɾ��</li>
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
                            <li class="gw4 gw4c">
                                <div>
                                    <%# Eval("TotalRealSellPriceInfo")%></div>
                                <div>
                                    <%# Eval("GiveQuantityInfo")%></div>
                            </li>
                            <li class="gw4-1">
                                <%# Eval("RealQuantity")%></li>
                            <li>
                                <div onclick='remoiviecart("s<%# Eval("SKU") %>","<%#Eval("ProductId") %>")' class="jian all2">
                                </div>
                            </li>
                            <li class="gw5 quantity">
                                <input type="text" pid="<%# Eval("SKU") %>" value="<%# Eval("Quantity") %>" name="s<%# Eval("SKU") %>"
                                    id='s<%# Eval("SKU") %>' /></li>
                            <li>
                                <div onclick='addnum("s<%# Eval("SKU") %>","<%#Eval("ProductId") %>")' class="jia all2">
                                </div>
                            </li>
                            <li class="gw4">
                                <%# Eval("TotalPoints")%></li>
                            <li class="gw6"><span onclick='delcart("<%# Eval("SKU") %>",this)'><a>ɾ��</a></span></li>
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
                        <div class="glst_lst_sub">
                            <span onclick="editeproductoption(<%# Eval("ProductId")%>,'<%# Eval("SKU")%>')" style="cursor: pointer;
                                color: #0000ff">[�޸ķ���ѡ��]</span>
                        </div>
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
                            <asp:Label ID="lblEmpty" Text="���Ĺ��ﳵû����Ʒ��<a href='javascript:history.back(-1)'>�������ȥ����</a>"
                                runat="server" Visible='<%#bool.Parse((repShoppingCart.Items.Count==0).ToString())%>'></asp:Label>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Repeater ID="repCreditCart" runat="server">
                    <HeaderTemplate>
                        <div class="glst_top">
                            <li class="gw2">���ֶһ���Ʒ����</li>
                            <li class="gw3">�һ��������</li>
                             <li class="gw4-1">ʵ�ʷ���</li>
                            <li class="gw5">����</li>
                            <li class="gw4">����С��</li>
                            <li class="gw6">ɾ��</li>
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
                                                <a target="_blank" href='<%#ShopLinkApi.JiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("CreditProductID")) %>'>
                                                    <%# Eval("ProductName")%></a>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </li>
                            <li class="gw3"><%# Eval("Credit")%></li>
                            <li class="gw4-1 ">
                                <div>
                                    <%# Eval("Quantity")%></div>
                            </li>
                             <li>
                                <div onclick='downNum("c<%# Eval("id") %>")' class="jian all2">
                                </div>
                            </li>
                            <li class="gw5 quantity">
                                <input type="text" pid="<%# Eval("CreditProductID") %>" value="<%# Eval("Quantity") %>" name="c<%# Eval("id") %>"
                                    id='c<%# Eval("id") %>' /></li>
                            <li>
                                <div onclick='upnum("c<%# Eval("id") %>","<%#Eval("Stock") %>","<%# Eval("Credit")%>")' class="jia all2">
                                </div>
                            </li>
                            <li class="gw4"> <%# Convert.ToInt32( Eval("Credit").ToString())*Convert.ToInt32(  Eval("Quantity").ToString())%></li>
                            <li class="gw6"><span onclick='delcraditcart("<%# Eval("CreditProductID") %>",this)'><a>ɾ��</a></span></li>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="glst_tal">
                    <div class="tal_l">
                        <li>
                            <div class="cha all">
                            </div>
                            <a href="javascript:clearshoppingcar()">��չ��ﳵ</a> </li>
                    </div>
                    <div style="padding-bottom: 10px;" class="tal_r">
                        <li>
                            <dl>
                                &nbsp;</dl>
                            <dl>
                                ��Ʒ��<span>&yen;<asp:Literal ID="ltlTotalProduct" runat="server"></asp:Literal></span></dl>
                        </li>
                        <li>
                            <dl>
                                &nbsp;</dl>
                            <dl>
                                ��Ʒ������<asp:Literal ID="ltlCount" runat="server"></asp:Literal></dl>
                        </li>
                        <li>
                            <dl>
                                &nbsp;</dl>
                            <dl>
                                �ɵû��֣�<asp:Literal ID="ltlPoints" runat="server"></asp:Literal></dl>
                        </li>
                        <li>
                            <dl>
                                &nbsp;</dl>
                            <dl>
                                ���������<asp:Literal ID="DiscountInfo" runat="server"></asp:Literal>
                                  <input id="HiScore" name="HiScore" runat="server" type="hidden" /> 
                            </dl>
                        </li>
                        
                    </div>
                </div>
                <div class="glst_bom">
                    <li>�ܼƣ������˷ѣ���<span>&yen;<asp:Literal ID="ltlTotal" runat="server"></asp:Literal></span></li></div>
            </div>
            <div id="gotobuy" runat="server" class="gst_btn">
                <img style="cursor: pointer;" onclick="javascript:history.back(-1)" src="<% =ThemeCss%>images/jxgw.png" />
                <a onclick="gotopay()" id="GoNext" kaurl="<%=ShopLinkApi.PostCarUrl(GetSiteID) %>">
                    <div class="qjsbtn all">
                    </div>
                </a>
            </div>
            <div class="clear">
            </div>
            <div class="jflst">
                <div class="jf_top">
                    <li>���ι���ɹ���ɵû��֣�<span><asp:Literal ID="ltlSumPoints" runat="server"></asp:Literal>���֣��ɻ�ȡ������Ʒ</span></li></div>
                <XS:Repeater ID="ScoreRep" runat="server">
                    <ItemTemplate>
                        <div class="prelst">
                            <div class="pretop">
                                <li><span>�ֻ�ͨѶ</span>&nbsp;����ȫ������</li></div>
                            <div class="prdinfo">
                                <a href="<%#ShopLinkApi.JiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("id")) %>">
                                <img src="<%#Eval("SmallImg") %>" class="fleft" width="60" height="52" /></a>
                                <div class="fRight prtit">
                                    <li>
                                       <a href="<%#ShopLinkApi.JiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("id")) %>">  <%#Eval("ProductName")%></a></li>
                                    <li><span>����Ҫ���֣�<%#Eval("Credit")%>����</span></li>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="nogift">
                            <asp:Label Text="û�д˻��ֶε���Ʒ!" runat="server" Visible='<%#bool.Parse((ScoreRep.Items.Count==0).ToString())%>'></asp:Label>
                        </div>
                    </FooterTemplate>
                </XS:Repeater>
            </div>
        </div>
    </div>
    <div style="clear: both;">
        <!--#include file="footer.inc" -->
    </div>
    <script type="text/javascript" src="<% =ThemePage%>mshoppingcar1.js"></script>
    <!--�޸���Ʒ����ѡ�������-->
    <div style="display: none;">
        <div style="width: 500px; height: 200px;" id="divEditeProductOption">
            <div id="divProductOptionItems">
            </div>
        </div>
    </div>
    <!--end-->
</body>
</html>
