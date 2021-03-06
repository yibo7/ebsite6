<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="album.aspx.cs" Inherits="EbSite.Web.Pages.album" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

             <asp:Repeater ID="rpAlbum" runat="server"  >
                             <ItemTemplate>
                             <ul>
                              <li class="list_title">
                                <a href="<%#HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%#Eval("newstitle")%></a>
                              </li>                            
                              </ul>
                             </ItemTemplate>
                         </asp:Repeater>

                         <asp:Repeater ID="rpContentList" runat="server"  >
                             <ItemTemplate>
                             
                             <ul>
                              <li class="list_title">
                                <a href="<%#HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%#Eval("newstitle")%></a>
                              </li>
                              <li class="text">                                
                                 <a href="<%#HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>">[阅读全文]</a></a></li>
                             
                              </ul>
                             </ItemTemplate>
                         </asp:Repeater>


            <XS:PagesContrl ID="pgCtr" runat="server" /> 
    
    
</body>
</html>
