<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false"  Inherits="EbSite.Modules.BBS.ModuleCore.Pages.msavepostmobile" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
<!--#include file="header.inc" --> 
	<form runat="server">
     <div class="saveposttitle">��������</div>
                <div><b>����</b>(�������Ϊ60���ַ�����������60 )</div>
                <div class="savediv"> 
                    <asp:TextBox id="txtposttitle" Width="100%" runat="server"></asp:TextBox>
                 </div>
                    <div style="width: 100%; margin-top: 10px;" >
                        <asp:TextBox ID="txtContentInfo"  Width="100%" Height="100" TextMode="MultiLine" runat="server"></asp:TextBox>  
                     </div> 
                     <div style="text-align: center; margin-top: 10px;" > 
                         <asp:Button id="btnSavePost" style="width: 90%; height:30px;"  runat="server" Text=" �ύ���� " />
                          
                 	</div>
    </form> 
</body>
</html>
