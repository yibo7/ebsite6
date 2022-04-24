<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlaceSetting.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.HomeSet.PlaceSetting" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
<table class="link-addtd" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            站点名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="Title" HintInfo="此标题将显示在站点LOGO位置" IsAllowNull="false"  runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr> 
                    <tr>
                        <td>
                            个性域名:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="ReWriteName" HintInfo="如您在这里写上cqs,那将可以这样访问 http://域名/space/cqs"   runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>    
                    <tr>
                        <td>
                            站点皮肤:
                        </td>
                        <td>                        
                            <XS:DropDownList  ID="ThemeID" runat="server"  >
                            </XS:DropDownList>

                        </td>
                    </tr>               
                    <tr>
                        <td>
                            站点简介:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="Description" TextMode=MultiLine width="200" height="50"   runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>   
                </table>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>