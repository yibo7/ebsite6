<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserMenu_Roles.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Menu.UserMenu_Roles" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<XS:PagesContrl ID="pcPage" runat="server" />
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>给用户组分配模块菜单权限</h3>
            操作流程:选择角色->分配权限
            </div>
            <div class="content">
				  <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="GroupName">
                    <Columns>

                        <asp:TemplateField HeaderText="序号" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <div style="text-align: center;"><%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="用户组名称" ItemStyle-CssClass="gvfisrtTD">
                            <ItemTemplate>
                                <%#Eval("GroupName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="<%$Resources:lang,
        EBGroupId%>" />
                        <asp:BoundField DataField="CreditShigher" HeaderText="<%$Resources:lang,
        EBIntegrationUpL%>" />
                        <asp:BoundField DataField="CreditSlower" HeaderText="<%$Resources:lang,
        EBIntegrationLowerL%>" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <a href='<%# string.Format("?t=6&rid={0}&name={1}",Eval("id"),Eval("GroupName"))%>'>分配权限</a>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </XS:GridView>
            </div>
    </div>
</div>