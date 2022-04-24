<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyAnswerList.ascx.cs"
    Inherits="EbSite.Modules.Wenda.UserPages.Controls.MyAskManage.MyAnswerList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:Repeater ID="gdList" runat="server">
    <headertemplate>
                 <div class="gdList_title" >
                  <div  style="width:400px;">标题 (共<%=iLoadCount%>条)</div> 
                  <div  style="width:100px;">被采纳答案</div>
                  <div  style="width:150px;">回答时间</div>
                </div>    
              
                            </headertemplate>
    <itemtemplate>
                             

                                 <div class="gdListContent" >
                  <div  style="width:400px;"> 
                   <span  style="float:left; margin-left:3px;"> 
                                      <a target="_blank" href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("QID"),EbSite.BLL.NewsClass.GetModel(int.Parse(Eval("QID").ToString())).HtmlName,ModuleSiteID)%>"> 
                                        <%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetAskByID(Eval("QID").ToString())%></a></span>
                  </div>
                  <div  style="width:100px;"><%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetBoolText(bool.Parse(Eval("IsAdoption").ToString()))%></div>
                  <div style="width:150px;"><%#string.Format("{0:g}", Eval("AnswerTime"))%></div>
                </div>    
                              
                             </itemtemplate>
    <footertemplate>
                              
                            </footertemplate>
</XS:Repeater>
<div style="clear: both;">
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
