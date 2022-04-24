<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.GetUserMsg.widget" %>
<asp:Repeater ID="rpSubMsg" runat="server">
    <ItemTemplate>
        <div>
            <%#Eval("title") %>-<span><%#Eval("senddate") %></span></div>
    </ItemTemplate>
</asp:Repeater>
