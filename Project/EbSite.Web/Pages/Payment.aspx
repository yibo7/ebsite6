<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="EbSite.Web.Pages.Payment" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
    <title>支付方式</title>
    <style type="text/css">
    .paypanel{width:818px; height:auto;border:1px solid #CCCCCC;}
    .titlediv{ color:Black; font-size:14px; font-weight:bold; height:20px; line-height:20px; vertical-align:middle; text-align:left;width:800px; padding:9px; background-color:#E7E7E7;}
    .titlediv ul{ margin:0px; padding:0px;}
    .titlediv ul li{ float:left; height:30px; line-height:30px; vertical-align:top; margin-left:50px;}
    .li_sel{ background-color:White; padding:5px 10px; cursor:pointer;}
    .li_def{ padding:5px; cursor:pointer;}
    .onlinepay{text-align:left;width:800px; height:auto;}
    .creditpay{text-align:left;width:800px;display:none;height:auto;}
    .savepay{text-align:left;width:800px;display:none;height:auto;}
    .bankitem{width:800px; height:auto; padding:10px;}
    .bankspan{width:180px; float:left; display:block; height:35px; margin-bottom:15px; margin-left:10px; line-height:35px; vertical-align:middle; text-align:left;}
    .bankspan img{width:140px; height:35px; border:1px solid #CCCCCC;}
    .bankspan input{outline:none;}
    .sectitle{ color:Gray; padding-top:10px; margin-left:25px;}
    .payBtn{padding-top:10px; margin-left:25px;}
    .payBtn a{ color:Blue; text-decoration:underline;}
</style>
</head>
<body>
<form id="form1" runat="server">
<input type="hidden" runat="server" id="hidorderinfo" />
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
<div class="payBtn"><a href="javascript:void(0)">立即付款</a></div>
</form>
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
    });
</script>
