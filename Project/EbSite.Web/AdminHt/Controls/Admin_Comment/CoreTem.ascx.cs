using System;
using System.IO;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Comment
{
    
    public partial class CoreTem : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "126";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }

        private Entity.RemarkClass md;
        override protected void InitModifyCtr()
        {
            md = BLL.RemarkClass.Instance.GetModel(ID);
           

        }

        override protected void SaveModel()
        {
            
        }

        private int ID
        {
            get
            {
                if(!string.IsNullOrEmpty(SID))
                {
                    return int.Parse(SID);
                }
                return 0;
            }
        }
         
        protected string MakeCoderIframe()
        {
            
            if (md.IPage == 1)
            {
                return string.Format("<iframe id=\"win\" name=\"win\" style=\"width: 100%; height: 600px;\" src=\'<%=HostApi.GetDiscussHref(\"{0}\",{1}, GetSiteID,{2},Model.ClassID,0)%>' frameborder=\"0\" scrolling=\"no\"></iframe>",
                    md.id, md.Itype, md.IPage);

            }
            else
            {
                return string.Format("<iframe id=\"win\" name=\"win\" style=\"width: 100%; height: 600px;\" src=\'<%=HostApi.GetDiscussHref(\"{0}\",{1}, GetSiteID,{2},Model.ClassID,Model.ID )%>' frameborder=\"0\" scrolling=\"no\"></iframe>",
                    md.id, md.Itype, md.IPage);
            }

        }

        protected string MakeCoderContent()
        {
            string sTem = @"<XSD:RepeaterRemark OnItemDataBound=""rpComment_ItemDataBound"" PageSize=""10"" RemarkClassID=""{评论分类ID}"" runat=""server"" ID=""rpComment"" EnableViewState=""false"">
                         <HeaderTemplate>
                            <div>
                                 <b>网友评论:</b>
                            </div>
                            
                        </HeaderTemplate>        
		                <ItemTemplate>
                      <table class=""remarktable"">
		                        <tr>
		                            <td class='remarktitle'>
		                                <%# bool.Parse(Eval(""IsNiName"").ToString()) ? ""匿名网友"" : string.Format(""<a target=_blank href='{0}'>{1}</a>"",HostApi.GetUserSiteUrl(Eval(""UserId"")),Eval(""UserNiName""))%>(<%#Eval(""ip"") %>)
		                                      发表于 <%#Eval(""dateandtime"")%>
			                
                                       评分： <%#Eval(""EvaluationScore"")%>
			                            <span>
                                             <a   onclick=""reply(<%#Eval(""ID"") %>)"">回复</a> 
	                                <a onclick=""ClientExecutePost(0,<%#Eval(""ID"") %>,this,<%#Eval(""Support"")%>)"">支持[<%#Eval(""Support"")%>]</a>
	                	               
	                                <a onclick=""ClientExecutePost(1,<%#Eval(""ID"") %>,this,<%#Eval(""Discourage"")%>)"">反对</a>[<%#Eval(""Discourage"")%>]
	             
	                                <a onclick=""ClientExecutePost(2,<%#Eval(""ID"") %>,this,<%#Eval(""Information"")%>)"">举报</a>[<%#Eval(""Information"")%>]
                                        </span>
                   

		                            </td>
		                        </tr>
            
                                <tr>
                                    <td class=""postbody"">
                                        <%#Eval(""Body"") %>
                                    </td>
                                </tr>
                                  <tr id=""postfoot<%#Eval(""ID"") %>"" style=""display: none"">
                                    <td class=""postfoot"">
                                          <div>
                                           <textarea  rows=""2"" cols=""20"" id=""replybox<%#Eval(""ID"") %>""  style=""height:100px;width:99%;""></textarea>
                                       </div>
                                        <div>
                                            <input onclick=""canclreply(<%#Eval(""ID"") %>)""  type=""button"" value=""取消""/>
                                            <input onclick=""replypost(<%#Eval(""ID"") %>)""  type=""button"" value=""提交""/> 
                                        </div>
                                    </td>
                                </tr>
                                    <tr>
                                        <td>
                    
                                            <asp:Repeater runat=""server"" ID=""rpCommentSubList"" >    
                                                <HeaderTemplate>
                                                    <div class=""replylist"">
                                                </HeaderTemplate>   
		                                        <ItemTemplate>
		                                             <div class=""replytile"">
		                                                <%# bool.Parse(Eval(""IsNiName"").ToString()) ? ""匿名网友"" : string.Format(""<a target=_blank href='{0}'>{1}</a>"",HostApi.GetUserSiteUrl(Eval(""UserId"")),Eval(""UserNiName""))%>(<%#Eval(""ip"") %>)
		                                          发表于 <%#Eval(""dateandtime"")%>
                                 
                                                          <span>
                                                                 <a   onclick=""replysub(<%#Eval(""ID"") %>)"">引用</a> 
	                                                    <a  onclick=""ClientExecutePostSub(0,<%#Eval(""ID"") %>,this,<%#Eval(""Support"")%>)"">支持[<%#Eval(""Support"")%>]</a>
	                	               
	                                                    <a  onclick=""ClientExecutePostSub(1,<%#Eval(""ID"") %>,this,<%#Eval(""Discourage"")%>)"">反对</a>[<%#Eval(""Discourage"")%>]
	             
	                                                    <a onclick=""ClientExecutePostSub(2,<%#Eval(""ID"") %>,this,<%#Eval(""Information"")%>)"">举报</a>[<%#Eval(""Information"")%>]
                                                            </span>
		                                            </div>
                                                    <div class=""SubQuote"">
                                                         <%#Eval(""QuoteShow"") %>
                                                    </div>
		                                            <div class=""replybody"">
		                                                <%#Eval(""Body"") %>
		                                            </div>
                                                    <div id=""postfootsub<%#Eval(""ID"") %>"" style=""display: none; margin-bottom: 30px;"" class=""postfoot"">
                                                        <div>
                                                           <textarea  rows=""2"" cols=""20"" id=""replybox<%#Eval(""ID"") %>""  style=""height:100px;width:100%;""></textarea>
                                                       </div>
                                                        <div>
                                                            <input onclick=""canclreplysub(<%#Eval(""ID"") %>)""  type=""button"" value=""取消""/>
                                                            <input onclick=""replypostsub(<%#Eval(""ID"") %>)""  type=""button"" value=""提交""/> 
                                                        </div>
                                
                                                    </div>
                                                    <div class=""clear""></div>
		                                        </ItemTemplate>
                                                <FooterTemplate>
                                                     </div>
                                                </FooterTemplate>
                                            </asp:Repeater>
                   
                                        </td>
                                    </tr> </table>
 
		    </ItemTemplate>
              <FooterTemplate>
                 <div style=""text-align: right;"">
                     [<a target=""_brank"" rel=""nofollow""  href=""<%=HostApi.GetDiscussHref(""{评论分类ID}"",{评论模式ID}, GetSiteID,{评论类型ID},Model.ClassID,Model.ID )%>"">查看所有评论</a>]
                 </div>               
                   <table style=""width:100%; margin-left:10px;"">
                  <tr>
                    <td colspan=""6"">
                        评分:<div id=""star""></div>
                          <script>
                              In.ready('raty', function () {
                                  $('#star').raty({
                                      hints: ['1分', '2分', '3分', '4分', '5分'],
                                      path: SiteConfigs.UrlIISPath+""/js/plugin/raty/img"",
                                      starOff: 'star-off-big.png',
                                      starOn: 'star-on-big.png',
                                      size: 30,
                                      score: CountScore,
                                      click: function (score, evt) {
                                          $(""#EvaluationScore"").val(score);
                                      }
                                  });
                              });
                          </script> 
                        <input type=""hidden"" value=""0""  id=""txtEvaluationScore"" />
                    </td>
                </tr>
                <tr>
                    <td colspan=""5"">
                         <textarea name=""txtContent"" rows=""2"" cols=""20"" id=""txtRemark"" style=""height:100px;width:80%;""></textarea>
                    </td>
                    <td style=""width:180px; "">
                    
                        <table>
                            <tr>
                                <td>
                                    <input type=""button""  style=""width: 100px; height: 50px; "" onclick=""savepl(<%=rpComment.RemarkClassID%>,<%=GetClassID%>,<%=iRequestID%>)""  value="" 提交评论 ""  />
                                </td>
                            </tr>
                             <tr>
                                <td>
                                  是否匿名发表<input id=""cbNiName"" type=""checkbox"" /> 
                                </td>
                            </tr>
                        </table>
                         
                    </td>
                </tr>
                 <tr>
                    <td style=""height:30px; color:ThreeDFace"" colspan=""5"">
                         网友评论仅供网友表达个人看法，并不表明本站同意其观点或证实其描述
                    </td>
                </tr>
            
            </table>
                   
<script type=""text/javascript"" src=""<% =IISPath%>js/remark.js""></script>
              </FooterTemplate>
    </XSD:RepeaterRemark>";
            //{评论分类ID}"",{评论模式ID}, GetSiteID,{评论类型ID}
            return sTem.Replace("{评论分类ID}",md.id.ToString()).Replace("{评论模式ID}",md.Itype.ToString()).Replace("{评论类型ID}",md.IPage.ToString());
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            txtContentCore.Text = MakeCoderContent();
            txtIframeCore.Text = MakeCoderIframe();
        }
         
    }
}