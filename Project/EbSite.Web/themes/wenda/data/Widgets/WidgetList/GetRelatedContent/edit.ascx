<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.GetRelatedContent.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

调用记录条数:<XS:TextBox ID="txtCount" Width="50" runat="server">10</XS:TextBox>
<br><br>
数据模板:
<XS:DDLCtrTem   ID="drpTem" runat="server"></XS:DDLCtrTem>
    <br />
  取前多少作为数据源:<XS:TextBox ID="txtLimit" Width="50" runat="server"></XS:TextBox> 0：EB_content 中所有数据。                      
<br/><br />
