<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.Setting" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="XSD" Namespace="EbSite.ControlData" Assembly="EbSite.ControlData"%>
<div class="tab-pane" id="tg1">
    <table>
        <tr>
            <td>
                收藏夹名称:
            </td>
            <td>
                <XS:TextBoxVL ID="txtFavoriteName" IsAllowNull="false" runat="server" Width="242px">
                </XS:TextBoxVL>
            </td>
        </tr>
    </table>
</div>
<div class="tab-pane" id="tg2">
    <table>
        <tr>
            <td>
                允许开通个人空间的用户级别:
            </td>
            <td>
                <XSD:UsreLevelListItem   ID="drpAllowOpenSiteGroup" runat="server">
                </XSD:UsreLevelListItem>
            </td>
        </tr>
        <tr>
            <td>
                可以使用个性域名的用户级别:
            </td>
            <td>
                <XSD:UsreLevelListItem  ID="drpUseMyDemainGroup" runat="server">
                </XSD:UsreLevelListItem>
            </td>
        </tr>
        <tr>
            <td>
                允许操作默认空间菜单的用户级别:
            </td>
            <td>
                <XSD:UsreLevelListItem  HintInfo="有时候默认设置的空间菜单可能不允许用户删除或修改，可以在这里设置权限" ID="drpAllowModifyDefaultTabGroup"
                    runat="server">
                </XSD:UsreLevelListItem>
            </td>
        </tr>
        <tr>
            <td>
                允许修改空间菜单的用户级别:
            </td>
            <td>
                <XSD:UsreLevelListItem  HintInfo="这里指的是除默认菜单以外的修改权限" ID="drpAllowModifyTabGroup" runat="server">
                </XSD:UsreLevelListItem>
            </td>
        </tr>
        <tr>
            <td>
                允许添加空间菜单的用户级别:
            </td>
            <td>
                <XSD:UsreLevelListItem  HintInfo="添加菜单，包括子菜单的添加权限" ID="drpAllowAddTabGroup" runat="server">
                </XSD:UsreLevelListItem>
            </td>
        </tr>
        <tr>
            <td>
                允许排序空间菜单的用户级别:
            </td>
            <td>
                <XSD:UsreLevelListItem  HintInfo="空间菜单是否可以让前台用户来排序" ID="drpAllowOrderTabGroup" runat="server">
                </XSD:UsreLevelListItem>
            </td>
        </tr>
        <tr>
            <td>
                允许更换皮肤的用户级别:
            </td>
            <td>
                <XSD:UsreLevelListItem  HintInfo="是否允许前台用户切换皮肤" ID="drpUseThemeGroup" runat="server">
                </XSD:UsreLevelListItem>
            </td>
        </tr>
        <tr>
            <td>
                允许更换版式的用户级别:
            </td>
            <td>
                <XSD:UsreLevelListItem  ID="drpUseLayout" runat="server">
                </XSD:UsreLevelListItem>
            </td>
        </tr>
        <tr>
            <td>
                允许更换部件的用户级别:
            </td>
            <td>
                <XSD:UsreLevelListItem  HintInfo="与皮肤一样，这里是一个全局设置，每个皮肤在添加的时候也可指定对应的用户组" ID="drpUseWidgets"
                    runat="server">
                </XSD:UsreLevelListItem>
            </td>
        </tr>
    </table>
</div>
