<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.EvaluatePg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>评价系统</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body><link type="text/css" href="<%=EbSite.Base.Host.Instance.ThemePath %>pj/css.css" rel="stylesheet" />
    <!--#include file="header.inc"-->
    <div class="content">
        <div class="container">
            <div style="float: left; width: 200px; height: 400px; margin-top: 5px;">
                <div style="border: 1px solid #CCCCCC;">
                    <div class="mt">
                        <h2>
                            商品信息</h2>
                    </div>
                    <div style="padding:10px;min-height:130px;">
                         <XS:Widget ID="Widget1" WidgetName="商品评价-左则商品信息"  WidgetID="8f13f347-f06e-4068-a351-3cd5eca4f4ca" runat="server"/>
                    </div>
                </div>
            </div>
            <div style="float: right; width: 780px; margin: 0px;">
                <form id="form1" runat="server">
                <div style="display: block" class="m m2">
                    <div class="mt">
                        <h3>
                            商品评价</h3>
                    </div>
                    <div class="mc loaded">
                        <div id="i-comment">
                            <%=GetSocre()%>
                           <%-- <div class="btns">
                                <div>
                                    我购买过此商品</div>
                                <a class="btn-comment" href="#pj">我要评价</a>
                                <div>
                                    <a href="#" target="_blank">查看全部评价</a></div>
                            </div>--%>
                        </div>
                    </div>
                </div>
                <div class="">
                    <div class="zhuyi">
                        <div id="tagsask" class="ttl queType" style="background: #fff7e3; height: 31px;">
                            <div name="tg0" u="?" class="focus" style="cursor: pointer;">
                                全部评价（<%=AllPJ %>）
                            </div>
                            <div name="tg1" u="?t=1" style="cursor: pointer;">
                                好评（<%=GooDPJ %>）
                            </div>
                            <div name="tg2" u="?t=2" style="cursor: pointer;">
                                中评（<%=MidPJ%>）
                            </div>
                            <div name="tg3" u="?t=3" style="cursor: pointer;">
                                差评（<%=BadPJ%>）
                            </div>
                        </div>
                        <div style="height: 100%;">
                            <asp:Repeater ID="rpComment" runat="server">
                                <ItemTemplate>
                                    <div class="mc" id="comment-0" data-widget="tab-content">
                                        <div class="item">
                                            <div class="user">
                                                <div class="u-icon">
                                                    <div style="text-align: center">
                                                        <img id="AvatarBig" src='<%#base.HostApi.AvatarBig(Convert.ToInt32(Eval("userid"))) %>'
                                                            width="80" />
                                                    </div>
                                                </div>
                                                <div class="u-name">
                                                    <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("username").ToString())%>"
                                                        target="_blank">
                                                        <%#Eval("username") %>
                                                    </a>
                                                </div>
                                                <span class="u-level"><span style="color: #088000">
                                                    <%# EbSite.BLL.UserLevel.Instance.GetUserLevelForScore(UserInfos(Eval("username").ToString()).Credits).LevelName%>
                                                </span></span>
                                            </div>
                                            <div class="i-item" style="width: 620px;">
                                                <div class="o-topic">
                                                    <%#GetScoreStyle(Eval("EvaluationScore").ToString())%><span class="date-comment">
                                                        <%#Eval("DateAndTime")%></span>
                                                </div>
                                                <div class="comment-content">
                                                    
                                                    <dl>
                                                        <dt>使用心得：</dt>
                                                        <dd>
                                                            <%# Eval("quote").ToString()%></dd></dl>
                                                    <br />
                                                    <dl>
                                                        <dt>购买日期：</dt>
                                                        <dd>
                                                            购买日期
                                                        </dd>
                                                    </dl>
                                                    <br />
                                                    <dl>
                                                        <dt>地区：</dt>
                                                        <dd>
                                                            购买人地区
                                                        </dd>
                                                    </dl>
                                                </div>
                                                <div class="btns">
                                                    <div id="b2edfbb1-1711-428e-9b8a-43cf02a59946" class="useful">
                                                        <span style="margin-top: 4px; margin-right: 8px;">此评价对我</span> <a class="btn-agree"
                                                            title="<%#Eval("Support")%>" href="#none" onclick="btnagree(<%#Eval("id")%>)"
                                                            name="agree">
                                                            <div id="support-k">
                                                                有用(<%#Eval("Support")%>)</div>
                                                        </a><a class="btn-oppose" title="<%#Eval("Discourage")%>" href="#none" name="oppose"
                                                            onclick="btnoppose(<%#Eval("id")%>)">
                                                            <div id="oppose-k">
                                                                没用(<%#Eval("Discourage")%>)</div>
                                                        </a>
                                                    </div>
                                                  <%--  <a class="btn-reply" onclick="rply(<%#Eval("id")%>)">回复</a>--%>
                                                </div>
                                                <br />
                                                <%#GetChindRep(int.Parse(Eval("id").ToString())) %>
                                            </div>
                                            <div class="corner tlx">
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div id="pg">
                                <XS:PagesContrl ID="pgCtr" Linktype="Aspx" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                </form>
            </div>
        </div>
    </div>
    <!--#include file="footer.inc"-->
</body>
</html>
