<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditTem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Tem.EditTem" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
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
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>插入引用代码</b></h4>
            <XSD:SelTempFields ID="SelTempFields1"   FieldType="部件" IsFull="true" Title="插入部件" Text="插入部件" runat="server"></XSD:SelTempFields>   
     <XSD:SelTempFields ID="SelTempFields2"  FieldType="分类字段" IsFull="true" Title="插入分类字段" Text="插入分类字段" runat="server"></XSD:SelTempFields>
     <XSD:SelTempFields ID="SelTempFields3"   FieldType="内容字段" IsFull="true" Title="插入内容字段" Text="插入内容字段" runat="server"></XSD:SelTempFields>
   <%--  <XSD:SelTempFields ID="SelTempFields4"   FieldType="专题字段" IsFull="true" Text="插入专题字段" runat="server"></XSD:SelTempFields>--%>
     <XSD:SelTempFields ID="SelTempFields5"   FieldType="用户字段" IsFull="true" Title="插入用户字段" Text="插入用户字段" runat="server"></XSD:SelTempFields>
     <XSD:SelTempFields ID="SelTempFields6"   FieldType="常用变量" IsFull="true" Title="插入常用变量" Text="插入常用变量" runat="server"></XSD:SelTempFields>
     <XSD:SelTempFields ID="SelTempFields7"   FieldType="函数" IsFull="true" Title="插入函数" Text="插入函数" runat="server"></XSD:SelTempFields>
     <XSD:SelTempFields ID="SelTempFields8"   FieldType="连接" IsFull="true" Title="插入连接" Text="插入连接" runat="server"></XSD:SelTempFields>
     <XSD:SelTempFields ID="SelTempFields9"   FieldType="inclue代码"  IsFull="true" Title="插入inclue代码" Text="插入inclue代码" runat="server"></XSD:SelTempFields>   
      
        </div>
    </div>
</div> <div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>模板内容</b></h4>
            <asp:TextBox ID="txtTem"    TextMode="MultiLine" runat="server"/>
        </div>
    </div>
</div> <div class="text-center mt10">     
  <XS:Button ID="bntSave" Text="保存模板" runat="server"  />
 </div>
<script> 
    var editor = CodeMirror.fromTextArea(document.getElementById("<%=txtTem.ClientID%>"), {
        lineNumbers: true,
        mode: "text/html"
    });
     
    function InserField(ob) {
        editor.replaceSelection(ob);
        //InserFieldToBox(ob,"<%=txtTem.ClientID %>");
    }
</script>