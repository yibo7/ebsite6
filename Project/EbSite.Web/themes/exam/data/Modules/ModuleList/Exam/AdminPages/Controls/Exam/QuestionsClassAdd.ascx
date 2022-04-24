<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionsClassAdd.ascx.cs" Inherits="EbSite.Modules.Exam.AdminPages.Controls.Exam.QuestionsClassAdd" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <asp:PlaceHolder ID="phCtrList" runat="server">
   <div class="admin_toobar">
   <fieldset>
        <legend>添加分类</legend>
        <div style=" padding-left:10px;">
   
    <table>       
     
                   
                 
     
             <tr>    
                <td>
                    所属试卷：            
                </td>
                <td>
                    <asp:Label ID="lbInation" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>      
           <tr>
                <td>                    
                    分类名称：               
                </td>                
                <td>
                    <XS:TextBoxVL ID="ClassName"   IsAllowNull="false" runat="server" Width="242px"></XS:TextBoxVL>
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