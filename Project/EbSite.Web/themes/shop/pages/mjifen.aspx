<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.jifen" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>
<body>
    <div id="centerbox">
        <!--#include file="headernav.inc" -->
        <div class="content">
            <div class="container">
                <div class="tuanprice w990">
                    <div class="tpl">
                        <ul>
                            <li>类别: &nbsp;</li>
                            <li>
                                <dt class="w40"><a href="<%=ShopLinkApi.JiFen(GetSiteID)%>" class="crr">全部</a></dt>
                                <XS:Repeater ID="RepClass" runat="server">
                                    <ItemTemplate>
                                        <dt><a href="<%#ShopLinkApi.JiFen(GetSiteID,Eval("id")) %>"><%#Eval("ClassName") %></a></dt>
                                    </ItemTemplate>
                                </XS:Repeater>
                            </li>
                        </ul>
                    </div>
                    <div class="sotabr fRight">
                    </div>
                </div>
                <div class="yhtuanlst">
                    <XS:Repeater ID="ScoreRep" runat="server">
                        <ItemTemplate>
                            <div class="tuaninfo h399" style="border-bottom: none;">
                                <div class="tuantab1">
                                    <li>
                                        <a href="<%#ShopLinkApi.JiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("id")) %>">
                                            <img src="<%#Eval("BigImg") %>" width="290" height="290" /></a></li>
                                    <li><%#Eval("ProductName")%> <%#Equals(Eval("Stock").ToString(),"0")?"库存为0":""%>  <%#Equals(Eval("IsSaling").ToString(), "0") ? "下架中" : ""%></li>
                                </div>
                                <div class="tuantab4">
                                    <li class="fleft ml"><font style="color: #FF8300; font-size: 16px;"><b>所需积分：<%#Eval("Credit") %>分</b></font><br />
                                        原价：<span>￥<%#Eval("MarketPrice") %></span></li>
                                    <li class="fRight">
                                        <a href="<%#ShopLinkApi.JiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("id")) %>">
                                            <div class="wydh all ">
                                            </div>
                                        </a>
                                    </li>
                                </div>
                            </div>

                        </ItemTemplate>
                    </XS:Repeater>
                </div>
                <!--fanye-->
                <div class="page" style="visibility: hidden;">
                    <XS:PagesContrl ID="pgCtr" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <!----中间--->
    <!--#include file="footer.inc" -->

</body>
</html>
