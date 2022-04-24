<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserArchives.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo.UserArchives" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="User-Profiles">
         <table>
           <tr>
                        <td>
                            登录帐号:
                        </td>
                        <td>
                           <asp:literal id="ltUserName" runat="server"></asp:literal>
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            最后访问时间:
                        </td>
                        <td>
                           <asp:literal id="ltLastLogin" runat="server"></asp:literal>
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            电子邮箱:
                        </td>
                        <td>
                           <asp:textbox id="txtEmail" runat="server"></asp:textbox>
                        </td>                        
                    </tr>
                    
    </table>
    
            <table>        
                <asp:placeholder id="phDefaultFileds" runat="server"></asp:placeholder>
            </table>

     <div style=" margin-top:10px; margin-bottom:20px; padding-left:150px;">
         <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
     </div>
     </div>