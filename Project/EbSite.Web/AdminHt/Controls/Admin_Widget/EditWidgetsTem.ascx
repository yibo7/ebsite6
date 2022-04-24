<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditWidgetsTem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Widget.EditWidgetsTem" %>
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
        <div class="boxheader headertips">
                <h3>编辑模板</h3>
            模板编辑要小心，确定模板有没有被多个部件使用，修改后将全部覆盖,推荐另外自创一个自定义的部件模板。
            </div>
            <div class="content">
				<asp:TextBox ID="txtTem"    TextMode="MultiLine" runat="server"/>
            </div>
    </div>
</div>
<div class="text-center mt10">
    
<XS:Button ID="bntSave" Text=" 保 存 模 板 " runat="server"  /> <input onclick="history.go(-1)" class="btn btn-default" type="button" value="返回"/>
</div>
<script>
    var editor = CodeMirror.fromTextArea(document.getElementById("<%=txtTem.ClientID%>"), {
      lineNumbers: true,
      mode: "text/html"
    });
     
    </script>