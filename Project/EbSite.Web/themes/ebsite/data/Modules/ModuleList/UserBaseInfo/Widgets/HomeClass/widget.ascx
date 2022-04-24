<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.Widgets.HomeClass.widget" %>

<asp:Repeater ID="rpParentClass" OnItemDataBound="rpAll_ItemBound" runat="server" EnableViewState="False" >
  <ItemTemplate>            		
        <li <%#GetManageLink(Eval("id"),Eval("TabName")) %>>
            <a href="<%# GetUrl(Eval("id"))%>"><%# Eval("TabName")%></a>
        </li>
                                        <asp:Repeater ID="rpSubList" runat="server">
                                            <HeaderTemplate>
                                                <div class="submenu">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li <%#GetManageLink(Eval("id"),Eval("TabName")) %> >
                                                    --<a href="<%# GetUrl(Eval("id"))%>"><%# Eval("TabName")%></a>
                                                </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </div>
                                            </FooterTemplate>
                                        </asp:Repeater>       
    </ItemTemplate>
</asp:Repeater> 