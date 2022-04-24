<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReNameRule.aspx.cs" Inherits="EbSite.CustomPages.ReNameRule" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>静态面页命名规则</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:left; font-size:12px; ">
        <XS:DataList RepeatColumns="3" ID="dlReNameList" ItemStyle-Height="25" runat="server">
            <ItemTemplate>
            <input type="checkbox" onclick="OnCheckOb('<%# Eval("Key") %>')"  /><%# Eval("Name") %>
            </ItemTemplate>
            
        </XS:DataList>
       
    </div>
    
    </form>
    <script>    
    
		var ucName = GetUrlParams("uc");
		function OnCheckOb(svalue) {
		    var ob = $(parent.document.getElementById(ucName));
		    svalue = ob.val() + svalue; 
		    ob.val(svalue);
		    //parent.parent.document.getElementById(ucName).value += svalue;
		}		
    </script>
</body>
</html>
