<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="orderlist.ascx.cs" Inherits="EbSite.Modules.Shop.UserPages.Controls.OrderManage.orderlist" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div class="gdList_title">
    <div style="width: 120px;">
        订单编号</div>
    <div style="width: 80px;">
        收货人
    </div>
    <div style="width: 130px;">
        支付方式</div>
    <div style="width: 120px;">
        金额</div>
    <div style="width: 100px;">
        订单状态</div>
    <div style="width: 150px;">
        下单时间</div>
    <div style="width: 100px;">
        操作
    </div>
</div>
<XS:Repeater ID="gdList" runat="server" OnItemCommand="gdList_ItemCommand" OnItemDataBound="gdList_ItemDataBound">
    <ItemTemplate>
        <div class="gdListContent">
            <div style="width: 120px;">
                <%# Eval("orderid") %>&nbsp;<%# Eval("PanicBuyingId")==null?"":"<span style='color:blue;font-weight:bold;'>(抢)</span>" %><%# Eval("groupid")==null?"":"<span style='color:blue;font-weight:bold;'>(团)</span>" %></div>
            <div style="width: 80px;">
                &nbsp;<%#Eval("SendToUserName")%>
            </div>
            <div style="width: 130px;">
                &nbsp;<%#Eval("PaymentType")%></div>
            <div style="width: 120px;">
                &nbsp;&yen;<%#Eval("OrderTotal")%></div>
            <div style="width: 100px;">
                &nbsp;<%#EbSite.Modules.Shop.ModuleCore.BLL.Buy_Orders.Instance.ParseOrderState(Eval("OrderStatus").ToString())%></div>
            <div style="width: 150px;">
                &nbsp;<%#Eval("OrderAddDate")%></div>
            <div style="width: 100px;" id='<%# Eval("id") %>' num='<%# Eval("orderid") %>'>
               <div class="clos">
                <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GetViewOrderUrl(ModuleSiteID,Eval("OrderId").ToString()) %>"
                    target="_blank">查看</a></div>
              <asp:HyperLink CssClass="clos" ID="HlinkPay" runat="server">付款</asp:HyperLink>
            
               <XS:LinkButton  CssClass="clos" ID="lbConfirm" runat="server" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('您确定已经收到货并完成该订单吗?')"
                    ForeColor="red" CommandName="ExConfirm" Text="确认收货 "></XS:LinkButton>
                <asp:HyperLink CssClass="clos" ID="lbComment" runat="server">评论</asp:HyperLink>
                <asp:Panel ID="PanColse"  runat="server" CssClass="clos">
                        <a href="javascript:void(0)" onclick="CloseOrder(this)">关闭</a>
                 </asp:Panel>
            </div>
        </div>
    </ItemTemplate>
</XS:Repeater>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>


<div style="display:none;">
<div id="ClosePanel" style="width:320px;height:220px;" tid="" num="">
    <div style="font-size:12px;color:#909090;margin-bottom:20px;height:20px;line-height:20px;">  <strong>关闭的理由</strong></div>
       <textarea id="txtRegion" cols="40"  rows="5"></textarea>    
    <span  style="color:red;display:none;">请添写理由</span>
    <div style="margin-top: 6px;">  *请注意:若使用的优惠券,不能退回。若使用预付款，请联系管理员给您退款。请慎重选择。</div>
    <div style="text-align:center;margin-top:20px;"><input type="button" value=" 确定 " onclick="CloseOrderFun()" /> &nbsp; &nbsp; &nbsp;<input type="button" value=" 取消 " onclick="ClosePanel()" /></div>
</div></div>
<style>
    .clos{ float: left;width: 30px;}
</style>
<script>
    function CloseOrder(obj) {
        var id = parseInt($(obj).parent("div").parent("div").attr("id"));
        if (id > 0) {
            var orderNum = $(obj).parent("div").parent("div").attr("num");
            clwindiv("ClosePanel");
            $("#ClosePanel").attr("tid", id).attr("num", orderNum);

        }
    }
    function CloseOrderFun() {
        var $cPanel = $("#txtRegion");
        var strReason = $cPanel.val();
        if (strReason != "" && strReason != "请选择关闭的理由") {
            var tid = $("#ClosePanel").attr("tid");
            var num = $("#ClosePanel").attr("num");
            runws("ClosePcOrder", { "id": tid, "orderID": num, "strReason": strReason }, function (data) {
                if (parseInt(data.d) > 0) {
                    window.location = window.location;
                }
                else {
                    alert("操作失败，请重新操作!");
                }
            });
        }
        else {
            $cPanel.next("span").show();
        }
    }
    function ClosePanel() {
        $("#fancybox-close").click();
    }
</script>