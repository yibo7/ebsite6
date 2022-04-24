<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BBS_hf.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.BBS.BBS_hf" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">         
                <table cellpadding="0" cellspacing="0">    
                <tr>               
                        <td style="width:600px;height:300px">                         
                           <XS:Editor ID="ebReplyContent" runat="server"  EditorTools="全功能模式" ExtImg="jpg,JPG,png,PNG,gif,GIF" Width="600" Height="300"/>
                        </td>
                    </tr>                    
                </table>          
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保 存 " />
    <XS:Button ID="btnColseGreyBox" runat="server" Text=" 取 消 "/>
</div>

