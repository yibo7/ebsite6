<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.Upload.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

允许上传的文件类型:
<XS:TextBox ID="txtAllowType" Width="100" runat="server"></XS:TextBox>
用逗号分开如:  bmp,jpge,jpg,rar
<br><br>
允许上传的文件的大小:
<XS:TextBox ID="txtAllowSize" Width="50" runat="server"></XS:TextBox>KB<br>
文本框的高:
<XS:TextBox ID="txtHeight" Width="50" runat="server"></XS:TextBox><br><br>
文本框的宽:
<XS:TextBox ID="txtWidth" Width="50" runat="server"></XS:TextBox><br><br>
文件保存路径:
<XS:TextBox ID="txtSaveFolder" HintInfo="要保存的文件夹,可以为空（保存到系统默认目录），如果文件夹名称前加上 /，表示不使用系统默认根目录保存路径" Width="100" runat="server"></XS:TextBox><br><br>

上传组件:<asp:DropDownList ID="drpUploadModel" runat="server">
            <asp:ListItem Text="SWFUpload组件" Value="1"></asp:ListItem>
             <asp:ListItem Text="Net默认组件" Value="2"></asp:ListItem>
        </asp:DropDownList><br><br>
选择提示:
<XS:TextBox ID="txtExtDes" HintInfo="只有对SWFUpload组件时有效,如 请选择图片，请选择mp3等" Width="100" runat="server">选择文件</XS:TextBox><br><br>