<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="EbSite.Modules.BBS.ModuleCore.Pages.msavepost" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control.xsPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
<style>
    
    textarea{ width: 100%;height: 500px;}
</style>
<!--#include file="header.inc" -->
    <div class="txt-c">
	<form runat="server">

    <table class="contentmain" cellpadding="0" cellspacing="0">
		<tr>
        	<td class="contentmain-right">
            	<div class="saveposttitle">��������</div>
                <div><b>����</b>(�������Ϊ60���ַ�����������60 )</div>
                <div class="savediv"> 
                    <asp:TextBox id="txtposttitle" runat="server"></asp:TextBox>
                 </div>
                    <div style="width: 100%;" >
                        <XS:Editor ID="edtContentInfo" Size="5024" IsUBB="true" Width="100%" Height="500" runat="server"></XS:Editor>  
                     </div>
                     <div > 
                         <asp:Button id="btnSavePost" runat="server" Text=" �ύ���� " />
                         
                         <asp:CheckBox id="cbIsReToSendEmail" runat="server" Text="���˻ظ�����Email����" />
                         <font color="#ff0000">(����Email�Ƿ���ȷ?<a target="_blank" href="<%=HostApi.GetModuleUrl("bf371bdd-f674-4077-a9ed-e2896fb4c857","477c77b4-be69-4d37-9593-90884fabc19c") %>">�޸��ҵ�Email</a>)</font>
                         
                 	</div>

            </td>
        </tr>
    </table>
    </form>
</div>
<!--#include file="footer.inc" -->
</body>
</html>
