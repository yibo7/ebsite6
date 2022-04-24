<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoneyOut.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.AccountMoney.MoneyOut" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    .pnbigdiv
    {
        margin: auto auto;
        width: 400px;
    }
    .pndiv
    {
        height: 30px;
    }
    .pnleft
    {
        float: left;
        width: 80px;
        margin-left: 3px;
        text-align: right;
    }
    .pnright
    {
        float: left;
        width: 80px;
        margin-left: 10px;
        text-align: left;
    }
    tr{ height: 39px;}
</style>
<div style="padding-bottom: 20px; background-color: #f0f0f0; margin-top: 4px; padding-left: 20px;
    padding-right: 20px; padding-top: 20px">
    <div style="border-bottom: #d2d2d2 1px solid; border-left: #d2d2d2 1px solid; padding-bottom: 6px;
        background-color: #ffffff; padding-left: 6px; padding-right: 6px; border-top: #d2d2d2 1px solid;
        border-right: #d2d2d2 1px solid; padding-top: 6px; text-align: left;">
        <asp:Panel ID="PanAdd" runat="server">
            <asp:Literal ID="LitMessage" runat="server">  <span class="warnpic"></span><div style="float: left; margin-left: 5px;">上笔提现管理员还没有处理，只有处理完后才能再次申请提现</div></asp:Literal>
           <div style="clear: both;"></div>
            <table border="0" cellspacing="5" cellpadding="0" width="330px" align="center">
                <tbody>
                    <tr>
                        <td style="height: 30px;text-align:right;">
                            用户名：
                        </td>
                        <td style="text-align:left;">
                            <%=base.UserNiname %>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;text-align:right;">
                            可用余额：
                        </td>
                        <td style="text-align:left;">
                            <span id="RequestBalanceDraw_lblBanlance">
                                <%=CountMoney%></span> 元
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;text-align:right;">
                            提现金额：
                        </td>
                        <td style="height: 30px;text-align:left;">
                            <XS:TextBoxVl ID="txtAmount" ValidateType="金额" MsgErr="请输入有效金额，提现金额必须不能大于用户可用金额"
                                runat="server" Width="180" IsAllowNull="false" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;text-align:right;">
                            开户银行：
                        </td>
                        <td style="height: 30px;text-align:left;">
                            <XS:TextBoxVl ID="txtBankName" IsNull="false" runat="server" Width="180" IsAllowNull="false"
                                MsgErr="开银行名称不能为空,长度限制在60字符以内" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;text-align:right;">
                            银行开户名：
                        </td>
                        <td style="height: 30px;text-align:left;">
                            <XS:TextBoxVl ID="txtAccountName" Msg="开户人真实姓名不能为空,长度限制在30字符以内" runat="server" Width="180"
                                IsAllowNull="false" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;text-align:right;">
                            提现账号信息：
                        </td>
                        <td style="height: 30px;text-align:left;">
                            <XS:TextBoxVl ID="txtCardNumber" IsAllowNull="false" HintInfo="个人银行帐号不能为空,限制在100个字符以内"
                                runat="server" Width="180" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;text-align:right;">
                            备注：
                        </td>
                        <td style="height: 30px;text-align:left;">
                            <XS:TextBoxVl ID="txtRemark" Height="30" TextMode="MultiLine" runat="server" Width="180" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;text-align:right;">
                            交易密码：
                        </td>
                        <td style="height: 30px;text-align:left;">
                            <XS:TextBoxVl ID="txtPwd" TextMode="Password" IsAllowNull="false" runat="server"
                                Width="180" HintInfo="交易密码不能为空，且在6-20个字符之间" />
                        </td>
                    </tr>
                    <tr>
                        <td class="right">
                            &nbsp;
                        </td>
                        <td style="height: 26px;text-align:left;">
                            <p>
                                <label class="labeldefault">
                                </label>
                                <XS:Button ID="bntSave" runat="server" Width="120" Text=" 下一步 " OnClick="bntSave_Click" /></p>
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:Panel>
        <asp:Panel ID="PanOK" runat="server">
            <div class="pnbigdiv">
                <div class="pndiv">
                    <div class="pnleft">
                        用户名:</div>
                    <div class="pnright">
                        <%=base.UserNiname %></div>
                </div>
                <div class="pndiv">
                    <div class="pnleft">
                        提现金额:</div>
                    <div class="pnright">
                        <span style="color: red;">
                            <asp:Label ID="lbMoney" runat="server" Text="Label"></asp:Label></span></div>
                </div>
                <div class="pndiv">
                    <div class="pnleft">
                        开户银行:</div>
                    <div class="pnright">
                        <asp:Label ID="lbBankName" runat="server" Text="Label"></asp:Label></div>
                </div>
                <div class="pndiv">
                    <div class="pnleft">
                        银行开户名:</div>
                    <div class="pnright">
                        <asp:Label ID="lbAccountName" runat="server" Text="Label"></asp:Label></div>
                </div>
                <div class="pndiv">
                    <div class="pnleft">
                        账号信息:</div>
                    <div class="pnright">
                        <asp:Label ID="lbCardNumber" runat="server" Text="Label"></asp:Label></div>
                </div>
                <div class="pndiv">
                    <div class="pnleft">
                        备注:</div>
                    <div class="pnright">
                        <asp:Label ID="lbDemo" runat="server" Text="Label"></asp:Label></div>
                </div>
                <XS:Button ID="bntOK" runat="server" Width="120" Text=" 确认提现 " OnClick="bntOK_Click" />
            </div>
        </asp:Panel>
    </div>
</div>
