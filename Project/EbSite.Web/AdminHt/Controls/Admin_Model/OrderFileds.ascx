<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderFileds.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Model.OrderFileds" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>     
	.Items ul { list-style-type: none; margin: 0; padding: 0; margin-bottom: 10px; }
	.Items li { margin: 5px; padding: 5px; width: 150px; cursor:move; }
	</style>  
<div class="row">
    <div class="col-sm-12">
        <div style="background:#ffffff;">
            <h4 class="m-t-0 m-b-20 header-title"><b>上下拖动字段，确认排列好后点保存即可</b></h4>
            <table>
    <tr>
        <td>
        
<div class="Items">

<ul id="sortable">
        <asp:Repeater ID="rpList" runat="server"  >
            <ItemTemplate> 
            <li id="<%#Eval("ColumFiledName")%>" class="ui-state-default"><%#Eval("ColumShowName")%></li>         
            </ItemTemplate>
        </asp:Repeater>
</ul>

</div>
        </td>
        <td >
        
       <%-- <input  type="button"  value="保存排序结果 " onclick="SaveOrderList();TipsAutoClose(this,'正在处理...'); "  class="AdminButton" style="height:50px;width:100px; margin-left:30px;" />
        --%>
        </td>
    </tr>
</table>
        </div>
    </div>
</div>

<script>

    In.ready('jqui', function () {
        //执行代码
        $("#sortable").sortable({
            revert: true
        });
    });
   
    function SaveFrame() {

        var aFields = [];
        $("#sortable").find("li").each(
		        function (i) {
		            aFields.push(this.id);
		        }
        ); 
        if (aFields.length > 0) { 
            var Urls = "ajaxget/ModuleFieldsOrder.ashx?mt=<%=ModuleType %>&mid=<%=ModelID %>&sort=" + aFields.join("|") + "&time=" + Math.random();
          
            run_ajax_async(Urls, "", function (msg) { 
                if (msg == "ok") {
                    alert("更新成功！");
                }
                else { alert("更新失败！"); }
            });
        }

    }

</script>