<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditeCss.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.EditeCss" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
   <div class="row">
    <div class="col-sm-12">
        <div class="card-box">
           <XS:TextBoxVl ID="txtCss" TextMode=MultiLine  height="300"   runat="server"  />
        </div>
    </div>
</div>
</asp:PlaceHolder>
<div style="text-align: center;display: none">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>

<script>
    function SaveFrame() {
        $("#<%=bntSave.ClientID%>").click();
    }
</script>