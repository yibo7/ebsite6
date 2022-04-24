<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddMFloor.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.FloorSet.AddMFloor" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls"
    TagPrefix="XE" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加/修改 楼层信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="35" width="30%" align="right">
                            名称：
                        </td>
                        <td height="35" width="*" align="left" colspan="3">
                           <XS:TextBoxVl ID="tbFloorName" runat="server" IsAllowNull="False" Width="200px"></XS:TextBoxVl>
                           </td>
                    </tr>
                    <tr>
                        <td height="35" width="30%" align="right">
                            楼层链接：
                        </td>
                        <td height="35" width="*" align="left" colspan="3">
                           <XS:TextBoxVl ID="txtFloorLink" runat="server" IsAllowNull="False" Width="200px"></XS:TextBoxVl>
                           </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                           楼层颜色
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                           <XS:ColorPicker ID="ShowColor"  runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                           楼层ID：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <XS:TextBoxVl ID="tbFloorID" runat="server"  ValidateType="整数" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                   <tr>
                        <td height="25" width="30%" align="right">
                           广告标题
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                           <XS:TextBoxVl ID="txtTitle" runat="server" Width="400px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                           广告超连接
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                           <XS:TextBoxVl ID="tbPicUrl" runat="server" Width="400px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            广告图片
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                         <XS:SWFUpload Width="350" ID="FloorPic" OnUploadComplete="UploadComplete" SaveFolder="/themes/shop/data/Upload" runat="server" IsMakeSmallImg="true"  AllowExt="jpg,gif,png" AllowSize="2024"  />

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
