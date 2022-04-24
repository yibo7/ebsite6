<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mmgrouplist" %>

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
             <div style="margin:5px;padding:5px; width: 100%;text-align: center;">团购活动</div>
           
            <div class="yhtuanlst">
                <ul class="tuantab1">
                <asp:Repeater ID="rpList" runat="server">
                    <ItemTemplate>
                        <li>
                            <div><a href="<%# ShopLinkApi.MGroupShow(base.GetSiteID,Eval("id"),Eval("productid")) %>"><img src="<%# Eval("smallimg") %>" width="145" height="160" /></a></div>
                            <div title="<%# Eval("title") %>" style="height:3em;line-height:1.5em;overflow:hidden;color:#808080"><%# Eval("title") %></div>
                            <div><span style="color:#ff6a00;">优惠价：<font class="ftuan">&yen;<%# Eval("BuyPrice") %></font></span><br /><span style="color:#808080">原价：</span><span>&yen;<%# Eval("price") %></span></div>
                            <div><span style="color:#808080">折扣：</span><%#EbSite.Modules.Shop.ModuleCore.Core.GetDiscountRate(Eval("price"),Eval("BuyPrice")) %></div>
                            <div><a href="<%# ShopLinkApi.MGroupShow(base.GetSiteID,Eval("id"),Eval("productid")) %>"><img src="<%=base.ThemeCss %>images/qkk.gif" /></a></div>
                            <div><%# Eval("Buyed")==null?"0":Eval("Buyed") %></span>人购买</div><div><%# GetEndDays(Eval("enddate")) %></div>
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