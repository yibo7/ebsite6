<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.Search" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                            <a href="<%=DomainName%>">
                                <b><%=SiteName%></b>
                            </a>>
	    	                商品搜索    
                        </div>
                    </div>
                </li>
            </div>
            <div class="lstdata">
                <div class="fleft">
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
                    <div class="lstl">
                        <div class="lstltop">
                            <li>
                                <div class="ico4 all"></div>
                                最近浏览的商品</li>
                        </div>
                        <div class="lstllst">
                            <XS:Widget ID="Widget3" WidgetName="分类页推荐商品" WidgetID="d58bc246-4fd0-472c-8258-dd4a812feda5" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="lstr">
                    <div>共搜索到<%=iSearchCount%>条与"<span style="color:red; font-weight:bold;"><%=KeyWord%></span>"相关的数据 </div>
                    <div class="pkpro plst">
                        <asp:Repeater ID="rpGetList" runat="server">
                            <ItemTemplate>
                            <li>
                                <dl>
                                    <div class=" all"></div>
                                    <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><img src="<%#Eval("SmallPic")%>" alt="<%#Eval("newstitle")%>" width="110" height="110" /></a>
                                </dl>
                                <dl>
                                    <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%#Eval("newstitle") %></a>
                                    <a title="<%#Eval("classname")%>" href="<%#EbSite.Base.Host.Instance.GetClassHref(int.Parse(Eval("classid").ToString()),0)%>" target="_blank"><%#Eval("classname")%></a>
                                </dl>
                                <dl>
                                    <span>￥<%#Eval("Annex16")%></span>
                                </dl>
                                <dl>
                                    <div class="pt1 all"><a href="#">加入购物车</a></div>
                                    <div class="pt2 all"><a href="#">关注</a></div>
                                    <div class="pt3 all"><input type="checkbox" name="checkbox1"><a href="#">对比</a></div>
                                </dl>
                            </li></ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="lstpage">
                        <XS:PagesContrl ID="pgCtr" CssClass="pageEx" Linktype="Aspx" PageSize="6" ShowCodeNum="5" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--#include file="footer.inc" -->
    <%=KeepUserState()%>
    <span runat="server" id="datacount"></span>
</body>
</html>
<script type="text/javascript">
    $("#k").val("<%=base.KeyWord %>");
</script>