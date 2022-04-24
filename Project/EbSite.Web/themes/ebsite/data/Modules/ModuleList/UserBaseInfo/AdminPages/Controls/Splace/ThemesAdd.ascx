<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemesAdd.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.ThemesAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
  <div class="row m-t-15">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>添加/修改皮肤</b></h4>
            <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            皮肤名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="ThemeName" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            皮肤英文名:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="ThemePath" runat="server"    IsAllowNull="false"  ValidateType="匹配由数字和26个英文字母组成的字符串"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <div id="DivCopy" runat="server">
                    <tr >
                        <td>
                            复制皮肤模板:
                        </td>
                        <td>                        
                            <XS:DropDownList ID="CopyThemeID" runat="server">
                            </XS:DropDownList>
                        </td>
                    </tr>  
                    </div>
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
                            皮肤作者:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="Author" runat="server"     ></XS:TextBoxVl>
                        </td>
                    </tr>
                   <%-- <tr>
                        <td>
                            适用用户组:
                        </td>
                        <td>                        
                            <XS:DropDownList ID="UserGroupID" runat="server">
                            </XS:DropDownList>
                        </td>
                    </tr>  --%>
                    
                </table>
        </div>
    </div>
</div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>
