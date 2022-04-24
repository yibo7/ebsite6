<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bbslist.ascx.cs" Inherits=" EbSite.Modules.BBS.AdminPages.Controls.BBS.bbslist" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="/Modules/bbs/DataStore/Attachments/images/index.css" rel="stylesheet" />
<style>
    
    #MarqueeR
    {
        height: 20px;
        overflow: hidden;
    }
    #MarqueeR div
    {
        height: 58px;
    }
    
      #MarqueeL
    {
        height: 20px;
        overflow: hidden;
    }
    #MarqueeL div
    {
        height: 58px;
    }
</style>
<div style="width: 980px;">
    <div class="clearfix">
        <div class="left main">
            <div class="mainBd">
                <!--slider开始 -->
                <div class="slider clearfix">
                    <h2 class="left sliderHd">
                        论坛新帖</h2>
                    <div class="right sliderBd">
                        <ul class="clearfix" id="slider">
                          
                            <li>
                                <div id="MarqueeL">
                                    <XS:Repeater ID="rpGdXTL" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 58px">
                                                <a href='BBS.aspx?muid=<%=pid%>&mid=<%=sid%>&t=14&id=<%# Eval("id")%>'><%# Eval("TopicTitle")%></a>&nbsp;[<%# Eval("ReplyCount")%>/<%# Eval("ViewCount")%>]
                                                &nbsp;<%# Eval("UserName")%></div>
                                        </ItemTemplate>
                                    </XS:Repeater>
                                </div>
                            </li>
                            <li>
                                <div id="MarqueeR">
                                    <XS:Repeater ID="rpGdXTR" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 58px">
                                                <a href='BBS.aspx?muid=<%=pid%>&mid=<%=sid%>&t=14&id=<%# Eval("id")%>'><%# Eval("TopicTitle")%></a>&nbsp;[<%# Eval("ReplyCount")%>/<%# Eval("ViewCount")%>]
                                                &nbsp;<%# Eval("UserName")%></div>
                                        </ItemTemplate>
                                    </XS:Repeater>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <!--slider结束 -->
                <!--category开始 -->
                <div class="category">
                    <table cellpadding="0" cellspacing="0">
                        <XS:Repeater ID="rpBK" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="bbsitemDetail">
                                        <a class="left bbsitemImg" href='bbs.aspx?muid=<%=pid%>&mid=<%=sid%>&t=12&ChannelId=<%# Eval("id")%>'>
                                            <img style="width: 50px; height: 50px" src='<%# Eval("ChannelImageUrl")%>' onerror="this.src='/Modules/bbs/DataStore/Attachments/images/noimg.gif';" />
                                        </a><b><a href='bbs.aspx?muid=<%=pid%>&mid=<%=sid%>&t=12&ChannelId=<%# Eval("id")%>'>
                                            <%# Eval("ChannelName")%></a> </b>
                                        <p>
                                            <%# Ms(Eval("ChannelDescription").ToString())%></p>                                                                                  
                                        <div class="master">
                                            <label class="masterText">
                                                版主：</label>
                                            <a href="#">
                                                <%# getChannelMasters(int.Parse(Eval("id").ToString()))%></a>
                                        </div>
                                    </td>
                                    <td>
                                        <label>
                                            今日：</label><span class="highlight" style="color: red;"><%# GetTopicCount(Eval("id").ToString(),"today")%></span>
                                        <br />
                                        <label>
                                            全部：</label><span><%# GetTopicCount(Eval("id").ToString(),"")%></span>
                                    </td>
                                    <td class="bbsitemTopic">
                                        <div class="bbsitemTopicBd">
                                            <div>
                                                <a href="BBS.aspx?muid=<%=pid%>&mid=<%=sid%>&t=14&id=<%# getTopic(int.Parse(Eval("id").ToString())).id%>">
                                                    <%# getTopic(int.Parse(Eval("id").ToString())).TopicTitle%></a></div>
                                            <div>
                                                <a class="topicUser" href="#">
                                                    <%# getTopic(int.Parse(Eval("id").ToString())).UserName%></a><span class="topicSep">-</span><span
                                                        class="topicTime"><%# getTopic(int.Parse(Eval("id").ToString())).CreatedTime%></span></div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </XS:Repeater>
                    </table>
                </div>
                <!--category结束 -->
            </div>
            <div class="mainFt">
            </div>
        </div>
        <div class="right aside">
            <!--帖子导读开始 -->
            <div class="asideSection mod">
                <div class="asideSectionHd clearfix">
                    <strong class="left">新帖导读</strong>
                    <div class="right asideTab">
                        <a style="color: Black">新帖</a></div>
                </div>
                <div class="asideSectionBd">
                    <ul class="topicList">
                        <XS:Repeater ID="rpXt" runat="server">
                            <ItemTemplate>
                                <li class="top"><a href='BBS.aspx?muid=<%=pid%>&mid=<%=sid%>&t=14&id=<%# Eval("id")%>'>
                                    <%# Eval("TopicTitle")%></a></li>
                            </ItemTemplate>
                        </XS:Repeater>
                    </ul>
                </div>
                <div class="asideSectionFt">
                </div>
            </div>
            <div class="asideSection mod">
                <div class="asideSectionHd clearfix">
                    <strong class="left">精华导读</strong>
                    <div class="right asideTab">
                        <a style="color: Black">精华帖</a></div>
                </div>
                <div class="asideSectionBd">
                    <ul class="topicList">
                        <XS:Repeater ID="rpJH" runat="server">
                            <ItemTemplate>
                                <li class="top"><a href='BBS.aspx?muid=<%=pid%>&mid=<%=sid%>&t=14&id=<%# Eval("id")%>'>
                                    <%# Eval("TopicTitle")%></a></li>
                            </ItemTemplate>
                        </XS:Repeater>
                    </ul>
                </div>
                <div class="asideSectionFt">
                </div>
            </div>
            <!--帖子导读结束 -->
        </div>
    </div>
</div>
<script>
    var Mar = document.getElementById("MarqueeR");
    var MarL = document.getElementById("MarqueeL");
    var child_div = Mar.getElementsByTagName("div");
    var child_divL = MarL.getElementsByTagName("div");
    var picH = 60; //移动高度 
    var scrollstep = 3; //移动步幅,越大越快 
    var scrolltime = 20; //移动频度(毫秒)越大越慢 
    var stoptime = 3000; //间断时间(毫秒) 
    var tmpH = 0;
    Mar.innerHTML += Mar.innerHTML;
    MarL.innerHTML += MarL.innerHTML;
    function start() {
        if (tmpH < picH) {
            tmpH += scrollstep;
            if (tmpH > picH) tmpH = picH;
            Mar.scrollTop = tmpH;
            MarL.scrollTop = tmpH;
            setTimeout(start, scrolltime);
        } else {
            tmpH = 0;
            Mar.appendChild(child_div[0]);
            Mar.scrollTop = 0;
            MarL.appendChild(child_divL[0]);
            MarL.scrollTop = 0;
            setTimeout(start, stoptime);
        }
    }
    onload = function () { setTimeout(start, stoptime) }; 
</script>