<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.BmAsk.Widgets.GetBestAnswer.widget" %>
<%@ Import Namespace="EbSite.Modules.BmAsk.ModuleCore" %>
<div class="jgzjda">
    <div class="zjdal">
        最佳答案</div>
    <div title="回答很有帮助，谢谢!" class="zjdar jgall">
        <a href="javascript:vote(<%=info.AnswerID %>);"><span style="display: block; padding-top: 0px;
            padding-left: 90px; font-size: 17px; color: #2AA8E3;"><b id="goodcount">
                <%=info.GoodSum %></b></span> </a>
    </div>
</div>
<!-- 最佳问题内容--->
<div id="con1" style="width: 753px;">
    <div class="tab2_onecur" style="border-bottom: none;">
        <div class="tab2_photo" style="float: left;">
            <li><a target="_blank" href="<%=info.SpacePath %>">
              <div class="jguserphotoauto"> <img src="<%=info.AvatarBig %>" width="63" /></div> </a></li>
        </div>
        <div class="tab2_name" style="width: 640px;">
            <div class="tab2_que">
                <li>
                    <%=info.AContent%></li></div>
            <div class="tab2_min">
                <li>回答：</li><li>
                    <%=info.AName%>
                </li>
                <li style="width: 20px;"></li>
                <li>时间：</li><li>
                    <%=info.AnswerDT%></li>
            </div>
        </div>
        <asp:Repeater ID="rpSubList" runat="server">
            <HeaderTemplate>
                <div class="tab2_ques" style="margin-left: 87px;">
            </HeaderTemplate>
            <ItemTemplate>
                <li>[<font color="#FF0000">
                    <% =UsNiName%></font>]追问：<%#Eval("ctent") %>?</li>  
                <%#GetZhiWenAnswer(Convert.ToInt32(Eval("id")),Convert.ToInt32(Eval("answerid"))) %>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <div class="clear">
        </div>
       <%-- <div class="tab2_time">
            <li><a href="#" onclick="JuBaoAdd(<%=info.AnswerID %>,1)"><span class="fds">举报 </span>
            </a></li>
        </div>--%>
    </div>
    <div style="clear: both; margin-top: 15px; margin-left: 88px; margin-bottom: 10px;">
        <br />
        <%--感言显示--%>
        <div id="showthankinfo">
            <div>
                提问者
                <%=info.AskUserInfo%>的感言:
                <%=info.ThankInfo%></div>
        </div>
    </div>
</div>

<script>
    //调出 好评数
    var pram = { "id": "<%=info.AnswerID %>" };
    runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GoodCount", pram, function (result) {
        $("#goodcount").text(result.d);
    });
</script>