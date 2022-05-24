<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menus.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.Menus" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="row m-t-15">
    <div class="col-lg-12">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="active nav-link" href="#tg1" data-bs-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">后台管理菜单</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="Admin_Modules.aspx?t=22&mid=<%=GetModuleID %>">
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">用户中心菜单</span>
                </a>
            </li>
        </ul>
        <div class="tab-content">
            <div id="tg1" class="tab-pane active">
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>

                <div class="table-responsive" id="PagesMain">
                    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnRowCommand="gdList_RowCommand">
                        <Columns>

                            <asp:TemplateField HeaderText="序号" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <div style="text-align: center;"><%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="菜单名称" ItemStyle-CssClass="gvfisrtTD">
                                <ItemTemplate>
                                    <%#Eval("PageName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="菜单路径">
                                <ItemTemplate>
                                    <%#Eval("FileName")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>

                                    <XS:EasyuiDialog ID="WinBox8" SaveText="保存菜单配置"  IsDialog="true" Width="500" runat="server" Href='<%# string.Concat("?t=14&id=",Eval("id"),"&mid=",GetModuleID,"&ctrPath=",Eval("FileName"))%>'
                                        Text="加入到主菜单" Title="加入到主菜单" />

                                    <XS:LinkButton ID="lbRemove" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="RemoveModel"
                                        confirm="true" Text="移出主菜单" ConfirmMsg="此操作将从菜单表中移出,请谨慎操作。"></XS:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </XS:GridView>
                </div>
                <div>
                    <XS:PagesContrl ID="pcPage" runat="server" />
                </div>
            </div>
        </div>
    </div>
</div>


