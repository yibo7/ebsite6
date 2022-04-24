<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mmshoppingcar3" %>

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
         
          
        <div class="container">
            <div class="orderok">
               
                <div class="orinfook">
                    <li class="color00a"><%=Tips%></li>
                    <li class="color654">订单号：<%=OrderNumber%> <span class="orline"></span>应付金额：<b class="colorc0"><%=TotalPay %>元</b> </li>
                </div>
            </div>

            <div class="zfbank">
                <div class="zfbaktitle">
                    <li style="float: left"><b style="font-size: 14px;">立即支付<font class="colorc0"><%=TotalPay %>元</font>,即可完成订单。</b>请您在<font class="colorc0"><b>24小时</b></font>内完成支付，否则订单会被自动取消。</li>
                </div>
                <br/>
                <div class="clear"></div>
                <div class="bankimg">
                    <div class="bakimtitle">
                        <li class="">请选择适合您的支付类型</li>
                    </div>
                    <div id="con1" class="banklist">
                        <form action="/gotopay.ashx" onsubmit="return OnGotoPay(this)" method="post">
                            <asp:Repeater ID="rpPaymentPClass" runat="server">
                                <ItemTemplate>
                                    <div class="bakkjzf">
                                        <div class="magb10"><b><%# Eval("Name")%></b> <span class="color6c"><%# Eval("Demo")%></span></div>
                                        <asp:Repeater ID="rpPayments" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <input value="<%# Eval("id")%>" type="radio" name="paymentapi" id="paymentapi<%# Eval("id")%>" />
                                                    <label for="paymentapi<%# Eval("id")%>">
                                                        <img disabled alt="<%# Eval("paymentname")%>" src="<%# Eval("showimg")%>" />
                                                    </label>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <input name="PayInfo" type="hidden" value="<%=PayInfo%>" />
                            <input name="OrderNamber" type="hidden" value="<%=OrderNumber%>" />
                            <input name="PayMoney" type="hidden" value="<%=TotalPay %>" />
                            <input name="PayKey" type="hidden" value="<%=PayKey %>" />
                            <input type="submit" name="btnSaveOrder" style="width: 100%; background: #D92509; height: 40px; cursor: pointer; font-size: 14px; font-weight:bold; color: #ffffff;" value="确认支付方式" />
                        </form>
                    </div>
                </div>
            </div>
            
        </div>
  
        </div>
    </div>
        </div>
    </div>
    
    
</body>
</html>
