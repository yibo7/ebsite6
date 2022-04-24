<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.SpecialList.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

选择要获取数据的专题:<br>
<asp:ListBox ID="cblSpecial"  Height="200" AppendDataBoundItems="true"  runat="server">
    <asp:ListItem Value="0" Text="自动适应ID"></asp:ListItem>
</asp:ListBox>
<br />
获取条数:<XS:TextBox ID="txtCount" Width="80" CanBeNull="必填" RequiredFieldType="数据校验" runat="server">10</XS:TextBox>
<br>
<br>
是否获取子级内容:<asp:CheckBox ID="cbIsGetSub" runat="server" />
<br>
<br>
数据模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="e878b3c7-6edc-466a-95da-61cb910cec68" runat="server"/>
<br>