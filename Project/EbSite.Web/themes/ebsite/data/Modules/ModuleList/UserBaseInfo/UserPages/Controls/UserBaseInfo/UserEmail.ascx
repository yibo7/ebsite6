<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserEmail.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo.UserEmail" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <div> 
    <XS:TextBoxVl  ID="txtEmail"  ValidateType="电子邮箱email"     Width="200" runat="server"></XS:TextBoxVl>
 </div>
	
    <div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>