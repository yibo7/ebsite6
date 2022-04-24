<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MSetAdvLink.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.FloorSet.MSetAdvLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls" TagPrefix="XE" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加/修改 楼层信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="35" width="30%" align="right">
                            广告标题：
                        </td>
                        <td height="35" width="*" align="left" colspan="3">
                           <XS:TextBoxVl ID="txtClassName" runat="server" IsAllowNull="False" Width="200px"></XS:TextBoxVl>
                           </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                           连接地址：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                           <XS:TextBoxVl ID="txtURL" runat="server" IsAllowNull="False" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>

<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " /> <a href="/themes/shop/data/Modules/ModuleList/Shop/AdminPages/FloorSet.aspx?muid=86d17e6e-af5f-4111-a6a7-8ed8f445ebdd&mid=cfccc599-4585-43ed-ba31-fdb50024714b&id=<%=fid %>">返回</a>
</div>

