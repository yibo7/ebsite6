<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="EbSite.Web.Pages.top" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <!--#include file="headerlist.inc" -->


    <div class="mainbox">

        <div style="margin-top: 10px;" class="contentbox">
            <div style="width: 185px;" class="fLeft">
                <div class="indexclassp">
                    <div class="indexclass">
                        总排行
                    </div>
                    <div class="datalist">
                        <XS:Widget ID="Widget4" WidgetName="排行数据-总排行" WidgetID="c825775f-5a4b-45b4-8556-2edb65fc1000" runat="server" />
                    </div>
                </div>
            </div>
            <div class="fRight">
                <div class="listbox">
                    <div class="tabtop">

                        <li <%=GetCurrentCss("0","current","t") %>><a href="<%=HostApi.GetTopHref(0,1)%>">总排行</a></li>
                        <li <%=GetCurrentCss("1","current","t") %>><a href="<%=HostApi.GetTopHref(1,1)%>">今日排行</a></li>
                        <li <%=GetCurrentCss("2","current","t") %>><a href="<%=HostApi.GetTopHref(2,1)%>">本周排行</a></li>
                        <li <%=GetCurrentCss("3","current","t") %>><a href="<%=HostApi.GetTopHref(3,1)%>">本月排行</a></li>
                        <li <%=GetCurrentCss("4","current","t") %>><a href="<%=HostApi.GetTopHref(4,1)%>">最新数据</a></li>
                        <li <%=GetCurrentCss("5","current","t") %>><a href="<%=HostApi.GetTopHref(5,1)%>">推荐数据</a></li>
                    </div>
                    <div class="datalist">
                        <asp:Repeater ID="rpTop" runat="server">
                            <ItemTemplate>
                                <li class="news_title">
                                    <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%#Eval("newstitle")%></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <XS:PagesContrl PageSize="50" ID="pgCtr" runat="server" />
                    </div>
                </div>
            </div>



        </div>

    </div>
    <div class="clear"></div>

    <!--#include file="footer.inc" -->




</body>
</html>
