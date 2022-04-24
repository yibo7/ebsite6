<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskAdd.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.AskOperate.AskAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
	<div class="admin_toobar">
		<fieldset>
			<legend>添加信息</legend>
			<div>

			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
            <tr>
			<td height="25" width="30%" align="right">
				标题
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="NewsTitle" runat="server" Width="200px"></XS:TextBoxVl>
			</td></tr>
			<tr>
			<td height="25" width="30%" align="right">
				内容
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="ContentInfo" runat="server" Width="200px"></XS:TextBoxVl>
			</td></tr>
            <tr>
			<td height="25" width="30%" align="right">
				悬赏分
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="Annex1" runat="server" Width="200px"></XS:TextBoxVl>
			</td></tr>

           
			
		</table>
		</div>
		</fieldset>
	</div>
</asp:PlaceHolder>
<div style="text-align: center">
	<XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>
