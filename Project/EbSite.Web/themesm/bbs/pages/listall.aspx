<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.list" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
</head>
<body>
    <div id="page">
        <div style="width:100%;height:auto;position:fixed;top:0px;left:0px;z-index:500;">
    <!--#include file="header.inc" -->
    <div class="w-navigator">
       <!--#include file="nav.inc" -->
    </div>
            </div>
    <div id="container1" style="z-index:100;margin-top:88px;">
        <ul class="data-list">
            <XS:RepeaterList ID="rpGetSubClassList" runat="server">
                <ItemTemplate>
                    <li class="listitem-classname" id="<%# Eval("id") %>">
                        <div>   <span class="classname"><%#Eval("ClassName")%></span>
                        <span class="arrow"></span></div>
                        <div>
                              <asp:Repeater ID="rpSub" runat="server">
                                <ItemTemplate>
                                    <div class="subclass">
                                        <a href="<%#HostApi.MGetClassHref(Eval("ID"),1) %>"><%#Eval("ClassName")%></a>
                                        (<span><%#Eval("Annex11")%></span>)
                                    </div>
                                 </ItemTemplate>
                            </asp:Repeater>
                        </div>
                     
                    </li>
                </ItemTemplate>
            </XS:RepeaterList>

        </ul>
    </div>
    </div>


    <!--#include file="foot.inc" -->
    <%=KeepUserState()%>
</body>
</html>
