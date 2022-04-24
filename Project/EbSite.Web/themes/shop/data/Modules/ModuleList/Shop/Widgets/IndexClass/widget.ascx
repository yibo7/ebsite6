<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Shop.Widgets.IndexClass.widget" %>
<asp:Repeater ID="rpList" runat="server" EnableViewState="False" OnItemDataBound="rpList_ItemDataBound">
    <HeaderTemplate>
        <div class="sort">
            <ul class="sort_ul">
    </HeaderTemplate>
    <ItemTemplate>
        <li class="sort_1">
            <p class="title">
                <a href="<%#EbSite.Base.Host.Instance.GetClassHref(int.Parse(Eval("id").ToString()),1, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID)%>">
                    <%#Eval("classname") %></a></p>
            <p class="sort_a">
                <asp:Repeater ID="rpSubList" runat="server">
                    <ItemTemplate>
                        <a href="<%#EbSite.Base.Host.Instance.GetClassHref(int.Parse(Eval("id").ToString()), 1,EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID)%>">
                            <%#Eval("classname") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </p>
        </li>
        <li class="hide_sort" style="top: -2px; display: none;">
            <div class="hide_div">
               <asp:Repeater ID="rpSubList2" runat="server">
                                <ItemTemplate>
                                    <a href="<%#EbSite.Base.Host.Instance.GetClassHref(int.Parse(Eval("id").ToString()), 1,EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID)%>">
                                        <%#Eval("classname") %></a>
                                </ItemTemplate>
                </asp:Repeater>
            </div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul> </div>
    </FooterTemplate>
</asp:Repeater>
