<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuotaFree.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Promotions.QuotaFree" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
	<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" onrowdatabound="gdList_RowDataBound" >
		<Columns>
			 <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" > 
				 <ItemTemplate>
					 <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div> 
				 </ItemTemplate>
			 </asp:TemplateField>
			<asp:TemplateField HeaderText="促销活动名称">
				<ItemTemplate>
					<%#Eval("TitleName")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="促销信息">
				<ItemTemplate>
					<asp:Label ID="labProInfo" runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="适合的会员等级">
				<ItemTemplate>
					<asp:Label ID="labUerLeval" runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="促销活动类型">
				<ItemTemplate>
					满额免费用
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
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