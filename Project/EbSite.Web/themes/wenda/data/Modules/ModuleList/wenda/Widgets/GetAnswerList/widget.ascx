<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.BmAsk.Widgets.GetAnswerList.widget" %>
<%@ Import Namespace="EbSite.BLL.User" %>
<%@ Import Namespace="EbSite.Modules.BmAsk.ModuleCore" %>
<asp:Repeater ID="AnswerList" runat="server" OnItemDataBound="AnswerList_ItemBound"
    EnableViewState="False">
    <HeaderTemplate>
     
        <div class="lb_top3">
            <li class="cur" style="width: 100px;"><a href="#">回 答（<font color="#FF0000">共<%=count%>条</font>）</a></li>
        </div>
        <div class='ans_listx'>
       
    </HeaderTemplate>
    <ItemTemplate>
        <div style="width: 753px;">
            <div class="tab2_onecur">
                <div class="tab2_photo">
                    <li>
                        <%#UserInfo(bool.Parse(Eval("IsAnonymity").ToString()),Eval("AnswerUserID").ToString())%></li>
                </div>
                <div class="tab2_name" style="width: 640px;">
                    <div class="tab2_que">
                        <li id="xHf<%#Eval("AnswerUserID") %>"><%#SetContent(Eval("AnswerContent").ToString(),int.Parse(Eval("IsApproved").ToString()))%></li></div>
                    <div class="tab2_min">
                        <li>回答：</li><li>
                            <%#AskCommon.GetUserName(Eval("AnswerUserID").ToString()) %></li><li style="width: 20px;">
                            </li>
                        <li>回答时间：</li><li>
                            <%#Eval("AnswerTime")%></li>
                    </div>
                    <%#UpdateAnswer(int.Parse(Eval("QID").ToString()), int.Parse(Eval("AnswerUserID").ToString()), int.Parse(Eval("IsApproved").ToString()), Eval("AnswerContent").ToString())%>
                </div>
                <asp:Repeater ID="rpSubList" runat="server">
                    <HeaderTemplate>
                        <div class="tab2_ques" style="margin-left:87px;">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>[<font color="#FF0000"> <% =UsNiName%></font>]追问：<%#Eval("ctent") %>?</li>
                       
                        <%#GetZhiWenAnswer(Convert.ToInt32(Eval("id")),Convert.ToInt32(Eval("answerid"))) %>
                       
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="tab2_ques" style="margin-left:87px; "  d="<%=UsNiName%>" id="xResult<%#Eval("AnswerUserID") %>"></div>
                <%# SetBestAnswer(int.Parse(Eval("QUserID").ToString()), Eval("AnswerUserID").ToString(), int.Parse(Eval("id").ToString()),int.Parse(Eval("isapproved").ToString()))%>   
                <div class="clear">
                </div>
                <div class="tab2_time">
                   </div>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
     
        </div>
       
    </FooterTemplate>
</asp:Repeater>
