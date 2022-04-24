<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskClassAdd.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.AskOperate.AskClassAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server"   onload="phCtrList_Load" >
	<div class="admin_toobar">
		<fieldset>
			<legend>添加信息</legend>
			<div>

			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
			<td height="25" width="30%" align="right">
				分类名称
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="ClassName" runat="server" Width="200px"></XS:TextBoxVl>
			</td></tr>
			<tr>
			<td height="25" width="30%" align="right">
				父分类
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="ParentID" runat="server" Visible="false" Width="200px"></XS:TextBoxVl>
                <asp:DropDownList   ID="FatherClass" Width="200" runat="server"  >
            </asp:DropDownList>
			</td></tr>
			<tr>
			<td height="25" width="30%" align="right">
				分类简介
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="Info" runat="server" Width="250px" Height="100"  TextMode="MultiLine"></XS:TextBoxVl>
			</td></tr>
			<tr>
			<td height="25" width="30%" align="right">
				标题样式
			：</td>
			<td height="25" width="*" align="left">
				<XS:TextBoxVl id="TitleStyle" runat="server" Width="200px"></XS:TextBoxVl>
			</td></tr>

		</table>
		</div>
		</fieldset>
	</div>
</asp:PlaceHolder>
<div style="text-align: center">
    <asp:Label ID="UnEdit" runat="server" Text="根分类不能编辑" ForeColor="Red" 
        Visible="False"></asp:Label>
	<XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>
 <script>
     $(document).ready(function () {
        // alert("全屏");

     });
 </script>