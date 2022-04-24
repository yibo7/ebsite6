<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mgrouplist" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls"
    TagPrefix="Shop" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <!--#include file="headernav.inc" -->
    <div class="content">
        <div class="container">
            <div class="tuanprice w990">
                <div class="tpl">
                    <ul>
                        <li>价格: &nbsp;</li>
                        <li>
                            <dt class="w40"><a href="<%=ShopLinkApi.GroupList(GetSiteID)%>"
                                class="crr">全部</a></dt>
                            <dt><a href="<%=ShopLinkApi.GroupList(GetSiteID,1,1)%>">0-100元</a></dt>
                            <dt><a href="<%=ShopLinkApi.GroupList(GetSiteID,2,1)%>">100-200元</a></dt>
                            <dt><a href="<%=ShopLinkApi.GroupList(GetSiteID,3,1)%>">200-500元</a></dt>
                            <dt><a href="<%=ShopLinkApi.GroupList(GetSiteID,4,1)%>">500-1000元</a></dt>
                            <dt><a href="<%=ShopLinkApi.GroupList(GetSiteID,5,1)%>">1000元以上</a></dt>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="yhtuanlst">
                <asp:Repeater ID="rpList" runat="server">
                    <ItemTemplate>
                        <div class="tuaninfo h399">
                            <div class="tuantab1">
                                <li><a href="<%# ShopLinkApi.GroupShow(base.GetSiteID,Eval("id"),Eval("productid")) %>">
                                    <img src="<%# Eval("smallimg") %>" width="290" height="290" /></a> </li>
                                <li title="<%# Eval("title") %>" style="height:3em;line-height:1.5em;overflow:hidden;">
                                    <%# Eval("title") %></li>
                            </div>
                            <div class="tuantab4">
                                <li class="fleft"><font class="ftuan">&yen;<%# Eval("BuyPrice") %></font><br />
                                    &nbsp;&nbsp;原价：<span>&yen;<%# Eval("price") %></span> | 折扣：<%#EbSite.Modules.Shop.ModuleCore.Core.GetDiscountRate(Eval("price"),Eval("BuyPrice")) %></li>
                                <li class="fRight"><a href="<%# ShopLinkApi.GroupShow(3,Eval("id"),Eval("productid")) %>">
                                    <img src="<%=base.ThemeCss %>images/qkk.gif" /></a></li>
                            </div>
                            <div class="tuandata">
                                <li><span>
                                    <%#Eval("Buyed")%></span>人购买</li>
                                <li class="rig">
                                    <%# GetEndDays(Eval("enddate")) %></li>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="page"><XS:PagesContrl ID="pgCtr"    runat="server" /></div>
        </div>
    </div>
    <!--#include file="footer.inc" -->
    <script type="text/javascript" src="<% =ThemePage%>mgrouplist.js"></script>
    <script type="text/javascript">
        In.ready('times', function () {

            $(".subdiv-l div").each(function (index, element) {
                var id = $(this).attr("vid");
                var enddate = $(this).attr("enddate");

                var obShowTarget = {
                    sec: document.getElementById("sec" + id),
                    mini: document.getElementById("mini" + id),
                    hour: document.getElementById("hour" + id),
                    day: document.getElementById("day" + id)
                }

                fnTimeCountDown(enddate, obShowTarget, null);
            });



        });
    </script>
</body>
</html>
