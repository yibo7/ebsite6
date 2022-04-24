<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.HtmlBox.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
编辑器的类型:
<XS:DropDownList ID="drpBoxType" runat="server">
    <asp:ListItem Value="1" Text="简单编辑器"></asp:ListItem>
    <asp:ListItem Value="2" Text="标准编辑器"></asp:ListItem>
    <asp:ListItem Value="3" Text="高级编辑器"></asp:ListItem>
</XS:DropDownList><br><br>


是否开启UBB:
<asp:CheckBox ID="cbUbb" runat="server" /><br><br>
编辑器的高:
<XS:TextBox ID="txtHeight" Width="50" runat="server"></XS:TextBox><br><br>
编辑器的宽:
<XS:TextBox ID="txtWidth" Width="50" runat="server"></XS:TextBox><br><br>
是否下载站外文件:
<asp:CheckBox ID="cbDownfile" runat="server" /><br><br>

下载图片是否加水印:<asp:CheckBox ID="cbPicAddMak" runat="server" /><br><br>
文件保存路径:
<XS:TextBox ID="txtSaveFolder" HintInfo="要保存的文件夹,可以为空（保存到系统默认目录），如果文件夹名称前加上 /，表示不使用系统默认根目录保存路径" Width="100" runat="server"></XS:TextBox><br><br>
最大文件上传大小:
<XS:TextBox ID="txtSize" HintInfo="超过此大小的文件将不允许上传" Width="30" runat="server">10</XS:TextBox>KB<br><br>
允许上传文件的后缀:
<XS:TextBox ID="txtExtLink" HintInfo="文件上传后自动加入连接，如果不设置后缀，将默认不可以上传文件" Width="180" runat="server"></XS:TextBox><br><br>
允许上传图片的后缀:
<XS:TextBox ID="txtExtImg" HintInfo="图片上传后自动加入img标签来默示图片，如果不设置后缀，将默认不可以上传图片" Width="180" runat="server"></XS:TextBox><br><br>
允许上传视频的后缀:
<XS:TextBox ID="txtExtMedia" HintInfo="文件上传后自动加入视频标签来播放视频，如果不设置后缀，将默认不可以上传视频" Width="180" runat="server"></XS:TextBox><br><br>
允许上传flash的后缀:
<XS:TextBox ID="txtExtFlash" HintInfo="文件上传后自动加入flash播放标签，如果不设置后缀，将默认不可以上传flash" Width="180" runat="server"></XS:TextBox><br><br>
<XS:Notes Text="如果不设置上传文件的后缀，将默认的不允许上传，后缀的格式用逗号分开，如 rar,txt,png"  runat="server"></XS:Notes>