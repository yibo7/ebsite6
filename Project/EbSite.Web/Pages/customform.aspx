<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="customform.aspx.cs" Inherits="EbSite.Web.Pages.customform" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:PlaceHolder ID="phFileds" runat="server">
    <div>
        <XS:ExtensionsCtrls ID="bbb" ModelCtrlID="8c6b7cb7-1fa2-496e-8ebe-8e9f5182680c" ShowName="公司人数  " runat="server"/> 
        <br><br>
        <XS:ExtensionsCtrls ID="aaa" ModelCtrlID="32088a7e-13c4-49da-af02-f18caf92b7ca" ShowName="公司名称  " runat="server"/> 
        
    </div>
    </asp:PlaceHolder>     <XS:Button  ID="btnSaveData" ValidationGroup="savedata"  Text="保存" runat="server" />
    </form>
</body>
</html>
