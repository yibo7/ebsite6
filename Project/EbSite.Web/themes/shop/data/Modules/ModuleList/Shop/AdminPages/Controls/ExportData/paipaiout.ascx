<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paipaiout.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.ExportData.paipaiout" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
	<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="id" >
		<Columns>
         <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" > 
				 <ItemTemplate>
					 <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div> 
				 </ItemTemplate>
			 </asp:TemplateField>
			<asp:TemplateField HeaderText="id">
				<ItemTemplate>
					<%#Eval("id")%>
				</ItemTemplate>
			</asp:TemplateField>
            
            </Columns>
	</XS:GridView>
</div>
<div>
	 <XS:PagesContrl ID="pcPage" runat="server" />
</div>
