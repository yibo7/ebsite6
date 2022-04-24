<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.special" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title></title>
</head>
<body>
    <!--#include file="header.inc" -->
    <div class="content">
        <div class="container">
            <div class="contop">
                <li>
                    <div class="wrapper mT5">
                        <div id="position">
                            <span style="font-size: 13px; color: #333333">当前位置：</span>
                            <a href="<%=DomainName%>"><b><%=SiteName%></b></a>><a href="<%= EbSite.Base.Host.Instance.GetSpecialHref(Model.id,0)%>" target="_self"><%=Model.SpecialName%></a>
                        </div>
                    </div>
                </li>
            </div>
            <div class="lstdata">
                <div class="fleft">
                    <div class="lstl">
                        <div class="lstltop">
                            <li><div class="ico4 all"></div>专题列表</li>
                        </div>
                        <div class="lstllst subspecial">
                             <asp:Repeater ID="rpSubSpecial" runat="server" EnableViewState="False" >
                              <ItemTemplate>   
                                        <a href="<%#EbSite.Base.Host.Instance.GetSpecialHref(int.Parse(Eval("ID").ToString()),1)%>"><%# Eval("SpecialName")%></a>
                                </ItemTemplate>
                            </asp:Repeater>  
                        </div>
                    </div>
                    <div class="lstl">
                        <div class="lstltop">
                            <li>
                                <div class="ico4 all"></div>
                                推荐商品</li>
                        </div>
                        <div class="lstllst">
                            <XS:Widget ID="Widget2" WidgetName="分类页推荐商品" WidgetID="d58bc246-4fd0-472c-8258-dd4a812feda5" runat="server" />

                        </div>
                    </div>
                    
                </div>
                <div class="lstr">
                    <div class="lstrtop">
                        <li>
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
                            </div>
                        </li>
                    </div>
                    <div class="pkpro plst">
                        <XS:RepeaterList ID="rpSpecialList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <dl>
                                        <div class=" all">
                                        </div>
                                        <a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID)%>">
                                            <img src="<%#Eval("SmallPic")%>" alt="<%#Eval("newstitle")%>" width="110" height="110" /></a>
                                    </dl>
                                    <dl>
                                        <a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID)%>">
                                            <%#Eval("newstitle") %></a>
                                        <a title="<%#Eval("classname")%>" href="<%#EbSite.Base.Host.Instance.GetClassHref(int.Parse(Eval("classid").ToString()),0)%>" target="_blank">
                                            <%#Eval("classname")%>
                                        </a>
                                    </dl>
                                    <dl>
                                        <span>￥<%#Eval("Annex16")%></span>
                                    </dl>
                                    <dl>
                                        <div class="pt1 all">
                                            <a href="#">加入购物车</a>
                                        </div>
                                        <div class="pt2 all">
                                            <a href="#">关注</a>
                                        </div>
                                        <div class="pt3 all">
                                            <input type="checkbox" name="checkbox1"><a href="#">对比</a>
                                        </div>
                                    </dl>
                                </li>
                            </ItemTemplate>
                        </XS:RepeaterList>
                    </div>
                    <div class="lstpage">
                        <XS:PagesContrl ID="pgCtr" CssClass="pageEx"  ShowCodeNum="5" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--#include file="footer.inc" -->
    <script type="text/javascript" src="<% =ThemePage%>list.js"></script>
</body>
</html>
