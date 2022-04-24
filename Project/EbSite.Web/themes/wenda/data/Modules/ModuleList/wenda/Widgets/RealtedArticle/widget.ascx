<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.RealtedArticle.widget" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<asp:Repeater ID="rpRelateContent" runat="server">
    <ItemTemplate>
        <li><a title="<%#Eval("Title")%>" href="<%#Eval("CtLink").ToString()%>" target="_blank"><%#Eval("Title")%></a>
           </li>
    </ItemTemplate>
</asp:Repeater>
