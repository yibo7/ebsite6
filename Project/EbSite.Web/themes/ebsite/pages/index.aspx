<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.index" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>

<!--#include file="header.inc" -->

<div class="mainbox">

<div style="margin-top: 10px;" class="contentbox">
    
    <div style="width: 760px;" class="fLeft">
            <div style="width: 185px;" class="fLeft">
                <div class="indexclassp" >
                    <div class="indexclass"  >
                        ����
                    </div>

                    <XS:Widget ID="Widget9" WidgetName="���ർ��-�б�����"  WidgetID="7f0c1852-85ce-4538-8068-cbe9f26db929" runat="server"/>
                    
                </div>
            </div>
            <div class="fRight">
                 <div class="indexgoodbox" >
                    <div class="title">
                      <a href="<%=HostApi.GetTopHref(5,1)%>"  >��վ�Ƽ�</a>>>
                      <a target="_blank" href="<%=HostApi.GetRss(100,1,0,GetSiteID) %>"><img src="<%=IISPath%>images/rss.gif"/></a>
                    </div>
                    <div class="goodlist">
                            <div class="fLeft">
                                <XS:Widget ID="Widget3"   WidgetName="��ҳ�Ƽ�����-����"  WidgetID="a4cf9b67-cc7d-461b-89f0-d76af9abf5de" runat="server"/>
                            </div>
                            <div class="fRight">
                               <XS:Widget ID="Widget2" WidgetName="��ҳ�Ƽ�����-ͼƬ"    WidgetID="071a90cd-f96d-45bf-9712-da048f800afc" runat="server"/>
                            </div>                   
                    </div>
                </div>
                 <div class="indeximgbox" >
                    <div class="title">
                        <a href="<%=HostApi.GetTopHref(4,1)%>"  >���·���</a>>>
                        <a target="_blank" href="<%=HostApi.GetRss(100,2,0,GetSiteID) %>"><img src="<%=IISPath%>images/rss.gif"/></a>
                    </div>
                    <div class="imgnewslist">
                        <XS:Widget ID="Widget1" WidgetName="ͼƬ����"  WidgetID="c0a213e8-75c3-46c6-a61b-35ec670d6ace" runat="server"/>
                                                                   
                    </div>
                </div>
            </div>
            <div class="clear"></div>
          
           <XSD:RepeaterIndex ID="rpGetClassList"    DataType="�����б�"  runat="server">
                    <ItemTemplate>   
                                <div class="indexclassbox">
                                   <div class="title"><a  href='<%#HostApi.GetClassHref(Eval("ID"),Eval("HtmlName"),1,GetSiteID) %>'><%#Eval("ClassName")%></a>
                                       <span style="" >>></span>
                                   </div>
                                   <div class="datalist">
                                         <asp:Repeater ID="rpContent" runat="server">
                                            <ItemTemplate>
                                                 <li><a href="<%#HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("ClassId")) %>"> <%#Eval("NewsTitle")%></a></li>               
                                            </ItemTemplate>
                                        </asp:Repeater>           
                                        
                                   </div>
                               </div>
                    </ItemTemplate>
            </XSD:RepeaterIndex>


    </div>
    <div   class="mainright">
        <div class="title"><a href="<%=HostApi.GetTopHref(0,1)%>"  >���а�</a>>></div>
        <div class="datalist">
             <XS:Widget ID="Widget4" WidgetName="��������-������"  WidgetID="c825775f-5a4b-45b4-8556-2edb65fc1000" runat="server"/>
        </div>
         <div class="usr-title">
             ����ע��
           
         </div>
        <div class="usr-list">
                          <XS:Widget ID="Widget5" WidgetName="����ע���û�"  WidgetID="db1da758-1a2c-4d48-91a7-d1a9e8e55070" runat="server"/>
        </div>
        <div class="title"><a href="<%=HostApi.TagsList(1,GetSiteID) %>">���ű�ǩ</a>>></div>
        <div class="datalisttag">
            <XS:Widget ID="Widget10" WidgetName="��ȡ���ű�ǩ"  WidgetID="48a468fb-c0ba-4ebe-ad6b-b7e3f555f865" runat="server"/>
                                               
        </div>
         <div   class="title">��վ����</div>
            <div class="votelist">
                         <XS:Widget ID="Widget6" WidgetName="ͶƱ�б�"  WidgetID="daf1b481-596f-435b-b6c8-0146802947af" runat="server"/>
            </div>
    </div>
</div>

</div>
<div class="mainbox">
<div class="clear"></div>
<div   class="contentbox frlinkbox">
    <div class="title">
          <a href="<%=EbSite.Base.PageLink.GetBaseLinks.Get(GetSiteID).FrdlinkRw%>"  >��������>></a>
                                           &nbsp;&nbsp;
            <a href="<%=EbSite.Base.PageLink.GetBaseLinks.Get(GetSiteID).FrdlinkPostRw%>" >������������>></a>
             &nbsp;&nbsp;| &nbsp;&nbsp;
            <a style="font-size: 12px; font-weight: normal;" href="<%=EbSite.Base.PageLink.GetBaseLinks.Get(GetSiteID).UserOnlineRw%>">�����û�>></a>
    </div>
    <div class="datalist">
        <XS:Widget ID="Widget7" WidgetName="��ҳ��������"  WidgetID="b0e551c7-5f7d-4584-9328-43f74cfd0dc1" runat="server"/>
    </div>
    
</div>

</div>
<!--#include file="footer.inc" -->
<div style="text-align:center;background-color:#F4F4F4;">
    <div>
         <img style="height: 80px;border: 1px solid #ccc;" id="MobileBarcode" src="<%=HostApi.MobileBarcode %>"></img>
         
      </div>
      <div style="text-align:center">ɨһɨ�����ְ�</div>
</div>
   <%=HostApi.MLoginRw%>
</body>
</html>
