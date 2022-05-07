<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigToClass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.ConfigToClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
<style>
    body {
        background-color: #fff !important
    }
</style>

<div class="container-fluid mt10">
    <div class="row-fluid"> 
        <XS:Notes ID="txtTips"  runat="server" />
        <div>
            <XS:ListBox ID="drpConfigs" SelectionMode="Single" Width="100%" Height="300" runat="server" />
        </div>

    </div>
</div>

<div style="text-align: center; display: none">
    <XS:Button ID="bntSave" Text=" 保存 " runat="server" />
</div>
<script>
    function SaveFrame() {
        $("#<%=bntSave.ClientID%>").click();
        /*RefeshParent1();*/
    }
</script>
