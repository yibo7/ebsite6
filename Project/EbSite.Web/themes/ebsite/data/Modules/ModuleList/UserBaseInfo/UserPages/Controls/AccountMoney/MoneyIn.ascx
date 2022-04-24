<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoneyIn.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.AccountMoney.MoneyIn" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    tr
    {
        height: 30px;
    }
   
</style>
<div style="padding-bottom: 20px; background-color: #f0f0f0; margin-top: 4px; padding-left: 20px;
    padding-right: 20px; padding-top: 20px">
    <div style="border-bottom: #d2d2d2 1px solid; border-left: #d2d2d2 1px solid; padding-bottom: 6px;
        background-color: #ffffff; padding-left: 6px; padding-right: 6px; border-top: #d2d2d2 1px solid;
        border-right: #d2d2d2 1px solid; padding-top: 6px; text-align: left;">
        <table id="tbPass" runat="server">
            <tr>
                <td width="70">
                    用户名称：
                </td>
                <td style="color: #0033FF;">
                    <%=base.UserNiname %>
                </td>
            </tr>
            <tr>
                <td>
                    可用余额：
                </td>
                <td style="color: #ff0000;">
                    <%=CountMoney%>元
                </td>
            </tr>
            <tr id="tdPayType1" runat="server">
                <td>
                    支付方式：
                </td>
                 <td id="tdPayName" runat="server">
                </td> 
            </tr>
            <tr id="tdPayType" runat="server">
                <td>
                    支付方式：
                </td>
               
                <td>
                    <asp:RadioButtonList RepeatColumns="2" ID="rbList" runat="server">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    充值金额：
                </td>
                <td id="tdMoney" runat="server">
                    <XS:TextBoxVl ID="txtPayMoney" ValidateType="金额" runat="server" Width="120" IsAllowNull="false" />元
                </td>
            </tr>
        </table>
        <div style="text-align: center">
            <XS:Button ID="bntSave" runat="server" width="120" Text=" 下一步 " onclick="bntSave_Click" />
            <XS:Button ID="bntSaveOrderToPay" runat="server" width="120" Visible="false" Text=" 确认支付 "
                onclick="bntSaveOrderToPay_Click" />
        </div>
    </div>
</div>
