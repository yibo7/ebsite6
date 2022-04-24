<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderLog.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage.OrderLog" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>


    .form_table_input {
        margin-left: auto;
        margin-right: auto;
        margin-left: 0px;
        color: #222222;
        font-size: 9pt;
    }
        .form_table_input td {
            border-top-color: #828778;
            border-top-width: 1px;
            border-top-style: solid;
        }
            .form_table_input td span {
                color:red;
            }
</style>
<div class="headtitle">
    订单日志</div>
<div>
    <table width="99%" align="center" border="0" cellspacing="0" cellpadding="0" class="form_table_input">
        <tr style="line-height: 30px;">
            <th style="width: 10%">
                序号
            </th>
            <th style="width:54%;">
                记录内容
            </th>
            <th style="width: 10%;">
                操作人
            </th>
            <th style="width: 26%;">
                操作时间
            </th>
        </tr>
        <XS:Repeater ID="rpList" runat="server">
            <ItemTemplate>
                <tr style="line-height: 30px;">
                    <td style="width: 10%; text-align:center; ">
                        <%# Container.ItemIndex+1 %>
                    </td>
                    <td style="width: 54%;">
                        <%# Eval("opctent")%>
                    </td>
                     <td style="width: 10%;text-align:center;">
                        <%# Eval("opusername")%>
                    </td>
                    
                    <td style="width: 26%;text-align:center;">
                        <%# Eval("opdate")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <tr style="line-height: 30px;">
                    <td style="width: 10%">
                    </td>
                    <td style="width:54%;">
                    </td>
                      <td style="width: 10%;">
                    </td>
                    <td style="width: 26%">
                    </td>
                </tr>
            </FooterTemplate>
        </XS:Repeater>
    </table>
</div>
<div>
	 <XS:PagesContrl ID="pcPage" runat="server" PageSize="15" />
</div>