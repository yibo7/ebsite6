<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.morderinfo" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls" Assembly="EbSite.Modules.Shop" %>
<!doctype html>
<html>
<head id="Head2" runat="server">
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
            <script runat="server">
                protected string temStateStep = string.Concat("<div style=\"text-align:left;\"><img src=\"", EbSite.Base.Host.Instance.MThemesPath, "css/images/{0}.png\" /></div><ul class=\"jtwenzi\"><li>{1}</li><li>{2}</li><li>{3}</li><li>{4}</li><li>{5}</li></ul>");
                public string GetStateStep()
                {
                    string html = string.Empty;
                    //订单状态 0提交订单 1审核订单 2等待付款 21支付款 3已发货 4确认收货 5交易完成
                    int Status = Model.OrderStatus;
                    int PayModel = Model.PaymentTypeId;
                    string Tips2 = (PayModel == -1) ? GetStatusTips(1) : ((Model.OrderStatus>2)?GetStatusTips(21):GetStatusTips(2));
                    DateTime? dtStep2 = (PayModel == -1) ? Model.ReviewedOrderDate : Model.PayDate;
                    string img = "orderprocess" + Status;
                    if (Status == 0)
                    {
                        img = "orderprocess1";
                    }
                    if (Status == 1)
                    {
                        img = "orderprocess2";
                    }
                    if (Status == 6)
                    {
                        Tips2 = GetStatusTips(Status);
                        dtStep2 = Model.DelOrderDate;
                    }
                    string subTem = "{0}<br/><span>{1}</span>";
                    html = string.Format(temStateStep, img,
                        string.Format(subTem, GetStatusTips(0), Model.OrderAddDate),
                        string.Format(subTem, Tips2, dtStep2),
                        string.Format(subTem, GetStatusTips(3), Model.SendDate),
                        string.Format(subTem, GetStatusTips(4), Model.SureReceiptDate),
                        string.Format(subTem, GetStatusTips(5), Model.FinishDate));
                    return html;
                }
            </script>

            <div class="eb-content">
                <div class="container">
                    <div class="navtitle"><li style="font-size: 16px;"><b><%=SiteName %></b>&nbsp;>&nbsp;订单中心</li></div>
                    <div class="bankimg ordrnum">
                        <div class="ornumtop">
                            <b>&nbsp; 订单号：<%=Model.OrderId%>
                                状态：<span><%=Model.OrderStatusText %></span>
                                <% if (Model.OrderStatus == 0 && Model.PaymentTypeId != -1)
                                    { %>
                                    <a href="<%=ShopLinkApi.GoToPayUrl(GetSiteID,Model.OrderId) %>"><img src="<% =ThemeCss%>images/btn2.jpg" /></a>
                                <%}%>
                            </b>
                        </div>
                        <div class="ornumbot"><%=OrderStateMark%></div>
                    </div>
                    <div class="jtimg"><%=GetStateStep() %></div>
                    <div class="bankimg" style="background: none; font-size:12px;">
                        <div id="tg1" class="dealinfo">
                            <div class="dealtitle">
                                <li style="width: 100px;"><b>处理时间</b></li>
                                <li style="width: 176px;"><b>处理信息</b></li>
                                <li style="width: 100px;"><b>操作人</b></li>
                            </div>
                            <asp:Repeater ID="orderrecod" runat="server">
                                <ItemTemplate>
                                    <div class="dealtitle" style="border-bottom: none;">
                                        <li style="width: 100px;"><%# DateTime.Parse(Eval("OpDate").ToString()).ToString("yyyy-MM-dd hh:mm") %></li>
                                        <li style="width: 176px; overflow:hidden;"><%# Eval("OpCtent") %></li>
                                        <li style="width: 100px;"><%# Eval("OpUserName") %></li>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="ordinfo" style="font-size:12px;">
                        <div class="zfwcline" style="border-bottom: none"><li class="color63"><b>订单信息</b></li></div>
                        <div class="infocen">
                            <div class="sentinfo">
                                <li>收货人：<%=Model.SendToUserName %></li>
                                <li>手机号码：<%=Model.CellPhone %></li>
                                <li>邮政编码：<%=Model.ZipCode %></li>
                                <li>地址：<%=Model.Address %></li>
                            </div>
                            <div class="sentinfo">
                                <li>支付方式：<%=Model.PaymentType %></li>
                                <li>配送方式：<%=Model.ModeName %></li>
                                <li>运费：<font color="#ff0000">&yen;<%=Model.Freight %></font></li>
                            </div>
                                <asp:Repeater ID="orderItem" runat="server">
                                    <HeaderTemplate>
                                        <div class="sentinfo" style="border-bottom: none;"><li><b>商品清单</b></li></div>
                                        <div class="shoplistit">
                                            <li style="width:173px;">商品名称</li>
                                            <li style="width:85px;">价格</li>
                                            <li style="width:65px;">商品数量</li>
                                        </div>
                                        <div class="shoplistit shopnone">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li style="width:173px;overflow:hidden;"><a target="_blank" href='<%# HostApi.MGetContentLink(Eval("ProductId"))%>'><%# Eval("ProductName")%></a></li>
                                        <li style="width:85px;"><span>&yen;<%# Eval("TotalRealSellPrice")%></span></li>
                                        <li style="width:65px;"><%# Eval("quantity") %></li>
                                    </ItemTemplate>
                                    <FooterTemplate></div></FooterTemplate>
                                </asp:Repeater>
                                
                                
                                  <asp:Repeater ID="rptCoreOrder" runat="server">
                        <HeaderTemplate>
                            <div class="sentinfo" style="border-bottom: none;"><li><b>积分兑换清单</b></li></div>
                            <div class="shoplistit">
                                <li style="width: 58px;">序号</li>
                                <li style="width: 173px;">商品名称</li>
                                <li style="width: 50px;">商品数量</li>
                            </div>
                            <div class="shoplistit shopnone">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li style="width: 58px;">
                                <%# Container.ItemIndex+1 %></li>
                            <li style="width: 173px;"><a href="<%#ShopLinkApi.MJiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("CreditProductID")) %>"
                                target="_blank">
                                <%# Eval("ProductName")%></a></li>
                            <li style="width: 50px;">
                                <%# Eval("quantity") %></li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                            <div style="height: 10px;"> &nbsp;</div>
                        </div>
                        <ul class="procount">
                            <li><div class="proconl">商品总额:&yen;<%=Model.Amount %></div></li>
                            <li><div class="proconl">+运费:&yen;<%=Model.Freight %></div></li>
                            <li><div class="proconl">-优惠:&yen;<%=Model.DiscountAmount %></div></li>
                            <li><div class="proconl">+支付手续费:&yen;<%=Model.PayFree %></div></li>
                        </ul>
                        <div class="countall"><li>应付金额：<span>&yen;<%=Model.OrderTotal %></span></li></div>
                    </div>
                </div>
            </div>
   
            <span runat="server" id="datacount"></span>
            <div style="display: none">
                <div id="divHelpPay">
                    <div>请将以下链接发给好友，完成代付：</div>
                    <div style="width: 500px; height: 28px; line-height: 28px;margin: 10px;"><a  id="divHelpPayUrl" target="_blank" href="<%=ShopLinkApi.GoToPayUrlHelp(GetSiteID,Model.OrderId)%>"><%=ShopLinkApi.GoToPayUrlHelp(GetSiteID,Model.OrderId)%></a></div>
                    <div><input type="button" style="border: #C23033 solid 1px; background: #E2383B; padding: 5px;color: #fff;" onclick="CopyObText(divHelpPayUrl)" value="复制链接" /></div>
                </div>
            </div>
            <div style="display: none">
                <div id="divCloseOrder">
                    <ifram>
                    <div class="tipetitle">取消订单</div>
                    <table>
                        <tr><th>原因:</th>
                        <td>
                                <textarea id="txtRea" rows="6" cols="39"></textarea>
                        </td>
                        </tr>
                        <tr><th></th>
                        <td style="color:red;">请注意:若使用的优惠券,不能退回,请慎重选择。</td></tr><tr><th></th>
                        <td align="center"><input type="button" value=" 确定 " onclick="CloseOrder(<%=Model.id%>)" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="button" value=" 取消 " onclick="closefancybox()" />
                        </td></tr>
                        </table>
                    </ifram>
                </div>
            </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>


