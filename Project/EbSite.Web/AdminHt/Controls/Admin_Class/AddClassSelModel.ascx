<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddClassSelModel.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.AddClassSelModel" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
<style>
    .badge a{color:#ffffff;}
</style>
<div style="background:#FAFAFA" class="container-fluid main-title">
 
        <h4 class="page-title">第一步</h4>
        <p class="text-muted page-title-alt">请选择以下分类模型进入下一步!</p>
   
</div>
 <div style="width:500px;" class="container-fluid mt10">
	<div class="row-fluid"> 
    <ul class="list-group">   

    <asp:Repeater ID="rpModels" runat="server">
        <ItemTemplate>
              <li data-toggle="tooltip" title="<%# Eval("ModelInfo")%>" class="list-group-item">
                 
                 <span class="badge"><a href="?t=0&modelid=<%# Eval("ID")%>">>></a></span>
                    <a href="?t=0&modelid=<%# Eval("ID")%>"><%# Eval("ModelName")%></a>
              </li> 
                  
        </ItemTemplate>
    </asp:Repeater>
        </ul>
</div>
</div>


<script>
    $(function () {
        var objTags = $(".list-group>li");

        if (objTags.length == 1) {
            gotourl($(objTags.find("a")[0]).attr("href"));
        }

    });
</script>

