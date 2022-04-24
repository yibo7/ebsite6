<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="orderlist.ascx.cs" Inherits="EbSite.Modules.Shop.UserPages.Controls.MOrderManage.Orderlist" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBarMobile ID="ucToolBar" runat="server">
</XS:ToolBarMobile>
<style>
    #pg {
        font-size:12px;
    }
    .fdiv
    {
        width: 100%;
        clear: both;
        margin-bottom: 20px;
    }
    .fleft
    {
        float: left;
        margin-bottom: 5px;
        margin-left: 5px;
    }
    .cl
    {
        float: left;
        width: 65px;
    }
</style>
<div id="pg">
    <div class="data-list">
        <XS:Repeater ID="gdList" runat="server" OnItemCommand="gdList_ItemCommand" OnItemDataBound="gdList_ItemDataBound">
            <itemtemplate>
        <div style="background-color: #ffffff; border: 1px solid #E7E7E7; margin-bottom: 10px;padding-top:9px; padding-bottom: 9px;">
             <div class="fdiv">
                <div class="fleft" >
                    订单编号:
                    <%# Eval("orderid") %>&nbsp;<%# Eval("PanicBuyingId")==null?"":"<span style='color:blue;font-weight:bold;'>(抢)</span>" %><%# Eval("groupid")==null?"":"<span style='color:blue;font-weight:bold;'>(团)</span>" %></div>
                <div class="fleft" >
                    收货人:&nbsp;<%#Eval("SendToUserName")%>
                </div>
            </div>
          <div class="fdiv">
                <div class="fleft" >
                    支付方式:&nbsp;<%#Eval("PaymentType")%></div>
                <div class="fleft" >
                    金额 :&nbsp;<span style="color:#FF0000;font-size:14px;">&yen;<%#Eval("OrderTotal")%></span></div>
            </div>
            <div class="fdiv">
                <div class="fleft" >
                    订单状态:&nbsp;<%#EbSite.Modules.Shop.ModuleCore.BLL.Buy_Orders.Instance.ParseOrderState(Eval("OrderStatus").ToString())%></div>
                <div class="fleft">
                    下单时间:&nbsp;<%#Eval("OrderAddDate")%></div>
            </div>
            <div class="fdiv">
               <div class="fleft" >
                    <div  class="cl">   <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GetViewOrderMUrl(ModuleSiteID,Eval("OrderId").ToString()) %>" target="_blank">查看</a></div>
                    <div  class="cl">   <asp:HyperLink  ID="HlinkPay" runat="server">付款</asp:HyperLink></div>
                    <asp:Panel ID="PnClose" runat="server" CssClass="cl"> <a onclick="clos(this)" aid="<%#Eval("id").ToString()%>" >关闭</a> </asp:Panel>
                    <div  class="cl"> <XS:LinkButton ID="lbConfirm" runat="server" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('您确定已经收到货并完成该订单吗?')" ForeColor="red"  CommandName="ExConfirm" Text="确认收货 "></XS:LinkButton>   </div> 
               </div>
                <div style="height:1px;"></div>
            </div>
            
        </div>
    </itemtemplate>
        </XS:Repeater>
    </div>
    <div class="btnloadmore">
        加载更多...</div>
    <XS:PagesContrl ID="pcPage" PageSize="5" runat="server" />
</div>
<div id="SelClass" style="display: none;">
    <div class="toolbar " id="toolbar">
        <span class="button fr" onclick="btnqx()">返回</span><h2 style="text-align: center;
            color: #fff; padding: 8px;">
            关闭订单 请添写原因</h2>
    </div>
    <div style="padding: 10px;">
        <textarea id="txtRegion" cols="20" style="width: 98%;" rows="8"></textarea>
      
        <div>
            请注意:若使用的优惠券,不能退回。若使用预付款，请联系管理员给您退款。请慎重选择。<br />
        </div>
    </div>
    <div style="width: 49%;" class="button btnred2 btnmiddle" onclick="SaveOrderInfo()">
        确定关闭
    </div>
    <div style="width: 49%;" class="button btnred2 btnmiddle" onclick="btnqx()">
        取消关闭
    </div>
</div>

 <div id="dialog4" class="vote-dialog">
            </div>
<script>

    m_dialog("dialog4", "200", "130");
    loadpage(".data-list", ".btnloadmore", '.data-list div');
    var OrderID = 0;
    function clos(obj) {
    
        var id = $(obj).attr("aid");
        OrderID = id;
        $("#pg").attr("style", "display:none");
        $("#SelClass").attr("style", "display:block");


    }
    //取消
    function btnqx() {
        $("#pg").attr("style", "display:block");
        $("#SelClass").attr("style", "display:none");
        $("#txtRegion").val("");     
    }
    //确定 关闭
    function SaveOrderInfo() {
      //  alert(OrderID);

        var icent = $("#txtRegion").val();       
     
        if (IsNullOrUndefined(icent)) {
            $("#dialog4").html("请添写理由");
            $('#dialog4').dialog('open', 20, 20);
        } else {
            //待完善
            var pram = { "orderid": OrderID,"ctent": icent };
            runws("cfccc599-4585-43ed-ba31-fdb50024714b", "CloseOrder", pram, function (result) {
                if (result.d) {
                   
                    Refesh();
                } else {
                    $("#dialog4").html("关闭失败！");
                    $('#dialog4').dialog('open', 20, 20);
                }
            });
            
        }
        
    }
    function IsNullOrUndefined(strInput)
    {
        strInput=$.trim(strInput);
        if(strInput==""||strInput==undefined||strInput==null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
</script>
