<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Transformation.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.SelReport.Transformation" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style type="text/css">
    .tdatalist {
    border-collapse:collapse;
    margin-left:10px;
    margin-top:10px;
    }
    .tdatalist thead tr {
    background-color:#ECEAE1;
    }
    .tdatalist thead tr th {
    text-align:left;
    padding:10px;
    color:#5C4A35;
    border-left:1px solid #E0DCCE;
    border-top:1px solid #E0DCCE;
    }

    .tdatalist tbody tr td {
    border-bottom:1px solid #E0DCCE;
    padding:5px;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {
        $(".tdatalist>tbody>tr").hover(function () {
            $(this).css("background-color", "#E8A55A");
        }, function () {
            $(this).css("background-color", "#FFFFFF");
        });
        //
        var $tab = $(".tdatalist").children("tbody");
        $tab.children("tr:eq(0)").children("td:eq(0)").html("<img width='24' height='24' src='/themes/shop/data/Modules/ModuleList/Shop/css/0001.gif' />1");
        $tab.children("tr:eq(1)").children("td:eq(0)").html("<img width='24' height='24' src='/themes/shop/data/Modules/ModuleList/Shop/css/0002.gif' />2");
        $tab.children("tr:eq(2)").children("td:eq(0)").html("<img width='24' height='24' src='/themes/shop/data/Modules/ModuleList/Shop/css/0003.gif' />3");
    });
</script>
<table class="tdatalist">
<thead>
    <tr><th width="150">排行</th><th width="300">商品名称</th><th width="100">访问次数</th><th width="150">购买次数</th><th width="150" style="border-right:1px solid #E0DCCE;">访问购买率</th></tr>
</thead>
<XS:Repeater ID="rpList" runat="server">
    <HeaderTemplate>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr rid='row_<%# Container.ItemIndex %>'>
            <td style="border-left:1px solid #E0DCCE;"><%# Container.ItemIndex+1 %></td>
            <td><%# Eval("productname") %></td>
            <td><%# Eval("viewtimes") %></td>
            <td><%# Eval("buytimes") %></td>
            <td style="border-right:1px solid #E0DCCE;"><%# Eval("buyrate") %>%</td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
    </FooterTemplate>
</XS:Repeater>
</table>