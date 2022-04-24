<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Vote.ItemAdd" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <asp:PlaceHolder ID="phCtrList" runat="server">
   <div class="admin_toobar">
   <fieldset>
        <legend>添加投票</legend>
        <div style=" padding-left:10px;">
   
    <table>       
     
                   
           <tr>
                <td>                    
                    选项名称：               
                </td>                
                <td>
                    <XS:TextBoxVL ID="ItemName"   IsAllowNull="false" runat="server" Width="242px"></XS:TextBoxVL>
                </td>
               
            </tr>
           <tr>
               
                <td colspan="2" style="text-align: center">

                        <XS:Button ID="bntSave" runat="server" Text=" 提 交 数 据 "  />
                </td>
           </tr>
    </table>
    </div>
    </fieldset>
</div>
</asp:PlaceHolder>