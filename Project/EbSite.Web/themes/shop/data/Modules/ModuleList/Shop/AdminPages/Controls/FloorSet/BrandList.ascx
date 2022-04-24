<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrandList.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.FloorSet.BrandList" %>
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
			<asp:TemplateField HeaderText="品牌标题">
				<ItemTemplate>
					<%#Eval("BrandTitle")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="链接地址">
				<ItemTemplate>
               <%#Eval("BrandUrl")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="图片">
				<ItemTemplate>
               <img width="80" height="60" src="<%#Eval("BrandPicUrl")%>" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					<XS:EasyuiDialog ID="wbModify" LinkOnly="True"  Title="修改" Text="修改" runat="server"/>
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