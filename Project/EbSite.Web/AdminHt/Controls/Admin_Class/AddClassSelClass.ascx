<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddClassSelClass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.AddClassSelClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
 
<div style="background:#FAFAFA" class="container-fluid main-title">
    <div  class="row">
    <div class="col-sm-12">
        <h3 class="page-title">选择父级分类</h3>
        <p class="text-muted page-title-alt">请选择父级分类然后点击[下一步]!</p>
    </div>
</div>
</div>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        
            <div class="eb-content">
				 <div class="selbox">
                <XSD:SelectClass ID="selClass" ApiFunctionName="GetSubClassForAddClass" Size="30" runat="server"></XSD:SelectClass>
            </div>
            <div style="text-align: center; padding: 10px;">
                <input type="button" value=" 下一步 进入添加子分类" onclick="gotonext()" id="bntSave" class="btn btn-primary" />
            </div>
            </div>
    </div>
</div>

 
<script>
    $(function () {

        AddClassSelInit();
    });
    function gotonext() {
        var selID = $("#<%=selClass.hfValue.ClientID%>").val();
        var selItem = null;
        if ($.trim(selID) != "") {
            $(".selbox")
                .find("option[value=" + selID + "]")
                .each(
                    function(i) {
                        selItem = $(this);

                    });

            if (selItem != null) {

                var isadd = selItem.attr("pram");
                if (isadd == 1) {
                    location.href = "?t=0&pid=" + selID;
                } else {
                    tb_err("所选分类不能添加下级子分类");
                }
            } else {
                
                tb_err("请选择一个分类");
            }
        } else {
             
            tb_err("请选择一个分类");
        }
        
         
    }
</script>
