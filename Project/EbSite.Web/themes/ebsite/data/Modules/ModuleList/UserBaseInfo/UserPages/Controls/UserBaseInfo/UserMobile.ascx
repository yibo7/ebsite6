<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserMobile.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo.UserMobile" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <div> 
    <XS:TextBoxVl  ID="txtMobile"  ValidateType="手机号"   runat="server"></XS:TextBoxVl>
 </div>
	
    <div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>