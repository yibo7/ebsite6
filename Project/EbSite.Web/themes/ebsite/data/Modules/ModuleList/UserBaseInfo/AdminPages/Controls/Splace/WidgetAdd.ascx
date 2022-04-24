<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetAdd.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.WidgetAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
   <div class="row m-t-15">
    <div class="col-sm-12">
        <div class="card-box">
          <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            部件名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="WidgetName" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            选择部件:
                        </td>
                        <td>
                            <XS:DropDownList ID="txtID" runat="server"></XS:DropDownList>
                        </td>
                    </tr>
                   <%-- <tr>
                        <td>
                            应用到用户组:
                        </td>
                        <td>                        
                            <XS:DropDownList ID="UserGroupID" runat="server">
                            </XS:DropDownList>
                        </td>
                    </tr>  --%>
                     <tr>
                        <td>
                            皮肤分类:
                        </td>
                        <td>                        
                            <XS:DropDownList ID="ThemeClassID" runat="server">
                            </XS:DropDownList>
                        </td>
                    </tr>      
                     <tr>
                        <td>
                            上传部件图片:
                        </td>
                         <td>
                        <XS:SWFUpload  SaveFolder="upImgUrl" HintInfo="此图片将显示在用户前台" ID="ImgUrl" AllowSize="10024" AllowExt="jpg,png,gif" runat="server"></XS:SWFUpload>
                    </td>
                    </tr>  
                </table>
        </div>
    </div>
</div>
</asp:PlaceHolder>
<div style="text-align: center;">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>
