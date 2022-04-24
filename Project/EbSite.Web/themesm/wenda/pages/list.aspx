<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.list" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!doctype html>
<html>
<head runat="server">
  
</head>
<body>
    <div id="page">
        <div class="cont">
            <!--#include file="header.inc" -->
            <div class="w-navigator">
                <a <%=rpGetSubClassList.Items.Count>0?"class='selclass'":"class='selclassex'" %>><%=Model.ClassName %></a><b>|</b> <a href="<%=HostApi.MGetIndexHref() %>">首页</a><b>|</b>
                <a href="<%=HostApi.MGetSpecialHref() %>">专题</a><b>|</b> <a href="<%=HostApi.MUccIndexRw %>">
                    我的中心<span class="unread"></span></a>
            </div>
            <div id="container1">
                <ul class="data-list">
                    <XS:RepeaterList ID="rpGetClassList" runat="server">
                        <ItemTemplate>
                            <li><a href="<%#HostApi.MGetContentLink(Eval("ID"),Eval("classid")) %>"><span id="Span1">
                                <%#Eval("newstitle")%></span></a> <span class="arrow"></span></li>
                        </ItemTemplate>
                    </XS:RepeaterList>
                       
                </ul>
                <div class="btnloadmore">加载更多...</div>
                 <XS:PagesContrl PageSize="5" ID="pgCtr"  runat="server" />
            </div>
            <!--#include file="foot.inc" -->
        </div>
       <div class="panel" style="margin-left: 0px; margin-right: 0px; padding-left: 0px; padding-right: 0px;">
            <h2 style="color: white; padding-left: 20px;"><%=Model.ClassName %></h2>
            <div style="width: 100%; height: 2px; margin-top: 10px; background-color: #514f4f; z-index: 1;">
                <div style="height: 2px; width: 108px; margin: 0px; padding: 0px; background-color: #b7b7b7; z-index: 999;"></div>
            </div>
            <ul class="panel-dir">
                <XS:RepeaterList ID="rpGetSubClassList" runat="server">
                    <ItemTemplate>
                        <li>&nbsp;&nbsp;<a href="<%#EbSite.Base.Host.Instance.MGetClassHref(Eval("id"),1,0)%>"><%# Eval("classname")%></a></li>
                    </ItemTemplate>
                </XS:RepeaterList>
            </ul>
        </div>
    </div>
    <script type="text/javascript">
        toggleright("selclass", "panel", "cont", "right");
        loadpage(".data-list", ".btnloadmore", '.data-list li');
    </script>
</body>
</html>
