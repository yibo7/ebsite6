<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.special" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>

<body>
    <!--#include file="header.inc" -->
    <div class="wrapper mT5">
        <div id="position">
            <span style="font-size: 13px; color: #333333">当前位置：</span>
            <a href="<%=DomainName%>">
                <b><%=SiteName%></b>
            </a>>
	    	    <a href="<%= EbSite.Base.Host.Instance.GetSpecialHref(Model.id,0)%>" target="_self">
                    <%=Model.SpecialName%> 
                </a>
        </div>
    </div>

    <div class="wrapper mT5">
        <div id="dedenews">
            <div id="newtitle" class="fLeft">专题：</div>
            <div id="news" class="fLeft">
                <XS:Widget ID="Widget1" WidgetID="1e99dc56-3a30-445c-994e-37d15f45cbaa" runat="server" />
            </div>
            <div id="newright" class="fRight"></div>
        </div>
    </div>

    <div class="wrapper mT5">
        <div class="utitle">
            <div class="utitlei">
                <div class="title">
                    <span class="title_t fLeft"><span class="title_t_i fLeft">
                        <h2><a href="<%= EbSite.Base.Host.Instance.GetSpecialHref(Model.id,0)%>" target="_self"><%=Model.SpecialName%></a></h2>
                    </span></span>
                    <div class="iterm fRight" style="padding-right: 60px;">
                    </div>
                </div>
            </div>
        </div>
        <div class="ucontent">
            <div id="tech" class="clear">

                <div class="arc_list">

                    <ul class="list_more">
                        <asp:Repeater ID="rpSpecialList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <input type="checkbox" value="'id':' <%#Eval("ID")%>','n':' <%#Eval("NewsTitle")%>','u':' <%#Eval("HtmlName")%>'" />
                                    <a title="<%#Eval("newstitle")%>" href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>" target="_blank">
                                        <%#Eval("newstitle")%>
                                    </a>
                                    <span>
                                        <a title="<%#Eval("classname")%>" href="<%#EbSite.Base.Host.Instance.GetClassHref(int.Parse(Eval("classid").ToString()),0)%>" target="_blank">
                                            <%#Eval("classname")%>
                                        </a></span>

                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <XS:PagesContrl ID="pgCtr" runat="server" />
                </div>
                <XS:RepeaterList ID="rpGetSubSpecialList" runat="server">
                    <ItemTemplate>
                        <div class="smdata">
                            <div class="booktit">
                                <li class="xgqname">
                                    <%#Eval("SpecialName")%></li>
                            </div>
                        </div>
                    </ItemTemplate>
                </XS:RepeaterList>

                <div class="clear"></div>
                <div style="top: 1475px;" id="foot"></div>
                <!--#include file="footer.inc" -->
                <%=KeepUserState()%>
</body>
</html>
