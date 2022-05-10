<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImitatePostUser.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.ImitatePost.ImitatePostUser" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="card-box" id="PagesMain">
	
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
	<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" >
		<Columns>
			<asp:TemplateField HeaderText="用户名称">
				<ItemTemplate>
				<a target="_blank" href="<%#HostApi.GetUserSiteUrl(Eval("ImitateUserID")) %>"> <%# Eval("ImitateUserRealName")%>   </a>	
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="用户帐号">
				<ItemTemplate>
					<%#Eval("ImitateUserName")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="用户ID">
				<ItemTemplate>
					<%#Eval("ImitateUserID")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="隶属用户ID">
				<ItemTemplate>
					<%#Eval("UserID")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="隶属用户ID">
				<ItemTemplate>
					<%#Eval("UserNiName")%>
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