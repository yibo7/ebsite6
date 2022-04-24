<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImitatePostUserAdd.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.ImitatePost.ImitatePostUserAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加/修改</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            选择真实发帖人:
                        </td>
                        <td>
                             <XSD:SelectUser Width="300" ID="suMainUser" runat="server"  />
                        </td>
                  
                    <tr>
                        <td>
                            选择模拟发帖人:
                        </td>
                        <td>                        
                            <XSD:SelectUser Width="300" ID="suImitateUser" Height="100" SelectType="多选" runat="server"  />
                        </td>
                    </tr>  
                    </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>
