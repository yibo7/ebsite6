<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LimitList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.LimitList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>


                <div class="alert alert-success m-t-15">操作流程:选择角色->分配权限,权限数据存放在模块的DataStore/Limits.txt里，可自行添加！ </div>

<div class="row">
    <div class="col-lg-12">
        <ul class="nav nav-tabs">
            <li class="active tab">
                <a href="#tg1" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">后台菜单权限</span>
                </a>
            </li>
            <li class="tab">
                <a href="Admin_Modules.aspx?t=23&mid=<%=GetModuleID %>" >
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">用户中心菜单权限</span>
                </a>
            </li>
        </ul>
        <div class="tab-content">
            <div id="tg1" class="tab-pane active">

                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>

                <div class="table-responsive" id="PagesMain">

                    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="RoleID">
                        <Columns>

                            <asp:TemplateField HeaderText="序号" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <div style="text-align: center;"><%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="角色名称" ItemStyle-CssClass="gvfisrtTD">
                                <ItemTemplate>
                                    <%#Eval("Description")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <XS:EasyuiDialog ID="EasyuiDialog1" runat="server" SaveText="保存权限配置" Href='<%# string.Format("?t=21&mid={0}&rid={1}&name={2}",GetModuleID,Eval("RoleID"),Eval("Description"))%>'
                                        Text="分配权限" Title="分配权限" />

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
