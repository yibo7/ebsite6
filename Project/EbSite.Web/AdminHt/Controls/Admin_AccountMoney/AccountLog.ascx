<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountLog.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_AccountMoney.AccountLog" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>付款日志</h3>
            </div>
            <div class="content">
				<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <table class="table" style="border:none" >
        <XS:Repeater ID="rpList" runat="server">
            <HeaderTemplate>
                <tr class="GridViewHeader">
                    <th scope="col">
                        序号
                    </th>
                    <th scope="col">
                        会员
                    </th>
                    <th scope="col">
                        会员ID
                    </th>
                    <th scope="col">
                        转入金额
                    </th>
                    <th scope="col">
                        手续费
                    </th>
                    <th scope="col">
                        添加日期
                    </th>
                    <th scope="col">
                        操作
                    </th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center" valign="middle" style="width: 50px;">
                        <%# (this.pcPage.PageIndex - 1) * this.pcPage.PageSize + Container.ItemIndex + 1%>
                    </td>
                    <td>
                        <%# Eval("UserName")%>
                    </td>
                    <td>
                        <%# Eval("UserID")%>
                    </td>
                    <td>
                        <%#Eval("Income")%>
                    </td>
                    <td>
                        <%# Eval("Free")%>
                    </td>
                    <td>
                      <%#Eval("AddDateTime")%> 
                    </td>
                    <td>
                      查看
                    </td>
                </tr>
            </ItemTemplate>
        </XS:Repeater>
    </table>
                <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>
 