<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModifyNiName.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo.ModifyNiName" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <div> 
    <XS:TextBoxVl  ID="txtNiName"  IsAllowNull="false" MaxLength="10" runat="server"></XS:TextBoxVl>
 </div>
	
    <div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>