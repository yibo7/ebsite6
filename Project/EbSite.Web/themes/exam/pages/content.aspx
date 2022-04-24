<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.content" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <!--#include file="headerlist.inc" -->
    <div class="clear"></div>
    <div class="mainbox">
            <div class="contentbox questionlist">
                <XS:Repeater ID="rptDataList" runat="server">
                    <ItemTemplate>
                      <div>
                          ��<font color="red"><%#Container.ItemIndex + 1%></font>��:<%#Eval("Questions")%>[<%#Eval("Score")%>��]
                      </div>
                    </ItemTemplate>
                </XS:Repeater>
            </div>
    </div>

    <script src="<%=this.ThemePage%>content.js" type="text/javascript"></script>
    <!--#include file="footer.inc" -->
</body>
</html>
