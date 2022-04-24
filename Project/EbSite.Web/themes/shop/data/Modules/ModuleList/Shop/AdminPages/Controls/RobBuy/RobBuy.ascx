<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RobBuy.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.RobBuy.RobBuy" %>
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
			<asp:TemplateField HeaderText="商品名称">
				<ItemTemplate>
					<%--<%#EbSite.BLL.NewsContent.GetModel(int.Parse(Eval("ProductId").ToString())).NewsTitle%>--%>
                    	<%#Eval("title")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="开始时间">
				<ItemTemplate>
                <%#Eval("StartDate")%>
				</ItemTemplate>
			</asp:TemplateField>
		
			<asp:TemplateField HeaderText="结束日期">
				<ItemTemplate>
					<%#Eval("EndDate")%>
				</ItemTemplate>
			</asp:TemplateField>
          	<asp:TemplateField HeaderText="抢购价格">
				<ItemTemplate>
					<%#Eval("CountDownPrice")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="活动说明">
				<ItemTemplate>
					<%#Eval("Content")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					<XS:EasyuiDialog LinkOnly="True" ID="wbModify"   Title="修改" Text="修改" runat="server"/>
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