<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="EbSite.Modules.BBS.ModuleCore.Pages.mreply" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control.xsPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>

<!--#include file="header.inc" -->
<style>textarea{ width: 100%;height: 500px;}</style>
    <div class="txt-c">
	<form runat="server">
    <table class="mapbox contentmain" cellpadding="0" cellspacing="0">
		<tr>
        	<td class="contentmain-right">
            	<div class="saveposttitle">����ظ�</div>
                <div>����: <asp:Literal ID="llReference" runat="server">��</asp:Literal></div>
              <div>(�������Ϊ1000���ַ�)</div>
               
                    <div >
                        <XS:UEditor ID="edtContentInfo"   Height="500" runat="server"></XS:UEditor>  
                     </div>
                     <div > 
                         <asp:Button id="btnSavePost" runat="server" Text=" �ύ�ظ� " />
                        
                 	</div>

            </td>
        </tr>
    </table>
        <asp:HiddenField id="hfRfUid" runat="server" />
        <asp:HiddenField id="RePath" runat="server" />
    </form>
</div>
<!--#include file="footer.inc" -->
</body>
</html>
