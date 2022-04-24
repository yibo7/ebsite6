<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SaleDetails.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.SelReport.SaleDetails" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>/css/ht.css" rel="stylesheet" />
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
        .seachtool {
        width:400px;
        margin-left:10px;
        margin-top:10px;
    }
    </style>
<script type="text/javascript">
    $(document).ready(function () {
        $(".tdatalist>tbody>tr").hover(function () {
            $(this).css("background-color", "#E8A55A");
        }, function () {
            $(this).css("background-color", "#FFFFFF");
        });
    });
</script>
<table class="seachtool">
    <tr>
        <th>成交时间段：</th><td><XS:DatePicker ID="txtBeginDate" runat="server" TimeModel="日期模式" Width="100"></XS:DatePicker> 至 <XS:DatePicker ID="txtEndDate" runat="server" Width="100" TimeModel="日期模式"></XS:DatePicker></td>
        <td><asp:Button ID="btnSeach" runat="server" Text="查询" CssClass="searchbutton" OnClick="btnSeach_Click" /></td>
    </tr>
</table>
<table class="tdatalist">
<thead>
    <tr><th width="150">订单号</th><th width="300">商品名称</th><th width="100">数量</th><th width="150">价格</th><th width="150" style="border-right:1px solid #E0DCCE;">成交时间</th></tr>
</thead>
<XS:Repeater ID="rpList" runat="server">
    <HeaderTemplate>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr rid='row_<%# Container.ItemIndex %>'>
            <td style="border-left:1px solid #E0DCCE;"><%# Eval("orderid") %></td>
            <td><%# Eval("productname") %></td>
            <td><%# Eval("quantity") %></td>
            <td>&yen;<%# Eval("memberprice") %></td>
            <td style="border-right:1px solid #E0DCCE;"><%# Eval("adddatetime") %></td></tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
    </FooterTemplate>
</XS:Repeater>
</table>
<div style="text-align:left; width:988px;">
	 <XS:PagesContrl ID="pcPage" runat="server" PageSize="10" />
</div>