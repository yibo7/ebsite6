<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoveItems.aspx.cs" Inherits="EbSite.Web.home.MoveItems" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style>     
	.Items ul { list-style-type: none; margin: 0; padding: 0; margin-bottom: 10px; }
	.Items li { margin: 5px; padding: 5px; width: 150px; cursor:move; }
	</style>
	
<body style=" background:#ffffff">
<XS:Notes ID="Notes7" Text="上下拖动分类，确认排列好后点保存即可"   runat=server></XS:Notes>
<div class="Items">

<ul id="sortable">
        <asp:Repeater ID="rpTabs" runat="server"  >
            <ItemTemplate> 
            <li id="<%#Eval("id")%>" class="ui-state-default"><%#Eval("TabName")%></li>            
            </ItemTemplate>
        </asp:Repeater>
</ul>

</div>
<br />
<div>
    <input type="button" onclick="SaveTabsList();TipsAutoClose(this,'正在处理...')"  value=" 保 存 " />
</div>
<script>


    $(function () {


        $("#sortable").sortable({
            revert: true
        });


    });

    function SaveTabsList() {
        var sTabsSort = "";
        var iOrder = 0;
        $("#sortable").find("li").each(
		    function (i) {
		        iOrder++;
		        sTabsSort += this.id + "," + iOrder + "|";

		    }
		    );
        if (sTabsSort != "")
            SaveTabsSortList(sTabsSort);
    }
	</script>
</body>
</html>
