<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.ModelListBox.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
选择模型类别:<br>
<asp:RadioButtonList ID="rbList" runat="server">
    <asp:ListItem Text="分类模型" Value="0"></asp:ListItem>
    <asp:ListItem Text="内容模型" Value="1"></asp:ListItem>
    <asp:ListItem Text="用户模型" Value="2"></asp:ListItem>
</asp:RadioButtonList>

在分类前插入自定义选项:<br>

<XS:TextBox ID="txtCustomItems" Width="200" runat="server"></XS:TextBox>
(格式为 选项名称1,选项值1|选项名称2,选项值2)
<br />