<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mmactfullquantity" %>

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
         <div style="margin:5px;padding:5px; width: 100%;text-align: center;">促销活动</div>
         <div class="yhtuanlst">
             <ul class="tuantab1">
              <asp:Repeater ID="rpList" runat="server">
                        <ItemTemplate>
                            <li>
                                <div><a href="<%#HostApi.MGetContentLink(Eval("id")) %>"><img src="<%#GetBigImgUrl(Eval("smallpic").ToString()) %>"  width="145"  height="160"/></a></div>
                                <div style="height:3em;line-height:1.5em;overflow:hidden;"><a href="<%#HostApi.MGetContentLink(Eval("id")) %>"><%#Eval("newstitle")%></a></div>
                                <div><div class="tuantab5 all"> 活动：<%# Eval("ActName") %><a href="<%#HostApi.MGetContentLink(Eval("id")) %>"></a></div></div>
                                <div>商品价格：<span>&yen;<%# Eval("price") %></span></div>
                            </li>
                        </ItemTemplate>
     		</asp:Repeater>
             </ul>
             <div style="clear:both;"></div>
               <div class="btnloadmore">加载更多...</div>
                <XS:PagesContrl ID="pgCtr" PageSize="4" runat="server" />
            <!--#include file="foot.inc" -->
        </div>
        
    </div>
   </div>
</body>
</html>
<script>
    loadpage(".tuantab1", ".btnloadmore", '.tuantab1 li');
</script>