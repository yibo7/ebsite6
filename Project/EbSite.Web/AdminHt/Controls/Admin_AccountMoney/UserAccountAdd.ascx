<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAccountAdd.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_AccountMoney.UserAccountAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>后台加款操作</h3>
            </div>
            <div class="eb-content">
				<table>
                    <tr>
                        <td colspan="3">
                            <span style="font-size: 14px; font-weight: bold">给“<asp:Label ID="lbUName" runat="server"
                                Text="Label"></asp:Label>”账户加款 </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            可用余额:
                        </td>
                        <td>
                            <asp:Label ID="lbUserMoney" runat="server" Text="Label"></asp:Label>元
                        </td>
                    </tr>
                    <tr>
                        <td>
                            类别:
                        </td>
                        <td>
                            <asp:DropDownList ID="dropDB" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            加款金额:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtAddMoney" IsAllowNull="False"  ValidateType="金额"  runat="server"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            备注:
                        </td>
                        <td>
                            <XS:TextBox TextMode="MultiLine" Width="300" Height="80" ID="Demo" runat="server"></XS:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
    </div>
</div>
 
</asp:PlaceHolder>
<div style="display: none">
<XS:Button ID="bntSave" runat="server" Text=" 保存 " ValidationGroup="BB" />
    </div>
<script>
    function SaveFrame() {
        $("#<%=bntSave.ClientID%>").click();
    }
</script>
