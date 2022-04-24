<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassField.ascx.cs" Inherits="EbSite.Web.AdminHt.dialog.Controls.dialog.ClassField" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>


<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <ul class="nav nav-tabs">
                <XS:Repeater ID="RepClassModel" runat="server">
                    <ItemTemplate>
                        <li class="<%#Equals( Container.ItemIndex+1,1)?"active":"" %>">
                            <a href="#tg<%#Container.ItemIndex+1 %>" data-toggle="tab"><%#Eval("ModelName")%></a>
                        </li>
                    </ItemTemplate>
                </XS:Repeater>
            </ul>
            <div class="tab-content">

                <XS:Repeater ID="RepClassAll" runat="server" OnItemDataBound="rpList_ItemDataBound">
                    <ItemTemplate>
                        <div id="tg<%#Container.ItemIndex+1 %>" class="tab-pane fade <%#Equals( Container.ItemIndex+1,1)?"in active":"" %>">

                            <table class="table">
                                <XS:Repeater ID="RepClassField" runat="server">
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
                    </ItemTemplate>
                </XS:Repeater>
            </div>
        </div>
    </div>
</div>
