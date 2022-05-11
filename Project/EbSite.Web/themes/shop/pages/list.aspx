<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.list" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control.xsPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
</head>
<body>
    <!--#include file="headernav.inc"-->
    <!----中间--->
    <div class="eb-content">
        <div class="container">
            <!---中间--->
            <div class="lstdata">
                <div class="fleft">
                    <div class="lstl">
                        <div class="lstltop">
                            <li>
                                <div class="ico4 all">
                                </div>
                                推荐商品</li></div>
                        <div class="lstllst">
                            <XS:Widget ID="Widget1" WidgetName="分类页推荐商品" WidgetID="d58bc246-4fd0-472c-8258-dd4a812feda5"
                                runat="server" />
                        </div>
                    </div>
                    <div class="lstl">
                        <div class="lstltop">
                            <li>
                                <div class="ico4 all">
                                </div>
                                最近浏览的商品</li></div>
                        <div class="lstllst">
                            <XS:Widget ID="Widget2" WidgetName="分类页推荐商品" WidgetID="d58bc246-4fd0-472c-8258-dd4a812feda5"
                                runat="server" />
                        </div>
                    </div>
                </div>
                <!---中间右侧--->
                <div class="lstr">
                    <!--右一--->
                    <div class="lstrtop">
                        <li>
                            <%=Model.ClassName %>-商品筛选</li></div>
                    <div class="soclass">
                        <%-- <XS:Widget ID="Widget1" WidgetName="分类页-商品属性" WidgetID="8e13c534-d4e3-46de-b1d1-d313e0131546"
                            runat="server" />	--%>
                        <XS:Repeater ID="rpSpecialSmall" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <div class="sotab b">
                                    <ul>
                                        <li class="w90">车型:</li>
                                        <li><font style="font-weight: normal;">
                                            <%#Eval("Text")%></font></li>
                                        <br />
                                        <li class="w650" style="margin-left: 95px;">
                                            <dt><a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %> ">不限</a></dt>
                                            <asp:Repeater ID="rpSubList" runat="server">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <dt><a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %>">
                                                        <%#Eval("Text")%></a></dt>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </li>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                </div>
                            </ItemTemplate>
                        </XS:Repeater>
                        <XS:Repeater ID="rpSpecial" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <div class="sotab b">
                                    <ul>
                                        <li class="w90">车型:</li>
                                        <li class="w650">
                                            <dt><a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %> ">不限</a></dt>
                                            <asp:Repeater ID="rpSubList" runat="server">
                                                <ItemTemplate>
                                                    <dt><a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %>">
                                                        <%#Eval("Text")%></a></dt>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </li>
                                </div>
                            </ItemTemplate>
                        </XS:Repeater>
                        <XS:Repeater ID="rpBrand" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <div class="sotab b">
                                    <ul>
                                        <li class="w90">品牌:</li>
                                        <li class="w650">
                                            <dt><a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %> ">不限</a></dt>
                                            <asp:Repeater ID="rpSubList" runat="server">
                                                <ItemTemplate>
                                                    <dt><a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %>">
                                                        <%#Eval("Text")%></a></dt>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </li>
                                </div>
                            </ItemTemplate>
                        </XS:Repeater>
                        <XS:Repeater ID="rpSKUList" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <div class="sotab b">
                                    <ul>
                                        <li class="w90">
                                            <%#Eval("Text")%>:</li>
                                        <li class="w650">
                                            <dt><a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %> ">不限</a></dt>
                                            <asp:Repeater ID="rpSubList" runat="server">
                                                <ItemTemplate>
                                                    <dt><a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %>">
                                                        <%#Eval("Text")%></a></dt>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </li>
                                </div>
                            </ItemTemplate>
                        </XS:Repeater>
                    </div>
                    <!--右二bnr--->
                    <div class="socon">
                        <div class="sopx">
                            <span>排序：</span>
                            <li><a href="javascript:void(0)" id="sort1">销量</a></li>
                            <li><a href="javascript:void(0)" id="sort2" title="按价格排序从低到高">价格↑</a></li>
                            <li><a href="javascript:void(0)" id="sort3" title="按价格排序从高到低">价格↓</a></li>
                            <li><a href="javascript:void(0)" id="sort4">评论数</a></li>
                            <li><a href="javascript:void(0)" id="sort5">上架时间</a></li>
                        </div>
                        <div class="pagin pagin-m">
                            <li>
                                <dl>
                                    共 <font style="font-weight: bold">
                                        <%=pgCtr.AllCount %></font> 个商品</dl>
                            </li>
                            <li>
                                <img src="<%=base.ThemeCss %>images/lin3.png" style="float: left; margin-top: -2px;
                                    margin-left: 5px;" />
                                <span class="text">
                                    <%=pgCtr.PageIndex%>/<%=pgCtr.PageCount %></span>
                                <%--<span class="prev-disabled">上一页<b></b></span>--%>
                                <a href="#" class="next" id="uppg">上一页</a> <a href="#" class="next" id="nextpg">下一页</a>
                            </li>
                        </div>
                    </div>
                    <!--右二bnr--->
                    <div class="pkpro plst">
                        <XS:RepeaterList ID="rpGetClassList" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <li>
                                    <dl>
                                        <div class="<%#Eval("annex9") %> all">
                                        </div>
                                        <a href="<%#HostApi.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                                            <img src="<%#Eval("SmallPic")%>" alt="<%#Eval("newstitle")%>" /></a></dl>
                                    <dl style="height:3em; line-height:1.5em; overflow:hidden; display:block;">
                                        <a href="<%#HostApi.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                                            <%#Eval("newstitle") %></a></dl>
                                    <dl>
                                        <span>￥<%#Eval("Annex16")%></span></dl>
                                    <dl>
                                        <div class="pt1 all">
                                            <a href="<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ShoppingCarUrl(GetSiteID,int.Parse(Eval("id").ToString())) %>">
                                                加入购物车</a></div>
                                        <div class="pt2 all">
                                            <a href="#">关注</a></div>
                                        <div class="pt3">
                                            <a class="btn-compare" id="comp_<%#Eval("id") %>" onclick="AppendContrast(this)"><span></span>对比</a></div>
                                    </dl>
                                </li>
                            </ItemTemplate>
                        </XS:RepeaterList>
                    </div>
                    <div class="lstpage">
                        <XS:PagesContrl ID="pgCtr" CssClass="pageEx" PageSize="18" ShowCodeNum="5" runat="server" />
                    </div>
                    <div class="pop-compare" id="pop-compare" style="bottom: 0px; display:none;" data-load="true">
                        <div class="pop-wrap">
                            <p class="pop-compare-tips">
                            </p>
                            <div class="pop-inner" data-widget="tabs">
                                <div class="diff-hd">
                                    <ul class="tab-btns clearfix">
                                        <li class="current" data-widget="tab-item"><a href="javascript:void(0);" onclick="hidecontrast(1)">对比栏</a></li>
                                        <%-- <li data-widget="tab-item"><a href="javascript:;">最近浏览</a></li>--%></ul>
                                    <div class="operate">
                                        <a class="hide-me" href="javascript:void(0);" onclick="hidecontrast(0)">隐藏</a></div>
                                </div>
                                <div class="diff-bd tab-cons">
                                    <div class="tab-con" data-widget="tab-content">
                                        <div class="diff-items clearfix" id="diff-items">
                                            <dl class="item-empty"><dt>1</dt><dd>您可以继续添加</dd></dl>
                                            <dl class="item-empty"><dt>2</dt><dd>您可以继续添加</dd></dl>
                                            <dl class="item-empty"><dt>3</dt><dd>您可以继续添加</dd></dl>
                                            <dl class="item-empty"><dt>4</dt><dd>您可以继续添加</dd></dl>
                                        </div>
                                        <div class="diff-operate">
                                            <a id="goto-contrast" class="btn-compare-b" href="javascript:void(0);" hrefex="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.Compare(EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID) %>" onclick="gotocompare(this)">对比</a>
                                            <a class="del-items" onclick="ClearCookies()">清空对比栏</a></div>
                                    </div>
                                    <div class="tab-con" style="display: none;" data-widget="tab-content">
                                        <div class="scroll-item clearfix">
                                            <span class="scroll-btn sb-prev disabled" id="sc-prev">&lt;</span>
                                            <span class="scroll-btn sb-next disabled" id="sc-next">&gt;</span>
                                            <div class="scroll-con clearfix">
                                                <ul id="scroll-con-inner"><p class="scroll-loading ac">载入中...</p></ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!---中间右侧--->
            </div>
            <!---中间--->
        </div>
    </div>
    <!----中间--->
    <div class="w ld" id="toppanel">
        <div class="hide" id="sidepanel" style="right: 300.5px; display: block;">
            <span id="side-cmp"><a class="compareHolder" href="javascript:void(0);" onclick="hidecontrast(1)"><b></b>对比栏</a></span></div>
    </div>
    <!--#include file="footer.inc"-->
    <script type="text/javascript" src="<% =ThemePage%>list.js"></script>
</body>
</html>
