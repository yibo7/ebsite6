<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvanceReport.ascx.cs"
    Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.AccountMoney.AdvanceReport" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    .bTitle
    {
        margin: 9px;
        font-size: 14px;
    }
    .bTop_BomPadding10
    {
        padding-bottom: 10px;
        padding-top: 5px;
    }
</style>
<asp:Panel runat="server" ID="RegAccount">
    <div style="float: left;">
        <div class="User_manage">
            开启预付款账户</div>
        <div class="sfq">
            当前预付款功能没有开启，要开启吗？开启请添入交易密码。</div>
        <div class="sfq ">
            <div id="divInputTradePassword" style="zoom: 1; text-align: left; display: block">
                <table style="font-size: 14px; height: 100px; color: #212222; margin-top: 18px" cellspacing="0"
                    cellpadding="0" align="left" border="0">
                    <tbody>
                        <tr>
                            <td nowrap align="right">
                                交易密码：
                            </td>
                            <td>
                                <XS:TextBoxVl ID="txtPassWord" runat="server" Width="200" TextMode="Password" IsAllowNull="false" />
                            </td>
                        </tr>
                        <tr>
                            <td nowrap align="right">
                                确认新交易密码：
                            </td>
                            <td>
                                <XS:TextBoxVl ID="txtCfPassWord" runat="server" Width="200" TextMode="Password" IsAllowNull="false" />
                            </td>
                        </tr>
                        <tr>
                            <td class="right">
                                &nbsp;
                            </td>
                            <td class="left">
                                <XS:Button ID="bntOpenBalance" runat="server" width="120" Text=" 开启 " class="btn_style_bar"
                                    onclick="bntOpenBalance_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="AccountInfo">
    <div class="bTop_BomPadding10">
        <div class="bTitle">
            <strong>预付款余额查询</strong></div>
        <div style="padding-bottom: 20px; background-color: #f0f0f0; margin-top: 4px; padding-left: 20px;
            padding-right: 20px; padding-top: 20px">
            <div style="border-bottom: #d2d2d2 1px solid; border-left: #d2d2d2 1px solid; padding-bottom: 6px;
                background-color: #ffffff; padding-left: 6px; padding-right: 6px; border-top: #d2d2d2 1px solid;
                border-right: #d2d2d2 1px solid; padding-top: 6px; text-align: left;">
                <p style="height: 30px; margin-top: 10px;">
                    <label style="color: black">
                        账户总余额：</label><span style="color: red"><strong><span id="MyAccountSummary_litAccountAmount"><%=CountMoney%></span></strong></span>
                    <span style="margin-left: 20px"><a style="color: blue; text-decoration: underline"
                        href="<%=HostApi.GetAccoutInfo %>">查看账户明细</a></span></p>
                <p style="height: 30px;">
                    <label style="color: black">
                        提现冻结金额：</label><span style="color: red"><strong><span id="MyAccountSummary_litRequestBalance"><%=FrozenMondy%></span></strong></span>
                </p>
               <p style="height: 30px;">
                    <label style="color: black">
                        可用余额：</label><span style="color: red"><strong><span id="MyAccountSummary_litUseableBalance"><%=CountMoney - FrozenMondy%></span></strong></span>
                    <span style="color: black; margin-left: 20px">金额不够?立刻</span> <span style="margin-left: 20px">
                        <a style="color: blue; text-decoration: underline" href="<%=HostApi.GetMoneyInUrl%>">
                            充值</a></span></p>
            </div>
        </div>
        <div class="bTitle">
            <strong>提现申请查询</strong></div>
        <div style="padding-bottom: 20px; background-color: #f0f0f0; margin-top: 4px; padding-left: 20px;
            padding-right: 20px; padding-top: 20px">
            <div style="border-bottom: #d2d2d2 1px solid; border-left: #d2d2d2 1px solid; padding-bottom: 6px;
                background-color: #ffffff; padding-left: 6px; padding-right: 6px; border-top: #d2d2d2 1px solid;
                border-right: #d2d2d2 1px solid; padding-top: 6px; text-align: left;">
                 <p style="height: 30px;">
                    <label style="color: black">
                    </label>
                    <span style="margin-left: 10px"><a style="color: blue; text-decoration: underline"
                        href="<%=HostApi.GetMoneyApply %>">申请提现</a></span> <span style="margin-left: 10px">
                    </span>
                </p>
            </div>
        </div>
    </div>
</asp:Panel>
