<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PluginsAdd.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.Plugins.PluginsAdd" %>
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
                            插件名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="PluginTitle" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            插件扩展Url:
                        </td>
                        <td>                        
                            <XS:TextBoxVl ID="Url"    IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            简介:
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
