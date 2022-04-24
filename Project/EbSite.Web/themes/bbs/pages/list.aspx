<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.list" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control.xsPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body style="background-color:#fff;">

<!--#include file="header.inc" -->
<form method="GET" onsubmit="return onmanagerpost(this)" action="<%=EbSite.Modules.BBS.ModuleCore.GetLinks.Operation(GetSiteID,Model.ID) %>">
<table border="0" cellspacing="0" cellpadding="0"  class="mapbox">
                       
                        <tr>                            
                            <td valign="top"> 
                                        <XS:RepeaterList ID="rpGetSubClassList"    runat="server">
                                            <HeaderTemplate>
                                               <div class="ctent">
                                                    <div class="ctent-top">
                                                        <span class="ctent-title"><a href="#">子版块</a></span>
                                                    </div>
                                                    <div class="bbs-ctent">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                    <div class="bbs-">
                                                                                        <div class="left-bbs">
                                                                                            <a href='<%#HostApi.GetClassHref(Eval("id"),Eval("HtmlName"),1,"",GetSiteID)%>'>
                                                                                                <img src="<%=base.ThemeCss %>images/icons/topicicon_default.png"></img>
                                                                                             </a>
                                                                                        </div>
                                                                                        <div class="right-bbs">
                                                                                            <span class="ctent-title-class">
                                                                                            <a href='<%#HostApi.GetClassHref(Eval("id"),Eval("HtmlName"),1,"",GetSiteID)%>' >
                                                                                            <%#Eval("classname")%>
                                                                                            </a>
                                                                                            </span> 主题: <%#Eval("Annex2")%>, 新帖: <%#Eval("Annex1")%>
                                                                                            <br />
                                                                                            最后发表: <%#Eval("Annex8")%>
                                                       </div>
                                                    </div>                     
                                    
                                            </ItemTemplate>
                                            <FooterTemplate>
                                             </div>
                                            </div>
                                            </FooterTemplate>
                                    </XS:RepeaterList>
                                   
                            </td>
                        
                        </tr>
                        <tr>
                            <td valign="top" id="postlistbox" >
                                <div class="middle-div">
                                    <div class="topice-top">
                                        <a href="<%=EbSite.Modules.BBS.ModuleCore.GetLinks.SavePostUrl(Model.ID,GetSiteID) %>" >
                                            <div class="topice-top-l"></div>
                                        </a>
                                        <div class="topice-top-r"></div>
                                    </div>
                                    <div style="border:1px solid #DEDEDE;" class="ctent">
                                        <div class="ctent-top-post">
                                            <span class="ctent-title">
                                                <span style="display: none;" id="ManagerTool">
                                                    <b style="cursor: pointer" onclick="on_checkback($('#postlistbox'))">
                                                    [全选]&nbsp;&nbsp; 
                                                    </b>
                                                    <b >
                                                       <input type="submit" value="管理帖子" />
                                                    </b>
                                                </span> 
                                                
                                                <%=Model.ClassName %> 
                                                今日:<%=Model.Annex14%> &nbsp;&nbsp;
                                                主题:<%=Model.Annex12%>  &nbsp;&nbsp;
                                                回帖:<%=Model.Annex13%>  &nbsp;&nbsp;
                                            </span>
                                        </div>

                                        <div class="topice-title">
                                            <div class="topice-list-pic">
                                               
                                            </div>
                                            <div class="topice-title-type">
                                                标题
                                            </div>
                                            <div class="topice-title-lasttime">
                                                最后更新</div>
                                             <div class="topice-title-hf">
                                                回复/查看</div>
                                             <div class="topice-title-time">作者</div>
                                        </div>

                                        
                                        
                                        <XS:Repeater ID="rpTops"  runat="server">
                                            <ItemTemplate>
                                                <div class="topice-list-title">
                                                <div class="topice-list-pic">
                                                    <input style="display: none;" name="postid" value="<%#Eval("id")%>" type="checkbox"/>
                                                   <%#EbSite.Modules.BBS.ModuleCore.Comm.PostTitleLab(Eval("Annex13"),base.ThemeCss,HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))) %>
                                                </div>
                                           
                                                <div class="topice-titlestyle">
                                                    <%#EbSite.Modules.BBS.ModuleCore.Comm.PostTitleFont(Eval("newstitle"),Eval("Annex8"),Eval("Annex5"),HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))) %>
                                                     
                                                 </div>

                                                 <div class="topice-list-ask">
                                                     <div class="topice-list-font">
                                                         <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("Annex3"))%>">
                                                                        <%#Eval("Annex2")%> 
                                                                </a>
                                                     </div>
                                                    <div class="topice-list-font-time"> 
                                                        <%#Eval("AddTime")%>
                                                    </div>
                                                </div>
                                             
                                                <div class="topice-list-nums">
                                                    <%#Eval("CommentNum")%>/<%#Eval("hits")%>
                                                </div>
                                               <div class="topice-list-add">
                                                    <div class="topice-list-font">
                                                        
                                                        <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("UserID"))%>">
                                                        <%#Eval("UserNiName")%>
                                                        </a>
                                                    </div>
                                                    <div class="topice-list-font-time"> 
                                                        <%#Eval("Annex4")%>
                                                    </div>
                                                </div>
                                            </div>
                                            </ItemTemplate>
                                    </XS:Repeater>

                                                                               
                                      

                                         <div class="topice-title-sub">
                                          版块帖子
                                        </div>

                                        <XS:RepeaterList ID="rpGetClassList" OrderBy="AddTimeDESC"   runat="server">
                                            <ItemTemplate>
                                                    <div class="topice-list-title">
                                                        <div class="topice-list-pic">
                                                            <input style="display: none;" name="postid" value="<%#Eval("id")%>" type="checkbox"/>
                                                            <%#EbSite.Modules.BBS.ModuleCore.Comm.PostTitleLab(Eval("Annex13"),base.ThemeCss,HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))) %>
                                                        </div>
                                           
                                                        <div class="topice-titlestyle">
                                                         <%#EbSite.Modules.BBS.ModuleCore.Comm.PostTitleFont(Eval("newstitle"),Eval("Annex8"),Eval("Annex5"),HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))) %>
                                                         </div>
                                                         <div class="topice-list-ask">
                                                             <div class="topice-list-font">
                                                                <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("Annex3"))%>">
                                                                        <%#Eval("Annex2")%> 
                                                                </a>
                                                              </div>
                                                            <div class="topice-list-font-time"> <%#Eval("AddTime")%></div>
                                                        </div>
                                             
                                                        <div class="topice-list-nums">
                                                            <%#Eval("CommentNum")%>/<%#Eval("hits")%>
                                                        </div>
                                                       <div class="topice-list-add">
                                                            <div class="topice-list-font">
                                                              <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("UserID"))%>">
                                                                <%#Eval("UserNiName")%>
                                                                </a>
                                                            </div>
                                                            <div class="topice-list-font-time">
                                                             <%#Eval("Annex4")%>
                                                            </div>
                                                        </div>
                                                    </div>
                                            </ItemTemplate>
                                    </XS:RepeaterList>
                                    </div>
                                    <div class="topice-top">
                                        <a  href="<%=EbSite.Modules.BBS.ModuleCore.GetLinks.SavePostUrl(Model.ID,GetSiteID) %>" >
                                            <div class="topice-top-l"></div>
                                        </a>
                                        <div class="topice-top-r">
                                        </div>
                                    </div>
                                    
                                </div>
                            </td>
                        </tr>
                       
                    </table>
                    <XS:PagesContrl PageSize="20" ID="pgCtr" runat="server" /> 

  
