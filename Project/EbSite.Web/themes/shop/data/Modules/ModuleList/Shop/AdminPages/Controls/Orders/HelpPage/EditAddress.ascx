<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAddress.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.EditAddress" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<table>
    <tr><td align="right">收货人姓名:</td><td align="left"><asp:TextBox ID="txtReUname" runat="server"></asp:TextBox></td></tr>
    <tr><td align="right">收货人地址:</td><td align="left"><XS:AreaList ID="ddlAddress" runat="server"></XS:AreaList></td></tr>
    <tr><td align="right">详细地址:</td><td align="left"><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td></tr>
    <tr><td align="right">手机号码:</td><td align="left"><asp:TextBox ID="txtMobil" runat="server"></asp:TextBox></td></tr>
    <tr><td align="right">电话号码:</td><td align="left"><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td></tr>
    <tr><td align="right">邮政编码:</td><td align="left"><asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox></td></tr>
    <tr>
        <td>&nbsp;</td><td align="left">
        <asp:Button ID="btnSubmit" runat="server" Text=" 提交 " onclick="btnSubmit_Click" />
        <input type="button" value=" 关闭 " onclick="ClosePage()" /> 
        </td>
    </tr>
</table>
<script type="text/javascript">
    function CloseOrder(flag) {
        if (flag > 0) {
            window.parent.location =window.parent.location;
            alert("提交成功!");
            ClosePage();
        }
        else {
            alert("提交失败,请重新操作!");
        }
    }
    function ClosePage() { 
        $(window.parent.document.body).find("div[class='panel-tool-close']").click();
    }
</script>
