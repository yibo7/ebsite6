<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.forgroup" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>
<body>
    <div id="centerbox">
        <!--#include file="header.inc" -->
        <form  runat="server">
            <div style="text-align:center;padding-top:30px;">
        ����������ϵ��ʽ,�Ա��Ź��ɹ�֪��:<br />
        �����ֻ���:<XS:TextBoxVl IsAllowNull="False"   ID="txtMobile" runat="server"></XS:TextBoxVl><br />
        ����Email:<XS:TextBoxVl IsAllowNull="False" ID="txtEmail" runat="server"></XS:TextBoxVl><br />
        ϣ���ļ۸�:<XS:TextBoxVl IsAllowNull="False" ID="txtPrice"  runat="server"></XS:TextBoxVl><br />
        <asp:Button ID="btnSave" runat="server" Text=" �� �� " />
                </div>
        </form>
    </div>
    <div style="clear: both;">
        <!--#include file="footer.inc" -->
    </div>
</body>
</html>
