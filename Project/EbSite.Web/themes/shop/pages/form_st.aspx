<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.customform" %>
	<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
	<%@ Import Namespace="EbSite.BLL.GetLink"%>
	<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
	<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
	</head>
	<body ><form id="form1" runat="server">
	<asp:PlaceHolder ID="phFileds" runat="server">
	内容<XS:ExtensionsCtrls  ID="name" ModelCtrlID="ead114fc-9c70-4837-be41-cbc294ec5ecb" ShowName= "住址" runat="server"/>
                         <XS:ExtensionsCtrls  ID="area" ModelCtrlID="ead114fc-9c70-4837-be41-cbc294ec5ecb" ShowName= "领域" runat="server"/>

	</asp:PlaceHolder>
	<XS:Button  ID="btnSaveData"   Text=" 提 交 " runat="server" />
	<%=KeepUserState()%>
	</form></body>
	</html>