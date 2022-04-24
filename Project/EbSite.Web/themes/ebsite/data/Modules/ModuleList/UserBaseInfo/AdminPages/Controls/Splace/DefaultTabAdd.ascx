<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultTabAdd.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.DefaultTabAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
   <div class="row m-t-15">
    <div class="col-sm-12">
        <div class="card-box">
           <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            标签名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="TabName" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                  
                    <tr>
                        <td>
                            页面版式:
                        </td>
                        <td>                        
                            <XS:DropDownList ID="Layout" runat="server">
                            </XS:DropDownList>
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
                    <tr>
                        <td>
                            排序ID:
                        </td>
                        <td>                        
                           <XS:TextBoxVl ID="OrderNum" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
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
