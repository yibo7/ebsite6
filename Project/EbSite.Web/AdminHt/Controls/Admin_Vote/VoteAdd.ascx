<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VoteAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Vote.VoteAdd" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <asp:PlaceHolder ID="phCtrList" runat="server">
   <div class="admin_toobar">
   <fieldset>
        <legend>添加投票</legend>
        <div style=" padding-left:10px;">
   
    <table>       
     
                   
           <tr>
                <td>                    
                    投票名称：               
                </td>                
                <td>
                    <XS:TextBoxVL ID="VoteName"   IsAllowNull="false" runat="server" Width="242px"></XS:TextBoxVL>
                </td>
               
            </tr>
            <tr>    
                <td>
                    选择模式：            
                </td>
                <td>
                    <XS:DropDownList ID="IsMoreSel"   HintInfo="前台投票时用户的选择模式"   runat="server">
                        <asp:ListItem Text="单选模式"  Value="False"/>
                        <asp:ListItem Text="多选模式"  Value="True"/>
                    </XS:DropDownList>
                </td>
            </tr>
            <tr>    
                <td>
                    展示颜色：            
                </td>
                <td>
                    <XS:DropDownList ID="IsItemColorRan"   HintInfo="前台选项的颜色"   runat="server">
                        <asp:ListItem Text="单色"  Value="False"/>
                        <asp:ListItem Text="随机颜色"  Value="True"/>
                    </XS:DropDownList>
                </td>
            </tr>
            <tr>
                <td>                    
                    最多可选项数目：               
                </td>                
                <td>
                    <XS:TextBoxVL ID="AllowMaxSel" HintInfo="只有多选模式时才起作用"    IsAllowNull="false" runat="server" Width="20">2</XS:TextBoxVL>
                </td>
            </tr>
             <tr>
                <td>                    
                    结束时间：               
                </td>                
                <td>
                    <XS:DatePicker ID="EndDate" TimeModel="数字模式" runat="server"  ></XS:DatePicker>
                </td>
            </tr>
            <tr>    
                <td>
                    投票说明：            
                </td>
                <td>
                    <XS:Editor ID="VoteInfo"    runat="server"  Height="200" Width="500"></XS:Editor>
                    
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