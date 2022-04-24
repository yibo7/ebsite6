<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PluginSetting.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Plugins.PluginSetting" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
       <div class="container-fluid mt10">
	<div class="row-fluid"> 
            <ul class="nav nav-tabs">
                <li class="active tab">
                    <a href="#tg1" data-toggle="tab" aria-expanded="false">
                        <span class="visible-xs"><i class="fa fa-cogs"></i></span>
                        <span class="hidden-xs">插件设置</span>
                    </a>
                </li>
                <li class="tab">
                    <a href="#tg2" data-toggle="tab" aria-expanded="false">
                        <span class="visible-xs"><i class="fa fa-database"></i></span>
                        <span class="hidden-xs">数据列表</span>
                    </a>
                </li>
                <li class="tab">
                    <a href="#tg3" data-toggle="tab" aria-expanded="false">
                        <span class="visible-xs"><i class="fa fa-lightbulb-o"></i></span>
                        <span class="hidden-xs">使用帮助</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content cbrowbox-tab">
                <div id="tg1" class="tab-pane active">
                    <table>
                        <tr>
                            <td>插件名称:</td>
                            <td>
                                <asp:Label ID="lbPluginName" runat="server"></asp:Label>
                                (<asp:Label ID="lbTypeName" runat="server"></asp:Label>)
                            </td>

                        </tr>
                        <tr>
                            <td>配置信息:</td>
                            <td>

                                <asp:PlaceHolder ID="phAddForm" runat="server"></asp:PlaceHolder>

                            </td>

                        </tr>
                        <tr>
                            <td>插件设置:</td>
                            <td style="padding: 10px;">
                                <XS:Button ID="bntEnabledPlugin" OnClick="bntEnabledPlugin_OnClick" runat="server" Confirm="true" Text=" 禁 用 " />
                                &nbsp;&nbsp;
                        <XS:Button ID="bntDelPlugin" runat="server" OnClick="bntDelPlugin_OnClick" Confirm="true" Text=" 卸 载 " />
                            </td>

                        </tr>
                       
                    </table>
                </div>
                <div id="tg2" class="tab-pane">
                    <div id="rzInfo" runat="server" visible="False" class="alert alert-info">此插件不是数据集类型的插件。</div>
                    <div class="table-responsive">
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
                <div id="tg3" class="tab-pane">
                    <asp:Label ID="lbHelp" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="text-center mt10">
        <XS:Button ID="btnAdd" runat="server" Text=" 保 存 " />
    </div>
    
                     


</asp:PlaceHolder>

<script>

    jQuery(function ($) {
        $("#divHelp").click();
    });

</script>
