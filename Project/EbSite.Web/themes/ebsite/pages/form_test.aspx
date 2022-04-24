<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.customform" %>
	<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
	<%@ Import Namespace="EbSite.BLL.GetLink"%>
	<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
	<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
	</head>
	<body ><form id="form1" runat="server">
		<br><br>
<asp:PlaceHolder ID="phFileds" runat="server">
	<XS:ExtensionsCtrls ID="uname" ModelCtrlID="ead114fc-9c70-4837-be41-cbc294ec5ecb" ShowName="姓名" runat="server"/> 
<br><br>
	<XS:ExtensionsCtrls ID="sex" ModelCtrlID="5e4977f6-d14e-4b54-acdd-03c58428423f" ShowName="性别" runat="server"/> 
<br>
	<XS:ExtensionsCtrls ID="ucount" ModelCtrlID="8c6b7cb7-1fa2-496e-8ebe-8e9f5182680c" ShowName="公司人数" runat="server"/> 
	<br><br>
	<XS:ExtensionsCtrls  ID="ctent" ModelCtrlID="d5ff6180-0bb8-4665-99e1-83df57760746" ShowName= "简介" runat="server"/>
<XS:ExtensionsCtrls ID="cpinfo" ModelCtrlID="d5ff6180-0bb8-4665-99e1-83df57760746" ShowName="公司简介" runat="server"/> 	<br><br>
	</asp:PlaceHolder>
	<XS:Button  ID="btnSaveData"   Text=" 提 交 " runat="server" />
	<%=KeepUserState()%>
	</form></body>
	</html>