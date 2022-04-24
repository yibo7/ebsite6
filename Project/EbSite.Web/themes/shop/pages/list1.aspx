<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.list" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
</head>
<body >
<!--#include file="header.inc" -->


<div class="clear"></div>
<div class="wrapper mT5">
  <div id="position">
        <span style="font-size: 13px;color:#333333">当前位置：</span>     <a href="<%=DomainName%>">
    	        <b><%=SiteName%></b>
    	    </a> > 
            <%=GetNav()%>    
 </div>
</div>
<div class="wrapper mT5">
  <div class="l_left">
     <div id="buyguide" class="mT5">
      <div class="utitle">
        <div class="utitlei">
          <div class="title"><span class="title_t fLeft"><span class="title_t_i fLeft">
            <h2><a href="#" style="color:#FFF">热门<%=Model.ClassName %></a></h2>
            </span></span></div>
        </div>
      </div>
      <div class="ucontent">
            <XS:Widget ID="Widget1"   WidgetID="3fc1675f-ba6c-43c8-8617-2b1e9921ccc1" runat="server"/>
                                               
      </div>
      <div class="title_buttom">
        <div class="title_buttom_i"></div>
      </div>
    </div>
   
  </div>
  <div class="l_right">
    <div class="utitle">
      <div class="utitlei">
        <div class="title"><span class="title_t fLeft"><span class="title_t_i fLeft">
          <h2><a href="#" style="color:#FFF"><%=Model.ClassName %></a></h2>
          </span></span>
          <div class="iterm fRight" style="padding-right: 60px;">
            <ul>              
              <li class='<%=GetOrbderByClass(0) %>'><a href="<%= EbSite.Base.Host.Instance.GetClassHref_OrderBy(GetClassID,1,0) %>"><span>发布时间</span></a></li>
              <li class='<%=GetOrbderByClass(1) %>' ><a href="<%= EbSite.Base.Host.Instance.GetClassHref_OrderBy(GetClassID,1,1) %>"><span>点击次数</span></a></li>               
              <li class='<%=GetOrbderByClass(2) %>' ><a href="<%= EbSite.Base.Host.Instance.GetClassHref_OrderBy(GetClassID,1,2) %>"><span>收藏</span></a></li>            
              <li class='<%=GetOrbderByClass(3) %>' ><a href="<%= EbSite.Base.Host.Instance.GetClassHref_OrderBy(GetClassID,1,3) %>"><span>评论</span></a></li>
              <li class='<%=GetOrbderByClass(4) %>' ><a href="<%= EbSite.Base.Host.Instance.GetClassHref_OrderBy(GetClassID,1,4) %>"><span>好评</span></a></li>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <div class="ucontent">
         <div id="tech" class="clear"> 
             
               <div class="arc_list">
      
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
                                                                                                <img src="<%#Eval("Annex10")%>"></img>
                                                                                             </a>
                                                                                        </div>
                                                                                        <div class="right-bbs">
                                                                                            <span class="ctent-title-class">
                                                                                            <a href='<%#HostApi.GetClassHref(Eval("id"),Eval("HtmlName"),1,"",GetSiteID)%>' >
                                                                                            <%#Eval("classname")%>
                                                                                            </a>
                                                                                            </span> 主题: <%#Eval("Annex2")%>, 帖数: <%#Eval("Annex1")%>
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
                         
                          </div>
                
          </div>
    
    <div class="title_buttom">
      <div class="title_buttom_i"></div>
    </div>
    
    
    
    
  </div>
  
  
  <div class="mT5">
      <div class="title_top">
        <div class="title_top_i"></div>
      </div>
      <div class="ucontent">
<XS:PagesContrl ID="pgCtr"   runat="server" /> 
             </div>
      <div class="title_buttom">
        <div class="title_buttom_i"></div>
      </div>
    </div>
  
</div>
<div class="clear"></div>

<div class="wrapper mT5 mB10">
  <div class="title_top">
    <div class="title_top_i"></div>
  </div>
  <div class="ucontent">
    <!--#include file="foot.inc" -->
  </div>
  <div class="title_buttom">
    <div class="title_buttom_i"></div>
  </div>
</div>
 
<div style="top: 1475px;" id="foot"></div>

<%=KeepUserState()%>
</body>
</html>
