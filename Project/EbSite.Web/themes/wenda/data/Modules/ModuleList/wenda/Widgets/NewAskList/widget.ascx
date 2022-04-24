<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.NewAskList.widget" %>
<asp:Repeater ID="rpList" runat="server">
    <ItemTemplate>
        <li>
            <dd class="<%#GetStyle(Container.ItemIndex + 1)%> asklistitem">
                <%# Container.ItemIndex + 1%>. <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),7)%>" title="<%# Eval("NewsTitle")%>">
                    <%# Eval("NewsTitle")%></a></dd>
        </li>
    </ItemTemplate>
</asp:Repeater>
