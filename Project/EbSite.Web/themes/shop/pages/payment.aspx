<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.Payment" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
</head>
<body >
<!--#include file="header.inc" -->
<div class="eb-content">
    <input type="hidden" runat="server" id="hidorderinfo" />
   <div class="container">
        <div class="paypanel">
    <div class="titlediv">
        <ul>
            <li class="li_title">请选择以下支付方式进行支付：</li>
            <asp:Repeater ID="rpt_tab" runat="server">
                <ItemTemplate>
                    <li <%# Container.ItemIndex==0?"class='li_sel'":"class='li_def'" %> name="tab_li" id="li_<%# Container.ItemIndex+1 %>"><%# Eval("name") %></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="onlinepay" id="div_1">
        <asp:Repeater ID="rpt_fir" runat="server" onitemdatabound="rpt_fir_ItemDataBound">
            <ItemTemplate>
                <div class="sectitle"><%# Eval("name") %></div>
                <div class="bankitem">
                <asp:Repeater ID="rpt_sec" runat="server">
                    <ItemTemplate>
                        <div class="bankspan"><input type="radio" value="<%# Eval("id") %>" name="platpay_online" /><img src="<%# Eval("showimg") %>" name="imgpay_online" /></div>
                    </ItemTemplate>
                </asp:Repeater>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="creditpay" id="div_2">
        <div class="sectitle">信用卡快捷支付:无需开通网银，支付大额支付，72小时安全赔付。（服务由支付宝提供）</div>
        <div class="bankitem">
        <asp:Repeater ID="rpt_creditpay" runat="server">
            <ItemTemplate>
                <div class="bankspan"><input type="radio" value="<%# Eval("id") %>" name="platpay_credit" /><img src="<%# Eval("showimg") %>" name="imgpay_credit" /></div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </div>
    <div class="savepay" id="div_3">
        <div class="sectitle">储蓄卡支付:无需开通网银，请确保已在付款银行预留手机号，以免支付失败。（服务由支付宝提供）</div>
        <div class="bankitem">
        <asp:Repeater ID="rpt_savepay" runat="server">
            <ItemTemplate>
                <div class="bankspan"><input type="radio" value="<%# Eval("id") %>" name="platpay_save" /><img src="<%# Eval("showimg") %>" name="imgpay_save" /></div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </div>
</div>
        <div class="payBtn"><a href="javascript:void(0)" id="FastPayBtn">立即付款</a></div>
    </div>
</div>
<%=KeepUserState()%>                                           
</body>
</html>
<script type="text/javascript">
    $(document).ready(function () {
        $("img[name^='imgpay_']").click(function () {
            $("img[name^='imgpay_']").css("border", "1px solid #CCCCCC");
            $(this).css("border", "1px solid #E10000");
            $(this).siblings("input").click();
        });
        $("input[name^='platpay_']").click(function () {
            $("img[name^='imgpay_']").css("border", "1px solid #CCCCCC");
            $(this).siblings("img").css("border", "1px solid #E10000");
        });
        $("li[name='tab_li']").click(function () {
            $("div[class='bankspan']").children("input[type='radio']").attr("checked", false);
            $("div[class='bankspan']").children("img").css("border", "1px solid #CCCCCC");
            $("li[name='tab_li']").attr("class", "li_def");
            $("#div_1,#div_2,#div_3").hide();
            $(this).attr("class", "li_sel");
            $("#" + $(this).attr("id").replace("li", "div")).show();
        });
        $("#FastPayBtn").click(function () {
            var payID = $("div[id='" + $("li[name='tab_li'][class='li_sel']").attr("id").replace("li", "div") + "']").find("input[type='radio']:checked").val();
            if (payID == "" || payID == undefined) {
                tips("请选择要支付的银行!",3,1);
                return;
            }
            var tInfo = $("#<%=hidorderinfo.ClientID %>").val();
            if (tInfo == "" || tInfo == undefined) {
                tips("信息不完整!",3,1);
                return;
            }
            //异步
            var params = { "payID": payID, "strInfo": tInfo };
            runebws("GetPaymentUrl", params, function (data) {
                if (data.d != "") {
                    window.open(data.d);
                }
                else {
                    tips("支付过程中遇到问题,请联系客服进行处理!",3,3);
                }
            });
        });
    });
</script>