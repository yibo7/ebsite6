<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.BBS.Widgets.BBSNav.widget" %>
<asp:Repeater ID="rpDataList"  runat="server">
            <ItemTemplate>
               <%# Eval("ReplyContent")%>
            </ItemTemplate>
</asp:Repeater>