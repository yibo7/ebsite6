<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditTem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Comment.EditTem" %>
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
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>编辑模板</h3>
            </div>
            <div class="eb-content">
				<asp:TextBox ID="txtTem"   TextMode="MultiLine"   runat="server"></asp:TextBox> 
            </div>
    </div>
</div>
<div class="text-center mt10">
    <XS:Button ID="bntSave" Text="保存模板" runat="server" />
</div>
 <br />
<script>
      var editor = CodeMirror.fromTextArea(document.getElementById("<%=txtTem.ClientID%>"), {
      lineNumbers: true,
      mode: "text/html"
    });
    function InserField(ob)
    {
       
        InserFieldToBox(ob,"<%=txtTem.ClientID %>");
    }
</script>
