<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnswerShow.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.AskOperate.AnswerShow"%> 
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
	<fieldset>
		<legend>��ϸ���� </legend>
		<div style="margin-left:20px;">
			<table cellpadding="0" cellspacing="0">
				
				
				<tr>
					<td>
						�ش�����:<%=Model.AnswerContent%>
					</td>
				</tr>
				<tr>
					<td>
						�Ƿ����:<%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetBoolText(bool.Parse(Eval("IsAdoption").ToString()))%>
					</td>
				</tr>
				<tr>
					<td>
						�ش�����:<%=Model.AnswerTime%>
					</td>
				</tr>
				
				<tr>
					<td>
						�ش���ip:<%=Model.AnswerIP%>
					</td>
				</tr>
				<tr>
					<td>
						�ο�����:<%=Model.ReferBook%>
					</td>
				</tr>
				<tr>
					<td>
						�Ƿ�����:<%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetBoolText(bool.Parse(Eval("IsAnonymity").ToString()))%>
					</td> 
				</tr>
				<tr>
					<td>
						�ش��޸�����:<%=Model.AnswerUpdateTime%>
					</td>
				</tr>
				<tr>
					<td>
						��ֵ:<%=Model.Score%>
					</td>
				</tr>
			</table>
		</div>
	</fieldset>
</div>
<div style="text-align: center">
	<XS:Button ID="btnColseGreyBox" runat="server" Text=" �� �� �� �� " />   
</div>
