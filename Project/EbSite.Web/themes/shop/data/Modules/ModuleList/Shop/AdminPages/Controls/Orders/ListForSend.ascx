<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListForSend.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.ListForSend" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<style type="text/css">
    * {
        font-size:12px;
    }
     .tablestyle
    {
        width: 100%;
        border-width: 0px;
        border-spacing: 0px;
    }
    .tablestyle tbody tr th
    {
        text-align: right;
        background-color: #E1E9FC;
        width: 100px;
    }
    .tablestyle thead tr th
    {
        padding-left: 2px;
    }
    #selProvince,#selCity,#selCounty{width:126px;}
    .GridView tbody tr td div{padding0:px; padding-bottom:2px; height:26px;}
    .GridView tbody tr td div a{ color:Blue; text-decoration:underline;}
    .GridView tbody tr td a{ color:Blue; text-decoration:underline;}
</style>
<div id="PagesMain">
    <XS:Notes ID="Notes1" runat="server"  Text="注：订单状态列中有“退”字代表该订单退过款；有“(团)”字的代表团购订单；有“(抢)”字的代表限时抢购订单；" />
    <input type="hidden" id="hidProvince" runat="server" value="" />
    <input type="hidden" id="hidCity" runat="server" value="" />
    <input type="hidden" id="hidCounty" runat="server" value="" />
    <table class="GridView" cellspacing="0" rules="all" border="1" style="border-collapse:collapse;">
        <XS:Repeater ID="rpList" runat="server" >
            <HeaderTemplate>
                <tr class="GridViewHeader">
                    <th style="width:180px;">订单编号</th><th scope="col">会员名称</th><th scope="col">收货人名称</th><th scope="col">支付方式</th>
                    <th scope="col">订单实收款(元)</th><th scope="col">订单状态</th><th>打印状态</th><th>标注</th><th>发货时间</th><th>操作</th>
                    <th scope="col"><input id='chAll' onclick='on_check(this)'  type=checkbox /></th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr tid="<%# Eval("ID") %>"> 
                                       <td style="width:180px;"><%# Eval("orderid") %>&nbsp;<%# Eval("PanicBuyingId")==null?"":"<span style='color:blue;font-weight:bold;'>(抢)</span>" %><%# Eval("groupid")==null?"":"<span style='color:blue;font-weight:bold;'>(团)</span>" %><%# Eval("RefundAmount") == null ? "" : "<span style='color:red;font-weight:bold;cursor:pointer;' onclick='RefundOrder(this)'>(退)</span>" %></td>

                    <td><%#Eval("username")%></td>
                    <td><%#Eval("SendToUserName")%></td>
                    <td><%#Eval("PaymentType")%></td>
                    <td><div>&yen;<%#Eval("OrderTotal")%></div>
                        <%# Eval("OrderStatus").ToString().Equals("0") ? "<div><a onclick=\"EditOrder(this)\">修改价格</a></div><div><a onclick=\"CloseOrder(this)\">关闭订单</a></div>" : ""%>
                    </td>
                    <td><div><%# base.ParseOrderState(Eval("OrderStatus").ToString())%></div><div><a href="javascript:void(0);" onclick="ViewOrderDetail(this)">详情</a></div>
                        <%# Eval("OrderStatus").ToString().Equals("0")?"<div><a onclick=\"PayedOrder(this)\">我已线下收款</a></div>":"" %>
                    </td>
                    <td><%# EbSite.Modules.Shop.ModuleCore.BLL.Buy_Orders.Instance.GetPrintStateTxt(Eval("IsPrinted"),false) %></td>
                    <td><%# base.GetImgName(Eval("MerchandiserMarkID").ToString()) %></td>
                    <td><%#Eval("sendDate")%></td>
                    <td> <a onclick="MarkOrder(this)">标注</a></td>
                    <td> <input name="ebcheckboxname" value="<%#Eval("ID")%>" type="checkbox" /></td>
                </tr>
            </ItemTemplate>
        </XS:Repeater>
    </table>
</div>
<div>
	 <XS:PagesContrl ID="pcPage" runat="server" PageSize="15" />
</div>
<div id="divSearchadv" title="高级查询" style="display:none; width:600px; height:300px;">
<table class="tablestyle">
    <tr>
        <th>日期:</th><td><XS:DatePicker ID="dateStartAdv" runat="server" Width="80px" />—<XS:DatePicker ID="dateEndAdv" runat="server" Width="80px"  /></td>
    </tr>
</table>
<table class="tablestyle">
    <tr>
        <th>会员姓名:</th><td><XS:TextBoxVl ID="txtMemberAdv" runat="server" Width="150px"></XS:TextBoxVl></td>
        <th>订单编号:</th><td><XS:TextBoxVl ID="txtOrderNumAdv" runat="server" Width="150px"></XS:TextBoxVl></td>
    </tr>
    <tr>
        <th>商品名称:</th><td><XS:TextBoxVl ID="txtGoodsNameAdv" runat="server" Width="150px"></XS:TextBoxVl></td>
        <th>收货人:</th><td><XS:TextBoxVl ID="txtRecNameAdv" runat="server" Width="150px"></XS:TextBoxVl></td>
    </tr>
    <tr>
        <th>打印状态:</th><td><XS:DropDownList ID="ddlPrintStateAdv" runat="server" Width="150px" ></XS:DropDownList></td>
        <th>配送方式:</th><td><XS:DropDownList ID="ddlSendTypeAdv" runat="server" Width="150px" ></XS:DropDownList></td>
    </tr>
    <%--<tr>
        <th>收货地址:</th>
        <td colspan="3">
            省:<select id="selProvince"><option value="-1">-请选择-</option></select>
            市:<select id="selCity"><option value="-1">-请选择-</option></select>
            区/县:<select id="selCounty"><option value="-1">-请选择-</option></select>
        </td>
    </tr>--%>
</table>
</div>
<script type="text/javascript" src="../js/comm_list.js"></script>