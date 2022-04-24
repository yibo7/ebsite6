<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintKDD.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.PrintKDD" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:Panel ID="panel1" runat="server" Width="100%">
<div class="printtitle">&nbsp;&nbsp;收货人信息</div>
<table class="printcss" border="0" cellspacing="1">
    <tr><th>收货人姓名：</th><td><asp:TextBox ID="txtUName" runat="server"></asp:TextBox></td><th>邮编：</th><td><asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox></td></tr>
    <tr><th>手机号码：</th><td><asp:TextBox ID="txtMobil" runat="server"></asp:TextBox></td><th>联系电话：</th><td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td></tr>
    <tr><th>省区：</th><td colspan="3"><XS:AreaList ID="ddlAddress" runat="server"></XS:AreaList></td></tr>
    <tr><th>详细地址：</th><td><asp:TextBox ID="txtAddress" runat="server" Width="280"></asp:TextBox></td><th>E-mail：</th><td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td></tr>
    <tr><th>&nbsp;</th><td colspan="3"><asp:Button ID="btnSubmit" runat="server" Text="保存地址" onclick="btnSubmit_Click" /></td></tr>
</table>
<div class="printtitle">&nbsp;&nbsp;发货人信息</div>
<table class="printcss" border="0" cellspacing="1">
    <tr><th>发货点选择：</th><td colspan="3"><asp:DropDownList ID="ddlSendRegion" runat="server" AutoPostBack="True" onselectedindexchanged="ddlSendRegion_SelectedIndexChanged"></asp:DropDownList></td></tr>
    <tr><th>发件人姓名：</th><td><asp:Literal ID="litSendUName" runat="server"></asp:Literal></td><th>地区：</th><td><asp:Literal ID="litSendRegion" runat="server"></asp:Literal></td></tr>
    <tr><th>邮　编：</th><td><asp:Literal ID="litZipCode" runat="server"></asp:Literal></td><th>详细地址：</th><td><asp:Literal ID="litAddress" runat="server"></asp:Literal></td></tr>
    <tr><th>手　机：</th><td><asp:Literal ID="litMobilNum" runat="server"></asp:Literal></td><th>联系电话：</th><td><asp:Literal ID="litPhoneNum" runat="server"></asp:Literal></td></tr>
</table>
<div class="printtitle">&nbsp;&nbsp;选择快递单模板</div>
<table class="printcss" border="0" cellspacing="1">
    <tr><th>客户所选配送方式：</th><td><asp:Literal ID="litSendTypeName" runat="server"></asp:Literal></td></tr>
    <tr><th>选择模版：</th><td><asp:DropDownList ID="ddlTemplate" runat="server"></asp:DropDownList>
        <asp:Button ID="btnPrint" runat="server" Text=" 立即打印快递单 " onclick="btnPrint_Click" /></td></tr>
</table>
</asp:Panel>
<asp:Panel ID="panel2" runat="server" Width="100%" Visible="false">
    <div class="listborder">
                <table bgcolor="#dddddd">
                    <tbody>
                        <tr>
                            <td>
                                <div id="dly_printer" style="width: 907px; height: 560px">
                                    <object id="dly_printer_flash" height="100%" width="100%" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000">
                                        <param value="high" name="quality" />
                                        <param value="always" name="allowScriptAccess" />
                                        <param value="true" name="swLiveConnect" />
                                        <param value="<%=ItemContent %>" name="flashVars" />
                                        <param value="/themes/shop/data/Modules/ModuleList/Shop/AdminPages/Controls/Orders/HelpPage/printermode.swf" name="movie" />
                                    </object>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
</asp:Panel>
<script type="text/javascript">
    function CloseOrder(flag) {
        if (flag > 0) {
            tips("修改成功", 1, 1);
            var time = setTimeout(function () { clearTimeout(time);}, 1000);
        }
        else {
            tips("提交失败,请重新操作!", 3, 2);
        }
    }
    //自动放大
    $(window.parent.document.body).find("div[class='panel-tool-max']").click();
</script>
