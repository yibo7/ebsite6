<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ctrl.ascx.cs" Inherits="EbSite.Modules.Wenda.ExtensionsCtrls.AskScore.Ctrl" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<link type="text/css" href="/themes/wenda/css/drpscore.css" rel="stylesheet" />
<SCRIPT language='javascript' src='/js/plugin/SelectSingle/select.js'></SCRIPT>
<script type="text/javascript">
    $(document).ready(function () {
        //绑定分类列表
        var params = { "pid": 0 };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetBmAskScore", params, function (result) {
            $("#ddlScore").html(result.d);
          
        });
        
        if ($.browser.msie && ($.browser.version == "6.0")) { //兼容IE6
            //ie6的一些处理
        }
        else {
            $("#ddlScore").sSelect();
        }

      
       
    });
</script>
 <select   style="width:124px;"  id="ddlScore"><option style="width:123px; " value="0">悬赏分</option></select>


