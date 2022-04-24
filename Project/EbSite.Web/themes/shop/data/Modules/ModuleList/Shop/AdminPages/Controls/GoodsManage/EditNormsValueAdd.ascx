<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditNormsValueAdd.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.GoodsManage.EditNormsValueAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
 <table>
        <tr>
            <td>
                规格值名：
            </td>
            <td>
                <XS:TextBox Width="200" runat="server" onkeydown="javascript:this.value=this.value.replace('，',',')"
                    ToolTip="多个规格值可用“,”号隔开，每个值的字符数最多15个字符。" ID="NormsValueName">
                </XS:TextBox>
               
            </td>
        </tr>
       
    </table>
</asp:PlaceHolder>
<div style="text-align: center; padding: 10px;">
    <XS:Button ID="bntSave" Text=" 提交 " runat="server" ValidationGroup="savedata" />
</div>