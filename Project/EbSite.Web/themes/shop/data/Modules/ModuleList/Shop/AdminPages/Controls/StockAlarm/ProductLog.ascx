<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductLog.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.StockAlarm.ProductLog" %>

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
            <asp:TemplateField HeaderText="货号名称">
				<ItemTemplate>
					
                    	<%#Eval("PNumber")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="商品名称">
				<ItemTemplate>
                    	<%# GetProductName(Eval("ProductId"))%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText=" 操作人用户名">
				<ItemTemplate>
                <%#Eval("UserName")%>
				</ItemTemplate>
			</asp:TemplateField>
		
			<asp:TemplateField HeaderText="操作日期">
				<ItemTemplate>
                <%#Eval("AddDate")%>
				</ItemTemplate>
			</asp:TemplateField>
            
            <asp:TemplateField HeaderText="内容">
				<ItemTemplate>
                <%#Eval("Content")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="数量">
				<ItemTemplate>
					<%#Eval("Number")%>
				</ItemTemplate>
			</asp:TemplateField>
			
		</Columns>
	</XS:GridView>
</div>
<div>
	 <XS:PagesContrl ID="pcPage" runat="server" />
</div>