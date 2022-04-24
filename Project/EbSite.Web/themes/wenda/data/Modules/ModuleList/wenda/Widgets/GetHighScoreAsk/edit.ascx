<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Modules.BmAsk.Widgets.GetHighScoreAsk.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

获取条数:<XS:TextBox ID="txtTOP" runat="server"></XS:TextBox>  <br /><br />

标题列表自定义模板:
<XS:ExtensionsCtrls ID="drpTemTitle"   ModelCtrlID="e878b3c7-6edc-466a-95da-61cb910cec68" runat="server"/>
<br /><br />
<asp:CheckBox ID="cbIsImage" Text="是否图片内容" runat="server" /> 