﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gift.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Gift.Gift" %>
<%@ Import Namespace="EbSite.Modules.Shop" %>
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
			<asp:TemplateField HeaderText="购买产品名称">
				<ItemTemplate>
					<%#EbSite.Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse( Eval("BuyProductId").ToString()),SettingInfo.Instance.GetSiteID).NewsTitle%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="赠品产品名称">
				<ItemTemplate>
                <%#EbSite.Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(Eval("GiftProductId").ToString()), SettingInfo.Instance.GetSiteID).NewsTitle%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="数量">
				<ItemTemplate>
					<%#Eval("Quantity")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="结束日期">
				<ItemTemplate>
					<%#Eval("EndDateTime")%>
				</ItemTemplate>
			</asp:TemplateField>
          
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					<XS:EasyuiDialog ID="wbModify" Title="修改" Text="修改" runat="server"/>
                    					 <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
					<%--<XS:EasyuiDialog ID="wbShow"  Title="详细内容" Text="详细内容" runat="server" />--%>
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