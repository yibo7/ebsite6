<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuppliersShow.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Supplier.SuppliersShow"%> 
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
	<fieldset>
		<legend>详细内容 </legend>
		<div style="margin-left:20px;">
			<table cellpadding="0" cellspacing="0">
				<tr>
					<td align="right">
						供货商名称:
					</td>
                    <td><%=Model.SupplierName%></td>
				</tr>
				<tr>
					<td align="right">
						供货商负责人:
					</td>
                    <td><%=Model.ContactUser%></td>
				</tr>
				<tr>
					<td align="right">
						手机号码:
					</td>
                    <td><%=Model.Phone%></td>
				</tr>
				<tr>
					<td align="right">
						电话号码:
					</td><td><%=Model.Tel%></td>
				</tr>
				<tr>
					<td align="right">
						地址:
					</td><td><%=Model.Adres%></td>
				</tr>
				
			</table>
		</div>
	</fieldset>
</div>
<div style="text-align: center">
	<XS:Button ID="btnColseGreyBox" runat="server" Text=" 关 闭 窗 口 " />
</div>
