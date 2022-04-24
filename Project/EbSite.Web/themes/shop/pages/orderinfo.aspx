<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.orderinfo" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单详情</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<link type="text/css" href="<%=base.ThemeCss %>/shoporder.css" rel="stylesheet" />
<body>
    <script runat="server">

        protected string temStateStep = string.Concat("<img src=\"", EbSite.Base.Host.Instance.ThemePath, "css/images/{0}.png\" /><div class=\"jtwenzi\"><li>{1}</li><li>{2}</li><li>{3}</li><li>{4}</li><li>{5}</li></div>");

        public string GetStateStep()
        {
            string html = string.Empty;
            //订单状态 0提交订单 1审核订单 2等待付款 21支付款 3已发货 4确认收货 5交易完成
            int Status = Model.OrderStatus;
            int PayModel = Model.PaymentTypeId;

            string Tips2 = (PayModel == -1) ? GetStatusTips(1) : ((Model.OrderStatus>2)?GetStatusTips(21):GetStatusTips(2));
            
            DateTime? dtStep2 = (PayModel == -1) ? Model.ReviewedOrderDate : Model.PayDate;
            string img = "orderprocess" + Status;
            if (Status == 0)
            {
                img = "orderprocess1";
            }
            if (Status == 1)
            {
                img = "orderprocess2";
            }

            if (Status == 6)
            {
                Tips2 = GetStatusTips(Status);
                dtStep2 = Model.DelOrderDate;
            }

            string subTem = "{0}<br/><span>{1}</span>";
            html = string.Format(temStateStep, img,
                string.Format(subTem, GetStatusTips(0), Model.OrderAddDate),
                string.Format(subTem, Tips2, dtStep2),
                string.Format(subTem, GetStatusTips(3), Model.SendDate),
                string.Format(subTem, GetStatusTips(4), Model.SureReceiptDate),
                string.Format(subTem, GetStatusTips(5), Model.FinishDate));


            return html;
        }
    </script>
    <!--#include file="header.inc"-->
    <div class="content">
        <div class="container">
            <div class="navtitle">
                <li style="font-size: 16px;"><b>
                    <%=SiteName %></b>&nbsp;>&nbsp;</li><li>订单中心&nbsp;>&nbsp;</li><li>订单：<%=Model.OrderId%></li>
            </div>
            <div class="bankimg ordrnum">
                <div class="ornumtop">
                    <li><b>&nbsp; 订单号：<%=Model.OrderId%>
                        状态：<span><%=Model.OrderStatusText %></span>
                        <!--如果定单状态为0也就是等待买家付款，同时支付状态不是货到付款的话，输出去付款的连接-->
                        <% if (Model.OrderStatus == 0 && Model.PaymentTypeId != -1)
                           { %>
                        <a href="<%=ShopLinkApi.GoToPayUrl(GetSiteID,Model.OrderId) %>">
                            <img src="<% =ThemeCss%>images/btn2.jpg" /></a> <a href="javascript:helppay()"><font
                                color="#005AA5">请别人代付</font></a>
                        <%}%>
                    </b></li>
                    <li class="r"><a href="javascript:void(0);"  onclick="CloseOrderPage()">
                        <%=Model.OrderStatus==0?"取消订单 |":"" %></a> <a href="/printorder-3-<%=Model.id %>.ashx"
                            target="_blank">订单打印</a> </li>
                </div>
                <div class="ornumbot">
                    <li>
                        <%=OrderStateMark%></li>
                </div>
            </div>
            <div class="jtimg">
                <%=GetStateStep() %>
            </div>
            <div class="bankimg" style="background: none;">
                <div id="divOrderState" class="bakimtitle2">
                    <li name="tg1" class="cur">订单跟踪</li>
                    <li name="tg2">物流配送状态查询</li>
                </div>
                <!--订单跟踪-->
                <div id="tg1" class="dealinfo">
                    <div class="dealtitle">
                        <li style="width: 147px;"><b>处理时间</b></li>
                        <li style="width: 482px;"><b>处理信息</b></li>
                        <li style="width: 290px;"><b>操作人</b></li>
                    </div>
                    <asp:Repeater ID="orderrecod" runat="server">
                        <ItemTemplate>
                            <div class="dealtitle" style="border-bottom: none;">
                                <li style="width: 147px;">
                                    <%# Eval("OpDate") %></li>
                                <li style="width: 482px;">
                                    <%# Eval("OpCtent") %></li>
                                <li style="width: 290px;">
                                    <%# Eval("OpUserName") %></li>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <!--物流配送状态查询-->
                <div id="tg2" class="dealinfo">
                    <div>
                        运单号:<%=MKuaiDi.Number%><br />
                        <br />
                        配送状态:<%=MKuaiDi.State%><br />
                        <br />
                    </div>
                    <div class="dealtitle">
                        <li style="width: 147px;"><b>处理时间</b></li>
                        <li style="width: 300px;"><b>操作信息</b></li>
                    </div>
                    <asp:Repeater ID="rpKuaiDi" runat="server">
                        <ItemTemplate>
                            <div class="dealtitle" style="border-bottom: none;">
                                <li style="width: 147px;">
                                    <%# Eval("Time")%></li>
                                <li style="width: 300px;">
                                    <%# Eval("Context")%></li>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div style='<%=rpKuaiDi.Items.Count>0?"display:none": ""%>; padding: 10px; color: #ff0000;'>
                                没有状态或查询运单状态没有正确返回结果！</div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="ordinfo">
                <div class="zfwcline" style="border-bottom: none">
                    <li class="color63"><b>订单信息</b></li></div>
                <div class="infocen">
                    <div class="sentinfo">
                        <li><b>收货人信息</b></li>
                        <li>收货人：<%=Model.SendToUserName %>
                        </li>
                        <li>地址：<%=Model.Address %></li>
                        <li>固定电话：<%=Model.TelPhone %></li>
                        <li>手机号码：<%=Model.CellPhone %></li>
                        <li>电子邮件：<%=Model.EmailAddress %></li>
                    </div>
                    <div class="sentinfo">
                        <li><b>支付及配送方式</b></li>
                        <li>支付方式：<%=Model.PaymentType %></li>
                        <li>配送方式：<%=Model.ModeName %></li>
                        <li>运费：<font color="#ff0000">&yen;<%=Model.Freight %></font></li>
                        <li>说明：<%=Model.Remark %></li>
                    </div>
                        <asp:Repeater ID="orderItem" runat="server">
                            <HeaderTemplate>
                                 <div class="sentinfo" style="border-bottom: none;">
                                    <li><b>商品清单</b></li></div>
                                <div class="shoplistit">
                                    <li style="width: 88px;">序号</li>
                                    <li style="width: 373px;">商品名称</li>
                                    <li style="width: 100px;">价格</li>
                                    <li style="width: 100px;">商品数量</li>
                                    <li style="width: 100px;">库存状态</li>
                                </div>
                                <div class="shoplistit shopnone">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li style="width: 88px;">
                                    <%# Container.ItemIndex+1 %></li>
                                <li style="width: 373px;"><a target="_blank" href='<%# HostApi.GetContentLink(Eval("ProductId"),0)%>'>
                                    <%# Eval("ProductName")%></a></li>
                                <li style="width: 100px;"><span>&yen;<%# Eval("TotalRealSellPrice")%></span></li>
                                <li style="width: 100px;">
                                    <%# Eval("quantity") %></li>
                                <li style="width: 100px;">现货</li>
                            </ItemTemplate>
                            <FooterTemplate></div></FooterTemplate>
                        </asp:Repeater>
                    
                    <asp:Repeater ID="rptCoreOrder" runat="server">
                        <HeaderTemplate>
                            <div class="sentinfo" style="border-bottom: none;">
                                <li><b>积分兑换清单</b></li></div>
                            <div class="shoplistit">
                                <li style="width: 88px;">序号</li>
                                <li style="width: 573px;">商品名称</li>
                                <li style="width: 100px;">商品数量</li>
                            </div>
                            <div class="shoplistit shopnone">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li style="width: 88px;">
                                <%# Container.ItemIndex+1 %></li>
                            <li style="width: 573px;"><a href="<%#ShopLinkApi.JiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("CreditProductID")) %>"
                                target="_blank">
                                <%# Eval("ProductName")%></a></li>
                            <li style="width: 100px;">
                                <%# Eval("quantity") %></li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div style="height: 10px;">
                        &nbsp;</div>
                </div>
                <div class="procount">
                    <li>
                        <div class="proconl">
                            商品总额:
                        </div>
                        <dl>
                            &yen;<%=Model.Amount %></dl>
                    </li>
                    <li>
                        <div class="proconl">
                            +运费:
                        </div>
                        <dl>
                            &yen;<%=Model.Freight %></dl>
                    </li>
                    <li>
                        <div class="proconl">
                            -优惠:
                        </div>
                        <dl>
                            &yen;<%=Model.DiscountAmount %></dl>
                    </li>
                    <li>
                        <div class="proconl">
                            +支付手续费:
                        </div>
                        <dl>
                            &yen;<%=Model.PayFree %></dl>
                    </li>
                    <li>
                        <div class="proconl">
                            +订单选项费用:
                        </div>
                        <dl>
                            &yen;<%=Model.OptionPrice %></dl>
                    </li>
                </div>
                <div class="countall">
                    <li>应付金额：<span>&yen;<%=Model.OrderTotal %></span></li></div>
            </div>
            <!---订单信息--->
        </div>
    </div>
    <!--#include file="footer.inc"-->
    <span runat="server" id="datacount"></span>
    <!--找人代付-->
    <div style="display: none">
        <div id="divHelpPay">
            <div>
                请将以下链接发给好友，完成代付：
            </div>
            <div style="width: 500px; height: 28px; line-height: 28px;margin: 10px;">
                
                <a  id="divHelpPayUrl" target="_blank" href="<%=ShopLinkApi.GoToPayUrlHelp(GetSiteID,Model.OrderId)%>">
                    <%=ShopLinkApi.GoToPayUrlHelp(GetSiteID,Model.OrderId)%>
                </a>
            </div>
            <div>
                <input type="button" style="border: #C23033 solid 1px; background: #E2383B; padding: 5px;
                    color: #fff;" onclick="CopyObText(divHelpPayUrl)" value="复制链接" />
            </div>
        </div>
    </div>
    <!--end找人代付-->
    <!--取消订单-->
   <div style="display: none">
        <div id="divCloseOrder">
            <ifram>
            <div class="tipetitle">取消订单</div>
            <table>
                <tr><th>原因:</th>
                <td>
                     <textarea id="txtRea" rows="6" cols="39"></textarea>
                </td>
                </tr>
                <tr><th></th>
                <td style="color:red;">请注意:若使用的优惠券,不能退回,请慎重选择。</td></tr><tr><th></th>
                <td align="center"><input type="button" value=" 确定 " onclick="CloseOrder(<%=Model.id%>)" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" value=" 取消 " onclick="closefancybox()" />
                </td></tr>
             </table>
            </ifram>
        </div>
       
 </div>

    <!--end取消订单-->
</body>
</html>
<script type="text/javascript">
    In.ready('customtags', function() {
        var Tags = new CustomTags();
        Tags.ParentObjName = "divOrderState";
        Tags.SubObj = "li";
        Tags.CurrentClassName = "cur";
        Tags.ClassName = "";

        Tags.InitOnclickInTags();
        Tags.InitOnclick(0);
    });
    //关闭订单
    function CloseOrderPage() {
        clwindiv("divCloseOrder");
    }
    function CloseOrder(id) 
    {
        if (window.confirm("确定要取消此订单吗？")) {
            var tmpRea = $.trim($("#txtRea").val());
            if (tmpRea != "" && tmpRea != undefined) {
                runws("cfccc599-4585-43ed-ba31-fdb50024714b", "PageCloseOrder", { "id": id, "strRea":tmpRea}, function (data) {
                    var result = data.d;
                    if (result == 1 || result == "1") {
                        alert("操作成功,订单已取消!");
                    }
                    else {
                        alert("操作失败，当前状态不能取消订单");
                    }
                });
            }
            else {
                alert("原因不能为空");
            }
        }
    }

    function helppay() {
        clwindiv("divHelpPay");
    }
</script>
