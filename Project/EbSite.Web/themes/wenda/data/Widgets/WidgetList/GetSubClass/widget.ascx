<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.GetSubClass.widget" %>

<asp:Repeater ID="rpSubClass"  runat="server">
            <ItemTemplate>                           
                    <a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("id"),Eval("HtmlName"),0)%>"><span><%# Eval("classname")%></span></a>
            </ItemTemplate>
</asp:Repeater>