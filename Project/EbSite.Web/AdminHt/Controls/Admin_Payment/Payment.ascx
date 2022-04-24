<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Payment.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Payment.Payment" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>管理支付方式</h3>
            </div>
            <div class="content">
				 <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                 <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="id">
                    <Columns>
                        <asp:TemplateField HeaderText="序号" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <div style="text-align: center;"><%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="支付方式名称" ItemStyle-CssClass="gvfisrtTD">
                            <ItemTemplate>
                                <%#Eval("PaymentName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="demo" HeaderText="分类"></asp:BoundField>
                        <asp:BoundField DataField="UseMoney" HeaderText="使用费用"></asp:BoundField>
                        <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <%#bool.Parse(Eval("IsOpend").ToString()) ?  " 启用 ":" <font color=red>关闭</font> " %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否百分比">
                            <ItemTemplate>
                                <%#bool.Parse(Eval("IsPercent").ToString()) ? " <font color=red>是</font> " : " 否 "%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否用于预付款">
                            <ItemTemplate>
                                <%#bool.Parse(Eval("IsUseInpour").ToString()) ? " <font color=red>是</font> " : " 否 "%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <XS:EasyuiDialog ID="wbModify" Title="修改数据" Text="修改" runat="server" />
                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" Text="删除"></XS:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </XS:GridView>
                <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>
