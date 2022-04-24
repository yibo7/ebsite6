<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditSendType.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.EditSendType" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<table width="90%" cellpadding="6">
    <tr>
        <td align="right">请选择新的配送方式:</td><td align="left"><XS:DropDownList ID="ddlSendType" runat="server" Width="150px" ></XS:DropDownList></td>
    </tr>
    <tr>
        <td align="right">
            <asp:Button ID="btnUpdate" runat="server" Text=" 确定 " onclick="btnUpdate_Click" />
            <input type="button" value=" 关闭 " onclick="ClosePage()" />
        </td><td>&nbsp;</td>
    </tr>
</table>
<script type="text/javascript">
    function CloseOrder(flag) {
        if (flag > 0) {
            alert("订单操作成功");
            window.parent.location = window.parent.location;
            ClosePage();
        }
        else {
            tips("提交失败,请重新操作!", 3, 2);
        }
    }
    function ClosePage() { 
        $(window.parent.document.body).find("div[class='panel-tool-close']").click();
    }
</script>