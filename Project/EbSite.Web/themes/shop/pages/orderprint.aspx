<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.orderprint" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>订单打印</title> <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link type="text/css" href="<%=base.ThemeCss %>/shoporder.css" rel="stylesheet" />
    <style type="text/css">
* {margin:0;padding:0}
body {font:12px/1.5  "宋体";color:#333}
.w{width:100%;}
.m1 td{height:0.6cm;line-height:0.6cm;}
.t3,.t7,.t6{width:1.6cm}
.t1{width:6.8cm}
.t5{width:1.1cm}
.tb4{border-collapse:collapse;border:1px solid #000}
.tb4 th, .tb4 td,.d1{border:1px solid #000}
.tb4 td {padding:1px}
.tb4 th {height:0.6cm;font-weight:normal}
.m1,.m2,.m3{padding-top:10px}
.d1{padding:10px}
.d2{text-align:right;padding:10px 0;font-size:14px}
.logo{border-bottom:1px solid #ccc;padding:10px}
.footer{border-top:1px solid #ccc;text-align:center;padding:10px}
.v-h{ text-align:center}
.m2{padding-left:1px}
</style>
<style type="text/css" media="print">
.v-h {display:none;}
</style>
</head>
<body>
<div class="eb-content">
   <div class="container">
		<div class="w">
            <div class="logo"><img width="182" height="85" src="<%=ThemeCss%>images/logo.png"  /></div>
			<div class="m1">
				<table width="100%" border="0" cellspacing="0" cellpadding="0" class="tb1">
					<tr>
						<td class="t1"><strong>订单编号：</strong><asp:Literal ID="litOrderNum" runat="server"></asp:Literal></td>
						<td class="t2"><strong>订购时间：</strong><asp:Literal ID="litAddDate" runat="server"></asp:Literal></td>
					</tr>
				</table>
				<table width="100%" border="0" cellspacing="0" cellpadding="0" class="tb2">
					<tr>
						<td class="t1"><strong>客户姓名：</strong><asp:Literal ID="litCustomName" runat="server"></asp:Literal></td>
						<td class="t2"><strong>联系方式：</strong><asp:Literal ID="litPhoneNum" runat="server"></asp:Literal></td>
					</tr>
				</table>
				<table width="100%" border="0" cellspacing="0" cellpadding="0" class="tb3">
					<tr>
						<td class="t8"><strong>客户地址：</strong><asp:Literal ID="litAddress" runat="server"></asp:Literal></td>
				    </tr>
				</table>
			</div>
			<div class="m2">
				<table width="98%" border="0" cellspacing="0" cellpadding="0" class="tb4">
					
                    <asp:Repeater ID="rptItemList" runat="server">
                        <HeaderTemplate>
                        <tr>
						<th class="t3">商品编号</th>
						<th class="t4">商品名称</th>
						<th class="t5">数量</th>
						<th class="t7">商品金额</th>
				    </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                        <tr>
							<td><%# Eval("sku") %></td>
							<td><div class="p-name"><%# Eval("productname") %></div></td>
							<td><%# Eval("quantity") %></td>
							<td>&yen;<%# int.Parse(Eval("quantity").ToString())*decimal.Parse(Eval("memberprice").ToString())%></td>
				    	</tr>
                        </ItemTemplate>
                    </asp:Repeater>	
                    </table>
                <div style="height:10px;"></div>
                <table width="98%" border="0" cellspacing="0" cellpadding="0" class="tb4">
                    <asp:Repeater ID="RepCredits" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <th colspan="4" align="left" style="padding-left:10px; font-weight:bold;">积分兑换列表</th>
                            </tr>
                            <tr><th style="width:200px;">
                                                序号
                                            </th>
                                            <th style="width:360px;" colspan="2">
                                                名称
                                            </th>
                                            <th style="width: 80px;">
                                                数量
                                            </th></tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr><td style="width:80px;">
                                                <%# Container.ItemIndex+1 %>
                                            </td>
                                            <td style="width:360px;" colspan="2">
                                                <a href="<%#ShopLinkApi.JiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("CreditProductID")) %>" target="_blank"><%# Eval("ProductName")%></a>
                                            </td>
                                            <td style="width: 80px;">
                                                <%# Eval("quantity") %>
                                            </td></tr>
                        </ItemTemplate>
                    </asp:Repeater>					
											    </table>
	    </div>
    <div class="m3" style="width:98%;">
	    <div class="d1">
	    商品总金额：<asp:Literal ID="litGoodsPrice" runat="server"></asp:Literal>
	    </div>
	    <div class="d2"><strong>订单支付金额：&yen;<asp:Literal ID="litPayPrice" runat="server"></asp:Literal></strong></div>
    </div>
    </div>
       	    <div class="v-h"><input name="" type="button" value="打印" onclick="javascript: window.print();" /></div>
   </div>
</div>  
<span runat="server" id="datacount"></span>
</body>
</html>