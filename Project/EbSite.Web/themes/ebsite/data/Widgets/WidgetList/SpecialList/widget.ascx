<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.SpecialList.widget" %>

<asp:Repeater ID="rpSpecialContent"  runat="server">
            <ItemTemplate>
                <li>                                  
                    <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%# Eval("newstitle")%></a>
                </li>
            </ItemTemplate>
</asp:Repeater>