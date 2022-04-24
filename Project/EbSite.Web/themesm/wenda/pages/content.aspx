<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.content" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!doctype html>
<html>
<head runat="server">
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidtmpaid" value="0" />
    <div id="panelbar1">
        <!--#include file="header.inc" -->
        <div class="askctent">
            <span class="ask-title">
                <%=Model.NewsTitle %>？</span>
            <div class="askctent_dt">
                <%=Model.UserNiName %>&nbsp;|&nbsp;浏览<%=Model.hits %>次 <span  style="float: right; margin-right: 3px;"><%=Model.AddTime %></span></div>
            <div class="askctent_ct">
                <%=Model.ContentInfo %></div>
        </div>
         <% if (Model.Annex21 == 1)
                   {%>
                <%if ((EbSite.Base.Host.Instance.UserID != Model.UserID))
                    {%>
        <div style="height: 110px; margin: 5px; ">
            <textarea id="txCtent" class="bor w2" style="height: 65px;" placeholder="请输入您的回答..."></textarea>
            <div style="text-align: center; margin-top: 10px;">
                <div style="width: 100%; cursor: pointer;" class="button btngreen2 btnmiddle" onclick="SubmitAnswer(<%=Model.ID %>,<%=Model.UserID %>,<%=base.UserID %>)">
                    提 交
                </div>
            </div>
        </div><%
                    }
                   }%>
        <div class="ask_floor2">
        <% if (Model.Annex11 >0)
           { %>
            <div class="ask_hd">回答</div>
            <% } %>
            <XS:Repeater ID="rptRefList" runat="server">
                <ItemTemplate>
                    <div style="background-color: #F7FCF6; margin: 10px;">
                        <div style="margin-bottom: 5px;">
                            <%# Eval("answercontent") %></div>
                        <div class="ask_hd_dt">
                            <%# EbSite.Base.Host.Instance.GetUserNiName(EbSite.Core.Utils.ObjectToInt(Eval("answeruserid"),0)) %>&nbsp;|&nbsp;<%#DateTime.Parse( Eval("answertime").ToString()).ToShortDateString() %></div>
                        <XS:Repeater ID="rptGoOnList" runat="server">
                            <ItemTemplate>
                                <div style="font-size: 14px; margin: 15px auto 5px auto;">
                                    <span style="color: #5EBB0B;">追问</span>：<%# Eval("ctent") %></div>
                                <%-- <div style="text-align:right;margin-bottom:10px;"><span style="margin-right:3px; font-size:12px;color:gray;"><%# Eval("tdate") %></span></div>--%>
                                <XS:Repeater ID="rptAnswerList" runat="server">
                                    <ItemTemplate>
                                        <div style="font-size: 14px;">
                                            <span style="color: #4190E3;">回答</span>：<%# Eval("ctent") %></div>
                                        <%-- <div style="text-align:right;margin-bottom:10px;"><span style="margin-right:3px; font-size:12px;color:gray;"><%# Eval("tdate") %></span></div>--%>
                                    </ItemTemplate>
                                </XS:Repeater>
                                <asp:Panel ID="panelanswer" runat="server" Visible="false">
                                    <div style="margin-bottom: 15px;">
                                        <div>
                                            继续回答：</div>
                                        <textarea id="txtGoOnRef_<%# Container.ItemIndex %>" class="bor w2" style="height: 75px;
                                            width: 252px;" placeholder="继续回答提问者的追问"></textarea>
                                        <div style="text-align: right; margin-right: 5px; margin-top: 15px;">
                                            <span class="mlink" onclick="CancelAnswer(this)">取消回答</span> &nbsp;&nbsp;&nbsp;&nbsp;
                                            <span class="mlink" onclick="GoOnAnswerEx(<%# Container.ItemIndex %>,<%# Eval("id") %>,<%# Eval("answerid") %>)">
                                                提交回答</span></div>
                                    </div>
                                </asp:Panel>
                            </ItemTemplate>
                        </XS:Repeater>
                        <div style="margin-top: 10px; margin-bottom: 15px; display: <%=(Model.Annex21==2?"none":(Model.UserID==base.UserID?"block":"none")) %>;"
                            id="btnPanel">
                            <span class="mlink" onclick='SetBestAnswer(<%# Eval("id") %>)'>选为满意答案</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <span class="mlink" onclick="GoOnAnswer(<%# Eval("id") %>)">继续追问</span></div>
                    </div>
                    <hr />
                </ItemTemplate>
            </XS:Repeater>
            <XS:Repeater ID="rptBestAnswer" runat="server">
                <HeaderTemplate>
                    <div class="ask_best" >
                        <div class="ask_best_title">提问者采纳答案</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div>
                        <div>
                            <%# Eval("answercontent") %></div>
                        <div class="ask_best_dt">
                            <%# EbSite.Base.Host.Instance.GetUserNiName(EbSite.Core.Utils.ObjectToInt(Eval("answeruserid"),0)) %>&nbsp;|&nbsp;<%# DateTime.Parse( Eval("answertime").ToString()).ToShortDateString() %></div>
                    </div>
                    <XS:Repeater ID="rptGoOnList" runat="server">
                            <ItemTemplate>
                                <div style="font-size: 14px; margin: 15px auto 5px auto;">
                                    <span style="color: #5EBB0B;">追问</span>：<%# Eval("ctent") %></div>
                                <XS:Repeater ID="rptAnswerList" runat="server">
                                    <ItemTemplate>
                                        <div style="font-size: 14px;">
                                            <span style="color: #4190E3;">回答</span>：<%# Eval("ctent") %></div>
                                    </ItemTemplate>
                                </XS:Repeater> 
                            </ItemTemplate>
                        </XS:Repeater>
                    <div class="ganyan">  提问者 <%=Model.UserNiName %>的感言:<%#Eval("ThanksInfo")%></div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </XS:Repeater>
            <XS:Repeater ID="rptOtherAnswer" runat="server">
                <HeaderTemplate>
                    <div class="askother">
                        其他回答者答案</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div style="background-color: #F7FCF6; margin: 10px;">
                        <div>
                            <%# Eval("answercontent") %></div>
                        <div class="ask_best_dt">
                            <%# EbSite.Base.Host.Instance.GetUserNiName(EbSite.Core.Utils.ObjectToInt(Eval("answeruserid"),0)) %>&nbsp;|&nbsp;<%#DateTime.Parse( Eval("answertime").ToString()).ToShortDateString() %></div>
                    </div>
                </ItemTemplate>
            </XS:Repeater>
        </div>
    </div>
    <div id="panelbar2" style="display: none;">
        <div class="toolbar " id="toolbar">
            <span class="button fl" onclick="togglePanel2()">返回</span><h2 style="text-align: center;
                color: #fff; padding: 8px;">
                填写满意感言</h2>
        </div>
        <div class="bt2 bg1 slist" style="padding: 10px;">
            <div class="radiusbox">
                <div class="ebinput">
                    <input type="text" id="txtThankWord" name="txtThankWord" autocomplete="off" autocorrect="off"
                        maxlength="100" placeholder="请输入您的感谢…" class="bor w2" />
                </div>
            </div>
        </div>
        <div style="width: 100%; text-align: center; cursor: pointer;" class="button btngreen2 btnmiddle"
            onclick="SetThankWord()">
            确 定
        </div>
        <input type="hidden" id="tmpAnswerID" />
    </div>
    <div id="dialogAnswer" class="vote-dialog">
        <div>
            <textarea id="txtGoOn" class="bor w2" style="height: 75px; margin-bottom: 1px;" placeholder="请输入您的追问内容..."></textarea></div>
    </div>
    <div id="panelMsg" class="vote-dialog">
    </div>
    <hr />
    <!--#include file="foot.inc" -->
    <span runat="server" id="datacount"></span>
    </form>
    <script type="text/javascript" src="<%= base.MThemePage%>content.js"></script>
</body>
</html>
