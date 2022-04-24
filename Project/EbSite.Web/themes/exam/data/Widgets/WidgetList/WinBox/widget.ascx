<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.WinBox.widget" %>

<asp:Panel ID="plOneItem" runat="server"></asp:Panel>
  <asp:Repeater ID="rpData" runat="server" 
    onitemdatabound="rpData_ItemDataBound"  >
  <ItemTemplate>         
      <asp:Panel ID="plItem"  runat="server"></asp:Panel> 
  </ItemTemplate>
</asp:Repeater> 
      