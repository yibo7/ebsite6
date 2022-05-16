<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleConfigs.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.ModuleConfigs" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row m-t-15">
    <div class="col-lg-12">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="active nav-link" href="#tg1" data-bs-toggle="tab">
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">模块信息</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#tg2" data-bs-toggle="tab">
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">配置选项</span>
                </a>
            </li>
        </ul>
        <div class="tab-content">
            <div id="tg1" class="tab-pane active">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td><b><%=Resources.lang.EBModelName %>:</b></td>
                        <td>
                            <%=Model.ModuleName %>
                        </td>
                    </tr>
                    <tr>
                        <td><b>出品单位:</b></td>
                        <td>
                            <%=Model.Author %>
                        </td>
                    </tr>
                    <tr>
                        <td><b>单位主页:</b></td>
                        <td>
                            <%=Model.AuthorUrl %>
                        </td>
                    </tr>
                    <tr>
                        <td><b>版本号:</b></td>
                        <td>
                            <%=Model.Version %>
                        </td>
                    </tr>
                    <%-- <tr>
                <td><b>是否关闭模块:</b></td>
                <td>
                    <XS:CheckBox ID="cbIsClose" runat="server" />
                </td>
            </tr>--%>
                    <%--<tr>
                <td><b>关闭通知:</b></td>
                <td>
                    <XS:TextBoxVl ID="ColseInfo" Height="100" Width="300" Msg="关闭模块后的通知信息" runat="server"></XS:TextBoxVl>
                </td>
            </tr>--%>
                    <tr>
                        <td><b>模块简介:</b></td>
                        <td>
                            <%=Model.Demo %>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="tg2" class="tab-pane">
                <div runat="server" id="phEdit"></div>
            </div>
        </div>
    </div>
</div>
<div style="text-align: center; padding-top: 10px;">
    <XS:Button ID="bntSave" OnClick="btnSave_Click" runat="server" Text=" 保 存 " />
</div>
