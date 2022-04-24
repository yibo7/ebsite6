<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CloseOrder.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.CloseOrder" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<table width="90%" cellpadding="6">
    <tr><td colspan="2">关闭交易?请您确认已经通知买家,并已达成一致意见,您单方面关闭交易,将可能导致交易纠纷</td></tr>
    <tr>
        <td align="right">关闭该订单的理由:</td><td align="left"><XS:DropDownList ID="ddlCloseReason" runat="server" Width="150px" ></XS:DropDownList></td>
    </tr>
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td align="right"><input type="button" value=" 确定关闭 " onclick="CloseOrder()" class="btnedit" /></td><td>&nbsp;&nbsp;&nbsp;<input type="button" value=" 取 消 " onclick="ClosePage()" class="btnclose" /></td>
    </tr>
</table>
<script type="text/javascript">
    function CloseOrder() {
        var rid = "<%= OrderCodeID %>";
        if (rid != "" && rid != undefined) {
            if ($("#<%=ddlCloseReason.ClientID %>").children("option:selected").val()!="-1") {
                var strRea = $("#<%=ddlCloseReason.ClientID %>").children("option:selected").text();
                runws("PageCloseOrder", { "id": rid, "strRea": strRea }, function (data) {
                    if (data.d > 0) {
                        alert("订单关闭成功");
                        window.parent.location = window.parent.location;
                        ClosePage();
                    }
                    else {
                        tips("提交失败,请重新操作!", 3, 2);
                    }
                });
            }
        }
    }
    function ClosePage()
    {
        $(window.parent.document.body).find("div[class='panel-tool-close']").click();
    }
</script>