<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mreduceprice" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <div id="centerbox">
        <!--#include file="header.inc" -->
        <form  runat="server">
            <div style="margin:10px auto; width: 600px;">
        ����������ϵ��ʽ,�Ա㽵��֪��:<br />
        �����ֻ���:<XS:TextBoxVl ID="txtMobile" IsAllowNull="False" Width="200" runat="server"></XS:TextBoxVl><br />
        ����Email:<XS:TextBoxVl ID="txtEmail" IsAllowNull="False" runat="server"></XS:TextBoxVl><br />
        <asp:Button ID="btnSave" runat="server" Text=" �� �� " />
        </div>
        </form>
    </div>
    <div style="clear: both;">
        <!--#include file="footer.inc" -->
    </div>
</body>
</html>
