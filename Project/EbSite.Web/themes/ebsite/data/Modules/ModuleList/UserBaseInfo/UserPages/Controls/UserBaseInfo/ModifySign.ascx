<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModifySign.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo.ModifySign" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <div> 
    <XS:TextBoxVl  ID="txtSign"  TextMode="MultiLine" IsAllowNull="false"  Width="250" Height="100" runat="server"></XS:TextBoxVl>
 </div>
	
    <div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>