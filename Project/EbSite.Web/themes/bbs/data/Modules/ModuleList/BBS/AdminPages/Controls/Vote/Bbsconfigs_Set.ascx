<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Bbsconfigs_Set.ascx.cs"
    Inherits="EbSite.Modules.BBS.AdminPages.Controls.Vote.Bbsconfigs_Set" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div>
    <table>
        <tr>
            <td>
                投票:
            </td>
            <td>
                <XS:RadioButtonList ID="rblTP" runat="server">
                    <asp:ListItem Text="关闭" Value="close">       
                    </asp:ListItem>
                    <asp:ListItem Text="开启" Value="open">       
                    </asp:ListItem>
                </XS:RadioButtonList>
            </td>
        </tr>
    </table>
</div>
<div style="text-align: center">
    <XS:Button ID="btnBC" runat="server" Text=" 保 存 " OnClick="btnBC_Click"/>   
</div>
