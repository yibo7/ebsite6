<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_AccountMoney.UserAccount" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>用户账款</h3>
            </div>
            <div class="content">
				            
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <table class="table">
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
                        账户总余额
                    </th>
                    <th scope="col">
                        提现冻结金额
                    </th>
                    <th scope="col">
                        可用余额
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
                        <%#EbSite.Base.Host.Instance.GetUserUserName(Convert.ToInt32( Eval("UserID")))%>
                    </td>
                    <td>
                        <%# Eval("UserID")%>
                    </td>
                    <td>
                        <%#Eval("Balance")%>
                    </td>
                    <td>
                        <%#Eval("RequestBalance")%>
                    </td>
                    <td>
                        <%#Convert.ToDecimal(Eval("Balance")) - Convert.ToDecimal(Eval("RequestBalance"))%>
                    </td>
                    <td>
                        <XS:EasyuiDialog ID="WinBox3" IsColseReLoad="true" runat="server" Width="500" Height="345" SaveText="确认加款" Href='<%# string.Concat(GetUrl,"&t=1&id=",Eval("id"),"&um=",Convert.ToDecimal(Eval("Balance")) - Convert.ToDecimal(Eval("RequestBalance")),"&uid=", Eval("UserID"))%>'
                            Text="加款" Title="加款" /> 
                         <a class="AdminLinkButton" href='<%#string.Format("?t=4&uid={0}",Eval("UserID"))%>'>明细</a>

                         <XS:EasyuiDialog ID="EasyuiDialog1" IsColseReLoad="false" runat="server" SaveText="确认修改交易密码" Width="500" Height="345" Href='<%# string.Concat(GetUrl,"&t=2&id=",Eval("id"),"&uid=", Eval("UserID"))%>'
                            Text="修改交易密码" Title="修改交易密码" /> 
                         
                         
                    </td>
                </tr>
            </ItemTemplate>
        </XS:Repeater>
    </table>
                <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>
 
