<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.EvaluatePg.widget" %>
<%@ Register TagPrefix="XS" Namespace="EbSite.Control" %>
<link type="text/css" href="/themes/<%=SiteName %>/pj/css.css" rel="stylesheet" />
<script type="text/javascript" src="/themes/<%=SiteName %>/pj/js.js"></script>

<div class="pingpun">
    <div id="tagsask" class="ttl queType pinlun_title " style="background: #FFFFFF; height: 28px;">
        <%-- <div id="tagsask" class="pinlun_title">--%>
        <div name="tg0" u="?" class="haoping" style="cursor: pointer;">
            全部评价（<%=AllPJ %>）
        </div>
        <div name="tg1" u="?t=1" class="haoping2" style="cursor: pointer;">
            好评（<%=GooDPJ %>）
        </div>
        <div name="tg2" u="?t=2" class="haoping2" style="cursor: pointer;">
            中评（<%=MidPJ%>）
        </div>
        <div name="tg3" u="?t=3" class="haoping2" style="cursor: pointer;">
            差评（<%=BadPJ%>）
        </div>
    </div>
    <div class="pinglun_main" style="height: 120%">
        <div class="pinglun_1">
            <div id="Div1">
                <%=GetSocre()%>
                <div class="btns">
                    
                   
                    <div>
                        <a href="/" target="_blank">查看全部评价</a></div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div style="height: auto; overflow: hidden;">
            <asp:Repeater ID="rpComment" runat="server">
                <ItemTemplate>
                    <div class="pinglun_2" style="width: 99%; margin-top: 0px; height: 100%;" id="comment-0"
                        data-widget="tab-content">
                        <div class="item">
                            <div class="user">
                                <div class="u-icon">
                                    <div style="text-align: center">
                                        <img id="AvatarBig" src='<%#UserInfos(Eval("username").ToString()).AvatarMid%>' width="60" />
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
                                <div class="u-address">
                                   地区
                                </div>
                                <div class="date-buy">
                                  购买日期  </div>
                            </div>
                            <div class="i-item">
                                <div class="o-topic">
                                 
                                    <%#GetScoreStyle(Eval("EvaluationScore").ToString())%><span class="date-comment">
                                        <%#Eval("DateAndTime")%></span>
                                </div>
                                <div class="comment-content">
                                 
                                    <dl>
                                        <dt>使用心得：</dt>
                                        <dd>
                                            <%# Eval("quote").ToString() %></dd></dl>
                                </div>
                                <div class="btns">
                                    <div id="b2edfbb1-1711-428e-9b8a-43cf02a59946" class="useful">
                                        <span style="margin-top: 4px; margin-right: 8px;">此评价对我</span> <a class="btn-agree"
                                            title="<%#Eval("Support")%>" href="#none" onclick="btnagree(<%#Eval("id")%>)"
                                            name="agree">
                                            <div id="support-k" style=" margin-top:4px;">
                                                有用(<%#Eval("Support")%>)</div>
                                        </a><a class="btn-oppose" title="<%#Eval("Discourage")%>" href="#none" name="oppose"
                                            onclick="btnoppose(<%#Eval("id")%>)">
                                            <div id="oppose-k" style=" margin-top:4px;">
                                                没用(<%#Eval("Discourage")%>)</div>
                                        </a>
                                    </div>
                                    
                                </div>
                                <br />
                                <%#GetChindRep(int.Parse(Eval("id").ToString())) %>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
      <a href="/" target="_blank">  <div class="moreque all2picX">
        </div></a>
    </div>
</div>

