<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentField.ascx.cs"
    Inherits="EbSite.Web.AdminHt.dialog.Controls.dialog.ContentField" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <ul class="nav nav-tabs">
                <XS:Repeater ID="RepContentModel" runat="server">
                    <ItemTemplate>
                        <li class="nav-item">
                            <a class="nav-link <%#Equals( Container.ItemIndex+1,1)?"active":"" %>" href="#tg<%#Container.ItemIndex+1 %>" data-toggle="tab"><%#Eval("ModelName")%></a>
                        </li>
                    </ItemTemplate>
                </XS:Repeater>
            </ul>
            <div class="tab-content">
                <XS:Repeater ID="RepContentAll" runat="server" OnItemDataBound="rpList_ItemDataBound">
                    <ItemTemplate>
                        <div id="tg<%#Container.ItemIndex+1 %>" class="tab-pane <%#Equals( Container.ItemIndex+1,1)?"active":"" %>">
                            <div class="table-responsive">
                            <table class="table table-hover">
                                <XS:Repeater ID="RepContentField" runat="server">
                                    <HeaderTemplate>
                                        <tr>
                                            <th scope="col">显示名称
                                            </th>
                                            <th scope="col">模板调用方式
                                            </th>
                                            <th scope="col">数据集控件模板绑定方式
                                            </th>
                                            <th scope="col">操作
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("ColumShowName")%>
                                            </td>
                                            <td>
                                                <%#Eval("BindCoreForPageTemAdv")%>
                                            </td>
                                            <td>
                                                <%#Eval("BindCoreForCtrTem")%>
                                            </td>
                                            <td>
                                                <a href="#" name='<%#Eval("BindCoreForPageTemAdv")%>' onclick="infield(name)">插入
                                                </a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </XS:Repeater>
                            </table>
                            </div>
                        </div>
                    </ItemTemplate>
                </XS:Repeater>
            </div>
        </div>
    </div>
</div>


