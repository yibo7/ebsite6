<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentApi.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Payment.PaymentApi" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %> 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>支付插件管理</h3>
            如果没有适合您的支付插件，请自行开发，到插件管理中安装
            </div>
            <div class="eb-content">
				<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="Name">
                    <Columns>
                        <asp:TemplateField HeaderText="序号" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <div style="text-align: center;"><%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="插件名称" ItemStyle-CssClass="gvfisrtTD">
                            <ItemTemplate>
                                <%#Eval("Description")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="状态" ItemStyle-CssClass="gvfisrtTD">
                            <ItemTemplate>
                                <%#bool.Parse(Eval("Enabled").ToString()) ? " 启用 " : " <font color=red>禁用</font> "%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="类型"></asp:BoundField>
                        <asp:BoundField DataField="Version" HeaderText="版本"></asp:BoundField>
                        <asp:TemplateField HeaderText="开发者">
                            <ItemTemplate>
                                <%#Eval("Author")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <a class="AdminLinkButton" href="Admin_Plugins.aspx?t=1&id=<%#Eval("Name")%>">设置插件</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </XS:GridView>
                 <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>