<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataIndex.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.DataExport.DataIndex" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style type="text/css">
    .TopToolBar{width:90%; height:20px; padding:5px;}
    .TopToolBar table{ width:600px;}
    .TopToolBar table tr th{width:100px; background-color:#FEF8E0; text-align:right;}
</style>
<div class="TopToolBar">
    <table>
        <tr>
            <th>选择来源:</th>
            <td><asp:DropDownList ID="ddlDataSource" runat="server" Width="100">
                <asp:ListItem Selected="True" Text="请选择" Value="0"></asp:ListItem>
                <asp:ListItem Text="专家问答" Value="1"></asp:ListItem>
                <asp:ListItem Text="已报价订单" Value="2"></asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnInPut" runat="server" Text=" 确定导入 " OnClientClick="return CheckItem()" onclick="btnInPut_Click" /></td>
        </tr>
    </table>
</div>
<script type="text/javascript">
    function CheckItem() {
        var ddlS = $("#<%=ddlDataSource.ClientID %>");
        if (ddlS.children("option:selected").val() == "0") {
            alert("请选择数据源");
            return false;
        }
        else {
            return true;
        }
    }
</script>

