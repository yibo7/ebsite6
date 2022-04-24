<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddClass.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.CreditProduct.AddClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls"
    TagPrefix="XE" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            分类名称：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtClassName" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            排序ID ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtOrderID" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>

<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
    <input type="button" class="AdminButton" value="返回" onclick="window.location = '/themes/shop/data/Modules/ModuleList/Shop/AdminPages/CreditProduct.aspx?muid=45c6da33-3516-46fe-a9c6-f8ddbbf0b5da&mid=cfccc599-4585-43ed-ba31-fdb50024714b'" />
</div>
