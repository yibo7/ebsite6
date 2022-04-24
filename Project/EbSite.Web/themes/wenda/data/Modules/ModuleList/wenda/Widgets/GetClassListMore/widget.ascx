<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.GetClassListMore.widget" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>

<asp:Repeater ID="rpAllClass" runat="server" OnItemDataBound="rpAll_ItemBound" EnableViewState="False" >
  <ItemTemplate>            		
  <ul class="icl">
    <li width="160">
            <a href="<%#HrefFactory.GetInstance(2).GetClassHref(Eval("ID"),Eval("HtmlName"),1)%>" class="<%#GetCurrentClass(Eval("ID"))%>">
                <b><%# Eval("ClassName")%></b>
            </a>
        </li>
        <asp:Repeater ID="rpSubList" runat="server">
            <ItemTemplate>
                <li>
                    <a href="<%#HrefFactory.GetInstance(2).GetClassHref(Eval("ID"),Eval("HtmlName"),1)%>" class="<%#GetCurrentClass(Eval("ID"))%>">
                        <span><%# Eval("ClassName")%></span>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
             <FooterTemplate>
                </ul>
            </FooterTemplate>
    </ItemTemplate>
</asp:Repeater> 