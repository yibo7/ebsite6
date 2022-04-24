<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequestList.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.RequestGroup.RequestList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
        <Columns>
            <asp:TemplateField HeaderText="序号" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center"
                ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <div style="text-align: center;">
                        <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="团购商品名称">
                <ItemTemplate>
                    <%# GetProductName(Eval("productid").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="期望团购价格">
                <ItemTemplate>
                    &yen;<%# Eval("requestprice").ToString()%>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="是否已经通知">
                <ItemTemplate>
                    <%# Eval("isnotice").ToString().Equals("0")?"未通知":"已通知"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <XS:EasyuiDialog ID="wbShow" Title="查看" Text="查看" Width="800" Height="400" IsFull="true"
                        Href='<%# string.Concat(GetUrl,"&t=0&id=",Eval("productid"))%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
          
        </Columns>
    </XS:GridView>
</div>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
