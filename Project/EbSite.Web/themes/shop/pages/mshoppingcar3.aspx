<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mshoppingcar3" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <div class="gtop">
       <!--#include file="headersmall.inc"-->
        <div class="eb-content">
            <div class="container">
                <div class="top2bnr">
                    <li>
                        <a href="<%=HostApi.GetMainIndexHref(GetSiteID) %>"><img src="<%=base.ThemeCss %>images/logo.png" /></a></li>
                    <li class="r">
                        <img src="<%=base.ThemeCss %>images/lin7.png" /></li>
                </div>
            </div>
        </div>
    </div>
    <div class="center_x">
        <div class="container">
            <div class="orderok">
                <div class="orokimg all2pic"></div>
                <div class="orinfook">
                    <li class="color00a"><%=Tips%></li>
                    <li class="color654">订单号：<%=OrderNumber%> <span class="orline"></span>应付金额：<b class="colorc0"><%=TotalPay %>元</b> </li>
                </div>
            </div>

            <div class="zfbank">
                <div class="zfbaktitle">
                    <li style="float: left"><b style="font-size: 14px;">立即支付<font class="colorc0"><%=TotalPay %>元</font>,即可完成订单。</b>请您在<font class="colorc0"><b>24小时</b></font>内完成支付，否则订单会被自动取消。</li>
                    <li style="float: right">
                        <div class="syhelp all2pic"></div>
                        <span>使用帮助</span></li>
                </div>

                <div class="clear"></div>
                <div class="bankimg">
                    <div class="bakimtitle">
                        <li class="cur">请选择适合您的支付类型</li>
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
                                                    </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <input name="PayInfo" type="hidden" value="<%=PayInfo%>" />
                            <input name="OrderNamber" type="hidden" value="<%=OrderNumber%>" />
                            <input name="PayMoney" type="hidden" value="<%=TotalPay %>" />
                            <input name="PayKey" type="hidden" value="<%=PayKey %>" />
                            <input type="submit" name="btnSaveOrder" style="border: none" class="btnzfok all" value="" />
                        </form>
                    </div>
                </div>
            </div>
            <div class="zfwcline">
                <li class="color63">完成支付后，您可以：<a href="#">查看订单详情</a> </li>
            </div>
        </div>
    </div>
    <div class="clear"></div>
    <div class="footer">
        <div class="container">


            <div class="clear"></div>
            <div class="youlian copy" style="margin-top: 15px;">
                <%=EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.Copyright %>
            </div>



        </div>
    </div>

    <!--footer--->
    <script>
        function OnGotoPay(obj) {
            var rdopaymentapi = $('input[name="paymentapi"]:checked').val();
            if (rdopaymentapi == null || rdopaymentapi == undefined) {
                alert("请选择一个支付类型");
                return false;
            }
            return true;
        }
    </script>
</body>
</html>
