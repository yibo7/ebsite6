<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mactfullquantity" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls"
    TagPrefix="Shop" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"> 
</head>
<body>
<!--#include file="headernav.inc"-->
<div  class="eb-content">
	<div class="container">	
		<div class="tuanprice w990">
			<div class=" tpl" >
				<ul><li> 满量: &nbsp;</li>
				<li>
                    <dt class="w40"><a href="/activities-3-0-1.ashx">全部</a></dt>
                    <asp:Repeater ID="rpActFullQuantity" runat="server">
                        <ItemTemplate>
                            <dt class="w40"><a href="<%#ShopLinkApi.ActFullQuantity(GetSiteID,Eval("id")) %>"><%#Eval("TitleName")%></a></dt>
                        </ItemTemplate>
     		       </asp:Repeater></li>
				</ul>
			</div>
		</div>
		<div class="tuanprice mlst w990">
			<div class=" tpl" >
				<ul><li > 满额: &nbsp;</li>
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
	 	<div class="yhtuanlst">
              <asp:Repeater ID="rpList" runat="server">
                        <ItemTemplate>
                            <div  class="tuaninfo h399">
				                <div class="tuantab1" ><li><a href="<%#HostApi.GetContentLink(Eval("id"),Eval("classid")) %>"><img src="<%#GetBigImgUrl(Eval("smallpic").ToString()) %>"  width="290"  height="290"/></a></li>
				                <li><a href="<%#HostApi.GetContentLink(Eval("id"),Eval("classid")) %>"><%#Eval("newstitle")%></a></li></div>
				                <div class="tuantab5 all">
					                <li>活动：<%# Eval("ActName") %></li>
                                    <li class="aright"><a href="<%#HostApi.GetContentLink(Eval("id"),Eval("classid")) %>"></a></li>
				                </div>
				                <div class="tuantab3 h35">
					                <li class="col">商品价格：<span>&yen;<%# Eval("price") %></span></li>
				                </div>
			                </div>	
                        </ItemTemplate>
     		</asp:Repeater>
		</div>
	 	<div class="page"><XS:PagesContrl ID="pgCtr"  runat="server" /></div>
	</div>
</div>
        <!--#include file="footer.inc" -->
</body>
</html>
