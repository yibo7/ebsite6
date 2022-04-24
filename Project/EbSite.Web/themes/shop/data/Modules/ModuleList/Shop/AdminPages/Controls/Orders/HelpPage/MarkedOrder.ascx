<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MarkedOrder.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.MarkedOrder" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<table width="90%" cellpadding="10">
    <tr>
        <td align="right" width="100px">订单编号：</td><td align="left"><asp:Label ID="litOrderNum" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td align="right">成交时间：</td><td align="left"><asp:Label ID="litSuccessDate" runat="server" Text=""></asp:Label></td>
    </tr>
     <tr>
        <td align="right">订单实收款：</td><td align="left">&yen;<asp:Label ID="litFactPrice" runat="server" Text=""></asp:Label></td>
    </tr>
     <tr>
        <td align="right">标志：</td>
        <td align="left">
            <asp:RadioButtonList ID="rdoflag" runat="server" RepeatDirection="Horizontal" Width="300">
                <asp:ListItem Text="" Value="0"><img alt="" src="/images/menus/Ok.gif" /></asp:ListItem>
                <asp:ListItem Text="" Value="1"><img alt="" src="/images/menus/Overlay-Warning.gif" /></asp:ListItem>
                <asp:ListItem Text="" Value="2"><img alt="" src="/images/menus/Flag-Red.gif" /></asp:ListItem>
                <asp:ListItem Text="" Value="3"><img alt="" src="/images/menus/Flag-Green.gif" /></asp:ListItem>
                <asp:ListItem Text="" Value="4"><img alt="" src="/images/menus/Flag-Yellow.gif" /></asp:ListItem>
                <asp:ListItem Text="" Value="5"><img alt="" src="/images/menus/Flag-Cyan.gif" /></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
     <tr>
        <td align="right">备忘录：</td>
        <td align="left"><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="300" Height="100"></asp:TextBox></td>
    </tr>
     <tr>
        <td>&nbsp;</td><td align="left">
            <asp:Button ID="btnSubmit" runat="server" Text=" 提交 " onclick="btnSubmit_Click" CssClass="btnrefundorder" /></td>
    </tr>
</table>
<script type="text/javascript">
    function CloseOrder(flag) {
        if (flag > 0) {
            alert("提交成功!");
            window.parent.location = window.parent.location;
            $(window.parent.document.body).find("div[class='panel-tool-close']").click();
        }
        else {
            alert("提交失败,请重新操作!");
        }
    }
</script>
