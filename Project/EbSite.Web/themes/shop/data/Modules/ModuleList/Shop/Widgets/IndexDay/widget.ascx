<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Shop.Widgets.IndexDay.widget" %>

<asp:Repeater ID="rpList" runat="server" EnableViewState="False" >
    <ItemTemplate>
        <div class="pr_info">
                    <div class="pr_left">
                    <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.RushShow(GetSiteID, Eval("id"), Eval("ProductId"))%>">
                    <img src="<%#Eval("SmallImg") %>" width="114" height="114" /></a></div>
                    <div class="pr_right">
                        <li style="height:3em;line-height:1.5em;overflow:hidden;"><%#Eval("Title")%></li>
                        <li><span>原价:</span><%#Eval("Price")%></li>
                        <li><span>优惠价:</span><%#Eval("CountDownPrice")%></li>
                        <div class="clear"></div>
                         <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.RushShow(GetSiteID, Eval("id"), Eval("ProductId"))%>"><div class="pr_btn2 all"></div></a>
                    </div>
                </div>
    </ItemTemplate>
</asp:Repeater>
