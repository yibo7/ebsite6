<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MySameAskList.ascx.cs" Inherits="EbSite.Modules.Wenda.UserPages.Controls.MyAskManage.MySameAskList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div id="PagesMain">
    <div class="ListLine">
        <ul>
            <XS:Repeater ID="gdList" runat="server">
                <headertemplate>
                 <table class="queslist" cellpadding="0" cellspacing="0" border="0" align="left">
                                    <tr class="header">
                                        <td width="400">
                                        <span  style="float:left;">    &nbsp;标题 (共<%=iLoadCount%>条)</span>
                                        </td>
                                         <td width="100">
                                            状态
                                        </td>
                                         <td width="80">
                                            悬赏分
                                        </td>
                                        
                                        <td width="80">
                                            回答数
                                        </td>
                                       
                                        <td width="150">
                                            提问时间
                                        </td>
                            </headertemplate>
                <itemtemplate>
                                <tr>   
                                    <td>
                                      <span  style="float:left; margin-left:3px;">   [<a  href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("classid"),EbSite.BLL.NewsClass.GetModel(int.Parse(Eval("classid").ToString())).HtmlName,1,EbSite.BLL.NewsClass.GetModel(int.Parse(Eval("classid").ToString())).OutLike,ModuleSiteID)%>">
                                      <%#EbSite.BLL.NewsClass.GetModel(int.Parse(Eval("classid").ToString())).ClassName%> </a>]  &nbsp; <a target="_blank" href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),ModuleSiteID)%>"> 
                                          
                                            <%# (Eval("newstitle")).ToString().Length >= 30 ?
                                        (Eval("newstitle")).ToString().PadRight(30).Substring(0, 30) + "..."
                                        : (Eval("newstitle")).ToString()%> ? 
                                        </a></span>
                                    </td>
                                     <td>
                        <%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetAskStatu(int.Parse( Eval("Annex21").ToString()))%>
                        </td>
                                      <td><%# Eval("Annex1")%></td>
                                    <td>
                                       <%#Eval("annex11") %>
                                    </td>
                                    
                                    <td>
                                        <%#string.Format("{0:g}",Eval("addtime"))%>
                                    </td>
                                   
                 
                                </tr>
                              
                             </itemtemplate>
                <footertemplate>
                                </table>
                            </footertemplate>
            </XS:Repeater>
        </ul>
    </div>
</div>
<div style="clear: both;">
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
