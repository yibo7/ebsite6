<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mactfullmoney" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"></head>
<body>
   <!--#include file="headernav.inc"-->
    <div  class="eb-content">
	<div class="container">	
		<div class="tuanprice w990">
			<div class=" tpl" >
				<ul><li> ÂúÁ¿: &nbsp;</li>
				<li>
                    <dt class="w40"><a href="/activities-3-0-1.ashx">È«²¿</a></dt>
                    <asp:Repeater ID="rpActFullQuantity" runat="server">
                        <ItemTemplate>
                            <dt class="w40"><a href="<%#  ShopLinkApi.ActFullQuantity(GetSiteID,Eval("id")) %>"><%#Eval("TitleName")%></a></dt>
                        </ItemTemplate>
     		       </asp:Repeater></li>
				</ul>
			</div>
		</div>
		<div class="tuanprice mlst w990">
			<div class=" tpl" >
				<ul><li > Âú¶î: &nbsp;</li>
				<li>
                    
                    <asp:Repeater ID="rpActFullMoney" runat="server">
                        <ItemTemplate>
                           <dt class="w40"><a  href="<%#ShopLinkApi.ActFullMoney(GetSiteID,Eval("id")) %>"><%#Eval("TitleName")%></a><dt>
                        </ItemTemplate>
     		       </asp:Repeater>
				</li>
				</ul>
			</div>
		</div>
        <div class="actfullmoney">
             <div class="title"><h1> <%=Model.TitleName %></h1></div>
             <div class="contentinfo">
                 <%=Model.Description %>
             </div>
		</div>
	 	
        </div></div>
    <div style="clear: both;">
        <!--#include file="footer.inc" -->
    </div>
</body>
</html>
