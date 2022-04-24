<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.FrdLink.widget" %>

  <asp:Repeater ID="rpFrdLink" runat="server">
    <ItemTemplate>
        <%#Eval("SiteName")%>               
    </ItemTemplate>
</asp:Repeater>          