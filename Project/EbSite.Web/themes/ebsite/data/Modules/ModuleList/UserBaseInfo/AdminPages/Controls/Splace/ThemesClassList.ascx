<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemesClassList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.ThemesClassList" %>
<%@ Import Namespace="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
           
            <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
            <div id="PagesMain">
                <XS:GridView ID="gdList" runat="server" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="序号" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <div style="text-align: center;"><%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="网站名称">
                            <ItemTemplate>
                                <%#Eval("ClassName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="用户组">
                            <ItemTemplate>
                                <%#DefaultTabList.UserGroupName(int.Parse(Eval("UserGroupID").ToString()))%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="添加时间">
                            <ItemTemplate>
                                <%#Eval("AddTime")%>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>

                                <XS:EasyuiDialog ID="wbModify" Title="修改数据" Text="修改" runat="server" />
                                /
                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" Text="删除"></XS:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" runat="server" />
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
