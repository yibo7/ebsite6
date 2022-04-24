<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.History.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<table>
    <tr>
        <td>调用数据:</td>
        <td>
            <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
        </td>
    </tr>
       <tr>
        <td>数据模板:</td>
        <td>
            <XS:ExtensionsCtrls ID="drpTemMoreList"   ModelCtrlID="71579f18-a40c-42fb-aa8c-73ee820ad3f3" runat="server"/>
        </td>
    </tr>
</table>