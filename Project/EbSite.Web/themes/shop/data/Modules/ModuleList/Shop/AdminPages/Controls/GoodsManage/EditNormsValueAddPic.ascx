<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditNormsValueAddPic.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.GoodsManage.EditNormsValueAddPic" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
  <table>
        <tr>
            <td>
                图片地址：
            </td>
            <td>
                <XS:SWFUpload ID="fileUpLoad" SaveFolder="/themes/shop/data/Upload"  AllowExt ="jpg,gif,png" runat="server" /> 55*55
               
            </td>
        </tr>
        <tr>
            <td>
                图片描述：
            </td>
            <td>
                <XS:TextBox Width="200" runat="server"  ID="NormsValueName"> </XS:TextBox>
               
            </td>
        </tr>
       
    </table>
</asp:PlaceHolder>
<div style="text-align: center; padding: 10px;">
    <XS:Button ID="bntSave" Text=" 添 加" runat="server" ValidationGroup="savedata" />
</div>