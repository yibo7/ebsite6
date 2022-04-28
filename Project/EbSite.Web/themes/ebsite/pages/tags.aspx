<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.tags" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>

<body>
    <!--#include file="headerlist.inc" -->

    <div class="mainbox">

        <div style="margin-top: 10px;" class="contentbox">
            <div style="width: 185px;" class="fLeft">
                <div class="indexclassp">
                    <div class="indexclass">
                        热门标签
                    </div>
                    <XS:Widget ID="Widget10" WidgetName="获取热门标签" WidgetID="48a468fb-c0ba-4ebe-ad6b-b7e3f555f865" runat="server" />
                </div>
            </div>
            <div class="fRight">
                <div class="listbox">
                    <div class="datalist">
                        <asp:Repeater ID="rpList" runat="server">
                            <ItemTemplate>
                                <span>
                                    <a href="<%#EbSite.Base.Host.Instance.TagsSearchList(Eval("ID"),1)%>"><%#Eval("TagName")%></a>(<font color="#ff0000"> <%#Eval("num")%></font>)</span>
                            </ItemTemplate>
                        </asp:Repeater>

                        <XS:PagesContrl ID="pgCtr" runat="server" />
                    </div>
                </div>
            </div>



        </div>

    </div>
    <div class="clear"></div>

    <!--#include file="footer.inc" -->
    <span runat="server" id="datacount"></span>

    <script>
        tagcolor();
    </script>
</body>
</html>

