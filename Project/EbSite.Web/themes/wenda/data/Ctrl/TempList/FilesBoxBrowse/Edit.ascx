<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.FilesBoxBrowse.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

允许查看上传的文件类型:
<XS:TextBox ID="txtAllowType" Width="100" runat="server"></XS:TextBox>
用逗号分开如: .bmp,.jpge,.jpg,.rar
<br><br>
允许上传的文件的大小:
<XS:TextBox ID="txtAllowSize" Width="50" runat="server"></XS:TextBox>KB<br>
文本框的高:
<XS:TextBox ID="txtHeight" Width="50" runat="server"></XS:TextBox><br><br>
文本框的宽:
<XS:TextBox ID="txtWidth" Width="50" runat="server"></XS:TextBox><br><br>
