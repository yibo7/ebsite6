<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Wenda.ModuleCore.Pages.mcontent" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <!--#include file="header.inc"-->
    <div style="width: 990px; margin: 8px auto; font-size: 14px;">
       
        <%=GetNav("-", true)%>
    </div>
    <div class="content" style="width: 990px; margin: 8px auto;">
        <div class="c_left">
            <div class="l_top jg">
                <div class="jguser">
                    <div class="jguserphoto">
                        <img id="AvatarBig" src='<%=EbSite.Base.Host.Instance.AvatarBig(Convert.ToInt32(Model.UserID))%>'
                            width="115" />
                    </div>
                    <div class="jgusername">
                        <a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Model.UserID) %>">
                            <span style="color: #86CA13;">
                                <% =Model.UserNiName%></span></a></div>
                    <div class="rabstamp" style="margin-left: 10px;">
                        <li>
                            <img title="积分" src="<%=base.ThemeCss%>images/24.png" /></li><li style="width: 49px;">
                                <span id="scoref">0 </span></li>
                    </div>
                    <a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.AskPost(GetSiteID) %>?u=<%=Model.UserID %>">
                        <div class="twbtn jgall">
                        </div>
                    </a>
                </div>
                <div class="jgques">
                    <div class="jgquetit">
                        <b>TA问</b>：
                        <% =Model.NewsTitle %>?</div>
                    <% if (Model.Annex21 == 1 && Model.UserID == EbSite.Base.Host.Instance.UserID)
                       {%>
                    <div class="jgquebtn" id="stateNo" >
                        <li>
                            <div class="jgbtnbj jgall">
                                <a href="#" onclick="EditQuestion()"><span style="color: #BE2B24;">补充问题</span></a>
                            </div>
                        </li>
                        <li>
                            <div class="jgbtnbj jgall">
                                <a href="#" onclick="UpScore()"><span style="color: #BE2B24;">提高赏金</span></a></div>
                        </li>
                        <li>
                            <div class="jgbtnbj jgall">
                                <a href="#" onclick="NoBestAnswer()"><span style="color: #BE2B24;">无满意答案</span></a></div>
                        </li>
                    </div>
                    <div class="clear">
                    </div>
                    <div id="EditQuestionDiv" class="normal" style="display: none; width: 550px; margin-left: 0px; height: 50px;">
                        <div class="normalarrow">
                        </div>
                        <input type="question" id="EditEdAsk" class="answerques" style="width: 440px;" />
                        <a href="#" class="tab2save jgall" style="margin-right: 0px; float: right;" onclick="MdfAsk()">
                        </a>
                    </div>
                    <div id="UpScoreDiv" class="normal" style="display: none; width: 550px; margin-left: 0px; height: 60px;">
                        <div class="normalarrow2">
                        </div>
                        <div style="margin-top: 4px; color: Red; font-size: 13px; float: left; width: 98%;">
                            提问期内，追加悬赏一次，可延长问题的有效期<span id="dysa"></span>天。
                        </div>
                        <div style="margin-top: 4px; float: left;" id="ScoreDDList">
                            追加悬赏分<select>
                                <option>5</option>
                                <option>10</option>
                                <option>15</option>
                                <option>20</option>
                                <option>30</option>
                                <option>50</option>
                            </select>
                        </div>
                        <div>
                            <a href="#" class="tab2save jgall" style="margin-top: -10px; float: right;" onclick="OkUpScore()">
                            </a>
                        </div>
                    </div>
                    <%  }%>
                    <%=sInfo%>
                    <div id="newcontentinfo">
                    </div>
                    <div class="jgquexf">
                        <div class="xfleft">
                            <img src="<%=base.ThemeCss%>images/24.png" />
                                <span>
                                    <%=Model.Annex1 %>分 发表 <%=Model.AddTime.ToShortDateString() %></span>
                                <% if (Model.Annex21 == 1)
                                   {%>
                                离问题结束还有： <span>
                                    <%=
                                               EbSite.Core.Strings.cConvert.DateDiff(
                                                   Convert.ToDateTime(Model.Annex9.ToString()), DateTime.Now, 2)%></span>
                                <%
                                    }%>
                                <% if (Model.Annex21 == 2)
                                   {%>
                                解决时间： <span>
                                    <%=Model.Annex10%></span>
                                <%
                                    }%>
                                <% if (Model.Annex21 == 3)
                                   {%>
                                关闭时间： <span>
                                    <%=Model.Annex10%></span>
                                <%
                                    }%>
                                <%--FavAdd()--%>
                                回答数：<span><%=allcount %></span> <a href="#" onclick="FavContent(<%=Model.ID%>)">
                                    收藏</a> 
                        </div>
                        <div class="xfright">
                            <span id="div_sq" class="xfright2 jgall"><a title="同问后有新回答将会通知到您" id="follow-btn"
                                href="#" onclick="sameOp()" style="padding-left: 9px; color: #fff;" onmouseout="cksamefunout()"
                                onmouseover="cksamefun()"></a></span>
                            <div id="testddd" style="cursor: pointer; float: right;" class="xfright1 jgall">
                            </div>
                        </div>
                    </div>
                </div>
                <% if (Model.Annex21 == 1)
                   {%>
                <%
                    if ((EbSite.Base.Host.Instance.UserID != Model.UserID))
                    {%>
                <div id="answerdiv" class="jgwenda">
                    <div class="jgwdtxta">
                        <textarea id="answercontent" name="answercontent" class="wdinput2 areabornone" cols="80"
                            rows="4"></textarea></div>
                    <a href="#" onclick="SubmitAnswer()">
                        <div class="jgwdbtn jgall">
                        </div>
                    </a>
                </div>
                <%
                    }
                   }%>
                <%if (Model.Annex21 == 3)
                  {%>
                <div class="jgwenda" style="margin-left: 220px;">
                    <div class="jgclosebtn jgall">
                    </div>
                    <div class="quesclose">
                        问题已关闭，没有最佳答案。</div>
                </div>
                <%
                    }%>
            </div>
            <div class="l_top">
                <% if (Model.Annex21 == 2)
                   {%>
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
                                <div class="jguserphotoauto">
                                    <img src="<%=info.AvatarBig %>" width="63" /></div>
                            </a></li>
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
                                    <% =Model.UserNiName%></font>]追问：<%#Eval("ctent") %>?</li>
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
                <%
                    }%>
                <div class="clear">
                </div>
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
                                        <%#UserInfo(Eval("IsAnonymity").ToString(),Eval("AnswerUserID").ToString())%></li>
                                </div>
                                <div class="tab2_name" style="width: 600px;">
                                    <div class="tab2_que">
                                        <li id="xHf<%#Eval("AnswerUserID") %>">
                                            <%#SetContent(Eval("AnswerContent").ToString(),int.Parse(Eval("IsApproved").ToString()))%></li></div>
                                    <div class="tab2_min">
                                        <li>回答：</li><li >
                                        <a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Convert.ToInt32(Eval("AnswerUserID").ToString())) %>">
                                               <span style=" color:red;">  <%#EbSite.Base.Host.Instance.GetUserByID(Convert.ToInt32(Eval("AnswerUserID").ToString())).NiName%></span>
                                        </a>
                                            </li>
                                        <li>回答时间：</li><li>
                                            <%#Eval("AnswerTime")%></li>
                                    </div>
                                    <%#UpdateAnswer(int.Parse(Eval("QID").ToString()), int.Parse(Eval("AnswerUserID").ToString()), int.Parse(Eval("IsApproved").ToString()), Eval("AnswerContent").ToString())%>
                                </div>
                                <asp:Repeater ID="rpSubList" runat="server">
                                    <HeaderTemplate>
                                        <div class="tab2_ques" style="margin-left: 87px;">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>[<font color="#FF0000">
                                            <%=Model.UserNiName%></font>]追问：<%#Eval("ctent") %>?</li>
                                        <%#SecoGetZhiWenAnswer(Convert.ToInt32(Eval("id")), Convert.ToInt32(Eval("answerid")))%>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <div class="tab2_ques" style="margin-left: 87px;" d="<%=Model.UserNiName%>" id="xResult<%#Eval("AnswerUserID") %>">
                                </div>
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
            </div>
            <div class="line">
            </div>
            
            
                    
            <div class="ques_ans2 mt10">
            <h2 class="new_ans"><strong>正在等你回答</strong></h2>
            <div class="recomlist anslist">
            	<ul>
            		<asp:Repeater ID="RepWaiting" runat="server">
                    <ItemTemplate>
                		<li class="c">
                			<a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),10)%>" target="_blank">
								<%#Eval("newstitle")%>？
                			</a><i><%#Eval("Annex11")%>回答</i></li>
                	</ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>

        </div>
        <div class="c_right">
            <div class="crtab2 ">
                <a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.AskPost(GetSiteID) %>">
                    <img src="<%=base.ThemeCss%>images/bnr5.png" title="点击这里，可迅速提问自己的问题。" /></a>
                您可以快速知道您爱车的故障所在及解决方法
            </div>
            <div class="clear">
            </div>
            <div class="bor_c">
                <div class="crtabtop">
                    相关问题</div>
                <div class="crtabli">
                  
                </div>
            </div>
        </div>
    </div>
    <span runat="server" id="datacount"></span>
    <!--#include file="footer.inc"-->
    <script>
    var SiteConfigsX = { contentIDX: <%=Model.ID  %>,contentCIDX:<%=Model.ClassID  %>, stateX:  <%=Model.Annex21 %>, askuseridX:  <%=Model.UserID %>,samecountX:<% =Model.Annex15 %> };
    </script>
    <script>  
   
    $(function () {
        debugger;
            var useridD =CurrentUserId;// <%=base.UserID %>; 
            var askuseridD = SiteConfigsX.askuseridX; 
            if (useridD > 0 && useridD == askuseridD) {
              $("#div_sq").hide();
            }
            else{
            $("#div_sq").show();
            }
            var pram = { "UserID": SiteConfigsX.askuseridX };
            runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetUserCredits", pram, GetScore);
           
       //同问
       var samenum=SiteConfigsX.samecountX;
       if(samenum=="0")
       {
       $("#follow-btn").html("同问");
       }
       else
       {
        $("#follow-btn").html(samenum+"人同问");
       }

        var a = SiteConfigsX.stateX;
        if (a == "2")  //已解决
        {
            $("#asktl").html("已解决");
        }
        else if (a == "1")//未解决
        {
            $("#asktl").html("待解决");

            var askcontentid = SiteConfigsX.contentIDX; //<%=Model.ID  %> ;//问题的ID
            var pram = { "AskID": askcontentid };
            runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "IsHaveAnswer", pram, bk_IsHaveAnswer); //如果回答了问题，隐藏回答框

            //是否可以匿名发表
            runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "UpScoreModel", pram, GetIfNi);
        }
        else if (a == "3") {
            $("#asktl").html("已关闭");
            var askcontentid = SiteConfigsX.contentIDX; //<%=Model.ID  %> ;//// 问题的ID
        }
    });
   
    $("#ScoreDDList>select").change(function () {
        alert(0);
        var score = $("#ScoreDDList").find("option:selected").val();
        if (sumscore < score) {
            tips("您的分数不足", 2);
            $("#btnokupscore").attr("disabled", "disabled");
        }
        else {
            $("#btnokupscore").removeAttr('disabled');

        }
    });

    jQuery(function ($) {
        UpSpecial("testddd", <%=Model.ID  %>);
    });
    
        //调出 好评数
        var pram = { "id": "<%=info.AnswerID %>" };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GoodCount", pram, function (result) {
            $("#goodcount").text(result.d);
        });
    </script>
    <script type="text/javascript" src="<%= base.ThemePage%>content.js"></script>
</body>
</html>
