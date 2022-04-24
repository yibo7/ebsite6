<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Friends.Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<br/>
<XS:TextBoxVl ID="txtMsg" runat="server" IsAllowNull="false"  Width="300" Height="100" TextMode="MultiLine" >我是</XS:TextBoxVl>

<div style="text-align:center; margin-top: 20px;">
    <XS:Button ID="bntSave" runat="server" Text=" 发出请求 " />
</div>

  <script>
     
      In.ready('textauto', function () {
          $("#<%=txtMsg.ClientID %>").textRemindAuto({ focusColor: "red" });
      });
      
  </script>