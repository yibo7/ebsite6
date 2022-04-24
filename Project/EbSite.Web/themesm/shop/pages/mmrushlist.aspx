<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mmrushlist" %>

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
           <div style="margin:5px;padding:5px; width: 100%;text-align: center;">限时抢购</div>
           <div class="yhtuanlst">
               <ul class="tuantab1">
                    <asp:Repeater ID="rpList" runat="server">
                        <ItemTemplate>
                                <li>
                                    <div><a href="<%#ShopLinkApi.MRushShow(GetSiteID, Eval("id"), Eval("ProductId"))%>"><img src="<%# Eval("smallimg") %>" width="145" height="160" /></a></div>
                                    <div style="height:3em;line-height:1.5em;overflow:hidden;"><a href="<%#ShopLinkApi.MRushShow(GetSiteID, Eval("id"), Eval("ProductId"))%>"><%#Eval("Title")%></a></div>
                                    <div><font color="#FF6633"><b>&yen;<%# Eval("CountDownPrice") %></b></font><br />原价：<span>&yen;<%# Eval("Price") %></span> </div>
                                    <div>折扣：<%# GetDiscountRate(Eval("Price"),Eval("CountDownPrice")) %></div>
                                    <div><div class="gobuy all "><a  href="<%#ShopLinkApi.MRushShow(GetSiteID, Eval("id"), Eval("ProductId"))%>"><img style="width: 100px; height: 30px;" src="<%=base.MThemeCss %>/images/bglink.gif"/></a></div></div>
                                    <div><%# EbSite.Modules.Shop.ModuleCore.Pages.mgrouplist.GetEndDays(Eval("enddate"),"抢购")%></div>
                                </li>
                        </ItemTemplate>
                    </asp:Repeater>
                  </ul>
               <div style="clear:both;"></div>
                 <div class="btnloadmore">加载更多...</div>
                <XS:PagesContrl ID="pgCtr" PageSize="4" runat="server" />
                </div>
            <!--#include file="foot.inc" -->
        </div>
    </div>
</body>
</html>
<script>
    loadpage(".tuantab1", ".btnloadmore", '.tuantab1 li');
</script>