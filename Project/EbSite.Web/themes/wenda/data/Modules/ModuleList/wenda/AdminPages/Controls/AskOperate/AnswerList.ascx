<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnswerList.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.AskOperate.AnswerList"%>
<%@ Import Namespace="EbSite.Modules.Wenda.ModuleCore" %> 
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>


<div style="text-align: center; font-size: 18px; font-weight: bold; padding: 8px; background: #E6E5E1; border-top:1px solid #DBDAD7; ">
    <%=GetTitle %>回答管理[<a style="color: red;" href="javascript:history.go(-1)">返回</a>]
</div>

<div id="PagesMain">
	<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="id" onrowcommand="gdList_RowCommand"  >
		<Columns>
			  <asp:BoundField HeaderText="ID" ItemStyle-Width="60" DataField="id" />     
			<asp:TemplateField HeaderText="问题"  ItemStyle-CssClass="gvfisrtTD">
				<ItemTemplate>
					 <a href='<%#EbSite.Base.Host.Instance.GetContentLink(Eval("QID"),int.Parse(Eval("SiteID").ToString()),Eval("classid"))%>'target="_blank">
                    &nbsp;<%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetAskByID(Eval("QID").ToString())%> </a>
				</ItemTemplate>
			</asp:TemplateField>

			
			
			<asp:TemplateField HeaderText="回答时间">
				<ItemTemplate>
					<%#Eval("AnswerTime")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="审核">
				<ItemTemplate>
					<%# Equals( Eval("IsApproved").ToString(),"0")?"未审核":"通过"%>
				</ItemTemplate>
			</asp:TemplateField>
            	<asp:TemplateField HeaderText="回答内容">
				<ItemTemplate>
					<%#AskCommon.GetCutAskTitle( EbSite.Core.UBB.Ubb2Html(Eval("AnswerContent").ToString()),50)%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					 <XS:LinkButton ID="lbDelete"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"   confirm="true" Text="删除"></XS:LinkButton>/
					
					<XS:EasyuiDialog ID="wbShow"  Title="回答内容" Text="回答内容" runat="server" />
                    <XS:LinkButton ID="lbCheck"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CheckModel"   confirm="true" Text="审核通过"></XS:LinkButton>
					
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
