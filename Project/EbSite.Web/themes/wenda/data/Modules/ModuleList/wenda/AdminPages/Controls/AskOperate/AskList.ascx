<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskList.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.AskOperate.AskList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="id"  OnRowDataBound="gdList_DataBound" onrowcommand="gdList_RowCommand">
        <columns>
			<%-- <asp:TemplateField HeaderText="ID"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" > 
				 <ItemTemplate>
					 <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div> 
				 </ItemTemplate>
			 </asp:TemplateField>--%>
             <asp:BoundField HeaderText="ID" DataField="id" />       
			<%--<asp:TemplateField HeaderText="id">
				<ItemTemplate>
					<%#Eval("id")%>
				</ItemTemplate>
			</asp:TemplateField>--%>
			<asp:TemplateField HeaderText="问题名称"  ItemStyle-CssClass="gvfisrtTD">
				<ItemTemplate>
					&nbsp;<%--<%#Eval("NewsTitle")%>--%>
                    <%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetCutAskTitle(Eval("NewsTitle").ToString())%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="悬赏分" >
				<ItemTemplate>
					&nbsp;<%#Eval("Annex1")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="用户" >
				<ItemTemplate>
					&nbsp;<%#Eval("UserName")%>
				</ItemTemplate>
			</asp:TemplateField>
             <asp:TemplateField HeaderText="时间" >
				<ItemTemplate>
					&nbsp;<%#Eval("addtime")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="状态" >
				<ItemTemplate>
					&nbsp;
                    <%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetAskStatu(int.Parse( Eval("Annex21").ToString()))%>
				</ItemTemplate>
			</asp:TemplateField>
             <asp:TemplateField HeaderText="审核状态" >
				<ItemTemplate>
					&nbsp;
                    <%#Eval("isauditing").ToString()%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					 <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
					<%--<XS:EasyuiDialog ID="wbModify" Title="修改" Text="修改" runat="server"/>/--%>
					<XS:EasyuiDialog ID="wbShow"  Title="详细内容" Text="详细内容" runat="server" />
                   <XS:LinkButton ID="lbCheck"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CheckModel"   confirm="true" Text="审核通过"></XS:LinkButton>
					
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

