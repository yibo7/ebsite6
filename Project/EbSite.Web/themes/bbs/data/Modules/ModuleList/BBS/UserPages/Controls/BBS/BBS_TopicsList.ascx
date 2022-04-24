<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BBS_TopicsList.ascx.cs"
    Inherits=" EbSite.Modules.BBS.UserPages.Controls.BBS.BBS_TopicsList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/CssBbs.css" rel="stylesheet" />
<div id="mainX">
    <div id="mainby">
        <div id="main-middle">
            <div class="main-s-top">
            </div>
            <div class="main-s">
                <div class="main-gg">
                    <span class="gg-bg"></span>公告 * 没有任何公告
                </div>
                <div class="gg-r">
                    版主：杨欢乐</div>
            </div>
            <div class="main-s-down">
            </div>
            <%--  <div class="main-l-bg ">
            </div>--%>
            <div class="middle-div">
                <%--子版块区域--%>
                <%= RetChildSection(isKey) %>
                <XS:Repeater runat="server" ID="bbsSectionChild">      
                    <ItemTemplate>
                        <div class="bbs-">
                            <div class="left-bbs">
                                <%#EbSite.Modules.BBS.ModuleCore.BLL.Channels.GetUrlT(int.Parse(Eval("id").ToString()))%>
                            </div>
                            <div class="right-bbs">
                                <span class="ctent-title-class">
                                    <%#Eval("ChannelName")%></span> 主题: <%#Eval("PostCount")%>, 帖数: <%#Eval("TopicCount")%>
                                            <br />
                                            最后发表: <%#Eval("SatisticsTime")%>
                            </div>
                        </div>
                        <%#EbSite.Modules.BBS.ModuleCore.BLL.Channels.RebackLine((Container.ItemIndex + 1), int.Parse(Eval("ParentID").ToString()))%>
                    </ItemTemplate>           
                </XS:Repeater>
                <%=RetChildSectionFoot(isKey)%>
                <div class="topice-top">
                    <a href="?t=4&bkId=<%=GetID %>" style="cursor: pointer;">
                        <div class="topice-top-l">
                        </div>
                    </a>
                    <div class="topice-top-r">
                        <%--分页--%>
                    </div>
                </div>
                <%--内容区已 --%>
                <div class="ctent">
                    <div class="ctent-top">
                        <span class="ctent-title">
                            <%=GetClassName()%>
                        </span>
                    </div>
                    <div class="topice-title">
                        <div class="topice-title-time">
                            发表时间</div>
                        <div class="topice-title-type">
                            标题
                        </div>
                        <div class="topice-title-lasttime">
                            最后更新</div>
                        <div class="topice-title-hf">
                            回复/查看</div>
                    </div>
                    <%--开始全站置顶循环--%>
                    <XS:Repeater runat="server" ID="repAllTopice">
                        <ItemTemplate>
                            <div class="topice-list-title">
                                <div class="topice-list-pic">
                                    <a href="?t=3&id=<%#Eval("id") %>">
                                        <img src="/Modules/BBS/DataStore/Attachments/img/icons/topic_pinned.gif" /></a>
                                </div>
                                <div class="topice-list-add">
                                    <div class="topice-list-add- topice-list-font">
                                        <%#Eval("UserName")%></div>
                                    <div class="">
                                        <%#EbSite.Core.Strings.cConvert.WriteDate(Eval("CreatedTime").ToString(),2)%></div>
                                </div>
                                <div class="topice-titlestyle">
                                    <a href="?t=3&id=<%#Eval("id") %>">
                                        <%#Eval("TopicTitle")%></a></div>
                                <div class="topice-list-ask">
                                    <div class="topice-list-add- topice-list-font">
                                        <%#Eval("LatestReplyUserName")%></div>
                                    <div class="">
                                        <%#EbSite.Core.Strings.cConvert.WriteDate(Eval("LatestRepliedTime").ToString(),10)%></div>
                                </div>
                                <div class="topice-list-nums">
                                    <div class="topice-list-font topice-list-left-">
                                        <%#Eval("ReplyCount")%>
                                    </div>
                                    <div class="topice-list-clear">
                                        /
                                        <%#Eval("ViewCount")%></div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </XS:Repeater>
                    <%--开始本版块置顶循环--%>
                    <XS:Repeater runat="server" ID="repOwnTopRopice">
                        <ItemTemplate>
                            <div class="topice-list-title">
                                <div class="topice-list-pic">
                                    <a href="?t=3&id=<%#Eval("id") %>">
                                        <img src="/Modules/BBS/DataStore/Attachments/img/icons/topic_sticky.gif" /></a>
                                </div>
                                <div class="topice-list-add">
                                    <div class="topice-list-add- topice-list-font">
                                        <%#Eval("UserName")%></div>
                                    <div class="">
                                        <%#EbSite.Core.Strings.cConvert.WriteDate(Eval("CreatedTime").ToString(),2)%></div>
                                </div>
                                <div class="topice-titlestyle">
                                    <a href="?t=3&id=<%#Eval("id") %>">
                                        <%#Eval("TopicTitle")%></a></div>
                                <div class="topice-list-ask">
                                    <div class="topice-list-add- topice-list-font">
                                        <%#Eval("LatestReplyUserName")%></div>
                                    <div class="">
                                        <%#EbSite.Core.Strings.cConvert.WriteDate(Eval("LatestRepliedTime").ToString(),10)%></div>
                                </div>
                                <div class="topice-list-nums">
                                    <div class="topice-list-font topice-list-left-">
                                        <%#Eval("ReplyCount")%>
                                    </div>
                                    <div class="topice-list-clear">
                                        /
                                        <%#Eval("ViewCount")%></div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </XS:Repeater>
                    <div class="topice-list-mid">
                    </div>
                    <%--开始本版块的帖子循环--%>
                    <XS:Repeater runat="server" ID="repOwnRopice">
                        <ItemTemplate>
                            <div class="topice-list-title">
                                <div class="topice-list-pic">
                                    <a href="?t=3&id=<%#Eval("id") %>">
                                        <%#PicInfo(int.Parse(Eval("ViewCount").ToString()))%>
                                    </a>
                                </div>
                                <div class="topice-list-add">
                                    <div class="topice-list-add- topice-list-font">
                                        <%#Eval("UserName")%></div>
                                    <div class="">
                                        <%#EbSite.Core.Strings.cConvert.WriteDate(Eval("CreatedTime").ToString(),2)%></div>
                                </div>
                                <div class="topice-titlestyle">
                                    <a href="?t=3&id=<%#Eval("id") %>">
                                        <%#Eval("TopicTitle")%></a></div>
                                <div class="topice-list-ask">
                                    <div class="topice-list-add- topice-list-font">
                                        <%#Eval("LatestReplyUserName")%></div>
                                    <div class="">
                                        <%#EbSite.Core.Strings.cConvert.WriteDate(Eval("LatestRepliedTime").ToString(),10)%></div>
                                </div>
                                <div class="topice-list-nums">
                                    <div class="topice-list-font topice-list-left-">
                                        <%#Eval("ReplyCount")%>
                                    </div>
                                    <div class="topice-list-clear">
                                        /
                                        <%#Eval("ViewCount")%></div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </XS:Repeater>
                </div>
                <div class="topice-top">
                    <div class="topice-top-l">
                    </div>
                    <div class="topice-top-r">
                        <%--分页--%>
                    </div>
                </div>
                <div id="ctent-botton">
                    <div class="ctent-top">
                        <span class="ctent-title">在线会员 详细在线列表</span>
                    </div>
                    <div class="ctent-botton-nr">
                        <div class="botton-pic-a">
                        </div>
                        <div class="botton-title-g">
                            管理员</div>
                        <div class="botton-pic-b">
                        </div>
                        <div class="botton-title-g">
                            超级版主
                        </div>
                        <div class="botton-pic-c">
                        </div>
                        <div class="botton-title-g">
                            分类版主
                        </div>
                        <div class="botton-pic-d">
                        </div>
                        <div class="botton-title-g">
                            版主
                        </div>
                        <div class="botton-pic-e">
                        </div>
                        <div class="botton-title-g">
                            注册用户
                        </div>
                        <div class="botton-pic-f">
                        </div>
                        <div class="botton-title-g">
                            游客</div>
                    </div>
                    <div style="clear: both; font-size: 13px; margin-left:auto; margin-right:auto; width:500px; margin-top:10px;">
                        <div class="botton-topice-a">
                        </div>
                      <div class="botton-title-g">  普通主题</div>
                        <div class="botton-topice-b">
                        </div>
                       <div class="botton-title-g"> 热门主题</div>
                        <div class="botton-topice-c">
                        </div>
                       <div class="botton-title-g"> 锁定主题</div>
                        <div class="botton-topice-d">
                        </div>
                       <div class="botton-title-g"> 总置顶主题</div>
                        <div class="botton-topice-e">
                        </div>
                        <div class="botton-title-g">置顶主题</div>
                    </div>
                </div>
            </div>
            <%--   <div class="main-r-bg">
            </div>--%>
            <div class="main-lf-down">
            </div>
            <div class="main-lf-down-bg">
            </div>
            <div class="main-lf-down-rr">
            </div>
        </div>
        <div id="main-down">
            Copyright &copy;2005 - 2011 Tencent. All Rights Reserved 北京亿博科技 版权所有
        </div>
    </div>
</div>
