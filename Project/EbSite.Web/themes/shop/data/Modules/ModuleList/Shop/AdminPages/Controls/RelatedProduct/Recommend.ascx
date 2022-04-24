<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Recommend.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.RelatedProduct.Recommend" %>
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
			<asp:TemplateField HeaderText="产品名称">
				<ItemTemplate>
					<%# Eval("Title").ToString()%>
				</ItemTemplate>
			</asp:TemplateField>
			
          
			 <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <XS:EasyuiDialog ID="wbModify" Title="修改" Text="修改/" Width="800" Height="400" IsFull="true"
                        Href='<%# string.Concat(GetUrl,"&t=2&id=",Eval("productid"))%>' runat="server" />
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("productid") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>
                 
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