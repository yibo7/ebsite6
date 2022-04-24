<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mmshoppingcar1" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
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
            <div class="t">
                我的购物车 您购物车中的商品将被永久保存。</div>
            <div class="">
               
                <div class="">
                    <asp:Repeater ID="repShoppingCart" runat="server">
                        <HeaderTemplate>
                             <div class="gtop">
                                <span>商品列表</span>
                             </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="ItemCell2">
                                <div class="ProName2">
                                    <span class="OrderNo"> <%# Container.ItemIndex + 1%></span> <a target="_blank" href='<%# HostApi.MGetContentLink(Eval("ProductId"))%>'>
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
                                    购买数量： <input style="width: 50px;" type="text" pid="<%# Eval("SKU") %>" value="<%# Eval("Quantity") %>"
                                        name="s<%# Eval("SKU") %>" id='s<%# Eval("SKU") %>' />
                                </div>
                                <div>送积分: <%# Eval("TotalPoints")%></div>
                                  <asp:Repeater ID="rpProductOptons" runat="server">
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
                                <div class="Operation">
                                 <span onclick='delcart("<%# Eval("SKU") %>",this)'><a>删除</a></span></div>
                            </div>
                            <asp:Repeater ID="rpGiveProducts" runat="server">
                               
                            </asp:Repeater>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div style="width: 100%; text-align: center; color: #ccc; padding-top: 10px;">
                                <asp:Label ID="lblEmpty" Text="您的购物车没有商品！<a href='javascript:history.back(-1)'>点击这里去购物</a>"
                                    runat="server" Visible='<%#bool.Parse((repShoppingCart.Items.Count==0).ToString())%>'></asp:Label>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="repCreditCart" runat="server">
                         <HeaderTemplate>
                             <div class="gtop">
                                <span>积分兑换商品列表</span>
                             </div>
                        </HeaderTemplate>
                       <ItemTemplate>
                            <div class="ItemCell2">
                                <div class="ProName2">
                                    <span class="OrderNo"> <%# Container.ItemIndex + 1%></span> <a target="_blank"  href='<%#ShopLinkApi.MJiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("CreditProductID")) %>'>
                                                    <%# Eval("ProductName")%></a></div>
                                <div>兑换所需积分：<%# Eval("Credit")%></div>
                                <div class="ItemQty">
                                    数量：  <%# Eval("Quantity")%>
                                </div>
                                <div>积分小计: <%# Convert.ToInt32( Eval("Credit").ToString())*Convert.ToInt32(  Eval("Quantity").ToString())%></div>
                                 
                                <div class="Operation">
                                 <span onclick='delcraditcart("<%# Eval("CreditProductID") %>",this)'><a>删除</a></span></div>
                            </div>
                       </ItemTemplate>
                    </asp:Repeater>
                    <div class="glst_tal">
                        <div class="tal_l">
                            <li>
                                <div class="cha all">
                                </div>
                                <a href="javascript:clearshoppingcar()">清空购物车</a> </li>
                        </div>
                        <div style="padding-bottom: 10px;" class="tal_r">
                            <li>
                                <dl>
                                    &nbsp;</dl>
                                <dl>
                                    商品金额：<span>&yen;<asp:Literal ID="ltlTotalProduct" runat="server"></asp:Literal></span></dl>
                            </li>
                            <li>
                                <dl>
                                    &nbsp;</dl>
                                <dl>
                                    商品数量：<asp:Literal ID="ltlCount" runat="server"></asp:Literal></dl>
                            </li>
                            <li>
                                <dl>
                                    &nbsp;</dl>
                                <dl>
                                    可得积分：<asp:Literal ID="ltlPoints" runat="server"></asp:Literal></dl>
                            </li>
                            <li>
                                <dl>
                                    &nbsp;</dl>
                                <dl>
                                    满额促销：<asp:Literal ID="DiscountInfo" runat="server"></asp:Literal>
                                    <input id="HiScore" name="HiScore" runat="server" type="hidden" />
                                </dl>
                            </li>
                        </div>
                    </div>
                    <div class="glst_bom">
                        <li>总计（不含运费）：<span>&yen;<asp:Literal ID="ltlTotal" runat="server"></asp:Literal></span></li></div>
                </div>
                
                
              
            </div>
        </div>
    </div>
    <div style="clear: both;">
        <div class="pggbox">
            <div class="addtocarbox">
                <div class="btnaddtocar">
                    <input type="button" id="GoNext" onclick="gotopay()" kaurl="<%=ShopLinkApi.MPostCarUrl(GetSiteID) %>" value="去结算" />
                    <input type="button" class="adv"onclick="javascript:history.back(-1)"  value="继续购物" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="<% =MThemePage%>mshoppingcar1.js"></script>
    <!--修改商品费用选项弹出窗口-->
    <div style="display: none;">
        <div style="width: 500px; height: 200px;" id="divEditeProductOption">
            <div id="divProductOptionItems">
            </div>
        </div>
    </div>
    <!--end-->
    <!--#include file="foot.inc" -->
</body>
</html>
<script>
    
    
function gotopay() {
    var userid =<%=EbSite.Base.Host.Instance.UserID%>;
    
    if (userid > 0) {
        var pram = { "userId": userid };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetUserScore", pram, gtUserScore);
    }
    else {
      
        window.location.href = "<%=EbSite.Base.Host.Instance.MLoginRw + "?ru=" + string.Format("{0}", EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.MShoppingCarUrl(GetSiteID)) %>";
    }
}
    
</script>