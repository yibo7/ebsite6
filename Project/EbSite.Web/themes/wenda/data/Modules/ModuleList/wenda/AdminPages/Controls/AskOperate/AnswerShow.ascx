<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnswerShow.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.AskOperate.AnswerShow"%> 
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
	<fieldset>
		<legend>详细内容 </legend>
		<div style="margin-left:20px;">
			<table cellpadding="0" cellspacing="0">
				
				
				<tr>
					<td>
						回答内容:<%=Model.AnswerContent%>
					</td>
				</tr>
				<tr>
					<td>
						是否采纳:<%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetBoolText(bool.Parse(Eval("IsAdoption").ToString()))%>
					</td>
				</tr>
				<tr>
					<td>
						回答日期:<%=Model.AnswerTime%>
					</td>
				</tr>
				
				<tr>
					<td>
						回答者ip:<%=Model.AnswerIP%>
					</td>
				</tr>
				<tr>
					<td>
						参考资料:<%=Model.ReferBook%>
					</td>
				</tr>
				<tr>
					<td>
						是否匿名:<%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetBoolText(bool.Parse(Eval("IsAnonymity").ToString()))%>
					</td> 
				</tr>
				<tr>
					<td>
						回答修改日期:<%=Model.AnswerUpdateTime%>
					</td>
				</tr>
				<tr>
					<td>
						分值:<%=Model.Score%>
					</td>
				</tr>
			</table>
		</div>
	</fieldset>
</div>
<div style="text-align: center">
	<XS:Button ID="btnColseGreyBox" runat="server" Text=" 关 闭 窗 口 " />   
</div>
