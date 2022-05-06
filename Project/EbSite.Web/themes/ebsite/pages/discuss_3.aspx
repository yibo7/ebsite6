<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="EbSite.Web.Pages.Remark" %>

<!DOCTYPE   html   PUBLIC   "-//W3C//DTD   XHTML   1.0   Transitional//EN "   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd ">
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>评论</title>
</head>
<body  onload="resizeFrame()">
    <form id="form1" runat="server">
        <table >
            <tr>
                <td style="width: 50%;">
                    <b>留言列表:</b>(共<%=iSearchCount %>条)
                </td>

                <td style="text-align: right; width: 50%;">发表或回复一条评论将可获得<font color="red"><%=CommentInCredit %></font>积分
                </td>
            </tr>
        </table>

        <table>

            <asp:Repeater OnItemDataBound="rpComment_ItemDataBound" runat="server" ID="rpComment" EnableViewState="false">
                <ItemTemplate>
                    <tr>
                        <td class='title'>
                            <%# bool.Parse(Eval("IsNiName").ToString()) ? "匿名网友" : string.Format("<a target=_blank href='{0}'>{1}</a>",HostApi.GetUserSiteUrl(Eval("UserId")),Eval("UserNiName"))%>(<%#Eval("ip") %>)
		                  发表于 <%#Eval("dateandtime")%>
			                
                   评分： <%#Eval("EvaluationScore")%>
                            <span>
                                <a href="#" onclick="reply(<%#Eval("ID") %>)">回复</a>
                                <a href="#" onclick="ClientExecutePost(0,<%#Eval("ID") %>,this,<%#Eval("Support")%>)">支持[<%#Eval("Support")%>]</a>

                                <a href="#" onclick="ClientExecutePost(1,<%#Eval("ID") %>,this,<%#Eval("Discourage")%>)">反对</a>[<%#Eval("Discourage")%>]
	             
	            <a href="#" onclick="ClientExecutePost(2,<%#Eval("ID") %>,this,<%#Eval("Information")%>)">举报</a>[<%#Eval("Information")%>]
                            </span>


                        </td>
                    </tr>

                    <tr>
                        <td class="postbody">
                            <%#Eval("Body") %>
                        </td>
                    </tr>
                    <tr id="postfoot<%#Eval("ID") %>" style="display: none">
                        <td class="postfoot">
                            <div>
                                <textarea rows="2" cols="20" id="replybox<%#Eval("ID") %>" style="height: 100px; width: 100%;"></textarea>
                            </div>
                            <div>
                                <input onclick="canclreply(<%#Eval("ID") %>)" type="button" value="取消" />
                                <input onclick="replypost(<%#Eval("ID") %>)" type="button" value="提交" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:Repeater runat="server" ID="rpCommentSubList">
                                <HeaderTemplate>
                                    <div class="replylist">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="replytile">
                                        <%# bool.Parse(Eval("IsNiName").ToString()) ? "匿名网友" : string.Format("<a target=_blank href='{0}'>{1}</a>",HostApi.GetUserSiteUrl(Eval("UserId")),Eval("UserNiName"))%>(<%#Eval("ip") %>)
		                  发表于 <%#Eval("dateandtime")%>

                                        <span>
                                            <a href="#" onclick="replysub(<%#Eval("ID") %>)">回复</a>
                                            <a href="#" onclick="ClientExecutePostSub(0,<%#Eval("ID") %>,this,<%#Eval("Support")%>)">支持[<%#Eval("Support")%>]</a>

                                            <a href="#" onclick="ClientExecutePostSub(1,<%#Eval("ID") %>,this,<%#Eval("Discourage")%>)">反对</a>[<%#Eval("Discourage")%>]
	             
	                            <a href="#" onclick="ClientExecutePostSub(2,<%#Eval("ID") %>,this,<%#Eval("Information")%>)">举报</a>[<%#Eval("Information")%>]
                                        </span>
                                    </div>
                                    <div class="SubQuote">
                                        <%#Eval("QuoteShow") %>
                                    </div>
                                    <div class="replybody">
                                        <%#Eval("Body") %>
                                    </div>
                                    <div id="postfootsub<%#Eval("ID") %>" style="display: none; margin-bottom: 30px;" class="postfoot">
                                        <div>
                                            <textarea rows="2" cols="20" id="replybox<%#Eval("ID") %>" style="height: 100px; width: 100%;"></textarea>
                                        </div>
                                        <div>
                                            <input onclick="canclreplysub(<%#Eval("ID") %>)" type="button" value="取消" />
                                            <input onclick="replypostsub(<%#Eval("ID") %>)" type="button" value="提交" />
                                        </div>

                                    </div>
                                    <div class="clear"></div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>

                        </td>
                    </tr>

                </ItemTemplate>
            </asp:Repeater>
        </table>

        <div style="padding-right:10px;" >
            <XS:PagesContrl ID="pgCtr" PageSize="6" Linktype="Aspx" runat="server" />
        </div>
        
        <table >


                <tr>
                    <td colspan="6">
                        <input type="text" style="display: none" id="quote" name="quote" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">评分:<div id="star"></div>
                        <script>
                            In.ready('raty', function () {
                                $('#star').raty({
                                    hints: ['1分', '2分', '3分', '4分', '5分'],
                                    path: "/js/plugin/raty/img",
                                    starOff: 'star-off-big.png',
                                    starOn: 'star-on-big.png',
                                    size: 30,
                                    score: CountScore,
                                    click: function (score, evt) {
                                        $("#EvaluationScore").val(score);
                                    }
                                });
                            });
                        </script>

                        <asp:HiddenField ID="EvaluationScore" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:TextBox Width="80%" Height="100" ID="txtContent" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 180px;">

                        <table>
                            <tr id="IsOpenSafeCoder" runat="server">
                                <td>
                                    <asp:Image ID="ImageCheck" runat="server" onClick="this.src+=Math.random()" Style="cursor: pointer;" ImageUrl="ValidateCode.ashx?" ToolTip="图片看不清？点击重新得到验证码,不区分大小写!红色数字,黑色字母!"></asp:Image>
                                    <br />
                                    验证码: 
                                <XS:TextBox ID="txtSafeCoder" runat="server" Width="80" CanBeNull="必填"></XS:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td class="form-inline">
                                    匿名发表:<asp:CheckBox ID="cbNiName" Text="是" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnPl" Width="80" Height="23" BorderColor="#000"
                                        runat="server" Text="我要留言" OnClick="btnPl_Click" />
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td style="height: 30px; color: ThreeDFace" colspan="5">网友评论仅供网友表达个人看法，并不表明本站同意其观点或证实其描述
                    </td>
                </tr>

            </table>


    </form>


    <style type="text/css">
        * {
            padding: 0;
            margin-left: 0;
            margin-right: 0;
            margin-top: 0;
        }

        body {
            font-size: 12px;
            background-color: #fff;
            width:100%;
        }

        input {
            border: solid 1px #CBCBCB;
            height: 20px;
        }

        textarea {
            border: solid 1px #CBCBCB;
            margin-top: 10px;
        }

        table {
            width: 100%;
        }

        .title {
            background: #F6F6F6;
            color: #B5B5B5;
        }

            .title span {
                float: right;
            }

        .replytile {
            color: #B5B5B5;
        }

            .replytile span {
                float: right;
            }

        .SubQuote {
            color: #B0A28B;
        }

        .replybody {
            padding-bottom: 20px;
        }

        .postfoot {
            padding-bottom: 20px;
        }

        td {
            padding: 8px;
        }

        .postfoot input {
            float: right;
            width: 100px;
            height: 30px;
            margin-left: 8px;
        }

        .replylist {
            background: #FAF7F2;
            padding: 8px;
            border: solid 1px #F0EDE9;
        }

        .ParentClass table {
            background: #fff;
            width: auto;
        }

        .ParentClass td {
            padding-left: 10px;
            padding-right: 10px;
            height: 20px;
            border: solid 1px #ccc;
            text-align: center
        }

        .CurrentPageCoder {
            color: #fff;
            font-weight: bold;
            background: #1F3A87
        }
    </style>
    <script type="text/javascript" src="<% =IISPath%>js/remark.js"></script>
</body>
</html>
