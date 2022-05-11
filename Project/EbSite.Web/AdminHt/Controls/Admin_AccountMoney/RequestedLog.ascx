<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequestedLog.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_AccountMoney.RequestedLog" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>支付请求日志</h3>
            </div>
            <div class="eb-content">
				<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                 <table class="table">
        <XS:Repeater ID="rpList" runat="server">
            <HeaderTemplate>
                <tr class="GridViewHeader">
                    <th scope="col">
                        序号
                    </th>
                    <th scope="col">
                        用户名
                    </th>
                    <th scope="col">
                        时间
                    </th>
                    <th scope="col">
                        类型
                    </th>
                    <th scope="col">
                       收入
                    </th>
                    <th scope="col">
                       支出
                    </th>
                    <th scope="col">
                       账户余额
                    </th>
                     <th scope="col">
                       备注
                    </th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center" valign="middle" style="width: 50px;">
                        <%# (this.pcPage.PageIndex - 1) * this.pcPage.PageSize + Container.ItemIndex + 1%>
                    </td>
                    <td>
                        <%#EbSite.Base.Host.Instance.GetUserUserName(Convert.ToInt32( Eval("UserID")))%>
                    </td>
                    
                    <td>
                        <%#Eval("tradedate")%>
                    </td>
                    <td>
                        <%#EbSite.BLL.AccountMoneyType.GetAccountMoneyTypeName(Eval("TradeType").ToString())%>
                    </td>
                    <td>
                        <%#Eval("income")%>
                    </td>
                    <td>
                        <%#Eval("expenses")%>
                    </td>
                    <td>
                       <%#Eval("balance")%>
                    </td>
                     <td>
                       <%#Eval("remark")%>
                    </td>
                </tr>
            </ItemTemplate>
        </XS:Repeater>
    </table>
                <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>
 