<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Coder.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Component.Coder" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link rel=stylesheet href="<%=IISPath%>js/codemirror/lib/codemirror.css">
<link rel=stylesheet href="<%=IISPath%>js/codemirror/lib/csharpcolors.css">
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
        <div class="boxheader headertips">
                <h3>查看组件代码</h3>
            为了安全，取消组件代码在线修改，如有需要请修改文件
            </div>
            <div class="content">
				<asp:TextBox ID="txtTem"    TextMode="MultiLine" runat="server"/> 
            </div>
    </div>
</div>
<script>
    var editor = CodeMirror.fromTextArea(document.getElementById("<%=txtTem.ClientID%>"), {
      lineNumbers: true,
      mode: "javascript"
    }); 
    </script>

<%-- <div style=" text-align:center">
 <XS:Button ID="btnSave"  runat="server" Text=" <%$Resources:lang,EBSave%> " OnClick="btnSave_Click" OnClientClick="return confirm('您的网站将会中断几秒钟。\n您确定要继续吗？');" />
 </div>--%>
    