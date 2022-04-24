<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OptimalAdd.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.RelatedProduct.OptimalAdd" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls"
    TagPrefix="XE" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加最佳组合</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            产品 ID：：
                        </td>
                        <td height="25" width="*" align="left">
                            <XE:SelectProduct Width="300" ID="ProductIDX" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            关联赠品产品ID ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XE:BatchProduct runat="server" ID="BestParts" OpTools="最佳组合"></XE:BatchProduct>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
</div>
