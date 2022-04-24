<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemesClassAdd.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.ThemesClassAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
   <div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>添加/修改分类</b></h4>
            <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            分类:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="classname" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            应用到用户组:
                        </td>
                        <td>                        
                            <XS:DropDownList ID="UserGroupID" runat="server">
                            </XS:DropDownList>
                        </td>
                    </tr>  
                </table>
        </div>
    </div>
</div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>