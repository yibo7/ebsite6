<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostUserList.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.ImitatePost.PostUserList" %>
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
			<asp:TemplateField HeaderText="用户名"  ItemStyle-CssClass="gvfisrtTD">
				<ItemTemplate>
					
                    &nbsp;<%#Eval("UserNiName").ToString()%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="用户ID"  ItemStyle-CssClass="gvfisrtTD">
				<ItemTemplate>
					
                    &nbsp;<%#Eval("UserID").ToString()%>
				</ItemTemplate>
			</asp:TemplateField>
		
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
                  <%--   <XS:EasyuiDialog ID="wbModify" IsFull="true"   Title="修改" Text="修改" runat="server"/>--%>
					 <XS:LinkButton ID="lbDelete"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"   confirm="true" Text="删除"></XS:LinkButton>
					
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
