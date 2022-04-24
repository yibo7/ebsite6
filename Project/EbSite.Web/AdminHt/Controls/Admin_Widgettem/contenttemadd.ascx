<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contenttemadd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Widgettem.contenttemadd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link rel="stylesheet" href="<%=IISPath%>js/codemirror/lib/codemirror.css">
<script src="<%=IISPath%>js/codemirror/lib/codemirror.js"></script>
<script src="<%=IISPath%>js/codemirror/xml.js"></script>
<script src="<%=IISPath%>js/codemirror/javascript.js"></script>
<script src="<%=IISPath%>js/codemirror/css.js"></script>
<script src="<%=IISPath%>js/codemirror/htmlmixed.js"></script>
<style>
    .CodeMirror {
        height: auto;
        border: 1px solid #ddd;
    }

        .CodeMirror pre {
            padding-left: 7px;
            line-height: 1.25;
        }
</style>
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>模板名称</h3>
            </div>
            <div class="content"> 
		        <XS:TextBox ID="txtClassTitle" Width="200" runat="server"></XS:TextBox>
            </div>
    </div>
</div>
 
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>编辑模板（列表+表头）</h3>
            </div>
            <div class="content">
			    <div class="container-fluid mt10">
	            <div class="row-fluid"> 
                        <ul class="nav nav-tabs">
                            <li class="active tab">
                                <a href="#tg1" data-toggle="tab" aria-expanded="false">
                                    <span class="visible-xs"><i class="fa fa-navicon"></i></span>
                                    <span class="hidden-xs">列表模板</span>
                                </a>
                            </li>
                            <li class="tab">
                                <a href="#tg2" data-toggle="tab" aria-expanded="false">
                                    <span class="visible-xs"><i class="fa fa-server"></i></span>
                                    <span class="hidden-xs">表头模板</span>
                                </a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div id="tg1" class="tab-pane active">

                                <asp:TextBox ID="txtListTemHtml" TextMode="MultiLine" Width="800" Height="600" runat="server"></asp:TextBox>
                            </div>
                            <div id="tg2" class="tab-pane">

                                <asp:TextBox ID="txtHeaderTemHtml" TextMode="MultiLine" Width="800" Height="600" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
</div>
<div class="text-center mt10">
    
<XS:Button ID="bntSave" Text=" 保 存 " runat="server" />
<input onclick="history.go(-1)" class="btn btn-default" type="button" value="返回" />

</div>



<script>
    var editor1 = CodeMirror.fromTextArea(document.getElementById("<%=txtListTemHtml.ClientID%>"), {
        lineNumbers: true,
        mode: "text/html"
    });

    var editor2 = null;
    $('a[data-toggle="tab"]')
        .on('shown.bs.tab',
            function (e) {
                //e.target // 激活的标签页
                //e.relatedTarget // 前一个激活的标签页
                if (!editor2) {
                    editor2 = CodeMirror.fromTextArea(document.getElementById("<%=txtHeaderTemHtml.ClientID%>"), {
                        lineNumbers: true,
                        mode: "text/html"
                    });
                }

            });

</script>
