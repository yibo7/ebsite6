<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.StockAlarm.List" %>
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
            <asp:TemplateField HeaderText="订单编号">
				<ItemTemplate>
                    	<%#Eval("orderid")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="商品编号">
				<ItemTemplate>
                    	<%#Eval("sku")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="商品名称">
				<ItemTemplate>
                <%#Eval("ProductName")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="提交数量">
				<ItemTemplate>
                <%#Eval("SubmitQuantity")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="服务类型">
				<ItemTemplate>
                <%# GetServiceState(Eval("ServiceType"))%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="状态">
				<ItemTemplate>
                <%#GetRetrunState(Eval("ItemStatus"))%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="申请时间" ItemStyle-Width="160">
				<ItemTemplate>
                <%#Eval("ReturnDate")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作" ItemStyle-Width="130">
				<ItemTemplate>
					<XS:EasyuiDialog ID="wbShow"  Title="处理退换货" IsColseReLoad="true" Text="查看" runat="server" />
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</XS:GridView>
</div>
<div>
	 <XS:PagesContrl ID="pcPage" runat="server" />
</div>