<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassWord.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo.ChangePassWord" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <div class="box" style=" height:150px; width:300px; padding:30px;">
 
                        <table id="tbPass" runat="server" >
                         <tr>
                                <td>原密码:</td>
                                <td><XS:TextBoxVl ID="txtOldPass" runat="server" Width="200"  TextMode="Password" IsAllowNull="false" /></td>
                            </tr>
                            <tr>
                                <td>新密码:</td>
                                <td> <XS:TextBoxVl  ID="txtPassWord"  runat="server" Width="200" TextMode="Password"  IsAllowNull="false" /></td>
                            </tr>
                             <tr>
                                <td>确认密码:</td>
                                <td> <XS:TextBoxVl  ID="txtCfPassWord"  runat="server" Width="200" TextMode="Password" IsAllowNull="false" /></td>
                            </tr>
                        </table>
                         </div>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" width="120"  Text=" 保  存 " />
</div>