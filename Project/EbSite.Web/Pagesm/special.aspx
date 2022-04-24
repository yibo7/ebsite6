<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="special.aspx.cs" Inherits="EbSite.Web.Pagesm.special" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <asp:Repeater ID="rpSpecialList" runat="server"  >
                             <ItemTemplate>                                      
                                 <li >
                                   <input  type="checkbox" value="'id':' <%#Eval("ID")%>','n':' <%#Eval("NewsTitle")%>','u':' <%#Eval("HtmlName")%>'" />
                                   <a title="<%#Eval("newstitle")%>" href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>" target="_blank">
                                            <%#Eval("newstitle")%>
                                        </a>
                                        <span> 
                                   <a title="<%#Eval("classname")%>" href="<%#EbSite.Base.Host.Instance.GetClassHref(int.Parse(Eval("classid").ToString()),0)%>" target="_blank">
                                            <%#Eval("classname")%>
                                        </a></span> 
                                        
                                 </li>
                             </ItemTemplate>
                </asp:Repeater> 
                  <XS:PagesContrl ID="pgCtr" runat="server" /> 
</body>
</html>
