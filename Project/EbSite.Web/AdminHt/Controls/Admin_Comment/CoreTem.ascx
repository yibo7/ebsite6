<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoreTem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Comment.CoreTem" %>
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
        <div class="headertips">
                <h3>代码调用-Iframe模式</h3>
            根据自身需求，选择以下一种模式，复制代码到内容模板里的相应位置，如果不需要做SEO优化，建议使用Iframe模式，这样性能更佳
            </div>
            <div class="eb-content">
				<asp:TextBox ID="txtIframeCore"   TextMode="MultiLine"   runat="server"></asp:TextBox>
            </div>
    </div>
</div>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="headertips">
                <h3>代码调用-当前代码模式</h3>
            有利于SEO,你可以编辑里面的模板，但带有ID的控件或方法请保留，并且ID名称不能更改
            </div>
            <div class="eb-content">				
             <asp:TextBox ID="txtContentCore"   TextMode="MultiLine"   runat="server"></asp:TextBox>
            </div>
    </div>
</div>
<script>
    var editor = CodeMirror.fromTextArea(document.getElementById("<%=txtIframeCore.ClientID%>"), {
      lineNumbers: true,
      mode: "text/html"
    });

      CodeMirror.fromTextArea(document.getElementById("<%=txtContentCore.ClientID%>"), {
      lineNumbers: true,
      mode: "text/html"
    });
    </script>