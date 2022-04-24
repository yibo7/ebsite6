<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BBS_TopicsList.ascx.cs"
    Inherits=" EbSite.Modules.BBS.AdminPages.Controls.BBS.BBS_TopicsList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="/Modules/bbs/DataStore/Attachments/images/index.css" rel="stylesheet" />

<div class="caption commonTopic">
    <div>
        <div class="captionBd clearfix">
            <h1 class="left categoryTitle">
              <%=bbsC.ChannelName%></h1>
            <div align="right">
                <XS:EasyuiDialog ID="WinBox8" runat="server" Text="发表新帖" Title="发表新帖" IsColseReLoad="true"
                    LinkModel="图片连接" HrefImg="/Modules/bbs/DataStore/Attachments/images/xt.jpg" />
            </div>
        </div>
        <div class="caption commonTopic">
            <div class="captionBd clearfix" style="height: 25px">
                <table width="100%" style="height: 20px">
                    <colgroup>
                        <col width="20" />
                        <col />
                        <col width="120" />
                        <col width="95" />
                        <col width="100" />
                    </colgroup>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            置顶帖子
                        </td>
                        <td>
                            作者
                        </td>
                        <td>
                            回复/查看
                        </td>
                        <td align="right">
                            最后更新
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <XS:Repeater ID="rpQZZD" runat="server">
            <ItemTemplate>
                <div class="clearfix topWrap topicList">
                    <table width="98%">
                        <tr>
                            <td style="width: 70%">
                                <div>
                                    <span class="topicIcon flagTop"></span><span class="topic"><a class="" href='BBS.aspx?muid=<%=pid%>&mid=<%=sid%>&t=14&id=<%# Eval("ID")%>'>
                                        <%# Eval("TopicTitle")%></a></span></div>
                            </td>
                            <td style="width: 13%">
                                <div class="user">
                                    <div>
                                        <%# Eval("UserName")%></div>
                                    <div class="time">
                                        <%# Eval("CreatedTime")%></div>
                                </div>
                            </td>
                            <td style="width: 12%;">
                                <div>
                                    <%# Eval("ReplyCount")%>/<%# Eval("ViewCount")%>
                                </div>
                            </td>
                            <td align="center">
                                <div class="reply">
                                    <div>
                                        <%# Eval("LatestReplyUserName")%>
                                    </div>
                                    <div class="time">
                                        <%# Eval("LatestRepliedTime","{0:yyyy-MM-dd}")%>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </XS:Repeater>
        <XS:Repeater ID="rpBKZD" runat="server">
            <ItemTemplate>
                <div class="clearfix topWrap topicList">
                    <table width="98%">
                        <tr>
                            <td style="width: 70%">
                                <div>
                                    <span class="topicIcon flagTop"></span><span class="topic"><a class="" href='BBS.aspx?mpid=<%=pid%>&msid=<%=sid%>&t=14&id=<%# Eval("ID")%>'>
                                        <%# Eval("TopicTitle")%></a></span></div>
                            </td>
                            <td style="width: 13%">
                                <div class="user">
                                    <div>
                                        <%# Eval("UserName")%></div>
                                    <div class="time">
                                        <%# Eval("CreatedTime")%></div>
                                </div>
                            </td>
                            <td style="width: 12%;">
                                <div>
                                    <%# Eval("ReplyCount")%>/<%# Eval("ViewCount")%>
                                </div>
                            </td>
                            <td align="center">
                                <div class="reply">
                                    <div>
                                        <%# Eval("LatestReplyUserName")%>
                                    </div>
                                    <div class="time">
                                        <%# Eval("LatestRepliedTime","{0:yyyy-MM-dd}")%>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </XS:Repeater>
        <div class="caption commonTopic">
            <div class="captionBd clearfix" style="height: 25px">
                <table width="100%">
                    <colgroup>
                        <col width="20" />
                        <col />
                        <col width="120" />
                        <col width="95" />
                        <col width="100" />
                    </colgroup>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            帖子标题
                        </td>
                        <td>
                            作者
                        </td>
                        <td>
                            回复/查看
                        </td>
                        <td>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 最后更新
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <XS:Repeater ID="rpList" runat="server">
            <ItemTemplate>
                <div class="clearfix topWrap topicList">
                    <table width="98%">
                        <tr>
                            <td style="width: 70%">
                                <div>
                                    <span class='<%# GetBs(Eval("ID").ToString())%>'></span><span class="topic"><a style="cursor: pointer;"
                                        href='BBS.aspx?muid=<%=pid%>&mid=<%=sid%>&t=14&id=<%# Eval("ID")%>'>
                                        <asp:Label ID="lbTitle" runat="server" Text='<%# TitleCss(Eval("ID").ToString())%>'></asp:Label></a></span></div>
                            </td>
                            <td style="width: 13%">
                                <div class="user">
                                    <div>
                                        <%# Eval("UserName")%></div>
                                    <div class="time">
                                        <%# Eval("CreatedTime")%></div>
                                </div>
                            </td>
                            <td style="width: 10%;">
                                <div>
                                    <%# Eval("ReplyCount")%>/<%# Eval("ViewCount")%></div>
                            </td>
                            <td align="center">
                                <div class="reply">
                                    <div>
                                        <%# Eval("LatestReplyUserName")%>
                                    </div>
                                    <div class="time">
                                        <%# Eval("LatestRepliedTime","{0:yyyy-MM-dd}")%>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </XS:Repeater>
    </div>
    <div id="PagesMain">
        <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            Visible="false">
        </XS:GridView>
        <XS:PagesContrl ID="pcPage" runat="server" />
    </div>
</div>
