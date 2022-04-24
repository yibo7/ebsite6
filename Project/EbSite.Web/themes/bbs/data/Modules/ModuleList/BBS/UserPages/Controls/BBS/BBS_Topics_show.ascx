<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BBS_Topics_show.ascx.cs"
    Inherits="EbSite.Modules.BBS.UserPages.Controls.BBS.BBS_Topics_show" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/CssBbs.css" rel="stylesheet" />
<div id="mainX">
 
    <div id="mainby">
        <div id="main-middle">
            <div class="main-s-top">
            </div>
            <div class="main-s">
                <div style="float: left; width: 160px; padding-top: 10px;">
                    <div style="float: left; width: 90px;">
                        <div class="topic-ct-top">
                            <%=Model.ViewCount%>
                            <span class="topic-small">阅读</span></div>
                    </div>
                    <div style="float: left; margin-left: 5px; border-left: 1px solid #F4E5C4; height: 50px;
                        width: 5px;">
                    </div>
                    <div style="float: left;">
                        <div class="topic-ct-top">
                            <%=Model.ReplyCount%>
                            <span class="topic-small">回复</span>
                        </div>
                    </div>
                    <div style="float: right; margin-left: 5px; border-left: 1px solid #F4E5C4; height: 50px;
                        width: 5px;">
                    </div>
                </div>
                <div style="margin-top: 2px;">
                    <div class="topiceTop">
                    </div>
                    <a href="<%=UrlAddTopice() %>" target="_blank" style="cursor:pointer;" >
                    <div class="topiceTop2">
                    </div></a>
                    <div style="float: right; font-size: 14px; margin-top: 10px;">
                        返回列表 分页</div>
                </div>
            </div>
            <div class="main-s-down">
            </div>
            <div class="middle-div">
                <%--内容区--%>
                <div class="topic-ct-l">
                    <div class="topic-ct-l-top">
                    </div>
                    <div class="topic-ct-l-pic">
                        <div class="topic-user">
                            <%=Model.UserName%></div>
                        <div class="topic-user-pic">
                            <img src="/Modules/BBS/DataStore/Attachments/img/1.png" /></div>
                       
                            <div style="margin-left:15px;">
                            注册时间 :2011-11-03 <br />
                            帖子:100  <br />
                            精华帖:10<br />

                            </div>
                    </div>
                </div>
                <div class="topic-ct-r">
                    <div class="topic-ct-r-top">
                    </div>
                    <div class="topic-ct-r-ct">
                        <div class="topic-ct-r-title">
                            <%=Model.TopicTitle%>
                            <span class="topic-small"></span></div>
                        <div class="topic-small" style="margin-top: 5px; float: left;">
                            发表于
                            <%=Model.CreatedTime%></div>
                        <div style="float: right;">
                            <p class="post-number">
                                楼主</p>
                            <p class="textresize" onmouseover="this.className+=' textresize-expand';" onmouseout="this.className=this.className.replace('textresize-expand','');">
                                <a class="label" href="javascript:void(0);"><span><em>.</em>字号</span></a> <span class="textresize-list">
                                    <a href="javascript:void(0);" class="small" onclick="PostViewStyle(this, 'fontsize-small');return false;">
                                        较小字号</a> <a href="javascript:void(0);" class="medium" onclick="PostViewStyle(this, 'fontsize-medium');return false;">
                                            正常字号</a> <a href="javascript:void(0);" class="large" onclick="PostViewStyle(this, 'fontsize-large');return false;">
                                                较大字号</a> </span>
                            </p>
                            <p class="post-authorip">
                                <a href="javascript:void(0);"><span><em>.</em>IP <code>218.26.*.*</code></span></a>
                            </p>
                        </div>
                        <div class="bbs-line">
                        </div>
                        <%=TopiceSiteOrder() %>
                        <div style="min-height: 100px;">
                            <%=Model.TopicContent %>
                        </div>
                        <div class="topic-small" style=" float:left;">
                            本帖最后于
                            <%=Model.UpdatedTime%>
                            编辑</div>
                            <div style="float:right">
                             <div class="topicFt">
                              <XS:EasyuiDialog ID="WinBoxHf" runat="server" Text="回复" Title="回复" IsColseReLoad="true" />
                              <XS:EasyuiDialog ID="WinBoxBj" runat="server" Text="编辑" Title="编辑" IsColseReLoad="true" />
                              <XS:LinkButton ID="lbSC" runat="server" Text="删除" confirm="true"  ></XS:LinkButton>
                            </div>
                            </div>
                        <div class="bbs-line">
                        </div>
                        <div>
                            <div style="float: left;">
                                <div class="topic-ct-copypic">
                                    <img src="/Modules/BBS/DataStore/Attachments/img/icons/posticon_reply.gif" />
                                </div>
                                <div style="margin-top: 3px; float: left; margin-right: 3px;">
                                    回复</div>
                                <div class="topic-ct-copypic">
                                    <img src="/Modules/BBS/DataStore/Attachments/img/icons/posticon_quote.gif" /></div>
                                <div style="margin-top: 3px; float: left; margin-right: 3px;">
                                    引用</div>
                               <%-- <div class="topic-ct-copypic">
                                    <img src="/Modules/BBS/DataStore/Attachments/img/icons/posticon_mark.gif" /></div>--%>
                               <%-- <div style="margin-top: 3px; float: left; margin-right: 3px;">
                                    评分</div>--%>
                                <div style="float: right;">
                                 <a id='<%# Eval("id")%>' href='javascript:void(0)' onclick='delete_Click(this)'>
                                <asp:Label ID="sc" runat="server" Text='<%# ifSc(Eval("TopicID").ToString())%>'></asp:Label></a>    支持 1反对 0 举报 TOP</div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both; margin-top: -10px;">
                    <XS:Repeater ID="repHf" runat="server">
                        <ItemTemplate>
                            <div class="topic-ct-l">
                                <div class="topic-ct-l-top">
                                </div>
                                <div class="topic-ct-l-pic">
                                    <div class="topic-user">
                                        <%#Eval("UserName")%></div>
                                    <div class="topic-user-pic">
                                        <img src="/Modules/BBS/DataStore/Attachments/img/1.png" /></div>
                                   <div style="margin-left:15px;">
                            注册时间 :2011-11-03 <br />
                            帖子:100  <br />
                            精华帖:10<br />

                            </div>
                                </div>
                            </div>
                            <div class="topic-ct-r">
                                <div class="topic-ct-r-top">
                                </div>
                                <div class="topic-ct-r-ct">
                                    <div>
                                        <div class="topic-small" style="margin-top: 5px; float: left;">
                                            发表于
                                            <%=Model.CreatedTime%></div>
                                        <div style="float: right; margin-right: 10px;">
                                            IP <%# Louc()%></strong>#</div>
                                    </div>
                                    <div class="bbs-line">
                                    </div>
                                    <div style="min-height: 180px; height: 100%;">
                                        <%#Eval("ReplyContent")%>
                                    </div>
                                    <div class="bbs-line">
                                    </div>
                                    <div>
                                        <div style="float: left;">
                                            <div class="topic-ct-copypic">
                                                <img src="/Modules/BBS/DataStore/Attachments/img/icons/posticon_reply.gif" />
                                            </div>
                                            <div style="margin-top: 3px; float: left; margin-right: 3px;">
                                                回复</div>
                                            <div class="topic-ct-copypic">
                                                <img src="/Modules/BBS/DataStore/Attachments/img/icons/posticon_quote.gif" /></div>
                                            <div style="margin-top: 3px; float: left; margin-right: 3px;">
                                                引用</div>
                                         <%--   <div class="topic-ct-copypic">
                                                <img src="/Modules/BBS/DataStore/Attachments/img/icons/posticon_mark.gif" /></div>--%>
                                         <%--   <div style="margin-top: 3px; float: left; margin-right: 3px;">
                                                评分</div>--%>
                                            <div style="float: right;">
                                                支持 1反对 0 举报 TOP</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </XS:Repeater>
                </div>
                <div id="nologin" runat="server">
                    <div class="topic-ct-l">
                        <div class="topic-ct-l-top">
                        </div>
                    </div>
                    <div class="topic-ct-r">
                        <div class="topic-ct-r-top">
                        </div>
                    </div>
                    <div style="clear: both; border: 1px solid #DFD0A3; height: 60px; width: 95%; margin-left: auto;
                        margin-right: auto; margin-top: 5px;">
                        请先登录或注册(小提示：如果登录成功后页面没有跳转，请按F5或刷新页面重试)
                    </div>
                </div>
                <div id="oklogin" runat="server">
                    <div class="topic-ct-l">
                        <div class="topic-ct-l-top">
                        </div>
                        <div style="background: #DFD5B7; height: 270px;">
                        </div>
                    </div>
                    <div class="topic-ct-r">
                        <div class="topic-ct-r-top">
                        </div>
                        <div class="topiceTop">
                        </div>
                        <div class="topiceTop2">
                        </div>
                        <div style="clear: both; margin-left: 4px;">
                            <XS:Editor ID="ebHT" runat="server" EditorTools="简单模式" ExtImg="jpg,JPG,png,PNG,gif,GIF"
                                Width="100%" Height="200px" />
                        </div>
                        <div style="margin-top: 4px; margin-left: 5px;">
                            <XS:Button ID="btnFT" runat="server" Width="80" Height="30" Text="发表回复" OnClick="btnFT_Click" />
                        </div>
                    </div>
                </div>
            </div>
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
