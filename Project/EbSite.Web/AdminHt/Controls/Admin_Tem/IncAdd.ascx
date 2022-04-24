<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IncAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Tem.IncAdd" %>
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
           文件名称:<XS:TextBox ID="txtTitle" Width="150"  runat="server"></XS:TextBox> 
        </div>
    </div>
</div>
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
      
            <%--<div class="form-inline" role="form">
		  <div class="form-group">
			<label for="name">插入部件</label>
			 <XS:DropDownList ID="drWebPartList" onchange="InserField(this)" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Text="选择部件" Value=""></asp:ListItem>
                </XS:DropDownList>
		  </div>
		  <div class="form-group">
			<label for="inputfile">插入全局字段</label>
			<XS:DropDownList ID="drpAllColumns" onchange="InserField(this)" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Text="选择字段" Value=""></asp:ListItem>
                </XS:DropDownList>  
		  </div> 
        </div>--%>

        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>模板内容</b></h4>
            <asp:TextBox ID="txtTem"    TextMode="MultiLine" runat="server"/>
             
        </div>
    </div>
</div> <XS:Button ID="bntSave" Text="保存模块" runat="server" />
<script>
     var editor = CodeMirror.fromTextArea(document.getElementById("<%=txtTem.ClientID%>"), {
      lineNumbers: true,
      mode: "text/html"
    });
    function InserField(ob)
    {
        editor.replaceSelection(ob);
        //InserFieldToBox(ob,"<%=txtTem.ClientID %>");
    }
</script>