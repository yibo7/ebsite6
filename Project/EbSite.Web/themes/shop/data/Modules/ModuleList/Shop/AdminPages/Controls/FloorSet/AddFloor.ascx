<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddFloor.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.FloorSet.AddFloor" %>
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
                   <%-- <tr>
                        <td height="25" width="30%" align="right">
                            图片
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                         <XS:SWFUpload Width="350" ID="FloorPic" OnUploadComplete="UploadComplete"  runat="server" IsMakeSmallImg="true"  AllowExt="jpg,gif,png" AllowSize="2024"  />

                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                           图片 超连接
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                           <XS:TextBoxVl ID="tbPicUrl" runat="server" Width="400px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                             上方 对应分类
                        </td>
                        <td  align="left">
                           <asp:ListBox ID="cblTopClass" Height="200" SelectionMode="Multiple"  runat="server"> </asp:ListBox>
                        </td>
                    
                        <td  >
                            右侧 对应分类
                        </td>
                        <td align="left">
                            <asp:ListBox ID="cblRightClass" Height="200" SelectionMode="Multiple"  runat="server"> </asp:ListBox>
                        </td>
                    </tr>
                     <tr>
                        <td height="25" width="30%" align="right" >
                            对应产品
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <XE:BatchProduct runat="server"   ID="FloorParts" OpTools="推荐配件"></XE:BatchProduct> 
                        </td>
                    </tr>--%>
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>

<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
</div>
<script>
    //自动放大
    $(window.parent.document.body).find("div[class='panel-tool-max']").click();
</script>
