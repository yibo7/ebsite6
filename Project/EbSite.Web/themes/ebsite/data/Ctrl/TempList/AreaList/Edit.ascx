<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.AreaList.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
选择一级区域
<asp:DropDownList ID="drpArea1" AppendDataBoundItems="true"   runat="server">
    <asp:ListItem Value="0"  Text="选择区域"></asp:ListItem>
</asp:DropDownList>
