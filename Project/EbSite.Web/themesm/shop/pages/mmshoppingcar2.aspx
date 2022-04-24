<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mmshoppingcar2" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls" Assembly="EbSite.Modules.Shop" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0">
    <title></title>
</head>
<body>
    <!--#include file="header.inc" -->
    <div class="pggbox">
        <div class="radiusbox">
            <div class="center_x">
                <div class="container">
                    <div class="t">收货人信息&nbsp;&nbsp;&nbsp;<a href="javascript:void(0);" onclick="UserNewAddress(this)">[使用新地址]</a></div>
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
                    <div id="tabControlPanel" class="tabinfo">
                        <table class="tabaddress">
                            <tr><th>收货人</th><td><input type="text" id="txtSHR" class="mtxt" /></td></tr>
                            <tr><th>手机</th><td><input type="text" id="txtMobile" class="mtxt" /></td></tr>
                            <tr><th>省份</th><td><select id="selProvice" class="msel"><option value="0" selected="selected">请选择</option></select></td></tr>
                            <tr><th>城市</th><td><select id="selCity" class="msel"><option value="0" selected="selected">请选择</option></select></td></tr>
                            <tr><th>地区</th><td><select id="selcoutry" class="msel"><option value="0" selected="selected">请选择</option></select></td></tr>
                            <tr><th>详细地址</th><td><textarea id="txtaddress" class="maddress"></textarea></td></tr>
                            <tr><th>邮政编码</th><td><input type="text" id="txtPostCode" class="mtxt" /></td></tr>
                        </table>
                    </div>
                    <div id="divsaveinfobtn" style="margin-bottom: 10px;">
                        <div id="btnSaveReceiveAddress"  style="float: left; margin-right: 10px; height: 20px; background: #FEDDB5; color: #663904; border: 1px solid #EFA44D;">保存收货人信息</div>
                        
                        <div class="btnsaver">请确保您填写的收货人信息准确无误，否则导致您无法及时收到货物。</div>
                    </div>
                    <form id="fmgotobuy" method="post" onsubmit="return vlorderinfo(this)" action="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.MGoToPayUrl(GetSiteID) %>">
                    <!--选择配送方式-->
                    <br/>
                        <div class="t">选择配送方式</div>
            
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
                                <option value="1">只在工作日送货</option>
                            </select>
                            <li><span>提醒：</span>此信息打印在快递面单上，作为快递公司送货的参考依据，个别地区配送可能会有延误，请谅解。</li>
                        </div>
                    </div>
                    <!--end选择配送方式-->
                    <!--支付方式-->
                        <div class="t">选择支付方式</div>
            
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
                            <div class="t">商品清单</div>
                   
                            <div style="border: none;" class="glst">
                       
                        </HeaderTemplate>
                        <ItemTemplate>
      
                            <div class="ItemCell2">
                                        <div class="ProName2">
                                            <span class="OrderNo"> <%# Container.ItemIndex + 1%></span> <a target="_blank" href='<%# HostApi.GetContentLink(Eval("ProductId"))%>'>
                                                                <%# Eval("ProductName")%></a></div>
                                            <div>
                                                <font color="red" size="2">  <%# Eval("SKUContent")%></font>    
                                                <font class="a-blue" size="2"> <%# Eval("PurchaseGiftInfo")%></font>
                                                <font class="a-blue" size="2"> <%# Eval("WholesaleDiscountInfo")%></font>
                                            </div>
                                            <div>
                                                <%# Eval("TotalRealSellPriceInfo")%></div>
                                            <div>
                                                <%# Eval("GiveQuantityInfo")%></div>
                                        <div class="NePrice2">
                                            <span>&yen;<%# Eval("TotalRealSellPrice")%></span></div>
                                            <div>实际发货：<%# Eval("RealQuantity")%></div>
                                        <div class="ItemQty">
                                            购买数量：<%# Eval("Quantity") %> 
                                        </div>
                                        <div>送积分: <%# Eval("TotalPoints")%></div>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <div class="glst_lst_sub">
                                                <li style="text-align: left; color: #ABABAB;" class="gw2">[<%# Eval("OptionName")%>]<%# Eval("ItemName")%>
                                                </li>
                                                <li class="gw3">价格:&yen;<%# Eval("TotalPrice")%></li>
                                       
                                                <li class="gw5 " style="width: 70px;">
                                                    数量:   <%# Eval("Quantity") %>
                                                </li>
                                       
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                               
                                    </div>

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
            
                    </asp:Repeater>
                    <!--end商品清单-->
                    
                    <!--商品可选项和结算-->
                    <div class="tabbill">
                        <div class="billleft">
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
                                        运费：
                                    </td>
                                    <td>
                                        <font color="red" size="2" id="ltlTrans">0.00</font>元
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
                                        订单总价格：
                                    </td>
                                    <td>
                                        <font color="red" size="5" id="ltlsummoney">0.00</font> 元
                                    </td>
                                </tr>
                            </table>
                    
                   
                   
                        </div>
                    </div>
                    <!--end商品可选项和结算-->
                    <input id="optionitemids" name="optionitemids" type="hidden" runat="server" />
                    <input id="address" name="address" type="hidden" runat="server" />
                        <div style="clear: both;">
       
            
                
                  
                            <input type="submit" name="btnSaveOrder" style="width: 100%; background: #D92509; height: 40px; cursor: pointer; font-size: 14px; font-weight:bold; color: #ffffff;" value="确认无误，提交订单" id="btnSaveOrder"/>
                
          
       
            </div>
                    </form>
                    <div class="clear"></div>
                    <div class="linbg" style="border-bottom: none"></div>
                </div>
            </div>
        </div>
    </div>
     <script type="text/javascript">
        //购物车里的商品重量，克
        var sumweight = <%=TotalWeight %>; 
        var summoney=<%=TotalMoney %>;
        var IsFreeEight = <%=IsFreeEight?"true":"false" %>;
        var IsFreePay = <%=IsFreePay?"true":"false" %>;
        var IsOrderOption = <%=IsFreeOrderOption?"true":"false" %>;
    </script>    
    <script type="text/javascript" src="<% =MThemePage%>mshoppingcar2.js"></script>
      <!--#include file="foot.inc" -->
</body>
</html>
