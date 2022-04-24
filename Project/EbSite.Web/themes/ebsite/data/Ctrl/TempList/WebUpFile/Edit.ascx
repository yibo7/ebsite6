<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.WebUpFile.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

允许上传的文件类型:
<XS:TextBox ID="txtAllowType" Width="300" CtrValue="rar,zip" runat="server"></XS:TextBox>
用逗号分开如: rar,zip,mp3,mp4
<br><br>
允许上传的文件的大小:
<XS:TextBox ID="txtAllowSize" Width="100" runat="server"></XS:TextBox>KB<br> 
文件保存路径:
<XS:TextBox ID="txtSaveFolder" HintInfo="要保存的文件夹,可以为空（默认目录files）" Width="200" runat="server"></XS:TextBox><br><br>
上传组件:<asp:DropDownList ID="drpUploadModel" runat="server">
            <asp:ListItem Text="单文件上传" Value="1"></asp:ListItem>
             <asp:ListItem Text="多文件上传" Value="2"></asp:ListItem>
        </asp:DropDownList><br><br> 