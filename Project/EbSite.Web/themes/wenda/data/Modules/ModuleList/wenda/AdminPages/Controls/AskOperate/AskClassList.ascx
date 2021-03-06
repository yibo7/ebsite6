<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskClassList.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.AskOperate.AskClassList" %>

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
			<%--<asp:TemplateField HeaderText="id">
				<ItemTemplate>
					<%#Eval("id")%>
				</ItemTemplate>
			</asp:TemplateField>--%>
			<asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                <HeaderTemplate>
                    <%=Resources.lang.EBClassName%>
                </HeaderTemplate>
                <ItemTemplate>                    
                        <%#Eval("ClassName")%>
                </ItemTemplate>
            </asp:TemplateField>

			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					 <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>/
					<XS:EasyuiDialog ID="wbModify" IsFull="true"   Title="修改" Text="修改" runat="server"/>
                    
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField >
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
