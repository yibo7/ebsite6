<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderStatistics.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.SelReport.OrderStatistics" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>/css/ht.css" rel="stylesheet" />
<script type="text/javascript">
    function ShowRows(obj)
    {
        $("#" + $(obj).attr("rid")).toggle();
    }

    $(document).ready(function () {
        $(".tdatalist>tbody>tr").hover(function () {
            var rrid = $(this).attr("rid");
            $(".tdatalist>tbody>tr[rid='" + rrid + "']").css("background-color", "#E8A55A");
        }, function () {
            var rrid = $(this).attr("rid");
            $(".tdatalist>tbody>tr[rid='" + rrid + "']").css("background-color", "#FFFFFF");
        });
    });
</script>
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

    .tdatalistc {
        width:100%;
    }
        .tdatalistc tbody tr td {
            text-align:left;
            border:none;
        }
    .seachtool {
        width:1100px;
        margin-left:10px;
        margin-top:10px;
    }
    .foottip {
        width:1100px;
        height:30px;
        line-height:30px;
        vertical-align:middle;
        font-size:14px;
        padding-left:10px;
    }
        .foottip span {
            color:green;
        }
    .foottip span b {
        color:red;
    }

        .foottip ins {
            color:#FF4800;
            text-decoration:none;
        }
            .foottip ins b {
                color:red;
            }
</style>
<table class="seachtool">
    <tr>
        <th>会员名：</th><td><XS:TextBox ID="txtMeberName" runat="server" Width="150px"></XS:TextBox></td>
        <th>收货人：</th><td><XS:TextBox ID="txtReUserName" runat="server" Width="150px"></XS:TextBox></td>
        <th>订单号：</th><td><XS:TextBox ID="txtOrderNum" runat="server" Width="150px"></XS:TextBox></td>
        <th>选择时间段：</th><td><XS:DatePicker ID="txtBeginDate" runat="server" TimeModel="日期模式" Width="100"></XS:DatePicker> 至 <XS:DatePicker ID="txtEndDate" runat="server" Width="100" TimeModel="日期模式"></XS:DatePicker></td>
        <td><asp:Button ID="btnSeach" runat="server" Text="查询" CssClass="searchbutton" OnClick="btnSeach_Click" /></td>
    </tr>
</table>
<table class="tdatalist">
<thead>
    <tr><th width="150">订单号</th><th width="300">下单时间</th><th width="150">总订单金额</th><th width="150">用户名</th><th width="150">收货人</th><th width="150" style="border-right:1px solid #E0DCCE;">利润</th></tr>
</thead>
<XS:Repeater ID="rpList" runat="server" OnItemDataBound="rpList_ItemDataBound">
    <HeaderTemplate>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="cursor:pointer;" rid='row_<%# Container.ItemIndex %>' onclick="ShowRows(this)" title="点击查看商品列表"><td style="border-left:1px solid #E0DCCE;"><%# Eval("orderid") %></td><td><%# Eval("orderadddate") %></td><td>&yen;<%# Eval("ordertotal") %></td><td><%# Eval("username") %></td><td><%# Eval("sendtousername") %></td><td style="border-right:1px solid #E0DCCE;">&yen;<%# Eval("orderprofit") %></td></tr>
        <tr id='row_<%# Container.ItemIndex %>' rid='row_<%# Container.ItemIndex %>' style="display:none;"><td colspan="6" style="border-left:1px solid #E0DCCE;border-right:1px solid #E0DCCE;">
         <asp:Repeater ID="repItemList" runat="server">
             <HeaderTemplate>
                 <table class="tdatalistc">
                     <tbody>
             </HeaderTemplate>
            <ItemTemplate>
                <tr><td width="150"><a target="_blank" href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),3)%>"><img width="40" height="40" src="<%# Eval("thumbnailsurl") %>" /></a></td><td width="300"><a target="_blank" href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),3)%>"><%# Eval("productname") %></a><br /><%# Eval("skucontent") %></td>
                    <td width="150">商品单价：&yen;<%# Eval("MemberPrice") %></td>
                    <td width="150">购买数量：×<%# Eval("quantity") %></td>
                    <td width="150">发货数量：×<%# Eval("Quantity") %></td><td width="160">总价：&yen;<%# Eval("AdjustedPrice") %></td>
                </tr>
            </ItemTemplate>
              <FooterTemplate>
                  </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
            </td></tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
    </FooterTemplate>
</XS:Repeater>
</table>
<div class="foottip">
    当前页总计：<ins>当前页共计<b><asp:Literal ID="litCureenCount" runat="server" Text="0"></asp:Literal></b>个 订单金额共计<b>
        <asp:Literal ID="litCureenTotalMoney" runat="server" Text="0.00"></asp:Literal></b>元 订单毛利润共计<b><asp:Literal ID="litCureenProfit" runat="server" Text="0.00"></asp:Literal></b>元</ins><br />
    当前查询结果合计：<span>当前查询结果共计<b><asp:Literal ID="litTotalCount" runat="server" Text="0"></asp:Literal></b>个 订单金额共计
        <b><asp:Literal ID="litTotalMoney" runat="server" Text="0.00"></asp:Literal></b>元 订单毛利润共计<b><asp:Literal ID="litTotalProfit" runat="server" Text="0.00"></asp:Literal></b>元</span>
</div>
<div style="text-align:left; width:1210px;">
	 <XS:PagesContrl ID="pcPage" runat="server" PageSize="10" />
</div>