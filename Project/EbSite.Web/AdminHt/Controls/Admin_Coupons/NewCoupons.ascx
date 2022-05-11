<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewCoupons.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Coupons.NewCoupons" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>新建优惠券</h3>
            </div>
            <div class="eb-content">
				<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
        <Columns>
            <asp:TemplateField HeaderText="序号" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center"
                ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <div style="text-align: center;">
                        <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="优惠券名称">
                <ItemTemplate>
                    <%#Eval("CouponName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="结束日期">
                <ItemTemplate>
                    <%#Eval("EndDateTime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="满足金额">
                <ItemTemplate>
                    <%#Eval("Amount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="可抵扣金额">
                <ItemTemplate>
                    <%#Eval("DiscountPrice")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="总数量">
                <ItemTemplate>
                    <%#Eval("SentCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="已使用数量">
                <ItemTemplate>
                    <%#Eval("UsedCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="兑换所需积分">
                <ItemTemplate>
                    <%#Eval("NeedPoint")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <XS:EasyuiDialog ID="wbModify" Title="修改" Text="修改" runat="server" />
                    <XS:EasyuiDialog ID="wbShow"  Title="详细内容" Text="详细内容" runat="server" />
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>
                    <XS:EasyuiDialog ID="WinBox3" IsColseReLoad="true" runat="server" Href='<%# string.Concat(GetUrl,"&t=3&id=",Eval("id"))%>'
                        Text="发送给会员" Title="发送给会员" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)">
                <ItemTemplate>
                    <asp:CheckBox ID="Selector" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </XS:GridView>
                <XS:PagesContrl ID="pcPage" runat="server" />
            </div>
    </div>
</div>
 