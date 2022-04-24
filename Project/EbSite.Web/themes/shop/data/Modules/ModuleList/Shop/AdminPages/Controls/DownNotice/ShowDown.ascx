<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowDown.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.DownNotice.ShowDown" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    .GridViewex
    {
        width: 1000px;
        margin: 6px auto;
    }
    .GridViewex thead tr th
    {
        font-size: 14px;
        text-align: center;
        padding: 10px;
    }
    .GridViewex tbody tr td
    {
        font-size: 14px;
        padding: 10px;
    }
</style>
<div class="admin_toobar">
    <fieldset>
        <legend>详细内容 </legend>
        <div style="margin-left: 20px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        商品名称:<asp:Label ID="lbName" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <table cellspacing="0" rules="all" border="1" style="border-collapse: collapse;"
            class="GridViewex">
            <asp:Repeater runat="server" ID="RepItem">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th scope="col" width="100">
                                申请人手机
                            </th>
                            <th scope="col">
                                申请人email
                            </th>
                            <th scope="col">
                                时间
                            </th>
                            <th scope="col">
                                是否通知
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:Literal ID="litMobile" runat="server" Text='<%#Eval("Mobile")%>'></asp:Literal>
                        </td>
                        <td style="text-align: center;">
                            <asp:Literal ID="litEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Literal>
                        </td>
                        <td style="text-align: center;">
                            <%#Eval("AddDateTime")%>
                        </td>
                        <td>
                            <asp:HiddenField ID="hidid" runat="server" Value='<%# Eval("id") %>' />
                            <%#Eval("isnotice")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </fielset>
</div>
<div style="text-align: center">
    <XS:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="发送降价通知(手机)" OnClientClick="return window.confirm('是否确定发送手机短信通知？')" />
    <XS:Button ID="btnPriced" runat="server" OnClick="btnPriced_Click" Text="发送降价通知(Email)" OnClientClick="return window.confirm('是否确定发送降价通知到邮箱？')" />
   
    <XS:Button ID="btnColseGreyBox" runat="server" Text=" 关 闭 窗 口 " />
</div>