<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.UserLevel.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<table>
    <tr>
        <th>数据源:</th>
        <td align="left">
            <asp:DropDownList ID="drpDataSource" runat="server">
                <asp:ListItem Text="会员组" Value="0"></asp:ListItem>
                <asp:ListItem Text="会员级别" Value="1"></asp:ListItem>
                <asp:ListItem Text="管理员角色" Value="2"></asp:ListItem>
            </asp:DropDownList>
       </td>
    </tr>
    <tr>
        <th>显示模式：</th>
        <td align="left">
            <asp:RadioButtonList ID="rdoModelList" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="单选" Value="0"></asp:ListItem>
                <asp:ListItem Text="多选" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <th>是否强制选择项：</th><td align="left"><asp:CheckBox ID="chkIsMastItem" runat="server" /></td>
    </tr>
</table>