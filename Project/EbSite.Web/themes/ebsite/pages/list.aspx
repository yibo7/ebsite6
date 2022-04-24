
<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.list" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body >

<!--#include file="headerlist.inc" -->

<div class="mainbox">

<div style="margin-top: 10px;" class="contentbox">
            <div style="width: 185px;" class="fLeft">
                <div class="indexclassp" >
                    <div class="indexclass"  >
                        <%=Model.ClassName %>
                    </div>
                    <XS:Widget ID="Widget9" WidgetName="分类导航-列表左则"  WidgetID="7f0c1852-85ce-4538-8068-cbe9f26db929" runat="server"/>
                    
                </div>
            </div>
            <div class="fRight">
                 <div class="listbox" >
                    <div class="title">
                         <%=Model.ClassName %>列表
                         <a target="_blank" href="<%=HostApi.GetRss(100,2,GetSiteID,GetSiteID) %>"><img src="<%=IISPath%>images/rss.gif"/></a>
                    </div>
                    <div class="datalist">
                             <XS:RepeaterList ID="rpGetClassList"     runat="server"  >
                                 <ItemTemplate>
                                     <ul>
                                      <li class="news_title">
                                        <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%#Eval("newstitle")%></a>
                                        
                                          <span class="ot">
                                        <span>作者：<a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("userid"))%>" target="_blank"><font color="red"><%#Eval("userniname")%></font></a> </span><span> 
                                        
                                        <span> 点击：<font color="red"><%#Eval("hits")%></font></span></span>
                                        <br/>
                                        发表于：<font color="red"><%#Eval("addtime")%></font></span>
                                      </li>
                                       
                                      </ul>  
                                 </ItemTemplate>
                            </XS:RepeaterList>
                           
                         <XS:PagesContrl ID="pgCtr" PageSize="2" runat="server" />       
                    </div>
                </div>
            </div>
         


    </div>
    
</div>
<div class="clear"></div>
<!--#include file="footer.inc" -->
</body>
</html>