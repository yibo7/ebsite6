<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemesList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.ThemesList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
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
                        <asp:TemplateField HeaderText="皮肤名称">
                            <ItemTemplate>
                                <%#Eval("ThemeName")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="英文名称">
                            <ItemTemplate>
                                <%#Eval("ThemePath")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="皮肤分类">
                            <ItemTemplate>
                                <%#SpaceThemeName(int.Parse(Eval("ThemeClassID").ToString()))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="作者">
                            <ItemTemplate>
                                <%#Eval("Author")%>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <XS:EasyuiDialog Title="编辑样式" SaveText="保存样式" Text="编辑样式" runat="server" Href='<%#GetUrl+string.Concat("&t=3&fn=",Eval("ThemePath"))%>' />
                                <XS:EasyuiDialog Title="编辑母板" SaveText="保存母板" Text="编辑母板" runat="server" Href='<%#GetUrl+string.Concat("&t=2&fn=",Eval("ThemePath"))%>' />
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
