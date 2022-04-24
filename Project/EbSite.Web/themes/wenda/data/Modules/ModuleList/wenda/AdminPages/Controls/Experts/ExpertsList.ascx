<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExpertsList.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.Experts.ExpertsList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="id" >
        <columns>
			 <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" > 
				 <ItemTemplate>
					 <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div> 
				 </ItemTemplate>
			 </asp:TemplateField>
		
			<asp:TemplateField HeaderText="专家名称"  ItemStyle-CssClass="gvfisrtTD">
				<ItemTemplate>
					&nbsp;
                    <%#Eval("UserNiName").ToString()%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="是否通过审核">
				<ItemTemplate>
					&nbsp;
                    <%#Eval("IsAudit").Equals(0)?"<font style='color:red;'>否</font>":"是"%>
				</ItemTemplate>
			</asp:TemplateField>


            
             <asp:TemplateField HeaderText="职位" >
				<ItemTemplate>
					&nbsp;<%#Eval("Postition")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="擅长领域" >
				<ItemTemplate>
					&nbsp;<%#Eval("Field")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="所在地区" >
				<ItemTemplate>
					&nbsp;<%#Eval("Area")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="擅长品牌" >
				<ItemTemplate>
					&nbsp;<%#Eval("brand")%>
				</ItemTemplate>
			</asp:TemplateField>
             
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					 <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
					<XS:EasyuiDialog ID="wbModify" Title="修改" Text="修改" runat="server"/>
				<%--	<XS:EasyuiDialog ID="wbShow"  Title="详细内容" Text="详细内容" runat="server" />--%>
                  
					
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)">
				<ItemTemplate>
					<asp:CheckBox ID="Selector" runat="server" />
				</ItemTemplate>
			</asp:TemplateField>
		</columns>
    </XS:GridView>
</div>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>

