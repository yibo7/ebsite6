<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Shop.Widgets.PjLeftInfo.widget" %>

<asp:Repeater ID="rpList" runat="server" EnableViewState="False" >
    <ItemTemplate>
        <ul>
            <li><a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID)%>" target="_blank"><img alt="<%#Eval("newstitle") %>" src="<%#Eval("smallpic") %>" /></a></li>
            <li class="p-name">商品名称：<a title="<%#Eval("newstitle") %>" href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID)%>" target="_blank"><%#Eval("newstitle") %></a></li>
            <li class="p-name" style="padding-top:5px;"><div class="dt">价格：</div><div class="dd"><strong style="color:red;">&yen;<%#Eval("annex16") %></strong></div></li>
            <li class="p-name" style="padding-top:5px;"><a class="btn-append" id="InitCartUrl" href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ShoppingCarUrl(GetSiteID,GetProductId) %>&num=1"><div class="btngwc all"></div></a> </li>
        </ul>
    </ItemTemplate>
</asp:Repeater>
