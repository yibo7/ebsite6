<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAttributeValuesAdd.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.GoodsManage.EditAttributeValuesAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div id="tg1">
        <table>
            <tr>
                <td>
                    属性值:
                </td>
                <td>
                    <XS:TextBox Width="150" runat="server" ID="TValues" IsAllowNull="false" HintInfo="长度限制在1-30个字符之间">
                    </XS:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:PlaceHolder>
<div style="text-align: center; padding: 10px;">
    <XS:Button ID="bntSave" Text=" 添 加" runat="server"  />
</div>
