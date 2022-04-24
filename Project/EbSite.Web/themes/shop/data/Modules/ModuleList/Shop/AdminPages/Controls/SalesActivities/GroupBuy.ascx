<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupBuy.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.SalesActivities.GroupBuy" %>
<%@ Import Namespace="EbSite.Modules.Shop" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
	<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" 
        DataKeyNames="ID" onrowdatabound="gdList_RowDataBound" >
		<Columns>
			 <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" > 
				 <ItemTemplate>
					 <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div> 
				 </ItemTemplate>
			 </asp:TemplateField>
			<asp:TemplateField HeaderText="商品名称">
				<ItemTemplate>
					<%#EbSite.Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(Eval("ProductID").ToString()), SettingInfo.Instance.GetSiteID).NewsTitle%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="状态">
				<ItemTemplate>
					<%# EbSite.Modules.Shop.ModuleCore.BLL.GroupBuy.Instance.ParseGroupState(Eval("Status").ToString())%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="开始时间">
				<ItemTemplate>
					<%# Eval("StartDate")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="结束时间">
				<ItemTemplate>
					<%# Eval("EndDate")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="违约金">
				<ItemTemplate>
					<%# Eval("NeedPrice")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="限购">
				<ItemTemplate>
					<%# Eval("MaxCount")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="订购商品">
				<ItemTemplate>
					<%#Eval("BuySumOrder")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="订单">
				<ItemTemplate>
					<%#Eval("Buyed")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="当前价格">
				<ItemTemplate>
				<%#Eval("buyPrice")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
                    <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GroupShow(EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("id"),Eval("productid"))%>" target="_blank">查看</a>&nbsp;
                    	<XS:EasyuiDialog LinkOnly="True" ID="wbModify" Title="修改" Text="修改" runat="server"/>
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