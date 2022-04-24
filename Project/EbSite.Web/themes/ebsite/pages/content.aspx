<%@ Page Language="C#" AutoEventWireup="true"    Inherits="EbSite.Web.Pages.content" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<%@ Register TagPrefix="XSD" Namespace="EbSite.ControlData" Assembly="EbSite.ControlData" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>

</head>
<body>
<!--#include file="headerlist.inc" -->

<div class="mainbox">

<div style="margin-top: 10px;" class="contentbox">
    
    <div style="width: 760px;" class="fLeft">
            <div class="contentinfo" >
                    <div class="title"><%=Model.NewsTitle %></div>

                <div>
                     <asp:Repeater ID="rpPageInfo"   runat="server"  >
                                       <HeaderTemplate>
                                           <div class="booktag">
                                           <div class="booktagt">目录</div>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                           <li><%#Container.ItemIndex+1 %>.<a <%#bool.Parse(Eval("IsCurrent").ToString())?"class='currentpi'":""%> href="<%#Eval("Href")%>"><%#Eval("Title")%></a> </li>   
                                        </ItemTemplate>
                                       <FooterTemplate>
                                            </div>
                                       </FooterTemplate>
                                    </asp:Repeater> 
                </div>
                    <div>
                         <%=ShowInfo%>
                    </div>
             </div>
              
              <div style="margin-top: 10px;">
                 <!--评论-->
                  
                   <XSD:RepeaterRemark OnItemDataBound="rpComment_ItemDataBound" PageSize="10" RemarkClassID="3" runat="server" ID="rpComment" EnableViewState="false">
                         <HeaderTemplate>
                            <div>
                                 <b>网友评论:</b>
                            </div>
                            
                        </HeaderTemplate>        
		                <ItemTemplate>
                      <table class="remarktable">
		                        <tr>
		                            <td class='remarktitle'>
		                                <%# bool.Parse(Eval("IsNiName").ToString()) ? "匿名网友" : string.Format("<a target=_blank href='{0}'>{1}</a>",HostApi.GetUserSiteUrl(Eval("UserId")),Eval("UserNiName"))%>(<%#Eval("ip") %>)
		                                      发表于 <%#Eval("dateandtime")%>
			                
                                       评分： <%#Eval("EvaluationScore")%>
			                            <span>
                                             <a   onclick="reply(<%#Eval("ID") %>)">回复</a> 
	                                <a onclick="ClientExecutePost(0,<%#Eval("ID") %>,this,<%#Eval("Support")%>)">支持[<%#Eval("Support")%>]</a>
	                	               
	                                <a onclick="ClientExecutePost(1,<%#Eval("ID") %>,this,<%#Eval("Discourage")%>)">反对</a>[<%#Eval("Discourage")%>]
	             
	                                <a onclick="ClientExecutePost(2,<%#Eval("ID") %>,this,<%#Eval("Information")%>)">举报</a>[<%#Eval("Information")%>]
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
                                           <textarea  rows="2" cols="20" id="replybox<%#Eval("ID") %>"  style="height:100px;width:99%;"></textarea>
                                       </div>
                                        <div>
                                            <input onclick="canclreply(<%#Eval("ID") %>)"  type="button" value="取消"/>
                                            <input onclick="replypost(<%#Eval("ID") %>)"  type="button" value="提交"/> 
                                        </div>
                                    </td>
                                </tr>
                                    <tr>
                                        <td>
                    
                                            <asp:Repeater runat="server" ID="rpCommentSubList" >    
                                                <HeaderTemplate>
                                                    <div class="replylist">
                                                </HeaderTemplate>   
		                                        <ItemTemplate>
		                                             <div class="replytile">
		                                                <%# bool.Parse(Eval("IsNiName").ToString()) ? "匿名网友" : string.Format("<a target=_blank href='{0}'>{1}</a>",HostApi.GetUserSiteUrl(Eval("UserId")),Eval("UserNiName"))%>(<%#Eval("ip") %>)
		                                          发表于 <%#Eval("dateandtime")%>
                                 
                                                          <span>
                                                                 <a   onclick="replysub(<%#Eval("ID") %>)">引用</a> 
	                                                    <a  onclick="ClientExecutePostSub(0,<%#Eval("ID") %>,this,<%#Eval("Support")%>)">支持[<%#Eval("Support")%>]</a>
	                	               
	                                                    <a  onclick="ClientExecutePostSub(1,<%#Eval("ID") %>,this,<%#Eval("Discourage")%>)">反对</a>[<%#Eval("Discourage")%>]
	             
	                                                    <a onclick="ClientExecutePostSub(2,<%#Eval("ID") %>,this,<%#Eval("Information")%>)">举报</a>[<%#Eval("Information")%>]
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
                                                           <textarea  rows="2" cols="20" id="replybox<%#Eval("ID") %>"  style="height:100px;width:100%;"></textarea>
                                                       </div>
                                                        <div>
                                                            <input onclick="canclreplysub(<%#Eval("ID") %>)"  type="button" value="取消"/>
                                                            <input onclick="replypostsub(<%#Eval("ID") %>)"  type="button" value="提交"/> 
                                                        </div>
                                
                                                    </div>
                                                    <div class="clear"></div>
		                                        </ItemTemplate>
                                                <FooterTemplate>
                                                     </div>
                                                </FooterTemplate>
                                            </asp:Repeater>
                   
                                        </td>
                                    </tr> </table>
 
		    </ItemTemplate>
              <FooterTemplate>
                 <div style="text-align: right;">
                     [<a target="_brank" rel="nofollow"  href="<%=HostApi.GetDiscussHref("3",1, GetSiteID,0,Model.ClassID,Model.ID )%>">查看所有评论</a>]
                 </div>               
                   <table style="width:100%; margin-left:10px;">
                  <tr>
                    <td colspan="6">
                        评分:<div id="star"></div>
                          <script>
                              In.ready('raty', function () {
                                  $('#star').raty({
                                      hints: ['1分', '2分', '3分', '4分', '5分'],
                                      path: SiteConfigs.UrlIISPath+"js/plugin/raty/img",
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
                        <input type="hidden" value="0"  id="txtEvaluationScore" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                         <textarea rows="2" cols="20" id="txtRemark" name="txtContent"  style="height:100px;width:80%;"></textarea>
                    </td>
                    <td style="width:180px; ">
                    
                        <table>
                            <tr>
                                <td>
                                    <input type="button"  style="width: 100px; height: 50px; " onclick="savepl(<%=rpComment.RemarkClassID%>,<%=GetClassID%>,<%=iRequestID%>)"  value=" 提交评论 "  />
                                </td>
                            </tr>
                             <tr>
                                <td>
                                  是否匿名发表<input id="cbNiName" type="checkbox" /> 
                                </td>
                            </tr>
                        </table>
                         
                    </td>
                </tr>
                 <tr>
                    <td style="height:30px; color:ThreeDFace" colspan="5">
                         网友评论仅供网友表达个人看法，并不表明本站同意其观点或证实其描述
                    </td>
                </tr>
            
            </table>
                   
<script type="text/javascript" src="<% =IISPath%>js/remark.js"></script>
              </FooterTemplate>
    </XSD:RepeaterRemark>
        
        
                                                                                                                                
              </div>

                                                                                                                                                                 
    </div>
    <div   class="mainright">
        <div class="title">相关内容</div>
        <div class="datalist">
            
             <XS:Widget ID="Widget1"   WidgetID="66098387-117e-4f3a-9154-02e6ce1b9ddb" runat="server"/>
                                                                             
        </div>
      
    </div>
</div>

</div>
<div class="clear"></div> 
 <script src="<%=this.ThemePage%>content.js" type="text/javascript"></script>
<!--#include file="footer.inc" -->
    <%if (!Equals(CPIUP, null)) {%> <a href="<%=CPIUP.Href %>">上一页</a> <%}%>  
    <%if (!Equals(CPINext, null)) {%> <a href="<%=CPINext.Href %>">下一页</a> <%}%>  
    
                                             
</body>
</html>