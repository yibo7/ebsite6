<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskShow.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.AskOperate.AskShow" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
	<fieldset>
		<legend>详细内容 </legend>
		<div style="margin-left:20px;">
			<table cellpadding="0" cellspacing="0">
				<tr>
					<td>
						<b>标题:</b>&nbsp;<%=Model.NewsTitle%>
					</td>
				</tr>
				<tr>
					<td>
						<b>内容:</b>&nbsp;<%=EbSite.Core.UBB.Ubb2Html(Model.ContentInfo)%>
					</td>
				</tr>
				<tr>
					<td>
						<b>提问用户:</b>&nbsp;<%=Model.UserName%>
					</td>
				</tr>
				<tr>
					<td>
						<b>状态:</b>&nbsp;<%=EbSite.Modules.Wenda.ModuleCore.AskCommon.GetAskStatu(Model.Annex21)%>
					</td>
				</tr>

			</table>
		</div>
	</fieldset>
</div>
<div style="text-align: center">
	<XS:Button ID="btnColseGreyBox" runat="server" Text=" 关 闭 窗 口 " />   
</div>