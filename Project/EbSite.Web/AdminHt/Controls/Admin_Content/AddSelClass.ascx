<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddSelClass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.AddSelClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
  
  <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div style="height:58px !important;" class="boxheader">
                <h3>第一步</h3>
            请选择分类然后点击[下一步] 进入内容添加页面
            </div>
            <div class="content">
				<div class="selbox form-horizontal">
               <XSD:SelectClass ID="selClass" Size="30" runat="server"></XSD:SelectClass>
            </div>
            <div style="text-align: center; padding: 10px;">
               <input type="button"  value=" 下一步 进入内容添加页面" onclick="gotonext()" class="btn btn-primary"  id="bntSave"   />
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
        $(".selbox").find("option[value=" + selID + "]").each(
		function (i) {
		    selItem = $(this);

		});

        if (selItem != null) {
            var isadd = selItem.attr("pram");
            if (isadd == 1) {
                location.href = "?t=4&cid=" + selID;
            }
            else {
                tips("所选分类不能添加内容", 1, 3);
            }
        }
        else {
            tips("请选择一个分类", 1, 3);
        }

    }
</script>