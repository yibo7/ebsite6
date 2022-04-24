<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuppliersEdit.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Supplier.SuppliersEdit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
	<div class="admin_toobar">
		<fieldset>
			<legend>添加信息</legend>
			<div>

			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
			<td height="25" width="30%" align="right">
				供货商名称：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="SupplierName" runat="server" Width="200px"></XS:TextBoxVl>
			</td></tr>
			<tr>
			<td height="25" width="30%" align="right">
				供货商负责人
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="ContactUser" runat="server" Width="200px"></XS:TextBoxVl>
			</td></tr>
			<tr>
			<td height="25" width="30%" align="right">
				手机号码
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="Phone" runat="server" Width="200px"></XS:TextBoxVl>
			</td></tr>
			<tr>
			<td height="25" width="30%" align="right">
				电话号码
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="Tel" runat="server" Width="200px"></XS:TextBoxVl>
			</td></tr>
			<tr>
			<td height="25" width="30%" align="right">
				联系地址
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="Adres" runat="server" Width="200px"></XS:TextBoxVl>
			</td></tr>
		</table>
		</div>
		</fieldset>
	</div>
</asp:PlaceHolder>
<div style="text-align: center">
	<XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>
