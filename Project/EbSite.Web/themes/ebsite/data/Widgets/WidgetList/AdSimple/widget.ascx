<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.Simple.widget" %>
<asp:Repeater ID="rpDataList" runat="server" EnableViewState="False">
    <ItemTemplate>
       
        <li><a href="<%# Eval("url")%>"><%# Eval("txttitle")%></a></li>
              
    </ItemTemplate>
</asp:Repeater>