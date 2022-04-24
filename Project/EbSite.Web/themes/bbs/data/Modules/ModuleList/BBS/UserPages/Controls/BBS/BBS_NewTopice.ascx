<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BBS_NewTopice.ascx.cs" Inherits="EbSite.Modules.BBS.UserPages.Controls.BBS.BBS_NewTopice" %>
<%@ Import Namespace="EbSite.Modules.BBS.UserPages.Controls.BBS" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<link type="text/css" href="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/CssBbs.css" rel="stylesheet" />
<div id="mainX">
    
    
    <div id="mainby">
        <div id="main-middle">
            <div class="main-s-top">
            </div>
            <div class="main-s">
                <div class="main-gg">
                   
                </div>
                <div class="gg-r">
                   </div>
            </div>
            <div class="main-s-down">
            </div>
        
            <div class="middle-div" style="margin-top:0px;">
               
                <%--内容区已 --%>
                <div class="ctent">
                    <div class="ctent-top">
                        <span class="ctent-title">
                          最新主题
                        </span>
                    </div>
                    <div class="topice-title">
                        <div class="topice-title-time">
                            作者</div>
                        <div class="topice-title-type">
                            主题
                        </div>
                         <div style="float:left;width:10%;margin-top:5px;">
                            版块
                        </div>
                        <div class="topice-title-lasttime">
                            最后回复</div>
                        <div class="topice-title-hf">
                            回复/查看</div>
                    </div>
                 
                    <%--开始本版块的帖子循环--%>
                    <XS:Repeater runat="server" ID="repNewRopice">
                        <ItemTemplate>
                            <div class="topice-list-title">
                                <div class="topice-list-pic">
                                      <a href="?t=3&id=<%#Eval("id") %>">
                                      <%#BBS_TopicsList.PicInfo(int.Parse(Eval("ViewCount").ToString()))%>
                                       </a>
                                </div>
                               <div class="topice-list-add">
                                    <div class="topice-list-add- topice-list-font">
                                        <%#Eval("UserName")%></div>
                                    <div class="">
                                       <%#EbSite.Core.Strings.cConvert.WriteDate(Eval("CreatedTime").ToString(),2)%></div>
                                </div>
                                <div class="topice-titlestyle">
                                     <a href="?t=3&id=<%#Eval("id") %>"> <%#Eval("TopicTitle")%></a></div>

                                      <div style="float:left;">
                                      <%#bbslist.GetChannelUrl(int.Parse(Eval("ChannelID").ToString()), Eval("ChannelName").ToString())%>
                                  </div>

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
                                        / <%#Eval("ViewCount")%></div>
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
