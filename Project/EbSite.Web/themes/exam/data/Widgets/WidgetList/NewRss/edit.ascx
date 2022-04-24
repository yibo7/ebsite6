<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.NewRss.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
rss源:<XS:TextBox ID="txtRssUrl" Width="380" runat="server"></XS:TextBox>
<br />
数据模板:

<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="bdec2947-cc6b-4e9a-abf2-56cb7d77387e" runat="server"/>
<br />
显示条数:<XS:TextBox ID="txtCount" Width="50" runat="server"></XS:TextBox>

