<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mjifen" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div id="page">
        <div class="cont">
           <!--#include file="header.inc" -->   
           <div class="eb-content">
            <div class="container">
                 <div style="margin:5px;padding:5px; width: 100%;text-align: center;">积分兑换</div>
                <div class="tuanprice w990">
                    <div class="tpl">
                        <ul>
                                &nbsp;<a href="<%=ShopLinkApi.MJiFen(GetSiteID)%>" ><li class="crr">全部</li></a>
                                <XS:Repeater ID="RepClass" runat="server"><ItemTemplate><a href="<%#ShopLinkApi.MJiFen(GetSiteID,Eval("id")) %>"><li><%#Eval("ClassName") %></li></a></ItemTemplate></XS:Repeater>
                        </ul>
                    </div>
                    <div class="sotabr fRight"></div>
                </div>
                <div class="yhtuanlst">
                    <ul class="tuantab1">
                    <XS:Repeater ID="ScoreRep" runat="server">
                        <ItemTemplate>
                            <li>
                                <div><a href="<%#ShopLinkApi.MJiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("id")) %>"><img src="<%#Eval("BigImg") %>" width="145" height="160" /></a></div>
                                <div><%#Eval("ProductName")%> <%#Equals(Eval("Stock").ToString(),"0")?"库存为0":""%>  <%#Equals(Eval("IsSaling").ToString(), "0") ? "下架中" : ""%></div>
                                <div><font style="color: #FF8300; font-size: 12px;"><b>所需积分：<%#Eval("Credit") %>分</b></font><br />原价：<span>￥<%#Eval("MarketPrice") %></span</div>
                                <div><a href="<%#ShopLinkApi.MJiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("id")) %>"><div class="wydh all "></div></a></div>
                            </li>
                        </ItemTemplate>
                    </XS:Repeater>
                    </ul>
                    <div style="clear:both;"></div>
                </div>
                <div class="page" style="visibility: hidden;"><XS:PagesContrl ID="pgCtr" runat="server" /></div>
            </div>
            </div>
            <!--#include file="foot.inc" -->
        </div>
    </div>
</body>
</html>

