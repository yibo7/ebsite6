<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassAdd.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Favorite.ClassAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <table class="link-addtd" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                分类名称:
            </td>
            <td>
                <XS:TextBoxVl ID="ClassName" IsAllowNull="false" runat="server">
                </XS:TextBoxVl>
            </td>
        </tr>
    </table>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
</div>
