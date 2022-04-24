<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluatePg.aspx.cs" Inherits="EbSite.Web.Pages.EvaluatePg" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>评价系统</title>
   
</head>
<body onload="resizeFrame()" style="background: #fff;">
    <form id="form1" runat="server">
    <div style="width: 990px; margin: 5px;">
        <div style="display: block"  class="m m2">
            <div class="mt">
                <h3>
                    商品评价</h3>
            </div>
            <div class="mc loaded">
                <div id="i-comment">
                  <%=GetSocre()%>
                    <div class="btns">
                        <div>
                            我购买过此商品</div>
                        <a class="btn-comment" href="#pj">我要评价</a>
                        <div>
                            <a href="#" target="_blank">查看全部评价</a></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="ev_sd">
            <div class="zhuyi">
                <div id="tagsask" class="ttl queType" style="background: #fff7e3; height: 31px;">
                    <div name="tg0" u="?" class="focus" style=" cursor:pointer;">
                        全部评价（<%=AllPJ %>）
                    </div>
                    <div name="tg1" u="?t=1" style=" cursor:pointer;">
                        好评（<%=GooDPJ %>）
                    </div>
                    <div name="tg2" u="?t=2" style=" cursor:pointer;">
                        中评（<%=MidPJ%>）
                    </div>
                    <div name="tg3" u="?t=3" style=" cursor:pointer;">
                        差评（<%=BadPJ%>）
                    </div>
                </div>
                <div style="height: auto; overflow: hidden;">
                    <asp:Repeater ID="rpComment" runat="server">
                        <ItemTemplate>
                            <div class="mc" id="comment-0" data-widget="tab-content">
                                <div class="item">
                                    <div class="user">
                                        <div class="u-icon">
                                            <div style="text-align: center">
                                               <img id="AvatarBig" src='<%#base.HostApi.AvatarBig(Convert.ToInt32(Eval("userid"))) %>' width="80"   />    
                                         </div>
                                        </div>
                                        <div class="u-name">
                                          <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("username").ToString())%>" target="_blank">
                                             <%#Eval("username") %>
                                           </a>
                                          </div>
                                        <span class="u-level"><span style="color: #088000">
                                        <%# EbSite.BLL.UserLevel.Instance.GetUserLevelForScore(UserInfos(Eval("username").ToString()).Credits).LevelName%>
                                         </span></span>
                                        <div class="u-address">
                                            (北京)
                                        </div>
                                        <div class="date-buy">
                                            购买日期<br />
                                            2012-08-21</div>
                                    </div>
                                    <div class="i-item">
                                        <div class="o-topic">
                                            <strong class="topic"><a href="#"target="_blank"><%#Eval("body") %></a></strong> <%#GetScoreStyle(Eval("EvaluationScore").ToString())%><span class="date-comment">
                                                   <%#Eval("DateAndTime")%></span>
                                        </div>
                                        <div class="comment-content">
                                            <dl>
                                                
                                                <dd><%#Eval("quote").ToString() %></dd></dl>
                                           
                                        </div>
                                        <div class="btns">
                                            <div id="b2edfbb1-1711-428e-9b8a-43cf02a59946" class="useful">
                                                <span style="  margin-top:4px; margin-right:8px;">此评价对我</span>
                                                 <a class="btn-agree" title="<%#Eval("Support")%>" href="#none" onclick="btnagree(<%#Eval("id")%>)" name="agree" ><div id="support-k">有用(<%#Eval("Support")%>)</div> </a> 
                                                 <a class="btn-oppose" title="<%#Eval("Discourage")%>" href="#none" name="oppose" onclick="btnoppose(<%#Eval("id")%>)"><div id="oppose-k"> 没用(<%#Eval("Discourage")%>)</div></a>
                                            </div>
                                            <a class="btn-reply" onclick="rply(<%#Eval("id")%>)" >回复</a>
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



    </div>
    <div style=" clear:both;"></div>
   <div id="pj" class="pingpun">
        <div class="pinglun_main" style="height: 100%">
        <div>发表评论</div>
            <table >
              
                <tr>
                    <td align="right">
                        评分：
                    </td>
                    <td >
                        <div class="starSt">
                            <input id="RdScore_0" type="radio" name="RdScore" value="5" /><label for="RdScore_0"><span
                                class="star sa5"></span>(5分)</label>
                        </div>
                        <div class="starSt">
                            <input id="RdScore_1" type="radio" name="RdScore" value="4" /><label for="RdScore_1"><span
                                class="star sa4"></span> (4分)</label>
                        </div>
                        <div class="starSt2">
                            <input id="RdScore_2" type="radio" name="RdScore" value="3" /><label for="RdScore_2"><span
                                class="star sa3"></span> (3分)</label>
                        </div>
                        <div class="starSt">
                            <input id="RdScore_3" type="radio" name="RdScore" value="2" /><label for="RdScore_3"><span
                                class="star sa2"></span> (2分)</label>
                        </div>
                        <div class="starSt2">
                            <input id="RdScore_4" type="radio" name="RdScore" value="1" /><label for="RdScore_4"><span
                                class="star sa1"></span> (1分)</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        使用心得：
                    </td>
                    <td>
                        <textarea name="txtExperience" rows="2" cols="20" id="txtExperience" style="height: 50px;
                            width: 300px;"></textarea>
                    </td>
                </tr>
               
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <input type="button" value=" 提 交 " onclick="toAddEvaluate()" />
                    </td>
                </tr>
            </table>
        </div>
    </div>



   </form>

   <script>
    var  PjConfigs = { cid: <%=cid  %>, classid:  <%=ClassID %>, contentid:  <%=ContentID %> };
    </script>
</body>
</html>
