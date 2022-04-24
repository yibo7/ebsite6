<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.UploadImg.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

允许上传的文件类型:
<XS:TextBox ID="txtAllowType" Width="300" CtrValue="jpg,jpeg,png,gif" runat="server"></XS:TextBox>
用逗号分开如: jpg,jpeg,png,gif
<br><br>
允许上传的文件的大小:
<XS:TextBox ID="txtAllowSize" Width="100" runat="server"></XS:TextBox>KB<br>
缩略图高:
<XS:TextBox ID="txtHeight" Width="100" runat="server"></XS:TextBox><br><br>
缩略图的宽:
<XS:TextBox ID="txtWidth" Width="100" runat="server"></XS:TextBox><br><br> 
文件保存路径:
<XS:TextBox ID="txtSaveFolder" HintInfo="要保存的文件夹,可以为空（默认目录imgs）" Width="200" runat="server"></XS:TextBox><br><br>
上传组件:<asp:DropDownList ID="drpUploadModel" runat="server">
            <asp:ListItem Text="单个图片" Value="1"></asp:ListItem>
             <asp:ListItem Text="多个图片" Value="2"></asp:ListItem>
        </asp:DropDownList><br><br> 