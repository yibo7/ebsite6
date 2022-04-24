<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.PostManage.List" %>
<%@ Import Namespace="EbSite.Modules.BBS" %>
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
			<asp:TemplateField HeaderText="回帖内容">
				<ItemTemplate>
				<a target="_blank" href="<%#HostApi.GetContentLink(Eval("TopicID"),SettingInfo.Instance.GetSiteID) %>"> <%# CutStr(Eval("ReplyContent"))%>   </a>	
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="回帖人">
				<ItemTemplate>
					<%#Eval("UserName")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="回帖人IP">
				<ItemTemplate>
					<%#Eval("CreatedIP")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="回帖时间">
				<ItemTemplate>
					<%#Eval("CreatedTime")%>
				</ItemTemplate>
			</asp:TemplateField>
           
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
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