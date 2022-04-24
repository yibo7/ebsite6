<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.RelateContent.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

调用记录条数:<XS:TextBox ID="txtCount" Width="50" runat="server">10</XS:TextBox>
<br><br>
数据模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="71579f18-a40c-42fb-aa8c-73ee820ad3f3" runat="server"/>
<%--<XS:DDLCtrTem   ID="drpTem" runat="server"></XS:DDLCtrTem>--%>
    <br />
                                 
<br><br />
