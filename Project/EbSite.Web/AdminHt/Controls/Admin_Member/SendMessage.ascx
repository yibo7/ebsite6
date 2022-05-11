<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendMessage.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.SendMessage" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    td{ padding: 5px;}
</style>
 
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>给用户发送手机短信</h3>
            请确保您已经安装手机短信发送插件，建议安装官方手机短信发送插件
            </div>
            <div class="eb-content">
				<table class="TableList">
                <tr>
                    <td>
                        <%=Resources.lang.EBMailObject %>：
                    </td>
                    <td>
                        <XS:RadioButtonList ID="rdoSendTo" runat="server"  RepeatColumns="3" AutoPostBack="true"
                            onselectedindexchanged="rdoSendTo_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0" Text="<%$Resources:lang,EBUNameList %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$Resources:lang,EBUserGroup %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="手机号列表"></asp:ListItem>
                        </XS:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td> 
                        <asp:Literal ID="llReceiver" runat="server" Text="接收对象"></asp:Literal>：
                    </td>
                    <td >                        
                        <XS:CheckBoxList Width="" HintInfo="将向所选用户组里的用户发送手机短信" ID="cbReceiverGroupList" runat="server">
                        </XS:CheckBoxList>
                        <XS:TextBoxVl ID="txtReceiverUserList" IsAllowNull="false" HintInfo="一行一个" TextMode="MultiLine" Width="300" Height="100" runat="server"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        短信内容：
                    </td>
                    <td>
                        <XS:TextBoxVl   ID="txtMsg" IsAllowNull="false" Width="350" TextMode="MultiLine" Height="100" runat="server"></XS:TextBoxVl>
                    </td>
                </tr>
               
                <tr>
                    <td colspan="2" style="text-align: center">
                        <XS:Button ID="btnSend" runat="server" Text="发送手机短信" onclick="btnSend_Click" />
                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>