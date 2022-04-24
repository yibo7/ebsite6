<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyCloseOrder.ascx.cs"
    Inherits="EbSite.Modules.Shop.UserPages.Controls.OrderManage.MyCloseOrder" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    .Cblock
    {
        border-top: #d4e4ff 1px solid;
        border-right: #d4e4ff 1px solid;
        border-bottom: #d4e4ff 1px solid;
        padding-bottom: 10px;
        padding-top: 10px;
        padding-left: 10px;
        margin: 10px;
        border-left: #d4e4ff 1px solid;
        padding-right: 10px;
        background-color: #fff;
        height: 100%;
    }
    .left{float: left;}
    .groud{ font-size: 13px;color: red;margin-top: 5px;margin-left: 40px;}
</style>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="Cblock">
        
        <div style="height: 90px;">
        <div class="left" style=" text-align: center; vert-align:middle; line-height: 50px;">
            理由：
        </div>

        <div class="left"><XS:TextBoxVl ID="txtRegion" IsAllowNull="False" TextMode="MultiLine" Width="280px" Height="80px" runat="server"/></div>
        </div>
        <div class="groud">请注意:若使用的优惠券,不能退回。若使用预付款，请联系管理员给您退款。请慎重选择。<br/>
            <asp:Literal ID="litGroupInfo" runat="server"></asp:Literal> 
         </div>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave"   runat="server" CssClass="baja" Text=" 确定关闭 "  
        onclick="bntSave_Click" />
    <XS:Button ID="btnColseGreyBox" runat="server" CssClass="baja" Text=" 取  消 " />
        

</div>
<script>
    function SaveOrderInfo() {
        if (window.confirm("确定要关闭订单信息吗？")) {
            ColseGreyBox();
            return true;
        }
        else {
            return false;
        }
    }

</script>