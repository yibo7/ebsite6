<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddSpecialSel.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Special.AddSpecialSel" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
 
<div id="divsteptips" runat="server"  class="container-fluid main-title">第一步:请选择父级专题然后点击[下一步]</div>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
									<h3 class="m-t-0 m-b-20 header-title">添加子专题</h3>
									 <XSD:SelectClass ID="selClass"  ApiFunctionName="GetSubSpecial" runat="server"></XSD:SelectClass>
        <br /><br />
								</div>
                               
							</div>
		  <div class="text-center mt10">
                                    <input type="button" class="btn  btn-primary" value=" 下一步 进入添加子专题" onclick="gotonext()"  id="bntSave"  />
                                </div>
 
<script>
    $(function () {

        AddClassSelInit();
    });
    function gotonext() {
        var selID = $("#<%=selClass.hfValue.ClientID%>").val();
        if (selID > 0) {
            location.href = "?t=0&pid=" + selID;
        }
        else {
            tb_err("请选择父专题", 1, 3);
        }
        

    }
</script>
