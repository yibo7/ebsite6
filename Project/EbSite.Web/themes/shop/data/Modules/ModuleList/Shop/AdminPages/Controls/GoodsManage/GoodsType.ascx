<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoodsType.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.GoodsManage.GoodsType" %>
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
		
			<asp:TemplateField HeaderText="商品类型名称">
				<ItemTemplate>
					<%#Eval("TypeName")%>
				</ItemTemplate>
			</asp:TemplateField>
			
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					
					<XS:EasyuiDialog ID="wbModify1"  Href='<%# string.Concat("?muid=e8b2cdd7-4299-497b-9215-a94e8c3a6c88&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=0&id=",Eval("id"))%>'  Title="修改" Text="修改" runat="server"/>
					 <XS:LinkButton ID="lbDelete" runat="server"     CommandArgument='<%#Eval("ID") %>' CommandName="DeleteModel" confirm="true" Tips_Msg="fdsafsa" Text="删除"></XS:LinkButton>
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
