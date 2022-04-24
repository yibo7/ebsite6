<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Wenda.ModuleCore.Pages.mjieda" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title></title>
</head>
<body>
    <!--#include file="header.inc"-->
    <!--topend--->
    <div class="content" style="width: 990px; margin: 0 auto">
        <!---中间开始--->
        <!--中间第一部分-->
        <div class="soletcen" style="margin-top: 10px;">
            <!---内容左侧--->
            <div class="soletr" style="width: 694px;">
                <div class="drtop">
                    <!---左侧--->
                    <div class="drtopl">
                        <div class="drinfo" style="margin-bottom: 5px;">
                            <div class="kfleft">
                                <img src="<%=EbSite.Base.Host.Instance.AvatarBig(mdUser.id)%>" class="wdtab2" />
								 <div class="jdxttw" id="t_tw">
                                            <a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.AskPost(GetSiteID) %>?u=<%=mdUser.id %>">向TA提问</a>
                                        </div>
                            </div>
                            <div class="kfright wdtab3">
                                <div class="niname">
                                    昵称：<%=mdUser.NiName%>
                                    <div id="sid" style="display: none;">
                                        <%=mdUser.id%>
                                    </div>
                                </div>
                                <div>
                                    积分：<span><%=mdUser.Credits%></span></div>
                                <div>
                                    回答：<span><%=mdTotal.ACount%></span></div>
                                <div>帮助人数：<span><%=mdTotal.HelpUserCount%></span></div>
                                <div>
                                    采纳：<span><%=mdTotal.AdoptionCount%></span>&nbsp;采纳率：<span><%=mdTotal.Accept%>%</span></div>
                            </div>
                        </div>
                    </div>
                    <!---左侧--->
                    <div class="drtopr">
                        <li><span>签名：</span></li>
                        <li>
                            <%=string.IsNullOrEmpty(mdUser.Sign) ? "<font color='#C4BEBB'>作者很忙，暂时没时间更新签名</font>" : mdUser.Sign%></li>
                    </div>
                </div>
                <!---内容中间循环调用数据--->
                <div class="drlist">
                    <div class="drtab1">
                        
                        <li id="menutiwen" class="cur1"><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.TiWen(GetSiteID,mdUser.id) %>">
                            TA的提问</a></li>
                        <li class="cur1" id="menutongwen"><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.TongWen(GetSiteID,mdUser.id) %>">
                            TA的同问</a></li>
                        <li class="cur2" id="menujieda"><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,mdUser.id) %>">
                            TA的解答</a></li>
                        <li class="cur1" id="menucheck" style="display: none;"><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.TiWenCheck(GetSiteID,mdUser.id) %>">
                            提问审核中</a></li>
                             <li class="cur1" id="menumyask"style="display: none;"><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.MyAsked(GetSiteID,mdUser.id) %>">向我的提问</a></li>
                    </div>
                    <div class="drquelst">
                        <table style="width: 100%;">
                            <XS:Repeater ID="rpList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div>
                                                <span style="padding-left: 15px;" class="fLeft">问: <a target="_blank" href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("QID"),GetSiteID) %>">
                                                   <%#Eval("NewsTitle")%></a>
                                                </span><span style="padding-right: 20px;" class="fRight">采纳:<%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetBoolText(bool.Parse(Eval("IsAdoption").ToString()))%>&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <%#string.Format("{0:g}", Eval("AnswerTime"))%>
                                                </span>
                                            </div>
                                           
                                            <div class="normal" style=" width: 685px; margin-left: 0px; margin-top:25px;">
                                                <div class="normalarrow">
                                                </div>
                                                答:
                                                <%#EbSite.Core.UBB.Ubb2Html(Eval("AnswerContent").ToString())%>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbEmpty" Text="TA还没有回复过任何问题！" Style="padding-left: 30px; color: #ccc;"
                                                runat="server" Visible='<%#bool.Parse((rpList.Items.Count==0).ToString())%>'></asp:Label>
                                        </td>
                                    </tr>
                                </FooterTemplate>
                            </XS:Repeater>
                        </table>
                    </div>
                </div>
                <!---内容中间循环调用数据--->
                <div class="iffanye dr_page">
                    <XS:PagesContrl ID="pgCtr" PageSize="15" runat="server" />
                </div>
            </div>
            <!---内容左侧--->
            <!---内容右侧--->
            <div class="soletl drl">
                <div class="leflst" style="height: 800px;">
                    <div class="sqzj">
                        <div id="requestexpert" class="zjbtn all2pic">
                        </div>
                        <li>申请专家立刻<font color="#AD3202">提高身价</font>，直接追加<font color="#34B706">1000</font>积分</li>
                    </div>
                    <div class="Expertsonline">
                        <div class="zjzx">
                            专家在线</div>
                        <XS:Widget ID="Widget3" WidgetName="问答首页专家" WidgetID="c3caec92-9bcd-4a05-b804-1dc915cc65dd"
                            runat="server" />
                    </div>
                </div>
            </div>
            <!---内容右侧--->
        </div>
        <!---中间end--->
    </div>
    <!--#include file="footer.inc" -->
       <script type="text/javascript" src="<%= base.ThemePage%>muser.js"></script>
   <span runat="server" id="datacount"></span>
</body>
</html>
