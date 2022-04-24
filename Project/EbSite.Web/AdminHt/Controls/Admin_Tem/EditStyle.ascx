<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditStyle.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Tem.EditStyle" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link rel=stylesheet href="<%=IISPath%>js/codemirror/lib/codemirror.css">
<script src="<%=IISPath%>js/codemirror/lib/codemirror.js"></script>
<script src="<%=IISPath%>js/codemirror/xml.js"></script>
<script src="<%=IISPath%>js/codemirror/javascript.js"></script>
<script src="<%=IISPath%>js/codemirror/css.js"></script>
<script src="<%=IISPath%>js/codemirror/htmlmixed.js"></script>

<style>
  .CodeMirror { height: auto; border: 1px solid #ddd; }
  .CodeMirror pre { padding-left: 7px; line-height: 1.25; }
</style>
    <div runat="server" id="thememName" style="font-size: 14px; font-weight: bold; padding: 10px;">
    </div>

  <asp:TextBox ID="txtTem"    TextMode="MultiLine" runat="server"/>

<div style="text-align: center; padding: 10px;">
    <XS:Button ID="bntSave" Text="保存样式" runat="server"  />
</div>

<script>
     var editor = CodeMirror.fromTextArea(document.getElementById("<%=txtTem.ClientID%>"), {
      lineNumbers: true,
      mode: "text/css"
    }); 
</script>