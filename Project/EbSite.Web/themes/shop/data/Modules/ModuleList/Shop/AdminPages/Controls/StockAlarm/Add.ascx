<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.StockAlarm.Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
	<div class="admin_toobar">
		<fieldset>
			<legend>添加信息</legend>
			<div>

			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
			<td height="25" width="30%" align="right">
				补充数量：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="txtAddCount" runat="server" Width="100px" IsAllowNull="false" ValidateType="正整数"></XS:TextBoxVl>
			</td></tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
			<tr>
                <td height="25" width="30%" valign="top" align="right">备注说明：</td>
                <td height="25" width="*" align="left"><XS:TextBoxVl id="txtContent" runat="server" Width="300px" Height="80px" TextMode="MultiLine"></XS:TextBoxVl></td>
			</tr>
		</table>
                <div style="text-align: center; margin-top:5px;">
	<XS:Button ID="bntSave" runat="server"  Text=" 保 存 " OnClientClick="return window.confirm('确定补充吗？')"  />
    <input type="button" class="AdminButton" value=" 取 消 " onclick="ClosePage()" />
</div>
		</div>
		</fieldset>
	</div>
</asp:PlaceHolder>

<script type="text/javascript">
    function ClosePage() {
        $(window.parent.document.body).find("div[class='panel-tool-close']").click();
    }
</script>