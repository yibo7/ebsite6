<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendEmail.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.SendEmail" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    td{ padding: 5px;}
</style>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>批量邮件发送</h3>
            请确保您已经安装邮件发送插件，建议安装官方邮件发送插件
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
                            <asp:ListItem Value="2" Text="<%$Resources:lang,EBEmailList %>"></asp:ListItem>
                        </XS:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td> 
                        <asp:Literal ID="llReceiver" runat="server" Text="<%$Resources:lang,EBRcvEmailUname %>"></asp:Literal>：
                    </td>
                    <td >                        
                        <XS:CheckBoxList Width="" HintInfo="将向所选用户组里的用户发送邮件" ID="cbReceiverGroupList" runat="server">
                        </XS:CheckBoxList>
                        <XS:TextBox ID="txtReceiverUserList" HintInfo="列表用逗号分开" TextMode="MultiLine" Width="300" Height="100" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBMailTitle %>：
                    </td>
                    <td>
                        <XS:TextBox ID="txtEmailTitle" Width="300" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBMailContent %>：
                    </td>
                    <td style="width:500px;height:300px;">
                        <XS:Editor ID="ebMailContent"  runat="server" />
                    </td>
                </tr>
               
                <tr>
                    <td colspan="2" style="text-align: center">
                        <XS:Button ID="btnSend" runat="server" Text="<%$Resources:lang,EBSendMail %>" onclick="btnSend_Click" />
                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>