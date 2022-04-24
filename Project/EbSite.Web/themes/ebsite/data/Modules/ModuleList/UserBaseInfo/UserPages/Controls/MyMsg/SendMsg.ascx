<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendMsg.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.MyMsg.SendMsg" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<br/>
<XS:TextBoxVl ID="txtMsg" runat="server" IsAllowNull="false"  Width="300" Height="100" TextMode="MultiLine" >请输入留言内容</XS:TextBoxVl>

<div style="text-align:center; margin-top: 20px;">
    <XS:Button ID="bntSave" runat="server" Text=" 提交留言 " />
</div>

  <script>
     
      In.ready('textauto', function () {
          $("#<%=txtMsg.ClientID %>").textRemindAuto({ focusColor: "red" });
      });
      
  </script>