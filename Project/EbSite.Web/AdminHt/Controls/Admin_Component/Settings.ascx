<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Component.Settings" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %> 
<div id="ErrorMsg" runat="server" style="color: Red; padding: 5px 0 5px 0; display: block;"></div>
<div id="InfoMsg" runat="server" style="color: Green; padding: 5px 0 5px 0; display: block;"></div>
<div class="container-fluid mt10">
    <div class="row-fluid">

        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" data-toggle="tab" href="#tg1">
                    <span class="visible-xs"><i class="fa fa-edit"></i></span>
                    <span class="hidden-xs">参数设置</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-toggle="tab" href="#tg2">
                    <span class="visible-xs"><i class="fa fa-database"></i></span>
                    <span class="hidden-xs">数据</span>
                </a>
            </li>
        </ul>

    </div>
    <div class="tab-content cbrowbox-tab">
        <div id="tg1" class="tab-pane container active">

            <table>
                <tr>
                    <td>
                        <asp:PlaceHolder ID="phAddForm" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; padding-top: 10px;">
                        <XS:Button runat="server" ID="btnAdd" ValidationGroup="new" />

                        <asp:Label ID="lbAddLink" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="tg2" class="tab-pane container table-responsive">
            <div id="tipsInfo" runat="server" class="alert alert-info">此组件不是数据表配置组件。</div>
            <XS:GridView ID="grid"
                runat="server"
                AutoGenerateColumns="False"
                CellPadding="3"
                AllowPaging="True"
                AllowSorting="True"
                OnPageIndexChanging="grid_PageIndexChanging"
                OnRowDataBound="grid_RowDataBound">
            </XS:GridView>
        </div>
    </div>
</div>
