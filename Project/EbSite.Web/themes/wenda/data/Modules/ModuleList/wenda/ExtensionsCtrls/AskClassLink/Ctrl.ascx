<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ctrl.ascx.cs" Inherits="EbSite.Modules.Wenda.ExtensionsCtrls.AskClassLink.Ctrl" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<link type="text/css" href="/themes/wenda/css/drpforindex.css" rel="stylesheet" />
<SCRIPT language='javascript' src='/js/plugin/SelectSingle/select.js'></SCRIPT>
<script type="text/javascript">
    $(document).ready(function () {
        //绑定分类列表
        var params = { "pid": 0 ,"bl":true};
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetBmAskClassList", params, function (result) {
            $("#ddlBrand").html(result.d);
           // $("#ddlCarModel").parent("div").hide();
        });
        $("#ddlBrand").change(function () {
            var $brandid = $(this).find("option:selected").val();
            var $carModel = $("#ddlCarModel");
            if ($brandid != "-1") {
                var param1 = { "pid": $brandid, "bl": false };
                runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetBmAskClassListCount", param1, function (result) {
                    if (result.d > 0) {
                        $("#ddlCarModel").parent("div").show();
                        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetBmAskClassList", param1, function (result) {

                            $carModel.html(result.d);
                            $carModel.click();
                        });
                    }
                    else {
                        $("#ddlCarModel").parent("div").hide();
                    }

                });
            }
            else {
                $("#ddlCarModel").parent("div").hide();
            }
        });
        

        if ($.browser.msie && ($.browser.version == "6.0")) { //兼容IE6
            //ie6的一些处理
        }
        else {
            $("#ddlBrand").sSelect();
            $("#ddlCarModel").sSelect();
        }
    
    });
</script>
 <select   style="width:110px; "  id="ddlBrand"><option style="width:231px; " value="-1">请选择问题类型</option></select>
 <select   style="width:110px; " id="ddlCarModel"><option style="width:231px; " value="-1">请选择问题类型</option></select>
