<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.special" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<%@ Import Namespace="EbSite.BLL.GetLink"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
</head>

<body >
 <!--#include file="header.inc"-->
 <div class="content" style="width: 990px; margin: 8px auto;">
        <div style="width:100%;" >
            <div class="l_top" style="padding: 10px; width:968px;">
                <li class="f_s14">
                
                     <a href="<%=DomainName%>"><b><%=SiteName%></b></a> ><a href="<%= EbSite.Base.Host.Instance.GetSpecialHref(Model.id,0)%>" target="_self"><%=Model.SpecialName%> </a>   

                </li>
            </div>
            <div style="width:99%; height:120px; line-height:35px; padding-left:8px; font-size:14px;" class="lb_top2">
              <XS:Widget ID="Widget1"   WidgetID="1e99dc56-3a30-445c-994e-37d15f45cbaa" runat="server"/>   
            </div>
            <div class="l_top3" style="z-index: 0;">
                <div class="zhuyi" >
                    <div id="tagsask" style="line-height:30px; padding-left:5px;" class="lb_top3ex">
                           <XS:Widget WidgetName="获取某个专题下的子专题"  WidgetID="cdd5349c-12b1-4745-92fd-c6bb96c82898" runat="server"/>
                                               
                    </div>
                    <div class="specialcontentlist">
                        <XS:RepeaterList ID="rpSpecialList" runat="server">

                         <ItemTemplate>
                         <div class="hid <%#Equals(((Container.ItemIndex+1)%2),0)?"bg":"" %>">
                         <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%>" title="<%#Eval("newstitle") %>"> <%#(pgCtr.PageSize*(pgCtr.PageIndex-1)) +Container.ItemIndex+1 %>. <%#EbSite.Modules.Wenda.ModuleCore.AskCommon.GetCutAskTitle(Eval("newstitle").ToString(),75)%></a>
                          </div>  </ItemTemplate>
                           
                        </XS:RepeaterList>
                    </div>
                  
                    <div style="float: right; ">
                        <XS:PagesContrl ID="pgCtr" runat="server" />
                    </div>
                </div>
            </div>
            <div style="width:100%;" class="line">
            </div>
        </div>
        
    </div>


<div class="clear"></div>
<div style="top: 1475px;" id="foot"></div>
  <!--#include file="footer.inc" -->
<span runat="server" id="datacount"></span> 
</body>
</html>