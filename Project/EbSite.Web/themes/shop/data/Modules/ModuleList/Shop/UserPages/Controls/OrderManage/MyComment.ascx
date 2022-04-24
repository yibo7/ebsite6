<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyComment.ascx.cs" Inherits="EbSite.Modules.Shop.UserPages.Controls.OrderManage.MyComment" %>
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
    }
    
    .User_manage
    {
        font-size: 14px;
        border-bottom: #4e91f4 2px solid;
        font-weight: bold;
        color: #2d6ace;
        padding-bottom: 2px;
        padding-top: 5px;
        padding-left: 5px;
        padding-right: 0px;
    }
    .User_manIcon
    {
        height: 16px;
        background: url(/images/menus/layers.png) no-repeat;
        float: left;
        padding-bottom: 0px;
        padding-top: 0px;
        padding-left: 3px;
        display: block;
        padding-right: 3px;
        width: 16px;
    }
    .bTop_Margin10
    {
        margin: 10px auto 0px;
    }
    .OrderDetails_table1
    {
        text-align: center;
        background-color: #e0dfdf;
    }
    .OrderDetails_table1 TH
    { text-align: center;
        height: 27px;
        font-weight: normal;
        color: #848383;
        padding-bottom: 0px;
        padding-top: 3px;
        padding-left: 0px;
        padding-right: 0px;
        background-color: #f3f3f3;
    }
    .OrderDetails_table1 TD
    {
        color: #1b1a1a;
        padding-bottom: 7px;
        padding-top: 7px;
        padding-left: 0px;
        padding-right: 0px;
        background-color: #fff;
    }
    .content_table_title
    {
        color: #a5a5a5;
        background-color: #f9f9f9;
    }
    .baja
    {
        background: url(<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>css/images/login_quick_sub.jpg) no-repeat;
        width: 87px;
        height: 30px;
    }
</style>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="Cblock">
        <div class="User_manage">
            <span class="User_manIcon"></span>订单详情</div>
        <table width="100%" border="0" cellspacing="1" cellpadding="0" class="bTop_Margin10 OrderDetails_table1">
            <tbody>
                <tr>
                    <th width="25%">
                        订单号
                    </th>
                    <th width="25%">
                        订单总金额
                    </th>
                    <th width="25%">
                        订单状态
                    </th>
                    <th width="25%">
                        下单时间
                    </th>
                </tr>
                <tr>
                    <td>
                        <%=Model.OrderId%>
                    </td>
                    <td>
                        <span id="OrderReviews_lbltotalPrice"><%=Model.OrderTotal %></span>
                    </td>
                    <td>
                        <span id="OrderReviews_lblOrderStatus"><%=EbSite.Modules.Shop.ModuleCore.BLL.Buy_Orders.Instance.ParseOrderState(Model.OrderStatus.ToString()) %></span>
                        <br>
                    </td>
                    <td>
                        <%=Model.OrderAddDate %>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="Cblock">
        <div class="User_manage">
            <span class="User_manIcon"></span>商品条目</div>
        <table cellspacing="0" border="0">
            <tbody>
                <tr class="GridViewHeaderStyle" style="color: #858585; text-align: left;">
                    <th class="content_table_title" width="60px">
                        商品图片
                    </th>
                    <th class="content_table_title" width="130px">
                        货号
                    </th>
                    <th class="content_table_title" width="350px">
                        商品名称
                    </th>
                    <th class="content_table_title" width="290px">
                        评论
                    </th>
                </tr>
                <XS:Repeater ID="gdList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="hidden"   value="">
                                <a  href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID)%>" target="_blank">
                                    <img src="<%#Eval("thumbnailsurl") %>" style="height: 60px; width: 60px; border-width: 0px;"></a>
                            </td>
                            <td>
                               <%#Eval("sku") %>&nbsp;
                            </td>
                            <td>
                                <a  href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID)%>" target="_blank"><%#Eval("productname") %></a>
                                <br>
                               <%#Eval("skucontent") %>
                                <br>
                               
                            </td>
                            <td>
                                <textarea  rows="3" cols="30"></textarea>
                            </td>
                        </tr>
                    </ItemTemplate>
                </XS:Repeater>
            </tbody>
        </table>
        <div class="">
            货物总重量：<span class=""><%=Model.Weight %>克</span>
        </div>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" CssClass="baja" Text=" 提交评论 " />
</div>
