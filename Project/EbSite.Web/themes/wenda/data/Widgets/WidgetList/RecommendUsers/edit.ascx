<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.RecommendUsers.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
选取推荐用户:<XSD:SelectUser Width="300" ID="txtUserInfo2"   Height="100"   SelectType="多选"  runat="server"  />

<br /><br />
调用记录条数:<XS:TextBox ID="txtCount" Width="50" runat="server">10</XS:TextBox>
<br><br>
数据模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="9552eabc-b186-432f-8384-f8266d986eef" runat="server"/>
                                    
<br><br>


