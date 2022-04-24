<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Suppliers.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Supplier.Suppliers" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
	<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" >
		<Columns>
			 <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" > 
				 <ItemTemplate>
					 <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div> 
				 </ItemTemplate>
			 </asp:TemplateField>
			<asp:TemplateField HeaderText="供货商名称">
				<ItemTemplate>
					<%#Eval("SupplierName")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="负责人">
				<ItemTemplate>
					<%#Eval("ContactUser")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="手机号码">
				<ItemTemplate>
					<%#Eval("Phone")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="电话号码">
				<ItemTemplate>
					<%#Eval("Tel")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="地址">
				<ItemTemplate>
					<%#Eval("Adres")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					 <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>/
					<XS:EasyuiDialog ID="wbModify" Title="修改" Text="修改" runat="server"/>/
					<XS:EasyuiDialog ID="wbShow"  Title="详细内容" Text="详细内容" runat="server" />
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