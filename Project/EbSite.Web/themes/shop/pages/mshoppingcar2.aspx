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
                <li><b>收货人信息</b>&nbsp;&nbsp;&nbsp;<a href="javascript:void(0);" onclick="UserNewAddress(this)">[使用新地址]</a></li></div>
            <div class="raone" id="ulAddress">
                <asp:Repeater ID="rpAddress" runat="server">
                    <ItemTemplate>
                        <li>
                            <input name="radioAddress" id="radioAddress<%# Eval("id") %>" areaid='<%# Eval("AreaID")%>' parentids="<%# Eval("CountryName")%>" value="<%# Eval("id") %>" type="radio">
                            <label for="radioAddress<%# Eval("id") %>">
                                <b>
                                    <%# Eval("AddressInfo")%>
                                    收货人:<%# Eval("UserRealName")%>
                                    手机:<%# Eval("Mobile")%></b>
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
                            <font color="#FF0000"><b>*</b></font>地址：</div>
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
                            <font color="#FF0000"><b>*</b></font>详细地址：</div>
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
                            邮编：</div>
                        <dl style="width: 450px;">
                            <input type="text" id="txtPostCode" name="txtPostCode" class="inp_dl inp_wid170" /></dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            <font color="#FF0000"><b>*</b></font>收货人姓名：</div>
                        <dl style="width: 425px;">
                            <input type="text" id="txtSHR" name="txtSHR" class="inp_dl inp_wid170" /><div id="errtxtSHR"
                                class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtSHR" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            <font color="#FF0000"><b>*</b></font>手机：</div>
                        <dl style="width: 390px;">
                            <input type="text" class="inp_dl" id="txtMobile" name="txtMobile" /><div id="errtxtMobile"
                                class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtMobile" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            座机：</div>
                        <dl style="width: 600px;">
                            <input type="text" class="inp_dl" id="txtTel" name="txtTel" />
                            <span class="tabinfospan">（格式:010-3688898）</span><div id="errtxtTel" class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtTel" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            Email：</div>
                        <dl style="width: 560px;">
                            <input type="text" id="txtEmail" name="txtEmail" class="inp_dl" />
                            <span class="tabinfospan">（用来接收订单状态提醒）</span><div id="errtxtEmail" class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtEmail" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                </ul>
            </div>
            <div id="divsaveinfobtn" style="margin-bottom: 10px;">
                <div id="btnSaveReceiveAddress" class="btn_save all" style="float: left; margin-right: 10px;">
                </div>
                <li class="btnsaver">请确保您填写的收货人信息准确无误，否则导致您无法及时收到货物。</li>
            </div>
            </form>
            <form id="fmgotobuy" method="post" onsubmit="return vlorderinfo(this)" action="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GoToPayUrl(GetSiteID) %>">
            <!--选择配送方式-->
            <div class="linbg">
                <li><b>选择配送方式</b></li></div>
            <div style="padding: 20px;">
                <asp:Repeater ID="rpPeiSong" runat="server">
                    <ItemTemplate>
                        <div class="ratwo">
                            <li>
                                <input type="radio" name="rdoDelivery" iscod="<%# Eval("IsCod")%>" temid="<%# Eval("ShippingTemplatesId") %>"
                                    id="radioPeiSong<%# Eval("id") %>" value="<%# Eval("id") %>" />
                                <label for="radioPeiSong<%# Eval("id") %>">
                                    <b>
                                        <%# Eval("ModeName")%></b>&nbsp;&nbsp; 是否支付货到付款：<font color="red"><%# Eval("IsCod").ToString() == "True"?"是":"否"%></font></label>
                            </li>
                        </div>
                        <div id="DeliveryDemo<%# Eval("id") %>" style="display: none;" class="tabptkd">
                            <ul>
                                <li>支持物流：<%# Eval("PsCompanys")%></li>
                                <li>详细说明：<%# Eval("Content")%></li>
                                <li>运费计算：<font id="FreightTotal<%# Eval("id") %>" size="5" color="#ff0000">加载中...</font>元</li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="tabsfkd">
                    送货时间：
                    <select name="drpSendDateTime" id="drpSendDateTime">
                        <option value="0">送货时间不限</option>
                        <option value="1">只在工作日送货（双休日、假日不送货，适合于办公地址）</option>
                    </select>
                    <li><span>提醒：</span>此信息打印在快递面单上，作为快递公司送货的参考依据，个别地区配送可能会有延误，请谅解。</li>
                </div>
            </div>
            <!--end选择配送方式-->
            <!--支付方式-->
            <div class="linbg">
                <li><b>选择支付方式</b></li></div>
            <div style="padding: 20px;">
                <div class="ratwo">
                    <li>
                        <input type="radio" id="rdo_payonline1" name="rdoPayment" value="0" />
                        <label for="rdo_payonline1">
                            <b>在线支付</b>
                        </label>
                </div>
                <div id="PaymentDemo0" style="display: none;" class="tabptkd">
                    <ul>
                        <li>支持 支付宝、网银、信用卡、储蓄卡支付</li>
                    </ul>
                </div>
                <asp:PlaceHolder ID="phPayOffline" runat="server">
                    <div class="ratwo">
                        <li>
                            <input type="radio" disabled="disabled" id="rdo_payoffline2" name="rdoPayment" value="-1" />
                            <label for="rdo_payoffline2">
                                <b>货到付款</b></label>
                            <span style="display: none; color: red;">（您选择的配送方式不支持货到付款）</span></li>
                    </div>
                    <div id="PaymentDemo-1" style="display: none;" class="tabptkd">
                        <ul>
                            <li>仅部分地区支持</li>
                            <li>手续费：<font id="CODTotal" size="5" color="#ff0000">加载中...</font>元 <span style="font-size: 12px;
                                color: #ccc;">(表示在运费的基础上另外追加的费用)</span></li>
                        </ul>
                    </div>
                </asp:PlaceHolder>
            </div>
            <!--end支付方式-->
            <!--商品清单-->
            <asp:Repeater ID="repShoppingCart" runat="server">
                <HeaderTemplate>
                    <div class="linbg">
                        <li><b>商品清单</b>[<a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ShoppingCarUrl(GetSiteID) %>">修改商品清单</a>]</li></div>
                    <div style="border: none;" class="glst">
                        <div class="glst_top">
                            <li class="gw2">商品</li>
                            <li class="gw3">价格</li>
                            <li class="gw4">返现</li>
                            <li class="gw4-1">实际发货</li>
                            <li class="gw5">数量</li>
                            <li class="gw4">送积分</li>
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
                                            <!--规格-->
                                            <font color="red" size="2">
                                                <%# Eval("SKUContent")%></font>
                                            <!--满量赠送-->
                                            <font class="a-blue" size="2">
                                                <%# Eval("PurchaseGiftInfo")%></font>
                                            <!--满量打折-->
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
                                <li style="text-align: left; color: #ABABAB;" class="gw2">[赠送] <a href='<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("GiftProductId").ToString()), GetSiteID)%>'>
                                    <img src='<%#Eval("SmallImg") %>' width='20' height='20' />
                                    <%#Eval("ProductName")%>
                                    ×<%#Eval("Quantity")%></a> </li>
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
                        <asp:Label ID="lblEmpty" Text="您的购物车没有商品！<a href='javascript:history.back(-1)'>点击这里去购物</>"
                            runat="server" Visible='<%#bool.Parse((repShoppingCart.Items.Count==0).ToString())%>'></asp:Label>
                    </div>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="repCreditCart" runat="server">
                <HeaderTemplate>
                    <div class="linbg">
                        <li><b>积分兑换商品清单</b></li></div>
                    <div style="border: none;" class="glst">
                        <div class="glst_top">
                            <li class="gw2">积分兑换商品名称</li>
                            <li class="gw3">兑换所需积分</li>
                            <li class="gw4-1">实际发货</li>
                            <li class="gw3">数量</li>
                            <li class="gw4">积分小计</li>
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
            <!--end商品清单-->
            <!--begin 预付款-->
            <% if (Balance > 0)
               { %>
            <div style="margin-left: 30px;">
                <div>
                    <input id="CkUserWith" type="checkbox" /><label for="CkUserWith">使用余款(账户当前可用余额：<%=Balance%>元)</label> <input id="uCountMoney"  value="<%=Balance%>" type="hidden" /></div>
                <% if (!IsOpenBlance)
                   { %>
                <div style="margin-top: 9px;">
                    <span style="color: #662217;">为了保障您账户资金安全，余额暂时不能用，请先开</span> 
                    <a href="<%=EbSite.Base.Host.Instance.GetOpenBalance %>" target="_blank" style="color: #204862">启支付密码</a></div>
                <% }
                   else
                   { %>
                <div id="withPass" style="margin-top: 5px; display: none">
                    本次使用：<input id="tbMoney" runat="server" type="text" style="width: 50px;" onblur="SetBalance(this)" />元 支付密码：<input id="tbPassWord"  runat="server" type="password" />
                    <a href="<%=HostApi.GetModuleUrl("c65f0059-b345-4c0b-a437-37363f2fa4e9","c6dd03df-5606-41a2-b09e-6e6981dc3b2e")%>" target="_blank">忘记支付密码？</a></div>
                <% }
                %>
            </div>
            <%} %>
            <!---end预付款-->
            <!--商品可选项和结算-->
            <div class="tabbill">
                <div class="billleft">
                    <div style="padding-bottom:10px;">
                        <a href="javascript:void(0);" listid="listyhqid" class="otherfree">+使用优惠卷</a>
                        <li id="listyhqid" style="display: none;"><span class="combo">
                            <input id="txtTick" name="txtTick" style="width: 125px;" class="combo-text validatebox-text" autocomplete="off"><span class="combo-arrow" onclick="opFun()"></span> </span>
                            <input id="btnCoupon" class="youhui_btn_sub" value="使用优惠券" onclick="ckTicket()" type="button">
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
                                            <span style="line-height: 20px; color: #ccc;">说明：<%# Eval("Remark")%></span>
                                        </dl>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="billtwo color66">
                        <div class="billtwoline1">
                            <li>订单留言(请不要超过30字)</li>
                        </div>
                        <input type="text" name="txtRemark" id="txtRemark" style="width: 90%;" class="orderRemakInfo"
                            value="收货信息、配送方式、支付方式等以上述选定值为准，在此备注无效" />
                        <br />
                        <input id="txtgroup" runat="server" name="txtgroup" value="" type="hidden" />
                        <input id="txtrush" runat="server" name="txtrush" value="" type="hidden" />
                        <span>(如果您有其他需求，请在此填写备注，我们会尽力为您服务。)</span>
                    </div>
                </div>
                <div class="billright">
                    <table>
                        <tr>
                            <td>
                                商品金额：
                            </td>
                            <td>
                                &yen;<asp:Literal ID="ltlTotalProduct" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                产品数量：
                            </td>
                            <td>
                                <font color="red" size="2">
                                    <asp:Literal ID="ltlCount" runat="server"></asp:Literal></font>
                            </td>
                        </tr>
                        <tr>
                            <td title="满额打折活动,满额免费用" valign="top">
                                促销活动：
                            </td>
                            <td class="DiscountInfo">
                                <font class="a-blue" size="2">
                                    <asp:Literal ID="DiscountInfo" runat="server"></asp:Literal></font>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                优惠后金额：
                            </td>
                            <td>
                                <b style="font-size: 18px; color: Red;">
                                    <asp:Literal ID="ltlTotal" runat="server"></asp:Literal></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                可得积分：
                            </td>
                            <td>
                                <font color="red" size="2">
                                    <asp:Literal ID="ltlPoints" runat="server"></asp:Literal></font>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                优惠券抵扣金额：
                            </td>
                            <td>
                                <font color="red" size="2" id="ltlTicket">0.00</font> 元
                            </td>
                        </tr>
                        <tr>
                            <td>
                                运费：
                            </td>
                            <td>
                                <font color="red" size="2" id="ltlTrans">0.00</font>元
                            </td>
                        </tr>
                          <tr>
                            <td>
                                使用余款：
                            </td>
                            <td>
                                <font color="red" size="2" id="ltlBalance">0.00</font>元
                            </td>
                        </tr>
                        <tr>
                            <td>
                                支付手续费：
                            </td>
                            <td>
                                <font color="red" size="2" id="ltlShouXu">0.00</font>元
                            </td>
                        </tr>
                        <tr>
                            <td>
                                订单选项费用：
                            </td>
                            <td>
                                <font color="red" size="2" id="ltlOrderFee">0.00</font> 元
                            </td>
                        </tr>
                        <tr>
                            <td>
                                订单总价格：
                            </td>
                            <td>
                                <font color="red" size="5" id="ltlsummoney">0.00</font> 元
                            </td>
                        </tr>
                    </table>
                    <input type="submit" name="btnSaveOrder" style="border: none;  cursor: pointer;" value="" id="btnSaveOrder"
                        class="btnsave"  />
                </div>
            </div>
            <!--end商品可选项和结算-->
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
        //购物车里的商品重量，克
        var sumweight = <%=TotalWeight %>; 
        var summoney=<%=TotalMoney %>;
        var IsFreeEight = <%=IsFreeEight?"true":"false" %>;
        var IsFreePay = <%=IsFreePay?"true":"false" %>;
        var IsOrderOption = <%=IsFreeOrderOption?"true":"false" %>;
    </script>
    <script type="text/javascript" src="<% =ThemePage%>mshoppingcar2.js"></script>
</body>
</html>
