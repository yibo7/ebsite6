<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ServiceClassAdd.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.Service.ServiceClassAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加/修改信息</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            类别名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="Title" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            类别描述:
                        </td>
                        <td>                        
                            <asp:TextBox TextMode="MultiLine" Height="100" Width="300" ID="Info" runat="server"  />
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
