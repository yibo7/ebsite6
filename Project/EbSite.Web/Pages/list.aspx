<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="EbSite.Web.Pages.list" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<%@ Import Namespace="EbSite.BLL.GetLink"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
<meta http-equiv="mobile-agent" content="format=xhtml;url=<%#EbSite.Base.Host.Instance.MGetClassHref(Eval("id"),1,0)%>" />
<meta http-equiv="mobile-agent" content="format=html5;url=<%#EbSite.Base.Host.Instance.MGetClassHref(Eval("id"),1,0)%>" />
<meta http-equiv="mobile-agent" content="format=wml;url=<%#EbSite.Base.Host.Instance.MGetClassHref(Eval("id"),1,0)%>" />
</head>
<body >
<!--#include file="header.inc" -->
<XS:Widget ID="Widget1" WidgetName="获取某个分类下的子分类"  WidgetID="916aa362-51b0-4eb7-9cf7-9d1ff826dab9" runat="server"/>
   <XS:RepeaterList ID="rpGetClassList" IsDataFromClass="False"    runat="server"  >
                             <ItemTemplate>    
                             
                             <ul>
                              <li class="list_title">
                                <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%#Eval("newstitle")%></a>
                              </li>
                              <li class="text">
                                
                                 <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>">[阅读全文]</a></a></li>
                              <li class="ot">
                                <span>作者：<font color="red"></font> </span><span> 
                                发表于：<font color="red"><%#Eval("addtime")%></font></span>
                                <span> 点击：<font color="red"><%#Eval("hits")%></font></span></li>
                              </ul>  <asp:Repeater ID="rpsub"   runat="server"  >
                                     <ItemTemplate>  

                                        
                                     </ItemTemplate>
                                 </asp:Repeater>

                             </ItemTemplate>
                         </XS:RepeaterList>
                         <XS:PagesContrl ID="pgCtr" PageSize="1" runat="server" />  
                         
                         
                         
                         
 <XS:RepeaterList  ID="rpGetSubClassList" runat="server">
            <ItemTemplate>
                <div class="smdata">
                    <div class="booktit">
                        <li class="xgqname">
                            <%#Eval("ClassName")%></li>
                    </div>
                    <div class="dbbtn">
                        <li><a href="#">顶部</a></li></div>
                </div>
                <asp:Repeater ID="rpsub" runat="server">
                    <ItemTemplate>
                        <div class="menulst">
                            <li>
                                <img src="<%=base.ThemeCss%>images/ico3.png" />
                                <a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("HtmlName"),1,GetSiteID) %>">
                                    <%#Eval("ClassName")%>
                                </a>
                            </li>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                 <asp:Repeater ID="rpContrent" runat="server">
                    <ItemTemplate>
                       
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </XS:RepeaterList>
        
        
<%=EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.Copyright %>
<%=KeepUserState()%>

</body>
</html>
