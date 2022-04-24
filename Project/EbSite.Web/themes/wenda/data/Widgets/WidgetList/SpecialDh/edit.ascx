<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.SpecialDh.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

选择要显示的专题:<br>
<asp:ListBox ID="cblSpecial"  AppendDataBoundItems="true"  Height="200" SelectionMode="Multiple" runat="server">
     <asp:ListItem Text="自动适应分类ID" Value="-1"></asp:ListItem>
    <asp:ListItem Text="全部" Value="0"></asp:ListItem>
</asp:ListBox>
<br>
数据模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="1cc0fd08-8ffa-4eb6-902e-811f2253af83" runat="server"/>

注：自动适应分类ID为，把所有专题都属于这个分类的给查出来 RelateClassIDs  
<br>           