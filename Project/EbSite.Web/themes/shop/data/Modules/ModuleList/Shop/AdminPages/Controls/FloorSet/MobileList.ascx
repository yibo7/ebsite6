<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MobileList.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.FloorSet.MobileList" %>
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
			<asp:TemplateField HeaderText="楼层名称">
				<ItemTemplate>
					<%#Eval("floorname")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="楼层颜色">
				<ItemTemplate>
               <div style="width:39px; height: 10px;  background-color: #<%#Eval("floorcolor")%>;  margin: 3px auto;"></div> 
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="楼层ID">
				<ItemTemplate>
					 <%#Eval("Floorid")%>
				</ItemTemplate>
			</asp:TemplateField>
			
			
          
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					<XS:EasyuiDialog ID="wbModify" LinkOnly="True"  Title="修改" Text="修改" runat="server"/>
                    
                    <a href="<%=GetPageUrl("86d17e6e-af5f-4111-a6a7-8ed8f445ebdd") %>&id=<%#Eval("id")%>">设计Mobile楼层</a>

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