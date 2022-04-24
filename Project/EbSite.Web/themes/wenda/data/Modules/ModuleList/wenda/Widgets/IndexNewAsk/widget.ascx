<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.IndexNewAsk.widget" %>
<asp:Repeater ID="rpRssNewsContent" runat="server">
    <ItemTemplate>
        <li>
            <dd class="hid <%#Equals((Container.ItemIndex + 1)%2,0)?"bg":""%> ">
                <span class="numlist">
                    <%# this.rpRssNewsContent.Items.Count + 1%></span> <a title="<%# DataBinder.Eval(Container.DataItem,"title") %>"
                        href="<%#string.Concat(EbSite.Base.Host.Instance.Domain,EbSite.Base.Host.Instance.GetContentLink(DataBinder.Eval(Container.DataItem,"askid"), "",2))%>"
                        target="_blank"> <%# DataBinder.Eval(Container.DataItem,"title") %></a>
            </dd>
        </li>
    </ItemTemplate>
</asp:Repeater>
