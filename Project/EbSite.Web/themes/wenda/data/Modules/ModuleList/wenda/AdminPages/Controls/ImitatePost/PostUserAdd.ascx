<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostUserAdd.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.ImitatePost.PostUserAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
	<div class="admin_toobar">
		<fieldset>
			<legend>添加信息</legend>
			<div>

			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			
			
			<tr>
			<td height="25" width="30%" align="right">
			 快速添加用户
			：</td>
			<td height="25" width="*" align="left">
				<XSD:SelectUser Width="300" ID="txtUserInfo2"   Height="100"   SelectType="多选"  runat="server"  />
			</td></tr>
			
		</table>
		</div>
		</fieldset>
	</div>
</asp:PlaceHolder>
<div style="text-align: center">
	<XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>