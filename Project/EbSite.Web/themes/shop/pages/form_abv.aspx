<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.customform" %>
	<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
	<%@ Import Namespace="EbSite.BLL.GetLink"%>
	<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
	<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
	</head>
	<body ><form id="form1" runat="server">
	<asp:PlaceHolder ID="phFileds" runat="server">
	内容<XS:ExtensionsCtrls ID="title" ModelCtrlID="32088a7e-13c4-49da-af02-f18caf92b7ca" ShowName="标题" runat="server"/>
    <XS:ExtensionsCtrls  ID="ct" ModelCtrlID="42be44b3-0062-470e-b341-0fc474ef221c" ShowName= "内容" runat="server"/>
	</asp:PlaceHolder>
	<XS:Button  ID="btnSaveData"   Text=" 提 交 " runat="server" />
	<%=KeepUserState()%>
	</form></body>
	</html>