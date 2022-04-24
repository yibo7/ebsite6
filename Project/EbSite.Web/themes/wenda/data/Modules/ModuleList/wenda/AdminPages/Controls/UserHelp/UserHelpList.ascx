<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserHelpList.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.UserHelp.UserHelpList"%> 
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
	<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="id" >
		<Columns>
			
			<asp:TemplateField HeaderText="用户ID" ItemStyle-Width="50">
				<ItemTemplate>
					<%#Eval("id")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="用户名称">
				<ItemTemplate>
					<%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetUserName(Eval("UserID").ToString())%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="提问总数">
				<ItemTemplate>
					<%#Eval("QCount")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="回答总数">
				<ItemTemplate>
					<%#Eval("ACount")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="采纳总数">
				<ItemTemplate>
					<%#Eval("AdoptionCount")%>
				</ItemTemplate>
			</asp:TemplateField>
			<%--<asp:TemplateField HeaderText="最近参于类型">
				<ItemTemplate>
					<%#Eval("LikeAskClass")%>
				</ItemTemplate>
			</asp:TemplateField>--%>
            <asp:TemplateField HeaderText="积分">
				<ItemTemplate>
					<%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetUserScore(Eval("UserID").ToString())%>
				</ItemTemplate>
			</asp:TemplateField>
			
			
		</Columns>
	</XS:GridView>
</div>
<div>
	 <XS:PagesContrl ID="pcPage" runat="server" />
</div>