<!--#include file="footer.inc" -->

  <script>

      function onmanagerpost(obj) {
          var  isok = false;
          $(obj).find("input[name=postid]").each(
             function (i) {                   
                 if (this.checked)
                 {
                     isok =  true;
                 }                     
                     
             }
             );
          if (!isok) {
              tips("请选择帖子！",1);
              return isok;
          }
          else {
              return isok;
          }
              
              

      }
      
      jQuery(function ($) {
          runebws("GetManagerID", null, function (msg) {
              var data = msg.d;
              if (data > 0) {
                  $("#ManagerTool").show();
                  $("input[name=postid]").show();
              }

          });
      });
      jQuery(function ($) {
          var currenturl = location.href;
          var index = currenturl.substring(0, currenturl.length - 1).lastIndexOf('/');
          var doname2 = currenturl.substring(index);

          var cur4Sorder = null;
          $(".majornav-list  a").each(function (i) {
              var obj = $(this);
              if (!!obj.attr("href")) {
                  var indexMenus = obj.attr("href");

                  if (doname2 == indexMenus) {

                      cur4Sorder = obj;

                  }
              }
          });
          if (cur4Sorder != null) {
              $(".majornav-list a").first().removeClass("current");
              cur4Sorder.addClass("current");
          }
      });
  </script>
   </form>
</body>
</html>