<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IpRandom.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.ImitatePost.IpRandom" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            ip范围 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtIP"   TextMode="MultiLine" height="300" width="300" IsAllowNull="false" runat="server"  onkeydown="javascript:this.value=this.value.replace('，',',')"
                    ToolTip="IP 范围，用逗号分开。" >
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                 
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
</div>


