<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoveToClass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.MoveToClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
<div  class="row">
    <div class="col-sm-12">
        <h4 class="page-title">第二步</h4>
        <p class="text-muted page-title-alt">请选择内容移动的目标分类!</p>
    </div>
</div>
<div class="row">
    <div class="col-lg-12">
        <div class="card-box">
            <div class="selbox form-horizontal">
               <XSD:SelectClass ID="selClass" Size="30" runat="server"></XSD:SelectClass>
            </div>
            <div style="text-align: center; padding: 10px;">
                <XS:Button ID="Button1" Text=" 确认移动内容到所选分类 " runat="server"  />

                <input type="button"  value=" 取消返回 " onclick="javascript:history.go(-1);" class="btn btn-default" /> 
            </div>
        </div>

    </div>
</div>
  
<script>
    $(function () {

        AddClassSelInit();
    });
</script>