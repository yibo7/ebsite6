<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskClassShow.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.AskOperate.AskClassShow" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
	<fieldset>
		<legend>详细内容 </legend>
		<div style="margin-left:20px;">
			<table cellpadding="0" cellspacing="0">
				<tr>
					<td>
						id:<%=Model.id%>
					</td>
				</tr>
				<tr>
					<td>
						QID:<%=Model.QID%>
					</td>
				</tr>
				<tr>
					<td>
						QUserID:<%=Model.QUserID%>
					</td>
				</tr>
				<tr>
					<td>
						AnswerUserID:<%=Model.AnswerUserID%>
					</td>
				</tr>
				<tr>
					<td>
						AnswerContent:<%=Model.AnswerContent%>
					</td>
				</tr>
				<tr>
					<td>
						IsAdoption:<%=Model.IsAdoption%>
					</td>
				</tr>
				<tr>
					<td>
						AnswerTime:<%=Model.AnswerTime%>
					</td>
				</tr>
				<tr>
					<td>
						IsDel:<%=Model.IsDel%>
					</td>
				</tr>
				<tr>
					<td>
						AnswerIP:<%=Model.AnswerIP%>
					</td>
				</tr>
				<tr>
					<td>
						ReferBook:<%=Model.ReferBook%>
					</td>
				</tr>
				<tr>
					<td>
						IsAnonymity:<%=Model.IsAnonymity%>
					</td> 
				</tr>
				<tr>
					<td>
						AnswerUpdateTime:<%=Model.AnswerUpdateTime%>
					</td>
				</tr>
				<tr>
					<td>
						Score:<%=Model.Score%>
					</td>
				</tr>
			</table>
		</div>
	</fieldset>
</div>
<div style="text-align: center">
	<XS:Button ID="btnColseGreyBox" runat="server" Text=" 关 闭 窗 口 " />   
</div>
