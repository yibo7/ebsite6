<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PayPass.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.AccountMoney.PayPass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    tr
    {
        height: 40px;
    }
</style>
<div style="padding-bottom: 20px; background-color: #f0f0f0; margin-top: 4px; padding-left: 20px;
    padding-right: 20px; padding-top: 20px">
    <div style="border-bottom: #d2d2d2 1px solid; border-left: #d2d2d2 1px solid; padding-bottom: 6px;
        background-color: #ffffff; padding-left: 6px; padding-right: 6px; border-top: #d2d2d2 1px solid;
        border-right: #d2d2d2 1px solid; padding-top: 6px; text-align: left;">
        <table id="tbPass" runat="server">
            <tr>
                <td>
                    原密码:
                </td>
                <td>
                    <XS:TextBoxVl ID="txtOldPass" runat="server" Width="200" TextMode="Password" IsAllowNull="false" />
                </td>
            </tr>
            <tr>
                <td>
                    新密码:
                </td>
                <td>
                    <XS:TextBoxVl ID="txtPassWord" runat="server" Width="200" TextMode="Password" IsAllowNull="false" />
                </td>
            </tr>
            <tr>
                <td>
                    确认密码:
                </td>
                <td>
                    <XS:TextBoxVl ID="txtCfPassWord" runat="server" Width="200" TextMode="Password" IsAllowNull="false" />
                </td>
            </tr>
        </table>
        <div style="text-align: center">
            <XS:Button ID="bntSave" runat="server" width="120" Text=" 保  存 " />
        </div>
    </div>
</div>
